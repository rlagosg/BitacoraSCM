using System;
using System.Collections.Generic;
using System.Text;

namespace CapaEntidades.Personas
{
    public class CE_Contacto
    {
        public int ID             { get; set; }
        public string IdPersona   { get; set; }
        public string Contacto    { get; set; }
        public string Descripcion { get; set; }
        public int IdTipo         { get; set; }
        
        public CE_Contacto() {
            this.ID = 0;
        }

        public CE_Contacto ( int id, string persona, string contacto, string desc, int tipo) { 
            
            this.ID          = id;
            this.IdPersona   = persona;
            this.Contacto    = contacto;
            this.Descripcion = desc;
            this.IdTipo      = tipo;            
        }
    }
}
