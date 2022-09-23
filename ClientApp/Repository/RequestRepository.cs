using ClientApp.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ClientApp.Repository
{
    public class RequestRepository
    {
        private static RequestRepository _Instance;
        public List<Request> Repository { get; set; }
        private RequestRepository()
        {
            Repository = new List<Request>();  
        }

        public static RequestRepository GetInstance()
        {
            if (_Instance == null)
            {
                _Instance = new RequestRepository();
            }
            return _Instance;
        }



    }
}
