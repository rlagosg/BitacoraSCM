using CapaDatos.Expedientes;
using CapaEntidades.Expedientes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace CapaNegocio.Expedientes
{
    public class CN_CambiosProceso
    {
        /// <summary>
        //metodo para enlistar los cambios de proceso del expediente
        /// </summary>   
        public static DataTable Listar(CE_Control expediente)
        {
            CD_CambiosProceso datos = new CD_CambiosProceso();
            return datos.Listar(expediente);
        }
    }
}
