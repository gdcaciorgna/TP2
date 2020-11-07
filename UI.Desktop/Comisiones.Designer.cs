namespace UI.Desktop
{
    partial class Comisiones
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Comisiones));
            this.tscComision = new System.Windows.Forms.ToolStripContainer();
            this.tlComision = new System.Windows.Forms.TableLayoutPanel();
            this.dgvComision = new System.Windows.Forms.DataGridView();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Descripcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IDPlan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AnioEspecialidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bntActualizar = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            this.tsComision = new System.Windows.Forms.ToolStrip();
            this.btnAgregarComision = new System.Windows.Forms.ToolStripButton();
            this.btnEditarComision = new System.Windows.Forms.ToolStripButton();
            this.btnEliminarComision = new System.Windows.Forms.ToolStripButton();
            this.tscComision.ContentPanel.SuspendLayout();
            this.tscComision.TopToolStripPanel.SuspendLayout();
            this.tscComision.SuspendLayout();
            this.tlComision.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvComision)).BeginInit();
            this.tsComision.SuspendLayout();
            this.SuspendLayout();
            // 
            // tscComision
            // 
            // 
            // tscComision.ContentPanel
            // 
            this.tscComision.ContentPanel.Controls.Add(this.tlComision);
            this.tscComision.ContentPanel.Margin = new System.Windows.Forms.Padding(2);
            this.tscComision.ContentPanel.Size = new System.Drawing.Size(600, 339);
            this.tscComision.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tscComision.Location = new System.Drawing.Point(0, 0);
            this.tscComision.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tscComision.Name = "tscComision";
            this.tscComision.Size = new System.Drawing.Size(600, 366);
            this.tscComision.TabIndex = 0;
            this.tscComision.Text = "toolStripContainer1";
            // 
            // tscComision.TopToolStripPanel
            // 
            this.tscComision.TopToolStripPanel.Controls.Add(this.tsComision);
            // 
            // tlComision
            // 
            this.tlComision.ColumnCount = 2;
            this.tlComision.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlComision.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlComision.Controls.Add(this.dgvComision, 0, 0);
            this.tlComision.Controls.Add(this.bntActualizar, 0, 1);
            this.tlComision.Controls.Add(this.btnSalir, 1, 1);
            this.tlComision.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlComision.Location = new System.Drawing.Point(0, 0);
            this.tlComision.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tlComision.Name = "tlComision";
            this.tlComision.RowCount = 2;
            this.tlComision.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlComision.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlComision.Size = new System.Drawing.Size(600, 339);
            this.tlComision.TabIndex = 0;
            // 
            // dgvComision
            // 
            this.dgvComision.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvComision.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.Descripcion,
            this.IDPlan,
            this.AnioEspecialidad});
            this.tlComision.SetColumnSpan(this.dgvComision, 2);
            this.dgvComision.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvComision.Location = new System.Drawing.Point(2, 2);
            this.dgvComision.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dgvComision.Name = "dgvComision";
            this.dgvComision.RowHeadersWidth = 51;
            this.dgvComision.RowTemplate.Height = 24;
            this.dgvComision.Size = new System.Drawing.Size(596, 312);
            this.dgvComision.TabIndex = 0;
            // 
            // ID
            // 
            this.ID.DataPropertyName = "ID";
            this.ID.HeaderText = "Id comision";
            this.ID.MinimumWidth = 6;
            this.ID.Name = "ID";
            this.ID.Width = 125;
            // 
            // Descripcion
            // 
            this.Descripcion.DataPropertyName = "Descripcion";
            this.Descripcion.HeaderText = "Descripcion";
            this.Descripcion.MinimumWidth = 6;
            this.Descripcion.Name = "Descripcion";
            this.Descripcion.Width = 125;
            // 
            // IDPlan
            // 
            this.IDPlan.DataPropertyName = "IDPlan";
            this.IDPlan.HeaderText = "Id plan";
            this.IDPlan.MinimumWidth = 6;
            this.IDPlan.Name = "IDPlan";
            this.IDPlan.Width = 125;
            // 
            // AnioEspecialidad
            // 
            this.AnioEspecialidad.DataPropertyName = "AnioEspecialidad";
            this.AnioEspecialidad.HeaderText = "Año especialidad";
            this.AnioEspecialidad.MinimumWidth = 6;
            this.AnioEspecialidad.Name = "AnioEspecialidad";
            this.AnioEspecialidad.Width = 125;
            // 
            // bntActualizar
            // 
            this.bntActualizar.Dock = System.Windows.Forms.DockStyle.Right;
            this.bntActualizar.Location = new System.Drawing.Point(482, 318);
            this.bntActualizar.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.bntActualizar.Name = "bntActualizar";
            this.bntActualizar.Size = new System.Drawing.Size(56, 19);
            this.bntActualizar.TabIndex = 1;
            this.bntActualizar.Text = "Actualizar";
            this.bntActualizar.UseVisualStyleBackColor = true;
            this.bntActualizar.Click += new System.EventHandler(this.bntActualizar_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.Location = new System.Drawing.Point(542, 318);
            this.btnSalir.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(56, 19);
            this.btnSalir.TabIndex = 2;
            this.btnSalir.Text = "Salir";
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // tsComision
            // 
            this.tsComision.Dock = System.Windows.Forms.DockStyle.None;
            this.tsComision.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.tsComision.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnAgregarComision,
            this.btnEditarComision,
            this.btnEliminarComision});
            this.tsComision.Location = new System.Drawing.Point(5, 0);
            this.tsComision.Name = "tsComision";
            this.tsComision.Size = new System.Drawing.Size(115, 27);
            this.tsComision.TabIndex = 0;
            this.tsComision.Text = "toolStrip1";
            // 
            // btnAgregarComision
            // 
            this.btnAgregarComision.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnAgregarComision.Image = ((System.Drawing.Image)(resources.GetObject("btnAgregarComision.Image")));
            this.btnAgregarComision.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAgregarComision.Name = "btnAgregarComision";
            this.btnAgregarComision.Size = new System.Drawing.Size(24, 24);
            this.btnAgregarComision.Text = "Agregar";
            this.btnAgregarComision.Click += new System.EventHandler(this.btnAgregarComision_Click);
            // 
            // btnEditarComision
            // 
            this.btnEditarComision.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnEditarComision.Image = ((System.Drawing.Image)(resources.GetObject("btnEditarComision.Image")));
            this.btnEditarComision.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnEditarComision.Name = "btnEditarComision";
            this.btnEditarComision.Size = new System.Drawing.Size(24, 24);
            this.btnEditarComision.Text = "Editar";
            this.btnEditarComision.Click += new System.EventHandler(this.btnEditarComision_Click_1);
            // 
            // btnEliminarComision
            // 
            this.btnEliminarComision.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnEliminarComision.Image = ((System.Drawing.Image)(resources.GetObject("btnEliminarComision.Image")));
            this.btnEliminarComision.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnEliminarComision.Name = "btnEliminarComision";
            this.btnEliminarComision.Size = new System.Drawing.Size(24, 24);
            this.btnEliminarComision.Text = "Eliminar";
            this.btnEliminarComision.Click += new System.EventHandler(this.btnEliminarComision_Click_1);
            // 
            // Comisiones
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 366);
            this.Controls.Add(this.tscComision);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "Comisiones";
            this.Text = "Comisiones";
            this.Load += new System.EventHandler(this.Comisiones_Load);
            this.tscComision.ContentPanel.ResumeLayout(false);
            this.tscComision.TopToolStripPanel.ResumeLayout(false);
            this.tscComision.TopToolStripPanel.PerformLayout();
            this.tscComision.ResumeLayout(false);
            this.tscComision.PerformLayout();
            this.tlComision.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvComision)).EndInit();
            this.tsComision.ResumeLayout(false);
            this.tsComision.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolStripContainer tscComision;
        private System.Windows.Forms.TableLayoutPanel tlComision;
        private System.Windows.Forms.ToolStrip tsComision;
        private System.Windows.Forms.DataGridView dgvComision;
        private System.Windows.Forms.Button bntActualizar;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.ToolStripButton btnAgregarComision;
        private System.Windows.Forms.ToolStripButton btnEditarComision;
        private System.Windows.Forms.ToolStripButton btnEliminarComision;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Descripcion;
        private System.Windows.Forms.DataGridViewTextBoxColumn IDPlan;
        private System.Windows.Forms.DataGridViewTextBoxColumn AnioEspecialidad;
    }
}