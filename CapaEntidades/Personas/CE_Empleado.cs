using System;
using System.Collections.Generic;
using System.Text;

namespace CapaEntidades.Personas
{
    public class CE_Empleado
    {
        public int IdEmpleado     { get; set; }
        public int Persona        { get; set; }
        public int ActivoEmpleado { get; set; }

        public CE_Empleado() { }

        public CE_Empleado(int idEmpleado, int persona, int activoEmpleado)
        {
            IdEmpleado     = idEmpleado;
            Persona        = persona;
            ActivoEmpleado = activoEmpleado;
        }
    }
}
