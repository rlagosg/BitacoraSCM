using CapaDatos.Expedientes;
using CapaDatos.Personas;
using CapaEntidades.Expedientes;
using CapaEntidades.Personas;
using CapaEntidades.Roles;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace CapaNegocio.Expedientes
{
    public class CN_Controles
    {
        /// <summary>
        /// //metodo para enlistar controles con filtro por el nombre del expediente
        /// </summary>   
        public static DataTable Listar(CE_Busqueda busqueda)
        {
            CD_Controles datos = new CD_Controles();
            return datos.Listar(busqueda);
        }

        /// <summary>
        /// obtiene los estados del expediente segun el rol en forma de Tabla
        /// </summary>
        public static DataTable Estados(CE_Control expediente)
        {
            CD_Controles datos = new CD_Controles();
            return datos.Estados(expediente);
        }

        /// <summary>
        /// obtiene los estados del expediente segun el rol en una lista
        /// </summary>
        public static List<CE_EstadoExpediente> ObtenerEstados(CE_Control expediente)
        {
            CD_Controles datos = new CD_Controles();
            return datos.ObtenerEstados(expediente);
        }

        /// <summary>
        /// obtiene TODOS los estados del expediente en Resumen retorna una Tabla
        /// </summary>
        public static DataTable Resumen(CE_Control expediente)
        {
            CD_Controles datos = new CD_Controles();
            return datos.Resumen(expediente);
        }

        /// <summary>
        /// Metodo para Crear un nuevo Control
        /// </summary>
        public static string Salvar(CE_CambioProceso cambio)
        {
            CD_Controles datos = new CD_Controles();
            return datos.Salvar(cambio);
        }
        
    }
}
