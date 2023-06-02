using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using CapaEntidades.Personas;

namespace CapaDatos.Personas
{
    public class CD_Nacionalidades
    {
        //metodo para enlistar los datos
        public DataTable Listar(string texto)
        {
            SqlDataReader resultado;
            DataTable tabla      = new DataTable();
            SqlConnection sqlCon = new SqlConnection();

            try
            {
                sqlCon = Conexion.getInstancia().CrearConexion();
                SqlCommand comando  = new SqlCommand("SCM_SP_NACIONALIDADES_LIST", sqlCon);
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
        public string Salvar(int opcion, CE_Nacionalidades nacionalidad)
        {
            string rpta = "";
            SqlConnection sqlCon = new SqlConnection();

            try
            {
                sqlCon = Conexion.getInstancia().CrearConexion();
                SqlCommand comando = new SqlCommand("SCM_SP_NACIONALIDADES_SAVE", sqlCon);
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.Add("@opcion",    SqlDbType.Int).Value = opcion;
                comando.Parameters.Add("@id",        SqlDbType.Int).Value = nacionalidad.Id;
                comando.Parameters.Add("@pais", SqlDbType.NVarChar).Value = nacionalidad.Pais;
                comando.Parameters.Add("@nac",  SqlDbType.NVarChar).Value = nacionalidad.Nacionalidad;
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
        public string Eliminar(CE_Nacionalidades nacionalidad)
        {
            string rpta = "";
            SqlConnection sqlCon = new SqlConnection();

            try
            {
                sqlCon = Conexion.getInstancia().CrearConexion();
                SqlCommand comando  = new SqlCommand("SCM_SP_NACIONALIDADES_DELETE", sqlCon);
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.Add("@id", SqlDbType.NVarChar).Value = nacionalidad.Id;
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

        public List<CE_Nacionalidades> ObtenerNacionalidades()
        {
            List<CE_Nacionalidades> nacionalidades = new List<CE_Nacionalidades>();
            SqlConnection sqlCon = new SqlConnection();
            SqlDataReader resultado;

            try
            {

                sqlCon = Conexion.getInstancia().CrearConexion();
                SqlCommand comando = new SqlCommand("select * from Nacionalidades", sqlCon);
                comando.CommandType = CommandType.Text;
                sqlCon.Open();
                resultado = comando.ExecuteReader();

                while (resultado.Read())
                {
                    int numero    = (int)    resultado[0];
                    string pais   = (string) resultado[1];
                    string nombre = (string) resultado[2];

                    CE_Nacionalidades nacionalidad = new CE_Nacionalidades
                    (
                        nombre,
                        pais,
                        numero
                    );

                    nacionalidades.Add(nacionalidad);
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

            return nacionalidades;
        }
    }
}

