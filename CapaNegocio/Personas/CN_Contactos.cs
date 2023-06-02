using CapaDatos.Personas;
using CapaEntidades.Personas;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace CapaNegocio.Personas
{
    public class CN_Contactos
    {
        public static DataTable Listar(string texto, CE_Persona persona)
        {
            CD_Contactos datos = new CD_Contactos();
            return datos.Listar(texto, persona);
        }

        public static string Salvar(int opcion, CE_Contacto colonia)
        {
            CD_Contactos datos = new CD_Contactos();
            return datos.Salvar(opcion, colonia);
        }

        public static string Eliminar(CE_Contacto colonia)
        {
            CD_Contactos datos = new CD_Contactos();
            return datos.Eliminar(colonia);
        }

        public static List<CE_Contacto> ObtenerLista()
        {
            CD_Contactos datos = new CD_Contactos();
            return datos.Obtenercontactos();
        }
    }
}
