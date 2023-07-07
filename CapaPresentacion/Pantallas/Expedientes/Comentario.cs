using Guna.UI2.WinForms;
using Microsoft.VisualBasic.Logging;
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
    public partial class Comentario : Form
    {
        public Comentario()
        {
            InitializeComponent();
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

            if (textBox.TextLength > 305)
            {
                textBox.Font = new Font("Segoe UI", 12f);
            }
            else if (textBox.TextLength > 210)
            {
                textBox.Font = new Font("Segoe UI", 13f);
            }
            else if (textBox.TextLength > 170)
            {
                textBox.Font = new Font("Segoe UI", 14f);
            }
            else if (textBox.TextLength > 110)
            {
                textBox.Font = new Font("Segoe UI", 15f);
            }else 
            {
                textBox.Font = new Font("Segoe UI", 16.5f);
            }

            
            int lineBreakCount = CountLineBreaks(textBox.Text);

            if (lineBreakCount >= 6)
            {
                textBox.ScrollBars = ScrollBars.Vertical;
                textBox.Size = new Size(471, 245);
            }
            else
            {
                textBox.ScrollBars = ScrollBars.None;
                textBox.Size = new Size(450, 245);
            }
        }

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
        private void Comentario_Load(object sender, EventArgs e)
        {
            verificaBoton();
        }

     
    }
}
