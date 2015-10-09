namespace MySoftPhone
{
    partial class FrmConfiguracion
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
            this.tcConfig = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.btnTestCentralita = new System.Windows.Forms.Button();
            this.tbSecret = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.tbCentralita = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnTest = new System.Windows.Forms.Button();
            this.tbPass = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tbusuario = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tbDatabase = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tbServer = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.comboBoxRecordingDevices = new System.Windows.Forms.ComboBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.comboBoxPlaybackDevices = new System.Windows.Forms.ComboBox();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.dgvContactos = new System.Windows.Forms.DataGridView();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._empresa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._grupo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._extension = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this._error = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idEmpresa = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idGurpo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idExtension = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.button2 = new System.Windows.Forms.Button();
            this.tbPasswordCorreo = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.tbUserCorreo = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.tbServidorCorreo = new System.Windows.Forms.MaskedTextBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.tbDestinatarioCorreo = new System.Windows.Forms.MaskedTextBox();
            this.tbPuertoCorreo = new System.Windows.Forms.MaskedTextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.chkActivarCorreo = new System.Windows.Forms.CheckBox();
            this.tbExtension = new System.Windows.Forms.MaskedTextBox();
            this.tbPort = new System.Windows.Forms.MaskedTextBox();
            this.tcConfig.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvContactos)).BeginInit();
            this.tabPage4.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // tcConfig
            // 
            this.tcConfig.Controls.Add(this.tabPage1);
            this.tcConfig.Controls.Add(this.tabPage2);
            this.tcConfig.Controls.Add(this.tabPage3);
            this.tcConfig.Controls.Add(this.tabPage4);
            this.tcConfig.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tcConfig.Location = new System.Drawing.Point(0, 0);
            this.tcConfig.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.tcConfig.Name = "tcConfig";
            this.tcConfig.SelectedIndex = 0;
            this.tcConfig.Size = new System.Drawing.Size(831, 298);
            this.tcConfig.TabIndex = 0;
            this.tcConfig.SelectedIndexChanged += new System.EventHandler(this.tcConfig_SelectedIndexChanged);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.groupBox2);
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Location = new System.Drawing.Point(4, 27);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.tabPage1.Size = new System.Drawing.Size(823, 267);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Credenciales";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.tbPort);
            this.groupBox2.Controls.Add(this.tbExtension);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.btnTestCentralita);
            this.groupBox2.Controls.Add(this.tbSecret);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.tbCentralita);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Location = new System.Drawing.Point(12, 139);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(792, 126);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Centralita";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(15, 85);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(68, 18);
            this.label7.TabIndex = 9;
            this.label7.Text = "Puerto:";
            // 
            // btnTestCentralita
            // 
            this.btnTestCentralita.Location = new System.Drawing.Point(705, 76);
            this.btnTestCentralita.Name = "btnTestCentralita";
            this.btnTestCentralita.Size = new System.Drawing.Size(64, 28);
            this.btnTestCentralita.TabIndex = 8;
            this.btnTestCentralita.Text = "Test";
            this.btnTestCentralita.UseVisualStyleBackColor = true;
            this.btnTestCentralita.Click += new System.EventHandler(this.btnTestCentralita_Click);
            // 
            // tbSecret
            // 
            this.tbSecret.Location = new System.Drawing.Point(487, 78);
            this.tbSecret.Name = "tbSecret";
            this.tbSecret.PasswordChar = '*';
            this.tbSecret.Size = new System.Drawing.Size(171, 27);
            this.tbSecret.TabIndex = 7;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(374, 82);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(108, 18);
            this.label5.TabIndex = 6;
            this.label5.Text = "Contraseña:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(374, 40);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(95, 18);
            this.label6.TabIndex = 4;
            this.label6.Text = "Extensión:";
            // 
            // tbCentralita
            // 
            this.tbCentralita.Location = new System.Drawing.Point(154, 42);
            this.tbCentralita.Name = "tbCentralita";
            this.tbCentralita.Size = new System.Drawing.Size(171, 27);
            this.tbCentralita.TabIndex = 1;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(15, 45);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(81, 18);
            this.label8.TabIndex = 0;
            this.label8.Text = "Servidor:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnTest);
            this.groupBox1.Controls.Add(this.tbPass);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.tbusuario);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.tbDatabase);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.tbServer);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 7);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(792, 126);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Base de datos";
            // 
            // btnTest
            // 
            this.btnTest.Location = new System.Drawing.Point(705, 73);
            this.btnTest.Name = "btnTest";
            this.btnTest.Size = new System.Drawing.Size(64, 28);
            this.btnTest.TabIndex = 8;
            this.btnTest.Text = "Test";
            this.btnTest.UseVisualStyleBackColor = true;
            this.btnTest.Click += new System.EventHandler(this.btnTest_Click);
            // 
            // tbPass
            // 
            this.tbPass.Location = new System.Drawing.Point(487, 75);
            this.tbPass.Name = "tbPass";
            this.tbPass.PasswordChar = '*';
            this.tbPass.Size = new System.Drawing.Size(171, 27);
            this.tbPass.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(374, 79);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(108, 18);
            this.label4.TabIndex = 6;
            this.label4.Text = "Contraseña:";
            // 
            // tbusuario
            // 
            this.tbusuario.Location = new System.Drawing.Point(487, 42);
            this.tbusuario.Name = "tbusuario";
            this.tbusuario.Size = new System.Drawing.Size(171, 27);
            this.tbusuario.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(374, 46);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 18);
            this.label3.TabIndex = 4;
            this.label3.Text = "Usuario:";
            // 
            // tbDatabase
            // 
            this.tbDatabase.Location = new System.Drawing.Point(154, 75);
            this.tbDatabase.Name = "tbDatabase";
            this.tbDatabase.Size = new System.Drawing.Size(171, 27);
            this.tbDatabase.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 78);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(133, 18);
            this.label2.TabIndex = 2;
            this.label2.Text = "Base de datos:";
            // 
            // tbServer
            // 
            this.tbServer.Location = new System.Drawing.Point(154, 42);
            this.tbServer.Name = "tbServer";
            this.tbServer.Size = new System.Drawing.Size(171, 27);
            this.tbServer.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 18);
            this.label1.TabIndex = 0;
            this.label1.Text = "Servidor:";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.groupBox5);
            this.tabPage2.Controls.Add(this.groupBox4);
            this.tabPage2.Location = new System.Drawing.Point(4, 27);
            this.tabPage2.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.tabPage2.Size = new System.Drawing.Size(823, 267);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Sonido";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.comboBoxRecordingDevices);
            this.groupBox5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox5.Location = new System.Drawing.Point(5, 97);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(813, 166);
            this.groupBox5.TabIndex = 2;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Recording";
            // 
            // comboBoxRecordingDevices
            // 
            this.comboBoxRecordingDevices.FormattingEnabled = true;
            this.comboBoxRecordingDevices.Location = new System.Drawing.Point(10, 34);
            this.comboBoxRecordingDevices.Name = "comboBoxRecordingDevices";
            this.comboBoxRecordingDevices.Size = new System.Drawing.Size(370, 26);
            this.comboBoxRecordingDevices.TabIndex = 0;
            // 
            // groupBox4
            // 
            this.groupBox4.BackColor = System.Drawing.Color.Transparent;
            this.groupBox4.Controls.Add(this.comboBoxPlaybackDevices);
            this.groupBox4.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox4.Location = new System.Drawing.Point(5, 4);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(813, 93);
            this.groupBox4.TabIndex = 1;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Playback";
            // 
            // comboBoxPlaybackDevices
            // 
            this.comboBoxPlaybackDevices.FormattingEnabled = true;
            this.comboBoxPlaybackDevices.Location = new System.Drawing.Point(10, 26);
            this.comboBoxPlaybackDevices.Name = "comboBoxPlaybackDevices";
            this.comboBoxPlaybackDevices.Size = new System.Drawing.Size(370, 26);
            this.comboBoxPlaybackDevices.TabIndex = 3;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.btnBuscar);
            this.tabPage3.Controls.Add(this.textBox1);
            this.tabPage3.Controls.Add(this.dgvContactos);
            this.tabPage3.Location = new System.Drawing.Point(4, 27);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(823, 267);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Contactos local";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // btnBuscar
            // 
            this.btnBuscar.Location = new System.Drawing.Point(678, 6);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(136, 29);
            this.btnBuscar.TabIndex = 3;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(7, 6);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(665, 27);
            this.textBox1.TabIndex = 2;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // dgvContactos
            // 
            this.dgvContactos.AllowUserToAddRows = false;
            this.dgvContactos.AllowUserToDeleteRows = false;
            this.dgvContactos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvContactos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Id,
            this._empresa,
            this._grupo,
            this._extension,
            this._id,
            this._error,
            this.nombre,
            this.idEmpresa,
            this.idGurpo,
            this.idExtension});
            this.dgvContactos.Location = new System.Drawing.Point(7, 39);
            this.dgvContactos.Name = "dgvContactos";
            this.dgvContactos.ReadOnly = true;
            this.dgvContactos.Size = new System.Drawing.Size(807, 218);
            this.dgvContactos.TabIndex = 0;
            // 
            // Id
            // 
            this.Id.DataPropertyName = "id";
            this.Id.HeaderText = "Id";
            this.Id.Name = "Id";
            this.Id.ReadOnly = true;
            this.Id.Visible = false;
            // 
            // _empresa
            // 
            this._empresa.DataPropertyName = "_Empresa";
            this._empresa.HeaderText = "Column1";
            this._empresa.Name = "_empresa";
            this._empresa.ReadOnly = true;
            this._empresa.Visible = false;
            // 
            // _grupo
            // 
            this._grupo.DataPropertyName = "_Grupo";
            this._grupo.HeaderText = "Column1";
            this._grupo.Name = "_grupo";
            this._grupo.ReadOnly = true;
            this._grupo.Visible = false;
            // 
            // _extension
            // 
            this._extension.DataPropertyName = "_Extension";
            this._extension.HeaderText = "Column1";
            this._extension.Name = "_extension";
            this._extension.ReadOnly = true;
            this._extension.Visible = false;
            // 
            // _id
            // 
            this._id.DataPropertyName = "_Id";
            this._id.HeaderText = "Column1";
            this._id.Name = "_id";
            this._id.ReadOnly = true;
            this._id.Visible = false;
            // 
            // _error
            // 
            this._error.DataPropertyName = "_Error";
            this._error.HeaderText = "Column1";
            this._error.Name = "_error";
            this._error.ReadOnly = true;
            this._error.Visible = false;
            // 
            // nombre
            // 
            this.nombre.DataPropertyName = "nombre";
            this.nombre.HeaderText = "Nombre";
            this.nombre.Name = "nombre";
            this.nombre.ReadOnly = true;
            this.nombre.Width = 300;
            // 
            // idEmpresa
            // 
            this.idEmpresa.DataPropertyName = "idEmpresa";
            this.idEmpresa.HeaderText = "IdEmpresa";
            this.idEmpresa.Name = "idEmpresa";
            this.idEmpresa.ReadOnly = true;
            this.idEmpresa.Visible = false;
            // 
            // idGurpo
            // 
            this.idGurpo.DataPropertyName = "idGrupo";
            this.idGurpo.HeaderText = "IdGrupo";
            this.idGurpo.Name = "idGurpo";
            this.idGurpo.ReadOnly = true;
            this.idGurpo.Visible = false;
            // 
            // idExtension
            // 
            this.idExtension.DataPropertyName = "idExtension";
            this.idExtension.HeaderText = "IdExtension";
            this.idExtension.Name = "idExtension";
            this.idExtension.ReadOnly = true;
            this.idExtension.Visible = false;
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.groupBox3);
            this.tabPage4.Location = new System.Drawing.Point(4, 27);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(823, 267);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Correo eléctronico";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(715, 195);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(64, 28);
            this.button2.TabIndex = 17;
            this.button2.Text = "Test";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // tbPasswordCorreo
            // 
            this.tbPasswordCorreo.Location = new System.Drawing.Point(412, 152);
            this.tbPasswordCorreo.Name = "tbPasswordCorreo";
            this.tbPasswordCorreo.PasswordChar = '*';
            this.tbPasswordCorreo.Size = new System.Drawing.Size(284, 27);
            this.tbPasswordCorreo.TabIndex = 16;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(273, 155);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(108, 18);
            this.label9.TabIndex = 15;
            this.label9.Text = "Contraseña:";
            // 
            // tbUserCorreo
            // 
            this.tbUserCorreo.Location = new System.Drawing.Point(412, 108);
            this.tbUserCorreo.Name = "tbUserCorreo";
            this.tbUserCorreo.Size = new System.Drawing.Size(284, 27);
            this.tbUserCorreo.TabIndex = 14;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(273, 111);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(77, 18);
            this.label10.TabIndex = 13;
            this.label10.Text = "Usuario:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(273, 198);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(116, 18);
            this.label11.TabIndex = 11;
            this.label11.Text = "Destinatario:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(273, 38);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(81, 18);
            this.label12.TabIndex = 9;
            this.label12.Text = "Servidor:";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.DimGray;
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.btnCancelar);
            this.panel1.Controls.Add(this.btnAceptar);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 298);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(831, 47);
            this.panel1.TabIndex = 1;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(337, 6);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(157, 35);
            this.button1.TabIndex = 2;
            this.button1.Text = "Aplicar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(662, 7);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(157, 35);
            this.btnCancelar.TabIndex = 1;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnAceptar
            // 
            this.btnAceptar.Location = new System.Drawing.Point(16, 6);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(157, 35);
            this.btnAceptar.TabIndex = 0;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // tbServidorCorreo
            // 
            this.tbServidorCorreo.Location = new System.Drawing.Point(412, 38);
            this.tbServidorCorreo.Name = "tbServidorCorreo";
            this.tbServidorCorreo.Size = new System.Drawing.Size(284, 27);
            this.tbServidorCorreo.TabIndex = 18;
            // 
            // tbDestinatarioCorreo
            // 
            this.tbDestinatarioCorreo.Location = new System.Drawing.Point(412, 195);
            this.tbDestinatarioCorreo.Name = "tbDestinatarioCorreo";
            this.tbDestinatarioCorreo.Size = new System.Drawing.Size(284, 27);
            this.tbDestinatarioCorreo.TabIndex = 19;
            // 
            // tbPuertoCorreo
            // 
            this.tbPuertoCorreo.Location = new System.Drawing.Point(412, 71);
            this.tbPuertoCorreo.Mask = "99999";
            this.tbPuertoCorreo.Name = "tbPuertoCorreo";
            this.tbPuertoCorreo.Size = new System.Drawing.Size(60, 27);
            this.tbPuertoCorreo.TabIndex = 21;
            this.tbPuertoCorreo.ValidatingType = typeof(int);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(273, 74);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(68, 18);
            this.label13.TabIndex = 20;
            this.label13.Text = "Puerto:";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.chkActivarCorreo);
            this.groupBox3.Controls.Add(this.tbPuertoCorreo);
            this.groupBox3.Controls.Add(this.tbDestinatarioCorreo);
            this.groupBox3.Controls.Add(this.label13);
            this.groupBox3.Controls.Add(this.button2);
            this.groupBox3.Controls.Add(this.tbServidorCorreo);
            this.groupBox3.Controls.Add(this.tbPasswordCorreo);
            this.groupBox3.Controls.Add(this.label12);
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Controls.Add(this.label10);
            this.groupBox3.Controls.Add(this.tbUserCorreo);
            this.groupBox3.Controls.Add(this.label11);
            this.groupBox3.Location = new System.Drawing.Point(12, 6);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(803, 241);
            this.groupBox3.TabIndex = 22;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Notificación de llamadas por correo";
            // 
            // chkActivarCorreo
            // 
            this.chkActivarCorreo.AutoSize = true;
            this.chkActivarCorreo.Location = new System.Drawing.Point(16, 37);
            this.chkActivarCorreo.Name = "chkActivarCorreo";
            this.chkActivarCorreo.Size = new System.Drawing.Size(83, 22);
            this.chkActivarCorreo.TabIndex = 22;
            this.chkActivarCorreo.Text = "Activar";
            this.chkActivarCorreo.UseVisualStyleBackColor = true;
            // 
            // tbExtension
            // 
            this.tbExtension.Location = new System.Drawing.Point(487, 37);
            this.tbExtension.Mask = "99999";
            this.tbExtension.Name = "tbExtension";
            this.tbExtension.Size = new System.Drawing.Size(60, 27);
            this.tbExtension.TabIndex = 22;
            this.tbExtension.ValidatingType = typeof(int);
            // 
            // tbPort
            // 
            this.tbPort.Location = new System.Drawing.Point(154, 82);
            this.tbPort.Mask = "99999";
            this.tbPort.Name = "tbPort";
            this.tbPort.Size = new System.Drawing.Size(60, 27);
            this.tbPort.TabIndex = 23;
            this.tbPort.ValidatingType = typeof(int);
            // 
            // FrmConfiguracion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(831, 345);
            this.Controls.Add(this.tcConfig);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.Navy;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.Name = "FrmConfiguracion";
            this.Text = "Configuración";
            this.Load += new System.EventHandler(this.FrmConfiguracion_Load);
            this.tcConfig.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvContactos)).EndInit();
            this.tabPage4.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tcConfig;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnTestCentralita;
        private System.Windows.Forms.TextBox tbSecret;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tbCentralita;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnTest;
        private System.Windows.Forms.TextBox tbPass;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbusuario;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbDatabase;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbServer;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.ComboBox comboBoxPlaybackDevices;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.ComboBox comboBoxRecordingDevices;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.DataGridView dgvContactos;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn _empresa;
        private System.Windows.Forms.DataGridViewTextBoxColumn _grupo;
        private System.Windows.Forms.DataGridViewTextBoxColumn _extension;
        private System.Windows.Forms.DataGridViewTextBoxColumn _id;
        private System.Windows.Forms.DataGridViewTextBoxColumn _error;
        private System.Windows.Forms.DataGridViewTextBoxColumn nombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn idEmpresa;
        private System.Windows.Forms.DataGridViewTextBoxColumn idGurpo;
        private System.Windows.Forms.DataGridViewTextBoxColumn idExtension;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox tbPasswordCorreo;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox tbUserCorreo;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.MaskedTextBox tbDestinatarioCorreo;
        private System.Windows.Forms.MaskedTextBox tbServidorCorreo;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.MaskedTextBox tbPuertoCorreo;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.CheckBox chkActivarCorreo;
        private System.Windows.Forms.MaskedTextBox tbPort;
        private System.Windows.Forms.MaskedTextBox tbExtension;
    }
}