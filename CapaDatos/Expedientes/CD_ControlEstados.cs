using CapaDatos.Controles;
using CapaEntidades.Expedientes;
using CapaEntidades.Roles;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Text;
using CapaDatos.Roles;
using CapaEntidades.Personas.Empleados;
using CapaDatos.Personas.Empleados;

namespace CapaDatos.Expedientes
{
    public class CD_ControlEstados
    {
        /// <summary>
        /// Metodo para obtener los control de estados de un expediente
        /// devolviendo una lista de objetos
        /// </summary>
        public List<CE_ControlEstado> ObtenerControlesEstados()
        {
            List<CE_ControlEstado> controles = new List<CE_ControlEstado>();
            CD_EstadosRoles cdEstadosRoles   = new CD_EstadosRoles();
            CD_Empleados cdEcmpleados        = new CD_Empleados();
            SqlConnection sqlCon             = new SqlConnection();
            SqlDataReader resultado;

            try
            {
                sqlCon = Conexion.getInstancia().CrearConexion();
                SqlCommand comando = new SqlCommand("SELECT * FROM CONTROL_ESTADOS", sqlCon);
                comando.CommandType = CommandType.Text;
                sqlCon.Open();
                resultado = comando.ExecuteReader();                

                while (resultado.Read())
                {
                    int ID                 = (int)resultado[0];
                    int Cambio             = (int)resultado[1];
                    CE_Empleado empleado   = cdEcmpleados.BuscaEmpleadoById ((int)resultado[2]);
                    CE_EstadoRol estadoRol = cdEstadosRoles.BuscarByAllId   ((int)resultado[3]);
                    bool completado        = (bool)resultado[4];

                    CE_ControlEstado control = new CE_ControlEstado(
                        ID, Cambio, empleado,
                        estadoRol, completado
                    );

                    controles.Add(control);
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

            return controles;
        }

        /// <summary>
        /// Metodo para obtener los estados completos o pendientes de un expediente,
        /// devolviendo una lista de objetos
        /// </summary>
        public List<CE_Estado> ObtenerTareas(CE_CambioProceso cambio, bool pendientes)
        {
            List<CE_Estado> estados = new List<CE_Estado>();
            CD_Estados cdEstados    = new CD_Estados();
            SqlConnection sqlCon    = new SqlConnection();
            SqlDataReader resultado;

            try
            {
                sqlCon = Conexion.getInstancia().CrearConexion();
                SqlCommand comando;
                  
                if (pendientes) comando = new SqlCommand("SCM_SP_CONTROL_ESTADOS_PENDIENTES_LIST", sqlCon);
                else comando = new SqlCommand("SCM_SP_CONTROL_ESTADOS_COMPLETOS_LIST", sqlCon);

                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.Add("@idCambio", SqlDbType.Int).Value = cambio.ID;
                comando.Parameters.Add("@idRol",    SqlDbType.Int).Value = cambio.NuevoProceso.ID;               

                sqlCon.Open();
                resultado = comando.ExecuteReader();

                while (resultado.Read())
                {
                    int ID = (int)resultado[0];

                    CE_Estado estado = cdEstados.BuscarById(ID);
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


        /// <summary>
        /// Metodo para obtener un control-estado de un expediente por su ID,
        /// devolviendo una objeto
        /// </summary>
        public CE_ControlEstado BuscarById(int id)
        {
            return this.ObtenerControlesEstados().Find(c => c.ID == id);
        }

        /// <summary>
        /// Metodo para obtener un una lista de control-estado de un expediente por el IdCambio de Proceso,
        /// devolviendo una lista de objetos
        /// </summary>
        public List<CE_ControlEstado> BuscarByIdCambio(int id)
        {
            return this.ObtenerControlesEstados().FindAll(c => c.IdCambioProceso == id);
        }

        /// <summary>
        /// Metodo para obtener un control-estado de un expediente por su Cambio de Proceso y su EstadoRol,
        /// devolviendo una objeto
        /// </summary>
        public CE_ControlEstado BuscarByCambioYEstado(CE_CambioProceso cambio, CE_EstadoRol EstadoRol )
        {
            return this.ObtenerControlesEstados().
                Find(c => c.IdCambioProceso == cambio.ID && c.EstadoRol.IdEstado == EstadoRol.IdEstado);
        }


        /// <summary>
        /// Metodo para guardar o modificar un control-estado acompaxado de un comentario u observacion,
        /// </summary>
        public string Salvar(int opcion, CE_ControlEstado controlEstado)
        {
            string rpta = "";            
            SqlConnection sqlCon = new SqlConnection();

            try
            {
                sqlCon = Conexion.getInstancia().CrearConexion();
                SqlCommand comando = new SqlCommand("SCM_SP_CONTROL_ESTADOS_SAVE", sqlCon);
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.Add("@opcion",             SqlDbType.Int).Value = opcion;
                comando.Parameters.Add("@IdControlEstado",    SqlDbType.Int).Value = controlEstado.ID;
                comando.Parameters.Add("@IdCambios",          SqlDbType.Int).Value = controlEstado.IdCambioProceso;
                comando.Parameters.Add("@IdEmpleado",         SqlDbType.Int).Value = controlEstado.Encargado.ID;
                comando.Parameters.Add("@IdEstadoRol",        SqlDbType.Int).Value = controlEstado.EstadoRol.ID;
                comando.Parameters.Add("@Completado",         SqlDbType.Bit).Value = controlEstado.Compleato;                
                comando.Parameters.Add("@Observaciones", SqlDbType.NVarChar).Value = controlEstado.Comentario.Observaciones;

                SqlParameter parametroResultado = new SqlParameter("@Resultado", SqlDbType.Int);
                parametroResultado.Direction = ParameterDirection.Output;
                comando.Parameters.Add(parametroResultado);

                sqlCon.Open();
                comando.ExecuteNonQuery();                

                rpta = Convert.ToInt32(parametroResultado.Value) == 1 ? "OK" : "No se pudo ingresar el registro.";
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
