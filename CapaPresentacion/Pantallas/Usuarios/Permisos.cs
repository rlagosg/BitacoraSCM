using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaPresentacion.Pantallas.Usuarios
{
    public partial class Permisos : Form
    {
        public Permisos()
        {
            InitializeComponent();
        }

        private void btnSALVAR_Click(object sender, EventArgs e)
        {
            Guna2MessageDialog mens = new Guna2MessageDialog();
            mens.Icon    = MessageDialogIcon.Information;
            mens.Text    = "Finalizado";
            mens.Caption = "Mesanje del Sistema";
            mens.Buttons = MessageDialogButtons.OK;
            mens.Style   = MessageDialogStyle.Light;
            mens.Show ();
            this.Close();
        }
    }
}
