using System;
using System.Collections.Generic;
using System.Text;

namespace ServerApp.Models
{
    public class Client
    {
        public string IPAddress { get; set; }
        public string Status { get; set; }
        public DateTime ConnectedAt { get; set; }
    }
}
