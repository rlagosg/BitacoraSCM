namespace CapaPresentacion.Pantallas.Personas
{
    partial class Personas
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Personas));
            this.gunaGradientButton1 = new Guna.UI.WinForms.GunaGradientButton();
            this.gunaGradientButton2 = new Guna.UI.WinForms.GunaGradientButton();
            this.Data = new Guna.UI.WinForms.GunaDataGridView();
            this.TXTBUSCA = new Guna.UI.WinForms.GunaTextBox();
            this.gunaButton1 = new Guna.UI.WinForms.GunaButton();
            this.btnLimpiar = new Guna.UI.WinForms.GunaCircleButton();
            ((System.ComponentModel.ISupportInitialize)(this.Data)).BeginInit();
            this.SuspendLayout();
            // 
            // gunaGradientButton1
            // 
            this.gunaGradientButton1.AnimationHoverSpeed = 0.07F;
            this.gunaGradientButton1.AnimationSpeed = 0.03F;
            this.gunaGradientButton1.BackColor = System.Drawing.Color.Transparent;
            this.gunaGradientButton1.BaseColor1 = System.Drawing.Color.Red;
            this.gunaGradientButton1.BaseColor2 = System.Drawing.Color.Pink;
            this.gunaGradientButton1.BorderColor = System.Drawing.Color.Black;
            this.gunaGradientButton1.DialogResult = System.Windows.Forms.DialogResult.None;
            this.gunaGradientButton1.FocusedColor = System.Drawing.Color.Empty;
            this.gunaGradientButton1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.gunaGradientButton1.ForeColor = System.Drawing.Color.White;
            this.gunaGradientButton1.Image = null;
            this.gunaGradientButton1.ImageSize = new System.Drawing.Size(20, 20);
            this.gunaGradientButton1.Location = new System.Drawing.Point(1205, 62);
            this.gunaGradientButton1.Margin = new System.Windows.Forms.Padding(2);
            this.gunaGradientButton1.Name = "gunaGradientButton1";
            this.gunaGradientButton1.OnHoverBaseColor1 = System.Drawing.Color.DarkRed;
            this.gunaGradientButton1.OnHoverBaseColor2 = System.Drawing.Color.Red;
            this.gunaGradientButton1.OnHoverBorderColor = System.Drawing.Color.Black;
            this.gunaGradientButton1.OnHoverForeColor = System.Drawing.Color.White;
            this.gunaGradientButton1.OnHoverImage = null;
            this.gunaGradientButton1.OnPressedColor = System.Drawing.Color.Black;
            this.gunaGradientButton1.Radius = 10;
            this.gunaGradientButton1.Size = new System.Drawing.Size(102, 26);
            this.gunaGradientButton1.TabIndex = 18;
            this.gunaGradientButton1.Text = "eliminar";
            this.gunaGradientButton1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.gunaGradientButton1.Click += new System.EventHandler(this.gunaGradientButton1_Click);
            // 
            // gunaGradientButton2
            // 
            this.gunaGradientButton2.AnimationHoverSpeed = 0.07F;
            this.gunaGradientButton2.AnimationSpeed = 0.03F;
            this.gunaGradientButton2.BackColor = System.Drawing.Color.Transparent;
            this.gunaGradientButton2.BaseColor1 = System.Drawing.Color.DeepPink;
            this.gunaGradientButton2.BaseColor2 = System.Drawing.Color.Pink;
            this.gunaGradientButton2.BorderColor = System.Drawing.Color.Black;
            this.gunaGradientButton2.DialogResult = System.Windows.Forms.DialogResult.None;
            this.gunaGradientButton2.FocusedColor = System.Drawing.Color.Empty;
            this.gunaGradientButton2.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.gunaGradientButton2.ForeColor = System.Drawing.Color.White;
            this.gunaGradientButton2.Image = null;
            this.gunaGradientButton2.ImageSize = new System.Drawing.Size(20, 20);
            this.gunaGradientButton2.Location = new System.Drawing.Point(1081, 62);
            this.gunaGradientButton2.Margin = new System.Windows.Forms.Padding(2);
            this.gunaGradientButton2.Name = "gunaGradientButton2";
            this.gunaGradientButton2.OnHoverBaseColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(79)))), ((int)(((byte)(103)))));
            this.gunaGradientButton2.OnHoverBaseColor2 = System.Drawing.Color.MediumVioletRed;
            this.gunaGradientButton2.OnHoverBorderColor = System.Drawing.Color.Black;
            this.gunaGradientButton2.OnHoverForeColor = System.Drawing.Color.White;
            this.gunaGradientButton2.OnHoverImage = null;
            this.gunaGradientButton2.OnPressedColor = System.Drawing.Color.Black;
            this.gunaGradientButton2.Radius = 10;
            this.gunaGradientButton2.Size = new System.Drawing.Size(102, 26);
            this.gunaGradientButton2.TabIndex = 17;
            this.gunaGradientButton2.Text = "nuevo";
            this.gunaGradientButton2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.gunaGradientButton2.Click += new System.EventHandler(this.gunaGradientButton2_Click);
            // 
            // Data
            // 
            this.Data.AllowUserToAddRows = false;
            this.Data.AllowUserToDeleteRows = false;
            this.Data.AllowUserToOrderColumns = true;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            this.Data.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.Data.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.Data.BackgroundColor = System.Drawing.Color.White;
            this.Data.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Data.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.Data.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(79)))), ((int)(((byte)(103)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(79)))), ((int)(((byte)(103)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.Data.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.Data.ColumnHeadersHeight = 40;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(248)))), ((int)(((byte)(249)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(77)))), ((int)(((byte)(100)))), ((int)(((byte)(132)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.Data.DefaultCellStyle = dataGridViewCellStyle3;
            this.Data.EnableHeadersVisualStyles = false;
            this.Data.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(248)))), ((int)(((byte)(249)))));
            this.Data.Location = new System.Drawing.Point(32, 104);
            this.Data.Margin = new System.Windows.Forms.Padding(2);
            this.Data.Name = "Data";
            this.Data.ReadOnly = true;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(79)))), ((int)(((byte)(103)))));
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(79)))), ((int)(((byte)(103)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.Data.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.Data.RowHeadersVisible = false;
            this.Data.RowHeadersWidth = 51;
            this.Data.RowTemplate.Height = 35;
            this.Data.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.Data.Size = new System.Drawing.Size(1275, 511);
            this.Data.TabIndex = 16;
            this.Data.Theme = Guna.UI.WinForms.GunaDataGridViewPresetThemes.White;
            this.Data.ThemeStyle.AlternatingRowsStyle.BackColor = System.Drawing.Color.White;
            this.Data.ThemeStyle.AlternatingRowsStyle.Font = null;
            this.Data.ThemeStyle.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Empty;
            this.Data.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.Empty;
            this.Data.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Empty;
            this.Data.ThemeStyle.BackColor = System.Drawing.Color.White;
            this.Data.ThemeStyle.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(248)))), ((int)(((byte)(249)))));
            this.Data.ThemeStyle.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(79)))), ((int)(((byte)(103)))));
            this.Data.ThemeStyle.HeaderStyle.BorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.Data.ThemeStyle.HeaderStyle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Data.ThemeStyle.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.Data.ThemeStyle.HeaderStyle.HeaightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            this.Data.ThemeStyle.HeaderStyle.Height = 40;
            this.Data.ThemeStyle.ReadOnly = true;
            this.Data.ThemeStyle.RowsStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(248)))), ((int)(((byte)(249)))));
            this.Data.ThemeStyle.RowsStyle.BorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.Data.ThemeStyle.RowsStyle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Data.ThemeStyle.RowsStyle.ForeColor = System.Drawing.Color.Black;
            this.Data.ThemeStyle.RowsStyle.Height = 35;
            this.Data.ThemeStyle.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(77)))), ((int)(((byte)(100)))), ((int)(((byte)(132)))));
            this.Data.ThemeStyle.RowsStyle.SelectionForeColor = System.Drawing.Color.White;
            this.Data.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Data_CellContentClick);
            this.Data.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Data_CellDoubleClick);
            // 
            // TXTBUSCA
            // 
            this.TXTBUSCA.BackColor = System.Drawing.Color.Transparent;
            this.TXTBUSCA.BaseColor = System.Drawing.Color.White;
            this.TXTBUSCA.BorderColor = System.Drawing.Color.Silver;
            this.TXTBUSCA.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.TXTBUSCA.FocusedBaseColor = System.Drawing.Color.White;
            this.TXTBUSCA.FocusedBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(79)))), ((int)(((byte)(103)))));
            this.TXTBUSCA.FocusedForeColor = System.Drawing.SystemColors.ControlText;
            this.TXTBUSCA.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TXTBUSCA.Location = new System.Drawing.Point(32, 56);
            this.TXTBUSCA.Margin = new System.Windows.Forms.Padding(2);
            this.TXTBUSCA.Name = "TXTBUSCA";
            this.TXTBUSCA.PasswordChar = '\0';
            this.TXTBUSCA.Radius = 5;
            this.TXTBUSCA.SelectedText = "";
            this.TXTBUSCA.Size = new System.Drawing.Size(486, 32);
            this.TXTBUSCA.TabIndex = 0;
            this.TXTBUSCA.TextChanged += new System.EventHandler(this.TXTBUSCA_TextChanged);
            // 
            // gunaButton1
            // 
            this.gunaButton1.AnimationHoverSpeed = 0.07F;
            this.gunaButton1.AnimationSpeed = 0.03F;
            this.gunaButton1.BackColor = System.Drawing.Color.Transparent;
            this.gunaButton1.BaseColor = System.Drawing.Color.White;
            this.gunaButton1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(79)))), ((int)(((byte)(103)))));
            this.gunaButton1.DialogResult = System.Windows.Forms.DialogResult.None;
            this.gunaButton1.FocusedColor = System.Drawing.Color.Empty;
            this.gunaButton1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.gunaButton1.ForeColor = System.Drawing.Color.White;
            this.gunaButton1.Image = ((System.Drawing.Image)(resources.GetObject("gunaButton1.Image")));
            this.gunaButton1.ImageAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.gunaButton1.ImageSize = new System.Drawing.Size(35, 35);
            this.gunaButton1.Location = new System.Drawing.Point(518, 52);
            this.gunaButton1.Name = "gunaButton1";
            this.gunaButton1.OnHoverBaseColor = System.Drawing.Color.Pink;
            this.gunaButton1.OnHoverBorderColor = System.Drawing.Color.Black;
            this.gunaButton1.OnHoverForeColor = System.Drawing.Color.White;
            this.gunaButton1.OnHoverImage = null;
            this.gunaButton1.OnPressedColor = System.Drawing.Color.Black;
            this.gunaButton1.Radius = 20;
            this.gunaButton1.Size = new System.Drawing.Size(40, 40);
            this.gunaButton1.TabIndex = 49;
            this.gunaButton1.Click += new System.EventHandler(this.gunaButton1_Click);
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.AnimationHoverSpeed = 0.07F;
            this.btnLimpiar.AnimationSpeed = 0.03F;
            this.btnLimpiar.BaseColor = System.Drawing.Color.White;
            this.btnLimpiar.BorderColor = System.Drawing.Color.Transparent;
            this.btnLimpiar.DialogResult = System.Windows.Forms.DialogResult.None;
            this.btnLimpiar.FocusedColor = System.Drawing.Color.Empty;
            this.btnLimpiar.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnLimpiar.ForeColor = System.Drawing.Color.White;
            this.btnLimpiar.Image = ((System.Drawing.Image)(resources.GetObject("btnLimpiar.Image")));
            this.btnLimpiar.ImageSize = new System.Drawing.Size(20, 20);
            this.btnLimpiar.Location = new System.Drawing.Point(488, 60);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.OnHoverBaseColor = System.Drawing.Color.White;
            this.btnLimpiar.OnHoverBorderColor = System.Drawing.Color.Black;
            this.btnLimpiar.OnHoverForeColor = System.Drawing.Color.White;
            this.btnLimpiar.OnHoverImage = null;
            this.btnLimpiar.OnPressedColor = System.Drawing.Color.Black;
            this.btnLimpiar.Size = new System.Drawing.Size(25, 25);
            this.btnLimpiar.TabIndex = 85;
            this.btnLimpiar.Click += new System.EventHandler(this.gunaCircleButton1_Click);
            // 
            // Personas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1338, 649);
            this.Controls.Add(this.btnLimpiar);
            this.Controls.Add(this.gunaButton1);
            this.Controls.Add(this.TXTBUSCA);
            this.Controls.Add(this.gunaGradientButton1);
            this.Controls.Add(this.gunaGradientButton2);
            this.Controls.Add(this.Data);
            this.Name = "Personas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Personas";
            this.Load += new System.EventHandler(this.Personas_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Data)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Guna.UI.WinForms.GunaGradientButton gunaGradientButton1;
        private Guna.UI.WinForms.GunaGradientButton gunaGradientButton2;
        private Guna.UI.WinForms.GunaDataGridView Data;
        private Guna.UI.WinForms.GunaTextBox TXTBUSCA;
        private Guna.UI.WinForms.GunaButton gunaButton1;
        private Guna.UI.WinForms.GunaCircleButton btnLimpiar;
    }
}