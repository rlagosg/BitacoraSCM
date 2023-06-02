using CapaEntidades;
using CapaEntidades.Personas;
using CapaNegocio;
using CapaNegocio.Personas;
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
    public partial class MunicipiosE : Form
    {
        //variable del formulario Municipios, para poder acceder a sus funciones y variales
        Municipios frmMunicipios;
        //variable de persona para poder manejar el municipio recibido
        CE_Municipio municipio = new CE_Municipio();
        //instancia de las funciones globales
        Funciones funciones = new Funciones();
        //variable de estado 1 guardando y otro modificando
        private int estado = 1;


        public MunicipiosE( Municipios frm, CE_Municipio muni = null, int state = 1 )
        {
            InitializeComponent();
            this.frmMunicipios = frm;
            this.municipio     = muni;
            this.estado        = state;
            llenar();
        }

        private void llenar()
        {
            if( municipio != null )
            {
                TXTNOMBRE.Text      = municipio.Nombre;
                TXTDESCRIPCION.Text = municipio.Descripcion;
            }
        }

        /// <summary>
        /// funcion para buscar una nacionalidad por su nombre
        /// </summary>
        private bool BuscaByName(string name)
        {
            List<CE_Municipio> municipios = CN_Municipios.ObtenerLista();
            foreach (CE_Municipio muni in municipios)
            {
                if (muni.Nombre.Equals(name)) return true;
            }
            return false;
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void MunicipiosE_Load(object sender, EventArgs e)
        {

        }

        private void BTNSALVAR_Click(object sender, EventArgs e)
        {
            try
            {
                
                if ( TXTNOMBRE.Text == string.Empty )
                {
                    funciones.MensajeShow("Falta ingresar datos requeridos", false);
                }
                else
                {
                    //si estamos guardando creamos una nueva instancia
                    if (this.estado == 1) this.municipio = new CE_Municipio();

                    string Rpta = "";
                    this.municipio.Nombre = TXTNOMBRE.Text.Trim();
                    this.municipio.Descripcion = TXTDESCRIPCION.Text.Trim();
                    bool existe = BuscaByName(municipio.Nombre);

                    //buscamos si existe
                    if (existe && estado == 1) { 
                        //funciones.MensajeShow("Ya existe el elemento " + municipio.Nombre, false);
                        Rpta = "Ya existe el elemento " + "'" + municipio.Nombre + "'" + "en la tabla";
                    }
                    //si no existe actualizamos o guardamos
                    else
                    {
                        //condicion para saber si salvar o modificar
                        if (this.estado == 1) Rpta = CN_Municipios.Salvar(1, this.municipio);
                        else { Rpta = CN_Municipios.Salvar(2, this.municipio); }
                    }

                  
                    //continua el proceso
                    if (Rpta.Equals("OK"))
                    {
                        funciones.MensajeShow("Los datos han sido guardados correctamente", true);
                        frmMunicipios.Listado(municipio.Nombre);
                        this.Close();
                    }
                    else
                    {
                        //mostramos la respuesta
                        if(!existe) funciones.MensajeShow(Rpta, false);
                        else funciones.MensajeShow(Rpta, false, true);                       

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
