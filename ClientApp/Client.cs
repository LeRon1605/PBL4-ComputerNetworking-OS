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
        public Client()
        {
            socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        }

        public void Connect(string ipAddress, int port)
        {
            if (socket != null)
            {
                socket.Connect(new IPEndPoint(IPAddress.Parse(ipAddress), port));
            }
        }

        public void Send(string data)
        {
            if (socket != null)
            {
                new Task(() =>
                {
                    socket.Send(Encoding.UTF8.GetBytes(data));
                    string result = ProcessReceiveMessage();
                    OnReceiveMessage?.Invoke(result);
                }).Start();
            }
        }

        public string ProcessReceiveMessage()
        {
            byte[] buffer = new byte[256];
            socket.Receive(buffer);
            return Encoding.UTF8.GetString(buffer);
        }

        public void Disconnect()
        {
            if (socket != null)
            {
                socket.Close();
                socket = null;
            }
        }
    }
}
