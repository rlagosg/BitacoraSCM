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
        public static DataTable Listar(string texto)
        {
            CD_Expedientes datos = new CD_Expedientes();
            return datos.Listar(texto);
        }

        public static DataTable Estados(CE_Expediente expediente)
        {
            CD_Expedientes datos = new CD_Expedientes();
            return datos.Estados(expediente);
        }

        public static List<CE_EstadoExpediente> ObtenerEstados(CE_Expediente expediente)
        {
            CD_Expedientes datos = new CD_Expedientes();
            return datos.ObtenerEstados(expediente);
        }
    }
}
