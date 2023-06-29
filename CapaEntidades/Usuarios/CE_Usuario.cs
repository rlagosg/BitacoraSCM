using CapaEntidades.Personas.Empleados;
using System;
using System.Collections.Generic;
using System.Text;

namespace CapaEntidades.Usuarios
{
    public class CE_Usuario
    {
        public int IdUsuario        { get; set; }
        public string Nombre        { get; set; }
        public string Contrasenia   { get; set; }
        public CE_Empleado Empleado { get; set; }
        public bool Activo          { get; set; }

        public CE_Usuario() 
        {
            IdUsuario = 0;
        }

        public CE_Usuario(int idUsuario, string nombreUsuario, string contrasenia, CE_Empleado empleado, bool activo)
        {
            IdUsuario     = idUsuario;
            Nombre        = nombreUsuario;
            Contrasenia   = contrasenia;
            Empleado      = empleado;
            Activo        = activo;
        }
    }
}
