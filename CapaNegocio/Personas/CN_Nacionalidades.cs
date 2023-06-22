using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using CapaEntidades.Personas;
using CapaDatos.Personas;

namespace CapaNegocio.Personas
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

        public static string Eliminar(CE_Nacionalidades nacionalidad)
        {
            CD_Nacionalidades datos = new CD_Nacionalidades();
            return datos.Eliminar(nacionalidad);
        }

        public static List<CE_Nacionalidades> ObtenerLista()
        {
            CD_Nacionalidades datos = new CD_Nacionalidades();
            return datos.ObtenerNacionalidades();
        }

        public static CE_Nacionalidades BuscarByNacionalidad(string nacionalidad)
        {
            CD_Nacionalidades datos = new CD_Nacionalidades();
            return datos.BuscarByNacionalidad(nacionalidad);
        }
    }
}
