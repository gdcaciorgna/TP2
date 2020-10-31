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
    public partial class Comisiones : System.Web.UI.Page
    {
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
        private Comision Entity
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
            this.txtDescripcion.Text = this.Entity.Descripcion;
            this.txtAnioEspecialidad.Text = this.Entity.AnioEspecialidad.ToString();
            this.ddlIDPlan.SelectedValue = this.Entity.IDPlan.ToString();
            PlanesLogic planLog = new PlanesLogic();
            List<Plan> planes = new List<Plan>();

            planes = planLog.GetAll();
            ddlIDPlan.DataSource = planes;
            ddlIDPlan.DataValueField = "ID";
            ddlIDPlan.DataTextField = "Descripcion";
            ddlIDPlan.DataBind();

        }
        protected void GridViewComisiones_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.SelectedID = (int)this.GridViewComisiones.SelectedValue;
        }

        protected void btnEditar_Click(object sender, EventArgs e)
        {
            if (this.IsEntitySelected)
            {


                this.PanelCampos.Visible = true;
                this.FormMode = FormModes.Modificacion;
                this.LoadForm(this.SelectedID);

            }
        }


        private void LoadGrid()
        {
            this.GridViewComisiones.DataSource = this.Logic.GetAll();
            this.GridViewComisiones.DataBind();



            PlanesLogic planLog = new PlanesLogic();
            List<Plan> planes = new List<Plan>();

            planes = planLog.GetAll();
            ddlIDPlan.DataSource = planes;
            ddlIDPlan.DataValueField = "ID";
            ddlIDPlan.DataTextField = "Descripcion";
            ddlIDPlan.DataBind();
        }

        ComisionLogic _logic;
        private ComisionLogic Logic
        {
            get
            {
                if (_logic == null)
                {
                    _logic = new ComisionLogic();
                }
                return _logic;
            }

        }

        private void LoadEntity(Comision com)
        {
            if (Validar()) 
            { 

            int a = Int32.Parse(ddlIDPlan.SelectedValue);
            com.IDPlan = a;

            int b = Int32.Parse(txtAnioEspecialidad.Text);
            com.AnioEspecialidad = b;

            com.Descripcion = txtDescripcion.Text;
            }
        }

        private void SaveEntity(Comision com)
        {
            this.Logic.Save(com);
        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            switch (this.FormMode)
            {
                case FormModes.Baja:
                    this.DeleteEntity(this.SelectedID);
                    this.LoadGrid();
                    break;
                case FormModes.Modificacion:

                    this.Entity = new Comision();
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
                    this.Entity = new Comision();
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
            this.PanelCampos.Visible = false;
        }

        private void EnableForm(bool enable)
        {

            this.ddlIDPlan.Enabled = enable;
            this.txtAnioEspecialidad.Enabled = enable;
            this.txtAnioEspecialidad.Enabled = enable;
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            if (this.IsEntitySelected)
            {
                this.PanelCampos.Visible = true;
                this.FormMode = FormModes.Baja;
                this.EnableForm(false);
                this.LoadForm(this.SelectedID);
            }
        }

        private void DeleteEntity(int id)
        {
            this.Logic.Delete(id);
        }

        protected void btnNuevo_Click(object sender, EventArgs e)
        {
            this.PanelCampos.Visible = true;
            this.FormMode = FormModes.Alta;
            this.ClearForm();
            this.EnableForm(true);
        }

        private void ClearForm()
        {

            this.txtDescripcion.Text = string.Empty;
            this.txtAnioEspecialidad.Text = string.Empty;
           
        }

        public bool Validar()
        {
            String error = "Se han encontrado los siguientes errores: <br /><br />";
            bool vof = true;

            if (txtDescripcion.Text == "")
            {
                error = error + "El campo descripcion no puede estar vacío. <br />";
                vof = false;
            }


            if (txtAnioEspecialidad.Text == "")
            {
                error = error + "El campo Año de especialidad no puede estar vacío. <br />";
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

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            this.PanelCampos.Visible = false;
            this.LoadGrid();
        }
    }
}