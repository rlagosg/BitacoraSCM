﻿using CapaEntidades.Expedientes;
using Guna.UI.WinForms;
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
    public partial class Control : Form
    {
        CE_CambioProceso cambioProceso;
        Expedientes frmExpediente;
        Funciones funciones = new Funciones();
        public Control(Expedientes frm, CE_CambioProceso cambio )
        {
            InitializeComponent();
            this.cambioProceso = cambio;
            this.frmExpediente = frm;
        }

        private void BTNSALVAR_Click(object sender, EventArgs e)
        {

        }

        private void Control_Load(object sender, EventArgs e)
        {
            llenar();           
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
            }
        }

        private GunaDateTimePicker ObtenerDatePicker(DateTime? fecha)
        {

            if (!fecha.HasValue)
                return null;

            CustomGunaDateTimePicker Picker = new CustomGunaDateTimePicker();

            // Configurar la fecha
            Picker.Value = fecha.Value;

            // Modificar los colores
            Picker.FocusedColor = Color.FromArgb(68, 88, 112);
            Picker.OnHoverBaseColor = Color.White;
            Picker.OnHoverBorderColor = Color.White;
            Picker.OnHoverForeColor = Color.FromArgb(76, 118, 175);


            Picker.BaseColor = Color.White;
            //Picker.BorderColor = Color.Silver;             
            Picker.BorderColor = Color.White;
            //Picker.ForeColor = Color.Black;
            Picker.ForeColor = Color.FromArgb(76, 118, 175);
            Picker.Size = new Size(275, 36);
            Picker.BorderSize = 1;
            Picker.Radius = 5;
            // Ajustar el anclaje al lado derecho del panel
            //Picker.Dock = DockStyle.Fill;
            // Otros ajustes de apariencia según sea necesario
            return Picker;
        }

        private void btnFINALIZAR_Click(object sender, EventArgs e)
        {
            CambioProceso frm = new CambioProceso();
            frm.ShowDialog();
        }

        private void guna2Panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
