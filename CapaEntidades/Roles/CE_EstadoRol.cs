using CapaEntidades.Roles;
using System;
using System.Collections.Generic;
using System.Text;

namespace CapaDatos.Roles
{
    public class CE_EstadoRol
    {
        public int ID             { get; set; }
        public int IdRol          { get; set; }
        public int IdEstado       { get; set; }
        public string Nombre      { get; set; }
        public string Descripcion { get; set; }
        public int Numero         { get; set; }
        public bool Activo        { get; set; }
        public CE_Estado Estado   { get; set; }

        public CE_EstadoRol()
        {
            ID = 0;
        }

        public CE_EstadoRol(int iD, int rol, int estado, string nombre, string descripcion, int numero, bool activo)
        {
            ID          = iD;
            IdRol       = rol;
            IdEstado    = estado;
            Nombre      = nombre;
            Descripcion = descripcion;
            Numero      = numero;
            Activo      = activo;
        }

        public CE_EstadoRol(CE_Rol rol, CE_Estado estado, int numero)
        {
            ID = 0;
            IdRol = rol.ID;
            IdEstado = estado.ID;
            Nombre = estado.Nombre;
            Descripcion = estado.Descripcion;
            Numero = numero;
            Activo = true;
        }

        public override string ToString()
        {
            return Nombre;
        }
    }
}
