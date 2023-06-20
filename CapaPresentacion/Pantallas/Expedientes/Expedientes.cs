using Bunifu.Json.Linq;
using CapaEntidades.Expedientes;
using CapaEntidades.Roles;
using CapaNegocio.Expedientes;
using CapaNegocio.Roles;
using CapaPresentacion.Pantallas.Roles;
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
        Funciones funciones = new Funciones();
        CE_Expediente expediente;
        int indiceData = -1;
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
            guna2ComboBox1.SelectedIndex = 0;
            guna2ComboBox2.SelectedIndex = 0;   
        }

        public void Listar(string texto = "")
        {
            try
            {
                string busca = TXTBUSCA.Text.Trim();
                if (busca.Length > 0)
                {
                    Data.DataSource = CN_Expedientes.Listar(busca);                    
                }
                else
                {                    
                    Data.DataSource = CN_Expedientes.Listar(texto);
                }

                Tabla();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void Tabla()
        {
            Data.Columns[0].Visible = false; Data.Columns[4]. Visible = false;
            Data.Columns[3].Visible = false; Data.Columns[9]. Visible = false;
            Data.Columns[5].Visible = false; Data.Columns[13].Visible = false;

            Data.Columns[1].Width  = 120; //nombre          
            Data.Columns[2].Width  = 140; //fecha inicial            
            Data.Columns[6].Width  = 140; //Proceso
            Data.Columns[7].Width  = 150; //Estado
            Data.Columns[8].Width  = 300; //Comentario
            Data.Columns[11].Width = 140; //Ult.Cambio
            Data.Columns[12].Width = 140; //fecha final           
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

        private void TXTBUSCA_TextChanged(object sender, EventArgs e)
        {
            Listar(TXTBUSCA.Text.Trim());
        }

        private bool validaItem()
        {
            if (Data.SelectedRows.Count > 0)
            {
                DataGridViewRow fila = Data.SelectedRows[0];

                if (!funciones.esVacio(fila.Cells[0].Value))
                {
                    // Sacamos los datos del grid                                    
                    expediente = new CE_Expediente(
                        funciones.convertInt    (fila.Cells[0]. Value), //id
                        funciones.convertString (fila.Cells[1]. Value), //nombre
                        funciones.convertDate   (fila.Cells[2]. Value),
                        funciones.convertInt    (fila.Cells[3]. Value),
                        funciones.convertString (fila.Cells[4]. Value),
                        funciones.convertString (fila.Cells[5]. Value),
                        funciones.convertString (fila.Cells[6]. Value),
                        funciones.convertString (fila.Cells[7]. Value),
                        funciones.convertString (fila.Cells[8]. Value),
                        funciones.convertInt    (fila.Cells[9]. Value),
                        funciones.convertString (fila.Cells[10].Value),
                        funciones.convertString (fila.Cells[11].Value),
                        funciones.convertDate   (fila.Cells[12].Value),
                        funciones.convertString (fila.Cells[13].Value)                        
                    );
                    indiceData = Data.CurrentRow.Index;
                    return true;
                }
            }
            return false;
        }

        private void Data_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (validaItem())
            {
                Expediente form = new Expediente(expediente);
                form.ShowDialog();
            }
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            Expediente form = new Expediente();
            form.ShowDialog();
        }
    }
}
