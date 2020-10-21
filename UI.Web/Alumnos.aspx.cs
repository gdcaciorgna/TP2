using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Business.Logic;
using Business.Entities;

namespace UI.Web
{
    public partial class Alumnos : System.Web.UI.Page
    {

        public enum FormModes
        {
            Alta,
            Baja,
            Modificacion
        }

        public FormModes FormMode
        {
            get { return (FormModes)this.ViewState["FormMode"]; }
            set { this.ViewState["FormMode"] = value; }
        }
        private Persona Entity
        {
            get;
            set;
        }
        private int SelectedID
        {
            get
            {
                if (this.ViewState["SelectedID"] != null)
                {
                    return (int)this.ViewState["SelectedID"];
                }
                else
                {
                    return 0;
                }
            }
            set
            {
                this.ViewState["SelectedID"] = value;
            }
        }
        private bool IsEntitySelected
        {
            get
            {
                return (this.SelectedID != 0);
            }
        }

        public Usuario UsuarioActual { get; set; }
        public Persona.TiposPersona TipoPersonaActual { get; set; }


        protected void Page_Load(object sender, EventArgs e)
        {
            UsuarioActual = (Usuario)Session["UsuarioActual"];

            if (UsuarioActual != null)
            {
                TipoPersonaActual = (Persona.TiposPersona)Session["TipoPersonaUsuarioActual"];


                if (TipoPersonaActual.Equals(Persona.TiposPersona.Administrador)) //verifico que sea administrador
                {
                    if (IsPostBack == false)
                    {
                        LoadGrid();
                    }

                }

                else
                {
                    Response.Redirect("~/Login.aspx");
                }
            }

            else
            {
                Response.Redirect("~/Login.aspx");
            }


        }


        private void LoadForm(int id)
        {


            this.inicializarForm();
            
            this.Entity = this.Logic.GetOne(id);
            this.tbNombre.Text = this.Entity.Nombre;
            this.tbApellido.Text = this.Entity.Apellido;
            this.tbDireccion.Text = this.Entity.Direccion;
            this.tbLegajo.Text = this.Entity.Legajo.ToString();
            this.tbTelefono.Text = this.Entity.Telefono;
            this.tbEmail.Text = this.Entity.Email;
            
            string fechaString = this.Entity.FechaNacimiento.ToString("dd/MM/yyyy");  // NO FUNCIONA
            this.tbFechaNacimiento.Text = fechaString;




            this.ddl_id_plan.SelectedValue = this.Entity.IDPlan.ToString();

            PersonaLogic perLog = new PersonaLogic();
            Persona per = new Persona();

   
            Persona.TiposPersona tipo_per = (Persona.TiposPersona) perLog.GetTipoPersona(this.Entity);
            this.Entity.TipoP = tipo_per;

            this.ddl_tipo_persona.SelectedValue = this.Entity.TipoP.ToString();

            








        }   



        PersonaLogic _logic;
        private PersonaLogic Logic
        {
            get
            {
                if (_logic == null)
                {
                    _logic = new PersonaLogic();
                }
                return _logic;
            }
        }

        private void LoadGrid()
        {
            this.GridView.DataSource = this.Logic.GetAllTipo(Persona.TiposPersona.Alumno);
            this.GridView.DataBind();
        }

        protected void lbNuevo_Click(object sender, EventArgs e)
        {
            this.inicializarForm();
            this.formPanel.Visible = true;
            this.FormMode = FormModes.Alta;
            this.ClearForm();
            this.EnableForm(true);

        }

        protected void lbEliminar_Click(object sender, EventArgs e)
        {
            if (this.IsEntitySelected)
            {
                this.formPanel.Visible = true;
                this.FormMode = FormModes.Baja;
                this.EnableForm(false);
                this.LoadForm(this.SelectedID);
            }

        }

