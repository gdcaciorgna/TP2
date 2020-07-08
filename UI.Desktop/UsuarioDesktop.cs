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
    public partial class UsuarioDesktop : ApplicationForm
    {
        public UsuarioDesktop()
        {
            InitializeComponent();
        }
        public UsuarioDesktop(ModoForm modo) : this()
        {
            this.Modo = modo;

        }

        public UsuarioDesktop(int ID, ModoForm modo) : this()
        {
            this.Modo = modo;
            UsuarioLogic usuariologic = new UsuarioLogic();
            Usuario usu = usuariologic.GetOne(ID);
            UsuarioActual = usu; //Revisar si es correcto (PASO 12)
            this.MapearDeDatos();
        }


        public override void MapearDeDatos()
        {
            this.txtID.Text = this.UsuarioActual.ID.ToString();
            this.txtNombre.Text = this.UsuarioActual.Nombre;
            this.txtApellido.Text = this.UsuarioActual.Apellido;
            this.txtEmail.Text = this.UsuarioActual.Email;
            this.txtUsuario.Text = this.UsuarioActual.NombreUsuario;
            this.chkHabilitado.Checked = this.UsuarioActual.Habilitado;
            this.txtClave.Text = this.UsuarioActual.Clave; 
            this.txtConfirmarClave.Text = this.UsuarioActual.Clave;


            if (this.Modo == ModoForm.Alta || this.Modo == ModoForm.Modificacion)
            {
                this.btnAceptar.Text = "Guardar";
            }


            if (this.Modo == ModoForm.Baja)
            {
                this.btnAceptar.Text = "Eliminar";
            }

            if (this.Modo == ModoForm.Consulta)
            {
                this.btnAceptar.Text = "Aceptar";
            }
        }

        public override void MapearADatos()
        {
            


            if (this.Modo == ModoForm.Alta)
            {
                Usuario usu = new Usuario();
                UsuarioActual = usu;
            }

            if (this.Modo == ModoForm.Alta || this.Modo == ModoForm.Modificacion)
            {
                UsuarioActual.State = BusinessEntity.States.New;

                if (this.Modo == ModoForm.Modificacion)
                {
                    UsuarioActual.ID = Int32.Parse(txtID.Text);
                    UsuarioActual.State = BusinessEntity.States.Modified;
                }

                UsuarioActual.Nombre = txtNombre.Text;
                UsuarioActual.Apellido = txtApellido.Text;
                UsuarioActual.Email = txtEmail.Text;
                UsuarioActual.NombreUsuario = txtUsuario.Text;
                UsuarioActual.Habilitado = chkHabilitado.Checked;
                UsuarioActual.Clave = txtClave.Text;

            }

            if (this.Modo == ModoForm.Baja)
            {
                UsuarioActual.State = BusinessEntity.States.Deleted;
            }


        }

        
        public override bool Validar()
        {
            if (txtNombre.Text != "" && txtApellido.Text != "" && txtEmail.Text != "" && txtUsuario.Text != "" && txtClave.Text != "" && txtConfirmarClave.Text != "") // this.chkHabilitado.Checked ¿se debe validar el checkbox?    
            {
                if (txtClave.Text.Equals(txtConfirmarClave.Text))
                {
                    if ( txtClave.Text.Length >= 8)
                    {
                        if ( txtEmail.Text.Contains("@"))
                        {
                            return true;
                        }
                        else
                        {
                            this.Notificar("Error", "El mail es inválido", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return false;
                        }
                    }
                    else
                    {
                        this.Notificar("Error", "La clave debe contener al menos 8 caracteres", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                }
                else
                {
                    this.Notificar("Error", "Las claves no coinciden", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
            else
            {
                this.Notificar("Error", "No deben quedar campos vacíos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        public override void GuardarCambios()
        {
            this.MapearADatos();
            UsuarioLogic usuLog = new UsuarioLogic();
            usuLog.Save(UsuarioActual);
            //REVISAR NOTA PASO 18 (¿Hay que agregar algo?)
        }

        public Usuario UsuarioActual { get; set; }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            
            if (this.Modo==ModoForm.Alta || this.Modo == ModoForm.Modificacion)
            { 
            if (this.Validar())
            {
                this.GuardarCambios();
                this.Close();
            }
            }
            else if (this.Modo==ModoForm.Baja)
            {
                this.GuardarCambios();
                this.Close();
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }


    
}
