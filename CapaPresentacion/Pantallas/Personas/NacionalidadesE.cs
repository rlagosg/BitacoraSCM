using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaPresentacion.Pantallas.Personas;
using CapaEntidades.Personas;
using CapaNegocio.Personas;

namespace CapaPresentacion.Pantallas.Personas
{
    public partial class NacionalidadesE : Form
    {
        //formulario principal, llamamos para acceder a sus metodos
        private Nacionalidades nacs;
        //creamos un objeto de nacionalidad extraer el objeto del fomulario principal
        private CE_Nacionalidades nacion = new CE_Nacionalidades(); 
        
        public NacionalidadesE(Nacionalidades formNac, CE_Nacionalidades nac = null)
        {              
            InitializeComponent();
            //setiamos
            nacs = formNac;
            llenar(nac);
        }

        private void llenar(CE_Nacionalidades nac)
        {
            //si el objeto existe significa que estamos modificando
            if (nac != null)
            {
                nacion = nac;
                TXTNOMBRE.Text = nacion.Pais;
                TXTNOMBRE.ReadOnly = true;
                TXTNACIONALIDAD.Text = nacion.Nacionalidad;
                TXTNACIONALIDAD.TabIndex = 0;
                TXTNACIONALIDAD.Focus();
            }
        }

        private void NacionalidadesE_Load(object sender, EventArgs e)
        {

        }

        private void MensajeShow(string mensaje, bool informacion = true)
        {
            //funcion para regresar una ventada de mensaje en pantalla
            if (informacion == true) MessageBox.Show(mensaje, "Aviso del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else MessageBox.Show(mensaje, "Aviso del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

 

        private void button2_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (TXTNACIONALIDAD.Text == string.Empty || TXTNOMBRE.Text == string.Empty)
                {
                    MensajeShow("Falta ingresar datos requeridos", false);
                }
                else
                {
                    string Rpta = "";
                    CE_Nacionalidades nacionalidad = new CE_Nacionalidades(TXTNOMBRE.Text.Trim(), TXTNACIONALIDAD.Text.Trim());

                    //condicion para saber si salvar o modificar
                    if (string.IsNullOrEmpty(nacion.Pais)) Rpta = CN_Nacionalidades.Salvar(1, nacionalidad);
                    else
                    {
                        nacionalidad.Id = nacion.Id;
                        Rpta = CN_Nacionalidades.Salvar(2, nacionalidad);
                    }

                    //continua el proceso
                    if (Rpta.Equals("OK"))
                    {
                        MensajeShow("Los datos han sido guardados correctamente", true);
                        nacs.Listado(nacionalidad.Pais);
                        this.Close();
                    }
                    else
                    {
                        //si ocurrio un error lo mostramos
                        MensajeShow(Rpta, false);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void NacionalidadesE_KeyDown(object sender, KeyEventArgs e)
        {
            //si presionamos sobre el boton ESC salimos
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }
    }
}
