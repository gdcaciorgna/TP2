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
    public partial class Cursos : Form
    {
        public Cursos()
        {
            InitializeComponent();
            dgvCursos.AutoGenerateColumns = false;
        }

        public void Listar()
        {
            CursoLogic cl = new CursoLogic();

            try
            {
                this.dgvCursos.DataSource = cl.GetAll();
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Cursos_Load(object sender, EventArgs e)
        {
            Listar();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            Listar();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tsbNuevo_Click(object sender, EventArgs e)
        {
            CursosDesktop cursosDesk = new CursosDesktop();
            cursosDesk.ShowDialog();
            this.Listar();
        }

        private void tsbEditar_Click(object sender, EventArgs e)
        {
            try
            {

                int ID = ((Curso)this.dgvCursos.SelectedRows[0].DataBoundItem).ID;

                CursosDesktop espDesk = new CursosDesktop(ID, ApplicationForm.ModoForm.Modificacion);

                espDesk.ShowDialog();
                this.Listar();
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void tsbEliminar_Click(object sender, EventArgs e)
        {
            try
            {

                int ID = ((Curso)this.dgvCursos.SelectedRows[0].DataBoundItem).ID;

                CursosDesktop espDesk = new CursosDesktop(ID, ApplicationForm.ModoForm.Baja);

                espDesk.ShowDialog();
                this.Listar();
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
    }
}
