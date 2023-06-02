using System;
using System.Collections.Generic;
using System.Text;

namespace CapaEntidades.Roles
{
    public class CE_Estado
    {
        public int ID             { get; set; }
        public string Nombre      { get; set; }
        public string Descripcion { get; set; }

        public CE_Estado()
        {
            ID = 0;
        }

        public CE_Estado(int iD, string nombre, string descripcion)
        {
            ID          = iD;
            Nombre      = nombre;
            Descripcion = descripcion;
        }
    }
}
