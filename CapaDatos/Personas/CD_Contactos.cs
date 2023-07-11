using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Text;
using CapaEntidades.Personas;
using System.Security.Cryptography;

namespace CapaDatos.Personas
{
    public class CD_Contactos
    {
        //metodo para enlistar los datos
        public DataTable Listar(string texto, CE_Persona persona)
        {
            SqlDataReader resultado;
            DataTable tabla      = new DataTable();
            SqlConnection sqlCon = new SqlConnection();

            try
            {
                sqlCon = Conexion.getInstancia().CrearConexion();
                SqlCommand comando  = new SqlCommand("SCM_SP_CONTACTOS_LIST", sqlCon);
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.Add("@texto",     SqlDbType.NVarChar).Value = texto;
                comando.Parameters.Add("@idPersona", SqlDbType.NVarChar).Value = persona.Id;                
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
        public string Salvar(int opcion, CE_Contacto contacto)
        {
            string rpta = "";
            SqlConnection sqlCon = new SqlConnection();

            try
            {
                sqlCon = Conexion.getInstancia().CrearConexion();
                SqlCommand comando  = new SqlCommand("SCM_SP_CONTACTOS_SAVE", sqlCon);
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.Add("@opcion",        SqlDbType.Int).Value = opcion;
                comando.Parameters.Add("@id",            SqlDbType.Int).Value = contacto.ID;
                comando.Parameters.Add("@idPersona",SqlDbType.NVarChar).Value = contacto.IdPersona;
                comando.Parameters.Add("@contacto", SqlDbType.NVarChar).Value = contacto.Contacto;
                comando.Parameters.Add("@desc",     SqlDbType.NVarChar).Value = contacto.Descripcion;
                comando.Parameters.Add("@idTipo",        SqlDbType.Int).Value = contacto.IdTipo;                
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
        public string Eliminar(CE_Contacto contacto)
        {
            string rpta = "";
            SqlConnection sqlCon = new SqlConnection();

            try
            {
                sqlCon = Conexion.getInstancia().CrearConexion();
                SqlCommand comando  = new SqlCommand("SCM_SP_CONTACTOS_DELETE", sqlCon);
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.Add("@id", SqlDbType.Int).Value = contacto.ID;
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

        public List<CE_Contacto> Obtenercontactos()
        {
            List<CE_Contacto> contactos = new List<CE_Contacto>();
            SqlConnection sqlCon = new SqlConnection();
            SqlDataReader resultado;

            try
            {
                sqlCon = Conexion.getInstancia().CrearConexion();
                SqlCommand comando = new SqlCommand("select * from contactos where activo = 1", sqlCon);
                comando.CommandType = CommandType.Text;
                sqlCon.Open();
                resultado = comando.ExecuteReader();

                while (resultado.Read())
                {
                    int ID             = (int)    resultado[0];
                    string IdPersona   = (string) resultado[1];
                    string Contact     = (string) resultado[2];
                    string Descripcion = (string) resultado[3];
                    int IdTipo         = (int)    resultado[4];

                    CE_Contacto nacionalidad = new CE_Contacto
                    (
                        ID,
                        IdPersona,
                        Contact,
                        Descripcion,
                        IdTipo
                    );
                    contactos.Add(nacionalidad);
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

            return contactos;
        }
    }
}
