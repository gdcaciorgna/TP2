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
    public partial class Usuarios : Form
    {
        public Usuarios()
        {
            InitializeComponent();
            this.dgvUsuarios.AutoGenerateColumns = false;
        }

        public void Listar()
        {
            UsuarioLogic ul = new UsuarioLogic();

            try
            {
                this.dgvUsuarios.DataSource = ul.GetAll();
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Usuarios_Load(object sender, EventArgs e)
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
            UsuarioDesktop usuDesk = new UsuarioDesktop(ApplicationForm.ModoForm.Alta);
            usuDesk.ShowDialog(); 
            this.Listar();

        }

        private void tsbEditar_Click(object sender, EventArgs e)
        {
            try
            {

                int ID = ((Usuario)this.dgvUsuarios.SelectedRows[0].DataBoundItem).ID;

                UsuarioDesktop usuDesk = new UsuarioDesktop(ID, ApplicationForm.ModoForm.Modificacion);

                usuDesk.ShowDialog();
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

                int ID = ((Usuario)this.dgvUsuarios.SelectedRows[0].DataBoundItem).ID;

                UsuarioDesktop usuDesk = new UsuarioDesktop(ID, ApplicationForm.ModoForm.Baja);

                usuDesk.ShowDialog();
                this.Listar();
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            
        }
    }
}
