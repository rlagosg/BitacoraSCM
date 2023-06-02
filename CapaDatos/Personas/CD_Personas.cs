using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using CapaEntidades.Personas;

namespace CapaDatos.Personas
{
    public class CD_Personas
    {

        //metodo para enlistar los datos
        public DataTable Listar(string texto)
        {
            SqlDataReader resultado;
            DataTable tabla = new DataTable();
            SqlConnection sqlCon = new SqlConnection();

            try
            {
                sqlCon = Conexion.getInstancia().CrearConexion();
                SqlCommand comando  = new SqlCommand("SCM_SP_PERSONAS_LIST", sqlCon);
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.Add("@texto", SqlDbType.VarChar).Value = texto;
                sqlCon.Open();
                resultado = comando.ExecuteReader();
                tabla.Load(resultado);
                return tabla;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (sqlCon.State == ConnectionState.Open) sqlCon.Close();
            }
        }

        //metodo para salvar y modificar
        public string Salvar(int opcion, CE_Persona Persona)
        {
            string rpta = "";
            SqlConnection sqlCon = new SqlConnection();

            try
            {
                sqlCon = Conexion.getInstancia().CrearConexion();
                SqlCommand comando = new SqlCommand("SCM_SP_PERSONAS_SAVE", sqlCon);
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.Add("@opcion",               SqlDbType.Int).Value = opcion;
                comando.Parameters.Add("@IdPersona",       SqlDbType.NVarChar).Value = Persona.Id;
                comando.Parameters.Add("@PrimerNombre",    SqlDbType.NVarChar).Value = Persona.PrimerNombre;
                comando.Parameters.Add("@SegundoNombre",   SqlDbType.NVarChar).Value = Persona.SegundoNombre;
                comando.Parameters.Add("@PrimerApellido",  SqlDbType.NVarChar).Value = Persona.PrimerApellido;
                comando.Parameters.Add("@SegundoApellido", SqlDbType.NVarChar).Value = Persona.SegundoApellido;
                comando.Parameters.Add("@IdNacionalidad",       SqlDbType.Int).Value = Persona.IdNacionalidad;                
                comando.Parameters.Add("@FechaNac",            SqlDbType.Date).Value = Persona.FechaNacimiento != null ? (object)Persona.FechaNacimiento : DBNull.Value;
                comando.Parameters.Add("@Genero",          SqlDbType.NVarChar).Value = Persona.Genero;
                comando.Parameters.Add("@RTN",             SqlDbType.NVarChar).Value = Persona.RTN;
                sqlCon.Open();
                rpta = comando.ExecuteNonQuery() >= 1 ? "OK" : "No se pudo ingresar el registro. \nEl ID que intentas registrar ya ha sido asignado a otra persona.";

            }
            catch (SqlException ex)
            {
                if (ex.Number == 2627) // Número de error para llave duplicada
                {
                    rpta = "El registro ya existe";
                }
                else
                {
                    rpta = ex.Message;
                }
            }
            finally
            {
                if (sqlCon.State == ConnectionState.Open) sqlCon.Close();
            }

            return rpta;
        }

        //eliminar
        public string Eliminar(CE_Persona Persona)
        {
            string rpta = "";
            SqlConnection sqlCon = new SqlConnection();

            try
            {
                sqlCon = Conexion.getInstancia().CrearConexion();
                SqlCommand comando  = new SqlCommand("SCM_SP_PERSONAS_DELETE", sqlCon);
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.Add("@IdPersona", SqlDbType.NVarChar).Value = Persona.Id;
                sqlCon.Open();
                rpta = comando.ExecuteNonQuery() >= 1 ? "OK" : "No se pudo eliminar el registro";
            }
            catch (Exception ex)
            {
                rpta = ex.Message;
            }
            finally
            {
                if (sqlCon.State == ConnectionState.Open) sqlCon.Close();
            }

            return rpta;
        }
    }
}
