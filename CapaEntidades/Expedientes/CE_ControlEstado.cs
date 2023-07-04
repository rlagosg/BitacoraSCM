using CapaEntidades.Personas.Empleados;
using System;
using System.Collections.Generic;
using System.Text;

namespace CapaEntidades.Expedientes
{
    public class CE_ControlEstado
    {
        public int ID                         { get; set; }
        public CE_CambioProceso CambioProceso { get; set; }        
        public CE_Empleado Encargado          { get; set; }
        public int IDEstadoAnterior           { get; set; }
        public TimeSpan Duracion              { get; set; }
        public bool Activo                    { get; set; }

        public CE_ControlEstado() 
        {
            ID = 0;
        }

        public CE_ControlEstado(int iD, CE_CambioProceso cambioProceso, CE_Empleado encargado, int iDEstadoAnterior, TimeSpan duracion, bool activo)
        {
            ID               = iD;
            CambioProceso    = cambioProceso;            
            Encargado        = encargado;
            IDEstadoAnterior = iDEstadoAnterior;
            Duracion         = duracion;
            Activo           = activo;
        }
    }
}
