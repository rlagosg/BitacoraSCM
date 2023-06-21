using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using CapaDatos.Personas;
using CapaEntidades.Personas;

namespace CapaNegocio.Personas
{
    public class CN_Personas
    {
        public static DataTable Listar(string texto, int op = 0)
        {
            CD_Personas datos = new CD_Personas();
            return datos.Listar(texto, op);
        }

        public static string Salvar(int opcion, CE_Persona persona)
        {
            CD_Personas datos = new CD_Personas();
            return datos.Salvar(opcion, persona);
        }

        public static string Eliminar(CE_Persona persona)
        {
            CD_Personas datos = new CD_Personas();
            return datos.Eliminar(persona);
        }
    }
}
