using CapaEntidades.Personas;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Text;
using CapaEntidades;
using System.Drawing;

namespace CapaDatos.Personas
{
    public class CD_DireccionTipos
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
                SqlCommand comando  = new SqlCommand("SCM_SP_DIRECTIPOS_LIST", sqlCon);
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
        public string Salvar(int opcion, CE_DireccionTipo tipo)
        {
            string rpta = "";
            SqlConnection sqlCon = new SqlConnection();

            try
            {
                sqlCon = Conexion.getInstancia().CrearConexion();
                SqlCommand comando  = new SqlCommand("SCM_SP_DIRECTIPOS_SAVE", sqlCon);
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.Add("@opcion",      SqlDbType.Int).Value = opcion;
                comando.Parameters.Add("@id",          SqlDbType.Int).Value = tipo.ID;
                comando.Parameters.Add("@nombre", SqlDbType.NVarChar).Value = tipo.Nombre;
                comando.Parameters.Add("@desc",   SqlDbType.NVarChar).Value = tipo.Descripcion;
                comando.Parameters.Add("@tipo",   SqlDbType.NVarChar).Value = tipo.Tipo;
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
        public string Eliminar(CE_DireccionTipo tipo)
        {
            string rpta = "";
            SqlConnection sqlCon = new SqlConnection();

            try
            {
                sqlCon = Conexion.getInstancia().CrearConexion();
                SqlCommand comando  = new SqlCommand("SCM_SP_DIRECTIPOS_DELETE", sqlCon);
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.Add("@id", SqlDbType.NVarChar).Value = tipo.ID;
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

        public List<CE_DireccionTipo> ObtenerTipos(bool direccion = true)
        {
            List<CE_DireccionTipo> tipos = new List<CE_DireccionTipo>();
            tipos.Add(new CE_DireccionTipo(-1, "Selecciona", "", ""));
            SqlConnection sqlCon = new SqlConnection();
            SqlDataReader resultado;

            try
            {
                sqlCon = Conexion.getInstancia().CrearConexion();

                string consulta = direccion
                    ? "select * from tipos where activo = 1 AND tipo = 'DIRECCION'"
                    : "select * from tipos where activo = 1 AND tipo = 'CONTACTO'";

                SqlCommand comando = new SqlCommand(consulta, sqlCon);

                comando.CommandType = CommandType.Text;
                sqlCon.Open();
                resultado = comando.ExecuteReader();

                while (resultado.Read())
                {
                    int ID             = (int)      resultado[0];
                    string Nombre      = (string)   resultado[1];                    
                    string Tipo        = (string)   resultado[3];
                    string Descripcion = resultado[2] != DBNull.Value 
                                         ? (string) resultado[2] 
                                         : null;

                    CE_DireccionTipo nacionalidad = new CE_DireccionTipo
                    (
                        ID,
                        Nombre,
                        Descripcion,
                        Tipo
                    );
                    tipos.Add(nacionalidad);
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

            return tipos;
        }
    }
}
