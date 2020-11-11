using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Business.Entities;
using Business.Logic;
using Microsoft.Reporting.WebForms;
using System.Data;

namespace UI.Web
{
    public partial class PlanillaDeAsistencias : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void Panel4_Load(object sender, EventArgs e)
        {
            CursoLogic curlog = new CursoLogic();
            List<Curso> cur = new List<Curso>();
            cur = curlog.GetAll();

            ddlCurso.DataSource = cur;
            ddlCurso.DataTextField = "Descripcion";
            ddlCurso.DataValueField = "ID";

            DateTime fechaHoy = new DateTime().Date;
        }
        public Curso CursoActual { get; set; }

 

        protected void ReportViewer1_Load1(object sender, EventArgs e)
        {
                this.ReportViewer1.LocalReport.ReportEmbeddedResource = "~/PlanillaAsistencias.rdlc";
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            CursoLogic cursologic = new CursoLogic();

            int id = Int32.Parse(ddlCurso.SelectedValue);
            CursoActual = cursologic.GetOne(id);
            if (CursoActual != null)
            {
                List<AlumnoInscripcion> alumins = new List<AlumnoInscripcion>();
                AlumnoInscripcionLogic aluminslog = new AlumnoInscripcionLogic();

                alumins = aluminslog.GetAllAlumnosPorCurso(CursoActual.ID);


                this.ReportViewer1.LocalReport.ReportEmbeddedResource = "~/PlanillaAsistencias.rdlc";
                ReportDataSource rdlc2 = new ReportDataSource("DataSet1", alumins);
                this.ReportViewer1.LocalReport.DataSources.Clear();
                this.ReportViewer1.LocalReport.DataSources.Add(rdlc2);
               
            }

        }
    }

}