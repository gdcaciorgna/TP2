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
          
            UsuarioActual = (Usuario) (Session["UsuarioActual"]);



            if(UsuarioActual != null) 
            {

                TipoPersonaActual = (Persona.TiposPersona)Session["TipoPersonaUsuarioActual"];
                this.TextoBienvenida.Text = "Bienvenido: " + UsuarioActual.Nombre + " " + UsuarioActual.Apellido;
                TextoRol.Text = "Rol: " + TipoPersonaActual.ToString();

            }


        }

        public Usuario UsuarioActual { get; set; }
        public Persona.TiposPersona TipoPersonaActual { get; set; }
    }
}