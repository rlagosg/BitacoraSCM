﻿using System;
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
        public string NombreCompleto     { get; set; }
        public int IdNacionalidad        { get; set; }
        public CE_Nacionalidades Nacionalidad { get; set; }
        public DateTime? FechaNacimiento { get; set; }
        public string Genero             { get; set; }
        public string RTN                { get; set; }        

        public string NombreCorto
        {
            get
            {
                StringBuilder sb = new StringBuilder();
                sb.Append(PrimerNombre);

                if (!string.IsNullOrEmpty(SegundoNombre))
                {
                    sb.Append(" ");
                    sb.Append(SegundoNombre);
                }

                return sb.ToString();
            }
        }

        //constructor con parametros
        public CE_Persona(
            string id, string primerNombre, string segundoNombre,
            string primerApellido, string segundoApellido, string nombreCompleto,
            int idNacionaliadad, DateTime? fechaNacimiento,
            string genero, string rTN)
        {
            Id              = id;
            PrimerNombre    = primerNombre;
            SegundoNombre   = segundoNombre;
            PrimerApellido  = primerApellido;
            SegundoApellido = segundoApellido;
            NombreCompleto  = nombreCompleto;
            IdNacionalidad  = idNacionaliadad;
            FechaNacimiento = fechaNacimiento;
            Genero          = genero;
            RTN             = rTN;            
        }

        //constructor vacio
        public CE_Persona() { }
    }
}
