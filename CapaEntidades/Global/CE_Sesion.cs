using CapaEntidades.Personas.Empleados;
using CapaEntidades.Roles;
using CapaEntidades.Usuarios;
using System;
using System.Collections.Generic;
using System.Text;

namespace CapaEntidades.Global
{
    public class CE_Sesion
    {
        public CE_Empleado Empleado { get; set; }
        public CE_Rol Rol           { get; set; }
        public CE_Usuario Usuario   { get; set; }

        public CE_Sesion() { }

        public CE_Sesion(CE_Empleado empleado, CE_Rol rol)
        {
            Empleado = empleado;
            Rol      = rol;
            //Usuario = usuario;
        }
    }
}
