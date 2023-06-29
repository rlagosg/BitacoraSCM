using System;
using System.Collections.Generic;
using System.Text;

namespace CapaEntidades.Expedientes
{
    public class CE_Expediente
    {
        public int ID            { get; set; }
        public string Expediente { get; set; }

        public CE_Expediente(string expediente)   
        { 
            ID         = 0;
            Expediente = expediente;
        }

        public CE_Expediente(int iD, string expediente)
        {
            ID         = iD;
            Expediente = expediente;
        }
    }
}
