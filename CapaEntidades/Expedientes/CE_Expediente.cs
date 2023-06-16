using System;
using System.Collections.Generic;
using System.Text;

namespace CapaEntidades.Expedientes
{
    public class CE_Expediente
    {
        public int ID            { get; set; }
        public string Expediente { get; set; }

        public CE_Expediente()
        {
            this.ID = 0;
        }

        public CE_Expediente(int id, string expediente)
        {

            this.ID         = id;
            this.Expediente = expediente;
        }
    }
}
