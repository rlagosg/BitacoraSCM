using Bunifu.Framework.UI;
using Bunifu.UI.WinForms.BunifuButton;
using Guna.UI.WinForms;
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

namespace CapaPresentacion.Pantallas.Expedientes
{
    public partial class Expediente : Form
    {
        public Expediente()
        {
            InitializeComponent();                    
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

        private void Cambia(int boton)
        {
            CambiaIndex(boton);
            List<GunaButton> botones = new List<GunaButton>(new GunaButton[] { 
                gunaButton1, gunaButton2, gunaButton3, gunaButton4, gunaButton5, gunaButton6
            });
            GunaButton clickedButton = botones[boton];

            clickedButton.BorderColor = Color.FromArgb(40, 96, 144);
            clickedButton.BaseColor   = Color.FromArgb(40, 96, 144);
            clickedButton.ForeColor   = Color.White;

            clickedButton.OnHoverBorderColor = Color.FromArgb(40, 96, 144);
            clickedButton.OnHoverBaseColor   = Color.FromArgb(40, 96, 144);
            clickedButton.OnHoverForeColor   = Color.White;
            
            clickedButton.OnPressedColor = Color.FromArgb(40, 96, 144);

            botones.Remove(clickedButton);
            

            // Cambiar los colores de todos los botones
            foreach (GunaButton button in botones)
            {
                button.BorderColor = Color.DodgerBlue;
                button.BaseColor   = Color.Azure;
                button.ForeColor   = Color.FromArgb(0, 150, 241);

                button.OnHoverBorderColor = Color.FromArgb(105, 181, 255);
                button.OnHoverBaseColor   = Color.FromArgb( 22, 229, 246);
                button.OnHoverForeColor   = Color.FromArgb(  0, 150, 241);

                button.OnPressedColor = Color.FromArgb(40, 96, 144);             
            }

            Refresh(); // Forzar la actualización de la interfaz gráfica
            Application.DoEvents(); // Procesar los eventos pendientes de la interfaz gráfica
        }

        private void CambiaIndex(int boton)
        {
            Tabs.SelectedIndex = boton;
        }

        private void gunaButton1_Click(object sender, EventArgs e)
        {
           Cambia(0);
        }

        private void gunaButton2_Click(object sender, EventArgs e)
        {            
           Cambia(1);
        }

        private void gunaButton3_Click(object sender, EventArgs e)
        {               
            Cambia(2);
        }


        private void gunaButton6_Click(object sender, EventArgs e)
        {               
            Cambia(5);
        }

        private void Tabs_SelectedIndexChanged(object sender, EventArgs e)
        {
            int indice = Tabs.SelectedIndex;
            Cambia(indice);            
        }

        private void gunaButton5_Click(object sender, EventArgs e)
        {
            Cambia(4);
        }

        private void gunaButton4_Click(object sender, EventArgs e)
        {
            Cambia(3);
        }
    }
}
