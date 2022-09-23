using ServerApp.Models;
using ServerApp.Translator;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ServerApp
{
    public class Server
    {
        private Socket serverSocket;
        private List<Client> clients;
        private List<Socket> clientSockets;
        private List<Response> requests;
        public Action<List<Response>> RequestProcessHanlder;
        public Action<List<Client>> ClientConnectedHandler;
        public EndPoint ServerEndPoint
        {
            get
            {
                if (serverSocket != null)
                {
                    return serverSocket.LocalEndPoint;
                }
                return null;
            }
        }
        public Server(string ipAddress, int port)
        {
            IPEndPoint ipEndpoint = new IPEndPoint(IPAddress.Parse(ipAddress), port);
            serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            serverSocket.Bind(ipEndpoint);
            clientSockets = new List<Socket>();
            requests = new List<Response>();
            clients = new List<Client>();
        }

        public void Listen()
        {
            serverSocket.Listen(100);
            new Task(() =>
            {
                while (true)
                {
                    try
                    {
                        Socket clientSocket = serverSocket.Accept();
                        clientSockets.Add(clientSocket);
                        clients.Add(new Client
                        {
                            IPAddress = clientSocket.RemoteEndPoint.ToString(),
                            Status = "Connected",
                            ConnectedAt = DateTime.Now
                        });
                        ClientConnectedHandler?.Invoke(clients);
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
            while (clientSocket.Connected)
            {
                try
                {
                    Response res = ProcessRequest(clientSocket);
                    
                    clientSocket.Send(Encoding.UTF8.GetBytes(res.Result));
                    requests.Add(res);
                    RequestProcessHanlder?.Invoke(requests);
                }
                catch (SocketException)
                {
                    //Console.WriteLine($"Client {clientSocket.RemoteEndPoint} disconnected");
                    clients = clients.Where(x => x.IPAddress != clientSocket.RemoteEndPoint.ToString()).ToList();
                    ClientConnectedHandler?.Invoke(clients);
                    clientSocket.Close();
                    break;
                }
            }
        }

        public Response ProcessRequest(Socket clientSocket)
        {
            byte[] buffer = new byte[1024];
            int size = clientSocket.Receive(buffer);
            ITranslator translator = TranslatorFactory.GetInstance("vi");
            string number = Encoding.UTF8.GetString(buffer).Replace("\0", "");
            string result = translator.Translate(number);
            return new Response
            {
                ClientIP = clientSocket.RemoteEndPoint.ToString(),
                Language = "vi",
                Number = number,
                Result = result
            };
        }

        public void Disconnect()
        {
            serverSocket.Close();
            foreach (Socket clientSocket in clientSockets)
            {
                clientSocket.Shutdown(SocketShutdown.Both);
            }
            serverSocket = null;
        }
    }
}
