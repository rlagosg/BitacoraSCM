using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Text;
using CapaEntidades.Personas;
using System.Data.SqlTypes;

namespace CapaDatos.Personas
{
    public class CD_DireccionPersonas
    {
        //metodo para enlistar los datos
        public DataTable Listar(string IdPersona)
        {
            SqlDataReader resultado;
            DataTable tabla      = new DataTable();
            SqlConnection sqlCon = new SqlConnection();

            try
            {
                sqlCon = Conexion.getInstancia().CrearConexion();
                SqlCommand comando  = new SqlCommand("SCM_SP_DIRECPERSONAS_LIST", sqlCon);              
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.Add("@persona", SqlDbType.VarChar).Value = IdPersona;
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

        //salvar y modificar
        public string Salvar(int opcion, CE_DireccionPersona direccion)
        {
            string rpta = "";
            SqlConnection sqlCon = new SqlConnection();

            try
            {
                sqlCon = Conexion.getInstancia().CrearConexion();
                SqlCommand comando = new SqlCommand("SCM_SP_DIRECPERSONAS_SAVE", sqlCon);
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.Add("@opcion",      SqlDbType.Int).Value = opcion;
                comando.Parameters.Add("@id",          SqlDbType.Int).Value = direccion.ID;
                comando.Parameters.Add("@persona",SqlDbType.NVarChar).Value = direccion.IdPersona; 
                comando.Parameters.Add("@barrio",      SqlDbType.Int).Value = direccion.IdBarrio      != 0 ? direccion.IdBarrio      : SqlInt32.Null;
                comando.Parameters.Add("@colonia",     SqlDbType.Int).Value = direccion.IdColonia     != 0 ? direccion.IdColonia     : SqlInt32.Null;
                comando.Parameters.Add("@residencial", SqlDbType.Int).Value = direccion.IdResidencial != 0 ? direccion.IdResidencial : SqlInt32.Null;
                comando.Parameters.Add("@aldea",       SqlDbType.Int).Value = direccion.IdAldea       != 0 ? direccion.IdAldea       : SqlInt32.Null;
                comando.Parameters.Add("@comen",  SqlDbType.NVarChar).Value = direccion.Comentario;
                sqlCon.Open();
                rpta = comando.ExecuteNonQuery() >= 1 ? "OK" : "No se pudo ingresar el registro";

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

        //eliminar
        public string Eliminar(CE_DireccionPersona direccion)
        {
            string rpta = "";
            SqlConnection sqlCon = new SqlConnection();

            try
            {
                sqlCon = Conexion.getInstancia().CrearConexion();
                SqlCommand comando  = new SqlCommand("SCM_SP_DIRECPERSONAS_DELETE", sqlCon);
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.Add("@id", SqlDbType.NVarChar).Value = direccion.ID;
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
