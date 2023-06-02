using CapaDatos.Controles;
using CapaDatos.Personas;
using CapaEntidades.Personas;
using CapaEntidades.Roles;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace CapaNegocio.Roles
{
    public class CN_Roles
    {
        public static DataTable Listar()
        {
            CD_Roles datos = new CD_Roles();
            return datos.Listar();
        }

        public static List<CE_Rol> ObtenerRoles()
        {
            CD_Roles datos = new CD_Roles();
            return datos.ObtenerRoles();
        }
    }
}
