using CapaDatos.Personas;
using CapaEntidades.Personas;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace CapaNegocio.Personas
{
    public class CN_Direcciones
    {
        public static DataTable Listar(string texto, string parametro = null)
        {
            CD_Direcciones datos = new CD_Direcciones();
            return datos.Listar(texto, parametro);
        }

        public static string Salvar(int opcion, CE_Direccion direccion)
        {
            CD_Direcciones datos = new CD_Direcciones();
            return datos.Salvar(opcion, direccion);
        }

        public static string Eliminar(CE_Direccion direccion)
        {
            CD_Direcciones datos = new CD_Direcciones();
            return datos.Eliminar(direccion);
        }

        public static List<CE_Direccion> ObtenerLista()
        {
            CD_Direcciones datos = new CD_Direcciones();
            return datos.ObtenerDirecciones();
        }
    }
}
