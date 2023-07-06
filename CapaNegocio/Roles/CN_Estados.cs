using CapaDatos.Controles;
using CapaDatos.Personas;
using CapaDatos.Roles;
using CapaEntidades.Personas;
using CapaEntidades.Roles;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace CapaNegocio.Roles
{
    public class CN_Estados
    {
        public static DataTable Listar(string texto = "")
        {
            CD_Estados datos = new CD_Estados();
            return datos.Listar(texto);
        }

        public static List<CE_Estado> ObtenerEstados()
        {
            CD_Estados datos = new CD_Estados();
            return datos.ObtenerEstados();
        }

        public static List<CE_Estado> ObtenerEstadosExcluidos(CE_Rol rol)
        {
            CD_Estados datos = new CD_Estados();
            return datos.ObtenerEstadosExcluidos(rol);
        }

        public static string Salvar(int opcion, CE_Estado estado)
        {
            CD_Estados datos = new CD_Estados();
            return datos.Salvar(opcion, estado);
        }

        public static string Eliminar(CE_Estado estado)
        {
            CD_Estados datos = new CD_Estados();
            return datos.Eliminar(estado);
        }

        /// <summary>
        /// Metodo para buscar un estado por su Id
        /// </summary>
        public static CE_Estado BuscarById(int id)
        {
            CD_Estados datos = new CD_Estados();
            return datos.BuscarById(id);
        }
    }
}
