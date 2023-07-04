using System;
using System.Collections.Generic;
using System.Text;

namespace CapaEntidades.Expedientes
{
    public class CE_Comentario
    {
        public int ID                         { get; set; }
        public CE_ControlEstado ControlEstado { get; set; }
        public string Observaciones           { get; set; }
        public CE_Comentario() 
        {
            ID = 0;
        }

        public CE_Comentario(CE_ControlEstado controlEstado, string observaciones)
        {
            ID            = 0;
            ControlEstado = controlEstado;
            Observaciones = observaciones;
        }
    }
}
