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
using Business.Entities;


namespace UI.Desktop
{
    public partial class Personas : Form
    {
        public Personas()
        {
            InitializeComponent();
            this.dgvPersonas.AutoGenerateColumns = false;

        }

        public void Listar()
        {
            PersonaLogic ul = new PersonaLogic();

            try
            {
                this.dgvPersonas.DataSource = ul.GetAll();
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Personas_Load(object sender, EventArgs e)
        {
            Listar();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            Listar();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tsbNuevo_Click(object sender, EventArgs e)
        {
            PersonasDesktop perDesk = new PersonasDesktop(ApplicationForm.ModoForm.Alta);
            perDesk.ShowDialog();
        }

        private void tsbEditar_Click(object sender, EventArgs e)
        {

        }

        private void tsbEliminar_Click(object sender, EventArgs e)
        {

        }

        private void tsbEditar_Click_1(object sender, EventArgs e)
        {
            try
            {

                int ID = ((Persona)this.dgvPersonas.SelectedRows[0].DataBoundItem).ID;

                PersonasDesktop perDesk = new PersonasDesktop(ID, ApplicationForm.ModoForm.Modificacion);
                perDesk.ShowDialog();
                this.Listar();
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void tsbEliminar_Click_1(object sender, EventArgs e)
        {
            try
            {

                int ID = ((Persona)this.dgvPersonas.SelectedRows[0].DataBoundItem).ID;

                PersonasDesktop perDesk = new PersonasDesktop(ID, ApplicationForm.ModoForm.Baja);

                perDesk.ShowDialog();
                this.Listar();
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
    }
}
