namespace AppMonitor.Plugin
{
    partial class IceDeployVersionForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(IceDeployVersionForm));
            this.stb_local_pdir = new CCWin.SkinControl.SkinTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_start = new System.Windows.Forms.Button();
            this.btn_cancel = new System.Windows.Forms.Button();
            this.btn_choose_dir = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.stb_icexml = new CCWin.SkinControl.SkinTextBox();
            this.btn_choose_xml = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.stb_remote_pdir = new CCWin.SkinControl.SkinTextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.btn_choose_mvnxml = new System.Windows.Forms.Button();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.stb_maven_xml = new CCWin.SkinControl.SkinTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.l_state4 = new System.Windows.Forms.Label();
            this.pb_state4 = new System.Windows.Forms.PictureBox();
            this.line_state3 = new System.Windows.Forms.Label();
            this.line_state2 = new System.Windows.Forms.Label();
            this.l_state3 = new System.Windows.Forms.Label();
            this.pb_state3 = new System.Windows.Forms.PictureBox();
            this.l_state2 = new System.Windows.Forms.Label();
            this.pb_state2 = new System.Windows.Forms.PictureBox();
            this.line_state1 = new System.Windows.Forms.Label();
            this.l_state1 = new System.Windows.Forms.Label();
            this.pb_state1 = new System.Windows.Forms.PictureBox();
            this.errorLabel = new System.Windows.Forms.Label();
            this.gifBox1 = new CCWin.SkinControl.GifBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pb_state4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_state3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_state2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_state1)).BeginInit();
            this.SuspendLayout();
            // 
            // stb_local_pdir
            // 
            this.stb_local_pdir.AllowDrop = true;
            this.stb_local_pdir.BackColor = System.Drawing.Color.Transparent;
            this.stb_local_pdir.DownBack = null;
            this.stb_local_pdir.Icon = null;
            this.stb_local_pdir.IconIsButton = false;
            this.stb_local_pdir.IconMouseState = CCWin.SkinClass.ControlState.Normal;
            this.stb_local_pdir.IsPasswordChat = '\0';
            this.stb_local_pdir.IsSystemPasswordChar = false;
            this.stb_local_pdir.Lines = new string[0];
            this.stb_local_pdir.Location = new System.Drawing.Point(177, 16);
            this.stb_local_pdir.Margin = new System.Windows.Forms.Padding(0);
            this.stb_local_pdir.MaxLength = 32767;
            this.stb_local_pdir.MinimumSize = new System.Drawing.Size(28, 28);
            this.stb_local_pdir.MouseBack = null;
            this.stb_local_pdir.MouseState = CCWin.SkinClass.ControlState.Normal;
            this.stb_local_pdir.Multiline = false;
            this.stb_local_pdir.Name = "stb_local_pdir";
            this.stb_local_pdir.NormlBack = null;
            this.stb_local_pdir.Padding = new System.Windows.Forms.Padding(5);
            this.stb_local_pdir.ReadOnly = false;
            this.stb_local_pdir.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.stb_local_pdir.Size = new System.Drawing.Size(423, 28);
            // 
            // 
            // 
            this.stb_local_pdir.SkinTxt.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.stb_local_pdir.SkinTxt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.stb_local_pdir.SkinTxt.Font = new System.Drawing.Font("微软雅黑", 9.75F);
            this.stb_local_pdir.SkinTxt.Location = new System.Drawing.Point(5, 5);
            this.stb_local_pdir.SkinTxt.Name = "BaseText";
            this.stb_local_pdir.SkinTxt.Size = new System.Drawing.Size(413, 18);
            this.stb_local_pdir.SkinTxt.TabIndex = 0;
            this.stb_local_pdir.SkinTxt.WaterColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(127)))), ((int)(((byte)(127)))));
            this.stb_local_pdir.SkinTxt.WaterText = "项目代码本地目录，支持拖拽";
            this.stb_local_pdir.TabIndex = 6;
            this.stb_local_pdir.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.stb_local_pdir.WaterColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(127)))), ((int)(((byte)(127)))));
            this.stb_local_pdir.WaterText = "项目代码本地目录，支持拖拽";
            this.stb_local_pdir.WordWrap = true;
            this.stb_local_pdir.DragDrop += new System.Windows.Forms.DragEventHandler(this.stb_local_pdir_DragDrop);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label1.Location = new System.Drawing.Point(29, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(135, 20);
            this.label1.TabIndex = 7;
            this.label1.Text = "项目代码本地目录：";
            // 
            // btn_start
            // 
            this.btn_start.Location = new System.Drawing.Point(613, 457);
            this.btn_start.Name = "btn_start";
            this.btn_start.Size = new System.Drawing.Size(98, 29);
            this.btn_start.TabIndex = 12;
            this.btn_start.Text = "开始部署";
            this.btn_start.UseVisualStyleBackColor = true;
            this.btn_start.Click += new System.EventHandler(this.button1_Click);
            // 
            // btn_cancel
            // 
            this.btn_cancel.Location = new System.Drawing.Point(525, 457);
            this.btn_cancel.Name = "btn_cancel";
            this.btn_cancel.Size = new System.Drawing.Size(75, 29);
            this.btn_cancel.TabIndex = 13;
            this.btn_cancel.Text = "取消";
            this.btn_cancel.UseVisualStyleBackColor = true;
            this.btn_cancel.Click += new System.EventHandler(this.button2_Click);
            // 
            // btn_choose_dir
            // 
            this.btn_choose_dir.Location = new System.Drawing.Point(608, 16);
            this.btn_choose_dir.Name = "btn_choose_dir";
            this.btn_choose_dir.Size = new System.Drawing.Size(72, 29);
            this.btn_choose_dir.TabIndex = 14;
            this.btn_choose_dir.Text = "定位目录";
            this.btn_choose_dir.UseVisualStyleBackColor = true;
            this.btn_choose_dir.Click += new System.EventHandler(this.btn_choose_dir_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label2.Location = new System.Drawing.Point(36, 93);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(128, 20);
            this.label2.TabIndex = 16;
            this.label2.Text = "ICE接口服务配置：";
            // 
            // stb_icexml
            // 
            this.stb_icexml.AllowDrop = true;
            this.stb_icexml.BackColor = System.Drawing.Color.Transparent;
            this.stb_icexml.DownBack = null;
            this.stb_icexml.Enabled = false;
            this.stb_icexml.Icon = null;
            this.stb_icexml.IconIsButton = false;
            this.stb_icexml.IconMouseState = CCWin.SkinClass.ControlState.Normal;
            this.stb_icexml.IsPasswordChat = '\0';
            this.stb_icexml.IsSystemPasswordChar = false;
            this.stb_icexml.Lines = new string[0];
            this.stb_icexml.Location = new System.Drawing.Point(177, 89);
            this.stb_icexml.Margin = new System.Windows.Forms.Padding(0);
            this.stb_icexml.MaxLength = 32767;
            this.stb_icexml.MinimumSize = new System.Drawing.Size(28, 28);
            this.stb_icexml.MouseBack = null;
            this.stb_icexml.MouseState = CCWin.SkinClass.ControlState.Normal;
            this.stb_icexml.Multiline = false;
            this.stb_icexml.Name = "stb_icexml";
            this.stb_icexml.NormlBack = null;
            this.stb_icexml.Padding = new System.Windows.Forms.Padding(5);
            this.stb_icexml.ReadOnly = false;
            this.stb_icexml.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.stb_icexml.Size = new System.Drawing.Size(423, 28);
            // 
            // 
            // 
            this.stb_icexml.SkinTxt.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.stb_icexml.SkinTxt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.stb_icexml.SkinTxt.Font = new System.Drawing.Font("微软雅黑", 9.75F);
            this.stb_icexml.SkinTxt.Location = new System.Drawing.Point(5, 5);
            this.stb_icexml.SkinTxt.Name = "BaseText";
            this.stb_icexml.SkinTxt.Size = new System.Drawing.Size(413, 18);
            this.stb_icexml.SkinTxt.TabIndex = 0;
            this.stb_icexml.SkinTxt.WaterColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(127)))), ((int)(((byte)(127)))));
            this.stb_icexml.SkinTxt.WaterText = "ICE接口服务配置，一般位于项目~/icedeploy/config/目录下，支持拖拽";
            this.stb_icexml.TabIndex = 15;
            this.stb_icexml.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.stb_icexml.WaterColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(127)))), ((int)(((byte)(127)))));
            this.stb_icexml.WaterText = "ICE接口服务配置，一般位于项目~/icedeploy/config/目录下，支持拖拽";
            this.stb_icexml.WordWrap = true;
            this.stb_icexml.DragDrop += new System.Windows.Forms.DragEventHandler(this.stb_icexml_DragDrop);
            // 
            // btn_choose_xml
            // 
            this.btn_choose_xml.Enabled = false;
            this.btn_choose_xml.Location = new System.Drawing.Point(608, 88);
            this.btn_choose_xml.Name = "btn_choose_xml";
            this.btn_choose_xml.Size = new System.Drawing.Size(72, 29);
            this.btn_choose_xml.TabIndex = 17;
            this.btn_choose_xml.Text = "选择文件";
            this.btn_choose_xml.UseVisualStyleBackColor = true;
            this.btn_choose_xml.Click += new System.EventHandler(this.btn_choose_xml_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label3.Location = new System.Drawing.Point(43, 25);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(121, 20);
            this.label3.TabIndex = 19;
            this.label3.Text = "服务器项目路径：";
            // 
            // stb_remote_pdir
            // 
            this.stb_remote_pdir.AllowDrop = true;
            this.stb_remote_pdir.BackColor = System.Drawing.Color.Transparent;
            this.stb_remote_pdir.DownBack = null;
            this.stb_remote_pdir.Icon = null;
            this.stb_remote_pdir.IconIsButton = false;
            this.stb_remote_pdir.IconMouseState = CCWin.SkinClass.ControlState.Normal;
            this.stb_remote_pdir.IsPasswordChat = '\0';
            this.stb_remote_pdir.IsSystemPasswordChar = false;
            this.stb_remote_pdir.Lines = new string[0];
            this.stb_remote_pdir.Location = new System.Drawing.Point(177, 21);
            this.stb_remote_pdir.Margin = new System.Windows.Forms.Padding(0);
            this.stb_remote_pdir.MaxLength = 32767;
            this.stb_remote_pdir.MinimumSize = new System.Drawing.Size(28, 28);
            this.stb_remote_pdir.MouseBack = null;
            this.stb_remote_pdir.MouseState = CCWin.SkinClass.ControlState.Normal;
            this.stb_remote_pdir.Multiline = false;
            this.stb_remote_pdir.Name = "stb_remote_pdir";
            this.stb_remote_pdir.NormlBack = null;
            this.stb_remote_pdir.Padding = new System.Windows.Forms.Padding(5);
            this.stb_remote_pdir.ReadOnly = false;
            this.stb_remote_pdir.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.stb_remote_pdir.Size = new System.Drawing.Size(423, 28);
            // 
            // 
            // 
            this.stb_remote_pdir.SkinTxt.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.stb_remote_pdir.SkinTxt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.stb_remote_pdir.SkinTxt.Font = new System.Drawing.Font("微软雅黑", 9.75F);
            this.stb_remote_pdir.SkinTxt.Location = new System.Drawing.Point(5, 5);
            this.stb_remote_pdir.SkinTxt.Name = "BaseText";
            this.stb_remote_pdir.SkinTxt.Size = new System.Drawing.Size(413, 18);
            this.stb_remote_pdir.SkinTxt.TabIndex = 0;
            this.stb_remote_pdir.SkinTxt.WaterColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(127)))), ((int)(((byte)(127)))));
            this.stb_remote_pdir.SkinTxt.WaterText = "服务器项目目录，例如：~/xxxsrv";
            this.stb_remote_pdir.TabIndex = 18;
            this.stb_remote_pdir.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.stb_remote_pdir.WaterColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(127)))), ((int)(((byte)(127)))));
            this.stb_remote_pdir.WaterText = "服务器项目目录，例如：~/xxxsrv";
            this.stb_remote_pdir.WordWrap = true;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.btn_choose_mvnxml);
            this.groupBox1.Controls.Add(this.checkBox2);
            this.groupBox1.Controls.Add(this.stb_maven_xml);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.checkBox1);
            this.groupBox1.Controls.Add(this.stb_icexml);
            this.groupBox1.Controls.Add(this.stb_local_pdir);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.btn_choose_xml);
            this.groupBox1.Controls.Add(this.btn_choose_dir);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(17, 37);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(694, 199);
            this.groupBox1.TabIndex = 20;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "本地";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.Color.PaleVioletRed;
            this.label6.Location = new System.Drawing.Point(92, 137);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(185, 12);
            this.label6.TabIndex = 24;
            this.label6.Text = "不勾选此项代表跳过“打包”步骤";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.PaleVioletRed;
            this.label5.Location = new System.Drawing.Point(105, 67);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(209, 12);
            this.label5.TabIndex = 23;
            this.label5.Text = "不勾选此项代表跳过“更新配置”步骤";
            // 
            // btn_choose_mvnxml
            // 
            this.btn_choose_mvnxml.Enabled = false;
            this.btn_choose_mvnxml.Location = new System.Drawing.Point(608, 158);
            this.btn_choose_mvnxml.Name = "btn_choose_mvnxml";
            this.btn_choose_mvnxml.Size = new System.Drawing.Size(72, 29);
            this.btn_choose_mvnxml.TabIndex = 22;
            this.btn_choose_mvnxml.Text = "选择文件";
            this.btn_choose_mvnxml.UseVisualStyleBackColor = true;
            this.btn_choose_mvnxml.Click += new System.EventHandler(this.btn_choose_mvnxml_Click);
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.checkBox2.Location = new System.Drawing.Point(18, 136);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(72, 16);
            this.checkBox2.TabIndex = 21;
            this.checkBox2.Text = "自动打包";
            this.checkBox2.UseVisualStyleBackColor = true;
            this.checkBox2.CheckedChanged += new System.EventHandler(this.checkBox2_CheckedChanged);
            // 
            // stb_maven_xml
            // 
            this.stb_maven_xml.AllowDrop = true;
            this.stb_maven_xml.BackColor = System.Drawing.Color.Transparent;
            this.stb_maven_xml.DownBack = null;
            this.stb_maven_xml.Enabled = false;
            this.stb_maven_xml.Icon = null;
            this.stb_maven_xml.IconIsButton = false;
            this.stb_maven_xml.IconMouseState = CCWin.SkinClass.ControlState.Normal;
            this.stb_maven_xml.IsPasswordChat = '\0';
            this.stb_maven_xml.IsSystemPasswordChar = false;
            this.stb_maven_xml.Lines = new string[0];
            this.stb_maven_xml.Location = new System.Drawing.Point(177, 158);
            this.stb_maven_xml.Margin = new System.Windows.Forms.Padding(0);
            this.stb_maven_xml.MaxLength = 32767;
            this.stb_maven_xml.MinimumSize = new System.Drawing.Size(28, 28);
            this.stb_maven_xml.MouseBack = null;
            this.stb_maven_xml.MouseState = CCWin.SkinClass.ControlState.Normal;
            this.stb_maven_xml.Multiline = false;
            this.stb_maven_xml.Name = "stb_maven_xml";
            this.stb_maven_xml.NormlBack = null;
            this.stb_maven_xml.Padding = new System.Windows.Forms.Padding(5);
            this.stb_maven_xml.ReadOnly = false;
            this.stb_maven_xml.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.stb_maven_xml.Size = new System.Drawing.Size(423, 28);
            // 
            // 
            // 
            this.stb_maven_xml.SkinTxt.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.stb_maven_xml.SkinTxt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.stb_maven_xml.SkinTxt.Font = new System.Drawing.Font("微软雅黑", 9.75F);
            this.stb_maven_xml.SkinTxt.Location = new System.Drawing.Point(5, 5);
            this.stb_maven_xml.SkinTxt.Name = "BaseText";
            this.stb_maven_xml.SkinTxt.Size = new System.Drawing.Size(413, 18);
            this.stb_maven_xml.SkinTxt.TabIndex = 0;
            this.stb_maven_xml.SkinTxt.WaterColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(127)))), ((int)(((byte)(127)))));
            this.stb_maven_xml.SkinTxt.WaterText = "Maven 配置文件：setting.xml，支持拖拽";
            this.stb_maven_xml.TabIndex = 19;
            this.stb_maven_xml.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.stb_maven_xml.WaterColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(127)))), ((int)(((byte)(127)))));
            this.stb_maven_xml.WaterText = "Maven 配置文件：setting.xml，支持拖拽";
            this.stb_maven_xml.WordWrap = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label4.Location = new System.Drawing.Point(39, 162);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(125, 20);
            this.label4.TabIndex = 20;
            this.label4.Text = "Maven配置文件：";
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.checkBox1.Location = new System.Drawing.Point(18, 65);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(84, 16);
            this.checkBox1.TabIndex = 18;
            this.checkBox1.Text = "配置有更新";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.Transparent;
            this.groupBox2.Controls.Add(this.stb_remote_pdir);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Location = new System.Drawing.Point(17, 243);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(694, 64);
            this.groupBox2.TabIndex = 21;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "服务器";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.Color.Transparent;
            this.groupBox3.Controls.Add(this.l_state4);
            this.groupBox3.Controls.Add(this.pb_state4);
            this.groupBox3.Controls.Add(this.line_state3);
            this.groupBox3.Controls.Add(this.line_state2);
            this.groupBox3.Controls.Add(this.l_state3);
            this.groupBox3.Controls.Add(this.pb_state3);
            this.groupBox3.Controls.Add(this.l_state2);
            this.groupBox3.Controls.Add(this.pb_state2);
            this.groupBox3.Controls.Add(this.line_state1);
            this.groupBox3.Controls.Add(this.l_state1);
            this.groupBox3.Controls.Add(this.pb_state1);
            this.groupBox3.Location = new System.Drawing.Point(17, 314);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(694, 131);
            this.groupBox3.TabIndex = 22;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "步骤";
            // 
            // l_state4
            // 
            this.l_state4.AutoSize = true;
            this.l_state4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.l_state4.ForeColor = System.Drawing.Color.White;
            this.l_state4.Location = new System.Drawing.Point(602, 61);
            this.l_state4.Name = "l_state4";
            this.l_state4.Size = new System.Drawing.Size(29, 12);
            this.l_state4.TabIndex = 27;
            this.l_state4.Text = "完成";
            // 
            // pb_state4
            // 
            this.pb_state4.BackgroundImage = global::AppMonitor.Properties.Resources.Circle_72px0;
            this.pb_state4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pb_state4.Location = new System.Drawing.Point(579, 32);
            this.pb_state4.Name = "pb_state4";
            this.pb_state4.Size = new System.Drawing.Size(72, 72);
            this.pb_state4.TabIndex = 26;
            this.pb_state4.TabStop = false;
            // 
            // line_state3
            // 
            this.line_state3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.line_state3.Location = new System.Drawing.Point(496, 61);
            this.line_state3.Name = "line_state3";
            this.line_state3.Size = new System.Drawing.Size(60, 4);
            this.line_state3.TabIndex = 25;
            // 
            // line_state2
            // 
            this.line_state2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.line_state2.Location = new System.Drawing.Point(317, 61);
            this.line_state2.Name = "line_state2";
            this.line_state2.Size = new System.Drawing.Size(60, 4);
            this.line_state2.TabIndex = 5;
            // 
            // l_state3
            // 
            this.l_state3.AutoSize = true;
            this.l_state3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.l_state3.ForeColor = System.Drawing.Color.White;
            this.l_state3.Location = new System.Drawing.Point(412, 61);
            this.l_state3.Name = "l_state3";
            this.l_state3.Size = new System.Drawing.Size(53, 12);
            this.l_state3.TabIndex = 24;
            this.l_state3.Text = "重启服务";
            // 
            // pb_state3
            // 
            this.pb_state3.BackgroundImage = global::AppMonitor.Properties.Resources.Circle_72px0;
            this.pb_state3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pb_state3.Location = new System.Drawing.Point(402, 32);
            this.pb_state3.Name = "pb_state3";
            this.pb_state3.Size = new System.Drawing.Size(72, 72);
            this.pb_state3.TabIndex = 23;
            this.pb_state3.TabStop = false;
            // 
            // l_state2
            // 
            this.l_state2.AutoSize = true;
            this.l_state2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.l_state2.ForeColor = System.Drawing.Color.White;
            this.l_state2.Location = new System.Drawing.Point(232, 61);
            this.l_state2.Name = "l_state2";
            this.l_state2.Size = new System.Drawing.Size(53, 12);
            this.l_state2.TabIndex = 4;
            this.l_state2.Text = "更新配置";
            // 
            // pb_state2
            // 
            this.pb_state2.BackgroundImage = global::AppMonitor.Properties.Resources.Circle_72px0;
            this.pb_state2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pb_state2.Location = new System.Drawing.Point(222, 32);
            this.pb_state2.Name = "pb_state2";
            this.pb_state2.Size = new System.Drawing.Size(72, 72);
            this.pb_state2.TabIndex = 3;
            this.pb_state2.TabStop = false;
            // 
            // line_state1
            // 
            this.line_state1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.line_state1.Location = new System.Drawing.Point(138, 61);
            this.line_state1.Name = "line_state1";
            this.line_state1.Size = new System.Drawing.Size(60, 4);
            this.line_state1.TabIndex = 2;
            // 
            // l_state1
            // 
            this.l_state1.AutoSize = true;
            this.l_state1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.l_state1.ForeColor = System.Drawing.Color.White;
            this.l_state1.Location = new System.Drawing.Point(51, 61);
            this.l_state1.Name = "l_state1";
            this.l_state1.Size = new System.Drawing.Size(53, 12);
            this.l_state1.TabIndex = 1;
            this.l_state1.Text = "打包上传";
            // 
            // pb_state1
            // 
            this.pb_state1.BackgroundImage = global::AppMonitor.Properties.Resources.Circle_72px0;
            this.pb_state1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pb_state1.Location = new System.Drawing.Point(42, 32);
            this.pb_state1.Name = "pb_state1";
            this.pb_state1.Size = new System.Drawing.Size(72, 72);
            this.pb_state1.TabIndex = 0;
            this.pb_state1.TabStop = false;
            // 
            // errorLabel
            // 
            this.errorLabel.BackColor = System.Drawing.Color.Transparent;
            this.errorLabel.Font = new System.Drawing.Font("宋体", 10F);
            this.errorLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.errorLabel.Location = new System.Drawing.Point(20, 455);
            this.errorLabel.Name = "errorLabel";
            this.errorLabel.Size = new System.Drawing.Size(436, 34);
            this.errorLabel.TabIndex = 23;
            // 
            // gifBox1
            // 
            this.gifBox1.BackColor = System.Drawing.Color.Transparent;
            this.gifBox1.BorderColor = System.Drawing.Color.Transparent;
            this.gifBox1.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.gifBox1.Image = global::AppMonitor.Properties.Resources.loading2;
            this.gifBox1.Location = new System.Drawing.Point(475, 452);
            this.gifBox1.Name = "gifBox1";
            this.gifBox1.Size = new System.Drawing.Size(36, 36);
            this.gifBox1.TabIndex = 24;
            this.gifBox1.Visible = false;
            // 
            // IceDeployVersionForm
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.BackgroundImage = global::AppMonitor.Properties.Resources.skin_12;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.CaptionFont = new System.Drawing.Font("微软雅黑", 9F);
            this.ClientSize = new System.Drawing.Size(730, 505);
            this.Controls.Add(this.gifBox1);
            this.Controls.Add(this.errorLabel);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btn_cancel);
            this.Controls.Add(this.btn_start);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(730, 505);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(730, 505);
            this.Name = "IceDeployVersionForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "一键部署Ice项目";
            this.TitleCenter = false;
            this.TitleColor = System.Drawing.Color.White;
            this.Load += new System.EventHandler(this.IceDeployVersionForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pb_state4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_state3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_state2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_state1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private CCWin.SkinControl.SkinTextBox stb_local_pdir;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_start;
        private System.Windows.Forms.Button btn_cancel;
        private System.Windows.Forms.Button btn_choose_dir;
        private System.Windows.Forms.Label label2;
        private CCWin.SkinControl.SkinTextBox stb_icexml;
        private System.Windows.Forms.Button btn_choose_xml;
        private System.Windows.Forms.Label label3;
        private CCWin.SkinControl.SkinTextBox stb_remote_pdir;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.PictureBox pb_state1;
        private System.Windows.Forms.Label l_state1;
        private System.Windows.Forms.Label line_state1;
        private System.Windows.Forms.Label line_state3;
        private System.Windows.Forms.Label line_state2;
        private System.Windows.Forms.Label l_state3;
        private System.Windows.Forms.PictureBox pb_state3;
        private System.Windows.Forms.Label l_state2;
        private System.Windows.Forms.PictureBox pb_state2;
        private System.Windows.Forms.Label l_state4;
        private System.Windows.Forms.PictureBox pb_state4;
        private System.Windows.Forms.Label errorLabel;
        private CCWin.SkinControl.SkinTextBox stb_maven_xml;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btn_choose_mvnxml;
        private System.Windows.Forms.CheckBox checkBox2;
        private CCWin.SkinControl.GifBox gifBox1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
    }
}