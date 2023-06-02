using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaEntidades.Personas;
using CapaNegocio.Personas;
using CapaPresentacion.Pantallas.Personas;

namespace CapaPresentacion
{
    public partial class Nacionalidades : Form
    {
        Funciones funciones = new Funciones();
        PersonasE frmPersonasE;

        //variable de estado, 0 modo basica, 1 modo seleccionando
        private int opcion = 0;
        

        public Nacionalidades( PersonasE person, int op = 0)
        {
            InitializeComponent();
            this.Listado("");
            this.frmPersonasE = person;
            this.opcion = op;
            this.configura();
        }       

        public CE_Nacionalidades nacion;

        private void configura()
        {
            //entramos en modo seleccion de nacionalidades
            if (this.opcion != 0) {
                btnNuevo.Visible = false;
                btnEliminar.Visible = false;
            }else btnSeleccionar.Visible = false;
        }

        #region "Mis Metodos"
        private void Formato()
        {
            DataNac.Columns[0].Width = 5;
            DataNac.Columns[0].HeaderText = "Numero";

            DataNac.Columns[1].Width = 10;
            DataNac.Columns[1].HeaderText = "Nombre";

            DataNac.Columns[2].Width = 10;
            DataNac.Columns[2].HeaderText = "Nacionalidad";
        }

        public void Listado(string texto)
        {
            try
            {
                DataNac.DataSource = CN_Nacionalidades.Listar(texto);
                DataNac.Columns[0].Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        #endregion

        private void label1_Click(object sender, EventArgs e)
        {

        }

         private void Nacionalidades_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Listado("a");
        }

        private void gunaTextBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void gunaGradientButton1_Click(object sender, EventArgs e)
        {
            
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }


        private void gunaGradientButton2_Click_1(object sender, EventArgs e)
        {
            NacionalidadesE form = new NacionalidadesE(this);
            form.ShowDialog();
        }

        private void TXTBUSCA_TextChanged(object sender, EventArgs e)
        {
            this.Listado(TXTBUSCA.Text);
        }

        private void DataNac_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void DataNac_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (validaItem())
            {
                if (opcion==0)
                {
                    NacionalidadesE form = new NacionalidadesE(this, nacion);
                    form.ShowDialog();
                }
                else
                {                    
                    frmPersonasE.ActualizaNacionalidad(this.nacion);
                    this.Close();
                }
                              
            }
        }

        private bool validaItem()
        {
            if (DataNac.SelectedRows.Count > 0)
            {
                DataGridViewRow fila = DataNac.SelectedRows[0];

                if (!funciones.esVacio(fila.Cells[0].Value))
                {
                    nacion = new CE_Nacionalidades(
                        funciones.convertString(fila.Cells[2].Value),
                        funciones.convertString(fila.Cells[1].Value),                                            
                        funciones.convertInt(fila.Cells[0].Value)
                    );
                    return true;
                }
            }
            return false;
        }

        private void gunaGradientButton1_Click_1(object sender, EventArgs e)
        {
            if(validaItem())
            {                               
                if (funciones.DialogoEliminar())
                {
                    funciones.MensajeEliminar(CN_Nacionalidades.Eliminar(nacion));
                    this.Listado(TXTBUSCA.Text);
                }                
            }
        }

        private void btnSeleccionar_Click(object sender, EventArgs e)
        {
            if (validaItem())
            {                  
                frmPersonasE.ActualizaNacionalidad(this.nacion);
                this.Close();            
            }
        }
    }
}
