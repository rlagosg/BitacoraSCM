using CapaDatos.Roles;
using CapaEntidades.Expedientes;
using CapaEntidades.Roles;
using CapaNegocio.Expedientes;
using CapaNegocio.Personas.Empleados;
using CapaNegocio.Roles;
using CapaPresentacion.Pantallas.Globales;
using Guna.UI2.WinForms;
using Microsoft.VisualBasic.Logging;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI;
using System.Web.UI.WebControls.WebParts;
using System.Windows.Forms;

namespace CapaPresentacion.Pantallas.Expedientes
{
    public partial class Comentario : Form
    {

        CE_CambioProceso cambio;
        Control frmControl;
        CE_EstadoRol estadoSeleccionado;
        CE_ControlEstado controlEstado;
        List<CE_ControlEstado> ListaControles;
        Funciones funciones = new Funciones();

        //variables para el efecto Switch
        private Timer switchTimer;
        private Timer showLabelTimer;
        private bool isSwitching = false;

        public Comentario(Control frmControl, CE_CambioProceso cambio)
        {
            InitializeComponent();
            this.frmControl    = frmControl;
            this.cambio        = cambio;
            this.controlEstado = cambio.EstadoActual;
            label3.Text = cambio.EstadoActual.EstadoRol.Estado.Nombre;
        }

        private void configura()
        {
            if (cambio != null) {

                Switch.Checked  = controlEstado.Compleato;
                int id = controlEstado.EstadoRol.Estado.ID;
                configuraCombobox(id);                                
            }
        }


        private void configuraCombobox(int id)
        {
            CE_Rol Rol = CN_Roles.RolById(cambio.Control.Rol);
            var Data   = CN_EstadosRoles.ListaEstadosByRol(Rol);
            
            COMBOESTADO.DataSource = Data;
            COMBOESTADO.DisplayMember = "Nombre";
            COMBOESTADO.ValueMember = "ID";

            // Buscar el objeto con el ID deseado en la lista de objetos
            estadoSeleccionado = Data.FirstOrDefault(estado => estado.Estado.ID == id);

            if (estadoSeleccionado != null)
            {
                // Seleccionar el objeto en el ComboBox
                COMBOESTADO.SelectedValue = estadoSeleccionado.ID;
            }

            // Asociar el evento de cambio de selección del ComboBox
            COMBOESTADO.SelectedIndexChanged += COMBOESTADO_SelectedIndexChanged;            
        }

        private void verificaBoton()
        {
            if (TXTCOMENTARIO.Text.Length == 0)
            {
                btnComentar.Enabled = false;
                btnComentar.Cursor = Cursors.No;
            }
            else
            {
                btnComentar.Enabled = true;
                btnComentar.Cursor = Cursors.Hand;                
            }
        }

        private void TXTCOMENTARIO_TextChanged(object sender, EventArgs e)
        {
            verificaBoton();
            Guna2TextBox textBox = (Guna2TextBox)sender;

            //efecto visual para ajustar manios de letras del texbox
            if      (textBox.TextLength > 405) textBox.Font = new Font("Segoe UI", 12.5f);
            else if (textBox.TextLength > 290) textBox.Font = new Font("Segoe UI",   13f);
            else if (textBox.TextLength > 170) textBox.Font = new Font("Segoe UI",   14f);
            else if (textBox.TextLength > 110) textBox.Font = new Font("Segoe UI",   15f);
            else     textBox.Font = new Font("Segoe UI", 16.5f);

            //activacion del scrollBar cuando el texbox tenga enters o es comentario largo
            //contador de enters
            int lineBreakCount = CountLineBreaks(textBox.Text);
            //contador de capacidad del texbox
            double textPercentage = (double)textBox.TextLength / textBox.MaxLength;            

            //validamos 6 saltos de lineas o 90% de letras cubiertas
            if (lineBreakCount >= 6 || textPercentage >= 0.9)
            {
                textBox.ScrollBars = ScrollBars.Vertical;
                textBox.Size = new Size(471, 245);
                textBox.FocusedState.BorderColor = Color.White;                
                separador.Visible = true;
            }
            else
            {
                textBox.ScrollBars = ScrollBars.None;
                textBox.Size = new Size(450, 245);
                textBox.FocusedState.BorderColor = Color.FromArgb(76, 118, 175);
                separador.Visible = false;
            }
        }

