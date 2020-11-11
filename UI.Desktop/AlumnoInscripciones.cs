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
    public partial class AlumnoInscripciones : Form
    {
        public AlumnoInscripciones()
        {
            InitializeComponent();
            dgv_Inscripciones.AutoGenerateColumns = false;
        }


        public void Listar()
        {
            AlumnoInscripcionLogic al = new AlumnoInscripcionLogic();
            List<AlumnoInscripcion> alInsc = new List<AlumnoInscripcion>();
            try
            {

                int anio_sel = Int32.Parse(this.cmb_anio.SelectedItem.ToString());
              
                alInsc = al.GetAllInscripcionesPorAlumno(Usuario.UsuarioActual.ID_Persona, anio_sel);
                this.dgv_Inscripciones.DataSource = alInsc; 
               
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            AlumnoInscripcionesDesktop aluInsDesk = new AlumnoInscripcionesDesktop();
            aluInsDesk.ShowDialog();
            this.Listar();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            try
            {

                int ID = ((AlumnoInscripcion)this.dgv_Inscripciones.SelectedRows[0].DataBoundItem).ID;

                AlumnoInscripcionesDesktop aluInskDesk = new AlumnoInscripcionesDesktop(ID, ApplicationForm.ModoForm.Modificacion);

                aluInskDesk.ShowDialog();
                this.Listar();
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {

                int ID = ((AlumnoInscripcion)this.dgv_Inscripciones.SelectedRows[0].DataBoundItem).ID;

                AlumnoInscripcionesDesktop aluInsDesk = new AlumnoInscripcionesDesktop(ID, ApplicationForm.ModoForm.Baja);

                aluInsDesk.ShowDialog();
                this.Listar();
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void AlumnoInscripciones_Load(object sender, EventArgs e)
        {
            UsuarioLogic usuLog = new UsuarioLogic();
            int id_alumno = Usuario.UsuarioActual.ID_Persona;
            int anio_calendario = DateTime.Now.Year;

            PersonaLogic perLog = new PersonaLogic();
            Persona alumno = new Persona();

            List<Persona> alumnos = new List<Persona>();

            alumnos = perLog.GetAll();

            cmb_alumnos.DataSource = alumnos;
            cmb_alumnos.DisplayMember = "Apellido";
            cmb_alumnos.ValueMember = "ID";





            CursoLogic curLog = new CursoLogic();

            List<int> anios = new List<int>();
            anios = curLog.GetAllAnios();

            cmb_anio.DataSource = anios;


            alumno = perLog.GetOne(id_alumno);
            int anio = DateTime.Now.Year;


            cmb_alumnos.SelectedItem = alumno;
            cmb_alumnos.SelectedItem = anio;

            Listar();


        }

        public AlumnoInscripcionLogic Logic { get; set; }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            Listar();
        }
    }
}
