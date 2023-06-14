using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaEntidades.Personas;
using CapaNegocio.Personas;
using Guna.UI2.WinForms.Internal;

namespace CapaPresentacion.Pantallas.Personas
{
    public partial class Personas : Form
    {
        //funcionas globales
        Funciones funciones = new Funciones();
        CE_Persona persona = new CE_Persona();
        CE_Nacionalidades nacionalidad;

        //indice de la tabla
        int indiceData = -1;


        public Personas()
        {
            InitializeComponent();
            this.Listado("");
        }

        //lista
        public void Listado(string texto)
        {
            try
            {
                string temp = TXTBUSCA.Text.Trim();
                if (funciones.esVacio(texto)) Data.DataSource = CN_Personas.Listar(temp);
                else Data.DataSource = CN_Personas.Listar(texto);

                Data.ClearSelection();
                if (indiceData >= 0) Data.Rows[indiceData].Selected = true;
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
                    persona.Id              = funciones.convertString(fila.Cells[0].Value);
                    persona.RTN             = funciones.convertString(fila.Cells[1].Value);
                    persona.PrimerNombre    = funciones.convertString(fila.Cells[2].Value);
                    persona.SegundoNombre   = funciones.convertString(fila.Cells[3].Value);
                    persona.PrimerApellido  = funciones.convertString(fila.Cells[4].Value);
                    persona.SegundoApellido = funciones.convertString(fila.Cells[5].Value);                                        
                    persona.FechaNacimiento = funciones.convertDate  (fila.Cells[7].Value);
                    persona.Genero          = funciones.convertString(fila.Cells[8].Value);
                    BuscaByName(funciones.convertString(fila.Cells[6].Value));
                    indiceData = Data.CurrentRow.Index;
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// funcion para buscar una nacionalidad por su nombre
        /// </summary>
        private void BuscaByName(string name)
        {
            List<CE_Nacionalidades> nacionalidades = CN_Nacionalidades.ObtenerLista();
            foreach (CE_Nacionalidades nacionalidad in nacionalidades)
            {
                if (nacionalidad.Nacionalidad.Equals(name)) this.nacionalidad = nacionalidad;
            }            
        }


        private void gunaGradientButton2_Click(object sender, EventArgs e)
        {
            BuscaByName("Hondureña");
            PersonasE form = new PersonasE(this,null, nacionalidad);
            form.ShowDialog();
        }

        private void Personas_Load(object sender, EventArgs e)
        {
            ToolTip toolTip = new ToolTip();
            toolTip.SetToolTip(btnLimpiar, "Limpiar");
            toolTip.SetToolTip(gunaButton1, "Actualizar");
        }

        private void Data_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (validaItem())
            {
                PersonasE form = new PersonasE(this, persona, nacionalidad, 2);
                form.ShowDialog();
            }
        }

        private void Data_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void TXTBUSCA_TextChanged(object sender, EventArgs e)
        {
            indiceData = -1;
            this.Listado(TXTBUSCA.Text);
        }

        private void gunaGradientButton1_Click(object sender, EventArgs e)
        {
            try
            {
                if (!validaItem())
                {
                    funciones.MensajeShow("Selecciona un Registro", false);
                }
                else
                {
                    if (funciones.DialogoEliminar())
                    {
                        funciones.MensajeEliminar(CN_Personas.Eliminar(this.persona));
                        indiceData = -1;
                        this.Listado(TXTBUSCA.Text.Trim());
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void gunaButton1_Click(object sender, EventArgs e)
        {
            Listado(TXTBUSCA.Text.Trim());
            TXTBUSCA.Focus();
        }

        private void gunaCircleButton1_Click(object sender, EventArgs e)
        {
            TXTBUSCA.Text = string.Empty;
            TXTBUSCA.Focus();
            Listado("");
        }
    }
}
