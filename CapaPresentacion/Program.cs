using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaPresentacion.Pantallas.Personas;
using CapaPresentacion.Pantallas;
using CapaPresentacion.Pantallas.Controles;
using CapaPresentacion.Pantallas.Roles;
using CapaPresentacion.Pantallas.Expedientes;
using Control = CapaPresentacion.Pantallas.Expedientes.Control;
using CapaPresentacion.Pantallas.Usuarios;

namespace CapaPresentacion
{
    static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Comentario());
        }
    }
}
