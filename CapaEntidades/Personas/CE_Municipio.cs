using System;
using System.Collections.Generic;
using System.Text;

namespace CapaEntidades.Personas
{
    public class CE_Municipio
    {
        public int ID             { get; set; }
        public string Nombre      { get; set; }
        public string Descripcion { get; set;}

        public CE_Municipio() {
            ID = 0;
        }

        public CE_Municipio(int iD, string nombre, string descripcion)
        {
            ID          = iD;
            Nombre      = nombre;
            Descripcion = descripcion;
        }
    }
}
