using Bunifu.Framework.UI;
using Bunifu.UI.WinForms.BunifuButton;
using CapaEntidades.Expedientes;
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
        CE_Expediente expediente;
        public Expediente(CE_Expediente exped)
        {
            InitializeComponent();            
            this.expediente = exped;
            llenar();
            
        }

        private void llenar()
        {
            if (expediente != null) {
                TXTBUSCA.Text = expediente.Expediente;
            }
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

            // Actualizar la visibilidad de los controles en cada pestaña
            switch (selectedTabIndex)
            {
                case 0:
                    // Mostrar los controles de la primera pestaña
                    Grupo0.Visible = true;
                    Grupo1.Visible = false;
                    // ...
                    break;

                case 1:
                    // Mostrar los controles de la segunda pestaña
                    Grupo0.Visible = false;
                    Grupo1.Visible = true;
                    // ...
                    break;

                // Agrega más casos según el número de pestañas

                default:
                    break;
            }
        }



        private void tab1_Click(object sender, EventArgs e)
        {
        }

        private void tab0_Click(object sender, EventArgs e)
        {
            
        }

        private void Tabs_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            
        }

        private void guna2Panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
