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
    public partial class Planes : Form
    {
        public Planes()
        {
            InitializeComponent();
        }

        public void Listar()
        {
            PlanesLogic pl = new PlanesLogic();

            try
            {
                this.dgvPlanes.DataSource = pl.GetAll();
            }
            catch (Exception Ex)
            {
                MessageBox.Show("Error al recuperar lista de planes", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Planes_Load(object sender, EventArgs e)
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
            PlanesDesktop pDesk = new PlanesDesktop(ApplicationForm.ModoForm.Alta);
            pDesk.ShowDialog();
            this.Listar();
        }

        private void tbsNew_Click(object sender, EventArgs e)
        {
            PlanesDesktop pDesk = new PlanesDesktop(ApplicationForm.ModoForm.Alta);
            pDesk.ShowDialog();
            this.Listar();

        }

        private void tsbEditar_Click(object sender, EventArgs e)
        {
            try
            {

                int ID = ((Plan)this.dgvPlanes.SelectedRows[0].DataBoundItem).ID;

                PlanesDesktop pDesk = new PlanesDesktop(ID, ApplicationForm.ModoForm.Modificacion);

                pDesk.ShowDialog();
                this.Listar();
            }
            catch (Exception Ex)
            {
                MessageBox.Show("Error al recuperar datos del usuario", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void tsbEliminar_Click(object sender, EventArgs e)
        {
              try
                {

                int ID = ((Plan)this.dgvPlanes.SelectedRows[0].DataBoundItem).ID;

                PlanesDesktop pDesk = new PlanesDesktop(ID, ApplicationForm.ModoForm.Baja);

                pDesk.ShowDialog();
                this.Listar();
            }
            catch (Exception Ex)
            {
                MessageBox.Show("Error al eliminar plan", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
