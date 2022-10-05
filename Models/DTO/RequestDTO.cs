using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Models.DTO
{
    public class RequestDTO
    {
        public string Lang { get; set; }
        public string Number { get; set; }
        public static RequestDTO Deserialize(string obj)
        {
            return JsonConvert.DeserializeObject<RequestDTO>(obj);
        }

        public string Serialize()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
