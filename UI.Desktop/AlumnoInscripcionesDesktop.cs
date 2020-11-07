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
    public partial class AlumnoInscripcionesDesktop : ApplicationForm
    {
        public AlumnoInscripcionesDesktop()
        {
            InitializeComponent();
        }

        public AlumnoInscripcionesDesktop(ModoForm modo) : this()
        {
            this.Modo = modo;

        }

        public AlumnoInscripcionesDesktop(int ID, ModoForm modo) : this()
        {
            this.Modo = modo;
            AlumnoInscripcionLogic aiLogic = new AlumnoInscripcionLogic();
            AlumnoInscripcion alInsc = aiLogic.GetOne(ID);
            AlumnoInscripcionActual = alInsc; //Revisar si es correcto (PASO 12)
            this.MapearDeDatos();
        }

        public AlumnoInscripcion AlumnoInscripcionActual { get; set; }

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

        }


        public override bool Validar()
        {
            String error = "Se han encontrado los siguientes errores: \n\n";
            bool vof = true;


            Curso cur = new Curso();
            CursoLogic curLog = new CursoLogic();

            AlumnoInscripcionLogic aluInscLog = new AlumnoInscripcionLogic();

            cur = curLog.GetOne(AlumnoInscripcionActual.IDCurso);

            int cant_alumnos = aluInscLog.ContarAlumnosInscriptosACurso(cur);



            if (cur.ID == 0)
            {
                error = error + "No se encontró curso para materia, comisión y año especificado. <br />";
                vof = false;

            }

            else if (aluInsc.ID != 0)
            {
                error = error + "Ya se encuentra inscripto al curso. <br />";
                vof = false;
            }


            else if ((cant_alumnos + 1) > cur.Cupo)
            {
                error = error + "El curso ya se encuentra completo. " + cant_alumnos + "/" + cur.Cupo + " <br />";
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
    }
}
