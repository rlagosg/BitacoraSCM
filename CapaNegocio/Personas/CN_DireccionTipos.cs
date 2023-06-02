using CapaDatos.Personas;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace CapaEntidades.Personas
{
    public class CN_DireccionTipos
    {
        public static DataTable Listar(string texto)
        {
            CD_DireccionTipos datos = new CD_DireccionTipos();
            return datos.Listar(texto);
        }

        public static string Salvar(int opcion, CE_DireccionTipo tipo)
        {
            CD_DireccionTipos datos = new CD_DireccionTipos();
            return datos.Salvar(opcion, tipo);
        }

        public static string Eliminar(CE_DireccionTipo tipo)
        {
            CD_DireccionTipos datos = new CD_DireccionTipos();
            return datos.Eliminar(tipo);
        }

        public static List<CE_DireccionTipo> ObtenerLista(bool direccion = true)
        {
            CD_DireccionTipos datos = new CD_DireccionTipos();
            return datos.ObtenerTipos(direccion);
        }
    }
}
