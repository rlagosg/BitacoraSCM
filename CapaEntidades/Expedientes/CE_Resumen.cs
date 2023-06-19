using System;
using System.Collections.Generic;
using System.Text;

namespace CapaEntidades.Expedientes
{
    public class CE_Resumen
    {
        public int ID               { get; set; }
        public string Proceso       { get; set; }
        public string Estado        { get; set; }
        public string Observaciones { get; set; }
        public DateTime Fecha       { get; set; }
        public string Encargado     { get; set; }

        public CE_Resumen (int iD, string proceso, string estado, string observaciones, DateTime fecha, string encargado)
        {
            ID            = iD;
            Proceso       = proceso;
            Estado        = estado;
            Observaciones = observaciones;
            Fecha         = fecha;
            Encargado     = encargado;
        }
    }
}
