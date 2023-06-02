using CapaEntidades;
using CapaEntidades.Personas;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using CapaNegocio.Personas;

namespace CapaPresentacion.Pantallas.Personas
{
    public partial class PersonaContacto : Form
    {
        Funciones   funciones = new Funciones();        
        CE_Contacto contacto;
        CE_DireccionTipo direccionTipo = new CE_DireccionTipo();
        PersonasE  frmPersonaE;

        // estado = 1 guardando, estado = 2 modificando
        int estado = 1;

        public PersonaContacto( PersonasE frmPerson, CE_Contacto contacto, int stado = 1 )
        {
            InitializeComponent();
            this.frmPersonaE = frmPerson;
            this.contacto    = contacto;       
            this.estado      = stado;
        }

        private void BuscaTipoByIndex(int id)
        {
            foreach (CE_DireccionTipo tipo in CN_DireccionTipos.ObtenerLista(false))
            {
                if ( tipo.ID == id ) this.direccionTipo = tipo;                
            }
        }

        private void Llenar()
        {
            // Llamamos los tipos
            COMBOTIPO.DataSource    = CN_DireccionTipos.ObtenerLista(false); // Llenamos
            COMBOTIPO.DisplayMember = "Nombre"; // Propiedad a mostrar como texto en el ComboBox
            COMBOTIPO.ValueMember   = "ID"; // Propiedad a utilizar como valor seleccionado en el ComboBox

            if ( contacto.ID != 0 )
            {
                COMBOTIPO.SelectedIndex = contacto.IdTipo;
                TXTCONTACTO.Text        = contacto.Contacto.Trim();
                TXTDESCRIPCION.Text     = contacto.Descripcion;                
            }
        }

        public bool ValidarCorreo(string correo)
        {            
            string patron = @"^[\w\.-]+@[\w\.-]+\.\w+$"; // Expresión regular para validar el formato de correo electrónico
            Regex regex   = new Regex(patron); // Validar el correo utilizando la expresión regular
            return regex.IsMatch(correo);
        }

        public bool ValidaCampos()
        {
            if (TXTCONTACTO.Text == string.Empty || (int)COMBOTIPO.SelectedValue == -1)
            {
                funciones.MensajeShow("Debes rellenar los campos obligatarios.\nLos campos obligatorios están señalizados con un ‘*’.", false);
                return false;
            }
            contacto.Contacto = TXTCONTACTO.Text.Trim();
            return true;
        }

        private void PersonaContacto_Load(object sender, EventArgs e)
        {
            Llenar();            
        }

        private void Salvar()
        {
            try
            {
                if (ValidaCampos())                
                {
                    string Rpta = "";                    
                    this.contacto.Contacto    = TXTCONTACTO.Text.Trim();
                    this.contacto.Descripcion = TXTDESCRIPCION.Text.Trim();
                    this.contacto.IdTipo      = COMBOTIPO.SelectedIndex;                   

                    //condicion para saber si salvar o modificar
                    if (this.estado == 1) Rpta = CN_Contactos.Salvar(1, this.contacto);
                    else Rpta = CN_Contactos.Salvar(2, this.contacto);

                    //continua el proceso
                    if (Rpta.Equals("OK"))
                    {
                        funciones.MensajeShow("Los datos han sido guardados correctamente", true);                        
                        this.Close();
                        frmPersonaE.ActualizaTablaContac();
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

        private void BTNSALVAR_Click(object sender, EventArgs e)
        {
            if (ValidaCampos())
            {   // Preguntamos si estamos guardando un correo para poder validarlo
                if (direccionTipo.Nombre.IndexOf("CORREO", StringComparison.OrdinalIgnoreCase) >= 0)
                {
                    // Si el correo es valido procedemos
                    if (TXTCONTACTO != null && ValidarCorreo(TXTCONTACTO.Text.Trim())) Salvar();
                    else funciones.MensajeShow("Correo electrónico inválido", false, true);
                }// Caso contrario Guardamos    
                else Salvar();
            }            
        }

        private void COMBOTIPO_SelectedIndexChanged(object sender, EventArgs e)
        {
            int idSeleccionado = ((CE_DireccionTipo)COMBOTIPO.SelectedItem).ID;
            BuscaTipoByIndex(idSeleccionado);
        }
    }
}
