using CapaEntidades.Personas;
using CapaEntidades.Roles;
using CapaNegocio.Personas;
using CapaNegocio.Roles;
using CapaPresentacion.Pantallas.Personas;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaPresentacion.Pantallas.Roles
{
    public partial class EstadosE : Form
    {
        Estados frmEstado;
        Funciones funciones = new Funciones();
        CE_Estado estado;
        int stado = 1;
        public EstadosE(Estados frm, CE_Estado es = null, int stado = 1)
        {
            InitializeComponent();
            this.frmEstado = frm;
            this.stado     = stado;
            this.estado    = es;
            Llenar();
        }

        private void Llenar()
        {
            if ( estado != null )
            {
                TXTNOMBRE.Text      = estado.Nombre;
                TXTDESCRIPCION.Text = estado.Descripcion;
            }
            else
            {
                estado = new CE_Estado();
            }
        }

        private void EstadosE_Load(object sender, EventArgs e)
        {

        }

        private void BTNSALVAR_Click(object sender, EventArgs e)
        {
            try
            {
                if ( TXTNOMBRE.Text == string.Empty )
                {
                    funciones.MensajeShow("Debes rellenar los campos obligatarios.\nLos campos obligatorios están señalizados con un ‘*’.", false);
                }
                else
                {
                    string Rpta = "";
                    this.estado.Nombre      = TXTNOMBRE.Text;
                    this.estado.Descripcion = TXTDESCRIPCION.Text.Trim();

                    //condicion para saber si salvar o modificar
                    if (this.stado == 1) Rpta = CN_Estados.Salvar(1, this.estado);
                    else Rpta = CN_Estados.Salvar(2, this.estado);

                    //continua el proceso
                    if (Rpta.Equals("OK"))
                    {
                        funciones.MensajeShow("Los datos han sido guardados correctamente", true);
                        frmEstado.Listar(this.estado.Nombre);
                        this.Close();
                    }
                    else
                    {
                        //si ocurrio un error lo mostramos
                        funciones.MensajeShow(Rpta, false);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }
    }
}
