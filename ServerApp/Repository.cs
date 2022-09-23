using Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;

namespace ServerApp
{
    public class Repository
    {
        public List<Client> Clients { get; set; }
        public List<Socket> ClientSockets { get; set; }
        public List<Response> Responses { get; set; }

        public Repository()
        {
            Clients = new List<Client>();
            ClientSockets = new List<Socket>();
            Responses = new List<Response>();
        }

        public void AddClient(Socket socket)
        {
            Clients.Add(new Client
            {
                IP = socket.RemoteEndPoint.ToString()
            });
            ClientSockets.Add(socket);
        }

        public void RemoveClient(Socket socket)
        {
            ClientSockets.Remove(socket);
            Clients = Clients.Where(x => x.IP != socket.RemoteEndPoint.ToString()).ToList();
        }

        public void Clear()
        {
            Clients.Clear();
            ClientSockets.Clear();
            Responses.Clear();
        }
    }
}
