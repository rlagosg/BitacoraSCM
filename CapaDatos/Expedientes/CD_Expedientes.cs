using CapaEntidades.Personas;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Text;

namespace CapaDatos.Expedientes
{
    public class CD_Expedientes
    {
        //metodo para enlistar los datos
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
    }
}
