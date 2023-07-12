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
        public int IdCambioProceso    { get; set; }        
        public CE_Empleado Encargado  { get; set; }
        public CE_EstadoRol EstadoRol { get; set; }
        public bool Compleato         { get; set; }        

        //campo adicional unicamente util para cuando se desee crear comentarios
        public CE_Comentario Comentario { get; set; }                

        public CE_ControlEstado() 
        {
            ID = 0;
        }

        public CE_ControlEstado(int iD, int idCambioProceso, CE_Empleado encargado, 
            CE_EstadoRol estadoRol, bool completado)            
        {
            ID               = iD;
            IdCambioProceso  = idCambioProceso;            
            Encargado        = encargado;
            EstadoRol        = estadoRol;
            Compleato        = completado;                                    
        }
    }
}
