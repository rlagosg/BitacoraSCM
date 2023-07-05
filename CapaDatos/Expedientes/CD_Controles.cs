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
    public class CD_Controles
    {
        /// <summary>
        /// metodo para enlistar expedientes con filtro por el nombre del expediente
        /// </summary>        
        public DataTable Listar(CE_Busqueda busqueda)
        {
            SqlDataReader resultado;
            DataTable tabla = new DataTable();
            SqlConnection sqlCon = new SqlConnection();

            string consulta =
                "SELECT " +
                "   C.IdControl AS IdControl, " +
                "   E.IdExpediente AS IdExpediente, " +
                "   E.Nombre AS Expediente, " +
                "   C.FechaInicio AS Iniciado, " +
                "   C.Iniciador AS IdIniciador, " +
                "   CONCAT(PIni.PrimerNombre, ' ', PIni.PrimerApellido) AS Iniciador, " +
                "   C.ObsIni AS [Observacion Inicial], " +
                "   Rol.Nombre AS Proceso, " +
                "   Et.Nombre AS Estado, " +
                "   (SELECT TOP 1 Observaciones " +
                "    FROM Comentarios " +
                "    WHERE IdControlEstado = CE.IdControlEstado " +
                "    ORDER BY Fecha DESC) AS [Ultimo Comentario], " +
                "   CE.IdEmpleado AS IdEncargado, " +
                "   CONCAT(PEn.PrimerNombre, ' ', PEn.PrimerApellido) AS Encargado, " +
                "   MAX(Com.Fecha) AS [Ultimo Cambio], " +
                "   C.Finalizador AS IdFinalizador, " +
                "   CONCAT(PFin.PrimerNombre, ' ', PFin.PrimerApellido) AS Finalizador, " +
                "   C.FechaFin AS Finalizacion, " +
                "   C.ObsFin AS [Observacion Final], " +
                "   CP.IdCambios " +
                "FROM " +
                "   Controles C " +
                "   INNER JOIN Expedientes E ON C.IdExpediente = E.IdExpediente " +
                "   INNER JOIN Empleados Ini ON C.Iniciador = Ini.IdEmpleado " +
                "   INNER JOIN Personas PIni ON Ini.IdPersona = PIni.IdPersona " +
                "   LEFT JOIN Cambios_Proceso CP ON C.IdControl = CP.IdControl " +
                "   LEFT JOIN Roles Rol ON CP.IdRol = Rol.IdRol " +
                "   LEFT JOIN Control_Estados CE ON CP.IdCambios = CE.IdCambios " +
                "   LEFT JOIN EstadosRoles EstRol ON CE.IdEstadoRol = EstRol.IdEstadoRol " +
                "   LEFT JOIN Estados Et ON Et.IdEstado = EstRol.IdEstado " +
                "   LEFT JOIN Empleados En ON CE.IdEmpleado = En.IdEmpleado " +
                "   LEFT JOIN Personas PEn ON En.IdPersona = PEn.IdPersona " +
                "   LEFT JOIN Comentarios Com ON CE.IdControlEstado = Com.IdControlEstado " +
                "   LEFT JOIN Empleados Fin ON C.Finalizador = Fin.IdEmpleado " +
                "   LEFT JOIN Personas PFin ON Fin.IdPersona = PFin.IdPersona " +
                "WHERE " +
                "   E.Nombre LIKE '%' + @texto + '%' " +
                "   AND E.Activo = 1 ";

            // Agregar condiciones dinámicas
            if (busqueda.fechaInicio != null)
            {
                consulta += "   AND C.FechaInicio >= @fechaInicio ";
            }
            if (busqueda.fechaFin != null)
            {
                consulta += "   AND C.FechaInicio <= @fechaFin ";
            }
            if (busqueda.idEncargado != 0)
            {
                consulta += "   AND CE.IdEmpleado = @idEncargado ";
            }
            if (busqueda.finalizados)
            {
                consulta += "   AND C.Finalizador IS NOT NULL ";
            }

            consulta += "GROUP BY " +
                "   C.IdControl, E.IdExpediente, E.Nombre, C.FechaInicio, C.Iniciador, " +
                "   PIni.PrimerNombre, PIni.PrimerApellido, C.ObsIni, Rol.Nombre, " +
                "   Et.Nombre, CE.IdEmpleado, PEn.PrimerNombre, PEn.PrimerApellido, " +
                "   C.Finalizador, PFin.PrimerNombre, PFin.PrimerApellido, C.FechaFin, " +
                "   C.ObsFin, CE.IdControlEstado, CP.IdCambios; ";

            try
            {
                sqlCon = Conexion.getInstancia().CrearConexion();
                SqlCommand comando = new SqlCommand(consulta, sqlCon);
                comando.CommandType = CommandType.Text;
                comando.Parameters.AddWithValue("@texto", busqueda.texto);

                // Asignar valores a los parámetros dinámicos
                if (busqueda.fechaInicio != null)
                {
                    comando.Parameters.AddWithValue("@fechaInicio", busqueda.fechaInicio);
                }
                if (busqueda.fechaFin != null)
                {
                    comando.Parameters.AddWithValue("@fechaFin", busqueda.fechaFin);
                }
                if (busqueda.idEncargado != 0)
                {
                    comando.Parameters.AddWithValue("@idEncargado", busqueda.idEncargado);
                }

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
        public DataTable Estados(CE_Control expediente)
        {
            SqlDataReader resultado;
            DataTable tabla = new DataTable();
            SqlConnection sqlCon = new SqlConnection();

            try
            {
                sqlCon = Conexion.getInstancia().CrearConexion();
                SqlCommand comando = new SqlCommand("SCM_SP_EXPEDIENTE_CONTROL_ESTADOS_BYROL_LIST", sqlCon);
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@id", expediente.Expediente.ID);
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
        public List<CE_EstadoExpediente> ObtenerEstados(CE_Control expediente)
        {
            SqlDataReader resultado;
            SqlConnection sqlCon = new SqlConnection();
            List<CE_EstadoExpediente> estados = new List<CE_EstadoExpediente>();

            try
            {
                sqlCon = Conexion.getInstancia().CrearConexion();
                SqlCommand comando = new SqlCommand("SCM_SP_EXPEDIENTE_CONTROL_ESTADOS_BYROL_LIST", sqlCon);
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.Add("@id", SqlDbType.Int).Value = expediente.Expediente.ID;
                comando.Parameters.Add("@idRol", SqlDbType.Int).Value = expediente.Rol;
                sqlCon.Open();
                resultado = comando.ExecuteReader();

                while (resultado.Read())
                {
                    int ID = (int)resultado[0];
                    string Proceso = (string)resultado[1];
                    string Estado = (string)resultado[2];
                    string Observaciones = resultado[3] != DBNull.Value
                                                            ? (string)resultado[3]
                                                            : null;
                    DateTime? Fecha = (DateTime)resultado[4];
                    string Encargado = (string)resultado[5];

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
        public DataTable Resumen(CE_Control expediente)
        {
            SqlDataReader resultado;
            DataTable tabla = new DataTable();
            SqlConnection sqlCon = new SqlConnection();

            try
            {
                sqlCon = Conexion.getInstancia().CrearConexion();
                SqlCommand comando = new SqlCommand("SCM_SP_EXPEDIENTE_ESTADOS_LIST", sqlCon);
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@id", expediente.Expediente.ID);
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
        /// Metodo para Crear un nuevo Control
        /// </summary>
        public string Salvar(CE_CambioProceso cambio)
        {
            string rpta = "";
            SqlConnection sqlCon = new SqlConnection();

            try
            {
                sqlCon = Conexion.getInstancia().CrearConexion();

                SqlCommand comando = new SqlCommand("SCM_SP_EXPEDIENTE_CONTROL_SAVE", sqlCon);
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.Add("@Nombre",        SqlDbType.NVarChar).Value = cambio.Control.Expediente.Expediente;                                
                comando.Parameters.Add("@Envio",              SqlDbType.Int).Value = cambio.Envia.ID;
                comando.Parameters.Add("@Recibio",            SqlDbType.Int).Value = cambio.Recibe.ID;                
                comando.Parameters.Add("@ObsIni",        SqlDbType.NVarChar).Value = cambio.ObsIni;
                comando.Parameters.Add("@Observaciones", SqlDbType.NVarChar).Value = cambio.Observaciones;

                SqlParameter resultadoParam = new SqlParameter("@Resultado", SqlDbType.Int);
                resultadoParam.Direction    = ParameterDirection.Output;
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
