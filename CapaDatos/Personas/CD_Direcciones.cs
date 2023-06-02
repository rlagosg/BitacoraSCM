using CapaEntidades.Personas;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Text;
using System.Security.Cryptography;

namespace CapaDatos.Personas
{
    public class CD_Direcciones
    {
        //metodo para enlistar los datos
        public DataTable Listar(string texto, string parametro = null)
        {
            SqlDataReader resultado;
            DataTable tabla      = new DataTable();
            SqlConnection sqlCon = new SqlConnection();

            try
            {
                sqlCon = Conexion.getInstancia().CrearConexion();
                SqlCommand comando;

                
                if ( parametro == null )
                {   //si no existe un parametro de busqueda en el tipo de direccion sera una busqueda normal
                    comando = new SqlCommand("SCM_SP_DIRECCIONES_LIST", sqlCon);
                }
                else
                {   //de lo contrario buscaremos condicionado al parametro
                    comando = new SqlCommand("SCM_SP_DIRECCIONESPARAM_LIST", sqlCon);                  
                    comando.Parameters.Add("@param", SqlDbType.VarChar).Value = parametro;
                }
                
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

        //salvar y modificar
        public string Salvar(int opcion, CE_Direccion direccion)
        {
            string rpta = "";
            SqlConnection sqlCon = new SqlConnection();

            try
            {
                sqlCon = Conexion.getInstancia().CrearConexion();
                SqlCommand comando = new SqlCommand("SCM_SP_DIRECCIONES_SAVE", sqlCon);
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.Add("@opcion",      SqlDbType.Int).Value = opcion;
                comando.Parameters.Add("@id",          SqlDbType.Int).Value = direccion.ID;
                comando.Parameters.Add("@nombre", SqlDbType.NVarChar).Value = direccion.Nombre;
                comando.Parameters.Add("@desc",   SqlDbType.NVarChar).Value = direccion.Descripcion;
                comando.Parameters.Add("@idMuni",      SqlDbType.Int).Value = direccion.IdMuni;
                comando.Parameters.Add("@idTipo",      SqlDbType.Int).Value = direccion.IdTipo;                
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
        public string Eliminar(CE_Direccion direccion)
        {
            string rpta = "";
            SqlConnection sqlCon = new SqlConnection();

            try
            {
                sqlCon = Conexion.getInstancia().CrearConexion();
                SqlCommand comando  = new SqlCommand("SCM_SP_DIRECCIONES_DELETE", sqlCon);
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

        public List<CE_Direccion> ObtenerDirecciones()
        {
            List<CE_Direccion> direcciones = new List<CE_Direccion>();
            SqlConnection sqlCon = new SqlConnection();
            SqlDataReader resultado;

            try
            {
                sqlCon = Conexion.getInstancia().CrearConexion();
                SqlCommand comando  = new SqlCommand("select * from direcciones where activo = 1", sqlCon);
                comando.CommandType = CommandType.Text;
                sqlCon.Open();
                resultado = comando.ExecuteReader();

                while (resultado.Read())
                {
                    int ID             = (int)    resultado[0];
                    string Nombre      = (string) resultado[1];                    
                    int muni           = (int)    resultado[3];
                    int tipo           = (int)    resultado[4];
                    string Descripcion = resultado[2] != DBNull.Value 
                                         ? (string)resultado[2] 
                                         : null;

                    CE_Direccion nacionalidad = new CE_Direccion
                    (
                        ID,
                        Nombre,
                        Descripcion,
                        muni,
                        tipo
                    );
                    direcciones.Add(nacionalidad);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (sqlCon.State == ConnectionState.Open) sqlCon.Close();
            }

            return direcciones;
        }
    }
}
