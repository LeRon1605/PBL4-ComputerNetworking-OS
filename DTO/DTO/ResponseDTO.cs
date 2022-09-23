using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Models.DTO
{
    public class ResponseDTO
    {
        public string Lang { get; set; }
        public string Number { get; set; }
        public string Text { get; set; }
        public bool Status { get; set; }
        public string Exception { get; set; }
        public static ResponseDTO Deserialize(string obj)
        {
            return JsonConvert.DeserializeObject<ResponseDTO>(obj);
        }

        public string Serialize()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
