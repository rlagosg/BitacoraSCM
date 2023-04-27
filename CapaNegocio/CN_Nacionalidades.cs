using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using CapaEntidades;
using CapaDatos;

namespace CapaNegocio
{
    public class CN_Nacionalidades
    {
        public static DataTable Listar(string texto)
        {
            CD_Nacionalidades datos = new CD_Nacionalidades();
            return datos.Listar(texto);
        }
        
        public static string Salvar(int opcion, CE_Nacionalidades nacionalidad)
        {
            CD_Nacionalidades datos = new CD_Nacionalidades();
            return datos.Salvar(opcion, nacionalidad);
        }

        public string Eliminar(CE_Nacionalidades nacionalidad)
        {
            CD_Nacionalidades datos = new CD_Nacionalidades();
            return datos.Eliminar(nacionalidad);
        } 
    }
}
