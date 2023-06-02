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

        public override bool Equals(object obj)
        {
            if (obj == null || !(obj is CE_Estado))
                return false;

            CE_Estado other = (CE_Estado)obj;
            return this.ID == other.ID && this.Nombre == other.Nombre && this.Descripcion == other.Descripcion;
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hash = 17;
                hash = hash * 23 + ID.GetHashCode();
                hash = hash * 23 + (Nombre != null ? Nombre.GetHashCode() : 0);
                hash = hash * 23 + (Descripcion != null ? Descripcion.GetHashCode() : 0);
                return hash;
            }
        }
    }
}
