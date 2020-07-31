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
    public partial class PlanesDesktop : ApplicationForm
    {
        public PlanesDesktop()
        {
            InitializeComponent();
        }

        public PlanesDesktop(ModoForm modo) : this()
        {
            this.Modo = modo;

        }

        public PlanesDesktop(int ID, ModoForm modo) : this()
        {
            this.Modo = modo;
            PlanesLogic pLogic = new PlanesLogic();
            Plan plan = pLogic.GetOne(ID);
            PlanActual = plan; //Revisar si es correcto (PASO 12)
            this.MapearDeDatos();
        }


        public Plan PlanActual { get; set; }


        private void PlanesDesktop_Load(object sender, EventArgs e)
        {
            EspecialidadesLogic espLog = new EspecialidadesLogic();
            List <Especialidad> especialidades = new  List<Especialidad>();

            especialidades = espLog.GetAll();
            cbEspecialidad.DataSource = especialidades;
            cbEspecialidad.ValueMember = "ID";
            cbEspecialidad.DisplayMember = "Descripcion";

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

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

        public override bool Validar()
        {
            String error = "Se han encontrado los siguientes errores: \n\n";
            bool vof = true;

            

            if (txtDescripcion.Text == "")  
            {
                error = error + "No puede quedar el campo descripción vacío. \n";
                vof = false;
            }

            if (cbEspecialidad.Items.Count <= 0) 
            {
                error = error + "Se debe seleccionar una especialidad. \n";
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
            PlanesLogic lLog = new PlanesLogic();
            lLog.Save(PlanActual);
        }

        public override void MapearDeDatos()
        {
            this.txtIDPlan.Text = this.PlanActual.ID.ToString();
            this.txtDescripcion.Text = this.PlanActual.Descripcion;
            this.cbEspecialidad.Text = this.PlanActual.IDEspecialidad.ToString();


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
                Plan plan = new Plan();
                PlanActual = plan;
            }

            if (this.Modo == ModoForm.Alta || this.Modo == ModoForm.Modificacion)
            {
                PlanActual.State = BusinessEntity.States.New;

                if (this.Modo == ModoForm.Modificacion)
                {
                    PlanActual.State = BusinessEntity.States.Modified;
                }

                PlanActual.Descripcion = txtDescripcion.Text;
                String str = cbEspecialidad.SelectedValue.ToString();
                PlanActual.IDEspecialidad = Int32.Parse(str);

            }

            if (this.Modo == ModoForm.Baja)
            {
                PlanActual.State = BusinessEntity.States.Deleted;
            }


        }

    }
}
