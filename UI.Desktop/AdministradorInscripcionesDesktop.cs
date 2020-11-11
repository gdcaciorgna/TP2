using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Business.Logic;
using Business.Entities;


namespace UI.Desktop
{
    public partial class AdministradorInscripcionesDesktop : ApplicationForm
    {
        public AdministradorInscripcionesDesktop()
        {
            InitializeComponent();

            PersonaLogic perLog = new PersonaLogic();
            MateriaLogic matLog = new MateriaLogic();
            ComisionLogic comLog = new ComisionLogic();
            CursoLogic curLog = new CursoLogic();


            List<Persona> personas = new List<Persona>();
            List<Materia> materias = new List<Materia>();
            List<Comision> comisiones = new List<Comision>();
            List<int> anios = new List<int>();


            anios = curLog.GetAllAnios();
            materias = matLog.GetAll();
            comisiones = comLog.GetAll();


            personas = perLog.GetAllTipo(Persona.TiposPersona.Alumno);


            DataTable dt = new DataTable();
            dt = Util.FuncionesComunes.ConvertToDataTable(personas);
            dt.Columns.Add(new DataColumn("NombreApellidoLegajo", System.Type.GetType("System.String"), "Apellido + ' ' + Nombre + ' - ' + Legajo"));

            cmbAlumno.DataSource = dt;

            cmbAlumno.ValueMember = "ID";
            cmbAlumno.DisplayMember = "NombreApellidoLegajo";


            cmbAnioCalendario.DataSource = anios;

            cmbComision.DataSource = comisiones;
            cmbComision.ValueMember = "ID";
            cmbComision.DisplayMember = "Descripcion";


            cmbMateria.DataSource = materias;
            cmbMateria.ValueMember = "ID";
            cmbMateria.DisplayMember = "Descripcion";
        }

        public AdministradorInscripcionesDesktop(ModoForm modo)
        {
            this.Modo = modo;

        }

        public AdministradorInscripcionesDesktop(int ID, ModoForm modo) : this()
        {
            this.Modo = modo;
            AlumnoInscripcionLogic aiLogic = new AlumnoInscripcionLogic();
            AlumnoInscripcion alInsc = aiLogic.GetOne(ID);
            AlumnoInscripcionActual = alInsc; //Revisar si es correcto (PASO 12)
            this.MapearDeDatos();
        }


        public AlumnoInscripcion AlumnoInscripcionActual { get; set; }

        public Curso CursoActual { get; set; }


