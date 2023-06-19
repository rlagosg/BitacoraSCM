using System;
using System.Collections.Generic;
using System.Text;

namespace CapaEntidades.Expedientes
{
    public class CE_Expediente
    {
        public int ID            { get; set; }
        public string Expediente { get; set; }
        public int Rol           { get; set; }

        public CE_Expediente()
        {
            this.ID  = 0;
            this.Rol = -1;
        }

        public CE_Expediente(int id, string expediente, int rol = -1)
        {
            this.ID         = id;
            this.Expediente = expediente;
            this.Rol        = rol;
        }
    }
}
