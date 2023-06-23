using Bunifu.Json.Linq;
using CapaEntidades.Expedientes;
using CapaEntidades.Personas.Empleados;
using CapaEntidades.Roles;
using CapaNegocio.Expedientes;
using CapaNegocio.Personas;
using CapaNegocio.Personas.Empleados;
using CapaNegocio.Roles;
using CapaPresentacion.Pantallas.Globales;
using CapaPresentacion.Pantallas.Roles;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaPresentacion.Pantallas.Expedientes
{
    public partial class Expedientes : Form
    {
        Funciones funciones = new Funciones();
        CE_Control control;
        int indiceData = -1;
        List<CE_Empleado> listaEmpleados;        
        public Expedientes()
        {
            InitializeComponent();           
        }

        private void Expedientes_Load(object sender, EventArgs e)
        {
            Listar("");
            Cargar();            
//            activeForm.Visible = false;
        }

        void Cargar()
        {
            guna2ComboBox1.SelectedIndex = 0;
            guna2ComboBox2.SelectedIndex = 0;   
        }

        public void Listar(string texto = "")
        {
            try
            {
                string busca = TXTBUSCA.Text.Trim();
                if (busca.Length > 0)
                {
                    Data.DataSource = CN_Controles.Listar(busca);                    
                }
                else
                {                    
                    Data.DataSource = CN_Controles.Listar(texto);
                }

                Tabla();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void Tabla()
        {
            Data.Columns[0].Visible = false;
            Data.Columns[1].Visible = false;
            Data.Columns[5]. Visible = false;
            Data.Columns[4].Visible = false; Data.Columns[10]. Visible = false;
            Data.Columns[6].Visible = false; Data.Columns[13].Visible = false;
            Data.Columns[14].Visible = false; Data.Columns[16].Visible = false;

            Data.Columns[2].Width  = 140; //nombre          
            Data.Columns[3].Width  = 140; //fecha inicial            
            Data.Columns[7].Width  = 140; //Proceso
            Data.Columns[8].Width  = 190; //Estado
            Data.Columns[9].Width  = 300; //Comentario
            Data.Columns[12].Width = 140; //Ult.Cambio
            Data.Columns[15].Width = 90; //fecha final           
        }

        private void gunaCircleButton1_Click(object sender, EventArgs e)
        {
            TXTBUSCA.Text = string.Empty;
            TXTBUSCA.Focus();
            //Listado("");
        }

        private void gunaButton2_Click(object sender, EventArgs e)
        {
            
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            Busqueda frm = new Busqueda();
            frm.ShowDialog();
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {

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

        private void TXTBUSCA_TextChanged(object sender, EventArgs e)
        {
            Listar(TXTBUSCA.Text.Trim());
        }

        private async Task<bool> validaItem()
        {
            if (Data.SelectedRows.Count > 0)
            {                
                DataGridViewRow fila = Data.SelectedRows[0];

                if (!funciones.esVacio(fila.Cells[0].Value))
                {
                    // Sacamos los datos del grid                    
                    control = new CE_Control();
                    listaEmpleados = CN_Empleados.ObtenerEmpleados();

                    await Busca //Expediente, Iniciador, Encargado, Finalizador
                    (
                        funciones.convertInt(fila.Cells[1].Value),
                        funciones.convertInt(fila.Cells[4].Value),
                        funciones.convertInt(fila.Cells[10].Value),
                        funciones.convertInt(fila.Cells[13].Value)
                    );
                    //control.Expediente = CN_Expedientes.BuscarById(funciones.convertInt(fila.Cells[1].Value));
                    control.IdControl    = funciones.convertInt    (fila.Cells[0].Value);  //IdControl                                     
                    control.Iniciado     = funciones.convertDate   (fila.Cells[3].Value);  //Iniciado
                    control.ObsInicial   = funciones.convertString (fila.Cells[6].Value);  //ObsInicial      
                    control.Proceso      = funciones.convertString (fila.Cells[7].Value);  //Proceso         
                    control.Estado       = funciones.convertString (fila.Cells[8].Value);  //Estado          
                    control.Comentario   = funciones.convertString (fila.Cells[9].Value);  //Comentario  
                    control.UltCambio    = funciones.convertDate   (fila.Cells[12].Value); //UltCambio  
                    control.Finalizacion = funciones.convertDate   (fila.Cells[15].Value); //Finalizacion 
                    control.ObsFinal     = funciones.convertString (fila.Cells[16].Value); //ObsFinal                     

                    indiceData = Data.CurrentRow.Index;                    
                    return true;
                }
            }            
            return false;
        }

        private async Task BuscaEmpleado(int empleado, int tipo)
        {
            switch (tipo)
            {
                case 0: //iniciador
                    control.Iniciador = await Task.Run(() => CN_Empleados.BuscaEmpleadoById(listaEmpleados, empleado));
                    break;
                case 1: //Encargado
                    control.Encargado = await Task.Run(() => CN_Empleados.BuscaEmpleadoById(listaEmpleados, empleado));
                    break;
                case 2: //Finalizador
                    control.Finalizador = await Task.Run(() => CN_Empleados.BuscaEmpleadoById(listaEmpleados, empleado));
                    break;
                default:
                    break;
            }
        }

        private async Task BuscaExpediente(int id)
        {
            control.Expediente = await Task.Run(() => CN_Expedientes.BuscarById(id));
        }


        private async Task Busca(int expediente, int iniciador, int encargado, int finalizador)
        {            
            var task1 = BuscaEmpleado(iniciador, 0);
            var task2 = BuscaEmpleado(encargado, 1);
            var task3 = BuscaEmpleado(finalizador, 2);
            var task4 = BuscaExpediente(expediente);

            await Task.WhenAll(task1, task2, task3, task4);
        }


        private async void Data_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

            // Deshabilitar controles del formulario principal
            Data.Enabled = false;

            // Mostrar el formulario de "Cargando"
            Cargando loadingForm = new Cargando();
            loadingForm.ShowDialog();

            await Task.Delay(25); // Ejemplo: Simular una tarea que toma tiempo
            
            bool resultado = await validaItem();

            loadingForm.Close();
            loadingForm.Exits();

            // Habilitar controles del formulario principal
            Data.Enabled = true;


            if (resultado)
            {
                Expediente form = new Expediente(this, control);
                form.ShowDialog();
            }         
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            Expediente form = new Expediente(this);
            form.ShowDialog();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {            
            //Cargando frm = new Cargando();
            //frm.ShowDialog();
        }
    }
}
