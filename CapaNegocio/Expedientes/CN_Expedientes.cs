using CapaDatos.Expedientes;
using CapaDatos.Personas;
using CapaEntidades.Expedientes;
using CapaEntidades.Personas;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace CapaNegocio.Expedientes
{
    public class CN_Expedientes
    {
        /// <summary>
        /// //metodo para enlistar expedientes con filtro por el nombre del expediente
        /// </summary>   
        public static DataTable Listar(string texto)
        {
            CD_Expedientes datos = new CD_Expedientes();
            return datos.Listar(texto);
        }

        /// <summary>
        /// obtiene los estados del expediente segun el rol en forma de Tabla
        /// </summary>
        public static DataTable Estados(CE_Expediente expediente)
        {
            CD_Expedientes datos = new CD_Expedientes();
            return datos.Estados(expediente);
        }

        /// <summary>
        /// obtiene los estados del expediente segun el rol en una lista
        /// </summary>
        public static List<CE_EstadoExpediente> ObtenerEstados(CE_Expediente expediente)
        {
            CD_Expedientes datos = new CD_Expedientes();
            return datos.ObtenerEstados(expediente);
        }

        /// <summary>
        /// obtiene TODOS los estados del expediente en Resumen retorna una Tabla
        /// </summary>
        public static DataTable Resumen(CE_Expediente expediente)
        {
            CD_Expedientes datos = new CD_Expedientes();
            return datos.Resumen(expediente);
        }
    }
}
