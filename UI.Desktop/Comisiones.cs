using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms;
using Business.Entities;
using Business.Logic;

namespace UI.Desktop
{
    public partial class Comisiones : Form
    {
        public Comisiones()
        {
            InitializeComponent();
        }

        private void tsComision_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void dgvComision_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        public void Listar()
        {
            ComisionLogic ul = new ComisionLogic();
            this.dgvComision.DataSource = ul.GetAll();
        }

        private void Comisiones_Load(object sender, EventArgs e)
        {
            Listar();
        }

        private void bntActualizar_Click(object sender, EventArgs e)
        {
            Listar();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAgregarComision_Click(object sender, EventArgs e)
        {
            ComisionDesktop comDesk = new ComisionDesktop(ApplicationForm.ModoForm.Alta);
            comDesk.ShowDialog();
            this.Listar();
        }
    }
}