        //funcion para contar los enters
        private int CountLineBreaks(string text)
        {
            int count = 0;
            int index = -1;

            while ((index = text.IndexOf(Environment.NewLine, index + 1)) != -1)
            {
                count++;
            }

            return count;
        }

        private void ConfigureSwitchText()
        {
            if (Switch.Checked)
            {
                if (!isSwitching)
                {
                    isSwitching = true;
                    labelSwitchOn.Visible = false;
                    labelSwitchOff.Visible = false;
                    switchTimer.Stop();
                    switchTimer.Start();
                }
            }
            else
            {
                if (!isSwitching)
                {
                    isSwitching = true;
                    labelSwitchOn.Visible = false;
                    labelSwitchOff.Visible = false;
                    switchTimer.Stop();
                    switchTimer.Start();
                }
            }
        }

        private void Switch_CheckedChanged(object sender, EventArgs e)
        {
            ConfigureSwitchText();
        }

        private void switchTimer_Tick(object sender, EventArgs e)
        {
            switchTimer.Stop();
            isSwitching = false;
            showLabelTimer.Start();
        }

        private void showLabelTimer_Tick(object sender, EventArgs e)
        {
            showLabelTimer.Stop();
            labelSwitchOn.Visible = Switch.Checked;
            labelSwitchOff.Visible = !Switch.Checked;
        }

        private async void Comentario_Load(object sender, EventArgs e)
        {
            switchTimer = new Timer();
            switchTimer.Interval = 100; // Ajusta el intervalo según tus necesidades
            switchTimer.Tick += switchTimer_Tick;

            showLabelTimer = new Timer();
            showLabelTimer.Interval = 150; // Espera 2 segundos
            showLabelTimer.Tick += showLabelTimer_Tick;

            configura();
            verificaBoton();

            await Task.Delay(400);
            await Task.Run(() => ListarControlEstados());
        }

        private void ListarControlEstados()
        {
            ListaControles = CN_ControlEstados.BuscarByIdCambio(cambio.ID);
        }

        private void labelSwitch_Click(object sender, EventArgs e)
        {
            if (labelSwitchOff.Text.Equals("finalizar")) Switch.Checked = true;         
            
        }

        private void label2Switch_Click(object sender, EventArgs e)
        {
            if (labelSwitchOn.Text.Equals("finalizado")) Switch.Checked = false;
        }

        private void separator_Click(object sender, EventArgs e)
        {

        }


        private void btnComentar_Click(object sender, EventArgs e)
        {
            
            try
            {       

                string comentario = TXTCOMENTARIO.Text.Trim();

                if (comentario.Length == 0 || estadoSeleccionado == null)
                {
                    string mensaje = "";
                    if (comentario.Length == 0 ) mensaje = "No has proporcionado un comentario. \n";
                    if (estadoSeleccionado == null) mensaje = "No has seleccionado un estado.";
                    
                    funciones.MensajeShowModal(mensaje, false, true);
                }
                else
                {                 
                    //si no existe lo creamos
                    if ( controlEstado == null ) controlEstado = new CE_ControlEstado();

                    controlEstado.IdCambioProceso = cambio.ID;
                    controlEstado.Encargado = cambio.Recibe;
                    controlEstado.EstadoRol = estadoSeleccionado;                    
                    controlEstado.Compleato = Switch.Checked;

                    //obtenemos los datos del comentario
                    controlEstado.Comentario = new CE_Comentario(controlEstado, comentario);

                    string Rpta = CN_ControlEstados.Salvar(controlEstado);

                    //continua el proceso
                    if (Rpta.Equals("OK"))
                    {
                        //funciones.MensajeShowModal("Los datos han sido guardados correctamente", true);
                        frmControl.Actualizar();
                        frmControl.cambioProceso.EstadoActual = controlEstado;
                        this.Close();
                    }
                    else
                    {
                        //si ocurrio un error lo mostramos
                        funciones.MensajeShowModal(Rpta, false);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void COMBOESTADO_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Actualizar la variable global con el objeto seleccionado en el ComboBox
            estadoSeleccionado = COMBOESTADO.SelectedItem as CE_EstadoRol;

            // Actualiza el Control
            if (ListaControles != null) controlEstado = CN_ControlEstados.BuscarByCambioYEstadoLIST(ListaControles, cambio, estadoSeleccionado);
            if (controlEstado  != null) Switch.Checked = controlEstado.Compleato; else Switch.Checked = false;
        }

    }
}
