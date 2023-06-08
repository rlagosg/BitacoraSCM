using CapaEntidades.Roles;
using CapaNegocio.Personas;
using CapaNegocio.Roles;
using CapaPresentacion.Pantallas.Controles;
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
    public partial class Estados : Form
    {
        EstadosRoles frmEstadosRoles;
        CE_Estado estado;
        Funciones funciones = new Funciones();
        int indiceData = -1;
        bool elimino = false;
        public Estados( EstadosRoles frm = null)
        {
            InitializeComponent();
            this.frmEstadosRoles = frm;
        }

        private void Estados_Load(object sender, EventArgs e)
        {
            Listar();
        }

        public void Listar(string texto = "")
        {
            try
            {
                string busca = TXTBUSCA.Text.Trim();
                if (busca.Length > 0) Data.DataSource = CN_Estados.Listar(busca);
                else Data.DataSource = CN_Estados.Listar(texto);
                Data.Columns[0].Visible = false;

                Data.ClearSelection();
                if (Data.SelectedRows.Count > 0) if (indiceData >= 0) Data.Rows[indiceData].Selected = true;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private bool validaItem()
        {
            if (Data.SelectedRows.Count > 0)
            {
                DataGridViewRow fila = Data.SelectedRows[0];

                if (!funciones.esVacio(fila.Cells[0].Value))
                {
                    // Sacamos los datos del grid                                    
                    estado = new CE_Estado(
                        funciones.convertInt   (fila.Cells[0].Value), //id
                        funciones.convertString(fila.Cells[1].Value), //nombre
                        funciones.convertString(fila.Cells[2].Value)                     
                    );
                    indiceData = Data.CurrentRow.Index;
                    return true;
                }
            }
            return false;
        }

        private void Data_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (validaItem()) {
                EstadosE form = new EstadosE(this, estado, 2);
                form.ShowDialog();
            }
        }

        private void TXTBUSCA_TextChanged(object sender, EventArgs e)
        {
            indiceData = -1;
            this.Listar(TXTBUSCA.Text);
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (!validaItem())
                {
                    funciones.MensajeShow("Selecciona un Registro", false);
                }
                else
                {
                    string mensaje = "Al eliminar un estado, este ya no formará parte de la lista de estados de todos los roles.\n"
                    + "Los estados del rol se actualizarán automáticamente, pero ten en cuenta que los cambios no guardados se perderán.";

                    funciones.MensajeShow(mensaje);

                    if (funciones.DialogoEliminar())
                    {
                        funciones.MensajeEliminar(CN_Estados.Eliminar(this.estado));                        
                        indiceData = -1;                        
                        this.Listar(TXTBUSCA.Text.Trim());
                        this.elimino = true;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            EstadosE form = new EstadosE(this);
            form.ShowDialog();
        }

        private void Estados_FormClosing(object sender, FormClosingEventArgs e)
        {
            frmEstadosRoles.ActualizaEstados(elimino);
        }

        private void gunaButton2_Click(object sender, EventArgs e)
        {
            TXTBUSCA.Text = string.Empty;
            TXTBUSCA.Focus();
            Listar("");
        }

        private void gunaButton1_Click(object sender, EventArgs e)
        {
            Listar("");
        }
    }
}
