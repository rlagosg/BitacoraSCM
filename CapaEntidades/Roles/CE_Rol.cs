using System;
using System.Collections.Generic;
using System.Text;

namespace CapaEntidades.Roles
{
    public class CE_Rol
    {
        public int ID             { get; set; }
        public string Nombre      { get; set; }
        public string Descripcion { get; set; }

        public CE_Rol()
        {
            ID = 0;
        }

        public CE_Rol(int iD, string nombre, string descripcion)
        {
            ID          = iD;
            Nombre      = nombre;
            Descripcion = descripcion;
        }
    }
}
