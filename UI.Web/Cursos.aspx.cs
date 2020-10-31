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
    public partial class Cursos : System.Web.UI.Page
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
        private Curso Entity
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

        private void LoadForm(int id)
        {
            this.Entity = this.Logic.GetOne(id);
            this.tbDescripcion.Text = this.Entity.Descripcion;
            this.tbCupo.Text = this.Entity.Cupo.ToString();
            this.tbanio.Text = this.Entity.AnioCalendario.ToString();
            this.ddl_Comision.SelectedValue = this.Entity.IDComision.ToString();
            this.ddl_Materia.SelectedValue = this.Entity.IDMateria.ToString();
        }
        CursoLogic _logic;
        private CursoLogic Logic
        {
            get
            {
                if (_logic == null)
                {
                    _logic = new CursoLogic();
                }
                return _logic;
            }
        }
        private void LoadGrid()
        {
            this.dgv_Cursos.DataSource = this.Logic.GetAll();
            this.dgv_Cursos.DataBind();


            List<Comision> comisiones = new List<Comision>();
            ComisionLogic comLog = new ComisionLogic();
            comisiones = comLog.GetAll();


            ddl_Comision.DataSource = comisiones;
            ddl_Comision.DataValueField = "Id";
            ddl_Comision.DataTextField = "Descripcion";
            ddl_Comision.DataBind();


            List<Materia> materias = new List<Materia>();
            MateriaLogic matLog = new MateriaLogic();
            materias = matLog.GetAll();

            ddl_Materia.DataSource = materias;
            ddl_Materia.DataValueField = "Id";
            ddl_Materia.DataTextField = "Descripcion";
            ddl_Materia.DataBind();




        }

        private void LoadEntity(Curso curso)
        {
            if (this.Validar()) 
            {

                curso.Descripcion = this.tbDescripcion.Text;
                curso.Cupo = Int32.Parse(this.tbCupo.Text);
                curso.AnioCalendario = Int32.Parse(this.tbanio.Text);
                int b = Int32.Parse(ddl_Comision.SelectedValue);
                curso.IDComision = b;
                int a = Int32.Parse(ddl_Materia.SelectedValue);
                curso.IDMateria = a;
            }

          
        }

        private void SaveEntity(Curso curso)
        {
            this.Logic.Save(curso);
        }


        private void EnableForm(bool enable)
        {
            this.tbDescripcion.Enabled = enable;
            this.tbCupo.Enabled = enable;
            this.tbanio.Enabled = enable;
            this.ddl_Comision.Enabled = enable;
            this.ddl_Materia.Enabled = enable;
        }

        private void DeleteEntity(int id)
        {
            this.Logic.Delete(id);
        }

        private void ClearForm()
        {
            this.tbDescripcion.Text = string.Empty;
            this.tbCupo.Text = string.Empty;
            this.tbanio.Text = string.Empty;
        }


        public bool Validar()
        {
            String error = "Se han encontrado los siguientes errores: <br /><br />";
            bool vof = true;



            if (tbDescripcion.Text == "")
            {
                error = error + "El campo Descripcion no puede estar vacío. <br />";
                vof = false;
            }

            if (tbCupo.Text == "")
            {
                error = error + "El campo Cupo no puede estar vacío. <br />";
                vof = false;
            }

            if (tbanio.Text == "")
            {
                error = error + "El campo anio Comision no puede estar vacío. <br />";
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
        }
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



        protected void lbEditar_Click1(object sender, EventArgs e)
        {
            if (this.IsEntitySelected)
            {
                this.EnableForm(true);
                this.formPanel.Visible = true;
                this.FormMode = FormModes.Modificacion;
                this.LoadForm(this.SelectedID);
            }
        }

        protected void lbAceptar_Click1(object sender, EventArgs e)
        {
            switch (this.FormMode)
            {
                case FormModes.Baja:
                    this.DeleteEntity(this.SelectedID);
                    this.LoadGrid();
                    this.formPanel.Visible = false;
                    break;
                case FormModes.Modificacion:
                    this.Entity = new Curso();
                    this.Entity.ID = this.SelectedID;
                    this.Entity.State = BusinessEntity.States.Modified;
                    this.LoadEntity(this.Entity);
                    if (this.Validar() == true)
                    {
                        this.SaveEntity(this.Entity);
                        this.LoadGrid();
                        this.formPanel.Visible = false;
                        this.PanelError.Visible = false;
                    }
                    break;
                case FormModes.Alta:
                    this.Entity = new Curso();
                    this.LoadEntity(this.Entity);
                    if (this.Validar() == true)
                    {
                        this.SaveEntity(this.Entity);
                        this.LoadGrid();
                        this.formPanel.Visible = false;
                        this.PanelError.Visible = false;
                    }
                    break;
                default:
                    break;
            }
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

        protected void lbNuevo_Click(object sender, EventArgs e)
        {
            this.formPanel.Visible = true;
            this.FormMode = FormModes.Alta;
            this.ClearForm();
            this.EnableForm(true);
        }

        protected void lbCancelar_Click(object sender, EventArgs e)
        {
            this.formPanel.Visible = false;
            this.LoadGrid();
        }


        protected void dgv_Cursos_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.SelectedID = (int)this.dgv_Cursos.SelectedValue;

        }
    }
}