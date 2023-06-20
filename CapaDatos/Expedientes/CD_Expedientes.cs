using CapaEntidades.Personas;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Text;
using CapaEntidades.Expedientes;
using CapaEntidades.Roles;

namespace CapaDatos.Expedientes
{
    public class CD_Expedientes
    {
        /// <summary>
        /// metodo para enlistar expedientes con filtro por el nombre del expediente
        /// </summary>        
        public DataTable Listar(string texto)
        {
            SqlDataReader resultado;
            DataTable tabla = new DataTable();
            SqlConnection sqlCon = new SqlConnection();

            string consulta =
            "SELECT "
                
                + "E.IdExpediente AS ID, "
                + "E.Nombre AS Expediente, "
                + "E.FechaInicio AS Iniciado, "
                + "EIni.IdEmpleado AS IdIniciador, "
                + "CONCAT( PIni.PrimerNombre, ' ',PIni.PrimerApellido) AS Iniciador, "
                + "E.ObsIni AS 'Obs. Inicial', "
                + "Rol.Nombre AS Proceso, "
                + "Est.Nombre AS Estado, "
                + "CE.Observaciones AS Comentario, "
                + "EUlt.IdEmpleado AS IdEncargado, "
                + "CONCAT(PUlt.PrimerNombre, ' ',PUlt.PrimerApellido) AS Encargado, "
                + "CE.Fecha AS 'Ult. Cambio', "
                + "E.FechaFin AS Finalizacion, "
                + "E.ObsFin AS 'Obs. Final' "
            + "FROM "
                + "Expedientes AS E "
                + "INNER JOIN Controles AS C ON E.IdExpediente = C.IdExpediente "
                + "INNER JOIN ( "
                    + "SELECT "
                        + "IdControl, "
                        + "MAX(IdControlEstado) AS UltimoControlEstado "
                    + "FROM "
                        + "Control_Estados "
                    + "GROUP BY "
                        + "IdControl "
                + ") AS CEID ON C.IdControl = CEID.IdControl "
                + "INNER JOIN Control_Estados AS CE ON CEID.UltimoControlEstado = CE.IdControlEstado "
                + "INNER JOIN Estados AS Est ON CE.IdEstado = Est.IdEstado "
                + "INNER JOIN Cambios_Proceso AS CP ON C.IdControl = CP.IdControl "
                + "INNER JOIN Empleados AS EUlt ON CP.Recibio = EUlt.IdEmpleado "
                + "INNER JOIN Roles AS Rol ON CP.IdRol = Rol.IdRol "
                + "INNER JOIN Empleados AS EIni ON E.Iniciador = EIni.IdEmpleado "
                + "INNER JOIN Personas AS PUlt ON EUlt.IdPersona = PUlt.IdPersona "
                + "INNER JOIN Personas AS PIni ON EIni.IdPersona = PIni.IdPersona "
            + "WHERE "
                + "E.Nombre LIKE '%' + @texto + '%' "
                + "AND E.Activo = 1 "
            + "ORDER BY "
                + "E.IdExpediente;";

            try
            {
                sqlCon = Conexion.getInstancia().CrearConexion();
                SqlCommand comando = new SqlCommand(consulta, sqlCon);
                comando.CommandType = CommandType.Text;
                comando.Parameters.AddWithValue("@texto", texto);
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
        /// obtiene los estados del expediente segun el rol en forma de Tabla
        /// </summary>
        public DataTable Estados(CE_Expediente expediente)
        {
            SqlDataReader resultado;
            DataTable tabla = new DataTable();
            SqlConnection sqlCon = new SqlConnection();     

            try
            {
                sqlCon = Conexion.getInstancia().CrearConexion();
                SqlCommand comando = new SqlCommand("SCM_SP_ESTADOS_EXPEDIENTE_BYROL_LIST", sqlCon);
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@id",    expediente.ID);
                comando.Parameters.AddWithValue("@idRol", expediente.Rol);
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
        /// obtiene los estados del expediente segun el rol en una lista
        /// </summary>
        public List<CE_EstadoExpediente> ObtenerEstados(CE_Expediente expediente)
        {            
            SqlDataReader resultado;            
            SqlConnection sqlCon = new SqlConnection();
            List<CE_EstadoExpediente> estados = new List<CE_EstadoExpediente>();

            try
            {
                sqlCon = Conexion.getInstancia().CrearConexion();
                SqlCommand comando = new SqlCommand("SCM_SP_ESTADOS_EXPEDIENTE_BYROL_LIST", sqlCon);
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.Add("@id",    SqlDbType.Int).Value = expediente.ID;
                comando.Parameters.Add("@idRol", SqlDbType.Int).Value = expediente.Rol;
                sqlCon.Open();
                resultado = comando.ExecuteReader();

                while (resultado.Read())
                {
                    int ID               = (int)    resultado[0];
                    string Proceso       = (string) resultado[1];
                    string Estado        = (string) resultado[2];
                    string Observaciones = resultado[3] != DBNull.Value
                                                            ? (string)resultado[3]
                                                            : null;
                    DateTime Fecha   = (DateTime) resultado[4];
                    string Encargado = (string)   resultado[5];

                    CE_EstadoExpediente estado = new CE_EstadoExpediente
                    (
                        ID,
                        Proceso,
                        Estado,
                        Observaciones,
                        Fecha,
                        Encargado
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

        /// <summary>
        /// obtiene TODOS los estados del expediente en Resumen retorna una Tabla
        /// </summary>
        public DataTable Resumen(CE_Expediente expediente)
        {
            SqlDataReader resultado;
            DataTable tabla = new DataTable();
            SqlConnection sqlCon = new SqlConnection();

            try
            {
                sqlCon = Conexion.getInstancia().CrearConexion();
                SqlCommand comando = new SqlCommand("SCM_SP_ESTADOS_EXPEDIENTE_LIST", sqlCon);
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@id", expediente.ID);                
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

    }
}
