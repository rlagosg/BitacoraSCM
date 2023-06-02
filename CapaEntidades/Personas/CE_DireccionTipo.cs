using System;
using System.Collections.Generic;
using System.Text;

namespace CapaEntidades.Personas
{
    public class CE_DireccionTipo
    {
        public int ID             { get; set; }
        public string Nombre      { get; set; }
        public string Descripcion { get; set; }
        public string Tipo        { get; set; }

        public CE_DireccionTipo() { 
            this.ID = 0;
        }

        public CE_DireccionTipo(int iD, string nombre, string descripcion, string tipo)
        {
            ID          = iD;
            Nombre      = nombre;
            Descripcion = descripcion;
            Tipo        = tipo;
        }
    }
}
