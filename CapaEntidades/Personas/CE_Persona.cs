using System;
using System.Collections.Generic;
using System.Text;

namespace CapaEntidades.Personas
{
    public class CE_Persona
    {
        public string Id                 { get; set; }
        public string PrimerNombre       { get; set; }
        public string SegundoNombre      { get; set; }
        public string PrimerApellido     { get; set; }
        public string SegundoApellido    { get; set; }
        public int IdNacionalidad        { get; set; }
        public DateTime? FechaNacimiento { get; set; }
        public string Genero             { get; set; }
        public string RTN                { get; set; }

        //constructor con parametros
        public CE_Persona(
            string id, string primerNombre, string segundoNombre,
            string primerApellido, string segundoApellido,
            int idNacionalidad, DateTime? fechaNacimiento,
            string genero, string rTN)
        {
            Id              = id;
            PrimerNombre    = primerNombre;
            SegundoNombre   = segundoNombre;
            PrimerApellido  = primerApellido;
            SegundoApellido = segundoApellido;
            IdNacionalidad  = idNacionalidad;
            FechaNacimiento = fechaNacimiento;
            Genero          = genero;
            RTN             = rTN;
        }

        //constructor vacio
        public CE_Persona() { }


    }
}
