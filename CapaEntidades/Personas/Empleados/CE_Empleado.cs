using System;
using System.Collections.Generic;
using System.Text;

namespace CapaEntidades.Personas.Empleados
{
    public class CE_Empleado
    {
        public int ID             {  get; set; }
        public CE_Persona Persona { get; set; }

        //public CE_Persona Persona { get; set; }

        public CE_Empleado() 
        {
            ID = 0;
        }
        public CE_Empleado(int iD, CE_Persona persona)
        {
            ID         = iD;
            Persona    = persona;            
        }
    }
}
