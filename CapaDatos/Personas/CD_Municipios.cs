using CapaEntidades;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Text;
using CapaEntidades.Personas;
using System.Security.Cryptography;

namespace CapaDatos.Personas
{
    public class CD_Municipios
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
                SqlCommand comando  = new SqlCommand("SCM_SP_MUNICIPIOS_LIST", sqlCon);
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
        public string Salvar(int opcion, CE_Municipio municipio)
        {
            string rpta = "";
            SqlConnection sqlCon = new SqlConnection();

            try
            {
                sqlCon = Conexion.getInstancia().CrearConexion();
                SqlCommand comando  = new SqlCommand("SCM_SP_MUNICIPIOS_SAVE", sqlCon);
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.Add("@opcion",      SqlDbType.Int).Value = opcion;
                comando.Parameters.Add("@id",          SqlDbType.Int).Value = municipio.ID;
                comando.Parameters.Add("@nombre", SqlDbType.NVarChar).Value = municipio.Nombre;
                comando.Parameters.Add("@desc",   SqlDbType.NVarChar).Value = municipio.Descripcion;
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
        public string Eliminar(CE_Municipio municipio)
        {
            string rpta = "";
            SqlConnection sqlCon = new SqlConnection();

            try
            {
                sqlCon = Conexion.getInstancia().CrearConexion();
                SqlCommand comando  = new SqlCommand("SCM_SP_MUNICIPIOS_DELETE", sqlCon);
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.Add("@id", SqlDbType.NVarChar).Value = municipio.ID;
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

        public List<CE_Municipio> ObtenerMunicipios()
        {
            List<CE_Municipio> municipios = new List<CE_Municipio>();
            SqlConnection sqlCon = new SqlConnection();
            SqlDataReader resultado;

            try
            {

                sqlCon = Conexion.getInstancia().CrearConexion();
                SqlCommand comando  = new SqlCommand("select * from Municipios where activo = 1", sqlCon);
                comando.CommandType = CommandType.Text;
                sqlCon.Open();
                resultado = comando.ExecuteReader();

                while (resultado.Read())
                {
                    int ID             = (int)    resultado[0];
                    string Nombre      = (string) resultado[1];
                    string Descripcion = (string) resultado[2];

                    CE_Municipio nacionalidad = new CE_Municipio
                    (
                        ID,
                        Nombre,
                        Descripcion
                    );
                    municipios.Add(nacionalidad);
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

            return municipios;
        }
    }
}
