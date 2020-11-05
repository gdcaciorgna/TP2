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
using System.Data;

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

            this.reportViewer1.RefreshReport();
        }

        private void reportViewer1_Load(object sender, EventArgs e)
        {
            try
            {
                List<Curso> cur = new List<Curso>();
                CursoLogic cursos = new CursoLogic();

                cur = cursos.GetAll();

                this.reportViewer1.LocalReport.ReportEmbeddedResource = "UI.Desktop.Report1.rdlc";
                ReportDataSource rdlc = new ReportDataSource("DataSet3", cur);
                this.reportViewer1.LocalReport.DataSources.Clear();
                this.reportViewer1.LocalReport.DataSources.Add(rdlc);
                this.reportViewer1.RefreshReport();

            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

           
        }
    }
}
