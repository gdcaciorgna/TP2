namespace UI.Desktop
{
    partial class Menu
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.tsmiArchivo = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiAlumnos = new System.Windows.Forms.ToolStripMenuItem();
            this.nuevoAlumnoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.verAlumnosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiDocentes = new System.Windows.Forms.ToolStripMenuItem();
            this.nuevoDocenteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.verDocentesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiPersonas = new System.Windows.Forms.ToolStripMenuItem();
            this.nuevaPersonaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.verPersonasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiUsuarios = new System.Windows.Forms.ToolStripMenuItem();
            this.crearUsuarioToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.verUsuariosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiEspecialidades = new System.Windows.Forms.ToolStripMenuItem();
            this.nuevaEspecialidadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.verEspecialidadesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiPlanes = new System.Windows.Forms.ToolStripMenuItem();
            this.nuevoPlanToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.verPlanesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiMaterias = new System.Windows.Forms.ToolStripMenuItem();
            this.nuevaMateriaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.verMateriasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiComisiones = new System.Windows.Forms.ToolStripMenuItem();
            this.nuevaComisiónToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.verComisionesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiCursos = new System.Windows.Forms.ToolStripMenuItem();
            this.nuevoCursoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.verCursosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiInscripciones = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiInscribirseACurso = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiinscribirAlumnos = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiInformes = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiRegistroNotas = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiRegistroCursos = new System.Windows.Forms.ToolStripMenuItem();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.TextoBienvenida = new System.Windows.Forms.Label();
            this.textoRol = new System.Windows.Forms.Label();
            this.tsmiInscribirDocente = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiArchivo,
            this.tsmiInscripciones,
            this.tsmiInformes});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(5, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(708, 28);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // tsmiArchivo
            // 
            this.tsmiArchivo.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiAlumnos,
            this.tsmiDocentes,
            this.tsmiPersonas,
            this.tsmiUsuarios,
            this.tsmiEspecialidades,
            this.tsmiPlanes,
            this.tsmiMaterias,
            this.tsmiComisiones,
            this.tsmiCursos});
            this.tsmiArchivo.Name = "tsmiArchivo";
            this.tsmiArchivo.Size = new System.Drawing.Size(73, 24);
            this.tsmiArchivo.Text = "Archivo";
            this.tsmiArchivo.Visible = false;
            // 
            // tsmiAlumnos
            // 
            this.tsmiAlumnos.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nuevoAlumnoToolStripMenuItem,
            this.verAlumnosToolStripMenuItem});
            this.tsmiAlumnos.Name = "tsmiAlumnos";
            this.tsmiAlumnos.Size = new System.Drawing.Size(190, 26);
            this.tsmiAlumnos.Text = "Alumnos";
            this.tsmiAlumnos.Visible = false;
            // 
            // nuevoAlumnoToolStripMenuItem
            // 
            this.nuevoAlumnoToolStripMenuItem.Name = "nuevoAlumnoToolStripMenuItem";
            this.nuevoAlumnoToolStripMenuItem.Size = new System.Drawing.Size(189, 26);
            this.nuevoAlumnoToolStripMenuItem.Text = "Nuevo alumno";
            this.nuevoAlumnoToolStripMenuItem.Click += new System.EventHandler(this.nuevoAlumnoToolStripMenuItem_Click);
            // 
            // verAlumnosToolStripMenuItem
            // 
            this.verAlumnosToolStripMenuItem.Name = "verAlumnosToolStripMenuItem";
            this.verAlumnosToolStripMenuItem.Size = new System.Drawing.Size(189, 26);
            this.verAlumnosToolStripMenuItem.Text = "Ver alumnos";
            this.verAlumnosToolStripMenuItem.Click += new System.EventHandler(this.verAlumnosToolStripMenuItem_Click);
            // 
            // tsmiDocentes
            // 
            this.tsmiDocentes.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nuevoDocenteToolStripMenuItem,
            this.verDocentesToolStripMenuItem});
            this.tsmiDocentes.Name = "tsmiDocentes";
            this.tsmiDocentes.Size = new System.Drawing.Size(190, 26);
            this.tsmiDocentes.Text = "Docentes";
            this.tsmiDocentes.Visible = false;
            // 
            // nuevoDocenteToolStripMenuItem
            // 
            this.nuevoDocenteToolStripMenuItem.Name = "nuevoDocenteToolStripMenuItem";
            this.nuevoDocenteToolStripMenuItem.Size = new System.Drawing.Size(193, 26);
            this.nuevoDocenteToolStripMenuItem.Text = "Nuevo docente";
            this.nuevoDocenteToolStripMenuItem.Click += new System.EventHandler(this.nuevoDocenteToolStripMenuItem_Click);
            // 
            // verDocentesToolStripMenuItem
            // 
            this.verDocentesToolStripMenuItem.Name = "verDocentesToolStripMenuItem";
            this.verDocentesToolStripMenuItem.Size = new System.Drawing.Size(193, 26);
            this.verDocentesToolStripMenuItem.Text = "Ver docentes";
            this.verDocentesToolStripMenuItem.Click += new System.EventHandler(this.verDocentesToolStripMenuItem_Click);
            // 
            // tsmiPersonas
            // 
            this.tsmiPersonas.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nuevaPersonaToolStripMenuItem,
            this.verPersonasToolStripMenuItem});
            this.tsmiPersonas.Name = "tsmiPersonas";
            this.tsmiPersonas.Size = new System.Drawing.Size(190, 26);
            this.tsmiPersonas.Text = "Personas";
            this.tsmiPersonas.Visible = false;
            // 
            // nuevaPersonaToolStripMenuItem
            // 
            this.nuevaPersonaToolStripMenuItem.Name = "nuevaPersonaToolStripMenuItem";
            this.nuevaPersonaToolStripMenuItem.Size = new System.Drawing.Size(191, 26);
            this.nuevaPersonaToolStripMenuItem.Text = "Nueva persona";
            this.nuevaPersonaToolStripMenuItem.Click += new System.EventHandler(this.nuevaPersonaToolStripMenuItem_Click);
            // 
            // verPersonasToolStripMenuItem
            // 
            this.verPersonasToolStripMenuItem.Name = "verPersonasToolStripMenuItem";
            this.verPersonasToolStripMenuItem.Size = new System.Drawing.Size(191, 26);
            this.verPersonasToolStripMenuItem.Text = "Ver personas";
            this.verPersonasToolStripMenuItem.Click += new System.EventHandler(this.verPersonasToolStripMenuItem_Click);
            // 
            // tsmiUsuarios
            // 
            this.tsmiUsuarios.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.crearUsuarioToolStripMenuItem,
            this.verUsuariosToolStripMenuItem});
            this.tsmiUsuarios.Name = "tsmiUsuarios";
            this.tsmiUsuarios.Size = new System.Drawing.Size(190, 26);
            this.tsmiUsuarios.Text = "Usuarios";
            this.tsmiUsuarios.Visible = false;
            // 
            // crearUsuarioToolStripMenuItem
            // 
            this.crearUsuarioToolStripMenuItem.Name = "crearUsuarioToolStripMenuItem";
            this.crearUsuarioToolStripMenuItem.Size = new System.Drawing.Size(179, 26);
            this.crearUsuarioToolStripMenuItem.Text = "Crear usuario";
            this.crearUsuarioToolStripMenuItem.Click += new System.EventHandler(this.crearUsuarioToolStripMenuItem_Click);
            // 
            // verUsuariosToolStripMenuItem
            // 
            this.verUsuariosToolStripMenuItem.Name = "verUsuariosToolStripMenuItem";
            this.verUsuariosToolStripMenuItem.Size = new System.Drawing.Size(179, 26);
            this.verUsuariosToolStripMenuItem.Text = "Ver usuarios";
            this.verUsuariosToolStripMenuItem.Click += new System.EventHandler(this.verUsuariosToolStripMenuItem_Click);
            // 
            // tsmiEspecialidades
            // 
            this.tsmiEspecialidades.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nuevaEspecialidadToolStripMenuItem,
            this.verEspecialidadesToolStripMenuItem});
            this.tsmiEspecialidades.Name = "tsmiEspecialidades";
            this.tsmiEspecialidades.Size = new System.Drawing.Size(190, 26);
            this.tsmiEspecialidades.Text = "Especialidades";
            this.tsmiEspecialidades.Visible = false;
            // 
            // nuevaEspecialidadToolStripMenuItem
            // 
            this.nuevaEspecialidadToolStripMenuItem.Name = "nuevaEspecialidadToolStripMenuItem";
            this.nuevaEspecialidadToolStripMenuItem.Size = new System.Drawing.Size(222, 26);
            this.nuevaEspecialidadToolStripMenuItem.Text = "Nueva especialidad";
            this.nuevaEspecialidadToolStripMenuItem.Click += new System.EventHandler(this.nuevaEspecialidadToolStripMenuItem_Click);
            // 
            // verEspecialidadesToolStripMenuItem
            // 
            this.verEspecialidadesToolStripMenuItem.Name = "verEspecialidadesToolStripMenuItem";
            this.verEspecialidadesToolStripMenuItem.Size = new System.Drawing.Size(222, 26);
            this.verEspecialidadesToolStripMenuItem.Text = "Ver especialidades";
            this.verEspecialidadesToolStripMenuItem.Click += new System.EventHandler(this.verEspecialidadesToolStripMenuItem_Click);
            // 
            // tsmiPlanes
            // 
            this.tsmiPlanes.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nuevoPlanToolStripMenuItem,
            this.verPlanesToolStripMenuItem});
            this.tsmiPlanes.Name = "tsmiPlanes";
            this.tsmiPlanes.Size = new System.Drawing.Size(190, 26);
            this.tsmiPlanes.Text = "Planes";
            this.tsmiPlanes.Visible = false;
            // 
            // nuevoPlanToolStripMenuItem
            // 
            this.nuevoPlanToolStripMenuItem.Name = "nuevoPlanToolStripMenuItem";
            this.nuevoPlanToolStripMenuItem.Size = new System.Drawing.Size(168, 26);
            this.nuevoPlanToolStripMenuItem.Text = "Nuevo plan";
            this.nuevoPlanToolStripMenuItem.Click += new System.EventHandler(this.nuevoPlanToolStripMenuItem_Click);
            // 
            // verPlanesToolStripMenuItem
            // 
            this.verPlanesToolStripMenuItem.Name = "verPlanesToolStripMenuItem";
            this.verPlanesToolStripMenuItem.Size = new System.Drawing.Size(168, 26);
            this.verPlanesToolStripMenuItem.Text = "Ver planes";
            this.verPlanesToolStripMenuItem.Click += new System.EventHandler(this.verPlanesToolStripMenuItem_Click);
            // 
            // tsmiMaterias
            // 
            this.tsmiMaterias.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nuevaMateriaToolStripMenuItem,
            this.verMateriasToolStripMenuItem});
            this.tsmiMaterias.Name = "tsmiMaterias";
            this.tsmiMaterias.Size = new System.Drawing.Size(190, 26);
            this.tsmiMaterias.Text = "Materias";
            this.tsmiMaterias.Visible = false;
            // 
            // nuevaMateriaToolStripMenuItem
            // 
            this.nuevaMateriaToolStripMenuItem.Name = "nuevaMateriaToolStripMenuItem";
            this.nuevaMateriaToolStripMenuItem.Size = new System.Drawing.Size(189, 26);
            this.nuevaMateriaToolStripMenuItem.Text = "Nueva materia";
            this.nuevaMateriaToolStripMenuItem.Click += new System.EventHandler(this.nuevaMateriaToolStripMenuItem_Click);
            // 
            // verMateriasToolStripMenuItem
            // 
            this.verMateriasToolStripMenuItem.Name = "verMateriasToolStripMenuItem";
            this.verMateriasToolStripMenuItem.Size = new System.Drawing.Size(189, 26);
            this.verMateriasToolStripMenuItem.Text = "Ver materias";
            this.verMateriasToolStripMenuItem.Click += new System.EventHandler(this.verMateriasToolStripMenuItem_Click);
            // 
            // tsmiComisiones
            // 
            this.tsmiComisiones.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nuevaComisiónToolStripMenuItem,
            this.verComisionesToolStripMenuItem});
            this.tsmiComisiones.Name = "tsmiComisiones";
            this.tsmiComisiones.Size = new System.Drawing.Size(190, 26);
            this.tsmiComisiones.Text = "Comisiones";
            this.tsmiComisiones.Visible = false;
            // 
            // nuevaComisiónToolStripMenuItem
            // 
            this.nuevaComisiónToolStripMenuItem.Name = "nuevaComisiónToolStripMenuItem";
            this.nuevaComisiónToolStripMenuItem.Size = new System.Drawing.Size(198, 26);
            this.nuevaComisiónToolStripMenuItem.Text = "Nueva comisión";
            this.nuevaComisiónToolStripMenuItem.Click += new System.EventHandler(this.nuevaComisiónToolStripMenuItem_Click);
            // 
            // verComisionesToolStripMenuItem
            // 
            this.verComisionesToolStripMenuItem.Name = "verComisionesToolStripMenuItem";
            this.verComisionesToolStripMenuItem.Size = new System.Drawing.Size(198, 26);
            this.verComisionesToolStripMenuItem.Text = "Ver comisiones";
            this.verComisionesToolStripMenuItem.Click += new System.EventHandler(this.verComisionesToolStripMenuItem_Click);
            // 
            // tsmiCursos
            // 
            this.tsmiCursos.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nuevoCursoToolStripMenuItem,
            this.verCursosToolStripMenuItem});
            this.tsmiCursos.Name = "tsmiCursos";
            this.tsmiCursos.Size = new System.Drawing.Size(190, 26);
            this.tsmiCursos.Text = "Cursos";
            this.tsmiCursos.Visible = false;
            // 
            // nuevoCursoToolStripMenuItem
            // 
            this.nuevoCursoToolStripMenuItem.Name = "nuevoCursoToolStripMenuItem";
            this.nuevoCursoToolStripMenuItem.Size = new System.Drawing.Size(174, 26);
            this.nuevoCursoToolStripMenuItem.Text = "Nuevo curso";
            this.nuevoCursoToolStripMenuItem.Click += new System.EventHandler(this.nuevoCursoToolStripMenuItem_Click);
            // 
            // verCursosToolStripMenuItem
            // 
            this.verCursosToolStripMenuItem.Name = "verCursosToolStripMenuItem";
            this.verCursosToolStripMenuItem.Size = new System.Drawing.Size(174, 26);
            this.verCursosToolStripMenuItem.Text = "Ver cursos";
            this.verCursosToolStripMenuItem.Click += new System.EventHandler(this.verCursosToolStripMenuItem_Click);
            // 
            // tsmiInscripciones
            // 
            this.tsmiInscripciones.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiInscribirseACurso,
            this.tsmiinscribirAlumnos,
            this.tsmiInscribirDocente});
            this.tsmiInscripciones.Name = "tsmiInscripciones";
            this.tsmiInscripciones.Size = new System.Drawing.Size(108, 24);
            this.tsmiInscripciones.Text = "Inscripciones";
            this.tsmiInscripciones.Visible = false;
            // 
            // tsmiInscribirseACurso
            // 
            this.tsmiInscribirseACurso.Name = "tsmiInscribirseACurso";
            this.tsmiInscribirseACurso.Size = new System.Drawing.Size(229, 26);
            this.tsmiInscribirseACurso.Text = "Inscribirse a un curso";
            this.tsmiInscribirseACurso.Visible = false;
            this.tsmiInscribirseACurso.Click += new System.EventHandler(this.tsmiInscribirAlumnoCurso_Click);
            // 
            // tsmiinscribirAlumnos
            // 
            this.tsmiinscribirAlumnos.Name = "tsmiinscribirAlumnos";
            this.tsmiinscribirAlumnos.Size = new System.Drawing.Size(229, 26);
            this.tsmiinscribirAlumnos.Text = "Inscribir alumnos";
            this.tsmiinscribirAlumnos.Click += new System.EventHandler(this.inscribirAlumnosToolStripMenuItem_Click);
            // 
            // tsmiInformes
            // 
            this.tsmiInformes.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiRegistroNotas,
            this.tsmiRegistroCursos});
            this.tsmiInformes.Name = "tsmiInformes";
            this.tsmiInformes.Size = new System.Drawing.Size(81, 24);
            this.tsmiInformes.Text = "Informes";
            this.tsmiInformes.Visible = false;
            // 
            // tsmiRegistroNotas
            // 
            this.tsmiRegistroNotas.Name = "tsmiRegistroNotas";
            this.tsmiRegistroNotas.Size = new System.Drawing.Size(189, 22);
            this.tsmiRegistroNotas.Text = "Planilla de notas";
            this.tsmiRegistroNotas.Click += new System.EventHandler(this.tsmiRegistroNotas_Click);
            // 
            // tsmiRegistroCursos
            // 
            this.tsmiRegistroCursos.Name = "tsmiRegistroCursos";
            this.tsmiRegistroCursos.Size = new System.Drawing.Size(189, 22);
            this.tsmiRegistroCursos.Text = "Planilla de Asistencias";
            this.tsmiRegistroCursos.Click += new System.EventHandler(this.tsmiRegistroCursos_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableLayoutPanel1.Controls.Add(this.pictureBox1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.TextoBienvenida, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.textoRol, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 28);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 49F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(708, 374);
            this.tableLayoutPanel1.TabIndex = 5;
            // 
            // pictureBox1
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.pictureBox1, 2);
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Image = global::UI.Desktop.Properties.Resources.img_20200206_wa0019_1;
            this.pictureBox1.Location = new System.Drawing.Point(4, 53);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(700, 321);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // TextoBienvenida
            // 
            this.TextoBienvenida.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.TextoBienvenida.AutoSize = true;
            this.TextoBienvenida.Location = new System.Drawing.Point(144, 16);
            this.TextoBienvenida.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.TextoBienvenida.Name = "TextoBienvenida";
            this.TextoBienvenida.Size = new System.Drawing.Size(136, 17);
            this.TextoBienvenida.TabIndex = 1;
            this.TextoBienvenida.Text = "Texto de bienvenida";
            // 
            // textoRol
            // 
            this.textoRol.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.textoRol.AutoSize = true;
            this.textoRol.Location = new System.Drawing.Point(621, 16);
            this.textoRol.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.textoRol.Name = "textoRol";
            this.textoRol.Size = new System.Drawing.Size(83, 17);
            this.textoRol.TabIndex = 2;
            this.textoRol.Text = "Texto de rol";
            // 
            // tsmiInscribirDocente
            // 
            this.tsmiInscribirDocente.Name = "tsmiInscribirDocente";
            this.tsmiInscribirDocente.Size = new System.Drawing.Size(229, 26);
            this.tsmiInscribirDocente.Text = "Inscribir docente";
            this.tsmiInscribirDocente.Visible = false;
            this.tsmiInscribirDocente.Click += new System.EventHandler(this.inscribirDocenteToolStripMenuItem_Click);
            // 
            // Menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(708, 402);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Menu";
            this.Text = "Menu";
            this.Load += new System.EventHandler(this.Menu_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem tsmiArchivo;
        private System.Windows.Forms.ToolStripMenuItem tsmiAlumnos;
        private System.Windows.Forms.ToolStripMenuItem nuevoAlumnoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem verAlumnosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tsmiDocentes;
        private System.Windows.Forms.ToolStripMenuItem nuevoDocenteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem verDocentesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tsmiPersonas;
        private System.Windows.Forms.ToolStripMenuItem nuevaPersonaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem verPersonasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tsmiUsuarios;
        private System.Windows.Forms.ToolStripMenuItem crearUsuarioToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem verUsuariosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tsmiEspecialidades;
        private System.Windows.Forms.ToolStripMenuItem nuevaEspecialidadToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem verEspecialidadesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tsmiPlanes;
        private System.Windows.Forms.ToolStripMenuItem nuevoPlanToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem verPlanesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tsmiMaterias;
        private System.Windows.Forms.ToolStripMenuItem nuevaMateriaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem verMateriasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tsmiComisiones;
        private System.Windows.Forms.ToolStripMenuItem nuevaComisiónToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem verComisionesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tsmiCursos;
        private System.Windows.Forms.ToolStripMenuItem nuevoCursoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem verCursosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tsmiInscripciones;
        private System.Windows.Forms.ToolStripMenuItem tsmiInscribirseACurso;
        private System.Windows.Forms.ToolStripMenuItem tsmiInformes;
        private System.Windows.Forms.ToolStripMenuItem tsmiRegistroNotas;
        private System.Windows.Forms.ToolStripMenuItem tsmiRegistroCursos;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label TextoBienvenida;
        private System.Windows.Forms.Label textoRol;
        private System.Windows.Forms.ToolStripMenuItem tsmiinscribirAlumnos;
        private System.Windows.Forms.ToolStripMenuItem tsmiInscribirDocente;
    }
}