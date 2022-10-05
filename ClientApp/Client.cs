using Models.DTO;
using Models.Entities;
using Models.Mapper;
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

        public Action<ResponseDTO> OnReceivedMessage;
        public Action OnConnectionStateChanged;

        public void Connect(string ipAddress, int port)
        {
            if (!IsConnected())
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
                    OnConnectionStateChanged?.Invoke();
                }).Start();
            }
        }

        public void Send(RequestDTO request)
        {
            if (socket != null)
            {
                new Task(() =>
                {
                    try
                    {
                        socket.Send(Encoding.UTF8.GetBytes(request.Serialize()));
                        ResponseDTO res = ProcessReceiveMessage();
                        Repository.GetInstance().Requests.Add(Mapper.MapRequest(res));
                        OnReceivedMessage?.Invoke(res);
                    }
                    catch (SocketException)
                    {
                        OnConnectionStateChanged?.Invoke();
                    }
                }).Start();
            }
        }

        public ResponseDTO ProcessReceiveMessage()
        {
            byte[] buffer = new byte[1024];
            socket.Receive(buffer);
            string d = Encoding.UTF8.GetString(buffer).Replace("\0", "");
            ResponseDTO res = ResponseDTO.Deserialize(Encoding.UTF8.GetString(buffer).Replace("\0", ""));
            return res;
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
