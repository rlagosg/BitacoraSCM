using CapaDatos.Personas;
using CapaEntidades.Personas;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace CapaNegocio.Personas
{
    public class CN_Municipios
    {
        public static DataTable Listar(string texto)
        {
            CD_Municipios datos = new CD_Municipios();
            return datos.Listar(texto);
        }

        public static string Salvar(int opcion, CE_Municipio municipio)
        {
            CD_Municipios datos = new CD_Municipios();
            return datos.Salvar(opcion, municipio);
        }

        public static string Eliminar(CE_Municipio municipio)
        {
            CD_Municipios datos = new CD_Municipios();
            return datos.Eliminar(municipio);
        }

        public static List<CE_Municipio> ObtenerLista()
        {
            CD_Municipios datos = new CD_Municipios();
            return datos.ObtenerMunicipios();
        }
    }
}
