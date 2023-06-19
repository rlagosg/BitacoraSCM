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
        /// //metodo para enlistar expedientes con filtro por el nombre del expediente
        /// </summary>        
        public DataTable Listar(string texto)
        {
            SqlDataReader resultado;
            DataTable tabla = new DataTable();
            SqlConnection sqlCon = new SqlConnection();

            string consulta =
            "SELECT " 
                + "E.IdExpediente AS ID, "
                + "E.Nombre as Expediente, "
                + "E.FechaInicio AS Iniciado, "
                + "UIni.Nombre AS Iniciador, "
                + "E.ObsIni AS 'Obs. Inicial', "
                + "Rol.Nombre AS Proceso, "
                + "Est.Nombre AS Estado, "
                + "CE.Observaciones AS Comentario, "
                + "UUlt.Nombre AS Encargado, "
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
                + "INNER JOIN Usuarios AS UUlt ON CP.Recibio = UUlt.IdUsuario "
                + "INNER JOIN Roles AS Rol ON CP.IdRol = Rol.IdRol "
                + "INNER JOIN Usuarios AS UIni ON E.Iniciador = UIni.IdUsuario "
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
                    int IdControl        = (int)resultado[0];
                    int IdRol            = (int)resultado[1];
                    int IdEstado         = (int)resultado[2];
                    string Estado        = (string)resultado[3];
                    string Observaciones = resultado[4] != DBNull.Value
                                                            ? (string)resultado[4]
                                                            : null;
                    DateTime Fecha = (DateTime)resultado[5];
                    int IdEmpleado = (int)resultado[6];
                    string Encargado = (string)resultado[7];

                    CE_EstadoExpediente estado = new CE_EstadoExpediente
                    (
                        IdControl,
                        IdRol,
                        IdEstado,
                        Estado,
                        Observaciones,
                        Fecha,
                        IdEmpleado,
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

    }
}
