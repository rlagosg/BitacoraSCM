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
            Cargar();
        }

        void Cargar()
        {
            Data.RowTemplate.Height = 35; // Altura de las filas
            Data.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
            

            // Establecer el estilo de la línea divisora entre las filas
            Data.CellPainting += (sender, e) =>
            {
                if (e.RowIndex >= 0 && e.RowIndex < Data.RowCount - 1)
                {
                    e.Paint(e.ClipBounds, DataGridViewPaintParts.All);

                    // Dibujar la línea divisora
                    int dividerHeight = 3; // Altura de la línea divisora (más gruesa)
                    int dividerY = e.CellBounds.Bottom - dividerHeight;
                    Color dividerColor = Color.FromArgb(245, 247, 251);
                    e.Graphics.DrawLine(new Pen(dividerColor, dividerHeight), e.CellBounds.Left, dividerY, e.CellBounds.Right, dividerY);

                    e.Handled = true;
                }
            };            
        }

        public void Listar(string texto = "")
        {
            try
            {
                string busca = TXTBUSCA.Text.Trim();
                if (busca.Length > 0)
                {
                    Data.DataSource = CN_Estados.Listar(busca);
                    Data.DataSource = CN_Estados.Listar(busca);
                }
                else
                {
                    Data.DataSource = CN_Estados.Listar(texto);
                    Data.DataSource = CN_Estados.Listar(texto);
                }
                Data.Columns[0].Visible = false;
                Data.Columns[0].Visible = false;

                Data.ClearSelection();
                Data.Columns[0].Visible = false;
                ///if (Data.SelectedRows.Count > 0) if (indiceData >= 0) Data.Rows[indiceData].Selected = true;
                Cargar();

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

        private void Data_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            // Verificar si es el encabezado de la columna
            if (e.RowIndex == -1 && e.ColumnIndex >= 0)
            {
                e.CellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                e.CellStyle.Padding = new Padding(0, 10, 0, 10);
                e.FormattingApplied = true;
            }
        }
    }
}
