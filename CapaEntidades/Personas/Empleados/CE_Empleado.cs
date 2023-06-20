using System;
using System.Collections.Generic;
using System.Text;

namespace CapaEntidades.Personas.Empleados
{
    public class CE_Empleado
    {
        public int ID         {  get; set; }
        public string IdPersona  { get; set; }
        public string Nombre  { get; set; }

        public CE_Empleado() 
        {
            ID = 0;
        }
        public CE_Empleado(int iD, string idPersona, string nombre)
        {
            ID         = iD;
            IdPersona  = idPersona;
            Nombre     = nombre;
        }
    }
}
