using CapaEntidades.Expedientes;
using CapaNegocio.Expedientes;
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

namespace CapaPresentacion.Pantallas.Expedientes
{
    public partial class CambioProceso : Form
    {

        private CE_Control control;
        //variable de estado 1 creando y otro modificando
        private int estado = 1;

        public CambioProceso(CE_Control Control = null, int stado = 2)
        {
            InitializeComponent();
            control = Control;
            estado = stado;
        }

        private void TXTENCARGADO_Click(object sender, EventArgs e)
        {
            Empleades frm = new Empleades();
            frm.ShowDialog();
        }

        private void CambioProceso_Load(object sender, EventArgs e)
        {
            llenar();
        }

        private void llenar()
        {
            if(control != null)
            {
                TXTEXPEDIENTE.Enabled = false;
                TXTEXPEDIENTE.Text    = control.Expediente.Expediente;                
            }
        }

        private void btnFINALIZAR_Click(object sender, EventArgs e)
        {
            //estamos creando un nuevo control expediente
            if( estado == 1 )
            {
                string nombreEx = TXTEXPEDIENTE.Text.Trim();
                if( nombreEx.Length > 0)
                {
                    CE_Expediente expediente = new CE_Expediente(nombreEx);
                    CN_Expedientes.Salvar(expediente);
                    control = new CE_Control();
                }  
            }
            else //de lo contrario estamos cambiando de proceso
            {

            }
        }
    }
}
