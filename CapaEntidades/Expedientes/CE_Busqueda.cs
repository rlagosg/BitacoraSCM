using System;
using System.Collections.Generic;
using System.Text;

namespace CapaEntidades.Expedientes
{
    public class CE_Busqueda
    {
        public string texto          { get; set; }
        public DateTime? fechaInicio { get; set; }
        public DateTime? fechaFin    { get; set; }
        public int idEncargado       { get; set; }
        public bool finalizados      { get; set; }

        public CE_Busqueda() 
        {
            this.texto       = "";
            this.fechaInicio = null;
            this.fechaFin    = null;
            this.idEncargado = 0;
            this.finalizados = false;
        }

        public CE_Busqueda(string texto)
        {
            this.texto       = texto;
            this.fechaInicio = null;
            this.fechaFin    = null;
            this.idEncargado = 0;
            this.finalizados = false;
        }

        public CE_Busqueda(string texto, DateTime? fechaInicio, DateTime? fechaFin, int idEncargado, bool finalizados)
        {
            this.texto       = texto;
            this.fechaInicio = fechaInicio;
            this.fechaFin    = fechaFin;
            this.idEncargado = idEncargado;
            this.finalizados = finalizados;
        }
    }
}
