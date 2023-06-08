using CapaDatos.Roles;
using CapaEntidades.Personas;
using CapaEntidades.Roles;
using CapaNegocio.Personas;
using CapaNegocio.Roles;
using CapaPresentacion.Pantallas.Personas;
using CapaPresentacion.Pantallas.Roles;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Guna.UI.WinForms;
using System.Xml.Linq;
using static System.Windows.Forms.Design.AxImporter;

namespace CapaPresentacion.Pantallas.Controles
{
    public partial class EstadosRoles : Form
    {
        Funciones funciones = new Funciones();
        List<CE_EstadoRol> listaEstados;
        List<CE_Estado> listaEstadosEx;
        List<CE_Estado> listaTemp;
        BindingSource bindingSource;
        CE_Estado estado;
        CE_Rol rol;
        CE_EstadoRol estadoSeleccionado;
        private GunaButton selectedButton;
        private int animationStep = 0;
        private Color[] borderColors = { Color.Red, Color.FromArgb(7, 100, 132), Color.Red, Color.FromArgb(7, 100, 132) }; // Cambia los colores según tus preferencias
        private int[] borderThicknesses = { 2, 1, 2, 1, 2 }; // Cambia los tamaños según tus preferencias

        public EstadosRoles()
        {
            InitializeComponent();
        }

        private void Estados_Load(object sender, EventArgs e)
        {
            Cargar();           
        }

        private void Cargar()
        {
            LlenarRoles();
            ActualizaEstados();

            DataGridViewTextBoxColumn columna = new DataGridViewTextBoxColumn();
            columna.Name       = "Nombre";
            columna.HeaderText = "Nombre";
            // Agregar la columna al DataGridView
            DataEstados.Columns.Add(columna);
            imgVacio.Visible = true;

        }

        public void ActualizaEstados(bool elimina = false)
        {

            listaEstadosEx = CN_Estados.ObtenerEstados();
            if (rol != null && !elimina)
            {
                listaEstadosEx = UneListas();
            }            

            ActualizaEstadosEx();

            if (elimina)
            {                
                int currentIndex = COMBOROL.SelectedIndex;
                COMBOROL.SelectedIndex = 0;
                COMBOROL.SelectedIndex = currentIndex;
            }

            if (TXTBUSCA.Text.Length > 0) { Listar(TXTBUSCA.Text.ToLower().Trim()); TXTBUSCA.Focus();}
        }

        private void OcultaCampos()
        {
            DataEstados.Columns[0].Visible = false;
            DataEstados.Columns[1].Visible = false;
            DataEstados.Columns[2].Visible = false;
            DataEstados.Columns[3].Visible = false;            
            DataEstados.Columns[5].Visible = false;
            DataEstados.Columns[6].Visible = false;
            DataEstados.Columns[7].Visible = false;
        }

        private void LlenarRoles()
        {
            // Llamamos los tipos
            COMBOROL.DataSource    = CN_Roles.ObtenerRoles();
            // Configurar las propiedades del ComboBox
            COMBOROL.DisplayMember = "Nombre"; // Propiedad a mostrar como texto
            COMBOROL.ValueMember   = "ID"; // Propiedad a utilizar como valor seleccionado            
        }

        private CE_Rol RolbyID(int id)
        {
            foreach (CE_Rol rol in CN_Roles.ObtenerRoles())
            {
                if (rol.ID == id) return rol;
            }
            return null;
        }

        private List<CE_Estado> UneListas()
        {
            List<CE_Estado> temp = CN_Estados.ObtenerEstadosExcluidos(rol);
            foreach (CE_EstadoRol estadorol in listaEstados)
            {
                temp.RemoveAll(estado => estado.ID == estadorol.IdEstado);
            }

            foreach (CE_Estado estado in listaTemp)
            {
                if (temp.IndexOf(estado) == -1) temp.Add(estado);
            }

            temp = temp.Distinct().ToList();
            return temp;
        }