        private void inicializarForm() 
        {
            PlanesLogic planLog = new PlanesLogic();
            List<Plan> planes = new List<Plan>();

            planes = planLog.GetAll();
            ddl_id_plan.DataSource = planes;
            ddl_id_plan.DataValueField = "ID";
            ddl_id_plan.DataTextField = "Descripcion";
            ddl_id_plan.DataBind();


            ddl_tipo_persona.DataSource = Enum.GetNames(typeof(Persona.TiposPersona));
            ddl_tipo_persona.DataBind();


        }

        private void EnableForm(bool enable)
        {

            this.ddl_id_plan.Enabled = enable;
            this.ddl_tipo_persona.Enabled = enable;
            //this.calFechaNacimiento.Enabled = enable; 

        }

        protected void lbEditar_Click(object sender, EventArgs e)
        {
            if (this.IsEntitySelected)
            {

                this.EnableForm(true);
                this.formPanel.Visible = true;
                this.FormMode = FormModes.Modificacion;
                this.LoadForm(this.SelectedID);

            }


        }

        private void DeleteEntity(int id)
        {
            this.Logic.Delete(id);
        }

        private void LoadEntity(Persona per)
        {
            
            per.Nombre = this.tbNombre.Text;
            per.Apellido = this.tbApellido.Text;
            per.Legajo = Int32.Parse(this.tbLegajo.Text);
            per.Telefono = this.tbTelefono.Text;            
            per.Direccion  = this.tbDireccion.Text;
            per.FechaNacimiento = DateTime.Parse(this.tbFechaNacimiento.Text).Date;
            per.Email = this.tbEmail.Text;
            per.IDPlan = Int32.Parse(ddl_id_plan.SelectedValue.ToString());


            TipoPersonaLogic tPerLogic = new TipoPersonaLogic();
            per.TipoP = tPerLogic.getTipoPersonaString(ddl_tipo_persona.SelectedValue.ToString()); 
           

        }

        private void SaveEntity(Persona per)
        {
            this.Logic.Save(per);
        }


        protected void lbAceptar_Click(object sender, EventArgs e)
        {
            switch (this.FormMode)
            {
                case FormModes.Baja:
                    this.DeleteEntity(this.SelectedID);
                    this.LoadGrid();
                    break;
                case FormModes.Modificacion:

                    this.Entity = new Persona();
                    this.Entity.ID = this.SelectedID;

                    this.Entity.State = BusinessEntity.States.Modified;
                    this.LoadEntity(this.Entity);
                    if (this.Validar() == true)
                    {
                        this.SaveEntity(this.Entity);
                        this.LoadGrid();


                    }
                    break;
                case FormModes.Alta:
                    this.Entity = new Persona();
                    this.LoadEntity(this.Entity);
                    if (this.Validar() == true)
                    {
                        this.SaveEntity(this.Entity);
                        this.LoadGrid();

                    }
                    break;
                default:
                    break;
            }
            this.formPanel.Visible = false;
        }

        public bool Validar()
        {
            String error = "Se han encontrado los siguientes errores: <br /><br />";
            bool vof = true;

            if (lblError.Text == "")
            {
                error = error + "El campo nombre no puede estar vacío. <br />";
                vof = false;
            }

            if (vof == true)
            {
                return true;
            }

            else
            {
                this.PanelError.Visible = true;
                this.lblError.Text = error;
                return false;
            }


            return vof;

        }

        protected void lbCancelar_Click(object sender, EventArgs e)
        {
            this.formPanel.Visible = false;
            this.LoadGrid();

        }

        private void ClearForm()
        {

            this.tbNombre.Text = string.Empty;
            this.tbApellido.Text = string.Empty;
            this.tbEmail.Text = string.Empty;
            this.tbTelefono.Text = string.Empty;
            this.tbDireccion.Text = string.Empty;
            //this.tbFechaNacimiento.Text = 
            //this.calFechaNacimiento.SelectedDate = DateTime.Now.Date;
            this.tbLegajo.Text = string.Empty;
            
 
            
        }


        protected void GridView_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.SelectedID = (int)this.GridView.SelectedValue;

        }

        protected void lbVerTodo_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Personas.aspx");
        }

        protected void lbVerDocentes_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Docentes.aspx");
        }

        protected void lbVerAlumnos_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Alumnos.aspx");
        }
    }
}