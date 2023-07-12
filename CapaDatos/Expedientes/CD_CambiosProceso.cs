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
                    TimeSpan Duracion  = (TimeSpan)resultado[8];
                    
                    
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

        public CE_CambioProceso BuscarById(int id)
        {
            return this.ObtenerCambios().Find(c => c.ID == id);
        }

    }
}
