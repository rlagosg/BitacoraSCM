﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Text;
using CapaDatos.Roles;
using CapaEntidades.Roles;
using CapaEntidades.Personas;
using System.Collections;

namespace CapaDatos.Controles
{
    public class CD_Roles
    {
        /// <summary>
        /// Metodo para enlistar los datos
        /// </summary>
        public DataTable Listar()
        {
            SqlDataReader resultado;
            DataTable tabla      = new DataTable();
            SqlConnection sqlCon = new SqlConnection();

            try
            {
                sqlCon = Conexion.getInstancia().CrearConexion();
                SqlCommand comando  = new SqlCommand("SELECT * FROM ROLES", sqlCon);
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

        /// <summary>
        /// Metodo para obtener los Roles, devolviendo una lista de objetos
        /// </summary>
        public List<CE_Rol> ObtenerRoles()
        {
            List<CE_Rol> roles   = new List<CE_Rol>();
            roles.Add(new CE_Rol(-1, "Selecciona", ""));

            SqlConnection sqlCon = new SqlConnection();
            SqlDataReader resultado;

            try
            {
                sqlCon = Conexion.getInstancia().CrearConexion();
                SqlCommand comando  = new SqlCommand("SELECT * FROM ROLES", sqlCon);
                comando.CommandType = CommandType.Text;
                sqlCon.Open();
                resultado = comando.ExecuteReader();

                while (resultado.Read())
                {
                    int ID             = (int)    resultado[0];
                    string Nombre      = (string) resultado[1];  
                    
                    string Descripcion = resultado[2] != DBNull.Value
                                         ? (string)resultado[2]
                                         : null;

                    CE_Rol rol = new CE_Rol
                    (
                        ID,
                        Nombre,
                        Descripcion                      
                    );
                    roles.Add(rol);
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

            return roles;
        }

        /// <summary>
        /// Obtiene un rol por nombre
        /// </summary>
        public CE_Rol RolByName(string nombre)
        {            
            foreach (CE_Rol Rol in ObtenerRoles())
            {                
                if (Rol.Nombre.ToLower().Equals(nombre)) return Rol;
            }

            return null;
        }

        public CE_Rol RolById(int id)
        {
            return this.ObtenerRoles().Find(r => r.ID == id);
        }
    }
}
