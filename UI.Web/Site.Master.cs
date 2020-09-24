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
    public partial class Site : System.Web.UI.MasterPage
    {

        public Usuario UsuarioActual { get; set; }
        public Persona.TiposPersona TipoPersonaActual { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            UsuarioLogic usuLog = new UsuarioLogic();        

            UsuarioActual = (Usuario)(Session["UsuarioActual"]);


            if (UsuarioActual != null)  //usuario logueado
            {
                lbLogin.Text = "Cerrar sesión";
                TipoPersonaActual = (Persona.TiposPersona)(Session["TipoPersonaUsuarioActual"]);
            }
            else 
            {
                lbLogin.Text = "Iniciar sesión";
            }





        }



        protected void lbLogin_Click(object sender, EventArgs e)
        {
            if (UsuarioActual != null)
            {
                Session["UsuarioActual"] = null;  // limpiamos la sesión
                Session["TipoPersonaUsuarioActual"] = null;
            }

            Response.Redirect("~/Login.aspx");
        }
    }
}