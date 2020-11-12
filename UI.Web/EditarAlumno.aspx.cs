using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Business.Entities;
using Business.Logic;

namespace UI.Web
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        private int SelectedID
        {
            get
            {
                if (this.ViewState["SelectedID"] != null)
                {
                    return (int)this.ViewState["SelectedID"];
                }
                else
                {
                    return 0;
                }
            }
            set
            {
                this.ViewState["SelectedID"] = value;
            }
        }
        private bool IsEntitySelected
        {
            get
            {
                return (this.SelectedID != 0);
            }
        }

        public Usuario UsuarioActual { get; set; }
        public Persona.TiposPersona TipoPersonaActual { get; set; }

        public AlumnoInscripcion AlumnoActual { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            AlumnoActual = (AlumnoInscripcion)Session["AlumnoActual"];

            UsuarioActual = (Usuario)Session["UsuarioActual"];

            if (UsuarioActual != null)
            {
                TipoPersonaActual = (Persona.TiposPersona)Session["TipoPersonaUsuarioActual"];


                if (TipoPersonaActual.Equals(Persona.TiposPersona.Docente)) //cambiar a docente
                {
                    if (IsPostBack == false)
                    {

                        this.txtAlumno.Text = AlumnoActual.Alumno;
                        
                        
                    }



                }

                else
                {
                    Response.Redirect("~/Login.aspx");
                }
            }

            else
            {
                Response.Redirect("~/Login.aspx");
            }



        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            AlumnoInscripcion alum = new AlumnoInscripcion();
            AlumnoInscripcionLogic alumIns = new AlumnoInscripcionLogic();
            if (this.Validar())
            {
                AlumnoActual.Condicion = this.txtCondicion.Text;
                AlumnoActual.Nota = Int32.Parse(this.txtNota.Text);


                alumIns.Update(AlumnoActual);


                Response.Redirect("~/VerAlumnosNotas.aspx");
            }
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/VerAlumnosNotas.aspx");
        }

         public bool Validar() 
         {
            String error = "Se han encontrado los siguientes errores: \n\n";
            bool vof = true;



            if (txtCondicion.Text == "")
            {
                error = error + "No puede quedar el campo condición vacío. \n";
                vof = false;
            }

            try
            {
                int nota = Int32.Parse(this.txtNota.Text);

                if (nota < 0 || nota > 10)
                {
                    error = error + "Ingrese una nota válida. \n";
                    vof = false;
                }
            }
            catch (Exception ex)
            {
                error = error + "Nota no válida. Ingrese un número del 1 al 10. \n";
                vof = false;

            }




            if (vof == true)
            {
                return true;
            }

            else
            {
                
                this.panelError.Visible = true;
                this.lblerror.Text = error;
                return vof;
            }
        }
    }
}