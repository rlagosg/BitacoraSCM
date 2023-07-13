using CapaEntidades.Personas.Empleados;
using CapaEntidades.Roles;
using CapaNegocio.Expedientes;
using CapaNegocio.Personas.Empleados;
using CapaPresentacion.Pantallas.Expedientes;
using CapaPresentacion.Pantallas.Personas.Empleados;
using CapaPresentacion.Pantallas.Usuarios;
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
    public partial class Empleades : Form
    {

        UsuariosE frmUsuarioE;
        CambioProceso frmCambio;
        int rol;
        Funciones funciones = new Funciones();
        CE_Empleado empleado;
        //variable de estado, 1: modo basico, 2: seleccionando usuario, 3: seleccionando recibe
        private int opcion = 1;

        //indice de la tabla
        int indiceData = -1;

        public Empleades(UsuariosE frm = null, CambioProceso cambio = null, int op = 1, int rol = 1)
        {
            InitializeComponent();
            this.frmUsuarioE = frm;
            this.opcion = op;
            this.frmCambio = cambio;
            this.rol = rol;
        }

        private void Empleados_Load(object sender, EventArgs e)
        {
            Listar();
            Tabla();
            Configura();
        }

        private void Configura()
        {
            if (opcion == 1) 
            {
                btnSeleccionar.Visible = false;
            }
        }

        private void Tabla()
        {
            Data.Columns[4].Visible = false; 
            Data.Columns[0].Width = 150; //nombre          
            Data.Columns[1].Width = 160; //fecha inicial                               
            Data.Columns[2].Width = 160; //fecha inicial 
        }

        public void Listar(string texto = "")
        {
            try
            {
                string busca = TXTBUSCA.Text.Trim();
                if (busca.Length > 0) Data.DataSource = CN_Empleados.Listar(busca, opcion, rol);
                else Data.DataSource = CN_Empleados.Listar(texto, opcion, rol);           
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
                    empleado = CN_Empleados.BuscaEmpleadoById(funciones.convertInt(fila.Cells[0].Value));
                    return true;
                }
            }
            return false;
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

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            EmpleadosE frm = new EmpleadosE();
            frm.ShowDialog();
        }

        private void btnSeleccionar_Click(object sender, EventArgs e)
        {
            if (validaItem())
            {     
                if ( opcion == 2) 
                {
                    frmUsuarioE.ActualizaEmpleado(empleado);
                    this.Close();
                }
                else
                {
                    frmCambio.ActualizaRecibe(empleado);
                    this.Close();
                }
                              
            }
            
        }
    }
}
