using System;
using System.Collections.Generic;
using System.Text;

namespace CapaEntidades.Expedientes
{
    public class CE_EstadoExpediente
    {
        int IdControl        { get; set; }
        int IdRol            { get; set; }
        int IdEstado         { get; set; }
        string Estado        { get; set; }
        string Observaciones { get; set; }
        DateTime Fecha       { get; set; }
        int IdEmpleado       { get; set; }
        string Encargado     { get; set; }        

        public CE_EstadoExpediente(int idControl, int idRol, int idEstado, string estado, string observaciones, DateTime fecha, int idempleado, string encargado)
        {
            IdControl     = idControl;
            IdRol         = idRol;
            IdEstado      = idEstado;
            Estado        = estado;
            Observaciones = observaciones;
            Fecha         = fecha;
            IdEmpleado    = idempleado;
            Encargado     = encargado;
        }
    }
}
