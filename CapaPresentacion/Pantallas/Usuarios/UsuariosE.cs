using CapaEntidades.Personas.Empleados;
using CapaEntidades.Usuarios;
using CapaPresentacion.Pantallas.Personas;
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
    public partial class UsuariosE : Form
    {
        CE_Empleado empleado;
        CE_Usuario usuario;
        Usuarios frmUsuarios;

        //variable de estado 1 guardando y otro modificando
        private int estado = 1;

        public UsuariosE(Usuarios frmUsuarios = null, CE_Usuario usu = null, int estado = 1)
        {
            InitializeComponent();
            this.frmUsuarios = frmUsuarios;
            this.usuario     = usu;
            this.estado      = estado;
        }

        private void btnSALVAR_Click(object sender, EventArgs e)
        {
            Guna2MessageDialog mens = new Guna2MessageDialog();
            mens.Icon    = MessageDialogIcon.Information;
            mens.Text    = "Finalizado";
            mens.Caption = "Mesanje del Sistema";
            mens.Buttons = MessageDialogButtons.OK;
            mens.Style   = MessageDialogStyle.Light;
            mens.Show();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            Empleades frm = new Empleades(this, null, 2);
            frm.ShowDialog();
        }

        private void UsuariosE_Load(object sender, EventArgs e)
        {
            llenar();
            CompruebaActivo();
        }

        private void llenar()
        {
            if (usuario != null)
            {
                TXTUSUARIO.Text  = usuario.Nombre;
                TXTEMPLEADO.Text = usuario.Empleado.Persona.NombreCompleto;                
                TXTPASSWORD.Text = usuario.Contrasenia;
                TXTPASSWORD.PasswordChar = '•';                
            }
        }

        public void ActualizaEmpleado(CE_Empleado e)
        {
            TXTEMPLEADO.Text = e.Persona.NombreCompleto;
            this.empleado    = e;            
        }

        private void guna2ToggleSwitch1_CheckedChanged(object sender, EventArgs e)
        {
            CompruebaActivo();
        }

        private void CompruebaActivo()
        {
            if (guna2ToggleSwitch1.Checked)
            {
                labelActivo.ForeColor = Color.FromArgb(76, 118, 175);
                labelActivo.Location  = new Point(606, 69);
                labelActivo.Text      = "Activo";  
            }
            else
            {
                labelActivo.ForeColor = Color.CadetBlue;
                labelActivo.Location  = new Point(582, 69);
                labelActivo.Text      = "Desactivado";
            }
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            Permisos frm = new Permisos();
            frm.ShowDialog();
        }
    }
}
