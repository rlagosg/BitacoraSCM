using CapaEntidades.Personas;
using CapaNegocio.Personas;
using Guna.UI2.WinForms.Internal;
using Guna.UI2.WinForms.Suite;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace CapaPresentacion.Pantallas.Personas
{
    public partial class PersonasE : Form
    {

        //variable del formulario personas, para poder acceder a sus funciones y variales
        private Personas personas;
        //variable de persona para poder manejar la persona que hemos seleccionado del formulario de personas
        private CE_Persona persona;
        //variable para guardar la nacionalidad seleccionada de las peronas
        public CE_Nacionalidades nacionalidad;
        //variable para guardar la direccion seleccionada de la perona
        CE_DireccionPersona direccionPersona = new CE_DireccionPersona();
        //variable para guardar el contacto seleccionada de la perona
        CE_Contacto contactoPersona          = new CE_Contacto();
        //instancia de las funciones globales
        Funciones funciones = new Funciones();
        string genero = "Seleccionar género";

        //variables para guardar los indices de las tablas
        int indiceDirec  = -1;
        int indiceContac = -1;

        //variable de estado 1 guardando y otro modificando
        private int estado = 1;

        public PersonasE(Personas frmPersonas, CE_Persona person = null, CE_Nacionalidades nacionalidad = null, int stado = 1)
        {
            InitializeComponent();
            this.personas     = frmPersonas;
            this.persona      = person;
            this.nacionalidad = nacionalidad;
            this.estado       = stado;
            llenar();           
        }

        private void llenar()
        {
            //si existe la persona la seteamos
            if (persona != null)
            {
                TXTID.Text               = persona.Id;
                TXTID.ReadOnly           = true;
                TXTID.FocusedBorderColor = Color.Black;
                TXTRTN.Text              = persona.RTN;
                TXTNOMBRE1.Text          = persona.PrimerNombre;
                TXTNOMBRE2.Text          = persona.SegundoNombre;
                TXTAPELLIDO1.Text        = persona.PrimerApellido;
                TXTAPELLIDO2.Text        = persona.SegundoApellido;                
                TXTGENERO.Text           = persona.Genero;
                
                SetFecha(persona.FechaNacimiento);
                LlenaComboGenero(persona.Genero);
                ActualizaTablaDirec (); //direcciones             
                ActualizaTablaContac(); //contactos                

                //si existe la nacionalidad la seteamos
                if ( nacionalidad != null )
                {
                    TXTNAC.Text            = nacionalidad.Nacionalidad;
                    persona.IdNacionalidad = nacionalidad.Id;
                }                
            }
            // Si no eiste la persona colocamos un valor por defecto
            if( persona == null ) TXTNAC.Text = nacionalidad.Nacionalidad;
            SetFecha(null);
            LlenaComboGenero(genero);
        }

        //cargamos la fecha
        public void SetFecha(DateTime? fecha)
        {
            if (fecha == null) TXTFECHA.Checked = false;
            else
            {
                TXTFECHA.Value = (DateTime)fecha;
                TXTFECHA.Checked = true;
            }
        }

        //asiganamos la fecha para enviar a la BD
        public void GetFecha()
        {
            if (!TXTFECHA.Checked) persona.FechaNacimiento = null; // Retorna null si no hay fecha seleccionada
            else persona.FechaNacimiento = TXTFECHA.Value;
        }


        private void LlenaComboGenero(string genero)
        {
            // Configurar el combo
            COMBOGENE.DropDownStyle = ComboBoxStyle.DropDownList;

            // Limpiar las opciones actuales del combo
            COMBOGENE.Items.Clear();

            // Agregar opción "Seleccionar género"
            COMBOGENE.Items.Add("Seleccionar género");

            // Agregar las opciones permitidas
            COMBOGENE.Items.Add("MASCULINO");
            COMBOGENE.Items.Add("FEMENINO");            

            // Establecer el valor seleccionado
            if (COMBOGENE.Items.Contains(genero))
            {
                COMBOGENE.SelectedItem = genero;
            }
            else
            {
                COMBOGENE.SelectedItem = "Seleccionar género";
            }
        }

        public void ActualizaTablaDirec()
        {
            DataDic.DataSource = CN_DireccionPersonas.Listar(persona.Id);
            DataDic.CellBorderStyle = DataGridViewCellBorderStyle.Single;
            DataDic.Columns[0].Visible = false;
            DataDic.Columns[1].Visible = false;
            DataDic.Columns[2].Visible = false;
            DataDic.Columns[3].Visible = false;
            DataDic.Columns[4].Visible = false;
            DataDic.Columns[5].Visible = false;
            DataDic.ClearSelection();
            if ( indiceDirec >= 0 ) DataDic.Rows[indiceDirec].Selected = true;                                            

        }

        public void ActualizaTablaContac()
        {
            DataContac.DataSource = CN_Contactos.Listar("", this.persona);
            DataContac.CellBorderStyle = DataGridViewCellBorderStyle.Single;
            DataContac.Columns[0].Visible = false;
            DataContac.Columns[1].Visible = false;
            DataContac.Columns[4].Visible = false;
            DataContac.ClearSelection();
            if ( indiceContac >= 0 ) DataContac.Rows[indiceContac].Selected = true;
        }

        private bool validaItemDic()
        {
            if (DataDic.SelectedRows.Count > 0)
            {
                DataGridViewRow fila = DataDic.SelectedRows[0];

                if (!funciones.esVacio(fila.Cells[0].Value))
                {
                    direccionPersona.ID            = funciones.convertInt    (fila.Cells[0].Value);
                    direccionPersona.IdPersona     = funciones.convertString (fila.Cells[1].Value);
                    direccionPersona.IdBarrio      = funciones.convertInt    (fila.Cells[2].Value);
                    direccionPersona.IdColonia     = funciones.convertInt    (fila.Cells[3].Value);
                    direccionPersona.IdResidencial = funciones.convertInt    (fila.Cells[4].Value);
                    direccionPersona.IdAldea       = funciones.convertInt    (fila.Cells[5].Value);
                    direccionPersona.Direccion     = funciones.convertString (fila.Cells[6].Value);
                    direccionPersona.Comentario    = funciones.convertString (fila.Cells[7].Value);
                    indiceDirec = DataDic.CurrentRow.Index;
                    return true;
                }
            }
            return false;
        }

        private bool validaItemContacto()
        {
            if (DataContac.SelectedRows.Count > 0)
            {
                DataGridViewRow fila = DataContac.SelectedRows[0];

                if (!funciones.esVacio(fila.Cells[0].Value))
                {
                    contactoPersona.ID          = funciones.convertInt    (fila.Cells[0].Value);
                    contactoPersona.IdPersona   = funciones.convertString (fila.Cells[1].Value);
                    contactoPersona.Contacto    = funciones.convertString (fila.Cells[2].Value);
                    contactoPersona.Descripcion = funciones.convertString (fila.Cells[3].Value);
                    contactoPersona.IdTipo      = funciones.convertInt    (fila.Cells[4].Value);
                    indiceContac = DataContac.CurrentRow.Index;
                    return true;
                }
            }
            return false;
        }

        public void ActualizaNacionalidad(CE_Nacionalidades nacion)
        {
            if (nacion != null) { 
                TXTNAC.Text       = nacion.Nacionalidad;
                this.nacionalidad = nacion;
            }
        }

        private void PersonasE_Load(object sender, EventArgs e)
        {

        }

        private void PersonasE_KeyDown(object sender, KeyEventArgs e)
        {
            //si presionamos sobre el boton ESC salimos
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Salvar(bool cerrar = true)
        {
            try
            {
                if (TXTNOMBRE1.Text == string.Empty || TXTAPELLIDO1.Text == string.Empty)
                {
                    funciones.MensajeShow("Debes rellenar los campos obligatarios.\nLos campos obligatorios están señalizados con un ‘*’.", false);
                }
                else
                {
                    //si estamos guardando creamos una nueva instancia
                    if (this.estado == 1) this.persona = new CE_Persona();

                    string Rpta = "";
                    this.persona.Id              = TXTID.Text.Trim();
                    this.persona.RTN             = TXTRTN.Text.Trim();
                    this.persona.PrimerNombre    = TXTNOMBRE1.Text.Trim();
                    this.persona.SegundoNombre   = TXTNOMBRE2.Text.Trim();
                    this.persona.PrimerApellido  = TXTAPELLIDO1.Text.Trim();
                    this.persona.SegundoApellido = TXTAPELLIDO2.Text.Trim();
                    this.persona.Genero          = TXTGENERO.Text.Trim();              
                    this.persona.IdNacionalidad  = this.nacionalidad.Id;                    
                    GetFecha();

                    //condicion para saber si salvar o modificar
                    if (this.estado == 1) Rpta = CN_Personas.Salvar(1, this.persona);
                    else Rpta = CN_Personas.Salvar(2, this.persona);

                    //continua el proceso
                    if (Rpta.Equals("OK"))
                    {
                        funciones.MensajeShow("Los datos han sido guardados correctamente", true);
                        personas.Listado("");

                        //cerramos segun el parametro
                        if (cerrar) { this.Close(); personas.Listado(""); };
                        this.estado = 2; //actualizamos el estado a modificando
                    }
                    else
                    {
                        //si ocurrio un error lo mostramos
                        funciones.MensajeShow(Rpta, false, true);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void ValidaEstado()
        {
            if (estado == 1) //si estamos creando un usuario, significa que una no existe
            {
                if (funciones.DialogoPregunta("Aún no está registrado este usuario. ¿Deseas registrarlo?"))
                {
                    Salvar(false);                    
                }
            }
        }

        private void BTNSALVAR_Click(object sender, EventArgs e)
        {
            Salvar();

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button1_KeyDown(object sender, KeyEventArgs e)
        {
            
        }

        private void button1_KeyPress(object sender, KeyPressEventArgs e)
        {
          
        }

        private void gunaGradientButton2_Click(object sender, EventArgs e)
        {
            ValidaEstado();
            if ( estado == 2 ) //si estamos modificando abrimos la ventana
            {
                direccionPersona.IdPersona = this.persona.Id;
                DireccionPersona form = new DireccionPersona(this, direccionPersona);
                form.ShowDialog();
            }            
        }

        private void DataDic_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (validaItemDic())
            {
                DireccionPersona form = new DireccionPersona(this, direccionPersona, 2);
                form.ShowDialog();
            }
        }

        private void gunaGradientButton4_Click(object sender, EventArgs e)
        {
            ValidaEstado();
            if (estado == 2) //si estamos modificando abrimos la ventana
            {
                CE_Contacto contacto = new CE_Contacto();
                contacto.IdPersona = this.persona.Id;
                PersonaContacto form        = new PersonaContacto(this, contacto);
                form.ShowDialog();
            }
        }

        private void DataContac_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (validaItemContacto())
            {
                PersonaContacto form = new PersonaContacto(this, contactoPersona, 2);
                form.ShowDialog();
            }
        }

        private void gunaGradientButton3_Click(object sender, EventArgs e)
        {

            try
            {
                if (!validaItemContacto())
                {
                    funciones.MensajeShow("Selecciona un Contacto", false);
                }
                else
                {
                    if (funciones.DialogoEliminar())
                    {
                        funciones.MensajeEliminar(CN_Contactos.Eliminar(this.contactoPersona));
                        indiceContac = -1;
                        this.ActualizaTablaContac();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void gunaGradientButton1_Click(object sender, EventArgs e)
        {
            try
            {
                if (!validaItemDic())
                {
                    funciones.MensajeShow("Selecciona una Dirección", false);
                }
                else
                {
                    if (funciones.DialogoEliminar())
                    {
                        funciones.MensajeEliminar(CN_DireccionPersonas.Eliminar(this.direccionPersona));
                        indiceDirec = -1;
                        this.ActualizaTablaDirec();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void COMBOGENE_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Obtener la opción seleccionada del combo
            object selectedItem = COMBOGENE.SelectedItem;

            // Verificar si se seleccionó alguna opción
            if (selectedItem != null && selectedItem.ToString() != "Seleccionar género")
            {
                genero = selectedItem.ToString();
                TXTGENERO.Text = genero;
            }
            else
            {
                // Si no se seleccionó ninguna opción o se seleccionó "Seleccionar género", establecer el valor por defecto
                genero = "Seleccionar género";
                TXTGENERO.Text = "";
            }
        }

        private void gunaButton1_Click(object sender, EventArgs e)
        {
            Nacionalidades form = new Nacionalidades(this, 1);
            form.ShowDialog();
        }
    }
}
