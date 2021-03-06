﻿using System;
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
    public partial class ComisionesDesktop : ApplicationForm
    {
        public ComisionesDesktop()
        {
            InitializeComponent();

            PlanesLogic planLog = new PlanesLogic();
            List<Plan> planes = new List<Plan>();

            planes = planLog.GetAll();
            cmbIdPlan.DataSource = planes;

            cmbIdPlan.ValueMember = "ID";
            cmbIdPlan.DisplayMember = "Descripcion";
        }
        public ComisionesDesktop(ModoForm modo) : this()
        {
            this.Modo = modo;

        }

        public ComisionesDesktop(int ID, ModoForm modo) : this()
        {
            this.Modo = modo;
            ComisionLogic pLogic = new ComisionLogic();
            Comision com = pLogic.GetOne(ID);
            ComisionActual = com; //Revisar si es correcto (PASO 12)
            this.MapearDeDatos();
        }

        public Comision ComisionActual {get; set;}

   
    
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

            if (cmbIdPlan.Items.Count <= 0)
            {
                error = error + "Se debe seleccionar un plan. \n";
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
           ComisionLogic clog = new ComisionLogic();
           clog.Save(ComisionActual);
        }

        public override void MapearDeDatos()
        {
            PlanesLogic pLog = new PlanesLogic();
            Plan plan = new Plan();

            plan = pLog.GetOne(this.ComisionActual.IDPlan);


            this.cmbIdPlan.SelectedValue = plan.ID;

            this.txtDescripcion.Text = this.ComisionActual.Descripcion;
            this.txtAnioEspecialidad.Text = this.ComisionActual.AnioEspecialidad.ToString();


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
                Comision com = new Comision();
                ComisionActual = com;
            }

            if (this.Modo == ModoForm.Alta || this.Modo == ModoForm.Modificacion)
            {
                ComisionActual.State = BusinessEntity.States.New;

                if (this.Modo == ModoForm.Modificacion)
                {
                    ComisionActual.State = BusinessEntity.States.Modified;
                }

                ComisionActual.Descripcion = txtDescripcion.Text;
                String str = cmbIdPlan.SelectedValue.ToString();
                ComisionActual.IDPlan= Int32.Parse(str);
                String anio = txtAnioEspecialidad.Text.ToString();
                ComisionActual.AnioEspecialidad = Int32.Parse(anio);

            }

            if (this.Modo == ModoForm.Baja)
            {
                ComisionActual.State = BusinessEntity.States.Deleted;
            }


        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void ComisionesDesktop_Load(object sender, EventArgs e)
        {
            

            
        }
    }
}
    

