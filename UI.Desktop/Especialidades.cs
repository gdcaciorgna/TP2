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
    public partial class Especialidades : Form
    {
        public Especialidades()
        {
            InitializeComponent();

        }

        public void Listar()
        {
            EspecialidadesLogic espLogic = new EspecialidadesLogic();
            this.dgvEspecialidades.DataSource = espLogic.GetAll();
        }

        private void Especialidades_Load(object sender, EventArgs e)
        {
            Listar();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            Listar();
        }

        private void tsbNuevo_Click(object sender, EventArgs e)
        {
            EspecialidadesDesktop espDesk = new EspecialidadesDesktop(ApplicationForm.ModoForm.Alta);
            espDesk.ShowDialog();
            this.Listar();
        }

        private void tsbEditar_Click(object sender, EventArgs e)
        {
            try
            {

                int ID = ((Especialidad)this.dgvEspecialidades.SelectedRows[0].DataBoundItem).ID;

                EspecialidadesDesktop espDesk = new EspecialidadesDesktop(ID, ApplicationForm.ModoForm.Modificacion);

                espDesk.ShowDialog();
                this.Listar();
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void tsbEliminar_Click(object sender, EventArgs e)
        {
            try
            {

                int ID = ((Especialidad)this.dgvEspecialidades.SelectedRows[0].DataBoundItem).ID;

                EspecialidadesDesktop espDesk = new EspecialidadesDesktop(ID, ApplicationForm.ModoForm.Baja);

                espDesk.ShowDialog();
                this.Listar();
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
    }
}
