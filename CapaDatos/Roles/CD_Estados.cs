using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Text;
using CapaEntidades.Personas;
using CapaEntidades.Roles;
using CapaDatos.Roles;

namespace CapaDatos.Controles
{
    public class CD_Estados
    {

        //metodo para enlistar los datos
        public DataTable Listar(string texto = "")
        {
            SqlDataReader resultado;
            DataTable tabla      = new DataTable();
            SqlConnection sqlCon = new SqlConnection();

            try
            {
                sqlCon = Conexion.getInstancia().CrearConexion();
                SqlCommand comando = new SqlCommand("SCM_SP_ESTADOS_LIST", sqlCon);
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


        // Metodo para obtener los Estados, devolviendo una lista de objetos
        public List<CE_Estado> ObtenerEstados()
        {
            List<CE_Estado> estados = new List<CE_Estado>();            
            SqlConnection sqlCon    = new SqlConnection();
            SqlDataReader resultado;

            try
            {
                sqlCon = Conexion.getInstancia().CrearConexion();
                SqlCommand comando = new SqlCommand("SELECT * FROM Estados WHERE Activo = 1 ORDER BY NOMBRE", sqlCon);
                comando.CommandType = CommandType.Text;
                sqlCon.Open();
                resultado = comando.ExecuteReader();

                while (resultado.Read())
                {
                    int ID             = (int)    resultado[0];
                    string Nombre      = (string) resultado[1];
                    bool Activo        = (bool)resultado[3];
                    string Descripcion = resultado[2] != DBNull.Value
                                         ? (string)resultado[2]
                                         : null;

                    CE_Estado estado = new CE_Estado
                    (
                        ID,
                        Nombre,
                        Descripcion,
                        Activo
                    );
                    estados.Add(estado);
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

            return estados;
        }

        // Metodo para obtener los estados que no tiene un Rol, devolviendo una lista de objetos
        public List<CE_Estado> ObtenerEstadosExcluidos(CE_Rol rol)
        {
            List<CE_Estado> estados = new List<CE_Estado>();
            SqlConnection sqlCon    = new SqlConnection();
            SqlDataReader resultado;            

            try
            {
                sqlCon = Conexion.getInstancia().CrearConexion();
                SqlCommand comando = new SqlCommand("SCM_SP_ESTADOSEX_LIST", sqlCon);
                comando.Parameters.AddWithValue("@idRol", rol.ID);
                comando.CommandType = CommandType.StoredProcedure;
                sqlCon.Open();
                resultado = comando.ExecuteReader();

                while (resultado.Read())
                {
                    int ID             = (int)    resultado[0];
                    string Nombre      = (string) resultado[1];
                    bool Activo        = (bool)   resultado[3];
                    string Descripcion = resultado[2] != DBNull.Value
                                         ? (string)resultado[2]
                                         : null;
                    
                    if (Activo) { 
                        CE_Estado estado = new CE_Estado
                        (
                            ID,
                            Nombre,
                            Descripcion,
                            Activo
                        );
                        estados.Add(estado);
                    }
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

            return estados;
        }

        //salvar y modificar
        public string Salvar(int opcion, CE_Estado estado)
        {
            string rpta = "";
            SqlConnection sqlCon = new SqlConnection();

            try
            {
                sqlCon = Conexion.getInstancia().CrearConexion();
                SqlCommand comando = new SqlCommand("SCM_SP_ESTADOS_SAVE", sqlCon);
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.Add("@opcion", SqlDbType.Int).Value = opcion;
                comando.Parameters.Add("@id", SqlDbType.Int).Value = estado.ID;
                comando.Parameters.Add("@nombre", SqlDbType.NVarChar).Value = estado.Nombre;
                comando.Parameters.Add("@desc", SqlDbType.NVarChar).Value = estado.Descripcion;
                sqlCon.Open();
                rpta = comando.ExecuteNonQuery() >= 1 ? "OK" : "No se pudo ingresar el registro porque el estado ya existe.";

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

        /*public string Salvar(int opcion, CE_Estado estado)
        {
            string rpta = "";
            SqlConnection sqlCon = new SqlConnection();

            try
            {
                sqlCon = Conexion.getInstancia().CrearConexion();
                SqlCommand comando = new SqlCommand("SCM_SP_ESTADOS_SAVE", sqlCon);
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.Add("@opcion",      SqlDbType.Int).Value = opcion;
                comando.Parameters.Add("@nombre", SqlDbType.NVarChar).Value = estado.Nombre;
                comando.Parameters.Add("@desc",   SqlDbType.NVarChar).Value = estado.Descripcion;               
                sqlCon.Open();
                rpta = comando.ExecuteNonQuery() >= 1 ? "OK" : "No se pudo actualizar el registro";                
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
        }*/




        //eliminar
        public string Eliminar(CE_Estado estado)
        {
            string rpta = "";
            SqlConnection sqlCon = new SqlConnection();

            try
            {
                sqlCon = Conexion.getInstancia().CrearConexion();
                SqlCommand comando  = new SqlCommand("SCM_SP_ESTADOS_DELETE", sqlCon);
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.Add("@id", SqlDbType.NVarChar).Value = estado.ID;
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
