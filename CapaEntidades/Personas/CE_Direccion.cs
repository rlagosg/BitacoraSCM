using System;
using System.Collections.Generic;
using System.Text;

namespace CapaEntidades.Personas
{
    public class CE_Direccion
    {
        public int ID             { get; set; }
        public string Nombre      { get; set; }
        public string Descripcion { get; set; }
        public int IdMuni         { get; set; }
        public int IdTipo         { get; set; }

        public CE_Direccion() { 
            ID = 0;
        }

        public CE_Direccion(int iD, string nombre, string descripcion, int muni, int tipo)
        {
            ID          = iD;
            Nombre      = nombre;
            Descripcion = descripcion;
            IdMuni      = muni;
            IdTipo      = tipo;
        }
    }
}
