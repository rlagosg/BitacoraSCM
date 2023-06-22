using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using CapaEntidades.Personas;
using System.Net.NetworkInformation;

namespace CapaDatos.Personas
{
    public class CD_Personas
    {

        //metodo para enlistar los datos
        public DataTable Listar(string texto, int op = 0)
        {
            SqlDataReader resultado;
            DataTable tabla = new DataTable();
            SqlConnection sqlCon = new SqlConnection();

            try
            {
                sqlCon = Conexion.getInstancia().CrearConexion();
                SqlCommand comando;
          
                //si el estado no es 0, estamos buscando posibles empleados
                if (op == 0 ) comando = new SqlCommand("SCM_SP_PERSONAS_LIST", sqlCon);
                else comando = new SqlCommand("SCM_SP_PERSONAS_NO_EMPLEADOS_LIST", sqlCon);

                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.Add("@texto", SqlDbType.VarChar).Value = texto;
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

        public List<CE_Persona> ObtenerPersonas()
        {
            List<CE_Persona> personas = new List<CE_Persona>();
            CD_Nacionalidades nacs = new CD_Nacionalidades();
            SqlConnection sqlCon = new SqlConnection();
            SqlDataReader resultado;

            try
            {
                sqlCon = Conexion.getInstancia().CrearConexion();
                SqlCommand comando = new SqlCommand("SCM_SP_PERSONAS_LIST", sqlCon);
                comando.CommandType = CommandType.StoredProcedure;
                sqlCon.Open();
                resultado = comando.ExecuteReader();

                while (resultado.Read())
                {
                    string Id             = (string)resultado[0];
                    string PrimerNombre   = (string)resultado[2];
                    string PrimerApellido = (string)resultado[4];

                    string SegundoNombre = resultado[3] != DBNull.Value
                                         ? (string)resultado[3]
                                         : null;                    

                    string SegundoApellido = resultado[5] != DBNull.Value
                                         ? (string)resultado[5]
                                         : null;

                    string NombreCompleto = resultado[6] != DBNull.Value
                                         ? (string)resultado[6]
                                         : null;

                    string Nacionalidad = resultado[7] != DBNull.Value
                                         ? (string)resultado[7]
                                         : null;

                    string Genero = resultado[9] != DBNull.Value
                                         ? (string)resultado[9]
                                         : null;

                    string RTN = resultado[1] != DBNull.Value
                                         ? (string)resultado[1]
                                         : null;

                    DateTime? FechaNacimiento = !Convert.IsDBNull(resultado[8])
                                            ? (DateTime)resultado[8]
                                            : (DateTime?)null;
                    

                    CE_Persona persona = new CE_Persona();
                    persona.Id = Id;
                    persona.PrimerNombre = PrimerNombre;
                    persona.SegundoNombre = SegundoNombre;
                    persona.PrimerApellido = PrimerApellido;
                    persona.SegundoApellido = SegundoApellido;
                    persona.NombreCompleto = NombreCompleto;
                    persona.FechaNacimiento = FechaNacimiento;
                    persona.Genero = Genero;
                    persona.RTN = RTN;
                    
                    CE_Nacionalidades nac  = nacs.BuscarByNacionalidad(Nacionalidad);
                    if(nac != null)
                    {
                        persona.IdNacionalidad = nac.Id;
                        persona.Nacionalidad = nac;
                    }
                 
                    personas.Add(persona);
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

            return personas;
        }




        //metodo para salvar y modificar
        public string Salvar(int opcion, CE_Persona Persona)
        {
            string rpta = "";
            SqlConnection sqlCon = new SqlConnection();

            try
            {
                sqlCon = Conexion.getInstancia().CrearConexion();
                SqlCommand comando = new SqlCommand("SCM_SP_PERSONAS_SAVE", sqlCon);
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.Add("@opcion",               SqlDbType.Int).Value = opcion;
                comando.Parameters.Add("@IdPersona",       SqlDbType.NVarChar).Value = Persona.Id;
                comando.Parameters.Add("@PrimerNombre",    SqlDbType.NVarChar).Value = Persona.PrimerNombre;
                comando.Parameters.Add("@SegundoNombre",   SqlDbType.NVarChar).Value = Persona.SegundoNombre;
                comando.Parameters.Add("@PrimerApellido",  SqlDbType.NVarChar).Value = Persona.PrimerApellido;
                comando.Parameters.Add("@SegundoApellido", SqlDbType.NVarChar).Value = Persona.SegundoApellido;
                comando.Parameters.Add("@IdNacionalidad",       SqlDbType.Int).Value = Persona.IdNacionalidad;                
                comando.Parameters.Add("@FechaNac",            SqlDbType.Date).Value = Persona.FechaNacimiento != null ? (object)Persona.FechaNacimiento : DBNull.Value;
                comando.Parameters.Add("@Genero",          SqlDbType.NVarChar).Value = Persona.Genero;
                comando.Parameters.Add("@RTN",             SqlDbType.NVarChar).Value = Persona.RTN;
                sqlCon.Open();
                rpta = comando.ExecuteNonQuery() >= 1 ? "OK" : "No se pudo ingresar el registro. \nEl ID que intentas registrar ya ha sido asignado a otra persona.";

            }
            catch (SqlException ex)
            {
                if (ex.Number == 2627) // Número de error para llave duplicada
                {
                    rpta = "El registro ya existe";
                }
                else
                {
                    rpta = ex.Message;
                }
            }
            finally
            {
                if (sqlCon.State == ConnectionState.Open) sqlCon.Close();
            }

            return rpta;
        }

        //eliminar
        public string Eliminar(CE_Persona Persona)
        {
            string rpta = "";
            SqlConnection sqlCon = new SqlConnection();

            try
            {
                sqlCon = Conexion.getInstancia().CrearConexion();
                SqlCommand comando  = new SqlCommand("SCM_SP_PERSONAS_DELETE", sqlCon);
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.Add("@IdPersona", SqlDbType.NVarChar).Value = Persona.Id;
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

        public CE_Persona BuscarById(string id)
        {
            CE_Persona persona = this.ObtenerPersonas().Find(p => p.Id.Equals(id));
            return persona;
        }
    }
}
