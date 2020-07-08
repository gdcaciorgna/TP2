using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


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
    }
}
