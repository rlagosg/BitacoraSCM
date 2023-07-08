﻿namespace CapaPresentacion.Pantallas.Expedientes
{
    partial class Comentario
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
            this.components = new System.ComponentModel.Container();
            Guna.UI2.AnimatorNS.Animation animation7 = new Guna.UI2.AnimatorNS.Animation();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Comentario));
            Guna.UI2.AnimatorNS.Animation animation8 = new Guna.UI2.AnimatorNS.Animation();
            this.guna2ControlBox1 = new Guna.UI2.WinForms.Guna2ControlBox();
            this.guna2BorderlessForm1 = new Guna.UI2.WinForms.Guna2BorderlessForm(this.components);
            this.separator = new Guna.UI2.WinForms.Guna2Separator();
            this.label1 = new System.Windows.Forms.Label();
            this.btnComentar = new Guna.UI2.WinForms.Guna2Button();
            this.gunaGroupBox5 = new Guna.UI.WinForms.GunaGroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.guna2ComboBox1 = new Guna.UI2.WinForms.Guna2ComboBox();
            this.Switch = new Guna.UI2.WinForms.Guna2ToggleSwitch();
            this.TXTCOMENTARIO = new Guna.UI2.WinForms.Guna2TextBox();
            this.separador = new Guna.UI2.WinForms.Guna2Separator();
            this.labelSwitchOff = new System.Windows.Forms.Label();
            this.TransitionOn = new Guna.UI2.WinForms.Guna2Transition();
            this.labelSwitchOn = new System.Windows.Forms.Label();
            this.TransitionOff = new Guna.UI2.WinForms.Guna2Transition();
            this.gunaGroupBox5.SuspendLayout();
            this.SuspendLayout();
            // 
            // guna2ControlBox1
            // 
            this.guna2ControlBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.guna2ControlBox1.BackColor = System.Drawing.Color.White;
            this.guna2ControlBox1.BorderRadius = 20;
            this.guna2ControlBox1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.TransitionOff.SetDecoration(this.guna2ControlBox1, Guna.UI2.AnimatorNS.DecorationType.None);
            this.TransitionOn.SetDecoration(this.guna2ControlBox1, Guna.UI2.AnimatorNS.DecorationType.None);
            this.guna2ControlBox1.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(230)))), ((int)(((byte)(233)))));
            this.guna2ControlBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(103)))), ((int)(((byte)(112)))));
            this.guna2ControlBox1.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(218)))), ((int)(((byte)(223)))));
            this.guna2ControlBox1.HoverState.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(103)))), ((int)(((byte)(112)))));
            this.guna2ControlBox1.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(103)))), ((int)(((byte)(112)))));
            this.guna2ControlBox1.Location = new System.Drawing.Point(425, 16);
            this.guna2ControlBox1.Name = "guna2ControlBox1";
            this.guna2ControlBox1.Size = new System.Drawing.Size(41, 41);
            this.guna2ControlBox1.TabIndex = 0;
            // 
            // guna2BorderlessForm1
            // 
            this.guna2BorderlessForm1.BorderRadius = 10;
            this.guna2BorderlessForm1.ContainerControl = this;
            this.guna2BorderlessForm1.DockIndicatorColor = System.Drawing.Color.DarkGray;
            this.guna2BorderlessForm1.DockIndicatorTransparencyValue = 0.6D;
            this.guna2BorderlessForm1.ResizeForm = false;
            this.guna2BorderlessForm1.TransparentWhileDrag = true;
            // 
            // separator
            // 
            this.TransitionOn.SetDecoration(this.separator, Guna.UI2.AnimatorNS.DecorationType.None);
            this.TransitionOff.SetDecoration(this.separator, Guna.UI2.AnimatorNS.DecorationType.None);
            this.separator.Location = new System.Drawing.Point(0, 59);
            this.separator.Name = "separator";
            this.separator.Size = new System.Drawing.Size(554, 22);
            this.separator.TabIndex = 126;
            this.separator.Click += new System.EventHandler(this.separator_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.TransitionOn.SetDecoration(this.label1, Guna.UI2.AnimatorNS.DecorationType.None);
            this.TransitionOff.SetDecoration(this.label1, Guna.UI2.AnimatorNS.DecorationType.None);
            this.label1.Font = new System.Drawing.Font("Gadugi", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(133, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(211, 28);
            this.label1.TabIndex = 127;
            this.label1.Text = "Crear comentario";
            // 
            // btnComentar
            // 
            this.btnComentar.Animated = true;
            this.btnComentar.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(118)))), ((int)(((byte)(175)))));
            this.btnComentar.BorderRadius = 5;
            this.btnComentar.BorderThickness = 1;
            this.btnComentar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.TransitionOff.SetDecoration(this.btnComentar, Guna.UI2.AnimatorNS.DecorationType.None);
            this.TransitionOn.SetDecoration(this.btnComentar, Guna.UI2.AnimatorNS.DecorationType.None);
            this.btnComentar.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnComentar.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnComentar.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(230)))), ((int)(((byte)(235)))));
            this.btnComentar.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(188)))), ((int)(((byte)(192)))), ((int)(((byte)(196)))));
            this.btnComentar.FillColor = System.Drawing.Color.White;
            this.btnComentar.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnComentar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(118)))), ((int)(((byte)(175)))));
            this.btnComentar.HoverState.BorderColor = System.Drawing.Color.Lavender;
            this.btnComentar.HoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(59)))), ((int)(((byte)(82)))));
            this.btnComentar.HoverState.ForeColor = System.Drawing.Color.White;
            this.btnComentar.Location = new System.Drawing.Point(21, 405);
            this.btnComentar.Name = "btnComentar";
            this.btnComentar.PressedColor = System.Drawing.Color.White;
            this.btnComentar.Size = new System.Drawing.Size(450, 36);
            this.btnComentar.TabIndex = 133;
            this.btnComentar.Text = "Comentar";
            // 
            // gunaGroupBox5
            // 
            this.gunaGroupBox5.BackColor = System.Drawing.Color.Transparent;
            this.gunaGroupBox5.BaseColor = System.Drawing.Color.White;
            this.gunaGroupBox5.BorderColor = System.Drawing.Color.Gainsboro;
            this.gunaGroupBox5.BorderSize = 2;
            this.gunaGroupBox5.Controls.Add(this.label3);
            this.gunaGroupBox5.Controls.Add(this.label2);
            this.TransitionOn.SetDecoration(this.gunaGroupBox5, Guna.UI2.AnimatorNS.DecorationType.None);
            this.TransitionOff.SetDecoration(this.gunaGroupBox5, Guna.UI2.AnimatorNS.DecorationType.None);
            this.gunaGroupBox5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gunaGroupBox5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(69)))), ((int)(((byte)(90)))), ((int)(((byte)(100)))));
            this.gunaGroupBox5.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(100)))), ((int)(((byte)(132)))));
            this.gunaGroupBox5.LineTop = 0;
            this.gunaGroupBox5.Location = new System.Drawing.Point(580, 164);
            this.gunaGroupBox5.Name = "gunaGroupBox5";
            this.gunaGroupBox5.Radius = 10;
            this.gunaGroupBox5.Size = new System.Drawing.Size(503, 95);
            this.gunaGroupBox5.TabIndex = 163;
            this.gunaGroupBox5.TextLocation = new System.Drawing.Point(10, 8);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.White;
            this.TransitionOn.SetDecoration(this.label3, Guna.UI2.AnimatorNS.DecorationType.None);
            this.TransitionOff.SetDecoration(this.label3, Guna.UI2.AnimatorNS.DecorationType.None);
            this.label3.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.label3.Location = new System.Drawing.Point(143, 58);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 19);
            this.label3.TabIndex = 165;
            this.label3.Text = "estados";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.White;
            this.TransitionOn.SetDecoration(this.label2, Guna.UI2.AnimatorNS.DecorationType.None);
            this.TransitionOff.SetDecoration(this.label2, Guna.UI2.AnimatorNS.DecorationType.None);
            this.label2.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.label2.Location = new System.Drawing.Point(355, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 19);
            this.label2.TabIndex = 164;
            this.label2.Text = "finalizar";
            // 
            // guna2ComboBox1
            // 
            this.guna2ComboBox1.BackColor = System.Drawing.Color.Transparent;
            this.guna2ComboBox1.BorderRadius = 15;
            this.guna2ComboBox1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.TransitionOff.SetDecoration(this.guna2ComboBox1, Guna.UI2.AnimatorNS.DecorationType.None);
            this.TransitionOn.SetDecoration(this.guna2ComboBox1, Guna.UI2.AnimatorNS.DecorationType.None);
            this.guna2ComboBox1.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.guna2ComboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.guna2ComboBox1.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(118)))), ((int)(((byte)(175)))));
            this.guna2ComboBox1.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(118)))), ((int)(((byte)(175)))));
            this.guna2ComboBox1.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.guna2ComboBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.guna2ComboBox1.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(118)))), ((int)(((byte)(175)))));
            this.guna2ComboBox1.ItemHeight = 30;
            this.guna2ComboBox1.Items.AddRange(new object[] {
            "   Todos",
            "   Activos",
            "   Finalizados",
            "   estados"});
            this.guna2ComboBox1.ItemsAppearance.SelectedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(229)))), ((int)(((byte)(246)))));
            this.guna2ComboBox1.Location = new System.Drawing.Point(44, 95);
            this.guna2ComboBox1.Name = "guna2ComboBox1";
            this.guna2ComboBox1.ShadowDecoration.BorderRadius = 10;
            this.guna2ComboBox1.ShadowDecoration.Shadow = new System.Windows.Forms.Padding(15);
            this.guna2ComboBox1.Size = new System.Drawing.Size(286, 36);
            this.guna2ComboBox1.StartIndex = 3;
            this.guna2ComboBox1.TabIndex = 165;
            this.guna2ComboBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Switch
            // 
            this.Switch.Animated = true;
            this.Switch.BackColor = System.Drawing.Color.White;
            this.Switch.CheckedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(95)))), ((int)(((byte)(184)))));
            this.Switch.CheckedState.BorderRadius = 15;
            this.Switch.CheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(95)))), ((int)(((byte)(184)))));
            this.Switch.CheckedState.InnerBorderColor = System.Drawing.Color.White;
            this.Switch.CheckedState.InnerBorderRadius = 14;
            this.Switch.CheckedState.InnerColor = System.Drawing.Color.White;
            this.Switch.Cursor = System.Windows.Forms.Cursors.Hand;
            this.TransitionOff.SetDecoration(this.Switch, Guna.UI2.AnimatorNS.DecorationType.Custom);
            this.TransitionOn.SetDecoration(this.Switch, Guna.UI2.AnimatorNS.DecorationType.Custom);
            this.Switch.Location = new System.Drawing.Point(336, 95);
            this.Switch.Name = "Switch";
            this.Switch.Size = new System.Drawing.Size(108, 36);
            this.Switch.TabIndex = 164;
            this.Switch.UncheckedState.BorderColor = System.Drawing.Color.LightGray;
            this.Switch.UncheckedState.BorderRadius = 15;
            this.Switch.UncheckedState.BorderThickness = 1;
            this.Switch.UncheckedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(235)))), ((int)(((byte)(246)))));
            this.Switch.UncheckedState.InnerBorderColor = System.Drawing.Color.LightGray;
            this.Switch.UncheckedState.InnerBorderRadius = 14;
            this.Switch.UncheckedState.InnerBorderThickness = 1;
            this.Switch.UncheckedState.InnerColor = System.Drawing.Color.White;
            this.Switch.CheckedChanged += new System.EventHandler(this.Switch_CheckedChanged);
            // 
            // TXTCOMENTARIO
            // 
            this.TXTCOMENTARIO.Animated = true;
            this.TXTCOMENTARIO.AutoScroll = true;
            this.TXTCOMENTARIO.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.TransitionOff.SetDecoration(this.TXTCOMENTARIO, Guna.UI2.AnimatorNS.DecorationType.None);
            this.TransitionOn.SetDecoration(this.TXTCOMENTARIO, Guna.UI2.AnimatorNS.DecorationType.None);
            this.TXTCOMENTARIO.DefaultText = "";
            this.TXTCOMENTARIO.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.TXTCOMENTARIO.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.TXTCOMENTARIO.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.TXTCOMENTARIO.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.TXTCOMENTARIO.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(118)))), ((int)(((byte)(175)))));
            this.TXTCOMENTARIO.Font = new System.Drawing.Font("Segoe UI", 16.5F);
            this.TXTCOMENTARIO.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(118)))), ((int)(((byte)(175)))));
            this.TXTCOMENTARIO.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(118)))), ((int)(((byte)(175)))));
            this.TXTCOMENTARIO.Location = new System.Drawing.Point(21, 150);
            this.TXTCOMENTARIO.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.TXTCOMENTARIO.MaxLength = 500;
            this.TXTCOMENTARIO.Multiline = true;
            this.TXTCOMENTARIO.Name = "TXTCOMENTARIO";
            this.TXTCOMENTARIO.PasswordChar = '\0';
            this.TXTCOMENTARIO.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(101)))), ((int)(((byte)(103)))), ((int)(((byte)(107)))));
            this.TXTCOMENTARIO.PlaceholderText = "Ingresa un comentario";
            this.TXTCOMENTARIO.SelectedText = "";
            this.TXTCOMENTARIO.Size = new System.Drawing.Size(450, 248);
            this.TXTCOMENTARIO.Style = Guna.UI2.WinForms.Enums.TextBoxStyle.Material;
            this.TXTCOMENTARIO.TabIndex = 167;
            this.TXTCOMENTARIO.TextChanged += new System.EventHandler(this.TXTCOMENTARIO_TextChanged);
            // 
            // separador
            // 
            this.TransitionOn.SetDecoration(this.separador, Guna.UI2.AnimatorNS.DecorationType.None);
            this.TransitionOff.SetDecoration(this.separador, Guna.UI2.AnimatorNS.DecorationType.None);
            this.separador.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(118)))), ((int)(((byte)(175)))));
            this.separador.FillThickness = 2;
            this.separador.Location = new System.Drawing.Point(24, 387);
            this.separador.Name = "separador";
            this.separador.Size = new System.Drawing.Size(445, 22);
            this.separador.TabIndex = 168;
            this.separador.Visible = false;
            // 
            // labelSwitchOff
            // 
            this.labelSwitchOff.AutoSize = true;
            this.labelSwitchOff.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(235)))), ((int)(((byte)(246)))));
            this.labelSwitchOff.Cursor = System.Windows.Forms.Cursors.Hand;
            this.TransitionOn.SetDecoration(this.labelSwitchOff, Guna.UI2.AnimatorNS.DecorationType.None);
            this.TransitionOff.SetDecoration(this.labelSwitchOff, Guna.UI2.AnimatorNS.DecorationType.None);
            this.labelSwitchOff.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.labelSwitchOff.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(95)))), ((int)(((byte)(184)))));
            this.labelSwitchOff.Location = new System.Drawing.Point(378, 104);
            this.labelSwitchOff.Name = "labelSwitchOff";
            this.labelSwitchOff.Size = new System.Drawing.Size(55, 19);
            this.labelSwitchOff.TabIndex = 170;
            this.labelSwitchOff.Text = "finalizar";
            this.labelSwitchOff.Visible = false;
            this.labelSwitchOff.Click += new System.EventHandler(this.labelSwitch_Click);
            // 
            // TransitionOn
            // 
            this.TransitionOn.AnimationType = Guna.UI2.AnimatorNS.AnimationType.Transparent;
            this.TransitionOn.Cursor = null;
            animation7.AnimateOnlyDifferences = true;
            animation7.BlindCoeff = ((System.Drawing.PointF)(resources.GetObject("animation7.BlindCoeff")));
            animation7.LeafCoeff = 0F;
            animation7.MaxTime = 1F;
            animation7.MinTime = 0F;
            animation7.MosaicCoeff = ((System.Drawing.PointF)(resources.GetObject("animation7.MosaicCoeff")));
            animation7.MosaicShift = ((System.Drawing.PointF)(resources.GetObject("animation7.MosaicShift")));
            animation7.MosaicSize = 0;
            animation7.Padding = new System.Windows.Forms.Padding(0);
            animation7.RotateCoeff = 0F;
            animation7.RotateLimit = 0F;
            animation7.ScaleCoeff = ((System.Drawing.PointF)(resources.GetObject("animation7.ScaleCoeff")));
            animation7.SlideCoeff = ((System.Drawing.PointF)(resources.GetObject("animation7.SlideCoeff")));
            animation7.TimeCoeff = 0F;
            animation7.TransparencyCoeff = 1F;
            this.TransitionOn.DefaultAnimation = animation7;
            this.TransitionOn.Interval = 1;
            this.TransitionOn.TimeStep = 1F;
            // 
            // labelSwitchOn
            // 
            this.labelSwitchOn.AutoSize = true;
            this.labelSwitchOn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(95)))), ((int)(((byte)(184)))));
            this.labelSwitchOn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.TransitionOn.SetDecoration(this.labelSwitchOn, Guna.UI2.AnimatorNS.DecorationType.None);
            this.TransitionOff.SetDecoration(this.labelSwitchOn, Guna.UI2.AnimatorNS.DecorationType.None);
            this.labelSwitchOn.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.labelSwitchOn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(235)))), ((int)(((byte)(246)))));
            this.labelSwitchOn.Location = new System.Drawing.Point(346, 104);
            this.labelSwitchOn.Name = "labelSwitchOn";
            this.labelSwitchOn.Size = new System.Drawing.Size(66, 19);
            this.labelSwitchOn.TabIndex = 171;
            this.labelSwitchOn.Text = "finalizado";
            this.labelSwitchOn.Visible = false;
            this.labelSwitchOn.Click += new System.EventHandler(this.label2Switch_Click);
            // 
            // TransitionOff
            // 
            this.TransitionOff.AnimationType = Guna.UI2.AnimatorNS.AnimationType.Transparent;
            this.TransitionOff.Cursor = null;
            animation8.AnimateOnlyDifferences = true;
            animation8.BlindCoeff = ((System.Drawing.PointF)(resources.GetObject("animation8.BlindCoeff")));
            animation8.LeafCoeff = 0F;
            animation8.MaxTime = 1F;
            animation8.MinTime = 0F;
            animation8.MosaicCoeff = ((System.Drawing.PointF)(resources.GetObject("animation8.MosaicCoeff")));
            animation8.MosaicShift = ((System.Drawing.PointF)(resources.GetObject("animation8.MosaicShift")));
            animation8.MosaicSize = 0;
            animation8.Padding = new System.Windows.Forms.Padding(0);
            animation8.RotateCoeff = 0F;
            animation8.RotateLimit = 0F;
            animation8.ScaleCoeff = ((System.Drawing.PointF)(resources.GetObject("animation8.ScaleCoeff")));
            animation8.SlideCoeff = ((System.Drawing.PointF)(resources.GetObject("animation8.SlideCoeff")));
            animation8.TimeCoeff = 0F;
            animation8.TransparencyCoeff = 1F;
            this.TransitionOff.DefaultAnimation = animation8;
            this.TransitionOff.Interval = 1;
            this.TransitionOff.TimeStep = 1F;
            // 
            // Comentario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(491, 464);
            this.Controls.Add(this.labelSwitchOn);
            this.Controls.Add(this.labelSwitchOff);
            this.Controls.Add(this.btnComentar);
            this.Controls.Add(this.separador);
            this.Controls.Add(this.TXTCOMENTARIO);
            this.Controls.Add(this.guna2ComboBox1);
            this.Controls.Add(this.Switch);
            this.Controls.Add(this.gunaGroupBox5);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.separator);
            this.Controls.Add(this.guna2ControlBox1);
            this.TransitionOff.SetDecoration(this, Guna.UI2.AnimatorNS.DecorationType.None);
            this.TransitionOn.SetDecoration(this, Guna.UI2.AnimatorNS.DecorationType.None);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Comentario";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Comentario";
            this.Load += new System.EventHandler(this.Comentario_Load);
            this.gunaGroupBox5.ResumeLayout(false);
            this.gunaGroupBox5.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Guna.UI2.WinForms.Guna2ControlBox guna2ControlBox1;
        private Guna.UI2.WinForms.Guna2BorderlessForm guna2BorderlessForm1;
        private System.Windows.Forms.Label label1;
        private Guna.UI2.WinForms.Guna2Separator separator;
        private Guna.UI2.WinForms.Guna2Button btnComentar;
        private Guna.UI.WinForms.GunaGroupBox gunaGroupBox5;
        private System.Windows.Forms.Label label3;
        private Guna.UI2.WinForms.Guna2ComboBox guna2ComboBox1;
        private Guna.UI2.WinForms.Guna2ToggleSwitch Switch;
        private Guna.UI2.WinForms.Guna2TextBox TXTCOMENTARIO;
        private Guna.UI2.WinForms.Guna2Separator separador;
        private System.Windows.Forms.Label labelSwitchOff;
        private System.Windows.Forms.Label label2;
        private Guna.UI2.WinForms.Guna2Transition TransitionOn;
        private Guna.UI2.WinForms.Guna2Transition TransitionOff;
        private System.Windows.Forms.Label labelSwitchOn;
    }
}