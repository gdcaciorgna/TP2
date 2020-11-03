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
    public partial class InscribirseAMateria : System.Web.UI.Page
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
                        CursoLogic curLog = new CursoLogic();
                        List<Curso> cursos = new List<Curso>();

                        int anioCalendario = DateTime.Now.Year;

                        cursos = curLog.GetAll(anioCalendario);

                        ddl_anioCalendario.DataSource = cursos;
                        ddl_anioCalendario.DataValueField = "ID";
                        ddl_anioCalendario.DataTextField = "Descripcion"; // Esto se podria mejorar quitando informacion redundante de Desc. Cursos
                        ddl_anioCalendario.DataBind();


                        PersonaLogic perLog = new PersonaLogic();
                        List<Persona> alumnos = new List<Persona>();

                        alumnos = perLog.GetAllTipo(Persona.TiposPersona.Alumno);


                        DataTable dt = new DataTable();
                        dt = Util.FuncionesComunes.ConvertToDataTable(alumnos);
                        dt.Columns.Add(new DataColumn("NombreApellidoLegajo", System.Type.GetType("System.String"), "Apellido + ' ' + Nombre + ' - ' + Legajo"));

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

            this.dgv_InscripcionesACurso.DataSource = this.Logic.GetAllCompleto();
            this.dgv_InscripcionesACurso.DataBind();

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
            this.tbNota.Text = this.Entity.Nota.ToString();


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
                aluInsc.IDAlumno = Int32.Parse();
                aluInsc.IDCurso = Int32.Parse(this.ddl_anioCalendario.SelectedValue.ToString());
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
            this.ddl_anioCalendario.Enabled = enable;
            this.ddl_Alumno.Enabled = enable;

        }



        public Usuario UsuarioActual { get; set; }
        public Persona.TiposPersona TipoPersonaActual { get; set; }


        protected void dgv_InscripcionesACurso_SelectedIndexChanged(object sender, EventArgs e)
        {
                         
        }

        protected void btnActualizar_Click(object sender, EventArgs e)
        {

        }

        protected void lbNuevo_Click(object sender, EventArgs e)
        {

        }

        protected void btnEditar2_Click(object sender, EventArgs e)
        {

        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {

        }

        protected void lbAceptar_Click(object sender, EventArgs e)
        {

        }

        protected void lbCancelar_Click(object sender, EventArgs e)
        {

        }
    }
}