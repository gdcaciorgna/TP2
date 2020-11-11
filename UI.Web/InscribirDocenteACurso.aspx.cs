using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Business.Entities;
using Business.Logic;
using System.Data;

namespace UI.Web
{
    public partial class InscribirDocenteACurso : System.Web.UI.Page
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
                        PersonaLogic perLog = new PersonaLogic();
                        List<Persona> docent = new List<Persona>();

                        docent = perLog.GetAllTipo(Persona.TiposPersona.Docente);

                        DataTable dt = new DataTable();
                        dt = Util.FuncionesComunes.ConvertToDataTable(docent);
                        dt.Columns.Add(new DataColumn("NombreApellido", System.Type.GetType("System.String"), "Apellido + ' ' + Nombre "));

                        ddlDocentes.DataSource = dt;
                        ddlDocentes.DataValueField = "ID";
                        ddlDocentes.DataTextField = "NombreApellido";
                        ddlDocentes.DataBind();

                        CursoLogic curLog = new CursoLogic();
                        List<Curso> cursos = new List<Curso>();

                        cursos = curLog.GetAll();

                        ddl_Cursos.DataSource = cursos;
                        ddl_Cursos.DataValueField = "ID";
                        ddl_Cursos.DataTextField = "Descripcion"; // Esto se podria mejorar quitando informacion redundante de Desc. Cursos
                        ddl_Cursos.DataBind();

                        ddl_TipoCargos.DataSource = Enum.GetNames(typeof(DocenteCurso.TiposCargo));
                        ddl_TipoCargos.DataBind();
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

        DocenteCursoLogic _logic;
        private DocenteCursoLogic Logic
        {
            get
            {
                if (_logic == null)
                {
                    _logic = new DocenteCursoLogic();
                }
                return _logic;
            }
        }


        private void LoadGrid()
        {
           

            this.dgvDocentesxCurso.DataSource = this.Logic.GetAllCompleto();
            this.dgvDocentesxCurso.DataBind();
           


        }



        private DocenteCurso Entity
        {
            get;
            set;
        }


        private void DeleteEntity(int id)
        {
            this.Logic.Delete(id);
        }

       
        private void LoadForm(int id)
        {

            this.Entity = this.Logic.GetOne(id);

            this.ddlDocentes.SelectedValue = this.Entity.IDDocente.ToString();

            this.ddl_TipoCargos.Text = this.Entity.Cargo.ToString();
            


            PersonaLogic perLog = new PersonaLogic();
            Persona per = new Persona();


        }
        private void LoadEntity(DocenteCurso docCur)
        {


            docCur.IDCurso = Int32.Parse(this.ddl_Cursos.SelectedValue.ToString());
            docCur.IDDocente = Int32.Parse(ddlDocentes.SelectedValue.ToString());
             DocenteCursoLogic tdocLogic = new DocenteCursoLogic();
            docCur.Cargo = tdocLogic.getTipoCargoString(ddl_TipoCargos.SelectedValue.ToString());



        }

        private void SaveEntity(DocenteCurso docCur)
        {
            this.Logic.Save(docCur);
        }
     

        private void ClearForm()
        {

           
            
        }

        private void EnableForm(bool enable)
        {

            this.ddl_TipoCargos.Enabled = enable;
            this.ddl_Cursos.Enabled = enable;
            this.ddlDocentes.Enabled = enable;

        }

        public Usuario UsuarioActual { get; set; }
        public Persona.TiposPersona TipoPersonaActual { get; set; }



        protected void btnActualizar_Click(object sender, EventArgs e)
        {

            this.Panelbotones.Visible = true;
            int cur = Int32.Parse(ddl_Cursos.SelectedValue.ToString());

            this.dgvDocentesxCurso.DataSource = this.Logic.GetAllDocentesPorCurso(cur);
            this.dgvDocentesxCurso.DataBind();
          
        }

        protected void dgvDocentesxCurso_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.SelectedID = (int)this.dgvDocentesxCurso.SelectedValue;

        }

        protected void btnNuevo_Click(object sender, EventArgs e)
        {
            this.PanelCampos.Visible = true;
            this.FormMode = FormModes.Alta;
            this.ClearForm();
            this.EnableForm(true);

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            switch (this.FormMode)
            {
                case FormModes.Baja:
                    this.DeleteEntity(this.SelectedID);
                    this.LoadGrid();
                    break;
                case FormModes.Modificacion:

                    this.Entity = new DocenteCurso();
                    this.Entity.ID = this.SelectedID;

                    this.Entity.State = BusinessEntity.States.Modified;
                    this.LoadEntity(this.Entity);
                    
                    
                        this.SaveEntity(this.Entity);
                        this.LoadGrid();


                    
                    break;
                case FormModes.Alta:
                    this.Entity = new DocenteCurso();
                    this.LoadEntity(this.Entity);                
                    this.SaveEntity(this.Entity);
                    this.LoadGrid();

                    
                    break;
                default:
                    break;
            }
            this.PanelCampos.Visible = false;
            this.EnableForm(true);
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

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            
            this.LoadGrid();

        }

        protected void ddlCargos_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void btnEditar_Click(object sender, EventArgs e)
        {
            if ( this.IsEntitySelected )
            {
                this.PanelCampos.Visible = true;
                this.FormMode = FormModes.Modificacion;
                this.LoadForm(this.SelectedID);
            
            }
        }
    }
}