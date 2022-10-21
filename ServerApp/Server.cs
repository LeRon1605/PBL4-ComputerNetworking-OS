using Models.DTO;
using Models.Entities;
using Models.Mapper;
using ServerApp.Translator;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public Action<List<ResponseLog>> OnReceiveData;
        public Action<List<Client>> OnClientConnectionStateChanged;
        public Server()
        {
            Repository = new Repository();
        }

        public void Listen(string ipAddress, int port)
        {
            if (!IsListening())
            {
                Socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                Socket.Bind(new IPEndPoint(IPAddress.Parse(ipAddress), port));
                Socket.Listen(100);
                new Task(() =>
                {
                    try
                    {
                        while (true)
                        {
                            Socket clientSocket = Socket.Accept();
                            Repository.AddClient(clientSocket);
                            OnClientConnectionStateChanged?.Invoke(Repository.Clients);
                            new Task(() => Receive(clientSocket)).Start();
                        }
                    }
                    catch (SocketException)
                    {

                    }
                }).Start();
            }
        }

        public void Receive(Socket clientSocket)
        {
            while (!((clientSocket.Poll(1000, SelectMode.SelectRead) && (clientSocket.Available == 0)) || !clientSocket.Connected))
            {
                try
                {
                    ResponseDTO res = ProcessRequest(clientSocket); // throw Exception if client disconnect
                    if (res != null)
                    {
                        string m = res.Serialize();
                        clientSocket.Send(Encoding.UTF8.GetBytes(res.Serialize()));
                        Repository.Responses.Add(Mapper.MapResponse(res));
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

        public void RemoveClient(string ClientIp)
        {
            Socket clientSocket = Repository.GetSocket(ClientIp);
            if (clientSocket != null)
            {
                clientSocket.Shutdown(SocketShutdown.Both);
                Repository.RemoveClient(ClientIp);
                OnClientConnectionStateChanged?.Invoke(Repository.Clients);
            }
        }

        public ResponseDTO ProcessRequest(Socket clientSocket)
        {
            byte[] buffer = new byte[16384];
            int size = clientSocket.Receive(buffer);
            if (size <= 0)
            {
                return null;
            }
            RequestDTO request = RequestDTO.Deserialize(Encoding.UTF8.GetString(buffer).Replace("\0", ""));
            string result = TranslatorFactory.GetInstance(request.Lang).Translate(request.Number);
            return new ResponseDTO
            {
                Lang = request.Lang,
                Number = request.Number,
                Text = result,
                Status = (result != null),
                Exception = (result != null) ? "" : "Not a number",
                Client = clientSocket.RemoteEndPoint.ToString(),
                Server = Socket.LocalEndPoint.ToString(),
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
            OnReceiveData?.Invoke(Repository.Responses);
            OnClientConnectionStateChanged?.Invoke(Repository.Clients);
        }
    }
}
