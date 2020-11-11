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
    public partial class VerCursosDocente : ApplicationForm
    {
        public VerCursosDocente()
        {
            InitializeComponent();

            this.dgvCursos.AutoGenerateColumns = false;

            List<Persona> docentes = new List<Persona>();
            PersonaLogic perLog = new PersonaLogic();

            docentes = perLog.GetAllTipo(Persona.TiposPersona.Docente);

            
            int id_per = Usuario.UsuarioActual.ID_Persona;
            DocenteActual = perLog.GetOne(id_per);

            string apellidoNombre = DocenteActual.Apellido + ", " + DocenteActual.Nombre;

            txtDocente.Text = apellidoNombre;


            Listar();

        }

     

        public void Listar()
        {
            
            DocenteCursoLogic docCurLog = new DocenteCursoLogic();
            List<Curso> cursos = new List<Curso>();
            try
            {

                cursos = docCurLog.GetAll(DocenteActual.ID);
                this.dgvCursos.DataSource = cursos;

            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            

            
        }

        public AlumnoInscripcionLogic Logic { get; set; }
        public Persona  DocenteActual { get; set; }

        private void btnVerCurso_Click(object sender, EventArgs e)
        {
            try
            {

                int ID = ((Curso)this.dgvCursos.SelectedRows[0].DataBoundItem).ID;

                VerCursoPorDocente pDesk = new VerCursoPorDocente(ID);
                pDesk.ShowDialog();
                this.Listar();
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
