using CapaEntidades.Personas.Empleados;
using CapaDatos.Personas.Empleados;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace CapaNegocio.Personas.Empleados
{
    public class CN_Empleados
    {
        /// <summary>
        /// Metodo para listar los emplpeados en forma de Tabla, usando filtro de texto
        /// </summary>
        public static DataTable Listar(string texto)
        {
            CD_Empleados datos = new CD_Empleados();
            return datos.Listar(texto);
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
    }
}
