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

            CursoLogic curLog = new CursoLogic();
            List<Curso> cursos = new List<Curso>();

            cursos = curLog.GetAll();

            ddl_Cursos.DataSource = cursos;
            ddl_Cursos.DataValueField = "ID";
            ddl_Cursos.DataTextField = "Descripcion"; // Esto se podria mejorar quitando informacion redundante de Desc. Cursos
            ddl_Cursos.DataBind();




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




        public Usuario UsuarioActual { get; set; }
        public Persona.TiposPersona TipoPersonaActual { get; set; }



        protected void btnActualizar_Click(object sender, EventArgs e)
        {
            int cur = Int32.Parse(ddl_Cursos.SelectedValue.ToString());

            this.dgvDocentesxCurso.DataSource = this.Logic.GetAllDocentesPorCursoCompleto(cur);
            this.dgvDocentesxCurso.DataBind();
        }

        protected void dgvDocentesxCurso_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}