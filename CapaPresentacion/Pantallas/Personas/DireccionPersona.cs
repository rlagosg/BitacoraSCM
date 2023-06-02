using CapaEntidades.Personas;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;
using System.Xml.Linq;
using CapaNegocio.Personas;
using Guna;
using Guna.UI2.WinForms;
using Guna.UI.WinForms;

namespace CapaPresentacion.Pantallas.Personas
{
    public partial class DireccionPersona : Form
    {
        public CE_Direccion Barrio      = new CE_Direccion();
        public CE_Direccion Colonia     = new CE_Direccion();
        public CE_Direccion Residencial = new CE_Direccion();
        public CE_Direccion Aldea       = new CE_Direccion();
        CE_DireccionPersona direccionPersona;
        Funciones funciones = new Funciones();
        PersonasE frmPersonaE;
        
        //variable de estado 1 guardando y otro modificando
        private int estado = 1;

        public DireccionPersona(PersonasE frm ,CE_DireccionPersona direccionPersona, int stado = 1)
        {
            InitializeComponent();
            this.direccionPersona = direccionPersona;
            this.frmPersonaE      = frm;
            this.estado           = stado;
        }

        private void BuscaById( int id, int tipo )
        {
            string nombre = null;

            foreach (CE_Direccion direccion in CN_Direcciones.ObtenerLista())
            {
                if (id == direccion.ID)
                {
                    switch (tipo)
                    {
                        case 0: //Barrios                            
                            this.Barrio = direccion;
                            nombre      = Barrio.Nombre;
                            break;

                        case 1: //Colonias
                            this.Colonia = direccion;
                            nombre       = Colonia.Nombre;
                            break;

                        case 2: //Residencial
                            this.Residencial = direccion;
                            nombre           = Residencial.Nombre;
                            break;

                        case 3: //Aldea
                            this.Aldea = direccion;
                            nombre     = Aldea.Nombre;
                            break;

                        default:
                            break;
                    }
                }
            }

            BeginInvoke((Action)(() =>
            {
                switch (tipo)
                {
                    case 0: //Barrios
                        TXTBARRIO.Text      = nombre;
                        break;

                    case 1: //Colonias
                        TXTCOLONIA.Text     = nombre;
                        break;

                    case 2: //Residencial
                        TXTRESIDENCIAL.Text = nombre;
                        break;

                    case 3: //Aldea
                        TXTALDEA.Text       = nombre;
                        break;

                    default:
                        break;
                }
            }));
        }

        private void Busca()
        {
            // Crear e iniciar los hilos
            Thread thread1 = new Thread(() => BuscaById(direccionPersona.IdBarrio,      0)); //Barrio
            Thread thread2 = new Thread(() => BuscaById(direccionPersona.IdColonia,     1)); //Colonia
            Thread thread3 = new Thread(() => BuscaById(direccionPersona.IdResidencial, 2)); //Residencial
            Thread thread4 = new Thread(() => BuscaById(direccionPersona.IdAldea,       3)); //Aldea

            thread1.Start();
            thread2.Start();
            thread3.Start();
            thread4.Start();

            // Esperar a que los hilos terminen
            thread1.Join();
            thread2.Join();
            thread3.Join();
            thread4.Join();

            TXTCOMENTARIO.Text = this.direccionPersona.Comentario;
        }

        public void Acutaliza()
        {
            TXTBARRIO.Text      = Barrio.Nombre;
            TXTCOLONIA.Text     = Colonia.Nombre;
            TXTRESIDENCIAL.Text = Residencial.Nombre;
            TXTALDEA.Text       = Aldea.Nombre;

            this.direccionPersona.IdBarrio      = Barrio.ID;
            this.direccionPersona.IdColonia     = Colonia.ID;
            this.direccionPersona.IdResidencial = Residencial.ID;
            this.direccionPersona.IdAldea       = Aldea.ID;
        }

        private void Button_Click(object sender, EventArgs e)
        { }

        private void BTNSALVAR_Click(object sender, EventArgs e)
        {
            try
            {
                // Preguntamos si almenos un texbox no esta vacio
                if (!new[] { TXTBARRIO, TXTCOLONIA, TXTRESIDENCIAL, TXTALDEA }.Any(tb => !string.IsNullOrEmpty(tb.Text)))
                {
                    funciones.MensajeShow("Debes ingresar almenos una ubicación", false);
                }
                else
                {                                     
                    string Rpta = "";
                    this.direccionPersona.IdBarrio      = Barrio.ID;
                    this.direccionPersona.IdColonia     = Colonia.ID;
                    this.direccionPersona.IdResidencial = Residencial.ID;
                    this.direccionPersona.IdAldea       = Aldea.ID;
                    this.direccionPersona.Comentario    = TXTCOMENTARIO.Text.Trim();

                    // Condicion para saber si salvar o modificar
                    if (this.estado == 1) Rpta = CN_DireccionPersonas.Salvar(1, this.direccionPersona);
                    else Rpta = CN_DireccionPersonas.Salvar(2, this.direccionPersona);

                    // Continua el proceso
                    if (Rpta.Equals("OK"))
                    {
                        funciones.MensajeShow("Los datos han sido guardados correctamente", true);                        
                        this.Close();
                        frmPersonaE.ActualizaTablaDirec();                        
                    }
                    else
                    {
                        //si ocurrio un error lo mostramos
                        funciones.MensajeShow(Rpta, false);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            
        }

        private void DireccionPersona_Load(object sender, EventArgs e)
        {
            //si estamos modificando rellenamos los texbox
            if( estado == 2 ) Busca();            
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            //abrimos la ventanda de direcciones con una busqueda respecto al elemento
            GunaButton button = (GunaButton)sender;
            string parametro = "";

            if (button == button1) parametro = "COLONIA";
            else if (button == button2) parametro = "BARRIO";
            else if (button == button3) parametro = "RESIDENCIAL";
            else if (button == button4) parametro = "ALDEA";

            Direcciones frm = new Direcciones(2, parametro, this);
            frm.ShowDialog();
        }
    }
}
