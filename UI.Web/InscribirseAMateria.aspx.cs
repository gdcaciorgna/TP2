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


                if (TipoPersonaActual.Equals(Persona.TiposPersona.Alumno)) //verifico que sea administrador
                {
                    if (IsPostBack == false)
                    {

                        MateriaLogic matLog = new MateriaLogic();
                        List <Materia> materias = new List<Materia>();

                        ddl_Materia.DataSource = matLog.GetAll();
                        ddl_Materia.DataValueField = "ID";
                        ddl_Materia.DataTextField = "Descripcion";
                        ddl_Materia.DataBind();
                        


                        ComisionLogic comLog = new ComisionLogic();
                        List<Comision> comisiones = new List<Comision>();

                        ddl_Comision.DataSource = comLog.GetAll();
                        ddl_Comision.DataValueField = "ID";
                        ddl_Comision.DataTextField = "Descripcion";
                        ddl_Comision.DataBind();


                        CursoLogic curLog = new CursoLogic();

                        List<int> anios = curLog.GetAllAnios();

                        ddl_anioCalendario.DataSource = anios;
                        ddl_anioCalendario.DataBind();

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

        public Curso CursoActual { get; set; }



        private void LoadGrid()
        {
            int id_alumno = this.UsuarioActual.ID_Persona;
            this.dgv_InscripcionesACurso.DataSource = this.Logic.GetAllInscripcionesPorAlumno(id_alumno);
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


            Curso cur = new Curso();
            CursoLogic curLog = new CursoLogic();


            int id_cur = Int32.Parse(this.Entity.IDCurso.ToString());
            cur = curLog.GetOne(this.Entity.IDCurso);


            MateriaLogic matLog = new MateriaLogic();
            ComisionLogic comLog = new ComisionLogic();

            Comision com = new Comision();
            Materia mat = new Materia();


            com = comLog.GetOne(cur.IDComision);
            mat = matLog.GetOne(cur.IDMateria);

            this.ddl_Comision.SelectedValue = cur.IDComision.ToString();
            this.ddl_Materia.SelectedValue = cur.IDMateria.ToString();
            this.ddl_anioCalendario.SelectedValue = cur.AnioCalendario.ToString();
           
           
            
        }


        private void DeleteEntity(int id)
        {
            this.Logic.Delete(id);
        }

        private void LoadEntity(AlumnoInscripcion aluInsc)
        {
 
           
            aluInsc.IDAlumno = UsuarioActual.ID_Persona;

            int anio_cal = Int32.Parse(this.ddl_anioCalendario.SelectedValue.ToString());

            int id_com = Int32.Parse(this.ddl_Comision.SelectedValue.ToString());

            int id_mat = Int32.Parse(this.ddl_Materia.SelectedValue.ToString());


            CursoLogic curLog = new CursoLogic();

            CursoActual = curLog.GetOne(id_com, id_mat, anio_cal);

            aluInsc.IDCurso = CursoActual.ID;
            aluInsc.DescCurso = CursoActual.Descripcion;
            aluInsc.Condicion = "Inscripto";






           

        }

        private void SaveEntity(AlumnoInscripcion aluInsc)
        {
            this.Logic.Save(aluInsc);
        }

        public bool Validar(int id_cur)
        {
            String error = "Se han encontrado los siguientes errores: <br /><br />";
            bool vof = true;

            int id_alumno = this.UsuarioActual.ID;


            AlumnoInscripcionLogic aluInscLogic = new AlumnoInscripcionLogic();
            AlumnoInscripcion aluInsc = new AlumnoInscripcion();

            aluInsc = aluInscLogic.GetOne(id_alumno, id_cur);

            Curso cur = new Curso();
            CursoLogic curLog = new CursoLogic();

            cur = curLog.GetOne(id_cur);

            int cant_alumnos = aluInscLogic.ContarAlumnosInscriptosACurso(cur);



            if (cur.ID == 0)
            {
                error = error + "No se encontró curso para materia, comisión y año especificado. <br />";
                vof = false;

            }

            else if (aluInsc.ID != 0)
            {
                error = error + "Ya se encuentra inscripto al curso. <br />";
                vof = false;
            }


            else if((cant_alumnos + 1) > cur.Cupo)
            {
                error = error + "El curso ya se encuentra completo. " + cant_alumnos +  "/" +cur.Cupo + " <br />";
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

        private void ClearForm()
        {

        }

        private void EnableForm(bool enable)
        {

            this.ddl_anioCalendario.Enabled = enable;
            this.ddl_Comision.Enabled = enable;
            this.ddl_Materia.Enabled = enable;
           
        }



        public Usuario UsuarioActual { get; set; }
        public Persona.TiposPersona TipoPersonaActual { get; set; }


        protected void dgv_InscripcionesACurso_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.SelectedID = (int)this.dgv_InscripcionesACurso.SelectedValue;

        }

        protected void btnActualizar_Click(object sender, EventArgs e)
        {
            int id_alumno = this.UsuarioActual.ID_Persona;
            int anio = Int32.Parse(ddl_anioCalendario.SelectedValue.ToString());
            this.dgv_InscripcionesACurso.DataSource = Logic.GetAllInscripcionesPorAlumno(id_alumno, anio);
            this.dgv_InscripcionesACurso.DataBind();
        }

        protected void lbNuevo_Click(object sender, EventArgs e)
        {
            this.formPanel.Visible = true;
            this.FormMode = FormModes.Alta;
            this.ClearForm();
            this.EnableForm(true);

        }

        protected void btnEditar2_Click(object sender, EventArgs e)
        {
            if (this.IsEntitySelected)
            {


                this.formPanel.Visible = true;
                this.FormMode = FormModes.Modificacion;
                this.LoadForm(this.SelectedID);

            }

        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            if (this.IsEntitySelected)
            {
                this.formPanel.Visible = true;
                this.FormMode = FormModes.Baja;
                this.EnableForm(false);
                this.LoadForm(this.SelectedID);
            }
        }

        protected void lbAceptar_Click(object sender, EventArgs e)
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
                    if (this.Validar(CursoActual.ID) == true)
                    {
                        this.SaveEntity(this.Entity);
                        this.LoadGrid();


                    }
                    break;
                case FormModes.Alta:
                    this.Entity = new AlumnoInscripcion();
                    this.LoadEntity(this.Entity);
                    if (this.Validar(CursoActual.ID) == true)
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

        protected void lbCancelar_Click(object sender, EventArgs e)
        {
            this.formPanel.Visible = false;
            this.LoadGrid();


        }
    }
}