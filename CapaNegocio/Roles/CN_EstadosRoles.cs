using CapaDatos.Controles;
using CapaDatos.Roles;
using CapaEntidades.Roles;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace CapaNegocio.Roles
{
    public class CN_EstadosRoles
    {
        public static DataTable Listar(CE_Rol rol)
        {
            CD_EstadosRoles datos = new CD_EstadosRoles();
            return datos.Listar(rol);
        }

        public static string Salvar(CE_EstadoRol estado)
        {
            CD_EstadosRoles datos = new CD_EstadosRoles();
            return datos.Salvar(estado);
        }

        public static string DeshabilitaEstados(CE_Rol rol)
        {
            CD_EstadosRoles datos = new CD_EstadosRoles();
            return datos.DeshabilitaEstados(rol);
        }

        public static List<CE_EstadoRol> ObtenerEstados(CE_Rol rol)
        {
            CD_EstadosRoles datos = new CD_EstadosRoles();
            return datos.ObtenerEstados(rol);
        }

        public static string ActualizarEstado(CE_EstadoRol estado)
        {
            CD_EstadosRoles datos = new CD_EstadosRoles();
            return datos.ActualizarEstado(estado);
        }

        /// <summary>
        /// Metodo para buscar la lista de estados asiganados a un rol
        /// </summary>
        public static List<CE_EstadoRol> ListaEstadosByRol(CE_Rol Rol)
        {
            CD_EstadosRoles datos = new CD_EstadosRoles();
            return datos.ListaEstadosByRol(Rol);

        }
    }
}
