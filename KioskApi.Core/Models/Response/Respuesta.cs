using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KioskApi.Core.Models.Response
{
    public class Respuesta
    {
        public int Successfull { get; set; }
        public string Message { get; set; }
        public object Data { get; set; }

        public Respuesta()
        {
            this.Successfull = 0;
        }


    }
}
