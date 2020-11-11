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
    public partial class NotasAlumnos : Form
    {
        public NotasAlumnos()
        {
            InitializeComponent();
        }

        private void NotasAlumnos_Load(object sender, EventArgs e)
        {
            PersonaLogic perlog = new PersonaLogic();
            List<Persona> per = new List<Persona>();
            per = perlog.GetAllTipo(Persona.TiposPersona.Alumno);

            this.cbAlumno.DataSource = per;
            this.cbAlumno.DisplayMember = "Apellido";
            this.cbAlumno.ValueMember = "ID";
            

            AlumnoActual = (Persona)this.cbAlumno.SelectedItem;


            this.reportViewer1.RefreshReport();
        }

        public Persona AlumnoActual { get; set; }

        private void reportViewer1_Load(object sender, EventArgs e)
        {
            try
            {
                this.reportViewer1.LocalReport.ReportEmbeddedResource = "UI.Desktop.Report2.rdlc";


            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            AlumnoActual = (Persona)this.cbAlumno.SelectedItem;

            if (AlumnoActual != null)
            {
                List<AlumnoInscripcion> alumins = new List<AlumnoInscripcion>();
                AlumnoInscripcionLogic aluminslog = new AlumnoInscripcionLogic();

                alumins = aluminslog.GetAllInscripcionesPorAlumno(AlumnoActual.ID);


                this.reportViewer1.LocalReport.ReportEmbeddedResource = "UI.Desktop.Report2.rdlc";
                ReportDataSource rdlc2 = new ReportDataSource("DataSet1", alumins);
                this.reportViewer1.LocalReport.DataSources.Clear();
                this.reportViewer1.LocalReport.DataSources.Add(rdlc2);
                this.reportViewer1.RefreshReport();
            }

        }
    }
}
