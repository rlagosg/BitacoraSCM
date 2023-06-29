using CapaDatos.Controles;
using CapaDatos.Usuarios;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace CapaNegocio.Usuarios
{
    public class CN_Usuarios
    {
        /// <summary>
        /// Metodo para enlistar los datos
        /// </summary>
        public static DataTable Listar(string texto = "")
        {
            CD_Usuarios datos = new CD_Usuarios();
            return datos.Listar(texto);
        }

    }
}
