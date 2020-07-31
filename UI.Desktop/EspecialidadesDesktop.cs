using Business.Entities;
using Business.Logic;
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
    public partial class EspecialidadesDesktop : ApplicationForm
    {
        public EspecialidadesDesktop()
        {
            InitializeComponent();
        }

        public EspecialidadesDesktop(ModoForm modo) : this()
        {
            this.Modo = modo;
        }

        public EspecialidadesDesktop(int ID, ModoForm modo) : this()
        {
            this.Modo = modo;
            EspecialidadesLogic esplogic = new EspecialidadesLogic();
            Especialidad esp = esplogic.GetOne(ID);
            EspecialidadActual = esp; 
            this.MapearDeDatos();
        }

        public override void MapearDeDatos()
        {
            this.txtId.Text = this.EspecialidadActual.ID.ToString();
            this.txtDescripcion.Text = this.EspecialidadActual.Descripcion;
          


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
                Especialidad esp = new Especialidad();
                EspecialidadActual = esp;
            }

            if (this.Modo == ModoForm.Alta || this.Modo == ModoForm.Modificacion)
            {
                EspecialidadActual.State = BusinessEntity.States.New;

                if (this.Modo == ModoForm.Modificacion)
                {
                    EspecialidadActual.ID = Int32.Parse(txtId.Text);
                    EspecialidadActual.State = BusinessEntity.States.Modified;
                }

                EspecialidadActual.Descripcion = txtDescripcion.Text;

            }

            if (this.Modo == ModoForm.Baja)
            {
                EspecialidadActual.State = BusinessEntity.States.Deleted;
            }


        }

        public Especialidad EspecialidadActual { get; set; }

        private void btnAceptar_Click(object sender, EventArgs e)
        {

            if (this.Modo == ModoForm.Alta || this.Modo == ModoForm.Modificacion)
            {
                if (this.Validar())
                {
                    this.GuardarCambios();
                    this.Close();
                }
            }
            else if (this.Modo == ModoForm.Baja)
            {
                this.GuardarCambios();
                this.Close();
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAceptar_Click_1(object sender, EventArgs e)
        {

            if (this.Modo == ModoForm.Alta || this.Modo == ModoForm.Modificacion)
            {
                if (this.Validar())
                {
                    this.GuardarCambios();
                    this.Close();
                }
            }
            else if (this.Modo == ModoForm.Baja)
            {
                this.GuardarCambios();
                this.Close();
            }
        }

        public override bool Validar()
        {
            
            String error = "Se han encontrado los siguientes errores: \n\n";
            bool vof = true;


            if (txtDescripcion.Text == "")
            {
                error = error + "No puede quedar el campo descripción vacío. \n";
                vof = false;
            }


            if (vof == true)
            {
                return true;
            }

            else
            {
                this.Notificar("Error", error, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }


        public override void GuardarCambios()
        {
            this.MapearADatos();
            EspecialidadesLogic espLog = new EspecialidadesLogic();
            espLog.Save(EspecialidadActual);

        }

    }

}
