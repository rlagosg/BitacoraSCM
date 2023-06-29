using CapaEntidades.Expedientes;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Text;
using CapaEntidades.Personas;
using CapaEntidades.Personas.Empleados;

namespace CapaDatos.Personas.Empleados
{
    public class CD_Empleados
    {
        /// <summary>
        /// Metodo para listar los emplpeados en forma de Tabla, usando filtro de texto
        /// </summary>
        public DataTable Listar(string texto, int op =  1)
        {
            SqlDataReader resultado;
            DataTable tabla = new DataTable();
            SqlConnection sqlCon = new SqlConnection();
            SqlCommand comando;

            try
            {
                sqlCon = Conexion.getInstancia().CrearConexion();

                if (op == 1) comando = new SqlCommand("SCM_SP_EMPLEADOS_LIST", sqlCon);
                else comando = new SqlCommand("SCM_SP_EMPLEADOS_NO_USUARIO_LIST", sqlCon);

                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.Add("@texto", SqlDbType.NVarChar).Value = texto;
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

        /// <summary>
        /// Metodo para obtener los empleados, devolviendo una lista de objetos
        /// </summary>
        public List<CE_Empleado> ObtenerEmpleados()
        {
            List<CE_Empleado> Empleados = new List<CE_Empleado>();
            CD_Personas personas = new CD_Personas();
            SqlConnection sqlCon = new SqlConnection();
            SqlDataReader resultado;

            try
            {
                sqlCon = Conexion.getInstancia().CrearConexion();
                SqlCommand comando = new SqlCommand("SELECT * FROM Empleados", sqlCon);
                comando.CommandType = CommandType.Text;
                sqlCon.Open();
                resultado = comando.ExecuteReader();

                while (resultado.Read())
                {
                    int ID = (int)resultado[0];
                    string IdPersona = (string)resultado[1];

                    CE_Empleado empleado = new CE_Empleado();
                    empleado.ID = ID;                    
                    empleado.Persona = personas.BuscarById(IdPersona);                    

                    Empleados.Add(empleado);
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

            return Empleados;
        }

        public CE_Empleado BuscaEmpleadoById(int id)
        {
            CE_Empleado empleado = this.ObtenerEmpleados().Find(e => e.ID == id);
            return empleado;
        }



        /// <summary>
        /// Metodo para Guarda & Modificar: 1 = salvar, 2 = modificar
        /// </summary>
        public string Salvar(int opcion, CE_Empleado empleado)
        {
            string rpta = "";
            SqlConnection sqlCon = new SqlConnection();

            try
            {
                sqlCon = Conexion.getInstancia().CrearConexion();
                SqlCommand comando = new SqlCommand("SCM_SP_EMPLEADOS_SAVE", sqlCon);
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.Add("@opcion", SqlDbType.Int).Value = opcion;
                comando.Parameters.Add("@id", SqlDbType.Int).Value = empleado.ID;
                comando.Parameters.Add("@idPersona", SqlDbType.NVarChar).Value = empleado.Persona.Id;
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

        
        /// <summary>
        /// Metodo para Eliminar
        /// </summary>
        public string Eliminar(CE_Empleado empleado)
        {
            string rpta = "";
            SqlConnection sqlCon = new SqlConnection();

            try
            {
                sqlCon = Conexion.getInstancia().CrearConexion();
                SqlCommand comando = new SqlCommand("SCM_SP_EMPLEADOS_DELETE", sqlCon);
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.Add("@id", SqlDbType.Int).Value = empleado.ID;
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
