using ClientApp.Models;
using ClientApp.Repository;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace ClientApp
{
    public class Client
    {
        private Socket socket;

        public Action<string> OnReceiveMessage;
        public Action OnDisconnected;
        public Client(string ipAddress, int port)
        {
            socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            socket.Connect(new IPEndPoint(IPAddress.Parse(ipAddress), port));
            new Task(async () =>
            {
                while (IsConnected())
                {
                    await Task.Delay(1000);
                };
                Disconnect();
                OnDisconnected?.Invoke();
            }).Start();
        }

        public void Send(string data)
        {
            if (socket != null)
            {
                new Task(() =>
                {
                    try
                    {
                        socket.Send(Encoding.UTF8.GetBytes(data));
                        string result = ProcessReceiveMessage();
                        RequestRepository.GetInstance().Repository.Add(new Request
                        {
                            Server = socket.RemoteEndPoint.ToString(),
                            Number = data,
                            RequestAt = DateTime.Now,
                            Response = result
                        });
                        OnReceiveMessage?.Invoke(result);
                    }
                    catch (SocketException)
                    {
                        OnDisconnected?.Invoke();
                    }
                }).Start();
            }
        }

        public string ProcessReceiveMessage()
        {
            byte[] buffer = new byte[256];
            socket.Receive(buffer);
            return Encoding.UTF8.GetString(buffer);
        }
        
        public bool IsConnected()
        {
            try
            {
                return (socket != null && !((socket.Poll(1000, SelectMode.SelectRead) && (socket.Available == 0)) || !socket.Connected));
            }
            catch (ObjectDisposedException)
            {
                return false;
            }
        }

        public void Disconnect()
        {
            if (socket != null)
            {
                socket.Shutdown(SocketShutdown.Both);
                socket.Close();
                socket = null;
            }
        }
    }
}
