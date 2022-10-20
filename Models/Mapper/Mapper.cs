using Models.DTO;
using Models.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Models.Mapper
{
    public class Mapper
    {
        public static ResponseLog MapResponse(ResponseDTO src)
        {

            return new ResponseLog
            {
                Text = src.Text,
                Status = src.Status ? "Success" : "Failure",
                Exception = src.Exception,
                Lang = GetLanguage(src.Lang),
                Number = src.Number,
                Client = src.Client,
                ResponseAt = src.ResponseAt
            };
        }

        public static RequestLog MapRequest(ResponseDTO src)
        {
            return new RequestLog
            {
                Text = src.Text,
                Status = src.Status ? "Success" : "Failure",
                Exception = src.Exception,
                Lang = GetLanguage(src.Lang),
                Number = src.Number,
                Server = src.Server,
                ResponseAt = src.ResponseAt
            };
        }

        private static string GetLanguage(string languageCode)
        {
            if (languageCode == "vi")
            {
                return "Tiếng Việt";
            }
            else if(languageCode == "en")
            {
                return "Tiếng Anh";
            }
            else if (languageCode == "sp")
            {
                return "Tiếng Tây Ban Nha";
            }
            else if (languageCode == "fr")
            {
                return "Tiếng Pháp";
            }
            return null;
        }
    }
}
