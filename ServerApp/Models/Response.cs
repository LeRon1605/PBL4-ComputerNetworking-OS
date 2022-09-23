using System;
using System.Collections.Generic;
using System.Text;

namespace ServerApp.Models
{
    public class Response
    {
        public string ClientIP { get; set; }
        public string Number { get; set; }
        public string Language { get; set; }
        public string Result { get; set; }
    }
}
