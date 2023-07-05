using CapaEntidades.Personas;
using CapaEntidades.Personas.Empleados;
using System;
using System.Collections.Generic;
using System.Text;

namespace CapaEntidades.Expedientes
{
    public class CE_Control
    {
        public int IdControl            { get; set; }
        public CE_Expediente Expediente { get; set; }        
        public DateTime? Iniciado       { get; set; }
        public CE_Empleado Iniciador    { get; set; }
        public string ObsInicial        { get; set; }
        public string Proceso           { get; set; }
        public string Estado            { get; set; }
        public string Comentario        { get; set; }        
        public CE_Empleado Encargado    { get; set; }
        public DateTime? UltCambio      { get; set; }
        public CE_Empleado Finalizador  { get; set; }
        public DateTime? Finalizacion   { get; set; }
        public string ObsFinal          { get; set; }
        public int Rol                  { get; set; }
        public int IdCambioProceso      { get; set; }

        public CE_Control()
        {
            this.IdControl     =  0;
            this.Expediente    =  null;
            this.Rol           = -1;
        }

        public CE_Control(CE_Expediente expediente)
        {
            this.IdControl  = 0;
            this.Expediente = expediente;
            this.Rol        = -1;
        }

        public CE_Control(
            int iDControl, CE_Expediente expediente, DateTime? iniciado,
            CE_Empleado iniciador, string obsInicial, 
            string proceso,  string estado,    string comentario,
            CE_Empleado encargado, DateTime? ultCambio, 
            DateTime? finalizacion, string obsFinal, int rol = -1, int idCambioProceso = 0)
        {
            this.IdControl       = iDControl;            
            this.Expediente      = expediente;
            this.Iniciado        = iniciado;
            this.Iniciador       = iniciador;
            this.ObsInicial      = obsInicial;
            this.Proceso         = proceso;
            this.Estado          = estado;
            this.Comentario      = comentario;
            this.Encargado       = encargado;
            this.UltCambio       = ultCambio;
            this.Finalizacion    = finalizacion;
            this.ObsFinal        = obsFinal;
            this.Rol             = rol;
            this.IdCambioProceso = idCambioProceso;
        }
    }
}
