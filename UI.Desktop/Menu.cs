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
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void btnUsuario_Click(object sender, EventArgs e)
        {
            Usuarios usuarios = new Usuarios();
            this.Hide();
            usuarios.ShowDialog();
            this.Show();
        }

        private void btnEspecialidad_Click(object sender, EventArgs e)
        {
            Especialidades especialidades = new Especialidades();
            this.Hide();
            especialidades.ShowDialog();
            this.Show();
        }

        private void btnPlan_Click(object sender, EventArgs e)
        {
            Planes formPlan = new Planes();
            this.Hide();
            formPlan.ShowDialog();
            this.Show();
        }

        private void Menu_Load(object sender, EventArgs e)
        {
            UsuarioLogic usuLog = new UsuarioLogic();
            int tipo_per = usuLog.GetTipoPersona(Usuario.UsuarioActual);

            TextoBienvenida.Text = "¡Bienvenido: " + Usuario.UsuarioActual.Apellido + ", " + Usuario.UsuarioActual.Nombre + "!";

            Persona.TiposPersona tipoUsuario = (Persona.TiposPersona)tipo_per;
            textoRol.Text = "Rol: " + tipoUsuario.ToString();


            switch (tipoUsuario)
            {
                case Persona.TiposPersona.Administrador:
                    tsmiAlumnos.Visible = true;
                    tsmiComisiones.Visible = true;
                    tsmiCursos.Visible = true;
                    tsmiDocentes.Visible = true;
                    tsmiEspecialidades.Visible = true;
                    tsmiPersonas.Visible = true;
                    tsmiPlanes.Visible = true;
                    tsmiUsuarios.Visible = true;
                    tsmiMaterias.Visible = true;

                    tsmiArchivo.Visible = true;
                    tsmiInformes.Visible = true;
                    tsmiInscripciones.Visible = true;
                    tsmiinscribirAlumnos.Visible = true;


                    tsmiInformes.Visible = true;
                    tsmiRegistroCursos.Visible = true;
                    tsmiRegistroNotas.Visible = true;

                    tsmiInscribirDocente.Visible = true;



                    break;

                case Persona.TiposPersona.Docente:
                    tsmiVerCursosAsignadosDocente.Visible = true;                    

                    break;

                case Persona.TiposPersona.Alumno:
                    tsmiInscripciones.Visible = true;
                    tsmiInscribirseACurso.Visible = true;
                    
                    break;
            }

        }

        private void nuevoAlumnoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PersonasDesktop formper = new PersonasDesktop();
            formper.ShowDialog();
        }

        private void nuevaEspecialidadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EspecialidadesDesktop formEsp = new EspecialidadesDesktop();
            formEsp.ShowDialog();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void verEspecialidadesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Especialidades formEsp = new Especialidades();
            formEsp.ShowDialog();

        }

        private void nuevoPlanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PlanesDesktop frmPlan = new PlanesDesktop();
            frmPlan.ShowDialog();

        }

        private void verPlanesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Planes frmPlan = new Planes();
            frmPlan.ShowDialog();

        }

        private void crearUsuarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UsuarioDesktop usuDesk = new UsuarioDesktop();
            usuDesk.ShowDialog();
        }

        private void verUsuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Usuarios usuDesk = new Usuarios();
            usuDesk.ShowDialog();
        }

        private void nuevaPersonaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PersonasDesktop perDesk = new PersonasDesktop();
            perDesk.ShowDialog();
        }

        private void verPersonasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Personas per = new Personas(0);
            per.ShowDialog();
        }

        private void verAlumnosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Personas personas = new Personas(2);
            personas.ShowDialog();
            
        }

        private void verDocentesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Personas personas = new Personas(1);
            personas.ShowDialog();
        }

        private void verMateriasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Materias mat = new Materias();
            mat.ShowDialog();
        }

        private void nuevaMateriaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MateriasDesktop matDesk = new MateriasDesktop();
            matDesk.ShowDialog();
        }

        private void verComisionesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Comisiones com = new Comisiones();
            com.ShowDialog();
        }

        private void nuevaComisiónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ComisionesDesktop com = new ComisionesDesktop();
            com.ShowDialog();
        }

        private void verCursosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Cursos cur = new Cursos();
            cur.ShowDialog();
        }

        private void nuevoCursoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CursosDesktop cur = new CursosDesktop();
            cur.ShowDialog();
        }

        private void tsmiRegistroCursos_Click(object sender, EventArgs e)
        {
            ReporteAsistencias rep = new ReporteAsistencias();
            rep.ShowDialog();
        }

        private void tsmiInscribirAlumnoCurso_Click(object sender, EventArgs e)
        {
            AlumnoInscripciones aluDesk = new AlumnoInscripciones();
            aluDesk.ShowDialog();
        }

        private void nuevoDocenteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PersonasDesktop formper = new PersonasDesktop();
            formper.ShowDialog();
        }

        private void tsmiRegistroNotas_Click(object sender, EventArgs e)
        {
            NotasAlumnos noal = new NotasAlumnos();
            noal.ShowDialog();
        }

        private void inscribirAlumnosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AdministradorVerInscripciones desk = new AdministradorVerInscripciones();
            desk.ShowDialog();
        }

        private void inscribirDocenteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DocenteCurso docCur = new DocenteCurso();
            docCur.ShowDialog();
        }


        private void verCursosAsignadosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            VerCursosDocente desk = new VerCursosDocente();
            desk.ShowDialog();

        }
    }
}
