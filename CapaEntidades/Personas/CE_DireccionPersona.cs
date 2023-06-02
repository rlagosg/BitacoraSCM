using System;
using System.Collections.Generic;
using System.Text;

namespace CapaEntidades.Personas
{
    public class CE_DireccionPersona
    {
        public int ID            { get; set; }
        public string IdPersona  { get; set; }
        public int IdBarrio      { get; set; }
        public int IdColonia     { get; set; }
        public int IdResidencial { get; set; }
        public int IdAldea       { get; set; }
        public string Direccion  { get; set; }
        public string Comentario { get; set; }

        public CE_DireccionPersona() 
        {
            this.ID = 0;
        }

        public CE_DireccionPersona(int iD, string idPersona, int idBarrio, int idColonia, int idResidencial, int idAldea, string direccion, string comentario)
        {
            ID            = iD;
            IdPersona     = idPersona;
            IdBarrio      = idBarrio;
            IdColonia     = idColonia;
            IdResidencial = idResidencial;
            IdAldea       = idAldea;
            Direccion     = direccion;
            Comentario    = comentario;
        }   
    }
}
