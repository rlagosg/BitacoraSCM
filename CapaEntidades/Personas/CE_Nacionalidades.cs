using System;
using System.Collections.Generic;
using System.Text;

namespace CapaEntidades.Personas
{
    public class CE_Nacionalidades
    {

        public string Pais         { get; set; }
        public string Nacionalidad { get; set; }
        public int Id              { get; set; }

        public CE_Nacionalidades(string nombre, string pais, int id = 0)
        {
            Pais         = pais;
            Nacionalidad = nombre;
            Id           = id;
        }

        public CE_Nacionalidades()
        {

        }
    }
}
