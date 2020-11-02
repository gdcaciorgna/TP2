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
    public partial class InscribirAlumnosACursos : System.Web.UI.Page
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
                        CursoLogic curLog = new CursoLogic();
                        List<Curso> cursos = new List<Curso>();

                        cursos = curLog.GetAll();

                        ddl_Cursos.DataSource = cursos;
                        ddl_Cursos.DataValueField = "ID";
                        ddl_Cursos.DataTextField = "Descripcion"; // Esto se podria mejorar quitando informacion redundante de Desc. Cursos
                        ddl_Cursos.DataBind();


                        PersonaLogic perLog = new PersonaLogic();
                        List<Persona> alumnos = new List<Persona>();

                        alumnos = perLog.GetAllTipo(Persona.TiposPersona.Alumno);


                        DataTable dt = new DataTable();
                        dt = Util.FuncionesComunes.ConvertToDataTable(alumnos);
                        dt.Columns.Add(new DataColumn("NombreApellidoLegajo", System.Type.GetType("System.String"), "Apellido + ' ' + Nombre + ' - ' + Legajo"));

                        ddl_Alumno.DataSource = dt;

                        ddl_Alumno.DataValueField = "ID";
                        ddl_Alumno.DataTextField = "NombreApellidoLegajo";
                        ddl_Alumno.DataBind();

                  
        
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


        AlumnoInscripcionLogic _logic;
        private AlumnoInscripcionLogic Logic
        {
            get
            {
                if (_logic == null)
                {
                    _logic = new AlumnoInscripcionLogic();
                }
                return _logic;
            }
        }


        private void LoadGrid()
        {

            this.dgv_AlumnosPorCurso.DataSource = this.Logic.GetAllCompleto();
            this.dgv_AlumnosPorCurso.DataBind();

        }

        private AlumnoInscripcion Entity
        {
            get;
            set;
        }


        private void LoadForm(int id)
        {

            this.Entity = this.Logic.GetOne(id);

            this.ddl_Alumno.SelectedValue = this.Entity.IDAlumno.ToString();
            
           this.tbCondicion.Text = this.Entity.Condicion;
            this.tbNota.Text =  this.Entity.Nota.ToString();


            PersonaLogic perLog = new PersonaLogic();
            Persona per = new Persona();


        }


        private void DeleteEntity(int id)
        {
            this.Logic.Delete(id);
        }

        private void LoadEntity(AlumnoInscripcion aluInsc)
        {
            if (Validar())
            {
                aluInsc.IDAlumno = Int32.Parse(ddl_Alumno.SelectedValue.ToString());
                aluInsc.IDCurso = Int32.Parse(this.ddl_Cursos.SelectedValue.ToString());
                aluInsc.Condicion = tbCondicion.Text;
                aluInsc.Nota = Int32.Parse(this.tbNota.Text.ToString());
            }

        }

        private void SaveEntity(AlumnoInscripcion aluInsc)
        {
            this.Logic.Save(aluInsc);
        }

        public bool Validar()
        {
            String error = "Se han encontrado los siguientes errores: <br /><br />";
            bool vof = true;

            if (tbCondicion.Text == "")
            {
                error = error + "El campo condicion no puede estar vacío. <br />";
                vof = false;
            }

            if (tbNota.Text == "")
            {
                error = error + "El campo nota no puede estar vacío. <br />";
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

        private void ClearForm()
        {

            this.tbCondicion.Text = string.Empty;
            this.tbNota.Text = string.Empty;


        }

        private void EnableForm(bool enable)
        {

            this.tbNota.Enabled = enable;
            this.tbCondicion.Enabled = enable;
            this.ddl_Cursos.Enabled = enable;
            this.ddl_Alumno.Enabled = enable;

        }



        public Usuario UsuarioActual { get; set; }
        public Persona.TiposPersona TipoPersonaActual { get; set; }


        protected void lbNuevo_Click(object sender, EventArgs e)
        {
            this.formPanel.Visible = true;
            this.FormMode = FormModes.Alta;
            this.ClearForm();
            this.EnableForm(true);
        }

 

        protected void btnActualizar_Click1(object sender, EventArgs e)
        {
            int cur = Int32.Parse(ddl_Cursos.SelectedValue.ToString());

            this.dgv_AlumnosPorCurso.DataSource = this.Logic.GetAllAlumnosPorCursoCompleto(cur);
            this.dgv_AlumnosPorCurso.DataBind();
        }


        protected void lbCancelar_Click(object sender, EventArgs e)
        {
            this.formPanel.Visible = false;
            this.LoadGrid();

        }

        protected void lbAceptar_Click1(object sender, EventArgs e)
        {
            switch (this.FormMode)
            {
                case FormModes.Baja:
                    this.DeleteEntity(this.SelectedID);
                    this.LoadGrid();
                    break;
                case FormModes.Modificacion:

                    this.Entity = new AlumnoInscripcion();
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
                    this.Entity = new AlumnoInscripcion();
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

        protected void btnEditar2_Click(object sender, EventArgs e)
        {

        }

        protected void btnEliminar2_Click(object sender, EventArgs e)
        {
            if (this.IsEntitySelected)
            {
                this.formPanel.Visible = true;
                this.FormMode = FormModes.Baja;
                this.EnableForm(false);
                this.LoadForm(this.SelectedID);
            }

        }

        protected void btnEditar2_Click1(object sender, EventArgs e)
        {
            if (this.IsEntitySelected)
            {


                this.formPanel.Visible = true;
                this.FormMode = FormModes.Modificacion;
                this.LoadForm(this.SelectedID);

            }
        }

        protected void dgv_AlumnosPorCurso_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.SelectedID = (int)this.dgv_AlumnosPorCurso.SelectedValue;

        }
    }
}