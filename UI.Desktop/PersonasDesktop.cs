using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Business.Entities;
using Business.Logic;

namespace UI.Desktop
{
    public partial class PersonasDesktop : ApplicationForm
    {
        public PersonasDesktop()
        {
            InitializeComponent();
        }

        public PersonasDesktop(ModoForm modo) : this()
        {
            this.Modo = modo;

        }

        public PersonasDesktop(int ID, ModoForm modo) : this()
        {
            this.Modo = modo;
            PersonaLogic perLog = new PersonaLogic();
            Persona per = perLog.GetOne(ID);
            PersonaActual = per; //Revisar si es correcto (PASO 12)
            this.MapearDeDatos();
        }

        public Persona PersonaActual { get; set; }

        public override void MapearDeDatos()
        {
            this.txtID.Text = this.PersonaActual.ID.ToString();
            this.txtNombre.Text = this.PersonaActual.Nombre;
            this.txtApellido.Text = this.PersonaActual.Apellido;
            this.txtEmail.Text = this.PersonaActual.Email;
            this.txtDireccion.Text = this.PersonaActual.Direccion;
            this.txtTelefono.Text = this.PersonaActual.Telefono;
            this.txtLegajo.Text = this.PersonaActual.Legajo.ToString();

            this.dtpFechaNac.Text = this.PersonaActual.FechaNacimiento.ToString();

            this.cmbPlan.DisplayMember = this.PersonaActual.IDPlan.ToString();
            


            //this.cmbPlan. = this.PersonaActual.IDPlan
            //this.cmbTipoPersona


            if (this.Modo == ModoForm.Alta || this.Modo == ModoForm.Modificacion)
            {
                this.btnAceptar.Text = "Guardar";
            }

            if (this.Modo == ModoForm.Baja)
            {
                this.btnAceptar.Text = "Eliminar";
            }

            if (this.Modo == ModoForm.Consulta)
            {
                this.btnAceptar.Text = "Aceptar";
            }
        }


        public override void MapearADatos()
        {

            if (this.Modo == ModoForm.Alta)
            {
                Persona per = new Persona();
                PersonaActual = per;
            }

            if (this.Modo == ModoForm.Alta || this.Modo == ModoForm.Modificacion)
            {
                PersonaActual.State = BusinessEntity.States.New;

                if (this.Modo == ModoForm.Modificacion)
                {
                    PersonaActual.ID = Int32.Parse(txtID.Text);
                    PersonaActual.State = BusinessEntity.States.Modified;
                }

                PersonaActual.Nombre = txtNombre.Text;
                PersonaActual.Apellido = txtApellido.Text;
                PersonaActual.Direccion = txtDireccion.Text;
                PersonaActual.Email = txtEmail.Text;
                PersonaActual.Legajo = Int32.Parse(txtLegajo.Text);
                PersonaActual.Telefono = txtTelefono.Text;

                PersonaActual.IDPlan = Int32.Parse(cmbPlan.SelectedValue.ToString());
                PersonaActual.TipoP = (Persona.TiposPersona)Int32.Parse(cmbTipoPersona.SelectedValue.ToString());
                PersonaActual.FechaNacimiento = dtpFechaNac.Value.Date;

            }

            if (this.Modo == ModoForm.Baja)
            {
                PersonaActual.State = BusinessEntity.States.Deleted;
            }


        }


        public override bool Validar()
        {
            String error = "Se han encontrado los siguientes errores: \n\n";
            bool vof = true;



            if (txtNombre.Text == "")
            {
                error = error + "El campo nombre no puede estar vacío. \n";
                vof = false;
            }

            if (txtApellido.Text == "")
            {
                error = error + "El campo apellido no puede estar vacío. \n";
                vof = false;
            }

            if (txtEmail.Text == "")
            {
                error = error + "El campo email no puede estar vacío. \n";
                vof = false;
            }

            if (txtDireccion.Text == "")
            {
                error = error + "El campo dirección no puede estar vacío. \n";
                vof = false;
            }

            if (txtLegajo.Text == "")
            {
                error = error + "El campo legajo no puede estar vacío. \n";
                vof = false;
            }

            if (txtTelefono.Text == "")
            {
                error = error + "El campo teléfono no puede estar vacío. \n";
                vof = false;
            }

            if (dtpFechaNac.Value.ToString() == "")
            {
                error = error + "El campo fecha de nacimiento no puede estar vacío. \n";
                vof = false;
            }

            if (dtpFechaNac.Value > DateTime.Now) 
            {
                error = error + "El campo fecha de nacimiento es incorrecta. \n";
                vof = false;
            }

            if (cmbPlan.Text == "")
            {
                error = error + "El plan no puede estar vacío. \n";
                vof = false;
            }

            if (cmbTipoPersona.Text == "")
            {
                error = error + "El tipo de persona no puede estar vacío. \n";
                vof = false;
            }



            if (!txtEmail.Text.Contains("@"))
            {
                error = error + "El campo email no es válido. \n";
                vof = false;
            }



            if (vof == true)
            {
                return true;
            }

            else
            {
                this.Notificar("Error", error, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;

            }
        }

        public override void GuardarCambios()
        {
            this.MapearADatos();
            PersonaLogic perLog = new PersonaLogic();
            perLog.Save(PersonaActual);
            //REVISAR NOTA PASO 18 (¿Hay que agregar algo?)
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (this.Modo == ModoForm.Alta || this.Modo == ModoForm.Modificacion)
            {
                if (this.Validar())
                {
                    this.GuardarCambios();
                    this.Close();
                }
            }
            else if (this.Modo == ModoForm.Baja)
            {
                this.GuardarCambios();
                this.Close();
            }

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void PersonasDesktop_Load(object sender, EventArgs e)
        {

            PlanesLogic planLog = new PlanesLogic();
            List<Plan> planes = new List<Plan>();

            planes = planLog.GetAll();
            cmbPlan.DataSource = planes;

            cmbPlan.ValueMember = "ID";
            cmbPlan.DisplayMember = "Descripcion";



            Dictionary<int, string> comboSource = new Dictionary<int, string>();
            comboSource.Add(3, "Alumno");
            comboSource.Add(2, "Profesor");
            comboSource.Add(1, "Administrador");
            cmbTipoPersona.DataSource = new BindingSource(comboSource, null);
            cmbTipoPersona.DisplayMember = "Value";
            cmbTipoPersona.ValueMember = "Key";
            cmbTipoPersona.SelectedIndex = 0;


        }
    }
}
