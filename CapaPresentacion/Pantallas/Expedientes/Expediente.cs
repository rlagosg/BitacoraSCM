using Bunifu.Framework.UI;
using Bunifu.UI.WinForms.BunifuButton;
using Guna.UI.WinForms;
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
            Tabs.TabIndex = 4;           
        }

        private void Cambia(int boton)
        {
            CambiaIndex(boton);
            List<GunaButton> botones = new List<GunaButton>(new GunaButton[] { gunaButton1, gunaButton2, gunaButton3, gunaButton4, gunaButton5, gunaButton6});
            GunaButton clickedButton = botones[boton];
            clickedButton.BorderColor = Color.FromArgb(40, 96, 144);
            clickedButton.BaseColor = Color.FromArgb(40, 96, 144);
            clickedButton.ForeColor = Color.White;

            clickedButton.OnHoverBorderColor = Color.FromArgb(40, 96, 144);
            clickedButton.OnHoverBaseColor = Color.FromArgb(40, 96, 144);
            clickedButton.OnHoverForeColor = Color.White;
            
            clickedButton.OnPressedColor = Color.FromArgb(40, 96, 144);

            botones.Remove(clickedButton);
            

            // Cambiar los colores de todos los botones
            foreach (GunaButton button in botones)
            {
                button.BorderColor = Color.DodgerBlue;
                button.BaseColor = Color.Azure;
                button.ForeColor = Color.FromArgb(0, 150, 241);

                button.OnHoverBorderColor = Color.FromArgb(105, 181, 255);
                button.OnHoverBaseColor = Color.FromArgb(22, 229, 246);
                button.OnHoverForeColor = Color.FromArgb(0, 150, 241);

                button.OnPressedColor = Color.FromArgb(40, 96, 144);             
            }

            Refresh(); // Forzar la actualización de la interfaz gráfica

            Application.DoEvents(); // Procesar los eventos pendientes de la interfaz gráfica

        }

        private void CambiaIndex(int boton)
        {
            Tabs.SelectedIndex = boton;
        }


        private void btn1_Click(object sender, EventArgs e)
        {
            CambiaIndex(1);
        }

        private void btn3_Click(object sender, EventArgs e)
        {
            CambiaIndex(3);
        }

        private void btn4_Click(object sender, EventArgs e)
        {
            CambiaIndex(4);
        }

        private void btn5_Click(object sender, EventArgs e)
        {
            CambiaIndex(5);
        }

        private void btn0_Click_1(object sender, EventArgs e)
        {
           

        }

        private void colorChangeTimer_Tick(object sender, EventArgs e, int botonIndex)
        {
            
            

        }

        private void doubleClickTimer_Tick(object sender, EventArgs e)
        {
            
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

        private void btn1_Click_1(object sender, EventArgs e)
        {
            
        }

        private void btn2_Click_1(object sender, EventArgs e)
        {
            
        }

        private void btn3_Click_1(object sender, EventArgs e)
        {
            
        }

        private void btn4_Click_1(object sender, EventArgs e)
        {
            
        }

        private void btn5_Click_1(object sender, EventArgs e)
        {
            
        }

        private void gunaButton6_Click(object sender, EventArgs e)
        {
            Cambia(5);
        }

        private void btn0_Click(object sender, EventArgs e)
        {
            CambiaIndex(0);
        }

        private void btn2_Click(object sender, EventArgs e)
        {
            CambiaIndex(2);
        }
    }
}
