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
    public partial class Materias : System.Web.UI.Page
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
        private Materia Entity
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
            this.txbDescripcionmaterias.Text = this.Entity.Descripcion;
            this.txbHsSemanales.Text = this.Entity.HSSemanales.ToString();
            this.txbHorasTotales.Text = this.Entity.HSTotales.ToString();
            this.DplIDPlan.SelectedValue = this.Entity.IDPlan.ToString();



        }


        MateriaLogic _logic;
        private MateriaLogic Logic
        {
            get
            {
                if (_logic == null)
                {
                    _logic = new MateriaLogic();
                }
                return _logic;
            }

        }

        private void LoadGrid()
        {
            this.GridMaterias.DataSource = this.Logic.GetAll();
            this.GridMaterias.DataBind();


            PlanesLogic planLog = new PlanesLogic();
            List<Plan> planes = new List<Plan>();

            planes = planLog.GetAll();
            DplIDPlan.DataSource = planes;
            DplIDPlan.DataValueField = "ID";
            DplIDPlan.DataTextField = "Descripcion";
            DplIDPlan.DataBind();

        }
        protected void GridMaterias_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.SelectedID = (int)this.GridMaterias.SelectedValue;
        }

        protected void BtnEditar_Click(object sender, EventArgs e)
        {
            if (this.IsEntitySelected)
            {

                
                this.PanelCampos.Visible = true;
                this.FormMode = FormModes.Modificacion;
                this.LoadForm(this.SelectedID);

            }

        }

        private void LoadEntity(Materia mat)
        {
            if (Validar()) { 
            int a = Int32.Parse(DplIDPlan.SelectedValue);
            mat.IDPlan = a;

            int b = Int32.Parse(txbHsSemanales.Text);
            mat.HSSemanales = b;

            int c = Int32.Parse(txbHorasTotales.Text);
            mat.HSTotales = c;

            mat.Descripcion = txbDescripcionmaterias.Text;
            }
        }

        private void SaveEntity(Materia mat)
        {
            this.Logic.Save(mat);
        }

        protected void BtnAceptar_Click(object sender, EventArgs e)
        {
            switch (this.FormMode)
            {
                case FormModes.Baja:
                    this.DeleteEntity(this.SelectedID);
                    this.LoadGrid();
                    break;
                case FormModes.Modificacion:

                    this.Entity = new Materia();
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
                    this.Entity = new Materia();
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

            this.DplIDPlan.Enabled = enable;
            this.txbDescripcionmaterias.Enabled = enable;
            this.txbHorasTotales.Enabled = enable;
            this.txbHsSemanales.Enabled = enable;
        }

        protected void BtnEliminar_Click(object sender, EventArgs e)
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

        protected void BtnNuevo_Click(object sender, EventArgs e)
         {


        this.PanelCampos.Visible = true;
        this.FormMode = FormModes.Alta;
        this.ClearForm();
        this.EnableForm(true);
          }
        private void ClearForm()
        {

            this.txbDescripcionmaterias.Text = string.Empty;
            this.txbHorasTotales.Text = string.Empty;
            this.txbHsSemanales.Text = string.Empty;

        }
        public bool Validar()
        {
            String error = "Se han encontrado los siguientes errores: <br /><br />";
            bool vof = true;

            if (txbDescripcionmaterias.Text == "")
            {
                error = error + "El campo descripcion de materias no puede estar vacío. <br />";
                vof = false;
            }
            
            if (txbHorasTotales.Text == "")
            {
                error = error + "El campo horas totales no puede estar vacío. <br />";
                vof = false;
            }

            if (txbHsSemanales.Text == "")
            {
                error = error + "El campo horas semanales no puede estar vacío. <br />";
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

        protected void BtnCancelar_Click(object sender, EventArgs e)
        {
            this.PanelCampos.Visible = false;
            this.LoadGrid();
        }

       
    }
    
}