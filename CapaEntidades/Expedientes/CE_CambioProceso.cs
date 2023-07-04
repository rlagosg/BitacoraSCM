﻿using CapaEntidades.Personas.Empleados;
using CapaEntidades.Roles;
using System;
using System.Collections.Generic;
using System.Text;

namespace CapaEntidades.Expedientes
{
    public class CE_CambioProceso
    {
        public int ID              { get; set; }
        public CE_Control Control  { get; set; }
        public CE_Rol NuevoProceso { get; set; }
        public CE_Empleado Envia   { get; set; }
        public CE_Empleado Recibe  { get; set; }        
        public string Observaciones { get; set; }

        public CE_CambioProceso() 
        {
            ID = 0;
        }

        public CE_CambioProceso(CE_Control control, CE_Rol nuevoProceso, CE_Empleado envia, CE_Empleado recibe, string obs)
        {
            ID            = 0;
            Control       = control;
            NuevoProceso  = nuevoProceso;            
            Envia         = envia;
            Recibe        = recibe;
            Observaciones = obs;
        }
    }
}