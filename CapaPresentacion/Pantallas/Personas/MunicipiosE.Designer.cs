namespace CapaPresentacion.Pantallas.Personas
{
    partial class MunicipiosE
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
            this.BTNSALVAR = new Guna.UI.WinForms.GunaGradientButton();
            this.TXTDESCRIPCION = new Guna.UI.WinForms.GunaTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.TXTNOMBRE = new Guna.UI.WinForms.GunaTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // BTNSALVAR
            // 
            this.BTNSALVAR.AnimationHoverSpeed = 0.07F;
            this.BTNSALVAR.AnimationSpeed = 0.03F;
            this.BTNSALVAR.BackColor = System.Drawing.Color.Transparent;
            this.BTNSALVAR.BaseColor1 = System.Drawing.Color.DeepPink;
            this.BTNSALVAR.BaseColor2 = System.Drawing.Color.Pink;
            this.BTNSALVAR.BorderColor = System.Drawing.Color.Black;
            this.BTNSALVAR.DialogResult = System.Windows.Forms.DialogResult.None;
            this.BTNSALVAR.FocusedColor = System.Drawing.Color.Empty;
            this.BTNSALVAR.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.BTNSALVAR.ForeColor = System.Drawing.Color.White;
            this.BTNSALVAR.Image = null;
            this.BTNSALVAR.ImageSize = new System.Drawing.Size(20, 20);
            this.BTNSALVAR.Location = new System.Drawing.Point(241, 302);
            this.BTNSALVAR.Margin = new System.Windows.Forms.Padding(2);
            this.BTNSALVAR.Name = "BTNSALVAR";
            this.BTNSALVAR.OnHoverBaseColor1 = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(79)))), ((int)(((byte)(103)))));
            this.BTNSALVAR.OnHoverBaseColor2 = System.Drawing.Color.MediumVioletRed;
            this.BTNSALVAR.OnHoverBorderColor = System.Drawing.Color.Black;
            this.BTNSALVAR.OnHoverForeColor = System.Drawing.Color.White;
            this.BTNSALVAR.OnHoverImage = null;
            this.BTNSALVAR.OnPressedColor = System.Drawing.Color.Black;
            this.BTNSALVAR.Radius = 10;
            this.BTNSALVAR.Size = new System.Drawing.Size(227, 41);
            this.BTNSALVAR.TabIndex = 2;
            this.BTNSALVAR.Text = "Salvar";
            this.BTNSALVAR.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.BTNSALVAR.Click += new System.EventHandler(this.BTNSALVAR_Click);
            // 
            // TXTDESCRIPCION
            // 
            this.TXTDESCRIPCION.BackColor = System.Drawing.Color.Transparent;
            this.TXTDESCRIPCION.BaseColor = System.Drawing.Color.White;
            this.TXTDESCRIPCION.BorderColor = System.Drawing.Color.Silver;
            this.TXTDESCRIPCION.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.TXTDESCRIPCION.FocusedBaseColor = System.Drawing.Color.White;
            this.TXTDESCRIPCION.FocusedBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(79)))), ((int)(((byte)(103)))));
            this.TXTDESCRIPCION.FocusedForeColor = System.Drawing.SystemColors.ControlText;
            this.TXTDESCRIPCION.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TXTDESCRIPCION.Location = new System.Drawing.Point(67, 156);
            this.TXTDESCRIPCION.Margin = new System.Windows.Forms.Padding(2);
            this.TXTDESCRIPCION.MaxLength = 500;
            this.TXTDESCRIPCION.Multiline = true;
            this.TXTDESCRIPCION.Name = "TXTDESCRIPCION";
            this.TXTDESCRIPCION.PasswordChar = '\0';
            this.TXTDESCRIPCION.Radius = 5;
            this.TXTDESCRIPCION.SelectedText = "";
            this.TXTDESCRIPCION.Size = new System.Drawing.Size(562, 111);
            this.TXTDESCRIPCION.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(63, 134);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(92, 20);
            this.label2.TabIndex = 19;
            this.label2.Text = "Descripción";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(63, 51);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 20);
            this.label1.TabIndex = 18;
            this.label1.Text = "* Nombre";
            // 
            // TXTNOMBRE
            // 
            this.TXTNOMBRE.BackColor = System.Drawing.Color.Transparent;
            this.TXTNOMBRE.BaseColor = System.Drawing.Color.White;
            this.TXTNOMBRE.BorderColor = System.Drawing.Color.Silver;
            this.TXTNOMBRE.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.TXTNOMBRE.FocusedBaseColor = System.Drawing.Color.White;
            this.TXTNOMBRE.FocusedBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(79)))), ((int)(((byte)(103)))));
            this.TXTNOMBRE.FocusedForeColor = System.Drawing.SystemColors.ControlText;
            this.TXTNOMBRE.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TXTNOMBRE.Location = new System.Drawing.Point(66, 75);
            this.TXTNOMBRE.Margin = new System.Windows.Forms.Padding(2);
            this.TXTNOMBRE.MaxLength = 70;
            this.TXTNOMBRE.Name = "TXTNOMBRE";
            this.TXTNOMBRE.PasswordChar = '\0';
            this.TXTNOMBRE.Radius = 5;
            this.TXTNOMBRE.SelectedText = "";
            this.TXTNOMBRE.Size = new System.Drawing.Size(364, 32);
            this.TXTNOMBRE.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.label3.Location = new System.Drawing.Point(152, 133);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(78, 20);
            this.label3.TabIndex = 22;
            this.label3.Text = "(opcional)";
            // 
            // MunicipiosE
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(695, 373);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.BTNSALVAR);
            this.Controls.Add(this.TXTDESCRIPCION);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.TXTNOMBRE);
            this.Name = "MunicipiosE";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MunicipiosE";
            this.Load += new System.EventHandler(this.MunicipiosE_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Guna.UI.WinForms.GunaGradientButton BTNSALVAR;
        private Guna.UI.WinForms.GunaTextBox TXTDESCRIPCION;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private Guna.UI.WinForms.GunaTextBox TXTNOMBRE;
        private System.Windows.Forms.Label label3;
    }
}