        private void Salvar()
        {
            try
            {
                CN_EstadosRoles.DeshabilitaEstados(rol);
                string Rpta = "OK";

                if (listaEstados.Count > 0)
                {
                    foreach (CE_EstadoRol estado in listaEstados)
                    {
                        // Llamar a la función de guardado y pasar el objeto estado con su nuevo número
                        estado.Activo = true;
                        Rpta = CN_EstadosRoles.Salvar(estado);
                        if (!Rpta.Equals("OK")) break;
                    }
                }                

                //continua el proceso
                if (Rpta.Equals("OK"))
                {
                    funciones.MensajeShow("Los datos han sido guardados correctamente.");
                }
                else
                {                    
                    funciones.MensajeShow(Rpta, false, true);
                }                
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

                if (fila.Index >= 0)
                {
                    if (!funciones.esVacio(fila.Cells[0].Value))
                    {
                        // Sacamos los datos del grid                                    
                        estado = new CE_Estado(
                            funciones.convertInt(fila.Cells[0].Value), //id
                            funciones.convertString(fila.Cells[1].Value), //nombre
                            funciones.convertString(fila.Cells[2].Value),
                            funciones.convertBool(fila.Cells[3].Value)//desc                            
                        );
                        return true;
                    }
                }                    
            }
            return false;
        }

        private void MoverArriba()
        {
            if (DataEstados.SelectedRows.Count > 0)
            {
                int rowIndex = DataEstados.SelectedRows[0].Index;

                // Obtener los objetos EstadoRol seleccionados
                estadoSeleccionado = (CE_EstadoRol)DataEstados.SelectedRows[0].DataBoundItem;

                // Mover la fila hacia arriba en la lista de objetos EstadoRol
                if (rowIndex > 0)
                {
                    CE_EstadoRol estadoAnterior = listaEstados[rowIndex - 1];

                    // Intercambiar los campos 'numero' de los objetos
                    int numeroTemp            = estadoAnterior.Numero;
                    estadoAnterior.Numero     = estadoSeleccionado.Numero;
                    estadoSeleccionado.Numero = numeroTemp;

                    // Intercambiar las posiciones en la lista
                    listaEstados[rowIndex - 1] = estadoSeleccionado;
                    listaEstados[rowIndex]     = estadoAnterior;

                    // Actualizar el origen de datos del DataGridView
                    DataEstados.DataSource = null;
                    DataEstados.DataSource = listaEstados;

                    OcultaCampos();

                    // Deseleccionar todas las filas
                    DataEstados.ClearSelection();
                    // Seleccionar la fila movida
                    DataEstados.Rows[rowIndex - 1].Selected     = true;
                    DataEstados.FirstDisplayedScrollingRowIndex = rowIndex - 1;                    
                }                
            }
        }

        private void MoverAbajo()
        {
            // Obtener la fila seleccionada actualmente
            if (DataEstados.SelectedRows.Count > 0)
            {
                int rowIndex = DataEstados.SelectedRows[0].Index;

                // Obtener los objetos EstadoRol seleccionados
                CE_EstadoRol estadoSeleccionado = (CE_EstadoRol)DataEstados.SelectedRows[0].DataBoundItem;

                // Mover la fila hacia abajo en la lista de objetos EstadoRol
                if (rowIndex < DataEstados.Rows.Count - 1)
                {
                    CE_EstadoRol estadoSiguiente = listaEstados[rowIndex + 1];

                    // Intercambiar los campos 'numero' de los objetos
                    int numeroTemp            = estadoSiguiente.Numero;
                    estadoSiguiente.Numero    = estadoSeleccionado.Numero;
                    estadoSeleccionado.Numero = numeroTemp;

                    // Intercambiar las posiciones en la lista
                    listaEstados[rowIndex + 1] = estadoSeleccionado;
                    listaEstados[rowIndex]     = estadoSiguiente;

                    // Actualizar el origen de datos del DataGridView
                    DataEstados.DataSource = null;
                    DataEstados.DataSource = listaEstados;

                    OcultaCampos();
                    // Deseleccionar todas las filas
                    DataEstados.ClearSelection();

                    // Seleccionar la fila movida
                    DataEstados.Rows[rowIndex + 1].Selected     = true;
                    DataEstados.FirstDisplayedScrollingRowIndex = rowIndex + 1;
                }                
            }
        }

