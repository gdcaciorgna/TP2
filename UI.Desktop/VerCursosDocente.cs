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
    public partial class VerCursosDocente : Form
    {
        public VerCursosDocente()
        {
            InitializeComponent();

            this.dgvCursos.AutoGenerateColumns = false;

            List<Persona> docentes = new List<Persona>();
            PersonaLogic perLog = new PersonaLogic();

            docentes = perLog.GetAllTipo(Persona.TiposPersona.Docente);

            DataTable dt = new DataTable();
            dt = Util.FuncionesComunes.ConvertToDataTable(docentes);
            dt.Columns.Add(new DataColumn("NombreApellidoLegajo", System.Type.GetType("System.String"), "Apellido + ' ' + Nombre + ' - ' + Legajo"));

            cmbDocente.DataSource = dt;

            cmbDocente.ValueMember = "ID";
            cmbDocente.DisplayMember = "NombreApellidoLegajo";

            int id_per = Usuario.UsuarioActual.ID_Persona;
            DocenteActual = perLog.GetOne(id_per);

            cmbDocente.SelectedItem = DocenteActual;


            Listar();

        }


        public void Listar()
        {
            /*
            DocenteCursoLogic docCurLog = new DocenteCursoLogic();
            List<Curso> cursos = new List<Curso>();
            try
            {


                cursos = docCurLog.GetAl
                this.dgvInscripciones.DataSource = alInsc;



            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            */

            
        }

        public AlumnoInscripcionLogic Logic { get; set; }
        public Persona  DocenteActual { get; set; }

    }
}
