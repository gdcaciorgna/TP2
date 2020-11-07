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

        private void btnAceptar_Click(object sender, EventArgs e)
        {
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


            Curso cur = new Curso();
            CursoLogic curLog = new CursoLogic();

            AlumnoInscripcionLogic aluInscLog = new AlumnoInscripcionLogic();
            AlumnoInscripcion aluInsc = new AlumnoInscripcion();


            try {


                cur = curLog.GetOne(AlumnoInscripcionActual.IDCurso);
                int cant_alumnos = aluInscLog.ContarAlumnosInscriptosACurso(cur);

                aluInsc = aluInscLog.GetOne(AlumnoInscripcionActual.IDAlumno, AlumnoInscripcionActual.IDCurso);



                if ((cant_alumnos + 1) > cur.Cupo)
                {
                    error = error + "El curso ya se encuentra completo. " + cant_alumnos + "/" + cur.Cupo + " <br />";
                    vof = false;
                    
                }

                else if (aluInsc.ID != 0)
                {
                    error = error + "Ya se encuentra inscripto al curso. <br />";
                    vof = false;
                }



            }
            catch (Exception e) 
            {
                vof = false;
                error = error + "No se encontró curso para materia, comisión y año especificado";
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

            if (this.Modo == ModoForm.Alta)
            {
                AlumnoInscripcion alInsc = new AlumnoInscripcion();
                AlumnoInscripcionActual = alInsc;

            }

            if (this.Modo == ModoForm.Alta || this.Modo == ModoForm.Modificacion)
            {
                AlumnoInscripcionActual.State = BusinessEntity.States.New;

                if (this.Modo == ModoForm.Modificacion)
                {
                    AlumnoInscripcionActual.State = BusinessEntity.States.Modified;
                }



                Materia mat = new Materia();
                Comision com = new Comision();

                com = (Comision) cmbComision.SelectedItem;
                mat = (Materia) cmbMateria.SelectedItem;
                int anio = Int32.Parse(cmbAnioCalendario.SelectedItem.ToString());
               

                Curso cur = new Curso();
                CursoLogic curLog = new CursoLogic();

                cur = curLog.GetOne(com.ID, mat.ID, anio);


                AlumnoInscripcionActual.IDAlumno = Usuario.UsuarioActual.ID_Persona;
                AlumnoInscripcionActual.IDCurso = cur.ID;

                
            }

            if (this.Modo == ModoForm.Baja)
            {
                AlumnoInscripcionActual.State = BusinessEntity.States.Deleted;
            }


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
