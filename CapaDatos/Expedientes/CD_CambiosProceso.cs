using CapaEntidades.Personas;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Text;
using CapaEntidades.Expedientes;
using CapaEntidades.Roles;
using CapaEntidades.Personas.Empleados;
using CapaDatos.Personas.Empleados;
using CapaDatos.Controles;

namespace CapaDatos.Expedientes
{
    public class CD_CambiosProceso
    {
        //metodo para enlistar los cambios de proceso del expediente
        public DataTable Listar(CE_Control expediente)
        {
            SqlDataReader resultado;
            DataTable tabla = new DataTable();
            SqlConnection sqlCon = new SqlConnection();

            try
            {
                sqlCon = Conexion.getInstancia().CrearConexion();
                SqlCommand comando  = new SqlCommand("SCM_SP_EXPEDIENTE_CAMBIOS_PROCESO_LIST", sqlCon);
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.Add("@id", SqlDbType.NVarChar).Value = expediente.Expediente.ID;                
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
        public List<CE_CambioProceso> ObtenerCambios()
        {
            List<CE_CambioProceso> cambios = new List<CE_CambioProceso>();
            CD_Roles roles                 = new CD_Roles();
            CD_Empleados empleados         = new CD_Empleados();                               
            
            SqlConnection sqlCon = new SqlConnection();
            SqlDataReader resultado;

            List<CE_Empleado> listaEmpleados = empleados.ObtenerEmpleados();

            try
            {
                sqlCon = Conexion.getInstancia().CrearConexion();
                SqlCommand comando = new SqlCommand("SELECT * FROM CAMBIOS_PROCESO;", sqlCon);
                comando.CommandType = CommandType.Text;
                
                sqlCon.Open();
                resultado = comando.ExecuteReader();                

                while (resultado.Read())
                {
                    int ID = (int)resultado[0];
                    DateTime Fecha = (DateTime)resultado[2];
                    CE_Rol nuevoProceso = roles.RolById((int)resultado[3]);
                    CE_Empleado envia   = empleados.BuscaEmpleadoByList(listaEmpleados, (int)resultado[4]);
                    CE_Empleado recibe  = empleados.BuscaEmpleadoByList(listaEmpleados, (int)resultado[5]);                   

                    string obs = resultado[6] != DBNull.Value
                                         ? (string)resultado[6]
                                         : null;

                    int IdEstadoActual = (int)resultado[7];
                    TimeSpan Duracion  = (TimeSpan)resultado[9];
                    
                    
                    CE_CambioProceso estado = new CE_CambioProceso
                    (
                        ID,
                        null,
                        nuevoProceso,
                        envia,
                        recibe,
                        null,
                        obs,
                        IdEstadoActual,
                        Fecha,
                        Duracion
                    );

                    cambios.Add(estado);
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

            return cambios;
        }

        /// <summary>
        /// Metodo para un Cambio de Proceso por su ID
        /// </summary>
        public CE_CambioProceso BuscarById(int id)
        {
            return this.ObtenerCambios().Find(c => c.ID == id);
        }

        /// <summary>
        /// Metodo para guardar un Cambio de Proceso.
        /// cuando desiemos cambiar de proceso y enviarlo a otro empleado
        /// </summary>
        public string Salvar(CE_CambioProceso cambio)
        {
            string rpta = "";
            SqlConnection sqlCon = new SqlConnection();

            try
            {
                sqlCon = Conexion.getInstancia().CrearConexion();

                SqlCommand comando = new SqlCommand("SCM_SP_EXPEDIENTE_CAMBIO_PROCESO_SAVE", sqlCon);
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.Add("@IdCambioAnt",        SqlDbType.Int).Value = cambio.ID;
                comando.Parameters.Add("@IdControl",          SqlDbType.Int).Value = cambio.Control.IdControl;
                comando.Parameters.Add("@IdProceso",          SqlDbType.Int).Value = cambio.IdNuevoProceso;
                comando.Parameters.Add("@Recibio",            SqlDbType.Int).Value = cambio.Recibe.ID;
                comando.Parameters.Add("@Envio",              SqlDbType.Int).Value = cambio.Envia.ID;              
                comando.Parameters.Add("@Observaciones", SqlDbType.NVarChar).Value = cambio.Observaciones;

                SqlParameter resultadoParam = new SqlParameter("@Resultado", SqlDbType.Int);
                resultadoParam.Direction = ParameterDirection.Output;
                comando.Parameters.Add(resultadoParam);

                sqlCon.Open();
                comando.ExecuteNonQuery();
                rpta = (int)resultadoParam.Value == 1 ? "OK" : "No se pudo ingresar el registro";
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
