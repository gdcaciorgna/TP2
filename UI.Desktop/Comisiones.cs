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
    public partial class Comisiones : Form
    {
        public Comisiones()
        {
            InitializeComponent();
            dgvComision.AutoGenerateColumns = false;
        }



        public void Listar()
        {
            ComisionLogic ul = new ComisionLogic();

            try
            {
                this.dgvComision.DataSource = ul.GetAll();
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }

        private void Comisiones_Load(object sender, EventArgs e)
        {
            Listar();
        }

        private void bntActualizar_Click(object sender, EventArgs e)
        {
            Listar();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAgregarComision_Click(object sender, EventArgs e)
        {
            ComisionesDesktop comDesk = new ComisionesDesktop(ApplicationForm.ModoForm.Alta);
            comDesk.ShowDialog();
            this.Listar();
        }

        private void btnEditarComision_Click(object sender, EventArgs e)
        {
            try
            {

                int ID = ((Comision)this.dgvComision.SelectedRows[0].DataBoundItem).ID;

                ComisionesDesktop cDesk = new ComisionesDesktop(ID, ApplicationForm.ModoForm.Modificacion);

                cDesk.ShowDialog();
                this.Listar();
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }
        private void btnEliminarComision_Click(object sender, EventArgs e)
        {
            try
            {

                int ID = ((Comision)this.dgvComision.SelectedRows[0].DataBoundItem).ID;

                ComisionesDesktop cDesk = new ComisionesDesktop(ID, ApplicationForm.ModoForm.Baja);

                cDesk.ShowDialog();
                this.Listar();
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }
    }
}
