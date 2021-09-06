using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CitasApi.DTO
{
    public class MensajeDTO
    {
        public int Code { get; set; }
        public object Data { get; set; }

        public MensajeDTO(int code, object obj)
        {
            Code = code;
            Data = obj;
        }
    }
}
