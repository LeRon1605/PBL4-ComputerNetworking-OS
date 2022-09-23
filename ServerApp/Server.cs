using Models.DTO;
using Models.Entities;
using Models.Mapper;
using ServerApp.Translator;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace ServerApp
{
    public class Server
    {
        private Socket Socket;

        private Repository Repository;

        public Action<List<Response>> OnReceiveData;
        public Action<List<Client>> OnClientConnectionStateChanged;

        public Server()
        {
            Repository = new Repository();
        }

        public void Listen(string ipAddress, int port)
        {
            Socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            Socket.Bind(new IPEndPoint(IPAddress.Parse(ipAddress), port));
            Socket.Listen(100);
            new Task(() =>
            {
                while (true)
                {
                    try
                    {
                        Socket clientSocket = Socket.Accept();
                        Repository.AddClient(clientSocket);
                        OnClientConnectionStateChanged?.Invoke(Repository.Clients);
                        Task task = new Task(() => Receive(clientSocket));
                        task.Start();
                    }
                    catch (SocketException)
                    {
                        break;
                    }
                }
            }).Start();
        }

        public void Receive(Socket clientSocket)
        {
            while (!((clientSocket.Poll(1000, SelectMode.SelectRead) && (clientSocket.Available == 0)) || !clientSocket.Connected))
            {
                try
                {
                    Response res = ProcessRequest(clientSocket);
                    if (res != null)
                    {
                        clientSocket.Send(Encoding.UTF8.GetBytes(Mapper.MapRequest(res).Serialize()));
                        OnReceiveData?.Invoke(Repository.Responses);
                    }
                }
                catch (SocketException)
                {
                    break;
                }
            }
            Repository.RemoveClient(clientSocket);
            OnClientConnectionStateChanged?.Invoke(Repository.Clients);
            clientSocket.Shutdown(SocketShutdown.Both);
            clientSocket.Close();
        }

        public Response ProcessRequest(Socket clientSocket)
        {
            byte[] buffer = new byte[1024];
            int size = clientSocket.Receive(buffer);
            if (size <= 0)
            {
                return null;
            }
            RequestDTO request = RequestDTO.Deserialize(Encoding.UTF8.GetString(buffer).Replace("\0", ""));
            string result = TranslatorFactory.GetInstance(request.Lang).Translate(request.Number);
            return new Response
            {
                Lang = request.Lang,
                Number = request.Number,
                Text = result,
                Status = (result != null),
                Exception = null,
                Client = clientSocket.RemoteEndPoint.ToString(),
                ResponseAt = DateTime.Now
            };
        }

        public bool IsListening()
        {
            try
            {
                return Socket != null && Socket.IsBound && !(Socket.Poll(1, SelectMode.SelectRead) && Socket.Available == 0);
            }
            catch (Exception)
            {
                return false;
            }
        }

        public void Disconnect()
        {
            foreach (Socket clientSocket in Repository.ClientSockets)
            {
                clientSocket.Shutdown(SocketShutdown.Both);
            }
            
            if (Socket != null)
            {
                Socket.Close();
            }

            Repository.Clear();
            OnClientConnectionStateChanged?.Invoke(Repository.Clients);
        }
    }
}
