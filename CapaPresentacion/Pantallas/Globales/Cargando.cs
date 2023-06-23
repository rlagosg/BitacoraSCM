using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaPresentacion.Pantallas.Globales
{
    public partial class Cargando : Form
    {
        public Cargando()
        {
            InitializeComponent();
        }

        private void Cargando_Load(object sender, EventArgs e)
        {

        }

        public void Cerrar()
        {
            this.Close();
        }

        public void Exits()
        {
            this.Close();
        }
    }
}
