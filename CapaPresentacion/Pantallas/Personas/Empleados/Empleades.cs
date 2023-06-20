using CapaNegocio.Expedientes;
using CapaNegocio.Personas.Empleados;
using CapaPresentacion.Pantallas.Personas.Empleados;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaPresentacion.Pantallas.Personas
{
    public partial class Empleades : Form
    {
        public Empleades()
        {
            InitializeComponent();
        }

        private void Empleados_Load(object sender, EventArgs e)
        {
            Listar();
            Tabla();
        }

        private void Tabla()
        {
            Data.Columns[3].Visible = false; 
            Data.Columns[0].Width = 150; //nombre          
            Data.Columns[1].Width = 140; //fecha inicial                               
        }

        public void Listar(string texto = "")
        {
            try
            {
                string busca = TXTBUSCA.Text.Trim();
                if (busca.Length > 0) Data.DataSource = CN_Empleados.Listar(busca);
                else Data.DataSource = CN_Empleados.Listar(texto);           
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void Data_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            // Verificar si es el encabezado de la columna
            if (e.RowIndex == -1 && e.ColumnIndex >= 0)
            {
                e.Paint(e.ClipBounds, DataGridViewPaintParts.All);

                // Crear el color personalizado
                Color separatorColor = Color.FromArgb(245, 247, 251);
                int separatorThickness = 8; // Grosor de la línea separadora

                // Dibujar la línea separadora
                int dividerY = e.CellBounds.Bottom - separatorThickness;
                using (Pen separatorPen = new Pen(separatorColor, separatorThickness))
                {
                    e.Graphics.DrawLine(separatorPen, e.CellBounds.Left, dividerY, e.CellBounds.Right, dividerY);
                }

                e.Handled = true;
            }
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            EmpleadosE frm = new EmpleadosE();
            frm.ShowDialog();
        }
    }
}
