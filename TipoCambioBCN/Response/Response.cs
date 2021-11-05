using System;

namespace TipoCambioBCN.Response
{
    public class Response
    {
        public bool IsSuccess { get; set; }

        public string Message { get; set; }

        public double Dolar { get; set; }
      
        public string Fecha { get; set; }
    }
}
