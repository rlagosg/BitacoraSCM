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
        public Control()
        {
            InitializeComponent();
        }

        private void BTNSALVAR_Click(object sender, EventArgs e)
        {

        }

        private void Control_Load(object sender, EventArgs e)
        {
            DateTime fecha = new DateTime(2023, 6, 30);
            panelf.Controls.Add(ObtenerDatePicker(fecha));
            paneli.Controls.Add(ObtenerDatePicker(fecha));
        }

        private GunaDateTimePicker ObtenerDatePicker(DateTime fecha)
        {

            CustomGunaDateTimePicker Picker = new CustomGunaDateTimePicker();

            // Configurar la fecha
            Picker.Value = fecha;

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

            // Otros ajustes de apariencia según sea necesario
            return Picker;
        }
    }
}
