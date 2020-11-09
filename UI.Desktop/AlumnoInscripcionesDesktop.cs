using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Business.Entities;
using Business.Logic;

namespace UI.Desktop
{
    public partial class AlumnoInscripcionesDesktop : ApplicationForm
    {
        public AlumnoInscripcionesDesktop()
        {
            InitializeComponent();
        }

        public AlumnoInscripcionesDesktop(ModoForm modo) : this()
        {
            this.Modo = modo;

        }

        public AlumnoInscripcionesDesktop(int ID, ModoForm modo) : this()
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
                if (this.Validar())
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


        public override bool Validar()
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
            

                

                else if (AlumnoInscripcionActual.ID != 0)
                {
                    error = error + "Ya se encuentra inscripto al curso. \n";
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
            CursoLogic curLog = new CursoLogic();

            MateriaLogic matLog = new MateriaLogic();
            ComisionLogic comLog = new ComisionLogic();

            Materia mat = new Materia();
            Comision com = new Comision();


            cur = curLog.GetOne(AlumnoInscripcionActual.IDCurso);



            mat = matLog.GetOne(cur.IDMateria);
            com = comLog.GetOne(cur.IDComision);
            int anio = cur.AnioCalendario;

            this.cmbAnioCalendario.SelectedItem = anio;
            this.cmbMateria.SelectedItem = mat;
            this.cmbComision.SelectedItem = com;


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


            AlumnoInscripcionActual.IDAlumno = Usuario.UsuarioActual.ID_Persona;
            AlumnoInscripcionActual.IDCurso = CursoActual.ID;
            AlumnoInscripcionActual.Condicion = "Inscripto";


        }

        public void LoadForm()
        {
            Materia mat = new Materia();
            Comision com = new Comision();

            com = (Comision)cmbComision.SelectedItem;
            mat = (Materia)cmbMateria.SelectedItem;
            int anio = Int32.Parse(cmbAnioCalendario.SelectedItem.ToString());


            CursoLogic curLog = new CursoLogic();

            CursoActual = curLog.GetOne(com.ID, mat.ID, anio);

            AlumnoInscripcionLogic alInscLogic = new AlumnoInscripcionLogic();

            AlumnoInscripcionActual = alInscLogic.GetOne(Usuario.UsuarioActual.ID_Persona, CursoActual.ID);
            

        }

        private void AlumnoInscripcionesDesktop_Load(object sender, EventArgs e)
        {
            MateriaLogic matLog = new MateriaLogic();
            ComisionLogic comLog = new ComisionLogic();
            CursoLogic curLog = new CursoLogic();

            List<Materia> materias = new List<Materia>();
            List<Comision> comisiones = new List<Comision>();
            List<int> anios = new List<int>();

            anios = curLog.GetAllAnios();
            materias = matLog.GetAll();
            comisiones = comLog.GetAll();


            cmbAnioCalendario.DataSource = anios;

            cmbComision.DataSource = comisiones;
            cmbComision.ValueMember = "ID";
            cmbComision.DisplayMember = "Descripcion";


            cmbMateria.DataSource = materias;
            cmbMateria.ValueMember = "ID";
            cmbMateria.DisplayMember = "Descripcion";

        }
    }
}
