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
    public partial class VerCursoPorDocente : Form
    {
        public VerCursoPorDocente(int ID)
        {
            InitializeComponent();

            CursoLogic curLog = new CursoLogic();

            CursoActual = curLog.GetOne(ID);
            txtCurso.Text = CursoActual.Descripcion;

            Listar();

        }

        public Curso CursoActual { get; set; }

        public AlumnoInscripcion InscripcionActual { get; set; }

        public void Listar()
        {
            List<AlumnoInscripcion> inscripciones = new List<AlumnoInscripcion>();
            AlumnoInscripcionLogic aiLog = new AlumnoInscripcionLogic();

            dgvVerInscripciones.DataSource = aiLog.GetAllAlumnosPorCurso(CursoActual.ID);
            
        }

        private void btnCargarNota_Click(object sender, EventArgs e)
        {
            try
            {

                int ID = ((AlumnoInscripcion)this.dgvVerInscripciones.SelectedRows[0].DataBoundItem).ID;

                DocenteInscripcionDesktop pDesk = new DocenteInscripcionDesktop(ID);
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
