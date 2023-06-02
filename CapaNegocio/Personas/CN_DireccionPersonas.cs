using CapaDatos.Personas;
using CapaEntidades.Personas;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace CapaNegocio.Personas
{
    public class CN_DireccionPersonas
    {
        public static DataTable Listar( string parametro )
        {
            CD_DireccionPersonas datos = new CD_DireccionPersonas();
            return datos.Listar( parametro );
        }

        public static string Salvar(int opcion, CE_DireccionPersona direccion)
        {
            CD_DireccionPersonas datos = new CD_DireccionPersonas();
            return datos.Salvar(opcion, direccion);
        }

        public static string Eliminar(CE_DireccionPersona direccion)
        {
            CD_DireccionPersonas datos = new CD_DireccionPersonas();
            return datos.Eliminar(direccion);
        }
    }
}
