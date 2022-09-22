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
        private List<Socket> clients;
        private List<Request> requests;
        public Action<List<Request>> RequestProcessHanlder;
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
            clients = new List<Socket>();
            requests = new List<Request>();
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
                        clients.Add(clientSocket);
                        ClientConnectedHandler?.Invoke(clients.Select(x => new Client
                        {
                            IPAddress = x.RemoteEndPoint.ToString(),
                            Status = "Connected"
                        }).ToList());
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
                byte[] buffer = new byte[1024];
                try
                {
                    int size = clientSocket.Receive(buffer);
                    ITranslator translator = new VietnameseTranslator();
                    string number = Encoding.UTF8.GetString(buffer).Replace("\0", "");
                    string result = translator.Translate(number);
                    clientSocket.Send(Encoding.UTF8.GetBytes(result));
                    requests.Add(new Request
                    {
                        ClientIP = clientSocket.RemoteEndPoint.ToString(),
                        Language = "vi",
                        Number = number,
                        Result = result
                    });
                    RequestProcessHanlder?.Invoke(requests);
                }
                catch (SocketException e)
                {
                    //Console.WriteLine($"Client {clientSocket.RemoteEndPoint} disconnected");
                    clientSocket.Close();
                    break;
                }
            }
        }

        public void Disconnect()
        {
            serverSocket.Close();
            foreach (Socket clientSocket in clients)
            {
                clientSocket.Close();
            }
            serverSocket = null;
        }
    }
}