        private void btnAceptar_Click(object sender, EventArgs e)
        {
            LoadForm();

            if (this.Modo == ModoForm.Alta || this.Modo == ModoForm.Modificacion)
            {
                if (this.Validar(this.Modo))
                {
                    this.GuardarCambios();
                    this.Close();
                }
            }
            else if (this.Modo == ModoForm.Baja)
            {
                this.GuardarCambios();
                this.Close();
            }


        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        public override bool Validar(ModoForm modo)
        {


            String error = "Se han encontrado los siguientes errores: \n\n";
            bool vof = true;


            CursoLogic curLog = new CursoLogic();

            AlumnoInscripcionLogic aluInscLog = new AlumnoInscripcionLogic();

            int cant_alumnos = aluInscLog.ContarAlumnosInscriptosACurso(CursoActual);

                
            if (CursoActual.ID == 0)
            {
                vof = false;
                error = error + "No se encontró curso para materia, comisión y año especificado \n";

            }

            else if ((cant_alumnos + 1) > CursoActual.Cupo)
            {
                error = error + "El curso ya se encuentra completo. " + cant_alumnos + "/" + CursoActual.Cupo + "\n";
                vof = false;

            }

            if(modo == ModoForm.Alta)
            {
                if (AlumnoInscripcionActual.ID != 0)
                {
                    error = error + "Este alumno ya se encuentra inscripto al curso. \n";
                    vof = false;
                }

            }


            
            else if(txtCondicion.Text == "")
            {
                error = error + "El campo condición no puede estar vacío \n";
                vof = false;
            }



            if (vof == true)
            {
                return true;
            }

            else
            {
                this.Notificar("Error", error, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        public override void GuardarCambios()
        {
            this.MapearADatos();
            AlumnoInscripcionLogic alInscLog = new AlumnoInscripcionLogic();
            alInscLog.Save(AlumnoInscripcionActual);
        }

        public override void MapearDeDatos()
        {
            

            Curso cur = new Curso();
           
            Materia mat = new Materia();
            Comision com = new Comision();
            Persona per = new Persona();



            CursoLogic curLog = new CursoLogic();
            MateriaLogic matLog = new MateriaLogic();
            ComisionLogic comLog = new ComisionLogic();
            PersonaLogic perLog = new PersonaLogic();


            cur = curLog.GetOne(AlumnoInscripcionActual.IDCurso);


            per = perLog.GetOne(AlumnoInscripcionActual.IDAlumno);
            mat = matLog.GetOne(cur.IDMateria);
            com = comLog.GetOne(cur.IDComision);
            int anio = cur.AnioCalendario;

            this.cmbAnioCalendario.SelectedItem = anio;
            this.cmbMateria.SelectedValue = mat.ID;
            this.cmbComision.SelectedValue = com.ID;
            this.cmbAlumno.SelectedValue = per.ID;
            this.txtCondicion.Text = AlumnoInscripcionActual.Condicion;
            this.txtNota.Text = AlumnoInscripcionActual.Nota.ToString();


            if (this.Modo == ModoForm.Alta || this.Modo == ModoForm.Modificacion)
            {

                this.btnAceptar.Text = "Guardar";
            }


            if (this.Modo == ModoForm.Baja)
            {
                this.btnAceptar.Text = "Eliminar";
            }

            if (this.Modo == ModoForm.Consulta)
            {
                this.btnAceptar.Text = "Aceptar";
            }
        }

        public override void MapearADatos()
        {


            if (this.Modo == ModoForm.Alta || this.Modo == ModoForm.Modificacion)
            {
                AlumnoInscripcionActual.State = BusinessEntity.States.New;

                if (this.Modo == ModoForm.Modificacion)
                {
                    AlumnoInscripcionActual.State = BusinessEntity.States.Modified;
                }

            }


            if (this.Modo == ModoForm.Baja)
            {
                AlumnoInscripcionActual.State = BusinessEntity.States.Deleted;
            }


            Persona al = new Persona();
            al.ID = Int32.Parse(this.cmbAlumno.SelectedValue.ToString());

            AlumnoInscripcionActual.IDAlumno = al.ID;           
            AlumnoInscripcionActual.IDCurso = CursoActual.ID;

            if(this.txtNota.Text != "")
            {
                AlumnoInscripcionActual.Nota = Int32.Parse(this.txtNota.Text);
            }

            if (this.txtCondicion.Text == "")
            {
                AlumnoInscripcionActual.Condicion = "Inscripto";
            }



        }

        public void LoadForm()
        {
            Materia mat = new Materia();
            Comision com = new Comision();

            com = (Comision)cmbComision.SelectedItem;
            mat = (Materia)cmbMateria.SelectedItem;
            int anio = Int32.Parse(cmbAnioCalendario.SelectedItem.ToString());

            int id_per = Int32.Parse(cmbAlumno.SelectedValue.ToString());


            CursoLogic curLog = new CursoLogic();

            CursoActual = curLog.GetOne(com.ID, mat.ID, anio);

            AlumnoInscripcionLogic alInscLogic = new AlumnoInscripcionLogic();

            AlumnoInscripcionActual = alInscLogic.GetOne(id_per, CursoActual.ID);


        }

        private void AdministradorInscripcionesDesktop_Load(object sender, EventArgs e)
        {
           


        }
    }
}
