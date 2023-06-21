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
            Data.Columns[0].Visible = false;
            Data.Columns[1].Visible = false;
            Data.Columns[5]. Visible = false;
            Data.Columns[4].Visible = false; Data.Columns[10]. Visible = false;
            Data.Columns[6].Visible = false; Data.Columns[13].Visible = false;
            Data.Columns[14].Visible = false; Data.Columns[16].Visible = false;

            Data.Columns[2].Width  = 140; //nombre          
            Data.Columns[3].Width  = 140; //fecha inicial            
            Data.Columns[7].Width  = 140; //Proceso
            Data.Columns[8].Width  = 190; //Estado
            Data.Columns[9].Width  = 300; //Comentario
            Data.Columns[12].Width = 140; //Ult.Cambio
            Data.Columns[15].Width = 90; //fecha final           
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
                        //funciones.convertInt(fila.Cells[5].Value),//IdControl          
                        //funciones.convertInt(fila.Cells[5].Value),//IdExpediente       
                        //funciones.convertString(fila.Cells[5].Value), //Expediente      
                        //funciones.convertDate(fila.Cells[5].Value), //Iniciado     
                        //CN_Persona.BuscaById(funciones.convertInt),// Iniciador   
                        //funciones.convertString(fila.Cells[5].Value), //ObsInicial      
                        //funciones.convertString(fila.Cells[5].Value), //Proceso         
                        //funciones.convertString(fila.Cells[5].Value), //Estado          
                        //funciones.convertString(fila.Cells[5].Value), //Comentario      
                        //CN_Persona.BuscaById(funciones.convertInt),// Encargado   
                        //funciones.convertDate(fila.Cells[5].Value), //UltCambio    
                        //CN_Persona.BuscaById(funciones.convertInt),// Finalizador 
                        //funciones.convertDate(fila.Cells[5].Value), //Finalizacion 
                        //funciones.convertString(fila.Cells[5].Value) //ObsFinal        
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
