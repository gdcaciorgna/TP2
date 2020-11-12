using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Business.Logic;
using Business.Entities;

namespace UI.Desktop
{
    public partial class DocenteInscripcionDesktop : ApplicationForm
    {
        public DocenteInscripcionDesktop()
        {
            InitializeComponent();
        }

       public DocenteInscripcionDesktop(int idAlumno) : this()
        {
            AlumnoInscripcionLogic insLog = new AlumnoInscripcionLogic();
            InscripcionActual = insLog.GetOne(idAlumno);

            this.MapearDeDatos();
        }

        public AlumnoInscripcion InscripcionActual { get; set; }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (this.Validar())
            {
                this.GuardarCambios();
                this.Close();
            }
         
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {

        }


        public override bool Validar()
        {
            String error = "Se han encontrado los siguientes errores: \n\n";
            bool vof = true;



        
            try 
            {
                int nota = Int32.Parse(this.txtNota.Text);

                if (nota < 0 || nota > 10)
                {
                    error = error + "Ingrese una nota válida. \n";
                    vof = false;
                }
            }
            catch(Exception ex)
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
                this.Notificar("Error", error, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        public override void GuardarCambios()
        {
            this.MapearADatos();
            AlumnoInscripcionLogic cLog = new AlumnoInscripcionLogic();
            cLog.Update(InscripcionActual);
        }

        public override void MapearDeDatos()
        {


            MateriaLogic matLog = new MateriaLogic();
            ComisionLogic comLog = new ComisionLogic();

            this.txtAlumno.Text = this.InscripcionActual.Alumno;
            this.txtCondicion.Text = this.InscripcionActual.Condicion;
            this.txtNota.Text = this.InscripcionActual.Nota.ToString();

        }

        public override void MapearADatos()
        {
            InscripcionActual.Condicion = this.txtCondicion.Text;
            InscripcionActual.Nota = Int32.Parse(this.txtNota.Text);

 
        }
    }
}
