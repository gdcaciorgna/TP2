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
    public partial class CursosDesktop : ApplicationForm
    {
        public CursosDesktop()
        {
            InitializeComponent();
        }

        public CursosDesktop(ModoForm modo) : this()
        {
            this.Modo = modo;

        }

        public CursosDesktop(int ID, ModoForm modo) : this()
        {
            this.Modo = modo;
            CursoLogic cLogic = new CursoLogic();
            Curso curso = cLogic.GetOne(ID);
            CursoActual = curso; //Revisar si es correcto (PASO 12)
            this.MapearDeDatos();
        }

        public Curso CursoActual { get; set; }

        private void CursosDesktop_Load(object sender, EventArgs e)
        {
            MateriaLogic matLog = new MateriaLogic();
            List<Materia> materias = new List<Materia>();

            materias = matLog.GetAll();
            cbMateria.DataSource = materias;
            cbMateria.ValueMember = "ID";
            cbMateria.DisplayMember = "Descripcion";

            ComisionLogic comLog = new ComisionLogic();
            List<Comision> comision = new List<Comision>();

            comision = comLog.GetAll();
            cbComision.DataSource = comision;
            cbComision.ValueMember = "ID";
            cbComision.DisplayMember = "Descripcion";
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

            if (cbMateria.Items.Count <= 0)
            {
                error = error + "Se debe seleccionar una especialidad. \n";
                vof = false;
            }

            if (cbComision.Items.Count <= 0)
            {
                error = error + "Se debe seleccionar una especialidad. \n";
                vof = false;
            }

            if (txtAnio.Text == "")
            {
                error = error + "No puede quedar el campo Anio Calendario vacío. \n";
                vof = false;
            }

            if (txtCupo.Text == "")
            {
                error = error + "No puede quedar el campo Cupo vacío. \n";
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
            CursoLogic cLog = new CursoLogic();
            cLog.Save(CursoActual);
        }

        public override void MapearDeDatos()
        {
            this.txtIDCursos.Text = this.CursoActual.ID.ToString();
            this.txtDescripcion.Text = this.CursoActual.Descripcion;
            this.txtAnio.Text = this.CursoActual.AnioCalendario.ToString();
            this.txtCupo.Text = this.CursoActual.Cupo.ToString();
            // this.cbEspecialidad.Text = this.PlanActual.IDEspecialidad.ToString();


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
                Curso curso = new Curso();
                CursoActual = curso;
            }

            if (this.Modo == ModoForm.Alta || this.Modo == ModoForm.Modificacion)
            {
                CursoActual.State = BusinessEntity.States.New;

                if (this.Modo == ModoForm.Modificacion)
                {
                    CursoActual.State = BusinessEntity.States.Modified;
                }

                CursoActual.Descripcion = txtDescripcion.Text;
                CursoActual.Cupo = Int32.Parse(txtCupo.Text);
                CursoActual.AnioCalendario = Int32.Parse(txtAnio.Text);
                String mat = cbMateria.SelectedValue.ToString();
                CursoActual.IDMateria = Int32.Parse(mat);
                String com = cbComision.SelectedValue.ToString();
                CursoActual.IDComision = Int32.Parse(com);

            }

            if (this.Modo == ModoForm.Baja)
            {
                CursoActual.State = BusinessEntity.States.Deleted;
            }


        }
    }
    
}
