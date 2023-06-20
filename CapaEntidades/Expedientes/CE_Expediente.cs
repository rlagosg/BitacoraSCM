using System;
using System.Collections.Generic;
using System.Text;

namespace CapaEntidades.Expedientes
{
    public class CE_Expediente
    {
        public int ID                 { get; set; }
        public string Expediente      { get; set; }        
        public DateTime? Iniciado     { get; set; }
        public int IdIniciador        { get; set; }
        public string Iniciador       { get; set; }
        public string ObsInicial      { get; set; }
        public string Proceso         { get; set; }
        public string Estado          { get; set; }
        public string Comentario      { get; set; }
        public int IdEncargado        { get; set; }
        public string Encargado       { get; set; }
        public string UltCambio       { get; set; }
        public DateTime? Finalizacion { get; set; }
        public string ObsFinal        { get; set; }
        public int Rol                { get; set; }

        public CE_Expediente()
        {
            this.ID  =  0;
            this.Rol = -1;
        }

        public CE_Expediente(
            int iD, string expediente, DateTime? iniciado, 
            int idIniciador, string iniciador, string obsInicial, 
            string proceso,  string estado,    string comentario, 
            int idEncargado, string encargado, string ultCambio, 
            DateTime? finalizacion, string obsFinal, int rol = -1)
        {
            this.ID           = iD;
            this.Expediente   = expediente;
            this.Iniciado     = iniciado;
            this.IdIniciador  = idIniciador;
            this.Iniciador    = iniciador;
            this.ObsInicial   = obsInicial;
            this.Proceso      = proceso;
            this.Estado       = estado;
            this.Comentario   = comentario;
            this.IdEncargado  = idEncargado;
            this.Encargado    = encargado;
            this.UltCambio    = ultCambio;
            this.Finalizacion = finalizacion;
            this.ObsFinal     = obsFinal;
            this.Rol          = rol;
        }
    }
}
