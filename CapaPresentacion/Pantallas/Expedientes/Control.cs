using Bunifu.Framework.UI;
using CapaEntidades.Expedientes;
using CapaEntidades.Roles;
using CapaNegocio.Expedientes;
using CapaNegocio.Roles;
using CapaPresentacion.Pantallas.Roles;
using Guna.UI.WinForms;
using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI;
using System.Windows.Forms;

namespace CapaPresentacion.Pantallas.Expedientes
{
    public partial class Control : Form
    {
        CE_CambioProceso cambioProceso;
        Expedientes frmExpediente;
        Funciones funciones = new Funciones();
        CE_Control control;
        public Control(Expedientes frm, CE_CambioProceso cambio )
        {
            InitializeComponent();
            this.cambioProceso = cambio;
            this.frmExpediente = frm;
        }

        private void BTNSALVAR_Click(object sender, EventArgs e)
        {

        }

        private async void Control_Load(object sender, EventArgs e)
        {
            llenar();           

            if (cambioProceso != null) control = cambioProceso.Control;

            Tabs.SelectedIndex = 0;

            // Esperar 3 segundos
            await Task.Delay(400);
            // Ejecutar BuscaEstado() en segundo plano
            if (cambioProceso != null) await Task.Run(() => BuscaEstado());
        }

        private void BuscaEstado()
        {
            cambioProceso.EstadoActual = CN_ControlEstados.BuscarById(cambioProceso.IdEstadoActual);
        }

        private void llenar()
        {
            if(cambioProceso != null)
            {   CE_Control control = cambioProceso.Control;
                TXTINICIADOR.Text  = control.Iniciador.Persona.NombreCompleto;
                TXTOBSINI.Text     = control.ObsInicial;
                TXTRECIBIDO.Text   = cambioProceso.Recibe.Persona.NombreCompleto;
                TXTOBS.Text        = cambioProceso.Observaciones;                 
                paneli.Controls.Add(ObtenerDatePicker(control.Iniciado));
                panelf.Controls.Add(ObtenerDatePicker(cambioProceso.Fecha));

                TXTESTADO.Text = control.Estado;
                TXTMYOBS.Text  = control.Comentario;
                panelU.Controls.Add(ObtenerDatePicker(control.UltCambio));
            }

            MostrarTareas();
        }

        private void MostrarTareas()
        {
            List<CE_Estado> Pendientes  = CN_ControlEstados.ObtenerTareas(cambioProceso, true );
            List<CE_Estado> Completados = CN_ControlEstados.ObtenerTareas(cambioProceso, false);

            double porcentaje = (double)Completados.Count / (Pendientes.Count + Completados.Count) * 100;
            progresoTareas.Value = (int)porcentaje;


            DataPendientes.DataSource = Pendientes;
            DataCompletos.DataSource  = Completados;
            DataPendientes.Columns[0].Visible  = false; DataPendientes.Columns[2].Visible = false;
            DataPendientes.Columns[3].Visible  = false; DataCompletos. Columns[0].Visible = false;
            DataCompletos.Columns [2].Visible  = false; DataCompletos. Columns[3].Visible = false;
            DataPendientes.Columns[1].HeaderText = "Estados Pendientes"; 
            DataCompletos. Columns[1].HeaderText = "Estados Completados";
        }

        private GunaDateTimePicker ObtenerDatePicker(DateTime? fecha)
        {

            if (!fecha.HasValue)
                return null;

            CustomGunaDateTimePicker Picker = new CustomGunaDateTimePicker();

            // Configurar la fecha
            Picker.Value = fecha.Value;

            // Modificar los colores
            Picker.FocusedColor       = Color.FromArgb(68, 88, 112);
            Picker.OnHoverBaseColor   = Color.White;
            Picker.OnHoverBorderColor = Color.White;
            Picker.OnHoverForeColor   = Color.FromArgb(76, 118, 175);


            Picker.BaseColor   = Color.White;            
            Picker.BorderColor = Color.White;            
            Picker.ForeColor   = Color.FromArgb(76, 118, 175);
            Picker.Size        = new Size(275, 36);
            Picker.BorderSize  = 1;
            Picker.Radius      = 5;
            return Picker;
        }

        public void Actualizar()
        {
            // Obtener el índice de la pestaña seleccionada
            int selectedTabIndex = Tabs.SelectedIndex;

            if (selectedTabIndex == 0)
            {
                MostrarTareas();
            }
            else if (selectedTabIndex == 1 || selectedTabIndex == 2)
            {
                var currentData = selectedTabIndex == 1 ? Data : DataR;

                if (currentData != null)
                {
                    var dataSource = CN_Controles.Estados(control);
                    var columns = currentData.Columns;

                    currentData.DataSource = dataSource;
                    columns[0].Visible = false;
                    columns[1].Visible = false;

                    if (selectedTabIndex == 2)
                    {
                        dataSource = CN_Controles.Resumen(control);
                        currentData.DataSource = dataSource;
                        columns = currentData.Columns;
                        columns[1].Visible = true;
                    }
                }
            }
        }

        private void btnFINALIZAR_Click(object sender, EventArgs e)
        {
            
        }

        private void guna2Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Data_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            // Establecer el modo de ajuste de texto (WrapMode) en la columna 5
            Data.Columns[5].DefaultCellStyle.WrapMode = DataGridViewTriState.True;

            // Autoajustar las filas para mostrar todo el contenido
            Data.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;

            // Ajustar el tamaño de las filas
            Data.AutoResizeRows(DataGridViewAutoSizeRowsMode.AllCells);
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

        private void Tabs_SelectedIndexChanged(object sender, EventArgs e)
        {
            Actualizar();
        }

        private void tab0_Click(object sender, EventArgs e)
        {

        }

        private void TXTFINALIZAR_Click(object sender, EventArgs e)
        {
            CambioProceso frm = new CambioProceso(null, control, 2);
            frm.ShowDialog();
        }

        private void TXTBUSCA_Click(object sender, EventArgs e)
        {
            Comentario frm = new Comentario(this, cambioProceso);
            frm.ShowDialog();
        }

        private void tab1_Click(object sender, EventArgs e)
        {

        }
    }
}
