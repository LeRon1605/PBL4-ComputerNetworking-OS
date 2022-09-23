using System;
using System.Collections.Generic;
using System.Text;

namespace ClientApp.Models
{
    public class Request
    {
        public string Server { get; set; }
        public string Number { get; set; }
        public string Response { get; set; }
        public DateTime RequestAt { get; set; }
        
    }
}
