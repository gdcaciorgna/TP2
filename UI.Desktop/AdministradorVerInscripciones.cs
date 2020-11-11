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
    public partial class AdministradorVerInscripciones : Form
    {
        public AdministradorVerInscripciones()
        {
            InitializeComponent();
            this.dgvInscripciones.AutoGenerateColumns = false;

            List<Curso> cursos = new List<Curso>();
            CursoLogic curLog = new CursoLogic();

            cursos = curLog.GetAll();

            this.cbCursos.DataSource = cursos;
            this.cbCursos.DisplayMember = "Descripcion";
            this.cbCursos.ValueMember = "ID";

            Listar();
        }


        public void Listar()
        {
            



            AlumnoInscripcionLogic al = new AlumnoInscripcionLogic();
            List<AlumnoInscripcion> alInsc = new List<AlumnoInscripcion>();
            try
            {

                CursoActual = (Curso)this.cbCursos.SelectedItem;


                if (CursoActual != null)
                {

                    alInsc = al.GetAllAlumnosPorCurso(CursoActual.ID);
                    this.dgvInscripciones.DataSource = alInsc;
                    

                }


            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public AlumnoInscripcionLogic Logic { get; set; }
        public Curso CursoActual { get; set; }

        private void tsNuevo_Click(object sender, EventArgs e)
        {
            AdministradorInscripcionesDesktop desk = new AdministradorInscripcionesDesktop();
            desk.ShowDialog();
            this.Listar();
        }

        private void tsEditar_Click(object sender, EventArgs e)
        {
            try
            {

                int ID = ((AlumnoInscripcion)this.dgvInscripciones.SelectedRows[0].DataBoundItem).ID;

                AdministradorInscripcionesDesktop aluInskDesk = new AdministradorInscripcionesDesktop(ID, ApplicationForm.ModoForm.Modificacion);

                aluInskDesk.ShowDialog();
                this.Listar();
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void tsEliminar_Click(object sender, EventArgs e)
        {
            try
            {

                int ID = ((AlumnoInscripcion)this.dgvInscripciones.SelectedRows[0].DataBoundItem).ID;

                AdministradorInscripcionesDesktop aluInsDesk = new AdministradorInscripcionesDesktop(ID, ApplicationForm.ModoForm.Baja);

                aluInsDesk.ShowDialog();
                this.Listar();
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnFiltrar_Click(object sender, EventArgs e)
        {
            Listar();
        }
    }
}
