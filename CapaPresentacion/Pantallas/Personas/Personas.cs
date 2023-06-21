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
using CapaPresentacion.Pantallas.Personas.Empleados;
using Guna.UI2.WinForms.Internal;

namespace CapaPresentacion.Pantallas.Personas
{
    public partial class Personas : Form
    {
        //funcionas globales
        Funciones funciones  = new Funciones();
        CE_Persona persona   = new CE_Persona();
        EmpleadosE frmEmpleados = new EmpleadosE();
        CE_Nacionalidades nacionalidad;        

        //variable de estado, 0 modo basica, 1 modo seleccionando
        private int opcion = 0;

        //indice de la tabla
        int indiceData = -1;


        public Personas(int op = 0, EmpleadosE empleadosE = null)
        {
            InitializeComponent();            
            opcion    = op;
            frmEmpleados = empleadosE;
            this.Listado("");
        }

        private void configura()
        {
            //entramos en modo seleccion de empleados
            if (this.opcion != 0)
            {
                btnNuevo.Visible = false;
                btnEliminar.Visible = false;
            }
            else btnSeleccionar.Visible = false;
        }


        //lista
        public void Listado(string texto)
        {
            try
            {
                string temp = TXTBUSCA.Text.Trim();
                if (funciones.esVacio(texto)) Data.DataSource = CN_Personas.Listar(temp, opcion);
                else Data.DataSource = CN_Personas.Listar(texto, opcion);

                Data.ClearSelection();
                if (indiceData >= 0) Data.Rows[indiceData].Selected = true;
                Data.Columns[2].Visible = false; Data.Columns[3].Visible = false;
                Data.Columns[4].Visible = false; Data.Columns[5].Visible = false;
                Data.Columns[6].Width = 400; Data.Columns[7].Width = 200; 
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
                    persona.NombreCompleto  = funciones.convertString(fila.Cells[6].Value);
                    persona.FechaNacimiento = funciones.convertDate  (fila.Cells[8].Value);
                    persona.Genero          = funciones.convertString(fila.Cells[9].Value);
                    BuscaByName(funciones.convertString(fila.Cells[7].Value));
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


        private void Personas_Load(object sender, EventArgs e)
        {
            ToolTip toolTip = new ToolTip();
            toolTip.SetToolTip(btnLimpiar, "Limpiar");
            toolTip.SetToolTip(gunaButton1, "Actualizar");
            configura();
        }

        private void Data_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (validaItem())
            {
                PersonasE form = new PersonasE(this, persona, nacionalidad, 2);
                form.ShowDialog();
            }
        }

        private void TXTBUSCA_TextChanged(object sender, EventArgs e)
        {
            indiceData = -1;
            this.Listado(TXTBUSCA.Text);
        }

        private void gunaButton1_Click(object sender, EventArgs e)
        {
            Listado(TXTBUSCA.Text.Trim());
            TXTBUSCA.Focus();
        }

        private void gunaCircleButton1_Click(object sender, EventArgs e)
        {
            
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

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            BuscaByName("Hondureña");
            PersonasE form = new PersonasE(this, null, nacionalidad);
            form.ShowDialog();
        }

        private void Data_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            // Verificar si es el encabezado de la columna
            if (e.RowIndex == -1 && e.ColumnIndex >= 0)
            {
                e.Paint(e.ClipBounds, DataGridViewPaintParts.All);

                // Crear el color personalizado
                Color separatorColor = Color.FromArgb(245, 247, 251);
                int separatorThickness = 8; // Grosor de la línea separadora

                // Dibujar la línea separadora
                int dividerY = e.CellBounds.Bottom - separatorThickness;
                using (Pen separatorPen = new Pen(separatorColor, separatorThickness))
                {
                    e.Graphics.DrawLine(separatorPen, e.CellBounds.Left, dividerY, e.CellBounds.Right, dividerY);
                }

                e.Handled = true;
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            TXTBUSCA.Text = string.Empty;
            TXTBUSCA.Focus();
            Listado("");
        }

        private void btnSeleccionar_Click(object sender, EventArgs e)
        {
            if (validaItem())
            {
                frmEmpleados.ActualizaPersona(persona);
                this.Close();
            }
        }
    }
}
