using Bunifu.Json.Linq;
using CapaNegocio.Roles;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaPresentacion.Pantallas.Expedientes
{
    public partial class Expedientes : Form
    {
        public Expedientes()
        {
            InitializeComponent();
        }

        private void Expedientes_Load(object sender, EventArgs e)
        {
            Listar("");
        }

        public void Listar(string texto = "")
        {
            try
            {
                string busca = TXTBUSCA.Text.Trim();
                if (busca.Length > 0) Data.DataSource = CN_Estados.Listar(busca);
                else Data.DataSource = CN_Estados.Listar(texto);
                Data.Columns[0].Visible = false;

                Data.ClearSelection();
                ///if (Data.SelectedRows.Count > 0) if (indiceData >= 0) Data.Rows[indiceData].Selected = true;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void gunaCircleButton1_Click(object sender, EventArgs e)
        {
            TXTBUSCA.Text = string.Empty;
            TXTBUSCA.Focus();
            //Listado("");
        }

        private void gunaButton2_Click(object sender, EventArgs e)
        {
            
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            Busqueda frm = new Busqueda();
            frm.ShowDialog();
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {

        }
    }
}
