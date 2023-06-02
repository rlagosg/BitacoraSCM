using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;

namespace CapaDatos
{
    class Conexion
    {
        private string Base;
        private string Servidor;
        private string Usuario;
        private string Clave;
        private static Conexion Con = null;

        private Conexion()
        {

            //this.Servidor = "DESKTOP-ETO5HDS";
            //tcp:DESKTOP-ETO5HDS
            //this.Servidor = "(local)";
            this.Servidor = "tcp:DESKTOP-ETO5HDS";
            this.Base     = "SCM";                        
            this.Usuario  = "SCM";
            this.Clave    = "123";
        }

        public SqlConnection CrearConexion()
        {
            SqlConnection Cadena = new SqlConnection();
            try
            {
                //private SqlConnection Conexion = new SqlConnection("Server=(local);DataBase=SCM;Integrated Security=true");
                Cadena.ConnectionString = "Server="     + this.Servidor +
                                          "; Database=" + this.Base     +
                                          "; User Id="  + this.Usuario  +
                                          "; Password=" + this.Clave;

            }
            catch (Exception ex)
            {
                Cadena = null;
                throw ex;
            }

            return Cadena;
        }

        public static Conexion getInstancia()
        {
            if (Con == null)
            {
                Con = new Conexion();
            }
            return Con;
        }
    }
}
