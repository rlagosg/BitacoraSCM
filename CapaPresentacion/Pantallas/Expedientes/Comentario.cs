using CapaEntidades.Expedientes;
using CapaNegocio.Expedientes;
using CapaNegocio.Roles;
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
using System.Web.UI.WebControls.WebParts;
using System.Windows.Forms;

namespace CapaPresentacion.Pantallas.Expedientes
{
    public partial class Comentario : Form
    {

        CE_CambioProceso cambio;
        Control frmControl;

        //variables para el efecto Switch
        private Timer switchTimer;
        private Timer showLabelTimer;
        private bool isSwitching = false;

        public Comentario(Control frmControl, CE_CambioProceso cambio)
        {
            InitializeComponent();
            this.frmControl = frmControl;
            this.cambio     = cambio;            
        }

        private void configura()
        {
            if (cambio != null) {

                configuraCombobox(cambio.EstadoActual.EstadoRol.Estado.ID);
            }
        }

        private void configuraCombobox(int id)
        {
            // Llamamos los tipos
            COMBOESTADO.DataSource = CN_ControlEstados.();
            // Configurar las propiedades del ComboBox
            COMBOESTADO.DisplayMember = "Nombre"; // Propiedad a mostrar como texto
            COMBOESTADO.ValueMember = "ID"; // Propiedad a utilizar como valor seleccionado  
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

        private void Comentario_Load(object sender, EventArgs e)
        {
            configura();
            verificaBoton();

            switchTimer = new Timer();
            switchTimer.Interval = 100; // Ajusta el intervalo según tus necesidades
            switchTimer.Tick += switchTimer_Tick;

            showLabelTimer = new Timer();
            showLabelTimer.Interval = 150; // Espera 2 segundos
            showLabelTimer.Tick += showLabelTimer_Tick;
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
    }
}
