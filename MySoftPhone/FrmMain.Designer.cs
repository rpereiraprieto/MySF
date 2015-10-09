namespace MySoftPhone
{
    partial class FrmMain
    {
        /// <summary>
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén utilizando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben eliminar; false en caso contrario, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblEstado = new System.Windows.Forms.Label();
            this.btnConecta = new System.Windows.Forms.Button();
            this.btnTransfer = new System.Windows.Forms.Button();
            this.btnHold = new System.Windows.Forms.Button();
            this.keypad0 = new System.Windows.Forms.Button();
            this.btnLlama = new System.Windows.Forms.Button();
            this.keypad1 = new System.Windows.Forms.Button();
            this.btnColgar = new System.Windows.Forms.Button();
            this.keypad2 = new System.Windows.Forms.Button();
            this.keypadSTAR = new System.Windows.Forms.Button();
            this.keypad3 = new System.Windows.Forms.Button();
            this.keypadHASH = new System.Windows.Forms.Button();
            this.keypad4 = new System.Windows.Forms.Button();
            this.keypad9 = new System.Windows.Forms.Button();
            this.keypad5 = new System.Windows.Forms.Button();
            this.keypad8 = new System.Windows.Forms.Button();
            this.keypad6 = new System.Windows.Forms.Button();
            this.keypad7 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.chkMuteOut = new System.Windows.Forms.CheckBox();
            this.chkMutein = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button2 = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.tbNumero = new System.Windows.Forms.ComboBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Hora = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Telefono = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblEstado
            // 
            this.lblEstado.AutoSize = true;
            this.lblEstado.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEstado.ForeColor = System.Drawing.Color.DarkGreen;
            this.lblEstado.Location = new System.Drawing.Point(33, 485);
            this.lblEstado.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblEstado.Name = "lblEstado";
            this.lblEstado.Size = new System.Drawing.Size(0, 18);
            this.lblEstado.TabIndex = 2;
            // 
            // btnConecta
            // 
            this.btnConecta.Location = new System.Drawing.Point(9, 27);
            this.btnConecta.Margin = new System.Windows.Forms.Padding(6, 4, 6, 4);
            this.btnConecta.Name = "btnConecta";
            this.btnConecta.Size = new System.Drawing.Size(93, 37);
            this.btnConecta.TabIndex = 3;
            this.btnConecta.Text = "Conecta";
            this.btnConecta.UseVisualStyleBackColor = true;
            this.btnConecta.Click += new System.EventHandler(this.btnConecta_Click);
            // 
            // btnTransfer
            // 
            this.btnTransfer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTransfer.Image = global::MySoftPhone.Properties.Resources.phone_redirect;
            this.btnTransfer.Location = new System.Drawing.Point(796, 485);
            this.btnTransfer.Margin = new System.Windows.Forms.Padding(6, 4, 6, 4);
            this.btnTransfer.Name = "btnTransfer";
            this.btnTransfer.Size = new System.Drawing.Size(65, 62);
            this.btnTransfer.TabIndex = 49;
            this.btnTransfer.UseVisualStyleBackColor = true;
            // 
            // btnHold
            // 
            this.btnHold.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHold.Image = global::MySoftPhone.Properties.Resources.phone_hold;
            this.btnHold.Location = new System.Drawing.Point(719, 485);
            this.btnHold.Margin = new System.Windows.Forms.Padding(6, 4, 6, 4);
            this.btnHold.Name = "btnHold";
            this.btnHold.Size = new System.Drawing.Size(65, 62);
            this.btnHold.TabIndex = 48;
            this.btnHold.UseVisualStyleBackColor = true;
            // 
            // keypad0
            // 
            this.keypad0.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.keypad0.Location = new System.Drawing.Point(80, 202);
            this.keypad0.Margin = new System.Windows.Forms.Padding(6, 4, 6, 4);
            this.keypad0.Name = "keypad0";
            this.keypad0.Size = new System.Drawing.Size(52, 42);
            this.keypad0.TabIndex = 46;
            this.keypad0.Tag = "0";
            this.keypad0.Text = "0";
            this.keypad0.UseVisualStyleBackColor = true;
            this.keypad0.Click += new System.EventHandler(this.panel1_Click);
            // 
            // btnLlama
            // 
            this.btnLlama.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLlama.Image = global::MySoftPhone.Properties.Resources.phone_pick_up;
            this.btnLlama.Location = new System.Drawing.Point(609, 411);
            this.btnLlama.Margin = new System.Windows.Forms.Padding(6, 4, 6, 4);
            this.btnLlama.Name = "btnLlama";
            this.btnLlama.Size = new System.Drawing.Size(65, 62);
            this.btnLlama.TabIndex = 4;
            this.btnLlama.UseVisualStyleBackColor = true;
            this.btnLlama.Click += new System.EventHandler(this.btnLlama_Click);
            // 
            // keypad1
            // 
            this.keypad1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.keypad1.Location = new System.Drawing.Point(9, 144);
            this.keypad1.Margin = new System.Windows.Forms.Padding(6, 4, 6, 4);
            this.keypad1.Name = "keypad1";
            this.keypad1.Size = new System.Drawing.Size(52, 42);
            this.keypad1.TabIndex = 42;
            this.keypad1.Tag = "1";
            this.keypad1.Text = "1";
            this.keypad1.UseVisualStyleBackColor = true;
            this.keypad1.Click += new System.EventHandler(this.panel1_Click);
            // 
            // btnColgar
            // 
            this.btnColgar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnColgar.Image = global::MySoftPhone.Properties.Resources.phone_hang_up;
            this.btnColgar.Location = new System.Drawing.Point(643, 485);
            this.btnColgar.Margin = new System.Windows.Forms.Padding(6, 4, 6, 4);
            this.btnColgar.Name = "btnColgar";
            this.btnColgar.Size = new System.Drawing.Size(65, 62);
            this.btnColgar.TabIndex = 6;
            this.btnColgar.UseVisualStyleBackColor = true;
            this.btnColgar.Click += new System.EventHandler(this.btnColgar_Click);
            // 
            // keypad2
            // 
            this.keypad2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.keypad2.Location = new System.Drawing.Point(80, 144);
            this.keypad2.Margin = new System.Windows.Forms.Padding(6, 4, 6, 4);
            this.keypad2.Name = "keypad2";
            this.keypad2.Size = new System.Drawing.Size(52, 42);
            this.keypad2.TabIndex = 43;
            this.keypad2.Tag = "2";
            this.keypad2.Text = "2";
            this.keypad2.UseVisualStyleBackColor = true;
            this.keypad2.Click += new System.EventHandler(this.panel1_Click);
            // 
            // keypadSTAR
            // 
            this.keypadSTAR.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.keypadSTAR.Location = new System.Drawing.Point(9, 202);
            this.keypadSTAR.Margin = new System.Windows.Forms.Padding(6, 4, 6, 4);
            this.keypadSTAR.Name = "keypadSTAR";
            this.keypadSTAR.Size = new System.Drawing.Size(52, 42);
            this.keypadSTAR.TabIndex = 45;
            this.keypadSTAR.Tag = "*";
            this.keypadSTAR.Text = "*";
            this.keypadSTAR.UseVisualStyleBackColor = true;
            this.keypadSTAR.Click += new System.EventHandler(this.panel1_Click);
            // 
            // keypad3
            // 
            this.keypad3.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.keypad3.Location = new System.Drawing.Point(152, 144);
            this.keypad3.Margin = new System.Windows.Forms.Padding(6, 4, 6, 4);
            this.keypad3.Name = "keypad3";
            this.keypad3.Size = new System.Drawing.Size(52, 42);
            this.keypad3.TabIndex = 44;
            this.keypad3.Tag = "3";
            this.keypad3.Text = "3";
            this.keypad3.UseVisualStyleBackColor = true;
            this.keypad3.Click += new System.EventHandler(this.panel1_Click);
            // 
            // keypadHASH
            // 
            this.keypadHASH.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.keypadHASH.Location = new System.Drawing.Point(152, 202);
            this.keypadHASH.Margin = new System.Windows.Forms.Padding(6, 4, 6, 4);
            this.keypadHASH.Name = "keypadHASH";
            this.keypadHASH.Size = new System.Drawing.Size(52, 42);
            this.keypadHASH.TabIndex = 47;
            this.keypadHASH.Tag = "#";
            this.keypadHASH.Text = "#";
            this.keypadHASH.UseVisualStyleBackColor = true;
            this.keypadHASH.Click += new System.EventHandler(this.panel1_Click);
            // 
            // keypad4
            // 
            this.keypad4.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.keypad4.Location = new System.Drawing.Point(9, 86);
            this.keypad4.Margin = new System.Windows.Forms.Padding(6, 4, 6, 4);
            this.keypad4.Name = "keypad4";
            this.keypad4.Size = new System.Drawing.Size(52, 42);
            this.keypad4.TabIndex = 39;
            this.keypad4.Tag = "4";
            this.keypad4.Text = "4";
            this.keypad4.UseVisualStyleBackColor = true;
            this.keypad4.Click += new System.EventHandler(this.panel1_Click);
            // 
            // keypad9
            // 
            this.keypad9.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.keypad9.Location = new System.Drawing.Point(152, 27);
            this.keypad9.Margin = new System.Windows.Forms.Padding(6, 4, 6, 4);
            this.keypad9.Name = "keypad9";
            this.keypad9.Size = new System.Drawing.Size(52, 42);
            this.keypad9.TabIndex = 38;
            this.keypad9.Tag = "9";
            this.keypad9.Text = "9";
            this.keypad9.UseVisualStyleBackColor = true;
            this.keypad9.Click += new System.EventHandler(this.panel1_Click);
            // 
            // keypad5
            // 
            this.keypad5.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.keypad5.Location = new System.Drawing.Point(80, 86);
            this.keypad5.Margin = new System.Windows.Forms.Padding(6, 4, 6, 4);
            this.keypad5.Name = "keypad5";
            this.keypad5.Size = new System.Drawing.Size(52, 42);
            this.keypad5.TabIndex = 40;
            this.keypad5.Tag = "5";
            this.keypad5.Text = "5";
            this.keypad5.UseVisualStyleBackColor = true;
            this.keypad5.Click += new System.EventHandler(this.panel1_Click);
            // 
            // keypad8
            // 
            this.keypad8.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.keypad8.Location = new System.Drawing.Point(80, 27);
            this.keypad8.Margin = new System.Windows.Forms.Padding(6, 4, 6, 4);
            this.keypad8.Name = "keypad8";
            this.keypad8.Size = new System.Drawing.Size(52, 42);
            this.keypad8.TabIndex = 37;
            this.keypad8.Tag = "8";
            this.keypad8.Text = "8";
            this.keypad8.UseVisualStyleBackColor = true;
            this.keypad8.Click += new System.EventHandler(this.panel1_Click);
            // 
            // keypad6
            // 
            this.keypad6.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.keypad6.Location = new System.Drawing.Point(152, 86);
            this.keypad6.Margin = new System.Windows.Forms.Padding(6, 4, 6, 4);
            this.keypad6.Name = "keypad6";
            this.keypad6.Size = new System.Drawing.Size(52, 42);
            this.keypad6.TabIndex = 41;
            this.keypad6.Tag = "6";
            this.keypad6.Text = "6";
            this.keypad6.UseVisualStyleBackColor = true;
            this.keypad6.Click += new System.EventHandler(this.panel1_Click);
            // 
            // keypad7
            // 
            this.keypad7.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.keypad7.Location = new System.Drawing.Point(9, 27);
            this.keypad7.Margin = new System.Windows.Forms.Padding(6, 4, 6, 4);
            this.keypad7.Name = "keypad7";
            this.keypad7.Size = new System.Drawing.Size(52, 42);
            this.keypad7.TabIndex = 36;
            this.keypad7.Tag = "7";
            this.keypad7.Text = "7";
            this.keypad7.UseVisualStyleBackColor = true;
            this.keypad7.Click += new System.EventHandler(this.panel1_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(9, 72);
            this.button1.Margin = new System.Windows.Forms.Padding(6, 4, 6, 4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(93, 37);
            this.button1.TabIndex = 9;
            this.button1.Text = "Config";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // chkMuteOut
            // 
            this.chkMuteOut.AutoSize = true;
            this.chkMuteOut.Font = new System.Drawing.Font("Verdana", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkMuteOut.Image = global::MySoftPhone.Properties.Resources.loudspeaker;
            this.chkMuteOut.Location = new System.Drawing.Point(522, 465);
            this.chkMuteOut.Margin = new System.Windows.Forms.Padding(4);
            this.chkMuteOut.Name = "chkMuteOut";
            this.chkMuteOut.Size = new System.Drawing.Size(47, 32);
            this.chkMuteOut.TabIndex = 10;
            this.chkMuteOut.UseVisualStyleBackColor = true;
            this.chkMuteOut.CheckedChanged += new System.EventHandler(this.chkMuteOut_CheckedChanged);
            // 
            // chkMutein
            // 
            this.chkMutein.Appearance = System.Windows.Forms.Appearance.Button;
            this.chkMutein.AutoSize = true;
            this.chkMutein.Font = new System.Drawing.Font("Verdana", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkMutein.Image = global::MySoftPhone.Properties.Resources.microphone1;
            this.chkMutein.Location = new System.Drawing.Point(531, 514);
            this.chkMutein.Margin = new System.Windows.Forms.Padding(4);
            this.chkMutein.Name = "chkMutein";
            this.chkMutein.Size = new System.Drawing.Size(38, 38);
            this.chkMutein.TabIndex = 11;
            this.chkMutein.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.btnConecta);
            this.groupBox1.Location = new System.Drawing.Point(36, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(112, 484);
            this.groupBox1.TabIndex = 12;
            this.groupBox1.TabStop = false;
            // 
            // button2
            // 
            this.button2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.button2.Location = new System.Drawing.Point(249, 198);
            this.button2.Margin = new System.Windows.Forms.Padding(6, 4, 6, 4);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(108, 24);
            this.button2.TabIndex = 50;
            this.button2.Tag = "9";
            this.button2.Text = "Llamar";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dataGridView1);
            this.groupBox2.Controls.Add(this.groupBox3);
            this.groupBox2.Controls.Add(this.tbNumero);
            this.groupBox2.Controls.Add(this.button2);
            this.groupBox2.Location = new System.Drawing.Point(154, 13);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(357, 500);
            this.groupBox2.TabIndex = 50;
            this.groupBox2.TabStop = false;
            // 
            // tbNumero
            // 
            this.tbNumero.FormattingEnabled = true;
            this.tbNumero.Location = new System.Drawing.Point(23, 213);
            this.tbNumero.Name = "tbNumero";
            this.tbNumero.Size = new System.Drawing.Size(212, 26);
            this.tbNumero.TabIndex = 52;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.keypad7);
            this.groupBox3.Controls.Add(this.keypad0);
            this.groupBox3.Controls.Add(this.keypad6);
            this.groupBox3.Controls.Add(this.keypad8);
            this.groupBox3.Controls.Add(this.keypad1);
            this.groupBox3.Controls.Add(this.keypad5);
            this.groupBox3.Controls.Add(this.keypad2);
            this.groupBox3.Controls.Add(this.keypad9);
            this.groupBox3.Controls.Add(this.keypadSTAR);
            this.groupBox3.Controls.Add(this.keypad4);
            this.groupBox3.Controls.Add(this.keypad3);
            this.groupBox3.Controls.Add(this.keypadHASH);
            this.groupBox3.Location = new System.Drawing.Point(23, 234);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(212, 256);
            this.groupBox3.TabIndex = 53;
            this.groupBox3.TabStop = false;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Hora,
            this.Telefono});
            this.dataGridView1.Location = new System.Drawing.Point(23, 23);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(212, 175);
            this.dataGridView1.TabIndex = 54;
            // 
            // Hora
            // 
            this.Hora.HeaderText = "Hora";
            this.Hora.Name = "Hora";
            this.Hora.ReadOnly = true;
            // 
            // Telefono
            // 
            this.Telefono.HeaderText = "Telefono";
            this.Telefono.Name = "Telefono";
            this.Telefono.ReadOnly = true;
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1008, 565);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.chkMutein);
            this.Controls.Add(this.btnTransfer);
            this.Controls.Add(this.btnHold);
            this.Controls.Add(this.chkMuteOut);
            this.Controls.Add(this.btnLlama);
            this.Controls.Add(this.lblEstado);
            this.Controls.Add(this.btnColgar);
            this.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.Navy;
            this.Margin = new System.Windows.Forms.Padding(6, 4, 6, 4);
            this.Name = "FrmMain";
            this.Text = "1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblEstado;
        private System.Windows.Forms.Button btnConecta;
        private System.Windows.Forms.Button btnLlama;
        private System.Windows.Forms.Button btnColgar;
        private System.Windows.Forms.Button keypad4;
        private System.Windows.Forms.Button keypad7;
        private System.Windows.Forms.Button keypad8;
        private System.Windows.Forms.Button keypad9;
        private System.Windows.Forms.Button btnTransfer;
        private System.Windows.Forms.Button btnHold;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.CheckBox chkMuteOut;
        private System.Windows.Forms.CheckBox chkMutein;
        private System.Windows.Forms.Button keypad0;
        private System.Windows.Forms.Button keypad1;
        private System.Windows.Forms.Button keypad2;
        private System.Windows.Forms.Button keypadSTAR;
        private System.Windows.Forms.Button keypad3;
        private System.Windows.Forms.Button keypadHASH;
        private System.Windows.Forms.Button keypad5;
        private System.Windows.Forms.Button keypad6;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox tbNumero;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Hora;
        private System.Windows.Forms.DataGridViewTextBoxColumn Telefono;
        private System.Windows.Forms.GroupBox groupBox3;
    }
}

