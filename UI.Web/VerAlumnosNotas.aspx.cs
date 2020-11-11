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
    public partial class VerAlumnosNotas : System.Web.UI.Page
    {

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
        
        public Curso CursoActual { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            UsuarioActual = (Usuario)Session["UsuarioActual"];
            CursoActual = (Curso)Session["CursoActual"];

            if (UsuarioActual != null)
            {
                TipoPersonaActual = (Persona.TiposPersona)Session["TipoPersonaUsuarioActual"];
                txtCursoAcutual.Text = CursoActual.Descripcion;


                if (TipoPersonaActual.Equals(Persona.TiposPersona.Docente)) //cambiar a docente
                {
                    if (IsPostBack == false)
                    {



                        AlumnoInscripcionLogic alumIns = new AlumnoInscripcionLogic();
                        List<AlumnoInscripcion> alum = new List<AlumnoInscripcion>();

                        alum = alumIns.GetAllAlumnosPorCurso(CursoActual.ID);

                        gvAlumnosCurso.DataSource = alum;
                        gvAlumnosCurso.DataBind();



                        
                    }


                }
            }
        }

        protected void btnEditar_Click(object sender, EventArgs e)
        {
            if (this.SelectedID != 0)
            {
                AlumnoInscripcion alum = new AlumnoInscripcion();
                AlumnoInscripcionLogic AlumLog = new AlumnoInscripcionLogic();

                alum = AlumLog.GetOne(this.SelectedID);

                Session["AlumnoActual"] = alum;

                Response.Redirect("~/EditarAlumno.aspx");

            }
            else 
            {
                this.panelError.Visible = Visible;
            }
        }

        protected void gvAlumnosCurso_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.SelectedID = (int)this.gvAlumnosCurso.SelectedValue;
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/VerCursosdeDocente.aspx");
        }
    }
}