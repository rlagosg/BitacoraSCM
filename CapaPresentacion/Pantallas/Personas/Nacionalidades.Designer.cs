
namespace CapaPresentacion
{
    partial class Nacionalidades
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btnNuevo = new Guna.UI.WinForms.GunaGradientButton();
            this.TXTBUSCA = new Guna.UI.WinForms.GunaTextBox();
            this.DataNac = new Guna.UI.WinForms.GunaDataGridView();
            this.btnEliminar = new Guna.UI.WinForms.GunaGradientButton();
            this.btnSeleccionar = new Guna.UI.WinForms.GunaGradientButton();
            ((System.ComponentModel.ISupportInitialize)(this.DataNac)).BeginInit();
            this.SuspendLayout();
            // 
            // btnNuevo
            // 
            this.btnNuevo.AnimationHoverSpeed = 0.07F;
            this.btnNuevo.AnimationSpeed = 0.03F;
            this.btnNuevo.BackColor = System.Drawing.Color.Transparent;
            this.btnNuevo.BaseColor1 = System.Drawing.Color.DeepPink;
            this.btnNuevo.BaseColor2 = System.Drawing.Color.Pink;
            this.btnNuevo.BorderColor = System.Drawing.Color.Black;
            this.btnNuevo.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnNuevo.FocusedColor = System.Drawing.Color.Empty;
            this.btnNuevo.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnNuevo.ForeColor = System.Drawing.Color.White;
            this.btnNuevo.Image = null;
            this.btnNuevo.ImageSize = new System.Drawing.Size(20, 20);
            this.btnNuevo.Location = new System.Drawing.Point(627, 59);
            this.btnNuevo.Margin = new System.Windows.Forms.Padding(2);
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.OnHoverBaseColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(79)))), ((int)(((byte)(103)))));
            this.btnNuevo.OnHoverBaseColor2 = System.Drawing.Color.MediumVioletRed;
            this.btnNuevo.OnHoverBorderColor = System.Drawing.Color.Black;
            this.btnNuevo.OnHoverForeColor = System.Drawing.Color.White;
            this.btnNuevo.OnHoverImage = null;
            this.btnNuevo.OnPressedColor = System.Drawing.Color.Black;
            this.btnNuevo.Radius = 10;
            this.btnNuevo.Size = new System.Drawing.Size(102, 32);
            this.btnNuevo.TabIndex = 14;
            this.btnNuevo.Text = "nuevo";
            this.btnNuevo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.btnNuevo.Click += new System.EventHandler(this.gunaGradientButton2_Click_1);
            // 
            // TXTBUSCA
            // 
            this.TXTBUSCA.BackColor = System.Drawing.Color.Transparent;
            this.TXTBUSCA.BaseColor = System.Drawing.Color.White;
            this.TXTBUSCA.BorderColor = System.Drawing.Color.Silver;
            this.TXTBUSCA.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.TXTBUSCA.FocusedBaseColor = System.Drawing.Color.White;
            this.TXTBUSCA.FocusedBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.TXTBUSCA.FocusedForeColor = System.Drawing.SystemColors.ControlText;
            this.TXTBUSCA.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TXTBUSCA.Location = new System.Drawing.Point(42, 59);
            this.TXTBUSCA.Margin = new System.Windows.Forms.Padding(2);
            this.TXTBUSCA.Name = "TXTBUSCA";
            this.TXTBUSCA.PasswordChar = '\0';
            this.TXTBUSCA.Radius = 10;
            this.TXTBUSCA.SelectedText = "";
            this.TXTBUSCA.Size = new System.Drawing.Size(360, 32);
            this.TXTBUSCA.TabIndex = 0;
            this.TXTBUSCA.TextChanged += new System.EventHandler(this.TXTBUSCA_TextChanged);
            // 
            // DataNac
            // 
            this.DataNac.AllowUserToAddRows = false;
            this.DataNac.AllowUserToDeleteRows = false;
            this.DataNac.AllowUserToOrderColumns = true;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            this.DataNac.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.DataNac.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DataNac.BackgroundColor = System.Drawing.Color.White;
            this.DataNac.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.DataNac.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.DataNac.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(79)))), ((int)(((byte)(103)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(79)))), ((int)(((byte)(103)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DataNac.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.DataNac.ColumnHeadersHeight = 40;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(248)))), ((int)(((byte)(249)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(77)))), ((int)(((byte)(100)))), ((int)(((byte)(132)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DataNac.DefaultCellStyle = dataGridViewCellStyle3;
            this.DataNac.EnableHeadersVisualStyles = false;
            this.DataNac.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(248)))), ((int)(((byte)(249)))));
            this.DataNac.Location = new System.Drawing.Point(42, 104);
            this.DataNac.Margin = new System.Windows.Forms.Padding(2);
            this.DataNac.Name = "DataNac";
            this.DataNac.ReadOnly = true;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(79)))), ((int)(((byte)(103)))));
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(79)))), ((int)(((byte)(103)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DataNac.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.DataNac.RowHeadersVisible = false;
            this.DataNac.RowHeadersWidth = 51;
            this.DataNac.RowTemplate.Height = 35;
            this.DataNac.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DataNac.Size = new System.Drawing.Size(811, 425);
            this.DataNac.TabIndex = 12;
            this.DataNac.Theme = Guna.UI.WinForms.GunaDataGridViewPresetThemes.White;
            this.DataNac.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.DataNac.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.DataNac.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.DataNac.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.DataNac.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.DataNac.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.DataNac.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(248)))), ((int)(((byte)(249)))));
            this.DataNac.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(79)))), ((int)(((byte)(103)))));
            this.DataNac.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.DataNac.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DataNac.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.DataNac.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.DataNac.ThemeStyle.HeaderStyle.Height = 40;
            this.DataNac.ThemeStyle.ReadOnly = true;
            this.DataNac.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(248)))), ((int)(((byte)(249)))));
            this.DataNac.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.DataNac.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DataNac.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.Black;
            this.DataNac.ThemeStyle.RowsStyle.Height = 35;
            this.DataNac.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(77)))), ((int)(((byte)(100)))), ((int)(((byte)(132)))));
            this.DataNac.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.White;
            this.DataNac.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataNac_CellContentClick);
            this.DataNac.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataNac_CellDoubleClick);
            // 
            // btnEliminar
            // 
            this.btnEliminar.AnimationHoverSpeed = 0.07F;
            this.btnEliminar.AnimationSpeed = 0.03F;
            this.btnEliminar.BackColor = System.Drawing.Color.Transparent;
            this.btnEliminar.BaseColor1 = System.Drawing.Color.Red;
            this.btnEliminar.BaseColor2 = System.Drawing.Color.Pink;
            this.btnEliminar.BorderColor = System.Drawing.Color.Black;
            this.btnEliminar.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnEliminar.FocusedColor = System.Drawing.Color.Empty;
            this.btnEliminar.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnEliminar.ForeColor = System.Drawing.Color.White;
            this.btnEliminar.Image = null;
            this.btnEliminar.ImageSize = new System.Drawing.Size(20, 20);
            this.btnEliminar.Location = new System.Drawing.Point(751, 59);
            this.btnEliminar.Margin = new System.Windows.Forms.Padding(2);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.OnHoverBaseColor1 = System.Drawing.Color.DarkRed;
            this.btnEliminar.OnHoverBaseColor2 = System.Drawing.Color.Red;
            this.btnEliminar.OnHoverBorderColor = System.Drawing.Color.Black;
            this.btnEliminar.OnHoverForeColor = System.Drawing.Color.White;
            this.btnEliminar.OnHoverImage = null;
            this.btnEliminar.OnPressedColor = System.Drawing.Color.Black;
            this.btnEliminar.Radius = 10;
            this.btnEliminar.Size = new System.Drawing.Size(102, 32);
            this.btnEliminar.TabIndex = 15;
            this.btnEliminar.Text = "eliminar";
            this.btnEliminar.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.btnEliminar.Click += new System.EventHandler(this.gunaGradientButton1_Click_1);
            // 
            // btnSeleccionar
            // 
            this.btnSeleccionar.AnimationHoverSpeed = 0.07F;
            this.btnSeleccionar.AnimationSpeed = 0.03F;
            this.btnSeleccionar.BackColor = System.Drawing.Color.Transparent;
            this.btnSeleccionar.BaseColor1 = System.Drawing.Color.DeepPink;
            this.btnSeleccionar.BaseColor2 = System.Drawing.Color.Pink;
            this.btnSeleccionar.BorderColor = System.Drawing.Color.Black;
            this.btnSeleccionar.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnSeleccionar.FocusedColor = System.Drawing.Color.Empty;
            this.btnSeleccionar.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnSeleccionar.ForeColor = System.Drawing.Color.White;
            this.btnSeleccionar.Image = null;
            this.btnSeleccionar.ImageSize = new System.Drawing.Size(20, 20);
            this.btnSeleccionar.Location = new System.Drawing.Point(406, 59);
            this.btnSeleccionar.Margin = new System.Windows.Forms.Padding(2);
            this.btnSeleccionar.Name = "btnSeleccionar";
            this.btnSeleccionar.OnHoverBaseColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(79)))), ((int)(((byte)(103)))));
            this.btnSeleccionar.OnHoverBaseColor2 = System.Drawing.Color.MediumVioletRed;
            this.btnSeleccionar.OnHoverBorderColor = System.Drawing.Color.Black;
            this.btnSeleccionar.OnHoverForeColor = System.Drawing.Color.White;
            this.btnSeleccionar.OnHoverImage = null;
            this.btnSeleccionar.OnPressedColor = System.Drawing.Color.Black;
            this.btnSeleccionar.Radius = 10;
            this.btnSeleccionar.Size = new System.Drawing.Size(102, 32);
            this.btnSeleccionar.TabIndex = 16;
            this.btnSeleccionar.Text = "Seleccionar";
            this.btnSeleccionar.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.btnSeleccionar.Click += new System.EventHandler(this.btnSeleccionar_Click);
            // 
            // Nacionalidades
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(894, 572);
            this.Controls.Add(this.btnSeleccionar);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.btnNuevo);
            this.Controls.Add(this.TXTBUSCA);
            this.Controls.Add(this.DataNac);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Nacionalidades";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Nacionalidades";
            this.Load += new System.EventHandler(this.Nacionalidades_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DataNac)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI.WinForms.GunaGradientButton btnNuevo;
        private Guna.UI.WinForms.GunaTextBox TXTBUSCA;
        private Guna.UI.WinForms.GunaDataGridView DataNac;
        private Guna.UI.WinForms.GunaGradientButton btnEliminar;
        private Guna.UI.WinForms.GunaGradientButton btnSeleccionar;
    }
}