using CapaEntidades.Personas.Empleados;
using CapaDatos.Personas.Empleados;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using CapaEntidades.Roles;

namespace CapaNegocio.Personas.Empleados
{
    public class CN_Empleados
    {
        /// <summary>
        /// Metodo para listar los emplpeados en forma de Tabla, usando filtro de texto
        /// </summary>
        public static DataTable Listar(string texto, int op = 1, int rol = 1)
        {
            CD_Empleados datos = new CD_Empleados();
            return datos.Listar(texto, op, rol);
        }

        /// <summary>
        /// Metodo para Guarda & Modificar: 1 = salvar, 2 = modificar
        /// </summary>
        public static string Salvar(int opcion, CE_Empleado empleado)
        {
            CD_Empleados datos = new CD_Empleados();
            return datos.Salvar(opcion, empleado);
        }

        /// <summary>
        /// Metodo para Eliminar
        /// </summary>
        public static string Eliminar(CE_Empleado empleado)
        {
            CD_Empleados datos = new CD_Empleados();
            return datos.Eliminar(empleado);
        }

        public static CE_Empleado BuscaEmpleadoById(int id)
        {
            CD_Empleados datos = new CD_Empleados();
            return datos.BuscaEmpleadoById(id);
        }

        public static List<CE_Empleado> ObtenerEmpleados()
        {
            CD_Empleados datos = new CD_Empleados();
            return datos.ObtenerEmpleados();
        }

        /// <summary>
        /// Metodo para obtener un empleado, desde una lista 
        /// </summary>
        public static CE_Empleado BuscaEmpleadoById(List<CE_Empleado> lista, int id)
        {
            return lista.Find( e => e.ID == id);            
        }

    }
}
