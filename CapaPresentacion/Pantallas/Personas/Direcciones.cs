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
    public partial class Direcciones : Form
    {
        Funciones funciones = new Funciones();
        CE_Direccion direccion;
        CE_Municipio municipio;
        CE_DireccionTipo direccionTipo;
        DireccionPersona frmDireccionPersona;
        string parametro;

        //variable de estado, 1 modo basica, 2 modo seleccionando
        private int estado = 1;

        public Direcciones(int state = 1, string param = null, DireccionPersona frmDireccionPersona = null)
        {
            InitializeComponent();
            this.frmDireccionPersona = frmDireccionPersona;
            this.parametro = param;
            this.estado    = state;            
            this.Listado("");
            this.configura();
            
        }

        public void Listado(string texto)
        {
            try
            {
                Data.DataSource = CN_Direcciones.Listar(texto, this.parametro);                
                Data.Columns[0].Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void configura()
        {
            //entramos en modo seleccion de nacionalidades
            if ( this.estado != 1 )
            {
                btnNuevo.Visible    = false;
                btnEliminar.Visible = false;
            }
            else btnSeleccionar.Visible = false;
        }

        private void BuscaMuniByName(string name)
        {            
            foreach (CE_Municipio muni in CN_Municipios.ObtenerLista())
            {
                if (muni.Nombre.Equals(name)) this.municipio = muni;
            }
        }

        private void BuscaTipoByName(string name)
        {
            foreach (CE_DireccionTipo tipo in CN_DireccionTipos.ObtenerLista())
            {
                if (tipo.Nombre.Equals(name)) this.direccionTipo = tipo;
            }
        }

        private bool validaItem()
        {
            if (Data.SelectedRows.Count > 0)
            {
                DataGridViewRow fila = Data.SelectedRows[0];

                if (!funciones.esVacio(fila.Cells[0].Value))
                {
                    //buscamos los objetos individuales para enviarlos
                    string munici = funciones.convertString(fila.Cells[3].Value);
                    string tipo   = funciones.convertString(fila.Cells[4].Value);
                    BuscaMuniByName(munici);
                    BuscaTipoByName(tipo);

                    direccion = new CE_Direccion(
                        funciones.convertInt    (fila.Cells[0].Value), //id
                        funciones.convertString (fila.Cells[1].Value), //nombre
                        funciones.convertString (fila.Cells[2].Value), //desc
                        municipio.ID,                                  //muni
                        direccionTipo.ID                               //tipo                                
                    );
                    return true;
                }
            }
            return false;
        }

        private void Direcciones_Load(object sender, EventArgs e)
        {

        }

        private void TXTBUSCA_TextChanged(object sender, EventArgs e)
        {
            this.Listado(TXTBUSCA.Text);
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (validaItem())
            {
                if (funciones.DialogoEliminar())
                {
                    funciones.MensajeEliminar(CN_Direcciones.Eliminar(direccion));
                    this.Listado(TXTBUSCA.Text);
                }
            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            DireccionesE form = new DireccionesE(this);
            form.ShowDialog();
        }

        private void Data_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (validaItem())
            {
                if( estado == 1)
                {
                    DireccionesE form = new DireccionesE(this, direccion, municipio, direccionTipo, 2);
                    form.ShowDialog();
                }
                else
                {
                    selecciona();
                }
                
            }
        }

        private void btnSeleccionar_Click(object sender, EventArgs e)
        {
            selecciona();
        }

        private void selecciona()
        {
            if (validaItem() && !funciones.esVacio(parametro))
            {
                if      (parametro.Equals("COLONIA"))frmDireccionPersona.Colonia         = direccion;
                else if (parametro.Equals("BARRIO"))frmDireccionPersona.Barrio           = direccion;
                else if (parametro.Equals("RESIDENCIAL"))frmDireccionPersona.Residencial = direccion;
                else if (parametro.Equals("ALDEA"))frmDireccionPersona.Aldea             = direccion;

                this.Close();
                frmDireccionPersona.Acutaliza();
            }            
        }
    }
}
