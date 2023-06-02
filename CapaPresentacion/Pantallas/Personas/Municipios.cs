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
    public partial class Municipios : Form
    {
        Funciones funciones = new Funciones();
        CE_Municipio municipio;
        DireccionesE frmDireccionesE;

        //variable de estado, 1 modo basica, 2 modo seleccionando
        private int opcion = 1;

        public Municipios(DireccionesE frm = null ,int op = 1)
        {
            InitializeComponent();
            frmDireccionesE = frm;
            this.Listado("");            
            this.opcion = op;
            this.configura();
        }

        public void Listado(string texto)
        {
            try
            {
                Data.DataSource = CN_Municipios.Listar(texto);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void configura()
        {
            //entramos en modo seleccion de nacionalidades
            if (this.opcion != 1)
            {
                btnNuevo.Visible    = false;
                btnEliminar.Visible = false;
            }
            else btnSeleccionar.Visible = false;
        }

        private bool validaItem()
        {
            if (Data.SelectedRows.Count > 0)
            {
                DataGridViewRow fila = Data.SelectedRows[0];

                if (!funciones.esVacio(fila.Cells[0].Value))
                {
                    municipio = new CE_Municipio(
                        funciones.convertInt   (fila.Cells[0].Value),                        
                        funciones.convertString(fila.Cells[1].Value),
                        funciones.convertString(fila.Cells[2].Value)
                    );
                    return true;
                }
            }
            return false;
        }

        private void Municipios_Load(object sender, EventArgs e)
        {

        }

        private void TXTBUSCA_TextChanged(object sender, EventArgs e)
        {
            this.Listado(TXTBUSCA.Text);
        }

        private void Data_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (validaItem())
            {
                if (opcion == 1)
                {
                    MunicipiosE form = new MunicipiosE(this, municipio, 2);
                    form.ShowDialog();
                }
                else
                {
                    frmDireccionesE.ActualizaMunicipio(this.municipio);
                    this.Close();
                }

            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            MunicipiosE form = new MunicipiosE(this);
            form.ShowDialog();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (validaItem())
            {
                if (funciones.DialogoEliminar())
                {
                    funciones.MensajeEliminar(CN_Municipios.Eliminar(municipio));
                    this.Listado(TXTBUSCA.Text);
                }
            }
        }

        private void Data_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnSeleccionar_Click(object sender, EventArgs e)
        {
            if(validaItem())
            {
                frmDireccionesE.ActualizaMunicipio(this.municipio);
                this.Close();
            }
        }
    }
}
