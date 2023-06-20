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
        public EmpleadosE()
        {
            InitializeComponent();
        }

        private void gunaButton1_Click(object sender, EventArgs e)
        {
            Personas frm = new Personas();
            frm.ShowDialog();
        }

        private void EmpleadosE_Load(object sender, EventArgs e)
        {

        }
    }
}
