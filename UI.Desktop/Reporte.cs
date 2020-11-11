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
using Microsoft.Reporting.WinForms;



namespace UI.Desktop
{
    public partial class Reporte : Form
    {
        public Reporte()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            CursoLogic curlog = new CursoLogic();
            List<Curso> cur = new List<Curso>();
            cur = curlog.GetAll();

            this.cbCurso.DataSource = cur;
            this.cbCurso.DisplayMember = "Descripcion";
            this.cbCurso.ValueMember = "ID";

            CursoActual = (Curso)this.cbCurso.SelectedItem;
            DateTime fechaHoy = new DateTime().Date;

        }

        public Curso CursoActual { get; set; }

        private void reportViewer1_Load(object sender, EventArgs e)
        {
            try
            {
                
                this.reportViewer1.LocalReport.ReportEmbeddedResource = "UI.Desktop.Report1.rdlc";


            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

           
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            CursoActual = (Curso)this.cbCurso.SelectedItem;

            if (CursoActual != null)
            {
                List<AlumnoInscripcion> alumins = new List<AlumnoInscripcion>();
                AlumnoInscripcionLogic aluminslog = new AlumnoInscripcionLogic();

                alumins = aluminslog.GetAllAlumnosPorCurso(CursoActual.ID);


                this.reportViewer1.LocalReport.ReportEmbeddedResource = "UI.Desktop.Report1.rdlc";
                ReportDataSource rdlc1 = new ReportDataSource("DataSet1", alumins);
                this.reportViewer1.LocalReport.DataSources.Clear();
                this.reportViewer1.LocalReport.DataSources.Add(rdlc1);
                this.reportViewer1.RefreshReport();
            }

        }
    }
}
