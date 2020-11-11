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
    public partial class MateriasDesktop : ApplicationForm
    {
        public MateriasDesktop()
        {
            InitializeComponent();

            PlanesLogic planLog = new PlanesLogic();
            List<Plan> planes = new List<Plan>();

            planes = planLog.GetAll();
            cbPlan.DataSource = planes;
            cbPlan.ValueMember = "ID";
            cbPlan.DisplayMember = "Descripcion";
        }

        public MateriasDesktop(ModoForm modo) : this()
        {
            this.Modo = modo;

        }

        public MateriasDesktop(int ID, ModoForm modo) : this()
        {
            this.Modo = modo;
            MateriaLogic mLogic = new MateriaLogic();
            Materia materia = mLogic.GetOne(ID);
            MateriaActual = materia; //Revisar si es correcto (PASO 12)
            this.MapearDeDatos();
        }


        public Materia MateriaActual { get; set; }


   

        public override bool Validar()
        {
            String error = "Se han encontrado los siguientes errores: \n\n";
            bool vof = true;

            if (txtDescripcion.Text == "")
            {
                error = error + "No puede quedar el campo descripción vacío. \n";
                vof = false;
            }

            if (txtHoras_Semanales.Text == "")
            {
                error = error + "No puede quedar el campo horas semanales vacío. \n";
                vof = false;
            }

            if (txtHoras_Totales.Text == "")
            {
                error = error + "No puede quedar el campo horas totales vacío. \n";
                vof = false;
            }

            if (cbPlan.Items.Count <= 0)
            {
                error = error + "Se debe seleccionar una plan. \n";
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
            MateriaLogic mLog = new MateriaLogic();
            mLog.Save(MateriaActual);
        }

        public override void MapearDeDatos()
        {
           

            this.txtIDMateria.Text = this.MateriaActual.ID.ToString();
            this.txtDescripcion.Text = this.MateriaActual.Descripcion;
            this.txtHoras_Semanales.Text = this.MateriaActual.HSSemanales.ToString();
            this.txtHoras_Totales.Text = this.MateriaActual.HSTotales.ToString();

            this.cbPlan.SelectedValue = this.MateriaActual.IDPlan;



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
                Materia materia = new Materia();
                MateriaActual = materia;
            }

            if (this.Modo == ModoForm.Alta || this.Modo == ModoForm.Modificacion)
            {
                MateriaActual.State = BusinessEntity.States.New;

                if (this.Modo == ModoForm.Modificacion)
                {
                    MateriaActual.State = BusinessEntity.States.Modified;
                }

                MateriaActual.Descripcion = txtDescripcion.Text;
                MateriaActual.HSSemanales = Int32.Parse(txtHoras_Semanales.Text);
                MateriaActual.HSTotales = Int32.Parse(txtHoras_Totales.Text);
                String str = cbPlan.SelectedValue.ToString();
                MateriaActual.IDPlan = Int32.Parse(str);

            }

            if (this.Modo == ModoForm.Baja)
            {
                MateriaActual.State = BusinessEntity.States.Deleted;
            }


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

        private void MateriasDesktop_Load(object sender, EventArgs e)
        {
          
        }
    }
}
