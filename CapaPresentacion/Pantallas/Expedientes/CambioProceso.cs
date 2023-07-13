using CapaEntidades.Expedientes;
using CapaEntidades.Global;
using CapaEntidades.Personas;
using CapaEntidades.Personas.Empleados;
using CapaEntidades.Roles;
using CapaEntidades.Usuarios;
using CapaNegocio.Expedientes;
using CapaNegocio.Personas;
using CapaNegocio.Personas.Empleados;
using CapaNegocio.Roles;
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
using System.Web.UI;
using System.Windows.Forms;

namespace CapaPresentacion.Pantallas.Expedientes
{
    public partial class CambioProceso : Form
    {
        //datos de la sesion
        private CE_Sesion sesion;

        //para almacenar el control
        private CE_Control control;
        
        //empleado a quien enviamos el expediente
        private CE_Empleado recibe = null;
        private Expedientes frmExpedientes;
        Funciones funciones = new Funciones();

        //variable de estado = 1 creando control de expediente, estado = 2 enviando expediente
        private int estado = 2;

        public CambioProceso(CE_Sesion sesion, Expedientes frm = null, CE_Control Control = null, int stado = 2)
        {
            InitializeComponent();
            estado  = stado;
            Configura();
            frmExpedientes = frm;
            control        = Control;
            this.sesion    = sesion;
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

        private void Configura()
        {
            if( estado == 2 )
            {
                this.Size              = new Size  (816, 420);
                grupo.Size             = new Size  (744, 332);
                btnFINALIZAR.Location  = new Point (535, 279);
                label1.Text            = "Comentario";
                label2.Visible         = false;
                TXTCOMENTARIO2.Visible = false;
            }
        }

        private void llenar()
        {
            if(control != null)
            {
                TXTEXPEDIENTE.Enabled = false;
                TXTEXPEDIENTE.Text    = control.Expediente.Expediente;    
                label3.Text = control.IdCambioProceso.ToString();
            }
        }

        private void btnFINALIZAR_Click(object sender, EventArgs e)
        {
            string nombreEx = TXTEXPEDIENTE.Text.Trim();

            try
            {
                if (nombreEx.Length == 0 || recibe == null)
                {
                    string mensaje = "";
                    if (nombreEx.Length == 0 && recibe == null) mensaje = "No has proporcionado un nombre de expediente y Debes seleccionar el nuevo encargado";
                    else if (nombreEx.Length == 0 && recibe != null) mensaje = "No has proporcionado un nombre de expediente.";
                    else mensaje = "Debes seleccionar el nuevo encargado";
                    funciones.MensajeShowModal(mensaje, false, true);
                }
                else
                {

                    CE_CambioProceso cambio = new CE_CambioProceso();
                    cambio.Control = control;
                    cambio.Envia   = sesion.Empleado;
                    cambio.Recibe  = recibe;                    
                    cambio.IdNuevoProceso = control.Rol + 1;

                    string Rpta;

                    //creando expediente
                    if (estado == 1)
                    {
                        CE_Expediente expediente = new CE_Expediente(nombreEx);
                        control = new CE_Control(expediente);
                        
                        cambio.Control = control;
                        cambio.ObsIni  = TXTCOMENTARIO.Text.Trim();
                        cambio.Observaciones  = TXTCOMENTARIO2.Text.Trim();
                        Rpta = CN_Controles.Salvar(cambio);

                    }
                    else //pasando expediente
                    {
                        cambio.ID = control.IdCambioProceso;
                        cambio.Observaciones = TXTCOMENTARIO.Text.Trim();

                        funciones.MensajeShow(cambio.ToString(), false, true);
                        Rpta = CN_CambiosProceso.Salvar(cambio);

                    }
                                        

                    //continua el proceso
                    if (Rpta.Equals("OK"))
                    {
                        funciones.MensajeShowModal("Los datos han sido guardados correctamente", true);
                        frmExpedientes.Listar();                        
                        this.Close();
                    }
                    else
                    {
                        //si ocurrio un error lo mostramos
                        funciones.MensajeShowModal(Rpta, false);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            Empleades frm;
            if (control == null) frm = new Empleades(null, this, 3, 1);
            else frm = new Empleades(null, this, 3, control.Rol + 1);
            frm.ShowDialog();
        }

        public void ActualizaRecibe(CE_Empleado recibe)
        {
            this.recibe = recibe;
            TXTENCARGADO.Text = recibe.Persona.NombreCompleto;
        }
    }
}
