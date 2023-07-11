using CapaEntidades.Personas;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Text;
using CapaEntidades.Roles;
using CapaDatos.Controles;

namespace CapaDatos.Roles
{
    public class CD_EstadosRoles
    {
        //consulta para obtener los estados vinculados a un rol
        private string consulta = "SELECT re.IdEstadoRol as ID, re.IdRol,  re.IdEstado, e.nombre as Estado, e.descripcion as Descripción, re.numero as Paso, re.Activo from EstadosRoles re INNER JOIN Estados e on re.IdEstado = e.IdEstado WHERE idRol = @idRol AND re.Activo = 1 ORDER BY Numero;";
        private string consultaSinRol = "SELECT re.IdEstadoRol as ID, re.IdRol,  re.IdEstado, e.nombre as Estado, e.descripcion as Descripción, re.numero as Paso, re.Activo from EstadosRoles re INNER JOIN Estados e on re.IdEstado = e.IdEstado WHERE re.Activo = 1 ORDER BY Numero;";

        /// <summary> 
        /// metodo para enlistar los datos
        /// </summary>
        public DataTable Listar(CE_Rol rol)
        {
            SqlDataReader resultado;
            DataTable tabla      = new DataTable();
            SqlConnection sqlCon = new SqlConnection();

            try
            {
                sqlCon = Conexion.getInstancia().CrearConexion();
                SqlCommand comando = new SqlCommand(consulta, sqlCon);
                comando.Parameters.AddWithValue("@idRol", rol.ID);
                comando.CommandType = CommandType.Text;
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

        public string Salvar(CE_EstadoRol estado)
        {
            string rpta = "";
            SqlConnection sqlCon = new SqlConnection();

            try
            {
                sqlCon = Conexion.getInstancia().CrearConexion();
                SqlCommand comando  = new SqlCommand("SCM_SP_ESTADOROL_SAVE", sqlCon);
                comando.CommandType = CommandType.StoredProcedure;                                
                comando.Parameters.Add("@idRol",    SqlDbType.Int).Value = estado.IdRol;
                comando.Parameters.Add("@idEstado", SqlDbType.Int).Value = estado.IdEstado;
                comando.Parameters.Add("@Numero",   SqlDbType.Int).Value = estado.Numero;
                comando.Parameters.Add("@Activo",   SqlDbType.Bit).Value = estado.Activo;
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

        public string DeshabilitaEstados(CE_Rol rol)
        {
            string rpta = "";
            SqlConnection sqlCon = new SqlConnection();

            try
            {
                sqlCon = Conexion.getInstancia().CrearConexion();
                SqlCommand comando  = new SqlCommand("UPDATE EstadosRoles SET Activo = 0 WHERE IdRol = @IdRol;", sqlCon);
                comando.CommandType = CommandType.Text;
                comando.Parameters.Add("@idRol", SqlDbType.Int).Value = rol.ID;
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
        /// metodo para actualizar el numero de estado, dentro de un rol
        /// </summary>
        public string ActualizarEstado(CE_EstadoRol estado)
        {
            string rpta = "";
            SqlConnection sqlCon = new SqlConnection();

            try
            {
                sqlCon = Conexion.getInstancia().CrearConexion();
                SqlCommand comando = new SqlCommand("UPDATE EstadosRoles SET Numero = @numero WHERE IdEstadoRol = @id", sqlCon);
                comando.Parameters.Add("@id",     SqlDbType.Int).Value = estado.ID;
                comando.Parameters.Add("@numero", SqlDbType.Int).Value = estado.Numero;
                sqlCon.Open();
                rpta = comando.ExecuteNonQuery() >= 1 ? "OK" : "No se pudo actualizar el registro";
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
        /// Metodo para obtener los estados de un Rol, devolviendo una lista de objetos
        /// </summary>
        public List<CE_EstadoRol> ObtenerEstados(CE_Rol rol)
        {
            List<CE_EstadoRol> estados = new List<CE_EstadoRol>();
            CD_Estados cdEstados       = new CD_Estados();
            SqlConnection sqlCon       = new SqlConnection();
            SqlDataReader resultado;

            try
            {
                sqlCon = Conexion.getInstancia().CrearConexion();
                SqlCommand comando  = new SqlCommand(consulta, sqlCon);
                comando.Parameters.AddWithValue("@idRol", rol.ID);
                comando.CommandType = CommandType.Text;
                sqlCon.Open();
                resultado = comando.ExecuteReader();

                while (resultado.Read())
                {
                    int ID             = (int)    resultado[0];
                    int IdRol          = (int)    resultado[1];
                    int IdEstado       = (int)    resultado[2];
                    string Nombre      = (string) resultado[3];
                    int Numero         = (int)    resultado[5];
                    bool Activo        = (bool)   resultado[6];

                    string Descripcion = resultado[4] != DBNull.Value
                                         ? (string) resultado[4]
                                         : null;

                    CE_EstadoRol estado = new CE_EstadoRol
                    (
                        ID,
                        IdRol,
                        IdEstado,
                        Nombre,
                        Descripcion,
                        Numero,
                        Activo
                    );

                    estado.Estado = cdEstados.BuscarById(IdEstado);

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
        /// Metodo para obtener los estados asigandos a roles, devolviendo una lista de objetos        
        /// </summary>
        public List<CE_EstadoRol> ObtenerAllEstados()
        {
            List<CE_EstadoRol> estados = new List<CE_EstadoRol>();
            CD_Estados cdEstados       = new CD_Estados();
            SqlConnection sqlCon       = new SqlConnection();
            SqlDataReader resultado;

            try
            {
                sqlCon = Conexion.getInstancia().CrearConexion();
                SqlCommand comando  = new SqlCommand(consultaSinRol, sqlCon);                
                comando.CommandType = CommandType.Text;
                sqlCon.Open();
                resultado = comando.ExecuteReader();

                while (resultado.Read())
                {
                    int ID        = (int)    resultado[0];
                    int IdRol     = (int)    resultado[1];
                    int IdEstado  = (int)    resultado[2];
                    string Nombre = (string) resultado[3];
                    int Numero    = (int)    resultado[5];
                    bool Activo   = (bool)   resultado[6];

                    string Descripcion = resultado[4] != DBNull.Value
                                         ? (string)resultado[4]
                                         : null;

                    CE_EstadoRol estado = new CE_EstadoRol
                    (
                        ID,
                        IdRol,
                        IdEstado,
                        Nombre,
                        Descripcion,
                        Numero,
                        Activo
                    );

                    estado.Estado = cdEstados.BuscarById(IdEstado);

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
        /// Metodo para buscar un estado de un Rol por su Id
        /// </summary>
        public CE_EstadoRol BuscarById(int id, CE_Rol rol)
        {
            CE_EstadoRol estado = this.ObtenerEstados(rol).Find(e => e.ID == id);
            return estado;
        }

        /// <summary>
        /// Metodo para buscar un estado de un por su Id
        /// </summary>
        public CE_EstadoRol BuscarByAllId(int id)
        {
            CE_EstadoRol estado = this.ObtenerAllEstados().Find(e => e.ID == id);
            return estado;
        }
    }
}
