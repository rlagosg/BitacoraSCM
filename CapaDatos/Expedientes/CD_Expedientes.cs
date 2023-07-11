using CapaEntidades.Expedientes;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Text;
using CapaEntidades.Personas;
using CapaEntidades.Personas.Empleados;

namespace CapaDatos.Expedientes
{
    public class CD_Expedientes
    {
        /// <summary>
        /// Metodo para obtener los expedientes, devolviendo una lista de objetos
        /// </summary>
        public List<CE_Expediente> ObtenerExpedientes()
        {
            List<CE_Expediente> expedientes = new List<CE_Expediente>();
            SqlConnection sqlCon = new SqlConnection();
            SqlDataReader resultado;

            try
            {
                sqlCon = Conexion.getInstancia().CrearConexion();
                SqlCommand comando  = new SqlCommand("SELECT * FROM Expedientes", sqlCon);
                comando.CommandType = CommandType.Text;
                sqlCon.Open();
                resultado = comando.ExecuteReader();

                while (resultado.Read())
                {
                    int ID = (int)resultado[0];
                    string Nombre = (string)resultado[1];

                    CE_Expediente expediente = new CE_Expediente
                    (
                        ID,
                        Nombre
                    );
                    expedientes.Add(expediente);
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

            return expedientes;
        }

        /// <summary>
        /// Metodo para buscar un expediente por su Id
        /// </summary>
        public CE_Expediente BuscarById(int id)
        {
            CE_Expediente expediente = this.ObtenerExpedientes().Find(e => e.ID == id);
            return expediente;
        }

        /// <summary>
        /// Metodo para Guarda & Modificar
        /// </summary>
        public string Salvar(CE_Expediente expediente)
        {
            string rpta = "";
            SqlConnection sqlCon = new SqlConnection();

            try
            {
                sqlCon = Conexion.getInstancia().CrearConexion();
                SqlCommand comando  = new SqlCommand("SCM_SP_EXPEDIENTE_SAVE", sqlCon);
                comando.CommandType = CommandType.StoredProcedure;               
                comando.Parameters.Add("@nombre", SqlDbType.NVarChar).Value = expediente.Expediente;
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
    }
}
