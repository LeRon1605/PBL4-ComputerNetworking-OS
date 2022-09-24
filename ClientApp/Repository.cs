using Models.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ClientApp
{
    public class Repository
    {
        private static Repository Instance;
        public List<RequestLog> Requests { get; set; }
        private Repository()
        {
            Requests = new List<RequestLog>();
        }

        public static Repository GetInstance()
        {
            if (Instance == null)
            {
                Instance = new Repository();
            }
            return Instance;
        }
    }
}
