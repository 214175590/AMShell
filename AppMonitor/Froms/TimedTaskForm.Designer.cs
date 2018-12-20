namespace AppMonitor.Froms
{
    partial class TimedTaskForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TimedTaskForm));
            this.scb_cycle = new CCWin.SkinControl.SkinComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.customShellListView = new CCWin.SkinControl.SkinListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.deleteItemToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.upToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.downToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.task_name = new CCWin.SkinControl.SkinTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.week_panel = new System.Windows.Forms.Panel();
            this.week6 = new System.Windows.Forms.CheckBox();
            this.week5 = new System.Windows.Forms.CheckBox();
            this.week4 = new System.Windows.Forms.CheckBox();
            this.week3 = new System.Windows.Forms.CheckBox();
            this.week2 = new System.Windows.Forms.CheckBox();
            this.week1 = new System.Windows.Forms.CheckBox();
            this.week0 = new System.Windows.Forms.CheckBox();
            this.time = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.date = new System.Windows.Forms.DateTimePicker();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.linkLabel2 = new System.Windows.Forms.LinkLabel();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.button1 = new System.Windows.Forms.Button();
            this.shell = new CCWin.SkinControl.SkinTextBox();
            this.shell_name = new CCWin.SkinControl.SkinTextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.scb_template = new CCWin.SkinControl.SkinListView();
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.var_list = new CCWin.SkinControl.SkinListView();
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.contextMenuStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.week_panel.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // scb_cycle
            // 
            this.scb_cycle.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.scb_cycle.BorderColor = System.Drawing.Color.LightSteelBlue;
            this.scb_cycle.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.scb_cycle.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.scb_cycle.Font = new System.Drawing.Font("宋体", 10F);
            this.scb_cycle.FormattingEnabled = true;
            this.scb_cycle.ItemBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.scb_cycle.ItemHeight = 18;
            this.scb_cycle.Items.AddRange(new object[] {
            "仅一次",
            "每天",
            "每周",
            "每月",
            "每年"});
            this.scb_cycle.Location = new System.Drawing.Point(78, 23);
            this.scb_cycle.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.scb_cycle.MouseColor = System.Drawing.Color.Orange;
            this.scb_cycle.MouseGradientColor = System.Drawing.Color.Orange;
            this.scb_cycle.Name = "scb_cycle";
            this.scb_cycle.Size = new System.Drawing.Size(137, 24);
            this.scb_cycle.TabIndex = 1;
            this.scb_cycle.WaterText = "";
            this.scb_cycle.SelectedIndexChanged += new System.EventHandler(this.skinComboBox1_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(24, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 19);
            this.label1.TabIndex = 2;
            this.label1.Text = "周期：";
            // 
            // customShellListView
            // 
            this.customShellListView.BorderColor = System.Drawing.Color.LightGray;
            this.customShellListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
            this.customShellListView.ContextMenuStrip = this.contextMenuStrip1;
            this.customShellListView.FullRowSelect = true;
            this.customShellListView.GridLines = true;
            this.customShellListView.HeadColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.customShellListView.Location = new System.Drawing.Point(20, 290);
            this.customShellListView.MultiSelect = false;
            this.customShellListView.Name = "customShellListView";
            this.customShellListView.OwnerDraw = true;
            this.customShellListView.RowBackColor2 = System.Drawing.Color.White;
            this.customShellListView.SelectedColor = System.Drawing.Color.LightSkyBlue;
            this.customShellListView.Size = new System.Drawing.Size(955, 367);
            this.customShellListView.TabIndex = 11;
            this.customShellListView.UseCompatibleStateImageBehavior = false;
            this.customShellListView.View = System.Windows.Forms.View.Details;
            this.customShellListView.KeyUp += new System.Windows.Forms.KeyEventHandler(this.AllKeyUp);
            this.customShellListView.MouseUp += new System.Windows.Forms.MouseEventHandler(this.customShellListView_MouseUp);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "执行时间";
            this.columnHeader1.Width = 200;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "命令名称";
            this.columnHeader2.Width = 150;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Shell脚本";
            this.columnHeader3.Width = 600;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.deleteItemToolStripMenuItem,
            this.upToolStripMenuItem,
            this.downToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(144, 70);
            // 
            // deleteItemToolStripMenuItem
            // 
            this.deleteItemToolStripMenuItem.Image = global::AppMonitor.Properties.Resources.remove_16px;
            this.deleteItemToolStripMenuItem.Name = "deleteItemToolStripMenuItem";
            this.deleteItemToolStripMenuItem.Size = new System.Drawing.Size(143, 22);
            this.deleteItemToolStripMenuItem.Text = "Delete Item";
            this.deleteItemToolStripMenuItem.Click += new System.EventHandler(this.deleteItemToolStripMenuItem_Click);
            // 
            // upToolStripMenuItem
            // 
            this.upToolStripMenuItem.Name = "upToolStripMenuItem";
            this.upToolStripMenuItem.Size = new System.Drawing.Size(143, 22);
            this.upToolStripMenuItem.Text = "Up";
            this.upToolStripMenuItem.Click += new System.EventHandler(this.upToolStripMenuItem_Click);
            // 
            // downToolStripMenuItem
            // 
            this.downToolStripMenuItem.Name = "downToolStripMenuItem";
            this.downToolStripMenuItem.Size = new System.Drawing.Size(143, 22);
            this.downToolStripMenuItem.Text = "Down";
            this.downToolStripMenuItem.Click += new System.EventHandler(this.downToolStripMenuItem_Click);
            // 
            // task_name
            // 
            this.task_name.BackColor = System.Drawing.Color.Transparent;
            this.task_name.DownBack = null;
            this.task_name.Icon = null;
            this.task_name.IconIsButton = false;
            this.task_name.IconMouseState = CCWin.SkinClass.ControlState.Normal;
            this.task_name.IsPasswordChat = '\0';
            this.task_name.IsSystemPasswordChar = false;
            this.task_name.Lines = new string[0];
            this.task_name.Location = new System.Drawing.Point(93, 19);
            this.task_name.Margin = new System.Windows.Forms.Padding(0);
            this.task_name.MaxLength = 32767;
            this.task_name.MinimumSize = new System.Drawing.Size(28, 28);
            this.task_name.MouseBack = null;
            this.task_name.MouseState = CCWin.SkinClass.ControlState.Normal;
            this.task_name.Multiline = false;
            this.task_name.Name = "task_name";
            this.task_name.NormlBack = null;
            this.task_name.Padding = new System.Windows.Forms.Padding(5);
            this.task_name.ReadOnly = false;
            this.task_name.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.task_name.Size = new System.Drawing.Size(433, 28);
            // 
            // 
            // 
            this.task_name.SkinTxt.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.task_name.SkinTxt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.task_name.SkinTxt.Font = new System.Drawing.Font("微软雅黑", 9.75F);
            this.task_name.SkinTxt.Location = new System.Drawing.Point(5, 5);
            this.task_name.SkinTxt.Name = "BaseText";
            this.task_name.SkinTxt.Size = new System.Drawing.Size(423, 18);
            this.task_name.SkinTxt.TabIndex = 0;
            this.task_name.SkinTxt.WaterColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(127)))), ((int)(((byte)(127)))));
            this.task_name.SkinTxt.WaterText = "任务名称";
            this.task_name.TabIndex = 12;
            this.task_name.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.task_name.WaterColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(127)))), ((int)(((byte)(127)))));
            this.task_name.WaterText = "任务名称";
            this.task_name.WordWrap = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(12, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 19);
            this.label2.TabIndex = 13;
            this.label2.Text = "任务名称：";
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.scb_cycle);
            this.groupBox1.Controls.Add(this.week_panel);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.time);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.date);
            this.groupBox1.Location = new System.Drawing.Point(20, 110);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(427, 172);
            this.groupBox1.TabIndex = 14;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "执行时间";
            // 
            // week_panel
            // 
            this.week_panel.Controls.Add(this.week6);
            this.week_panel.Controls.Add(this.week5);
            this.week_panel.Controls.Add(this.week4);
            this.week_panel.Controls.Add(this.week3);
            this.week_panel.Controls.Add(this.week2);
            this.week_panel.Controls.Add(this.week1);
            this.week_panel.Controls.Add(this.week0);
            this.week_panel.Location = new System.Drawing.Point(76, 57);
            this.week_panel.Name = "week_panel";
            this.week_panel.Size = new System.Drawing.Size(332, 29);
            this.week_panel.TabIndex = 18;
            this.week_panel.Visible = false;
            // 
            // week6
            // 
            this.week6.AutoSize = true;
            this.week6.Location = new System.Drawing.Point(266, 4);
            this.week6.Name = "week6";
            this.week6.Size = new System.Drawing.Size(39, 21);
            this.week6.TabIndex = 6;
            this.week6.Text = "六";
            this.week6.UseVisualStyleBackColor = true;
            // 
            // week5
            // 
            this.week5.AutoSize = true;
            this.week5.Location = new System.Drawing.Point(223, 4);
            this.week5.Name = "week5";
            this.week5.Size = new System.Drawing.Size(39, 21);
            this.week5.TabIndex = 5;
            this.week5.Text = "五";
            this.week5.UseVisualStyleBackColor = true;
            // 
            // week4
            // 
            this.week4.AutoSize = true;
            this.week4.Location = new System.Drawing.Point(180, 4);
            this.week4.Name = "week4";
            this.week4.Size = new System.Drawing.Size(39, 21);
            this.week4.TabIndex = 4;
            this.week4.Text = "四";
            this.week4.UseVisualStyleBackColor = true;
            // 
            // week3
            // 
            this.week3.AutoSize = true;
            this.week3.Location = new System.Drawing.Point(137, 4);
            this.week3.Name = "week3";
            this.week3.Size = new System.Drawing.Size(39, 21);
            this.week3.TabIndex = 3;
            this.week3.Text = "三";
            this.week3.UseVisualStyleBackColor = true;
            // 
            // week2
            // 
            this.week2.AutoSize = true;
            this.week2.Location = new System.Drawing.Point(94, 4);
            this.week2.Name = "week2";
            this.week2.Size = new System.Drawing.Size(39, 21);
            this.week2.TabIndex = 2;
            this.week2.Text = "二";
            this.week2.UseVisualStyleBackColor = true;
            // 
            // week1
            // 
            this.week1.AutoSize = true;
            this.week1.Location = new System.Drawing.Point(51, 4);
            this.week1.Name = "week1";
            this.week1.Size = new System.Drawing.Size(39, 21);
            this.week1.TabIndex = 1;
            this.week1.Text = "一";
            this.week1.UseVisualStyleBackColor = true;
            // 
            // week0
            // 
            this.week0.AutoSize = true;
            this.week0.Location = new System.Drawing.Point(4, 4);
            this.week0.Name = "week0";
            this.week0.Size = new System.Drawing.Size(43, 21);
            this.week0.TabIndex = 0;
            this.week0.Text = "日 ";
            this.week0.UseVisualStyleBackColor = true;
            // 
            // time
            // 
            this.time.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.time.Location = new System.Drawing.Point(78, 94);
            this.time.MinDate = new System.DateTime(2017, 11, 20, 0, 0, 0, 0);
            this.time.Name = "time";
            this.time.ShowUpDown = true;
            this.time.Size = new System.Drawing.Size(137, 23);
            this.time.TabIndex = 17;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(24, 59);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 19);
            this.label3.TabIndex = 15;
            this.label3.Text = "日期：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(24, 95);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(48, 19);
            this.label4.TabIndex = 14;
            this.label4.Text = "时间：";
            // 
            // date
            // 
            this.date.CalendarTrailingForeColor = System.Drawing.Color.Olive;
            this.date.Location = new System.Drawing.Point(78, 57);
            this.date.MinDate = new System.DateTime(2017, 11, 20, 0, 0, 0, 0);
            this.date.Name = "date";
            this.date.ShowUpDown = true;
            this.date.Size = new System.Drawing.Size(137, 23);
            this.date.TabIndex = 16;
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.Transparent;
            this.groupBox2.Controls.Add(this.task_name);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Location = new System.Drawing.Point(20, 35);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(788, 61);
            this.groupBox2.TabIndex = 15;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "任务信息";
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.Color.Transparent;
            this.groupBox3.Controls.Add(this.linkLabel2);
            this.groupBox3.Controls.Add(this.linkLabel1);
            this.groupBox3.Controls.Add(this.button1);
            this.groupBox3.Controls.Add(this.shell);
            this.groupBox3.Controls.Add(this.shell_name);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Location = new System.Drawing.Point(453, 111);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(522, 172);
            this.groupBox3.TabIndex = 18;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "任务命令";
            // 
            // linkLabel2
            // 
            this.linkLabel2.AutoSize = true;
            this.linkLabel2.Location = new System.Drawing.Point(457, 68);
            this.linkLabel2.Name = "linkLabel2";
            this.linkLabel2.Size = new System.Drawing.Size(56, 17);
            this.linkLabel2.TabIndex = 20;
            this.linkLabel2.TabStop = true;
            this.linkLabel2.Text = "插入变量";
            this.linkLabel2.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel2_LinkClicked);
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(456, 26);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(56, 17);
            this.linkLabel1.TabIndex = 16;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "选择模版";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(456, 128);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(60, 38);
            this.button1.TabIndex = 19;
            this.button1.Text = "新增↓";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // shell
            // 
            this.shell.BackColor = System.Drawing.Color.Transparent;
            this.shell.DownBack = null;
            this.shell.Icon = null;
            this.shell.IconIsButton = false;
            this.shell.IconMouseState = CCWin.SkinClass.ControlState.Normal;
            this.shell.IsPasswordChat = '\0';
            this.shell.IsSystemPasswordChar = false;
            this.shell.Lines = new string[0];
            this.shell.Location = new System.Drawing.Point(78, 56);
            this.shell.Margin = new System.Windows.Forms.Padding(0);
            this.shell.MaxLength = 32767;
            this.shell.MinimumSize = new System.Drawing.Size(28, 28);
            this.shell.MouseBack = null;
            this.shell.MouseState = CCWin.SkinClass.ControlState.Normal;
            this.shell.Multiline = true;
            this.shell.Name = "shell";
            this.shell.NormlBack = null;
            this.shell.Padding = new System.Windows.Forms.Padding(5);
            this.shell.ReadOnly = false;
            this.shell.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.shell.Size = new System.Drawing.Size(372, 111);
            // 
            // 
            // 
            this.shell.SkinTxt.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.shell.SkinTxt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.shell.SkinTxt.Font = new System.Drawing.Font("微软雅黑", 9.75F);
            this.shell.SkinTxt.Location = new System.Drawing.Point(5, 5);
            this.shell.SkinTxt.Multiline = true;
            this.shell.SkinTxt.Name = "BaseText";
            this.shell.SkinTxt.Size = new System.Drawing.Size(362, 101);
            this.shell.SkinTxt.TabIndex = 0;
            this.shell.SkinTxt.WaterColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(127)))), ((int)(((byte)(127)))));
            this.shell.SkinTxt.WaterText = "shell脚本";
            this.shell.TabIndex = 14;
            this.shell.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.shell.WaterColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(127)))), ((int)(((byte)(127)))));
            this.shell.WaterText = "shell脚本";
            this.shell.WordWrap = true;
            this.shell.Enter += new System.EventHandler(this.shell_Enter);
            // 
            // shell_name
            // 
            this.shell_name.BackColor = System.Drawing.Color.Transparent;
            this.shell_name.DownBack = null;
            this.shell_name.Icon = null;
            this.shell_name.IconIsButton = false;
            this.shell_name.IconMouseState = CCWin.SkinClass.ControlState.Normal;
            this.shell_name.IsPasswordChat = '\0';
            this.shell_name.IsSystemPasswordChar = false;
            this.shell_name.Lines = new string[0];
            this.shell_name.Location = new System.Drawing.Point(78, 19);
            this.shell_name.Margin = new System.Windows.Forms.Padding(0);
            this.shell_name.MaxLength = 32767;
            this.shell_name.MinimumSize = new System.Drawing.Size(28, 28);
            this.shell_name.MouseBack = null;
            this.shell_name.MouseState = CCWin.SkinClass.ControlState.Normal;
            this.shell_name.Multiline = false;
            this.shell_name.Name = "shell_name";
            this.shell_name.NormlBack = null;
            this.shell_name.Padding = new System.Windows.Forms.Padding(5);
            this.shell_name.ReadOnly = false;
            this.shell_name.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.shell_name.Size = new System.Drawing.Size(372, 28);
            // 
            // 
            // 
            this.shell_name.SkinTxt.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.shell_name.SkinTxt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.shell_name.SkinTxt.Font = new System.Drawing.Font("微软雅黑", 9.75F);
            this.shell_name.SkinTxt.Location = new System.Drawing.Point(5, 5);
            this.shell_name.SkinTxt.Name = "BaseText";
            this.shell_name.SkinTxt.Size = new System.Drawing.Size(362, 18);
            this.shell_name.SkinTxt.TabIndex = 0;
            this.shell_name.SkinTxt.WaterColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(127)))), ((int)(((byte)(127)))));
            this.shell_name.SkinTxt.WaterText = "命令/脚本名称";
            this.shell_name.TabIndex = 13;
            this.shell_name.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.shell_name.WaterColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(127)))), ((int)(((byte)(127)))));
            this.shell_name.WaterText = "命令/脚本名称";
            this.shell_name.WordWrap = true;
            this.shell_name.Enter += new System.EventHandler(this.shell_name_Enter);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.Location = new System.Drawing.Point(27, 23);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(48, 19);
            this.label5.TabIndex = 15;
            this.label5.Text = "名称：";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.Location = new System.Drawing.Point(27, 57);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(48, 19);
            this.label6.TabIndex = 14;
            this.label6.Text = "脚本：";
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.button2.Location = new System.Drawing.Point(814, 44);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(161, 52);
            this.button2.TabIndex = 18;
            this.button2.Text = "保存 Ctrl+S";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.label7.Location = new System.Drawing.Point(9, 101);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(980, 5);
            this.label7.TabIndex = 19;
            // 
            // scb_template
            // 
            this.scb_template.BorderColor = System.Drawing.Color.LightGray;
            this.scb_template.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader4,
            this.columnHeader5});
            this.scb_template.FullRowSelect = true;
            this.scb_template.GridLines = true;
            this.scb_template.HeadColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.scb_template.Location = new System.Drawing.Point(158, 5);
            this.scb_template.MultiSelect = false;
            this.scb_template.Name = "scb_template";
            this.scb_template.OwnerDraw = true;
            this.scb_template.RowBackColor2 = System.Drawing.Color.White;
            this.scb_template.SelectedColor = System.Drawing.Color.LightSteelBlue;
            this.scb_template.Size = new System.Drawing.Size(370, 182);
            this.scb_template.TabIndex = 21;
            this.scb_template.UseCompatibleStateImageBehavior = false;
            this.scb_template.View = System.Windows.Forms.View.Details;
            this.scb_template.Visible = false;
            this.scb_template.MouseClick += new System.Windows.Forms.MouseEventHandler(this.scb_template_MouseClick);
            this.scb_template.MouseUp += new System.Windows.Forms.MouseEventHandler(this.scb_template_MouseUp);
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "命令名称";
            this.columnHeader4.Width = 120;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Shell脚本";
            this.columnHeader5.Width = 245;
            // 
            // var_list
            // 
            this.var_list.BorderColor = System.Drawing.Color.LightGray;
            this.var_list.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader6,
            this.columnHeader7});
            this.var_list.FullRowSelect = true;
            this.var_list.GridLines = true;
            this.var_list.HeadColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.var_list.Location = new System.Drawing.Point(539, 5);
            this.var_list.MultiSelect = false;
            this.var_list.Name = "var_list";
            this.var_list.OwnerDraw = true;
            this.var_list.RowBackColor2 = System.Drawing.Color.White;
            this.var_list.SelectedColor = System.Drawing.Color.LightSteelBlue;
            this.var_list.Size = new System.Drawing.Size(370, 182);
            this.var_list.TabIndex = 22;
            this.var_list.UseCompatibleStateImageBehavior = false;
            this.var_list.View = System.Windows.Forms.View.Details;
            this.var_list.Visible = false;
            this.var_list.MouseClick += new System.Windows.Forms.MouseEventHandler(this.var_list_MouseClick);
            this.var_list.MouseUp += new System.Windows.Forms.MouseEventHandler(this.var_list_MouseUp);
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "变量";
            this.columnHeader6.Width = 180;
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "描述";
            this.columnHeader7.Width = 185;
            // 
            // TimedTaskForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::AppMonitor.Properties.Resources.skin_12;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.CaptionFont = new System.Drawing.Font("微软雅黑", 9F);
            this.ClientSize = new System.Drawing.Size(997, 670);
            this.Controls.Add(this.var_list);
            this.Controls.Add(this.scb_template);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.customShellListView);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(718, 528);
            this.Name = "TimedTaskForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "定时任务";
            this.TitleCenter = false;
            this.TitleColor = System.Drawing.Color.White;
            this.Load += new System.EventHandler(this.TimedTaskForm_Load);
            this.contextMenuStrip1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.week_panel.ResumeLayout(false);
            this.week_panel.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private CCWin.SkinControl.SkinComboBox scb_cycle;
        private System.Windows.Forms.Label label1;
        private CCWin.SkinControl.SkinListView customShellListView;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private CCWin.SkinControl.SkinTextBox task_name;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker date;
        private System.Windows.Forms.DateTimePicker time;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private CCWin.SkinControl.SkinTextBox shell;
        private CCWin.SkinControl.SkinTextBox shell_name;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.Panel week_panel;
        private System.Windows.Forms.CheckBox week0;
        private System.Windows.Forms.CheckBox week4;
        private System.Windows.Forms.CheckBox week3;
        private System.Windows.Forms.CheckBox week2;
        private System.Windows.Forms.CheckBox week1;
        private System.Windows.Forms.CheckBox week6;
        private System.Windows.Forms.CheckBox week5;
        private System.Windows.Forms.Label label7;
        private CCWin.SkinControl.SkinListView scb_template;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.LinkLabel linkLabel2;
        private CCWin.SkinControl.SkinListView var_list;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem deleteItemToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem upToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem downToolStripMenuItem;
    }
}