using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Business.Entities;
using Business.Entities;
using Business.Logic;

namespace UI.Web
{
    public partial class VerCursosdeDocente : System.Web.UI.Page
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

        protected void Page_Load(object sender, EventArgs e)
        {
            UsuarioActual = (Usuario)Session["UsuarioActual"];

            if (UsuarioActual != null)
            {
                TipoPersonaActual = (Persona.TiposPersona)Session["TipoPersonaUsuarioActual"];


                if (TipoPersonaActual.Equals(Persona.TiposPersona.Docente)) //cambiar a docente
                {
                    if (IsPostBack == false)
                    {

                        List<Curso> cursos = new List<Curso>();


                        DocenteCursoLogic doccur = new DocenteCursoLogic();

                        cursos = doccur.GetAll(UsuarioActual.ID);

                        gvCursosdeDocente.DataSource = cursos;
                        gvCursosdeDocente.DataBind();



                        //  LoadGrid();
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
    }
}