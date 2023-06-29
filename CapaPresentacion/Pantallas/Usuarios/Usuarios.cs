using CapaNegocio.Personas;
using CapaNegocio.Usuarios;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.Design.AxImporter;

namespace CapaPresentacion.Pantallas.Usuarios
{
    public partial class Usuarios : Form
    {

        Funciones funciones = new Funciones();
        //indice de la tabla
        int indiceData = -1;

        public Usuarios()
        {
            InitializeComponent();
        }

        private void Usuarios_Load(object sender, EventArgs e)
        {
            Listado("");
        }

        //lista
        public void Listado(string texto)
        {
            try
            {
                string temp = TXTBUSCA.Text.Trim();
                if (funciones.esVacio(texto)) Data.DataSource = CN_Usuarios.Listar(texto);
                else Data.DataSource = CN_Usuarios.Listar(texto);

                Data.ClearSelection();
                if (indiceData >= 0) Data.Rows[indiceData].Selected = true;
                Data.Columns[0].Visible = false; Data.Columns[2].Visible = false;
                Data.Columns[5].Width = 70; //Data.Columns[3].Visible = false;
                Data.Columns[1].Width = 200; //Data.Columns[7].Width = 200;
                Data.Columns[3].Width = 300;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void TXTBUSCA_TextChanged(object sender, EventArgs e)
        {
            indiceData = -1;
            this.Listado(TXTBUSCA.Text);
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

        private bool validaItem()
        {
            if (Data.SelectedRows.Count > 0)
            {
                DataGridViewRow fila = Data.SelectedRows[0];

                if (!funciones.esVacio(fila.Cells[0].Value))
                {
                    //persona.Id = funciones.convertString(fila.Cells[0].Value);
                    //persona.RTN = funciones.convertString(fila.Cells[1].Value);
                    //persona.PrimerNombre = funciones.convertString(fila.Cells[2].Value);
                    //persona.SegundoNombre = funciones.convertString(fila.Cells[3].Value);
                    //persona.PrimerApellido = funciones.convertString(fila.Cells[4].Value);
                    //persona.SegundoApellido = funciones.convertString(fila.Cells[5].Value);
                    //persona.NombreCompleto = funciones.convertString(fila.Cells[6].Value);
                    //persona.FechaNacimiento = funciones.convertDate(fila.Cells[8].Value);
                    //persona.Genero = funciones.convertString(fila.Cells[9].Value);
                    //BuscaByName(funciones.convertString(fila.Cells[7].Value));
                    //indiceData = Data.CurrentRow.Index;
                    return true;
                }
            }
            return false;
        }

        private void Data_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (validaItem())
            {
                UsuariosE form = new UsuariosE();
                form.ShowDialog();
            }
        }
    }
}
