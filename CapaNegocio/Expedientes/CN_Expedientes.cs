using CapaDatos.Expedientes;
using CapaEntidades.Expedientes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace CapaNegocio.Expedientes
{
    public class CN_Expedientes
    {
        /// <summary>
        /// Metodo para obtener los expedientes, devolviendo una lista de objetos
        /// </summary>
        public static List<CE_Expediente> ObtenerExpedientes()
        {
            CD_Expedientes datos = new CD_Expedientes();
            return datos.ObtenerExpedientes();
        }

        /// <summary>
        /// Metodo para buscar un expediente por su Id
        /// </summary>
        public static CE_Expediente BuscarById(int id)
        {
            CD_Expedientes datos = new CD_Expedientes();
            return datos.BuscarById(id);
        }

        /// <summary>
        /// Metodo para buscar un expediente por su Id desde una lista
        /// </summary>
        public static CE_Expediente BuscarById(List<CE_Expediente> lista, int id)
        {
            return lista.Find(e => e.ID == id);
        }

        /// <summary>
        /// Metodo para Guarda & Modificar
        /// </summary>
        public static string Salvar(CE_Expediente expediente)
        {
            CD_Expedientes datos = new CD_Expedientes();
            return datos.Salvar(expediente);
        }
    }
}
