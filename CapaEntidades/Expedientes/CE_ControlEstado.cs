using CapaDatos.Roles;
using CapaEntidades.Personas.Empleados;
using System;
using System.Collections.Generic;
using System.Text;

namespace CapaEntidades.Expedientes
{
    public class CE_ControlEstado
    {
        public int ID                 { get; set; }
        public int IdCambioProceso      { get; set; }        
        public CE_Empleado Encargado  { get; set; }
        public CE_EstadoRol EstadoRol { get; set; }
        public bool Compleato         { get; set; }        
        //public TimeSpan Duracion      { get; set; }        

        public CE_ControlEstado() 
        {
            ID = 0;
        }

        public CE_ControlEstado(int iD, int idCambioProceso, CE_Empleado encargado, 
            CE_EstadoRol estadoRol, bool completado)//, 
            //TimeSpan duracion)
        {
            ID               = iD;
            IdCambioProceso  = idCambioProceso;            
            Encargado        = encargado;
            EstadoRol        = estadoRol;
            Compleato        = completado;            
            //Duracion         = duracion;            
        }
    }
}
