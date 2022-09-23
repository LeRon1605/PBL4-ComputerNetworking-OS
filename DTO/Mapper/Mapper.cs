using Models.DTO;
using Models.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Models.Mapper
{
    public class Mapper
    {
        public static ResponseDTO MapRequest(Response src)
        {
            return new ResponseDTO
            {
                Text = src.Text,
                Status = src.Status,
                Exception = src.Exception,
                Lang = src.Lang,
                Number = src.Number,
            };
        }
    }
}
