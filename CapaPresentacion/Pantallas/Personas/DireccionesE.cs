using CapaEntidades;
using CapaEntidades.Personas;
using CapaNegocio;
using CapaNegocio.Personas;
using Guna.UI2.WinForms.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaPresentacion.Pantallas.Personas
{
    public partial class DireccionesE : Form
    {
        //instancia de las funciones globales
        Funciones funciones = new Funciones();

        //variable del formulario Direcciones, para poder acceder a sus funciones y variales
        Direcciones frmDirecciones;
        //objeto de direccion para poder manejar el municipio recibido
        CE_Direccion direccion = new CE_Direccion();
        //variable para manejar los municipios
        CE_Municipio municipio = new CE_Municipio();
        //variable para manejar los tipos
        CE_DireccionTipo tipo =  new CE_DireccionTipo();

        //variable de estado 1 guardando y otro modificando
        private int estado = 1;

        public DireccionesE( Direcciones frmdirec, CE_Direccion dir = null, CE_Municipio muni = null, CE_DireccionTipo tip = null, int stado = 1 )
        {
            InitializeComponent();
            frmDirecciones = frmdirec;
            direccion      = dir;
            estado         = stado;
            municipio      = muni;
            tipo           = tip;
        }

        private void DireccionesE_Load(object sender, EventArgs e)
        {
            Llenar();
        }

        private void Llenar()
        {
            // Llamamos los tipos
            COMBOTIPO.DataSource = CN_DireccionTipos.ObtenerLista();
            // Configurar las propiedades del ComboBox
            COMBOTIPO.DisplayMember = "Nombre"; // Propiedad a mostrar como texto
            COMBOTIPO.ValueMember   = "ID"; // Propiedad a utilizar como valor seleccionado

            if( direccion != null )
            {
                TXTNOMBRE.Text      = direccion.Nombre;
                TXTDESCRIPCION.Text = direccion.Descripcion;
                if ( municipio != null ) TXTMUNICIPIO.Text       = municipio.Nombre;
                if ( tipo      != null ) COMBOTIPO.SelectedIndex = tipo.ID;
            }
        }

        public void ActualizaMunicipio(CE_Municipio muni)
        {
            if (muni != null)
            {
                TXTMUNICIPIO.Text = muni.Nombre;
                this.municipio    = muni;
            }
        }

        private void BTNSALVAR_Click(object sender, EventArgs e)
        {
            try
            {
                if (TXTNOMBRE.Text == string.Empty || TXTMUNICIPIO.Text == string.Empty || (int)COMBOTIPO.SelectedValue == -1)
                {
                    funciones.MensajeShow("Falta ingresar datos requeridos", false);
                }
                else
                {
                    //si estamos guardando creamos una nueva instancia
                    if ( this.estado == 1 ) this.direccion = new CE_Direccion();
                    
                    string Rpta = "";
                    this.direccion.Nombre      = TXTNOMBRE.Text;
                    this.direccion.Descripcion = TXTDESCRIPCION.Text.Trim();
                    this.direccion.IdMuni      = municipio.ID;
                    this.direccion.IdTipo      = COMBOTIPO.SelectedIndex;                    

                    //condicion para saber si salvar o modificar
                    if (this.estado == 1) Rpta = CN_Direcciones.Salvar(1, this.direccion);
                    else Rpta = CN_Direcciones.Salvar(2, this.direccion);

                    //continua el proceso
                    if (Rpta.Equals("OK"))
                    {
                        funciones.MensajeShow("Los datos han sido guardados correctamente", true);
                        frmDirecciones.Listado(direccion.Nombre);
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

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void gunaButton1_Click(object sender, EventArgs e)
        {
            Municipios form = new Municipios(this, 2);
            form.ShowDialog();
        }
    }
}
