using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Business.Entities;
using Business.Logic;

namespace UI.Web
{
    public partial class Home : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            UsuarioLogic usuLog = new UsuarioLogic();
            int tipo_per = usuLog.GetTipoPersona(Usuario.UsuarioActual);

            Usuario usuario = (Usuario) (Session["UsuarioActual"]);

            Persona.TiposPersona tipoUsuario = (Persona.TiposPersona)tipo_per;
            TextoRol.Text = "Rol: " + tipoUsuario.ToString();
            this.TextoBienvenida.Text = "Bienvenido: " + usuario.Nombre + " " + usuario.Apellido ;

        }
    }
}