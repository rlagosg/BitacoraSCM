using CapaNegocio;
using Guna.UI2.WinForms.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaPresentacion
{
    //clase para crear funciones globales que utilice toda la aplicacion
    internal class Funciones
    {

        /// <summary>
        /// mostrar mensaje en patalla
        /// </summary>
        public void MensajeShow(string mensaje, bool informacion = true, bool error = false)
        {
            //funcion para regresar una ventada de mensaje en pantalla
            if (!informacion && error)  MessageBox.Show(mensaje, "Aviso del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            if (informacion  && !error) MessageBox.Show(mensaje, "Aviso del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
            if (!informacion && !error) MessageBox.Show(mensaje, "Aviso del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        /// <summary>
        /// comprobar si el valor es null o vacio
        /// </summary>
        public bool esVacio(object valor)
        {
            if (string.IsNullOrEmpty(Convert.ToString(valor))) return true;
            return false;
        }

        /// <summary>
        ///mensaje de dialogo de eliminacion, con retorno de una respuesta bool
        /// </summary>
        public bool DialogoEliminar()
        {
            DialogResult Opcion;
            Opcion = MessageBox.Show("¿Estás seguro de eliminar el registro seleccionado?", "Aviso del Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (Opcion == DialogResult.Yes) return true;
            return false;
        }

        /// <summary>
        ///mensaje de dialogo de pregunta, con retorno de una respuesta bool
        /// </summary>
        public bool DialogoPregunta(string pregunta)
        {
            DialogResult Opcion;
            Opcion = MessageBox.Show(pregunta, "Aviso del Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (Opcion == DialogResult.Yes) return true;
            return false;
        }

        /// <summary>
        /// funcion para evaluar la respuesta de eliminacion y mostrar mensaje en pantalla
        /// </summary>
        public void MensajeEliminar(string Rpta)
        {
            if (Rpta.Equals("OK")) MensajeShow("El registro ha sido eliminado");
            else MensajeShow(Rpta, false, true);
        }

        /// <summary>
        /// convertir un objeto a entero
        /// </summary>
        public Int32 convertInt(object valor) 
        {
            if (valor != DBNull.Value)  return Convert.ToInt32(valor);
            else return 0; // Valor predeterminado cuando el valor es DBNull
        }

        /// <summary>
        /// convertir un objeto a texto
        /// </summary>
        public string convertString(object valor) { return Convert.ToString(valor); }


        /// <summary>
        /// convertir un objeto a bool
        /// </summary>
        public bool convertBool(object valor) { return Convert.ToBoolean(valor); }
        /// <summary>
        /// convertir de objeto a fecha sin hora
        /// </summary>
        public DateTime? convertDate(object valor) {
            if (valor != DBNull.Value) return Convert.ToDateTime(valor).Date;
            else return null;            
        }
    }
}
