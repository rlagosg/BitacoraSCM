using CapaEntidades.Personas;
using System;
using System.Collections.Generic;
using System.Text;

namespace CapaEntidades.Expedientes
{
    public class CE_Expediente
    {
        public int IdControl          { get; set; }
        public int IdExpediente       { get; set; }
        public string Expediente      { get; set; }        
        public DateTime? Iniciado     { get; set; }
        public CE_Persona Iniciador   { get; set; }
        public string ObsInicial      { get; set; }
        public string Proceso         { get; set; }
        public string Estado          { get; set; }
        public string Comentario      { get; set; }        
        public CE_Persona Encargado   { get; set; }
        public DateTime? UltCambio    { get; set; }
        public CE_Persona Finalizador { get; set; }
        public DateTime? Finalizacion { get; set; }
        public string ObsFinal        { get; set; }
        public int Rol                { get; set; }

        public CE_Expediente()
        {
            this.IdControl     =  0;
            this.IdExpediente  =  0;
            this.Rol           = -1;
        }

        public CE_Expediente(
            int iDControl, int iDExpediente, string expediente, DateTime? iniciado,
            CE_Persona iniciador, string obsInicial, 
            string proceso,  string estado,    string comentario,
            CE_Persona encargado, DateTime? ultCambio, 
            DateTime? finalizacion, string obsFinal, int rol = -1)
        {
            this.IdControl    = iDControl;
            this.IdExpediente = iDExpediente;
            this.Expediente   = expediente;
            this.Iniciado     = iniciado;
            this.Iniciador    = iniciador;
            this.ObsInicial   = obsInicial;
            this.Proceso      = proceso;
            this.Estado       = estado;
            this.Comentario   = comentario;
            this.Encargado    = encargado;
            this.UltCambio    = ultCambio;
            this.Finalizacion = finalizacion;
            this.ObsFinal     = obsFinal;
            this.Rol          = rol;
        }
    }
}
