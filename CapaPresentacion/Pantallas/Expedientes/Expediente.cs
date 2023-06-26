using Bunifu.Framework.UI;
using Bunifu.UI.WinForms.BunifuButton;
using CapaEntidades.Expedientes;
using CapaEntidades.Personas.Empleados;
using CapaEntidades.Roles;
using CapaNegocio.Expedientes;
using CapaNegocio.Roles;
using Guna.UI.WinForms;
using Guna.UI2.WinForms;
using MetroFramework.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace CapaPresentacion.Pantallas.Expedientes
{
    public partial class Expediente : Form
    {
        CE_Control control;
        CE_Rol rol;
        Expedientes frmExpedientes;
        Funciones funciones = new Funciones();
        public Expediente(Expedientes frm, CE_Control exped = null)
        {
            InitializeComponent();            
            this.control = exped;
            this.frmExpedientes = frm;
            llenar();
        }

 
        private void llenar()
        {
            
            if (control != null)
            {
                TXTBUSCA.Text = control.Expediente.Expediente;

                if (control.Iniciador != null)
                {
                    TXTINICIADOR.Text = control.Iniciador.Persona.NombreCompleto;
                    paneli.Controls.Add(ObtenerDatePicker(control.Iniciado.Value));                    
                }

                if (control.Finalizador != null)
                {
                    TXTINICIADOR.Text = control.Finalizador.Persona.NombreCompleto;                    
                    panelf.Controls.Add(ObtenerDatePicker(control.Finalizacion.Value));
                }

                if (control.Encargado != null)
                {
                    TXTULTIMOs = new CustomGunaDateTimePicker();
                    TXTULTIMOs.Value = control.UltCambio.Value;

                    TXTENCARGADO.Text  = control.Encargado.Persona.NombreCompleto;                    
                    TXTPROCESO.Text    = control.Proceso;
                    TXTESTADO.Text     = control.Estado;
                    TXTCOMENTARIO.Text = control.Comentario;                    
                    panel.Controls.Add(ObtenerDatePicker(control.UltCambio.Value));
                }
                
                llenarGridGeneral();
            }
            else
            {
                Tabs.SelectedIndex = 1;
            }

        }

        private GunaDateTimePicker ObtenerDatePicker(DateTime fecha)
        {

            CustomGunaDateTimePicker Picker = new CustomGunaDateTimePicker();

            // Configurar la fecha
            Picker.Value = fecha;

            // Modificar los colores
            Picker.FocusedColor = Color.FromArgb(68, 88, 112);            
            Picker.OnHoverBaseColor = Color.White;
            Picker.OnHoverBorderColor = Color.FromArgb(76, 118, 175);
            Picker.OnHoverForeColor = Color.FromArgb(76, 118, 175);


            Picker.BaseColor = Color.White;
            //Picker.BorderColor = Color.Silver;             
            Picker.BorderColor = Color.FromArgb(76, 118, 175);
            //Picker.ForeColor = Color.Black;
            Picker.ForeColor = Color.FromArgb(76, 118, 175);
            Picker.Size = new Size(275, 36);
            Picker.BorderSize = 1;
            Picker.Radius = 5;

            // Otros ajustes de apariencia según sea necesario
            return Picker;
        }


        private void llenarGridGeneral()
        {
            DataG.DataSource = CN_CambiosProceso.Listar(control);
            DataG.Columns[1].Visible = false;
            DataG.Columns[3].Visible = false;
        }

        private void Expediente_Load(object sender, EventArgs e)
        {
            
        }

        private void BTNSALVAR_Click(object sender, EventArgs e)
        {
            progres0.Value = progres0.Value + 5;
            progres1.Value = progres1.Value + 5;
            progres2.Value = progres2.Value + 5;
            progres3.Value = progres3.Value + 5;
        }


        private void CambiaIndex(int boton)
        {
            Tabs.SelectedIndex = boton;
        }

        private void Tabs_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Obtener el índice de la pestaña seleccionada
            int selectedTabIndex = Tabs.SelectedIndex;
            
            // Asignamos el rol al Expediente
            rol = CN_Roles.RolByName(Tabs.SelectedTab.Text.Trim());
            if ( rol != null) control.Rol = rol.ID;            

            List<Guna2DataGridView> Datas = new List<Guna2DataGridView>()
            {
                null, null, DataC, DataT, DataV, DataD, DataR
            };

            // Llenamos las datas
            if (selectedTabIndex > 1 && selectedTabIndex < Datas.Count && Datas[selectedTabIndex] != null)
            {
                var currentData = Datas[selectedTabIndex];

                var dataSource = CN_Controles.Estados(control);
                var columns = currentData.Columns;

                currentData.DataSource = dataSource;
                columns[0].Visible = false; columns[1].Visible = false;

                if (selectedTabIndex == 6)
                {
                    dataSource = CN_Controles.Resumen(control);
                    currentData.DataSource = dataSource;
                    columns = currentData.Columns;
                    columns[0].Visible = false;
                }
            }
        }



        private void tab1_Click(object sender, EventArgs e)
        {
        }

        private void tab0_Click(object sender, EventArgs e)
        {
            
        }

        private void guna2Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tab6_Click(object sender, EventArgs e)
        {

        }

        private void tab1_Click_1(object sender, EventArgs e)
        {

        }

        private void DataG_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
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
    }
}
