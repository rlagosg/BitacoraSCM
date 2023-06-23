using Bunifu.Framework.UI;
using Bunifu.UI.WinForms.BunifuButton;
using CapaEntidades.Expedientes;
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
            if (control != null) {
                TXTBUSCA.Text = control.Expediente.Expediente;
            }
            else
            {
                Tabs.SelectedIndex = 1;

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
    }
}
