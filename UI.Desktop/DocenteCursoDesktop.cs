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
    public partial class DocenteCursoDesktop : ApplicationForm
    {
        public DocenteCursoDesktop()
        {
            InitializeComponent();

            CursoLogic curLog = new CursoLogic();
            Curso cur = new Curso();

            List<Curso> cursos = new List<Curso>();

            cursos = curLog.GetAll();

            cbCursosNuevo.DataSource = cursos;
            cbCursosNuevo.DisplayMember = "Descripcion";
            cbCursosNuevo.ValueMember = "ID";

            PersonaLogic perLog = new PersonaLogic();
            List<Persona> docentes = new List<Persona>();

            docentes = perLog.GetAllTipo(Persona.TiposPersona.Docente);

            DataTable dt = new DataTable();
            dt = Util.FuncionesComunes.ConvertToDataTable(docentes);
            dt.Columns.Add(new DataColumn("NombreApellidoLegajo", System.Type.GetType("System.String"), "Apellido + ' ' + Nombre + ' - ' + Legajo"));

            cbDocentes.DataSource = dt;

            cbDocentes.ValueMember = "ID";
            cbDocentes.DisplayMember = "NombreApellidoLegajo";


            cbCargos.DataSource = Enum.GetNames(typeof(Business.Entities.DocenteCurso.TiposCargo));


        }

        public DocenteCursoDesktop (ModoForm modo) : this()
        {
            this.Modo = modo;
        }

        public DocenteCursoDesktop(int ID, ModoForm modo) : this()
        {
            this.Modo = modo;
            DocenteCursoLogic docLogic = new DocenteCursoLogic();
            Business.Entities.DocenteCurso doc = docLogic.GetOne(ID);
            DocenteCursoActual = doc;
            this.MapearDeDatos();
        }

        public override void MapearDeDatos()
        {
            Persona doc = new Persona();
            PersonaLogic docente = new PersonaLogic();

            doc = docente.GetOne(DocenteCursoActual.IDDocente);

            Curso cur = new Curso();
            CursoLogic cursos = new CursoLogic();

            cur = cursos.GetOne(DocenteCursoActual.IDCurso);

            this.cbDocentes.SelectedItem = doc;
            this.cbCursosNuevo.SelectedItem = cur;

            

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
                Business.Entities.DocenteCurso doc = new Business.Entities.DocenteCurso();
                DocenteCursoActual = doc;
            }

            if (this.Modo == ModoForm.Alta || this.Modo == ModoForm.Modificacion)
            {
                DocenteCursoActual.State = BusinessEntity.States.New;

                if (this.Modo == ModoForm.Modificacion)
                {
                    
                    DocenteCursoActual.State = BusinessEntity.States.Modified;
                }

                string docen = cbDocentes.SelectedValue.ToString();
                DocenteCursoActual.IDDocente = Int32.Parse(docen);

                string curs = cbCursosNuevo.SelectedValue.ToString();
                DocenteCursoActual.IDCurso = Int32.Parse(curs);

                DocenteCursoLogic tdocLogic = new DocenteCursoLogic();
                DocenteCursoActual.Cargo = tdocLogic.getTipoCargoString(cbCargos.SelectedValue.ToString());
               

            }

            if (this.Modo == ModoForm.Baja)
            {
                DocenteCursoActual.State = BusinessEntity.States.Deleted;
                cbCargos.Enabled = true;
            }


        }

        public Business.Entities.DocenteCurso DocenteCursoActual { get; set; }

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

        public override void GuardarCambios()
        {
            this.MapearADatos();
            DocenteCursoLogic docCur = new DocenteCursoLogic();
            docCur.Save(DocenteCursoActual);

        }

        public override bool Validar()
        {

            String error = "Se han encontrado los siguientes errores: \n\n";
            bool vof = true;

            return vof;


            
        }

        private void DocenteCursoDesktop_Load(object sender, EventArgs e)
        {
          
        }
    }
}
