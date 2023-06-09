﻿using CapaDatos.Expedientes;
using CapaDatos.Roles;
using CapaEntidades.Expedientes;
using CapaEntidades.Roles;
using System;
using System.Collections.Generic;
using System.Text;

namespace CapaNegocio.Expedientes
{
    public class CN_ControlEstados
    {
        /// <summary>
        /// Metodo para obtener los control de estados de un expediente
        /// devolviendo una lista de objetos
        /// </summary>        
        public static List<CE_ControlEstado> ObtenerControlesEstados()
        {
            CD_ControlEstados datos = new CD_ControlEstados();
            return datos.ObtenerControlesEstados();
        }

        /// <summary>
        /// Metodo para obtener los estados completos o pendientes de un expediente,
        /// devolviendo una lista de objetos
        /// </summary>
        public static List<CE_Estado> ObtenerTareas(CE_CambioProceso cambio, bool pendientes)
        {
            CD_ControlEstados datos = new CD_ControlEstados();
            return datos.ObtenerTareas(cambio, pendientes);
        }


        /// <summary>
        /// Metodo para obtener un control-estado de un expediente por su ID,
        /// devolviendo una objeto
        /// </summary>
        public static CE_ControlEstado BuscarById(int id)
        {
            CD_ControlEstados datos = new CD_ControlEstados();
            return datos.BuscarById(id);
        }

        /// <summary>
        /// Metodo para obtener un una lista de control-estado de un expediente por el IdCambio de Proceso,
        /// devolviendo una lista de objetos
        /// </summary>
        public static List<CE_ControlEstado> BuscarByIdCambio(int id)
        {
            CD_ControlEstados datos = new CD_ControlEstados();
            return datos.BuscarByIdCambio(id);
        }

        /// <summary>
        /// Metodo para obtener un control-estado de un expediente por su Cambio de Proceso y su EstadoRol,
        /// devolviendo una objeto
        /// </summary>
        public static CE_ControlEstado BuscarByCambioYEstado(CE_CambioProceso cambio, CE_EstadoRol EstadoRol)
        {
            CD_ControlEstados datos = new CD_ControlEstados();
            return datos.BuscarByCambioYEstado(cambio, EstadoRol);
        }

        public static CE_ControlEstado BuscarByCambioYEstadoLIST(List<CE_ControlEstado> lista, CE_CambioProceso cambio, CE_EstadoRol EstadoRol)
        {
            return lista.
                Find(c => c.IdCambioProceso == cambio.ID && c.EstadoRol.IdEstado == EstadoRol.IdEstado);
        }

        public static string Salvar(CE_ControlEstado controlEstado)
        {            
            int opcion = controlEstado.ID == 0 ? 1 : 2; // 1 guardando, 2 modificando
            CD_ControlEstados datos = new CD_ControlEstados();
            return datos.Salvar(opcion,controlEstado);           
        }
    }
}