        private void DataRoles_CellClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void gunaButton1_Click(object sender, EventArgs e)
        { }

        private void BTNSALVAR_Click(object sender, EventArgs e)
        {
            
        }

        private void DataRoles_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            validaItem();
        }

        private void DataEstados_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnArriba_Click(object sender, EventArgs e)
        {
            MoverArriba();            
        }

        private void btnAbajo_Click(object sender, EventArgs e)
        {
            MoverAbajo();
        }

        private void BTNSALVAR_Click_1(object sender, EventArgs e)
        {
            if (ValidaRol()) Salvar();
        }

        private bool ValidaRol()
        {
            if (rol != null) if (rol.ID >= 0) return true;
            funciones.MensajeShow("Selecciona un Rol.");
            //COMBOROL.DroppedDown = true;                      
            BorderTimer.Start();
            BorderTimer.Start();
            grupoRol.LineColor = Color.FromArgb(7, 100, 132);
            return false;
        }

        private void DataEstados_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void COMBOROL_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (int.TryParse(COMBOROL.SelectedValue.ToString(), out int selectedID))
            {
                // Paso 1: Cargar la lista de objetos EstadoRol desde la base de datos
                rol = RolbyID(selectedID);
                listaEstados = CN_EstadosRoles.ObtenerEstados(rol);
                listaTemp = new List<CE_Estado>();

                ActualizaEstados();
                ActualizaImagen();
                if (rol.ID == -1) grupoEstados.Text = "Edición de Estados";
                else grupoEstados.Text = "Edición de Estados para el rol de " + rol.Nombre;

                // Paso 2: Asignar la lista de objetos EstadoRol al origen de datos del DataGridView
                bindingSource = new BindingSource();
                bindingSource.DataSource = listaEstados;
                DataEstados.DataSource   = bindingSource;
                OcultaCampos();
                DataEstados.ClearSelection();                
            }
            else
            {
                // El valor seleccionado no es compatible con int
                // Maneja este caso según tus necesidades
            }
        }

        private void grupoEstados_Click(object sender, EventArgs e)
        {

        }

        private void gunaLabel1_Click(object sender, EventArgs e)
        {
            Estados form = new Estados(this);
            form.ShowDialog();
        }

        private void ActualizaEstadosRol()
        {
            //reordenamos la lista de los estados del rol
            for (int i = 0; i < listaEstados.Count; i++)
            {
                listaEstados[i].Numero = i + 1;
            }

            //actualizamos la data de los estados del rol
            DataEstados.DataSource = null;
            DataEstados.DataSource = listaEstados;
            OcultaCampos();
        }

        private void ActualizaImagen()
        {            
            if (listaEstados.Count == 0 || COMBOROL.SelectedIndex == 0) imgVacio.Visible = true;
            else imgVacio.Visible = false;

            if (listaEstadosEx.Count == 0) imgVacioE.Visible = true;
            else imgVacioE.Visible = false;
        }

        private void ActualizaEstadosEx()
        {
            // Ordenar la lista de EstadosRoles por el campo "Nombre"
            listaEstadosEx  = listaEstadosEx.OrderBy(estado => estado.Nombre).ToList();
            Data.DataSource = null;
            Data.DataSource = listaEstadosEx;
            Data.Columns[0].Visible = false;
            Data.Columns[3].Visible = false;
            if (TXTBUSCA.Text.Length > 0) Listar(TXTBUSCA.Text.Trim());
        }

        private void gunaGradientButton1_Click(object sender, EventArgs e)
        {
            if (Data.SelectedRows.Count > 0 && ValidaRol())
            {
                //obtenemos el indice del estado
                int indice = Data.SelectedRows[0].Index;

                //preguntamos si hemos seleccionado un registro y si ese rol existe
                if ( indice >= 0 && rol.ID != -1)
                {
                    CE_Estado temp = listaEstadosEx[indice];
                    listaTemp.Remove(temp);
                    //lo eliminamos de la lista de estados disponibles
                    listaEstadosEx.RemoveAt(indice);
                    //actualizamos la data de estados disponibles
                    ActualizaEstadosEx();


                    //---------------------------------------------------------------
                    //agregamos ese estado eliminado a los estados del rol
                    CE_EstadoRol estadoRol = new CE_EstadoRol(rol, temp, DataEstados.SelectedRows.Count + 1);
                    listaEstados.Add(estadoRol);

                    //reordenamos la lista de los estados del rol
                    ActualizaEstadosRol();
                    ActualizaImagen();

                    // Obtener el índice de la última fila                    
                    int lastIndex = DataEstados.Rows.Count - 1;
                    // Seleccionar la última fila
                    DataEstados.ClearSelection();
                    DataEstados.Rows[lastIndex].Selected = true;
                }                
            }
        }

        private void gunaGradientButton2_Click(object sender, EventArgs e)
        {
            if (DataEstados.SelectedRows.Count > 0 && ValidaRol())
            {
                //obtenemos el indice del estado
                int indice = DataEstados.SelectedRows[0].Index;

                //preguntamos si hemos seleccionado un rol
                if ( indice >= 0 )
                {                    
                    CE_EstadoRol temp = listaEstados[indice];
                    //lo eliminamos
                    listaEstados.RemoveAt(indice);

                    //reordenamos la lista de los estados del rol
                    ActualizaEstadosRol();
                    ActualizaImagen();

                    //agregamos ese estado a los estados disponibles
                    List<CE_Estado> estados = CN_Estados.ObtenerEstados();
                    foreach (CE_Estado estado in estados)
                    {
                        if (estado.Nombre.Equals(temp.Nombre))
                        {
                            listaEstadosEx.Add(estado);
                            listaTemp.Add(estado);
                            break;
                        }
                    }
                    //actualizamos la data de estados disponibles
                    ActualizaEstadosEx();
                }
            }
        }

        private void TXTBUSCA_TextChanged(object sender, EventArgs e)
        {
            Listar(TXTBUSCA.Text.ToLower().Trim());
        }

        private void Listar(string texto)
        {
            List<CE_Estado> resultados = listaEstadosEx
               .Where(estado => estado.Nombre.ToLower().Contains(texto) || estado.Descripcion.ToLower().Contains(texto))
               .ToList();

            Data.DataSource = resultados;            
        }

        private void gunaButton1_Click_1(object sender, EventArgs e) {}

        private void gunaButton2_Click_1(object sender, EventArgs e){}

        private void gunaButton3_Click(object sender, EventArgs e){}

        private void gunaButton4_Click(object sender, EventArgs e){}

        private void gunaButton1_Click_2(object sender, EventArgs e)
        {

            // Restaurar el color de borde del botón previamente seleccionado
            if (selectedButton != null)
            {                
                selectedButton.BorderColor = Color.FromArgb(224, 224, 224);
                selectedButton.BorderSize  = 1;
            }

            // Cambiar el color de borde del botón seleccionado
            GunaButton clickedButton  = (GunaButton)sender;
            clickedButton.BorderColor = clickedButton.OnHoverBorderColor;
            clickedButton.BorderSize  = 2;
            
            if      (clickedButton == gunaButton1) COMBOROL.SelectedIndex = 1;            
            else if (clickedButton == gunaButton2) COMBOROL.SelectedIndex = 2;
            else if (clickedButton == gunaButton3) COMBOROL.SelectedIndex = 3;
            else if (clickedButton == gunaButton4) COMBOROL.SelectedIndex = 4;

            // Actualizar el botón seleccionado actualmente
            selectedButton = clickedButton;
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            CE_Estado es = new CE_Estado();
            es.Nombre = TXTBUSCA.Text.Trim();
            EstadosE form = new EstadosE(null,es,1,this);
            form.ShowDialog();
        }

        private void BorderTimer_Tick(object sender, EventArgs e)
        {
            grupoRol.LineColor = borderColors[animationStep];
            grupoRol.BorderSize = borderThicknesses[animationStep];
            animationStep++;

            if (animationStep >= borderColors.Length)
            {
                animationStep = 0;
                BorderTimer.Stop(); // Detiene el temporizador al finalizar la animación
            }
        }

        private void grupoRol_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            TXTBUSCA.Text = string.Empty;
            TXTBUSCA.Focus();
        }
    }
}
