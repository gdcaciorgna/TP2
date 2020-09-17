﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Business.Entities;
using Business.Logic;
using Util;

namespace UI.Web
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnIngresar_Click(object sender, EventArgs e)
        {
            if (Validaciones.ControlaCampos(txtUsuario.Text) == true && Validaciones.ControlaCampos(txtClave.Text))
            {
                Usuario usr = new Usuario();
                UsuarioLogic usLog = new UsuarioLogic();
                usr = usLog.GetUsuarioxUsrNombre(txtUsuario.Text);

                Usuario.UsuarioActual = usr;

                if (Validaciones.ControlaClave(txtClave.Text, Usuario.UsuarioActual.Clave) == true)
                {
                    Session["UsuarioActual"] = usr;
                    Response.Redirect("~/Home.aspx");
                }
                else Page.Response.Write("Usuario y/o Contraseña incorrectos");
            }
            else Page.Response.Write("Campos vacíos");
          }

        protected void lnkRecordarClave_Click(object sender, EventArgs e)
        {
            Page.Response.Write("Es Ud. un usuario muy descuidado, haga memoria");
        }
    }
}