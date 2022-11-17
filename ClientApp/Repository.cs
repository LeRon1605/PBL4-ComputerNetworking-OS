using Models.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ClientApp
{
    public class Repository
    {
        public List<RequestLog> Requests { get; set; }
        public Repository()
        {
            Requests = new List<RequestLog>();
        }
    }
}
