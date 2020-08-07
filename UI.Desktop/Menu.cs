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
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void btnUsuario_Click(object sender, EventArgs e)
        {
            Usuarios usuarios = new Usuarios();
            this.Hide();
            usuarios.ShowDialog();
            this.Show();
        }

        private void btnEspecialidad_Click(object sender, EventArgs e)
        {
            Especialidades especialidades = new Especialidades();
            this.Hide();
            especialidades.ShowDialog();
            this.Show();
        }

        private void btnPlan_Click(object sender, EventArgs e)
        {
            Planes formPlan = new Planes();
            this.Hide();
            formPlan.ShowDialog();
            this.Show();
        }

        private void Menu_Load(object sender, EventArgs e)
        {
            UsuarioLogic usuLog = new UsuarioLogic();
            int tipo_per = usuLog.GetTipoPersona(Usuario.UsuarioActual);
            
            switch (tipo_per)
            {
                case 1:
                     //pnlAdmin.Visible = true;
                    break;
                case 2:
                    //pnlProf.Visible = true;
                    break;
                case 3:
                    //pnlAlum.Visible = true;
                    break;
            }

        }

        private void nuevoAlumnoToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void nuevaEspecialidadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EspecialidadesDesktop formEsp = new EspecialidadesDesktop();
            formEsp.ShowDialog();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void verEspecialidadesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Especialidades formEsp = new Especialidades();
            formEsp.ShowDialog();

        }

        private void nuevoPlanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PlanesDesktop frmPlan = new PlanesDesktop();
            frmPlan.ShowDialog();

        }

        private void verPlanesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Planes frmPlan = new Planes();
            frmPlan.ShowDialog();

        }

        private void crearUsuarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UsuarioDesktop usuDesk = new UsuarioDesktop();
            usuDesk.ShowDialog();
        }

        private void verUsuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Usuarios usuDesk = new Usuarios();
            usuDesk.ShowDialog();
        }

        private void nuevaPersonaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PersonasDesktop perDesk = new PersonasDesktop();
            perDesk.ShowDialog();
        }

        private void verPersonasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Personas per = new Personas();
            per.ShowDialog();
        }
    }
}
