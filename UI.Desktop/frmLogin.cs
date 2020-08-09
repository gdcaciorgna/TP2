using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Util;
using Business.Logic;
using Business.Entities;

namespace UI.Desktop
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (Validaciones.ControlaCampos(txtUsuario.Text) == true && Validaciones.ControlaCampos(txtPassword.Text))
            {

                Usuario usr = new Usuario();
                UsuarioLogic usLog = new UsuarioLogic();
                usr = usLog.GetUsuarioxUsrNombre(txtUsuario.Text);

                Usuario.UsuarioActual = usr;

                if (Validaciones.ControlaClave(txtPassword.Text, usr.Clave) == true)
                {
                    Menu menu = new Menu();
                    this.Hide();
                    menu.ShowDialog();
                    txtPassword.Text = null;
                    txtUsuario.Text = null;
                }
                else MessageBox.Show("Usuario y/o contraseña incorrectos");
            }
            else MessageBox.Show("Campos vacíos");
        }
    }
}
