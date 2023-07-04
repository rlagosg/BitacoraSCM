using CapaEntidades.Personas;
using CapaEntidades.Personas.Empleados;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaPresentacion.Pantallas.Personas.Empleados
{
    public partial class EmpleadosE : Form
    {
        CE_Empleado empleado = new CE_Empleado();
        CE_Persona persona;
        public EmpleadosE()
        {
            InitializeComponent();
        }

        private void gunaButton1_Click(object sender, EventArgs e)
        {
            Personas frm = new Personas(1, this); 
            frm.ShowDialog();
        }

        private void EmpleadosE_Load(object sender, EventArgs e)
        {

        }

        public void ActualizaPersona(CE_Persona persona)
        {
            empleado.Persona = persona;
            TXTNOMBRE.Text = persona.NombreCompleto;
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {

        }
    }
}
