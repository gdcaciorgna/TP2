using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Business.Entities;
using Business.Logic;

namespace UI.Web
{
    public partial class Usuarios : System.Web.UI.Page
    {
        public enum FormModes
        {
            Alta,
            Baja,
            Modificacion
        }

        public FormModes FormMode
        {
            get { return (FormModes)this.ViewState["FormMode"]; }
            set { this.ViewState["FormMode"] = value; }
        }
        private Usuario Entity
        {
            get;
            set;
        }
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
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack == false)
            {
                LoadGrid();
            }
        }

        protected void GridView_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.SelectedID = (int)this.GridView.SelectedValue;
        }

        private void LoadForm(int id)
        {
            this.Entity = this.Logic.GetOne(id);
            this.tbNombre.Text = this.Entity.Nombre;
            this.tbApellido.Text = this.Entity.Apellido;
            this.tbEmail.Text = this.Entity.Email;
            this.cbHabilitado.Checked = this.Entity.Habilitado;
            this.tbUsuario.Text = this.Entity.NombreUsuario;
        }
        UsuarioLogic _logic;
        private UsuarioLogic Logic
        {
            get
            {
                if (_logic==null)
                {
                    _logic = new UsuarioLogic();
                }
                return _logic;
            }
        }
        private void LoadGrid()
        {
            this.GridView.DataSource = this.Logic.GetAll();
            this.GridView.DataBind();
        }

        protected void lbEditar_Click(object sender, EventArgs e)
        {
            if (this.IsEntitySelected)
            {
                this.EnableForm(true);
                this.formPanel.Visible = true;
                this.FormMode = FormModes.Modificacion;
                this.LoadForm(this.SelectedID);
            }
        }

        private void LoadEntity (Usuario usuario)
        {
            usuario.Nombre = this.tbNombre.Text;
            usuario.Apellido = this.tbApellido.Text;
            usuario.Email = this.tbEmail.Text;
            usuario.NombreUsuario = this.tbUsuario.Text;
            usuario.Clave = this.tbClave.Text;
            usuario.Habilitado = this.cbHabilitado.Checked;
        }

        private void SaveEntity(Usuario usuario)
        {
            this.Logic.Save(usuario);
        }

        protected void lbAceptar_Click(object sender, EventArgs e)
        {
            switch (this.FormMode)
            {
                case FormModes.Baja:
                    this.DeleteEntity(this.SelectedID);
                    this.LoadGrid();
                    break;
                case FormModes.Modificacion:
                    this.Entity = new Usuario();
                    this.Entity.ID = this.SelectedID;
                    this.Entity.State = BusinessEntity.States.Modified;
                    this.LoadEntity(this.Entity);
                    if (this.Validar() == true)
                    {
                        this.SaveEntity(this.Entity);
                        this.LoadGrid();
                        
                    }
                    break;
                case FormModes.Alta:
                    this.Entity = new Usuario();
                    this.LoadEntity(this.Entity);
                    if (this.Validar() == true)
                    {
                        this.SaveEntity(this.Entity);
                        this.LoadGrid();

                    }
                    break;
                default:
                    break;
             }
            this.formPanel.Visible = false;
        }

        private void EnableForm (bool enable)
        {
            this.tbNombre.Enabled = enable;
            this.tbApellido.Enabled = enable;
            this.tbEmail.Enabled = enable;
            this.tbUsuario.Enabled = enable;
            this.tbClave.Visible = enable;
            this.lbClave.Visible = enable;
            this.tbRepetirClave.Visible = enable;
            this.lbRepetirClave.Visible = enable;
        }

        protected void lbEliminar_Click(object sender, EventArgs e)
        {
            if (this.IsEntitySelected)
            {
                this.formPanel.Visible = true;
                this.FormMode = FormModes.Baja;
                this.EnableForm(false);
                this.LoadForm(this.SelectedID);
            }
        }

        private void DeleteEntity(int id)
        {
            this.Logic.Delete(id);
        }

        protected void lbNuevo_Click(object sender, EventArgs e)
        {
            this.formPanel.Visible = true;
            this.FormMode = FormModes.Alta;
            this.ClearForm();
            this.EnableForm(true);
        }
        
        private void ClearForm()
        {
            this.tbNombre.Text = string.Empty;
            this.tbApellido.Text = string.Empty;
            this.tbEmail.Text = string.Empty;
            this.cbHabilitado.Checked = false;
            this.tbUsuario.Text = string.Empty;
            this.tbClave.Text = string.Empty;
            this.tbRepetirClave.Text = string.Empty;
        }

        protected void lbCancelar_Click(object sender, EventArgs e)
        {
            this.formPanel.Visible = false;
            this.LoadGrid();
        }

        public bool Validar()
        {
            String error = "Se han encontrado los siguientes errores: <br /><br />";
            bool vof = true;



            if (tbNombre.Text == "")
            {
                error = error + "El campo nombre no puede estar vacío. <br />";
                vof = false;
            }

            if (tbApellido.Text == "")
            {
                error = error + "El campo apellido no puede estar vacío. <br />";
                vof = false;
            }

            if (tbEmail.Text == "")
            {
                error = error + "El campo email no puede estar vacío. <br />";
                vof = false;
            }


            if (tbUsuario.Text == "")
            {
                error = error + "El campo usuario no puede estar vacío. <br />";
                vof = false;
            }

            if (tbClave.Text == "")
            {
                error = error + "El campo clave no puede estar vacío. <br />";
                vof = false;
            }


            if (tbRepetirClave.Text == "")
            {
                error = error + "El campo confirmar clave no puede estar vacío. <br />";
                vof = false;
            }

            if (!tbEmail.Text.Contains("@"))
            {
                error = error + "El campo email no es válido. <br />";
                vof = false;
            }

            if (tbClave.Text.Length <= 8)
            {
                error = error + "La clave debe contener al menos 8 caracteres. <br />";
                vof = false;
            }

            if (!tbClave.Text.Equals(tbRepetirClave.Text))
            {
                error = error + "Ambas claves deben coincidir. <br />";
                vof = false;
            }


            if (vof == true)
            {
                return true;
            }

            else
            {
                this.PanelError.Visible = true;
                this.lblError.Text = error;
                return false;

            }
        }
    }
}