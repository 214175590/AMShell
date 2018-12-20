namespace AppMonitor.Froms
{
    partial class TomcatMonitorForm
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
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.contextMenu2 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.自定义命令ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.TimedTaskToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ConditionTaskToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.skinToolTip1 = new CCWin.SkinToolTip(this.components);
            this.linkLabel2 = new System.Windows.Forms.LinkLabel();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.projects = new CCWin.SkinControl.SkinListView();
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.button5 = new System.Windows.Forms.Button();
            this.btn_run = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.btn_restart = new System.Windows.Forms.Button();
            this.btn_start = new System.Windows.Forms.Button();
            this.btn_stop = new System.Windows.Forms.Button();
            this.pic_run_state = new System.Windows.Forms.PictureBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.l_visit_url = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.l_name = new System.Windows.Forms.TextBox();
            this.l_tomcat_path = new System.Windows.Forms.TextBox();
            this.l_xml_path = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.custom_btn = new System.Windows.Forms.LinkLabel();
            this.customShellListView = new CCWin.SkinControl.SkinListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.shellView = new CCWin.SkinControl.SkinTextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label_msg = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tb_port = new System.Windows.Forms.TextBox();
            this.label_status = new System.Windows.Forms.Label();
            this.contextMenuStrip2 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenu2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pic_run_state)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.contextMenuStrip2.SuspendLayout();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // contextMenu2
            // 
            this.contextMenu2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.自定义命令ToolStripMenuItem,
            this.toolStripSeparator1,
            this.TimedTaskToolStripMenuItem,
            this.ConditionTaskToolStripMenuItem});
            this.contextMenu2.Name = "contextMenuStrip1";
            this.contextMenu2.Size = new System.Drawing.Size(137, 76);
            // 
            // 自定义命令ToolStripMenuItem
            // 
            this.自定义命令ToolStripMenuItem.Name = "自定义命令ToolStripMenuItem";
            this.自定义命令ToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.自定义命令ToolStripMenuItem.Text = "自定义脚本";
            this.自定义命令ToolStripMenuItem.Click += new System.EventHandler(this.自定义命令ToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(133, 6);
            // 
            // TimedTaskToolStripMenuItem
            // 
            this.TimedTaskToolStripMenuItem.Name = "TimedTaskToolStripMenuItem";
            this.TimedTaskToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.TimedTaskToolStripMenuItem.Text = "定时任务";
            this.TimedTaskToolStripMenuItem.Click += new System.EventHandler(this.CustomTimeTaskToolStripMenuItem_Click);
            // 
            // ConditionTaskToolStripMenuItem
            // 
            this.ConditionTaskToolStripMenuItem.Name = "ConditionTaskToolStripMenuItem";
            this.ConditionTaskToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.ConditionTaskToolStripMenuItem.Text = "条件任务";
            this.ConditionTaskToolStripMenuItem.Click += new System.EventHandler(this.ConditionTaskToolStripMenuItem_Click_1);
            // 
            // skinToolTip1
            // 
            this.skinToolTip1.AutoPopDelay = 5000;
            this.skinToolTip1.InitialDelay = 500;
            this.skinToolTip1.OwnerDraw = true;
            this.skinToolTip1.ReshowDelay = 800;
            this.skinToolTip1.ToolTipTitle = "AppMonitor";
            // 
            // linkLabel2
            // 
            this.linkLabel2.AutoSize = true;
            this.linkLabel2.Location = new System.Drawing.Point(358, 95);
            this.linkLabel2.Name = "linkLabel2";
            this.linkLabel2.Size = new System.Drawing.Size(29, 12);
            this.linkLabel2.TabIndex = 24;
            this.linkLabel2.TabStop = true;
            this.linkLabel2.Text = "编辑";
            this.skinToolTip1.SetToolTip(this.linkLabel2, "编辑服务器上的server.xml文件");
            this.linkLabel2.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel2_LinkClicked);
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(357, 129);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(29, 12);
            this.linkLabel1.TabIndex = 23;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "访问";
            this.skinToolTip1.SetToolTip(this.linkLabel1, "在默认浏览器中打开项目首页地址");
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // projects
            // 
            this.projects.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.projects.BorderColor = System.Drawing.Color.LightGray;
            this.projects.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader2,
            this.columnHeader4});
            this.projects.FullRowSelect = true;
            this.projects.GridLines = true;
            this.projects.HeadColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.projects.Location = new System.Drawing.Point(395, 13);
            this.projects.MultiSelect = false;
            this.projects.Name = "projects";
            this.projects.OwnerDraw = true;
            this.projects.RowBackColor2 = System.Drawing.Color.White;
            this.projects.SelectedColor = System.Drawing.Color.SkyBlue;
            this.projects.Size = new System.Drawing.Size(414, 186);
            this.projects.TabIndex = 11;
            this.skinToolTip1.SetToolTip(this.projects, "双击访问各个项目");
            this.projects.UseCompatibleStateImageBehavior = false;
            this.projects.View = System.Windows.Forms.View.Details;
            this.projects.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.projects_MouseDoubleClick);
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "项目访问地址";
            this.columnHeader2.Width = 220;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "磁盘路径";
            this.columnHeader4.Width = 300;
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(14, 111);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(81, 25);
            this.button5.TabIndex = 9;
            this.button5.Text = "立即检测";
            this.skinToolTip1.SetToolTip(this.button5, "立即检测程序运行是否正常");
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // btn_run
            // 
            this.btn_run.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_run.Enabled = false;
            this.btn_run.Location = new System.Drawing.Point(631, 158);
            this.btn_run.Name = "btn_run";
            this.btn_run.Size = new System.Drawing.Size(65, 26);
            this.btn_run.TabIndex = 9;
            this.btn_run.Text = "运行";
            this.skinToolTip1.SetToolTip(this.btn_run, "手动运行脚本");
            this.btn_run.UseVisualStyleBackColor = true;
            this.btn_run.Click += new System.EventHandler(this.btn_run_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(403, 27);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(60, 28);
            this.button1.TabIndex = 21;
            this.button1.Text = "修改";
            this.skinToolTip1.SetToolTip(this.button1, "修改端口号");
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btn_restart
            // 
            this.btn_restart.Location = new System.Drawing.Point(176, 27);
            this.btn_restart.Name = "btn_restart";
            this.btn_restart.Size = new System.Drawing.Size(60, 28);
            this.btn_restart.TabIndex = 7;
            this.btn_restart.Text = "重启";
            this.skinToolTip1.SetToolTip(this.btn_restart, "重启Tomcat，会先停止Tomcat然后再启动Tomcat");
            this.btn_restart.UseVisualStyleBackColor = true;
            this.btn_restart.Click += new System.EventHandler(this.btn_restart_Click);
            // 
            // btn_start
            // 
            this.btn_start.Location = new System.Drawing.Point(19, 27);
            this.btn_start.Name = "btn_start";
            this.btn_start.Size = new System.Drawing.Size(60, 28);
            this.btn_start.TabIndex = 5;
            this.btn_start.Text = "启动";
            this.skinToolTip1.SetToolTip(this.btn_start, "启动Tomcat，如果Tomcat未停止或导致因重复启动而失败");
            this.btn_start.UseVisualStyleBackColor = true;
            this.btn_start.Click += new System.EventHandler(this.btn_start_Click);
            // 
            // btn_stop
            // 
            this.btn_stop.Location = new System.Drawing.Point(99, 27);
            this.btn_stop.Name = "btn_stop";
            this.btn_stop.Size = new System.Drawing.Size(60, 28);
            this.btn_stop.TabIndex = 6;
            this.btn_stop.Text = "停止";
            this.skinToolTip1.SetToolTip(this.btn_stop, "停止Tomcat");
            this.btn_stop.UseVisualStyleBackColor = true;
            this.btn_stop.Click += new System.EventHandler(this.btn_stop_Click);
            // 
            // pic_run_state
            // 
            this.pic_run_state.BackgroundImage = global::AppMonitor.Properties.Resources.gray_light_48;
            this.pic_run_state.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pic_run_state.Location = new System.Drawing.Point(31, 30);
            this.pic_run_state.Name = "pic_run_state";
            this.pic_run_state.Size = new System.Drawing.Size(48, 48);
            this.pic_run_state.TabIndex = 4;
            this.pic_run_state.TabStop = false;
            this.skinToolTip1.SetToolTip(this.pic_run_state, "未检测");
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.linkLabel2);
            this.groupBox1.Controls.Add(this.linkLabel1);
            this.groupBox1.Controls.Add(this.l_visit_url);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.projects);
            this.groupBox1.Controls.Add(this.l_name);
            this.groupBox1.Controls.Add(this.l_tomcat_path);
            this.groupBox1.Controls.Add(this.l_xml_path);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(7, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(815, 207);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "基本信息";
            // 
            // l_visit_url
            // 
            this.l_visit_url.BackColor = System.Drawing.SystemColors.Control;
            this.l_visit_url.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.l_visit_url.Font = new System.Drawing.Font("宋体", 9F);
            this.l_visit_url.Location = new System.Drawing.Point(90, 129);
            this.l_visit_url.Name = "l_visit_url";
            this.l_visit_url.Size = new System.Drawing.Size(261, 14);
            this.l_visit_url.TabIndex = 22;
            // 
            // label9
            // 
            this.label9.Location = new System.Drawing.Point(11, 129);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(80, 12);
            this.label9.TabIndex = 21;
            this.label9.Text = "Home Url：";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // l_name
            // 
            this.l_name.BackColor = System.Drawing.SystemColors.Control;
            this.l_name.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.l_name.Font = new System.Drawing.Font("宋体", 9F);
            this.l_name.Location = new System.Drawing.Point(90, 27);
            this.l_name.Name = "l_name";
            this.l_name.ReadOnly = true;
            this.l_name.Size = new System.Drawing.Size(287, 14);
            this.l_name.TabIndex = 19;
            // 
            // l_tomcat_path
            // 
            this.l_tomcat_path.BackColor = System.Drawing.SystemColors.Control;
            this.l_tomcat_path.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.l_tomcat_path.Font = new System.Drawing.Font("宋体", 9F);
            this.l_tomcat_path.Location = new System.Drawing.Point(90, 61);
            this.l_tomcat_path.Name = "l_tomcat_path";
            this.l_tomcat_path.ReadOnly = true;
            this.l_tomcat_path.Size = new System.Drawing.Size(287, 14);
            this.l_tomcat_path.TabIndex = 18;
            // 
            // l_xml_path
            // 
            this.l_xml_path.BackColor = System.Drawing.SystemColors.Control;
            this.l_xml_path.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.l_xml_path.Font = new System.Drawing.Font("宋体", 9F);
            this.l_xml_path.Location = new System.Drawing.Point(90, 94);
            this.l_xml_path.Name = "l_xml_path";
            this.l_xml_path.ReadOnly = true;
            this.l_xml_path.Size = new System.Drawing.Size(261, 14);
            this.l_xml_path.TabIndex = 17;
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(11, 27);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(80, 12);
            this.label6.TabIndex = 10;
            this.label6.Text = "Tomcat名称：";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(11, 93);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(80, 12);
            this.label5.TabIndex = 9;
            this.label5.Text = "server.xml：";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(11, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 12);
            this.label2.TabIndex = 0;
            this.label2.Text = "Tomcat路径：";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.progressBar1);
            this.groupBox2.Controls.Add(this.button5);
            this.groupBox2.Controls.Add(this.groupBox4);
            this.groupBox2.Controls.Add(this.groupBox3);
            this.groupBox2.Controls.Add(this.pic_run_state);
            this.groupBox2.Controls.Add(this.label_status);
            this.groupBox2.Location = new System.Drawing.Point(8, 219);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(814, 289);
            this.groupBox2.TabIndex = 8;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "状态监控";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.label3.ForeColor = System.Drawing.Color.Silver;
            this.label3.Location = new System.Drawing.Point(4, 262);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 21);
            this.label3.TabIndex = 14;
            this.label3.Text = "Tomcat";
            // 
            // progressBar1
            // 
            this.progressBar1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBar1.BackColor = System.Drawing.SystemColors.Control;
            this.progressBar1.Location = new System.Drawing.Point(59, 6);
            this.progressBar1.Maximum = 20;
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(758, 2);
            this.progressBar1.TabIndex = 9;
            this.progressBar1.Value = 20;
            // 
            // groupBox4
            // 
            this.groupBox4.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox4.Controls.Add(this.custom_btn);
            this.groupBox4.Controls.Add(this.customShellListView);
            this.groupBox4.Controls.Add(this.shellView);
            this.groupBox4.Controls.Add(this.btn_run);
            this.groupBox4.Location = new System.Drawing.Point(107, 94);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(701, 188);
            this.groupBox4.TabIndex = 10;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "扩展功能";
            // 
            // custom_btn
            // 
            this.custom_btn.AutoSize = true;
            this.custom_btn.LinkColor = System.Drawing.Color.Blue;
            this.custom_btn.Location = new System.Drawing.Point(69, 1);
            this.custom_btn.Name = "custom_btn";
            this.custom_btn.Size = new System.Drawing.Size(41, 12);
            this.custom_btn.TabIndex = 12;
            this.custom_btn.TabStop = true;
            this.custom_btn.Text = "自定义";
            this.skinToolTip1.SetToolTip(this.custom_btn, "自定义Shell、Task");
            this.custom_btn.MouseUp += new System.Windows.Forms.MouseEventHandler(this.button6_MouseUp);
            // 
            // customShellListView
            // 
            this.customShellListView.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.customShellListView.BorderColor = System.Drawing.Color.LightGray;
            this.customShellListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader3});
            this.customShellListView.FullRowSelect = true;
            this.customShellListView.GridLines = true;
            this.customShellListView.HeadColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.customShellListView.Location = new System.Drawing.Point(8, 20);
            this.customShellListView.MultiSelect = false;
            this.customShellListView.Name = "customShellListView";
            this.customShellListView.OwnerDraw = true;
            this.customShellListView.RowBackColor2 = System.Drawing.Color.White;
            this.customShellListView.SelectedColor = System.Drawing.Color.SkyBlue;
            this.customShellListView.Size = new System.Drawing.Size(284, 161);
            this.customShellListView.TabIndex = 10;
            this.customShellListView.UseCompatibleStateImageBehavior = false;
            this.customShellListView.View = System.Windows.Forms.View.Details;
            this.customShellListView.SelectedIndexChanged += new System.EventHandler(this.customShellListView_SelectedIndexChanged);
            this.customShellListView.MouseUp += new System.Windows.Forms.MouseEventHandler(this.customShellListView_MouseUp);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "名称";
            this.columnHeader1.Width = 150;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "类型";
            this.columnHeader3.Width = 100;
            // 
            // shellView
            // 
            this.shellView.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.shellView.BackColor = System.Drawing.Color.Transparent;
            this.shellView.DownBack = null;
            this.shellView.Icon = null;
            this.shellView.IconIsButton = false;
            this.shellView.IconMouseState = CCWin.SkinClass.ControlState.Normal;
            this.shellView.IsPasswordChat = '\0';
            this.shellView.IsSystemPasswordChar = false;
            this.shellView.Lines = new string[0];
            this.shellView.Location = new System.Drawing.Point(295, 20);
            this.shellView.Margin = new System.Windows.Forms.Padding(0);
            this.shellView.MaxLength = 32767;
            this.shellView.MinimumSize = new System.Drawing.Size(28, 28);
            this.shellView.MouseBack = null;
            this.shellView.MouseState = CCWin.SkinClass.ControlState.Normal;
            this.shellView.Multiline = true;
            this.shellView.Name = "shellView";
            this.shellView.NormlBack = null;
            this.shellView.Padding = new System.Windows.Forms.Padding(5);
            this.shellView.ReadOnly = false;
            this.shellView.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.shellView.Size = new System.Drawing.Size(400, 136);
            // 
            // 
            // 
            this.shellView.SkinTxt.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.shellView.SkinTxt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.shellView.SkinTxt.Font = new System.Drawing.Font("微软雅黑", 9.75F);
            this.shellView.SkinTxt.Location = new System.Drawing.Point(5, 5);
            this.shellView.SkinTxt.Multiline = true;
            this.shellView.SkinTxt.Name = "BaseText";
            this.shellView.SkinTxt.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.shellView.SkinTxt.Size = new System.Drawing.Size(390, 126);
            this.shellView.SkinTxt.TabIndex = 0;
            this.shellView.SkinTxt.WaterColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(127)))), ((int)(((byte)(127)))));
            this.shellView.SkinTxt.WaterText = "";
            this.shellView.TabIndex = 0;
            this.shellView.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.shellView.WaterColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(127)))), ((int)(((byte)(127)))));
            this.shellView.WaterText = "";
            this.shellView.WordWrap = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.label_msg);
            this.groupBox3.Controls.Add(this.button1);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.tb_port);
            this.groupBox3.Controls.Add(this.btn_restart);
            this.groupBox3.Controls.Add(this.btn_start);
            this.groupBox3.Controls.Add(this.btn_stop);
            this.groupBox3.Location = new System.Drawing.Point(107, 12);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(701, 76);
            this.groupBox3.TabIndex = 9;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "基础功能";
            // 
            // label_msg
            // 
            this.label_msg.AutoSize = true;
            this.label_msg.ForeColor = System.Drawing.Color.Teal;
            this.label_msg.Location = new System.Drawing.Point(480, 38);
            this.label_msg.Name = "label_msg";
            this.label_msg.Size = new System.Drawing.Size(0, 12);
            this.label_msg.TabIndex = 22;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(282, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 20;
            this.label1.Text = "端口号：";
            // 
            // tb_port
            // 
            this.tb_port.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tb_port.Location = new System.Drawing.Point(339, 34);
            this.tb_port.Name = "tb_port";
            this.tb_port.ReadOnly = true;
            this.tb_port.Size = new System.Drawing.Size(55, 14);
            this.tb_port.TabIndex = 8;
            this.tb_port.Text = "8080";
            // 
            // label_status
            // 
            this.label_status.Location = new System.Drawing.Point(17, 88);
            this.label_status.Name = "label_status";
            this.label_status.Size = new System.Drawing.Size(79, 12);
            this.label_status.TabIndex = 1;
            this.label_status.Text = "检测中...";
            this.label_status.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // contextMenuStrip2
            // 
            this.contextMenuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem2,
            this.toolStripMenuItem3});
            this.contextMenuStrip2.Name = "contextMenuStrip1";
            this.contextMenuStrip2.Size = new System.Drawing.Size(114, 48);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(113, 22);
            this.toolStripMenuItem2.Text = "Edit";
            this.toolStripMenuItem2.Click += new System.EventHandler(this.toolStripMenuItem2_Click);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(113, 22);
            this.toolStripMenuItem3.Text = "Delete";
            this.toolStripMenuItem3.Click += new System.EventHandler(this.toolStripMenuItem3_Click);
            // 
            // TomcatMonitorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(831, 513);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "TomcatMonitorForm";
            this.Text = "TomcatMonitorForm";
            this.Load += new System.EventHandler(this.TomcatMonitorForm_Load);
            this.contextMenu2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pic_run_state)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.contextMenuStrip2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private CCWin.SkinControl.SkinListView customShellListView;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ProgressBar progressBar1;
        private CCWin.SkinControl.SkinTextBox shellView;
        private System.Windows.Forms.Button btn_run;
        private CCWin.SkinToolTip skinToolTip1;
        private System.Windows.Forms.Button btn_restart;
        private System.Windows.Forms.Button btn_start;
        private System.Windows.Forms.Button btn_stop;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ContextMenuStrip contextMenu2;
        private System.Windows.Forms.ToolStripMenuItem 自定义命令ToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem TimedTaskToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ConditionTaskToolStripMenuItem;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.PictureBox pic_run_state;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label label_status;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox l_name;
        private System.Windows.Forms.TextBox l_tomcat_path;
        private System.Windows.Forms.TextBox l_xml_path;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tb_port;
        private System.Windows.Forms.Button button1;
        private CCWin.SkinControl.SkinListView projects;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.TextBox l_visit_url;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.LinkLabel linkLabel2;
        private System.Windows.Forms.Label label_msg;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip2;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.LinkLabel custom_btn;
    }
}