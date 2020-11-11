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
    public partial class DocenteCurso : Form
    {
        public DocenteCurso()
        {
            InitializeComponent();
            dgvDocentes.AutoGenerateColumns = false;
        }

        public void Listar() 
        {

            CursoLogic curLog = new CursoLogic();
            Curso cur = new Curso();

            List<Curso> cursos = new List<Curso>();

            cursos = curLog.GetAll();

            cbCursos.DataSource = cursos;
            cbCursos.DisplayMember = "Descripcion";
            cbCursos.ValueMember = "ID";



           DocenteCursoLogic docCur = new DocenteCursoLogic();
           List<Business.Entities.DocenteCurso> docenteCursos = new List<Business.Entities.DocenteCurso>();

            docenteCursos = docCur.GetAllDocentesCursos();
            this.dgvDocentes.DataSource = docenteCursos;



        }

       
        private void DocenteCurso_Load(object sender, EventArgs e)
        {
            Listar();
        }

        private void Filtrar_Click(object sender, EventArgs e)
        {

            Curso cur = new Curso();
            string idstring = this.cbCursos.SelectedValue.ToString();
            
            cur.ID = Int32.Parse(idstring);


            DocenteCursoLogic docCur = new DocenteCursoLogic();
            List<Business.Entities.DocenteCurso> docenteCursos = new List<Business.Entities.DocenteCurso>();


            docenteCursos = docCur.GetAllDocentesPorCurso(cur.ID);
            this.dgvDocentes.DataSource = docenteCursos;
        }

        private void tsbNuevo_Click(object sender, EventArgs e)
        {
            DocenteCursoDesktop docdesk = new DocenteCursoDesktop(ApplicationForm.ModoForm.Alta);
            docdesk.ShowDialog();
            this.Listar();
        }

        private void tspEditar_Click(object sender, EventArgs e)
        {
            int ID = ((Business.Entities.DocenteCurso)this.dgvDocentes.SelectedRows[0].DataBoundItem).ID;

            DocenteCursoDesktop docdesk = new DocenteCursoDesktop(ID , ApplicationForm.ModoForm.Modificacion);
            docdesk.ShowDialog();
            this.Listar();
        }

        private void tsbEliminar_Click(object sender, EventArgs e)
        {
            int ID = ((Business.Entities.DocenteCurso)this.dgvDocentes.SelectedRows[0].DataBoundItem).ID;
            DocenteCursoDesktop docdesk = new DocenteCursoDesktop(ID, ApplicationForm.ModoForm.Baja);
            docdesk.ShowDialog();
            this.Listar();
        }
    }
}
