using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Business.Entities;
using Business.Logic;


namespace UI.Web
{
    public partial class Planes : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            UsuarioActual = (Usuario)Session["UsuarioActual"];

            if (UsuarioActual != null)
            {
                TipoPersonaActual = (Persona.TiposPersona)Session["TipoPersonaUsuarioActual"];


                if (TipoPersonaActual.ToString().Equals("Administrador")) //verifico que sea administrador
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

        public Usuario UsuarioActual { get; set; }
        public Persona.TiposPersona TipoPersonaActual { get; set; }

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
        private Plan Entity
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
       

        private void LoadForm(int id)
        {
            this.Entity = this.Logic.GetOne(id);
            this.Desc_PlanTextBox.Text = this.Entity.Descripcion;
            this.Id_Especialidaddrownlist.SelectedValue = this.Entity.IDEspecialidad.ToString();
          

        }

        PlanesLogic _logic;
        private PlanesLogic Logic
        {
            get
            {
                if (_logic == null)
                {
                    _logic = new PlanesLogic();
                }
                return _logic;
            }

        }
        private void LoadGrid()
        {
            this.gridView.DataSource = this.Logic.GetAll();
            this.gridView.DataBind();
        }

        protected void EditarPlanLink_Click(object sender, EventArgs e)
        {
            

            if (this.IsEntitySelected)
            {

                this.EnableForm(true);
                this.fomrPanel.Visible = true;
                this.FormMode = FormModes.Modificacion;
                this.LoadForm(this.SelectedID);

            }
          

        }
        protected void gridView_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.SelectedID = (int)this.gridView.SelectedValue;

        }
        private void LoadEntity(Plan plan)
        {
            int a = Int32.Parse(Id_Especialidaddrownlist.SelectedValue);
            plan.IDEspecialidad = a;

            plan.Descripcion = this.Desc_PlanTextBox.Text;
           
       }

        private void SaveEntity(Plan plan)
        {
            this.Logic.Save(plan);
        }

        protected void btnaceptarPlan_Click(object sender, EventArgs e)
        {
            switch (this.FormMode)
            {
                case FormModes.Baja:
                    this.DeleteEntity(this.SelectedID);
                    this.LoadGrid();
                    break;
                case FormModes.Modificacion:

                    this.Entity = new Plan();
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
                    this.Entity = new Plan();
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
            this.fomrPanel.Visible = false;
        }

        private void EnableForm(bool enable)
        {
            
            this.Id_Especialidaddrownlist.Enabled = enable;
            this.Desc_PlanTextBox.Enabled = enable;
        }

        protected void EliminarPlanLink_Click(object sender, EventArgs e)
        {

            if (this.IsEntitySelected)
            {
                this.fomrPanel.Visible = true;
                this.FormMode = FormModes.Baja;
                this.EnableForm(false);
                this.LoadForm(this.SelectedID);
            }
        }
        private void DeleteEntity (int id)
        {
            this.Logic.Delete(id);
        }

        protected void AgregarPlanLink_Click(object sender, EventArgs e)
        {
          
            EspecialidadesLogic espLog = new EspecialidadesLogic();
            List<Especialidad> especialidades = new List<Especialidad>();

            especialidades = espLog.GetAll();
            Id_Especialidaddrownlist.DataSource = especialidades;
            Id_Especialidaddrownlist.DataValueField = "ID";
            Id_Especialidaddrownlist.DataTextField = "Descripcion";
            Id_Especialidaddrownlist.DataBind();

            this.fomrPanel.Visible = true;
            this.FormMode = FormModes.Alta;
            this.ClearForm();
            this.EnableForm(true);
        }
        private void ClearForm()
        {
            
            this.Desc_PlanTextBox.Text = string.Empty;
          // this.Id_Especialidaddrownlist.Text = string.Empty;
            
        }

        public bool Validar()
        {
            String error = "Se han encontrado los siguientes errores: <br /><br />";
            bool vof = true;
           
            if(Desc_PlanTextBox.Text == "") 
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
                this.panelerror.Visible = true;
                this.lblerror.Text = error;
                return false;
            }


            return vof;

        }

        protected void Id_EspecialidadcheckBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        protected void btnCancelarPlan_Click(object sender, EventArgs e)
        {
            this.fomrPanel.Visible = false;
            this.LoadGrid();
        }
    }

}




