namespace AppMonitor.Froms
{
    partial class MonitorItemForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MonitorItemForm));
            this.label1 = new System.Windows.Forms.Label();
            this.stb_tomcat_path = new CCWin.SkinControl.SkinTextBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tab_springboot = new System.Windows.Forms.TabPage();
            this.label11 = new System.Windows.Forms.Label();
            this.stb_home_url = new CCWin.SkinControl.SkinTextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label9 = new System.Windows.Forms.Label();
            this.stb_project_svn = new CCWin.SkinControl.SkinTextBox();
            this.cb_need_add = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.stb_project_source_dir = new CCWin.SkinControl.SkinTextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.stb_ctl_file = new CCWin.SkinControl.SkinTextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.stb_build_file = new CCWin.SkinControl.SkinTextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.stb_app_name = new CCWin.SkinControl.SkinTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.stb_sh_dir = new CCWin.SkinControl.SkinTextBox();
            this.tab_tomcat = new System.Windows.Forms.TabPage();
            this.label12 = new System.Windows.Forms.Label();
            this.stb_tomcat_port = new CCWin.SkinControl.SkinTextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.stb_tomcat_name = new CCWin.SkinControl.SkinTextBox();
            this.tab_nginx = new System.Windows.Forms.TabPage();
            this.label13 = new System.Windows.Forms.Label();
            this.stb_nginx_conf = new CCWin.SkinControl.SkinTextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.stb_nginx_path = new CCWin.SkinControl.SkinTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.stb_nginx_name = new CCWin.SkinControl.SkinTextBox();
            this.tab_ice = new System.Windows.Forms.TabPage();
            this.label17 = new System.Windows.Forms.Label();
            this.stb_ice_servername = new CCWin.SkinControl.SkinTextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.stb_ice_ports = new CCWin.SkinControl.SkinTextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.stb_ice_srvpath = new CCWin.SkinControl.SkinTextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.stb_ice_appname = new CCWin.SkinControl.SkinTextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.toolTip_contextname = new System.Windows.Forms.ToolTip(this.components);
            this.label18 = new System.Windows.Forms.Label();
            this.stb_disconfig_url = new CCWin.SkinControl.SkinTextBox();
            this.tabControl1.SuspendLayout();
            this.tab_springboot.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tab_tomcat.SuspendLayout();
            this.tab_nginx.SuspendLayout();
            this.tab_ice.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(137, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tomcat Home Location：";
            // 
            // stb_tomcat_path
            // 
            this.stb_tomcat_path.BackColor = System.Drawing.Color.Transparent;
            this.stb_tomcat_path.DownBack = null;
            this.stb_tomcat_path.Icon = null;
            this.stb_tomcat_path.IconIsButton = false;
            this.stb_tomcat_path.IconMouseState = CCWin.SkinClass.ControlState.Normal;
            this.stb_tomcat_path.IsPasswordChat = '\0';
            this.stb_tomcat_path.IsSystemPasswordChar = false;
            this.stb_tomcat_path.Lines = new string[0];
            this.stb_tomcat_path.Location = new System.Drawing.Point(21, 48);
            this.stb_tomcat_path.Margin = new System.Windows.Forms.Padding(0);
            this.stb_tomcat_path.MaxLength = 32767;
            this.stb_tomcat_path.MinimumSize = new System.Drawing.Size(28, 28);
            this.stb_tomcat_path.MouseBack = null;
            this.stb_tomcat_path.MouseState = CCWin.SkinClass.ControlState.Normal;
            this.stb_tomcat_path.Multiline = false;
            this.stb_tomcat_path.Name = "stb_tomcat_path";
            this.stb_tomcat_path.NormlBack = null;
            this.stb_tomcat_path.Padding = new System.Windows.Forms.Padding(5);
            this.stb_tomcat_path.ReadOnly = false;
            this.stb_tomcat_path.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.stb_tomcat_path.Size = new System.Drawing.Size(578, 28);
            // 
            // 
            // 
            this.stb_tomcat_path.SkinTxt.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.stb_tomcat_path.SkinTxt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.stb_tomcat_path.SkinTxt.Font = new System.Drawing.Font("微软雅黑", 9.75F);
            this.stb_tomcat_path.SkinTxt.Location = new System.Drawing.Point(5, 5);
            this.stb_tomcat_path.SkinTxt.Name = "BaseText";
            this.stb_tomcat_path.SkinTxt.Size = new System.Drawing.Size(568, 18);
            this.stb_tomcat_path.SkinTxt.TabIndex = 0;
            this.stb_tomcat_path.SkinTxt.WaterColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(127)))), ((int)(((byte)(127)))));
            this.stb_tomcat_path.SkinTxt.WaterText = "Tomcat路径，例如：/home/gxb/soft/apache-tomcat-8.0.36";
            this.stb_tomcat_path.TabIndex = 1;
            this.stb_tomcat_path.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.toolTip_contextname.SetToolTip(this.stb_tomcat_path, "Tomcat路径，例如：/home/gxb/soft/apache-tomcat-8.0.36");
            this.stb_tomcat_path.WaterColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(127)))), ((int)(((byte)(127)))));
            this.stb_tomcat_path.WaterText = "Tomcat路径，例如：/home/gxb/soft/apache-tomcat-8.0.36";
            this.stb_tomcat_path.WordWrap = true;
            // 
            // tabControl1
            // 
            this.tabControl1.Appearance = System.Windows.Forms.TabAppearance.FlatButtons;
            this.tabControl1.Controls.Add(this.tab_springboot);
            this.tabControl1.Controls.Add(this.tab_tomcat);
            this.tabControl1.Controls.Add(this.tab_nginx);
            this.tabControl1.Controls.Add(this.tab_ice);
            this.tabControl1.Location = new System.Drawing.Point(11, 34);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(625, 486);
            this.tabControl1.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tabControl1.TabIndex = 2;
            // 
            // tab_springboot
            // 
            this.tab_springboot.Controls.Add(this.label11);
            this.tab_springboot.Controls.Add(this.stb_home_url);
            this.tab_springboot.Controls.Add(this.groupBox1);
            this.tab_springboot.Controls.Add(this.label3);
            this.tab_springboot.Controls.Add(this.stb_project_source_dir);
            this.tab_springboot.Controls.Add(this.label8);
            this.tab_springboot.Controls.Add(this.stb_ctl_file);
            this.tab_springboot.Controls.Add(this.label7);
            this.tab_springboot.Controls.Add(this.stb_build_file);
            this.tab_springboot.Controls.Add(this.label6);
            this.tab_springboot.Controls.Add(this.stb_app_name);
            this.tab_springboot.Controls.Add(this.label2);
            this.tab_springboot.Controls.Add(this.stb_sh_dir);
            this.tab_springboot.Location = new System.Drawing.Point(4, 25);
            this.tab_springboot.Name = "tab_springboot";
            this.tab_springboot.Size = new System.Drawing.Size(617, 457);
            this.tab_springboot.TabIndex = 2;
            this.tab_springboot.Text = "SpringBoot App";
            this.tab_springboot.UseVisualStyleBackColor = true;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(61, 66);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(89, 12);
            this.label11.TabIndex = 12;
            this.label11.Text = "App Home Url：";
            // 
            // stb_home_url
            // 
            this.stb_home_url.BackColor = System.Drawing.Color.Transparent;
            this.stb_home_url.DownBack = null;
            this.stb_home_url.Icon = null;
            this.stb_home_url.IconIsButton = false;
            this.stb_home_url.IconMouseState = CCWin.SkinClass.ControlState.Normal;
            this.stb_home_url.IsPasswordChat = '\0';
            this.stb_home_url.IsSystemPasswordChar = false;
            this.stb_home_url.Lines = new string[0];
            this.stb_home_url.Location = new System.Drawing.Point(154, 59);
            this.stb_home_url.Margin = new System.Windows.Forms.Padding(0);
            this.stb_home_url.MaxLength = 32767;
            this.stb_home_url.MinimumSize = new System.Drawing.Size(28, 28);
            this.stb_home_url.MouseBack = null;
            this.stb_home_url.MouseState = CCWin.SkinClass.ControlState.Normal;
            this.stb_home_url.Multiline = false;
            this.stb_home_url.Name = "stb_home_url";
            this.stb_home_url.NormlBack = null;
            this.stb_home_url.Padding = new System.Windows.Forms.Padding(5);
            this.stb_home_url.ReadOnly = false;
            this.stb_home_url.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.stb_home_url.Size = new System.Drawing.Size(450, 28);
            // 
            // 
            // 
            this.stb_home_url.SkinTxt.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.stb_home_url.SkinTxt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.stb_home_url.SkinTxt.Font = new System.Drawing.Font("微软雅黑", 9.75F);
            this.stb_home_url.SkinTxt.Location = new System.Drawing.Point(5, 5);
            this.stb_home_url.SkinTxt.Name = "BaseText";
            this.stb_home_url.SkinTxt.Size = new System.Drawing.Size(440, 18);
            this.stb_home_url.SkinTxt.TabIndex = 0;
            this.stb_home_url.SkinTxt.WaterColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(127)))), ((int)(((byte)(127)))));
            this.stb_home_url.SkinTxt.WaterText = "应用主页访问地址，例如：http://192.168.20.*:[port]/";
            this.stb_home_url.TabIndex = 13;
            this.stb_home_url.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.stb_home_url.WaterColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(127)))), ((int)(((byte)(127)))));
            this.stb_home_url.WaterText = "应用主页访问地址，例如：http://192.168.20.*:[port]/";
            this.stb_home_url.WordWrap = true;
            this.stb_home_url.Enter += new System.EventHandler(this.stb_home_url_Enter);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label18);
            this.groupBox1.Controls.Add(this.stb_disconfig_url);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.stb_project_svn);
            this.groupBox1.Controls.Add(this.cb_need_add);
            this.groupBox1.Location = new System.Drawing.Point(7, 293);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(605, 155);
            this.groupBox1.TabIndex = 11;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "          ";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(18, 29);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(89, 12);
            this.label9.TabIndex = 7;
            this.label9.Text = "Code Svn Url：";
            // 
            // stb_project_svn
            // 
            this.stb_project_svn.BackColor = System.Drawing.Color.Transparent;
            this.stb_project_svn.DownBack = null;
            this.stb_project_svn.Enabled = false;
            this.stb_project_svn.Icon = null;
            this.stb_project_svn.IconIsButton = false;
            this.stb_project_svn.IconMouseState = CCWin.SkinClass.ControlState.Normal;
            this.stb_project_svn.IsPasswordChat = '\0';
            this.stb_project_svn.IsSystemPasswordChar = false;
            this.stb_project_svn.Lines = new string[0];
            this.stb_project_svn.Location = new System.Drawing.Point(18, 55);
            this.stb_project_svn.Margin = new System.Windows.Forms.Padding(0);
            this.stb_project_svn.MaxLength = 32767;
            this.stb_project_svn.MinimumSize = new System.Drawing.Size(28, 28);
            this.stb_project_svn.MouseBack = null;
            this.stb_project_svn.MouseState = CCWin.SkinClass.ControlState.Normal;
            this.stb_project_svn.Multiline = false;
            this.stb_project_svn.Name = "stb_project_svn";
            this.stb_project_svn.NormlBack = null;
            this.stb_project_svn.Padding = new System.Windows.Forms.Padding(5);
            this.stb_project_svn.ReadOnly = false;
            this.stb_project_svn.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.stb_project_svn.Size = new System.Drawing.Size(579, 28);
            // 
            // 
            // 
            this.stb_project_svn.SkinTxt.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.stb_project_svn.SkinTxt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.stb_project_svn.SkinTxt.Font = new System.Drawing.Font("微软雅黑", 9.75F);
            this.stb_project_svn.SkinTxt.Location = new System.Drawing.Point(5, 5);
            this.stb_project_svn.SkinTxt.Name = "BaseText";
            this.stb_project_svn.SkinTxt.Size = new System.Drawing.Size(569, 18);
            this.stb_project_svn.SkinTxt.TabIndex = 0;
            this.stb_project_svn.SkinTxt.WaterColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(127)))), ((int)(((byte)(127)))));
            this.stb_project_svn.SkinTxt.WaterText = "项目SVN路径，例如：svn://192.168.20.26/GxbPlatform/05_%E8%BD%AF%E4%BB%B6%E7%BC%96%E7%A0%8" +
    "1/trunck/gxbow";
            this.stb_project_svn.TabIndex = 6;
            this.stb_project_svn.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.stb_project_svn.WaterColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(127)))), ((int)(((byte)(127)))));
            this.stb_project_svn.WaterText = "项目SVN路径，例如：svn://192.168.20.26/GxbPlatform/05_%E8%BD%AF%E4%BB%B6%E7%BC%96%E7%A0%8" +
    "1/trunck/gxbow";
            this.stb_project_svn.WordWrap = true;
            // 
            // cb_need_add
            // 
            this.cb_need_add.AutoSize = true;
            this.cb_need_add.Location = new System.Drawing.Point(18, 1);
            this.cb_need_add.Name = "cb_need_add";
            this.cb_need_add.Size = new System.Drawing.Size(96, 16);
            this.cb_need_add.TabIndex = 6;
            this.cb_need_add.Text = "New Checkout";
            this.cb_need_add.UseVisualStyleBackColor = true;
            this.cb_need_add.CheckedChanged += new System.EventHandler(this.cb_need_add_CheckedChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 246);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(137, 12);
            this.label3.TabIndex = 4;
            this.label3.Text = "Code Source Location：";
            // 
            // stb_project_source_dir
            // 
            this.stb_project_source_dir.BackColor = System.Drawing.Color.Transparent;
            this.stb_project_source_dir.DownBack = null;
            this.stb_project_source_dir.Icon = global::AppMonitor.Properties.Resources.write_16px;
            this.stb_project_source_dir.IconIsButton = true;
            this.stb_project_source_dir.IconMouseState = CCWin.SkinClass.ControlState.Normal;
            this.stb_project_source_dir.IsPasswordChat = '\0';
            this.stb_project_source_dir.IsSystemPasswordChar = false;
            this.stb_project_source_dir.Lines = new string[0];
            this.stb_project_source_dir.Location = new System.Drawing.Point(154, 239);
            this.stb_project_source_dir.Margin = new System.Windows.Forms.Padding(0);
            this.stb_project_source_dir.MaxLength = 32767;
            this.stb_project_source_dir.MinimumSize = new System.Drawing.Size(28, 28);
            this.stb_project_source_dir.MouseBack = null;
            this.stb_project_source_dir.MouseState = CCWin.SkinClass.ControlState.Normal;
            this.stb_project_source_dir.Multiline = false;
            this.stb_project_source_dir.Name = "stb_project_source_dir";
            this.stb_project_source_dir.NormlBack = null;
            this.stb_project_source_dir.Padding = new System.Windows.Forms.Padding(5, 5, 28, 5);
            this.stb_project_source_dir.ReadOnly = false;
            this.stb_project_source_dir.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.stb_project_source_dir.Size = new System.Drawing.Size(450, 28);
            // 
            // 
            // 
            this.stb_project_source_dir.SkinTxt.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.stb_project_source_dir.SkinTxt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.stb_project_source_dir.SkinTxt.Font = new System.Drawing.Font("微软雅黑", 9.75F);
            this.stb_project_source_dir.SkinTxt.Location = new System.Drawing.Point(5, 5);
            this.stb_project_source_dir.SkinTxt.Name = "BaseText";
            this.stb_project_source_dir.SkinTxt.Size = new System.Drawing.Size(417, 18);
            this.stb_project_source_dir.SkinTxt.TabIndex = 0;
            this.stb_project_source_dir.SkinTxt.WaterColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(127)))), ((int)(((byte)(127)))));
            this.stb_project_source_dir.SkinTxt.WaterText = "项目代码路径，例如：/home/gxb/sources";
            this.stb_project_source_dir.TabIndex = 5;
            this.stb_project_source_dir.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.stb_project_source_dir.WaterColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(127)))), ((int)(((byte)(127)))));
            this.stb_project_source_dir.WaterText = "项目代码路径，例如：/home/gxb/sources";
            this.stb_project_source_dir.WordWrap = true;
            this.stb_project_source_dir.IconClick += new System.EventHandler(this.stb_project_source_dir_IconClick);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(73, 201);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(77, 12);
            this.label8.TabIndex = 9;
            this.label8.Text = "Control Sh：";
            // 
            // stb_ctl_file
            // 
            this.stb_ctl_file.BackColor = System.Drawing.Color.Transparent;
            this.stb_ctl_file.DownBack = null;
            this.stb_ctl_file.Icon = null;
            this.stb_ctl_file.IconIsButton = false;
            this.stb_ctl_file.IconMouseState = CCWin.SkinClass.ControlState.Normal;
            this.stb_ctl_file.IsPasswordChat = '\0';
            this.stb_ctl_file.IsSystemPasswordChar = false;
            this.stb_ctl_file.Lines = new string[0];
            this.stb_ctl_file.Location = new System.Drawing.Point(154, 194);
            this.stb_ctl_file.Margin = new System.Windows.Forms.Padding(0);
            this.stb_ctl_file.MaxLength = 32767;
            this.stb_ctl_file.MinimumSize = new System.Drawing.Size(28, 28);
            this.stb_ctl_file.MouseBack = null;
            this.stb_ctl_file.MouseState = CCWin.SkinClass.ControlState.Normal;
            this.stb_ctl_file.Multiline = false;
            this.stb_ctl_file.Name = "stb_ctl_file";
            this.stb_ctl_file.NormlBack = null;
            this.stb_ctl_file.Padding = new System.Windows.Forms.Padding(5);
            this.stb_ctl_file.ReadOnly = false;
            this.stb_ctl_file.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.stb_ctl_file.Size = new System.Drawing.Size(450, 28);
            // 
            // 
            // 
            this.stb_ctl_file.SkinTxt.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.stb_ctl_file.SkinTxt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.stb_ctl_file.SkinTxt.Font = new System.Drawing.Font("微软雅黑", 9.75F);
            this.stb_ctl_file.SkinTxt.Location = new System.Drawing.Point(5, 5);
            this.stb_ctl_file.SkinTxt.Name = "BaseText";
            this.stb_ctl_file.SkinTxt.Size = new System.Drawing.Size(440, 18);
            this.stb_ctl_file.SkinTxt.TabIndex = 0;
            this.stb_ctl_file.SkinTxt.Tag = "ctl";
            this.stb_ctl_file.SkinTxt.WaterColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(127)))), ((int)(((byte)(127)))));
            this.stb_ctl_file.SkinTxt.WaterText = "sh文件，例如：omp_ctl.sh";
            this.stb_ctl_file.TabIndex = 10;
            this.stb_ctl_file.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.stb_ctl_file.WaterColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(127)))), ((int)(((byte)(127)))));
            this.stb_ctl_file.WaterText = "sh文件，例如：omp_ctl.sh";
            this.stb_ctl_file.WordWrap = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(85, 156);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(65, 12);
            this.label7.TabIndex = 7;
            this.label7.Text = "Build Sh：";
            // 
            // stb_build_file
            // 
            this.stb_build_file.BackColor = System.Drawing.Color.Transparent;
            this.stb_build_file.DownBack = null;
            this.stb_build_file.Icon = null;
            this.stb_build_file.IconIsButton = false;
            this.stb_build_file.IconMouseState = CCWin.SkinClass.ControlState.Normal;
            this.stb_build_file.IsPasswordChat = '\0';
            this.stb_build_file.IsSystemPasswordChar = false;
            this.stb_build_file.Lines = new string[0];
            this.stb_build_file.Location = new System.Drawing.Point(154, 149);
            this.stb_build_file.Margin = new System.Windows.Forms.Padding(0);
            this.stb_build_file.MaxLength = 32767;
            this.stb_build_file.MinimumSize = new System.Drawing.Size(28, 28);
            this.stb_build_file.MouseBack = null;
            this.stb_build_file.MouseState = CCWin.SkinClass.ControlState.Normal;
            this.stb_build_file.Multiline = false;
            this.stb_build_file.Name = "stb_build_file";
            this.stb_build_file.NormlBack = null;
            this.stb_build_file.Padding = new System.Windows.Forms.Padding(5);
            this.stb_build_file.ReadOnly = false;
            this.stb_build_file.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.stb_build_file.Size = new System.Drawing.Size(450, 28);
            // 
            // 
            // 
            this.stb_build_file.SkinTxt.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.stb_build_file.SkinTxt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.stb_build_file.SkinTxt.Font = new System.Drawing.Font("微软雅黑", 9.75F);
            this.stb_build_file.SkinTxt.Location = new System.Drawing.Point(5, 5);
            this.stb_build_file.SkinTxt.Name = "BaseText";
            this.stb_build_file.SkinTxt.Size = new System.Drawing.Size(440, 18);
            this.stb_build_file.SkinTxt.TabIndex = 0;
            this.stb_build_file.SkinTxt.Tag = "build";
            this.stb_build_file.SkinTxt.WaterColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(127)))), ((int)(((byte)(127)))));
            this.stb_build_file.SkinTxt.WaterText = "sh文件，例如：omp_build.sh";
            this.stb_build_file.TabIndex = 8;
            this.stb_build_file.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.stb_build_file.WaterColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(127)))), ((int)(((byte)(127)))));
            this.stb_build_file.WaterText = "sh文件，例如：omp_build.sh";
            this.stb_build_file.WordWrap = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(85, 21);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 12);
            this.label6.TabIndex = 4;
            this.label6.Text = "App Name：";
            // 
            // stb_app_name
            // 
            this.stb_app_name.BackColor = System.Drawing.Color.Transparent;
            this.stb_app_name.DownBack = null;
            this.stb_app_name.Icon = null;
            this.stb_app_name.IconIsButton = false;
            this.stb_app_name.IconMouseState = CCWin.SkinClass.ControlState.Normal;
            this.stb_app_name.IsPasswordChat = '\0';
            this.stb_app_name.IsSystemPasswordChar = false;
            this.stb_app_name.Lines = new string[0];
            this.stb_app_name.Location = new System.Drawing.Point(154, 14);
            this.stb_app_name.Margin = new System.Windows.Forms.Padding(0);
            this.stb_app_name.MaxLength = 32767;
            this.stb_app_name.MinimumSize = new System.Drawing.Size(28, 28);
            this.stb_app_name.MouseBack = null;
            this.stb_app_name.MouseState = CCWin.SkinClass.ControlState.Normal;
            this.stb_app_name.Multiline = false;
            this.stb_app_name.Name = "stb_app_name";
            this.stb_app_name.NormlBack = null;
            this.stb_app_name.Padding = new System.Windows.Forms.Padding(5);
            this.stb_app_name.ReadOnly = false;
            this.stb_app_name.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.stb_app_name.Size = new System.Drawing.Size(450, 28);
            // 
            // 
            // 
            this.stb_app_name.SkinTxt.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.stb_app_name.SkinTxt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.stb_app_name.SkinTxt.Font = new System.Drawing.Font("微软雅黑", 9.75F);
            this.stb_app_name.SkinTxt.Location = new System.Drawing.Point(5, 5);
            this.stb_app_name.SkinTxt.Name = "BaseText";
            this.stb_app_name.SkinTxt.Size = new System.Drawing.Size(440, 18);
            this.stb_app_name.SkinTxt.TabIndex = 0;
            this.stb_app_name.SkinTxt.WaterColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(127)))), ((int)(((byte)(127)))));
            this.stb_app_name.SkinTxt.WaterText = "应用名称（项目简称），例如：omp";
            this.stb_app_name.TabIndex = 5;
            this.stb_app_name.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.stb_app_name.WaterColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(127)))), ((int)(((byte)(127)))));
            this.stb_app_name.WaterText = "应用名称（项目简称），例如：omp";
            this.stb_app_name.WordWrap = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(43, 111);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(107, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "Sh Bin Location：";
            // 
            // stb_sh_dir
            // 
            this.stb_sh_dir.BackColor = System.Drawing.Color.Transparent;
            this.stb_sh_dir.DownBack = null;
            this.stb_sh_dir.Icon = global::AppMonitor.Properties.Resources.write_16px;
            this.stb_sh_dir.IconIsButton = true;
            this.stb_sh_dir.IconMouseState = CCWin.SkinClass.ControlState.Normal;
            this.stb_sh_dir.IsPasswordChat = '\0';
            this.stb_sh_dir.IsSystemPasswordChar = false;
            this.stb_sh_dir.Lines = new string[0];
            this.stb_sh_dir.Location = new System.Drawing.Point(154, 104);
            this.stb_sh_dir.Margin = new System.Windows.Forms.Padding(0);
            this.stb_sh_dir.MaxLength = 32767;
            this.stb_sh_dir.MinimumSize = new System.Drawing.Size(28, 28);
            this.stb_sh_dir.MouseBack = null;
            this.stb_sh_dir.MouseState = CCWin.SkinClass.ControlState.Normal;
            this.stb_sh_dir.Multiline = false;
            this.stb_sh_dir.Name = "stb_sh_dir";
            this.stb_sh_dir.NormlBack = null;
            this.stb_sh_dir.Padding = new System.Windows.Forms.Padding(5, 5, 28, 5);
            this.stb_sh_dir.ReadOnly = false;
            this.stb_sh_dir.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.stb_sh_dir.Size = new System.Drawing.Size(450, 28);
            // 
            // 
            // 
            this.stb_sh_dir.SkinTxt.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.stb_sh_dir.SkinTxt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.stb_sh_dir.SkinTxt.Font = new System.Drawing.Font("微软雅黑", 9.75F);
            this.stb_sh_dir.SkinTxt.Location = new System.Drawing.Point(5, 5);
            this.stb_sh_dir.SkinTxt.Name = "BaseText";
            this.stb_sh_dir.SkinTxt.Size = new System.Drawing.Size(417, 18);
            this.stb_sh_dir.SkinTxt.TabIndex = 0;
            this.stb_sh_dir.SkinTxt.WaterColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(127)))), ((int)(((byte)(127)))));
            this.stb_sh_dir.SkinTxt.WaterText = "sh脚本路径，例如：/home/gxb/bin";
            this.stb_sh_dir.TabIndex = 3;
            this.stb_sh_dir.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.stb_sh_dir.WaterColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(127)))), ((int)(((byte)(127)))));
            this.stb_sh_dir.WaterText = "sh脚本路径，例如：/home/gxb/bin";
            this.stb_sh_dir.WordWrap = true;
            this.stb_sh_dir.IconClick += new System.EventHandler(this.stb_sh_dir_IconClick);
            // 
            // tab_tomcat
            // 
            this.tab_tomcat.Controls.Add(this.label12);
            this.tab_tomcat.Controls.Add(this.stb_tomcat_port);
            this.tab_tomcat.Controls.Add(this.label5);
            this.tab_tomcat.Controls.Add(this.stb_tomcat_name);
            this.tab_tomcat.Controls.Add(this.label1);
            this.tab_tomcat.Controls.Add(this.stb_tomcat_path);
            this.tab_tomcat.Location = new System.Drawing.Point(4, 25);
            this.tab_tomcat.Name = "tab_tomcat";
            this.tab_tomcat.Padding = new System.Windows.Forms.Padding(3);
            this.tab_tomcat.Size = new System.Drawing.Size(617, 457);
            this.tab_tomcat.TabIndex = 0;
            this.tab_tomcat.Text = "Tomcat";
            this.tab_tomcat.UseVisualStyleBackColor = true;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(18, 184);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(71, 12);
            this.label12.TabIndex = 4;
            this.label12.Text = "Http Port：";
            // 
            // stb_tomcat_port
            // 
            this.stb_tomcat_port.BackColor = System.Drawing.Color.Transparent;
            this.stb_tomcat_port.DownBack = null;
            this.stb_tomcat_port.Icon = null;
            this.stb_tomcat_port.IconIsButton = false;
            this.stb_tomcat_port.IconMouseState = CCWin.SkinClass.ControlState.Normal;
            this.stb_tomcat_port.IsPasswordChat = '\0';
            this.stb_tomcat_port.IsSystemPasswordChar = false;
            this.stb_tomcat_port.Lines = new string[0];
            this.stb_tomcat_port.Location = new System.Drawing.Point(20, 213);
            this.stb_tomcat_port.Margin = new System.Windows.Forms.Padding(0);
            this.stb_tomcat_port.MaxLength = 32767;
            this.stb_tomcat_port.MinimumSize = new System.Drawing.Size(28, 28);
            this.stb_tomcat_port.MouseBack = null;
            this.stb_tomcat_port.MouseState = CCWin.SkinClass.ControlState.Normal;
            this.stb_tomcat_port.Multiline = false;
            this.stb_tomcat_port.Name = "stb_tomcat_port";
            this.stb_tomcat_port.NormlBack = null;
            this.stb_tomcat_port.Padding = new System.Windows.Forms.Padding(5);
            this.stb_tomcat_port.ReadOnly = false;
            this.stb_tomcat_port.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.stb_tomcat_port.Size = new System.Drawing.Size(578, 28);
            // 
            // 
            // 
            this.stb_tomcat_port.SkinTxt.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.stb_tomcat_port.SkinTxt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.stb_tomcat_port.SkinTxt.Font = new System.Drawing.Font("微软雅黑", 9.75F);
            this.stb_tomcat_port.SkinTxt.Location = new System.Drawing.Point(5, 5);
            this.stb_tomcat_port.SkinTxt.Name = "BaseText";
            this.stb_tomcat_port.SkinTxt.Size = new System.Drawing.Size(568, 18);
            this.stb_tomcat_port.SkinTxt.TabIndex = 0;
            this.stb_tomcat_port.SkinTxt.WaterColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(127)))), ((int)(((byte)(127)))));
            this.stb_tomcat_port.SkinTxt.WaterText = "Tomcat Web Server Port，例如：8080";
            this.stb_tomcat_port.TabIndex = 5;
            this.stb_tomcat_port.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.toolTip_contextname.SetToolTip(this.stb_tomcat_port, "Tomcat Web Server Port，例如：8080");
            this.stb_tomcat_port.WaterColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(127)))), ((int)(((byte)(127)))));
            this.stb_tomcat_port.WaterText = "Tomcat Web Server Port，例如：8080";
            this.stb_tomcat_port.WordWrap = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(19, 99);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(83, 12);
            this.label5.TabIndex = 2;
            this.label5.Text = "Tomcat Name：";
            // 
            // stb_tomcat_name
            // 
            this.stb_tomcat_name.BackColor = System.Drawing.Color.Transparent;
            this.stb_tomcat_name.DownBack = null;
            this.stb_tomcat_name.Icon = null;
            this.stb_tomcat_name.IconIsButton = false;
            this.stb_tomcat_name.IconMouseState = CCWin.SkinClass.ControlState.Normal;
            this.stb_tomcat_name.IsPasswordChat = '\0';
            this.stb_tomcat_name.IsSystemPasswordChar = false;
            this.stb_tomcat_name.Lines = new string[0];
            this.stb_tomcat_name.Location = new System.Drawing.Point(21, 128);
            this.stb_tomcat_name.Margin = new System.Windows.Forms.Padding(0);
            this.stb_tomcat_name.MaxLength = 32767;
            this.stb_tomcat_name.MinimumSize = new System.Drawing.Size(28, 28);
            this.stb_tomcat_name.MouseBack = null;
            this.stb_tomcat_name.MouseState = CCWin.SkinClass.ControlState.Normal;
            this.stb_tomcat_name.Multiline = false;
            this.stb_tomcat_name.Name = "stb_tomcat_name";
            this.stb_tomcat_name.NormlBack = null;
            this.stb_tomcat_name.Padding = new System.Windows.Forms.Padding(5);
            this.stb_tomcat_name.ReadOnly = false;
            this.stb_tomcat_name.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.stb_tomcat_name.Size = new System.Drawing.Size(578, 28);
            // 
            // 
            // 
            this.stb_tomcat_name.SkinTxt.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.stb_tomcat_name.SkinTxt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.stb_tomcat_name.SkinTxt.Font = new System.Drawing.Font("微软雅黑", 9.75F);
            this.stb_tomcat_name.SkinTxt.Location = new System.Drawing.Point(5, 5);
            this.stb_tomcat_name.SkinTxt.Name = "BaseText";
            this.stb_tomcat_name.SkinTxt.Size = new System.Drawing.Size(568, 18);
            this.stb_tomcat_name.SkinTxt.TabIndex = 0;
            this.stb_tomcat_name.SkinTxt.WaterColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(127)))), ((int)(((byte)(127)))));
            this.stb_tomcat_name.SkinTxt.WaterText = "Tomcat名称，例如：tomcat8";
            this.stb_tomcat_name.TabIndex = 3;
            this.stb_tomcat_name.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.toolTip_contextname.SetToolTip(this.stb_tomcat_name, "Tomcat名称，例如：tomcat8");
            this.stb_tomcat_name.WaterColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(127)))), ((int)(((byte)(127)))));
            this.stb_tomcat_name.WaterText = "Tomcat名称，例如：tomcat8";
            this.stb_tomcat_name.WordWrap = true;
            // 
            // tab_nginx
            // 
            this.tab_nginx.Controls.Add(this.label13);
            this.tab_nginx.Controls.Add(this.stb_nginx_conf);
            this.tab_nginx.Controls.Add(this.label10);
            this.tab_nginx.Controls.Add(this.stb_nginx_path);
            this.tab_nginx.Controls.Add(this.label4);
            this.tab_nginx.Controls.Add(this.stb_nginx_name);
            this.tab_nginx.Location = new System.Drawing.Point(4, 25);
            this.tab_nginx.Name = "tab_nginx";
            this.tab_nginx.Padding = new System.Windows.Forms.Padding(3);
            this.tab_nginx.Size = new System.Drawing.Size(617, 457);
            this.tab_nginx.TabIndex = 1;
            this.tab_nginx.Text = "Nginx";
            this.tab_nginx.UseVisualStyleBackColor = true;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(19, 184);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(89, 12);
            this.label13.TabIndex = 6;
            this.label13.Text = "Nginx Config：";
            // 
            // stb_nginx_conf
            // 
            this.stb_nginx_conf.BackColor = System.Drawing.Color.Transparent;
            this.stb_nginx_conf.DownBack = null;
            this.stb_nginx_conf.Icon = global::AppMonitor.Properties.Resources.find;
            this.stb_nginx_conf.IconIsButton = true;
            this.stb_nginx_conf.IconMouseState = CCWin.SkinClass.ControlState.Normal;
            this.stb_nginx_conf.IsPasswordChat = '\0';
            this.stb_nginx_conf.IsSystemPasswordChar = false;
            this.stb_nginx_conf.Lines = new string[0];
            this.stb_nginx_conf.Location = new System.Drawing.Point(20, 213);
            this.stb_nginx_conf.Margin = new System.Windows.Forms.Padding(0);
            this.stb_nginx_conf.MaxLength = 32767;
            this.stb_nginx_conf.MinimumSize = new System.Drawing.Size(28, 28);
            this.stb_nginx_conf.MouseBack = null;
            this.stb_nginx_conf.MouseState = CCWin.SkinClass.ControlState.Normal;
            this.stb_nginx_conf.Multiline = false;
            this.stb_nginx_conf.Name = "stb_nginx_conf";
            this.stb_nginx_conf.NormlBack = null;
            this.stb_nginx_conf.Padding = new System.Windows.Forms.Padding(5, 5, 28, 5);
            this.stb_nginx_conf.ReadOnly = false;
            this.stb_nginx_conf.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.stb_nginx_conf.Size = new System.Drawing.Size(578, 28);
            // 
            // 
            // 
            this.stb_nginx_conf.SkinTxt.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.stb_nginx_conf.SkinTxt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.stb_nginx_conf.SkinTxt.Font = new System.Drawing.Font("微软雅黑", 9.75F);
            this.stb_nginx_conf.SkinTxt.Location = new System.Drawing.Point(5, 5);
            this.stb_nginx_conf.SkinTxt.Name = "BaseText";
            this.stb_nginx_conf.SkinTxt.Size = new System.Drawing.Size(545, 18);
            this.stb_nginx_conf.SkinTxt.TabIndex = 0;
            this.stb_nginx_conf.SkinTxt.WaterColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(127)))), ((int)(((byte)(127)))));
            this.stb_nginx_conf.SkinTxt.WaterText = "Nginx配置文件完整路径，例如：/usr/local/nginx/nginx.conf";
            this.stb_nginx_conf.TabIndex = 7;
            this.stb_nginx_conf.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.toolTip_contextname.SetToolTip(this.stb_nginx_conf, "Nginx配置文件完整路径，例如：/usr/local/nginx/nginx.conf");
            this.stb_nginx_conf.WaterColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(127)))), ((int)(((byte)(127)))));
            this.stb_nginx_conf.WaterText = "Nginx配置文件完整路径，例如：/usr/local/nginx/nginx.conf";
            this.stb_nginx_conf.WordWrap = true;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(20, 101);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(101, 12);
            this.label10.TabIndex = 4;
            this.label10.Text = "Nginx Location：";
            // 
            // stb_nginx_path
            // 
            this.stb_nginx_path.BackColor = System.Drawing.Color.Transparent;
            this.stb_nginx_path.DownBack = null;
            this.stb_nginx_path.Icon = null;
            this.stb_nginx_path.IconIsButton = false;
            this.stb_nginx_path.IconMouseState = CCWin.SkinClass.ControlState.Normal;
            this.stb_nginx_path.IsPasswordChat = '\0';
            this.stb_nginx_path.IsSystemPasswordChar = false;
            this.stb_nginx_path.Lines = new string[0];
            this.stb_nginx_path.Location = new System.Drawing.Point(21, 130);
            this.stb_nginx_path.Margin = new System.Windows.Forms.Padding(0);
            this.stb_nginx_path.MaxLength = 32767;
            this.stb_nginx_path.MinimumSize = new System.Drawing.Size(28, 28);
            this.stb_nginx_path.MouseBack = null;
            this.stb_nginx_path.MouseState = CCWin.SkinClass.ControlState.Normal;
            this.stb_nginx_path.Multiline = false;
            this.stb_nginx_path.Name = "stb_nginx_path";
            this.stb_nginx_path.NormlBack = null;
            this.stb_nginx_path.Padding = new System.Windows.Forms.Padding(5);
            this.stb_nginx_path.ReadOnly = false;
            this.stb_nginx_path.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.stb_nginx_path.Size = new System.Drawing.Size(578, 28);
            // 
            // 
            // 
            this.stb_nginx_path.SkinTxt.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.stb_nginx_path.SkinTxt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.stb_nginx_path.SkinTxt.Font = new System.Drawing.Font("微软雅黑", 9.75F);
            this.stb_nginx_path.SkinTxt.Location = new System.Drawing.Point(5, 5);
            this.stb_nginx_path.SkinTxt.Name = "BaseText";
            this.stb_nginx_path.SkinTxt.Size = new System.Drawing.Size(568, 18);
            this.stb_nginx_path.SkinTxt.TabIndex = 0;
            this.stb_nginx_path.SkinTxt.WaterColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(127)))), ((int)(((byte)(127)))));
            this.stb_nginx_path.SkinTxt.WaterText = "Nginx执行文件完整路径，例如：/usr/local/nginx/nginx";
            this.stb_nginx_path.TabIndex = 5;
            this.stb_nginx_path.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.toolTip_contextname.SetToolTip(this.stb_nginx_path, "Nginx执行文件完整路径，例如：/usr/local/nginx/nginx");
            this.stb_nginx_path.WaterColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(127)))), ((int)(((byte)(127)))));
            this.stb_nginx_path.WaterText = "Nginx执行文件完整路径，例如：/usr/local/nginx/nginx";
            this.stb_nginx_path.WordWrap = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(20, 19);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 12);
            this.label4.TabIndex = 2;
            this.label4.Text = "Nginx Name：";
            // 
            // stb_nginx_name
            // 
            this.stb_nginx_name.BackColor = System.Drawing.Color.Transparent;
            this.stb_nginx_name.DownBack = null;
            this.stb_nginx_name.Icon = null;
            this.stb_nginx_name.IconIsButton = false;
            this.stb_nginx_name.IconMouseState = CCWin.SkinClass.ControlState.Normal;
            this.stb_nginx_name.IsPasswordChat = '\0';
            this.stb_nginx_name.IsSystemPasswordChar = false;
            this.stb_nginx_name.Lines = new string[] {
        "nginx 1"};
            this.stb_nginx_name.Location = new System.Drawing.Point(21, 48);
            this.stb_nginx_name.Margin = new System.Windows.Forms.Padding(0);
            this.stb_nginx_name.MaxLength = 32767;
            this.stb_nginx_name.MinimumSize = new System.Drawing.Size(28, 28);
            this.stb_nginx_name.MouseBack = null;
            this.stb_nginx_name.MouseState = CCWin.SkinClass.ControlState.Normal;
            this.stb_nginx_name.Multiline = false;
            this.stb_nginx_name.Name = "stb_nginx_name";
            this.stb_nginx_name.NormlBack = null;
            this.stb_nginx_name.Padding = new System.Windows.Forms.Padding(5);
            this.stb_nginx_name.ReadOnly = false;
            this.stb_nginx_name.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.stb_nginx_name.Size = new System.Drawing.Size(578, 28);
            // 
            // 
            // 
            this.stb_nginx_name.SkinTxt.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.stb_nginx_name.SkinTxt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.stb_nginx_name.SkinTxt.Font = new System.Drawing.Font("微软雅黑", 9.75F);
            this.stb_nginx_name.SkinTxt.Location = new System.Drawing.Point(5, 5);
            this.stb_nginx_name.SkinTxt.Name = "BaseText";
            this.stb_nginx_name.SkinTxt.Size = new System.Drawing.Size(568, 18);
            this.stb_nginx_name.SkinTxt.TabIndex = 0;
            this.stb_nginx_name.SkinTxt.Text = "nginx 1";
            this.stb_nginx_name.SkinTxt.WaterColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(127)))), ((int)(((byte)(127)))));
            this.stb_nginx_name.SkinTxt.WaterText = "Nginx名称，例如：nginx";
            this.stb_nginx_name.TabIndex = 3;
            this.stb_nginx_name.Text = "nginx 1";
            this.stb_nginx_name.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.toolTip_contextname.SetToolTip(this.stb_nginx_name, "Nginx名称，例如：nginx");
            this.stb_nginx_name.WaterColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(127)))), ((int)(((byte)(127)))));
            this.stb_nginx_name.WaterText = "Nginx名称，例如：nginx";
            this.stb_nginx_name.WordWrap = true;
            // 
            // tab_ice
            // 
            this.tab_ice.Controls.Add(this.label17);
            this.tab_ice.Controls.Add(this.stb_ice_servername);
            this.tab_ice.Controls.Add(this.label14);
            this.tab_ice.Controls.Add(this.stb_ice_ports);
            this.tab_ice.Controls.Add(this.label15);
            this.tab_ice.Controls.Add(this.stb_ice_srvpath);
            this.tab_ice.Controls.Add(this.label16);
            this.tab_ice.Controls.Add(this.stb_ice_appname);
            this.tab_ice.Location = new System.Drawing.Point(4, 25);
            this.tab_ice.Name = "tab_ice";
            this.tab_ice.Size = new System.Drawing.Size(617, 457);
            this.tab_ice.TabIndex = 3;
            this.tab_ice.Text = "IceSrv";
            this.tab_ice.UseVisualStyleBackColor = true;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(20, 185);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(83, 12);
            this.label17.TabIndex = 14;
            this.label17.Text = "Server Name：";
            // 
            // stb_ice_servername
            // 
            this.stb_ice_servername.BackColor = System.Drawing.Color.Transparent;
            this.stb_ice_servername.DownBack = null;
            this.stb_ice_servername.Icon = null;
            this.stb_ice_servername.IconIsButton = true;
            this.stb_ice_servername.IconMouseState = CCWin.SkinClass.ControlState.Normal;
            this.stb_ice_servername.IsPasswordChat = '\0';
            this.stb_ice_servername.IsSystemPasswordChar = false;
            this.stb_ice_servername.Lines = new string[0];
            this.stb_ice_servername.Location = new System.Drawing.Point(21, 214);
            this.stb_ice_servername.Margin = new System.Windows.Forms.Padding(0);
            this.stb_ice_servername.MaxLength = 32767;
            this.stb_ice_servername.MinimumSize = new System.Drawing.Size(28, 28);
            this.stb_ice_servername.MouseBack = null;
            this.stb_ice_servername.MouseState = CCWin.SkinClass.ControlState.Normal;
            this.stb_ice_servername.Multiline = false;
            this.stb_ice_servername.Name = "stb_ice_servername";
            this.stb_ice_servername.NormlBack = null;
            this.stb_ice_servername.Padding = new System.Windows.Forms.Padding(5);
            this.stb_ice_servername.ReadOnly = false;
            this.stb_ice_servername.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.stb_ice_servername.Size = new System.Drawing.Size(578, 28);
            // 
            // 
            // 
            this.stb_ice_servername.SkinTxt.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.stb_ice_servername.SkinTxt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.stb_ice_servername.SkinTxt.Font = new System.Drawing.Font("微软雅黑", 9.75F);
            this.stb_ice_servername.SkinTxt.Location = new System.Drawing.Point(5, 5);
            this.stb_ice_servername.SkinTxt.Name = "BaseText";
            this.stb_ice_servername.SkinTxt.Size = new System.Drawing.Size(568, 18);
            this.stb_ice_servername.SkinTxt.TabIndex = 0;
            this.stb_ice_servername.SkinTxt.WaterColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(127)))), ((int)(((byte)(127)))));
            this.stb_ice_servername.SkinTxt.WaterText = "Ice Server名称，例如：pfa95";
            this.stb_ice_servername.TabIndex = 15;
            this.stb_ice_servername.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.toolTip_contextname.SetToolTip(this.stb_ice_servername, "Nginx配置文件完整路径，例如：/usr/local/nginx/nginx.conf");
            this.stb_ice_servername.WaterColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(127)))), ((int)(((byte)(127)))));
            this.stb_ice_servername.WaterText = "Ice Server名称，例如：pfa95";
            this.stb_ice_servername.WordWrap = true;
            this.stb_ice_servername.Enter += new System.EventHandler(this.stb_ice_servername_Enter);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(20, 269);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(77, 12);
            this.label14.TabIndex = 12;
            this.label14.Text = "Node Ports：";
            // 
            // stb_ice_ports
            // 
            this.stb_ice_ports.BackColor = System.Drawing.Color.Transparent;
            this.stb_ice_ports.DownBack = null;
            this.stb_ice_ports.Icon = null;
            this.stb_ice_ports.IconIsButton = true;
            this.stb_ice_ports.IconMouseState = CCWin.SkinClass.ControlState.Normal;
            this.stb_ice_ports.IsPasswordChat = '\0';
            this.stb_ice_ports.IsSystemPasswordChar = false;
            this.stb_ice_ports.Lines = new string[0];
            this.stb_ice_ports.Location = new System.Drawing.Point(21, 298);
            this.stb_ice_ports.Margin = new System.Windows.Forms.Padding(0);
            this.stb_ice_ports.MaxLength = 32767;
            this.stb_ice_ports.MinimumSize = new System.Drawing.Size(28, 28);
            this.stb_ice_ports.MouseBack = null;
            this.stb_ice_ports.MouseState = CCWin.SkinClass.ControlState.Normal;
            this.stb_ice_ports.Multiline = false;
            this.stb_ice_ports.Name = "stb_ice_ports";
            this.stb_ice_ports.NormlBack = null;
            this.stb_ice_ports.Padding = new System.Windows.Forms.Padding(5);
            this.stb_ice_ports.ReadOnly = false;
            this.stb_ice_ports.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.stb_ice_ports.Size = new System.Drawing.Size(578, 28);
            // 
            // 
            // 
            this.stb_ice_ports.SkinTxt.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.stb_ice_ports.SkinTxt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.stb_ice_ports.SkinTxt.Font = new System.Drawing.Font("微软雅黑", 9.75F);
            this.stb_ice_ports.SkinTxt.Location = new System.Drawing.Point(5, 5);
            this.stb_ice_ports.SkinTxt.Name = "BaseText";
            this.stb_ice_ports.SkinTxt.Size = new System.Drawing.Size(568, 18);
            this.stb_ice_ports.SkinTxt.TabIndex = 0;
            this.stb_ice_ports.SkinTxt.WaterColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(127)))), ((int)(((byte)(127)))));
            this.stb_ice_ports.SkinTxt.WaterText = "Ice Node 端口号，多个以逗号（,）分隔，例如：8320,8321";
            this.stb_ice_ports.TabIndex = 13;
            this.stb_ice_ports.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.toolTip_contextname.SetToolTip(this.stb_ice_ports, "Ice Node 端口号，多个以逗号（,）分隔");
            this.stb_ice_ports.WaterColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(127)))), ((int)(((byte)(127)))));
            this.stb_ice_ports.WaterText = "Ice Node 端口号，多个以逗号（,）分隔，例如：8320,8321";
            this.stb_ice_ports.WordWrap = true;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(20, 101);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(107, 12);
            this.label15.TabIndex = 10;
            this.label15.Text = "IceSrv Location：";
            // 
            // stb_ice_srvpath
            // 
            this.stb_ice_srvpath.BackColor = System.Drawing.Color.Transparent;
            this.stb_ice_srvpath.DownBack = null;
            this.stb_ice_srvpath.Icon = global::AppMonitor.Properties.Resources.write_16px;
            this.stb_ice_srvpath.IconIsButton = true;
            this.stb_ice_srvpath.IconMouseState = CCWin.SkinClass.ControlState.Normal;
            this.stb_ice_srvpath.IsPasswordChat = '\0';
            this.stb_ice_srvpath.IsSystemPasswordChar = false;
            this.stb_ice_srvpath.Lines = new string[0];
            this.stb_ice_srvpath.Location = new System.Drawing.Point(21, 130);
            this.stb_ice_srvpath.Margin = new System.Windows.Forms.Padding(0);
            this.stb_ice_srvpath.MaxLength = 32767;
            this.stb_ice_srvpath.MinimumSize = new System.Drawing.Size(28, 28);
            this.stb_ice_srvpath.MouseBack = null;
            this.stb_ice_srvpath.MouseState = CCWin.SkinClass.ControlState.Normal;
            this.stb_ice_srvpath.Multiline = false;
            this.stb_ice_srvpath.Name = "stb_ice_srvpath";
            this.stb_ice_srvpath.NormlBack = null;
            this.stb_ice_srvpath.Padding = new System.Windows.Forms.Padding(5, 5, 28, 5);
            this.stb_ice_srvpath.ReadOnly = false;
            this.stb_ice_srvpath.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.stb_ice_srvpath.Size = new System.Drawing.Size(578, 28);
            // 
            // 
            // 
            this.stb_ice_srvpath.SkinTxt.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.stb_ice_srvpath.SkinTxt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.stb_ice_srvpath.SkinTxt.Font = new System.Drawing.Font("微软雅黑", 9.75F);
            this.stb_ice_srvpath.SkinTxt.Location = new System.Drawing.Point(5, 5);
            this.stb_ice_srvpath.SkinTxt.Name = "BaseText";
            this.stb_ice_srvpath.SkinTxt.Size = new System.Drawing.Size(545, 18);
            this.stb_ice_srvpath.SkinTxt.TabIndex = 0;
            this.stb_ice_srvpath.SkinTxt.WaterColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(127)))), ((int)(((byte)(127)))));
            this.stb_ice_srvpath.SkinTxt.WaterText = "IceSrv完整路径，例如：/home/gxb/pfasrv";
            this.stb_ice_srvpath.TabIndex = 11;
            this.stb_ice_srvpath.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.toolTip_contextname.SetToolTip(this.stb_ice_srvpath, "Nginx执行文件完整路径，例如：/usr/local/nginx/nginx");
            this.stb_ice_srvpath.WaterColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(127)))), ((int)(((byte)(127)))));
            this.stb_ice_srvpath.WaterText = "IceSrv完整路径，例如：/home/gxb/pfasrv";
            this.stb_ice_srvpath.WordWrap = true;
            this.stb_ice_srvpath.IconClick += new System.EventHandler(this.skinTextBox2_IconClick);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(20, 19);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(65, 12);
            this.label16.TabIndex = 8;
            this.label16.Text = "App Name：";
            // 
            // stb_ice_appname
            // 
            this.stb_ice_appname.BackColor = System.Drawing.Color.Transparent;
            this.stb_ice_appname.DownBack = null;
            this.stb_ice_appname.Icon = null;
            this.stb_ice_appname.IconIsButton = false;
            this.stb_ice_appname.IconMouseState = CCWin.SkinClass.ControlState.Normal;
            this.stb_ice_appname.IsPasswordChat = '\0';
            this.stb_ice_appname.IsSystemPasswordChar = false;
            this.stb_ice_appname.Lines = new string[0];
            this.stb_ice_appname.Location = new System.Drawing.Point(21, 48);
            this.stb_ice_appname.Margin = new System.Windows.Forms.Padding(0);
            this.stb_ice_appname.MaxLength = 32767;
            this.stb_ice_appname.MinimumSize = new System.Drawing.Size(28, 28);
            this.stb_ice_appname.MouseBack = null;
            this.stb_ice_appname.MouseState = CCWin.SkinClass.ControlState.Normal;
            this.stb_ice_appname.Multiline = false;
            this.stb_ice_appname.Name = "stb_ice_appname";
            this.stb_ice_appname.NormlBack = null;
            this.stb_ice_appname.Padding = new System.Windows.Forms.Padding(5);
            this.stb_ice_appname.ReadOnly = false;
            this.stb_ice_appname.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.stb_ice_appname.Size = new System.Drawing.Size(578, 28);
            // 
            // 
            // 
            this.stb_ice_appname.SkinTxt.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.stb_ice_appname.SkinTxt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.stb_ice_appname.SkinTxt.Font = new System.Drawing.Font("微软雅黑", 9.75F);
            this.stb_ice_appname.SkinTxt.Location = new System.Drawing.Point(5, 5);
            this.stb_ice_appname.SkinTxt.Name = "BaseText";
            this.stb_ice_appname.SkinTxt.Size = new System.Drawing.Size(568, 18);
            this.stb_ice_appname.SkinTxt.TabIndex = 0;
            this.stb_ice_appname.SkinTxt.WaterColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(127)))), ((int)(((byte)(127)))));
            this.stb_ice_appname.SkinTxt.WaterText = "项目名称，例如：pfasrv";
            this.stb_ice_appname.TabIndex = 9;
            this.stb_ice_appname.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.toolTip_contextname.SetToolTip(this.stb_ice_appname, "项目名称，例如：pfasrv");
            this.stb_ice_appname.WaterColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(127)))), ((int)(((byte)(127)))));
            this.stb_ice_appname.WaterText = "项目名称，例如：pfasrv";
            this.stb_ice_appname.WordWrap = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(558, 526);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 25);
            this.button2.TabIndex = 5;
            this.button2.Text = "Cancel";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(474, 526);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 25);
            this.button1.TabIndex = 4;
            this.button1.Text = "Save";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // toolTip_contextname
            // 
            this.toolTip_contextname.ToolTipTitle = "AppMonitor";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(18, 97);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(137, 12);
            this.label18.TabIndex = 9;
            this.label18.Text = "Disconfig Server Url：";
            // 
            // stb_disconfig_url
            // 
            this.stb_disconfig_url.BackColor = System.Drawing.Color.Transparent;
            this.stb_disconfig_url.DownBack = null;
            this.stb_disconfig_url.Enabled = false;
            this.stb_disconfig_url.Icon = null;
            this.stb_disconfig_url.IconIsButton = false;
            this.stb_disconfig_url.IconMouseState = CCWin.SkinClass.ControlState.Normal;
            this.stb_disconfig_url.IsPasswordChat = '\0';
            this.stb_disconfig_url.IsSystemPasswordChar = false;
            this.stb_disconfig_url.Lines = new string[] {
        "http://admin:admin123@192.168.20.91:8761/config"};
            this.stb_disconfig_url.Location = new System.Drawing.Point(18, 119);
            this.stb_disconfig_url.Margin = new System.Windows.Forms.Padding(0);
            this.stb_disconfig_url.MaxLength = 32767;
            this.stb_disconfig_url.MinimumSize = new System.Drawing.Size(28, 28);
            this.stb_disconfig_url.MouseBack = null;
            this.stb_disconfig_url.MouseState = CCWin.SkinClass.ControlState.Normal;
            this.stb_disconfig_url.Multiline = false;
            this.stb_disconfig_url.Name = "stb_disconfig_url";
            this.stb_disconfig_url.NormlBack = null;
            this.stb_disconfig_url.Padding = new System.Windows.Forms.Padding(5);
            this.stb_disconfig_url.ReadOnly = false;
            this.stb_disconfig_url.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.stb_disconfig_url.Size = new System.Drawing.Size(579, 28);
            // 
            // 
            // 
            this.stb_disconfig_url.SkinTxt.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.stb_disconfig_url.SkinTxt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.stb_disconfig_url.SkinTxt.Font = new System.Drawing.Font("微软雅黑", 9.75F);
            this.stb_disconfig_url.SkinTxt.Location = new System.Drawing.Point(5, 5);
            this.stb_disconfig_url.SkinTxt.Name = "BaseText";
            this.stb_disconfig_url.SkinTxt.Size = new System.Drawing.Size(569, 18);
            this.stb_disconfig_url.SkinTxt.TabIndex = 0;
            this.stb_disconfig_url.SkinTxt.Text = "http://admin:admin123@192.168.20.91:8761/config";
            this.stb_disconfig_url.SkinTxt.WaterColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(127)))), ((int)(((byte)(127)))));
            this.stb_disconfig_url.SkinTxt.WaterText = "公共配置服务器地址，例如：http://admin:admin123@192.168.20.91:8761/config";
            this.stb_disconfig_url.TabIndex = 8;
            this.stb_disconfig_url.Text = "http://admin:admin123@192.168.20.91:8761/config";
            this.stb_disconfig_url.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.stb_disconfig_url.WaterColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(127)))), ((int)(((byte)(127)))));
            this.stb_disconfig_url.WaterText = "公共配置服务器地址，例如：http://admin:admin123@192.168.20.91:8761/config";
            this.stb_disconfig_url.WordWrap = true;
            // 
            // MonitorItemForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::AppMonitor.Properties.Resources.skin_12;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.CaptionFont = new System.Drawing.Font("微软雅黑", 10F);
            this.ClientSize = new System.Drawing.Size(650, 566);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MonitorItemForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Monitor Item";
            this.TitleCenter = false;
            this.TitleColor = System.Drawing.Color.White;
            this.Load += new System.EventHandler(this.MonitorItemForm_Load);
            this.tabControl1.ResumeLayout(false);
            this.tab_springboot.ResumeLayout(false);
            this.tab_springboot.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tab_tomcat.ResumeLayout(false);
            this.tab_tomcat.PerformLayout();
            this.tab_nginx.ResumeLayout(false);
            this.tab_nginx.PerformLayout();
            this.tab_ice.ResumeLayout(false);
            this.tab_ice.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private CCWin.SkinControl.SkinTextBox stb_tomcat_path;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tab_tomcat;
        private System.Windows.Forms.TabPage tab_nginx;
        private System.Windows.Forms.TabPage tab_springboot;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label2;
        private CCWin.SkinControl.SkinTextBox stb_sh_dir;
        private System.Windows.Forms.Label label3;
        private CCWin.SkinControl.SkinTextBox stb_project_source_dir;
        private System.Windows.Forms.CheckBox cb_need_add;
        private CCWin.SkinControl.SkinTextBox stb_project_svn;
        private System.Windows.Forms.Label label4;
        private CCWin.SkinControl.SkinTextBox stb_nginx_name;
        private System.Windows.Forms.Label label5;
        private CCWin.SkinControl.SkinTextBox stb_tomcat_name;
        private System.Windows.Forms.Label label6;
        private CCWin.SkinControl.SkinTextBox stb_app_name;
        private System.Windows.Forms.Label label8;
        private CCWin.SkinControl.SkinTextBox stb_ctl_file;
        private System.Windows.Forms.Label label7;
        private CCWin.SkinControl.SkinTextBox stb_build_file;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private CCWin.SkinControl.SkinTextBox stb_nginx_path;
        private System.Windows.Forms.Label label11;
        private CCWin.SkinControl.SkinTextBox stb_home_url;
        private System.Windows.Forms.ToolTip toolTip_contextname;
        private System.Windows.Forms.Label label12;
        private CCWin.SkinControl.SkinTextBox stb_tomcat_port;
        private System.Windows.Forms.Label label13;
        private CCWin.SkinControl.SkinTextBox stb_nginx_conf;
        private System.Windows.Forms.TabPage tab_ice;
        private System.Windows.Forms.Label label14;
        private CCWin.SkinControl.SkinTextBox stb_ice_ports;
        private System.Windows.Forms.Label label15;
        private CCWin.SkinControl.SkinTextBox stb_ice_srvpath;
        private System.Windows.Forms.Label label16;
        private CCWin.SkinControl.SkinTextBox stb_ice_appname;
        private System.Windows.Forms.Label label17;
        private CCWin.SkinControl.SkinTextBox stb_ice_servername;
        private System.Windows.Forms.Label label18;
        private CCWin.SkinControl.SkinTextBox stb_disconfig_url;
    }
}