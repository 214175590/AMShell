namespace AppMonitor.Froms
{
    partial class ConditionTaskForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ConditionTaskForm));
            this.scb_condition1 = new CCWin.SkinControl.SkinComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.customShellListView = new CCWin.SkinControl.SkinListView();
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.deleteItemToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.upToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.downToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.task_name = new CCWin.SkinControl.SkinTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.scb_status3 = new CCWin.SkinControl.SkinComboBox();
            this.btn_di3 = new System.Windows.Forms.Button();
            this.scb_condition3 = new CCWin.SkinControl.SkinComboBox();
            this.rb_q2 = new System.Windows.Forms.RadioButton();
            this.rb_h2 = new System.Windows.Forms.RadioButton();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.scb_status2 = new CCWin.SkinControl.SkinComboBox();
            this.scb_status1 = new CCWin.SkinControl.SkinComboBox();
            this.btn_di2 = new System.Windows.Forms.Button();
            this.rb_q1 = new System.Windows.Forms.RadioButton();
            this.rb_h1 = new System.Windows.Forms.RadioButton();
            this.scb_condition2 = new CCWin.SkinControl.SkinComboBox();
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
            this.groupBox5.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // scb_condition1
            // 
            this.scb_condition1.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.scb_condition1.BorderColor = System.Drawing.Color.LightSteelBlue;
            this.scb_condition1.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.scb_condition1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.scb_condition1.Font = new System.Drawing.Font("宋体", 10F);
            this.scb_condition1.FormattingEnabled = true;
            this.scb_condition1.ItemBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.scb_condition1.ItemHeight = 18;
            this.scb_condition1.Location = new System.Drawing.Point(98, 19);
            this.scb_condition1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.scb_condition1.MouseColor = System.Drawing.Color.Orange;
            this.scb_condition1.MouseGradientColor = System.Drawing.Color.Orange;
            this.scb_condition1.Name = "scb_condition1";
            this.scb_condition1.Size = new System.Drawing.Size(192, 24);
            this.scb_condition1.TabIndex = 1;
            this.scb_condition1.WaterText = "";
            this.scb_condition1.SelectedIndexChanged += new System.EventHandler(this.scb_condition1_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(68, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(22, 19);
            this.label1.TabIndex = 2;
            this.label1.Text = "当";
            // 
            // customShellListView
            // 
            this.customShellListView.BorderColor = System.Drawing.Color.LightGray;
            this.customShellListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
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
            // columnHeader2
            // 
            this.columnHeader2.Text = "命令名称";
            this.columnHeader2.Width = 200;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Shell脚本";
            this.columnHeader3.Width = 750;
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
            this.groupBox1.Controls.Add(this.groupBox5);
            this.groupBox1.Controls.Add(this.groupBox4);
            this.groupBox1.Location = new System.Drawing.Point(20, 110);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(427, 172);
            this.groupBox1.TabIndex = 14;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "执行条件";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.scb_status3);
            this.groupBox5.Controls.Add(this.btn_di3);
            this.groupBox5.Controls.Add(this.scb_condition3);
            this.groupBox5.Controls.Add(this.rb_q2);
            this.groupBox5.Controls.Add(this.rb_h2);
            this.groupBox5.Location = new System.Drawing.Point(6, 108);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(415, 54);
            this.groupBox5.TabIndex = 26;
            this.groupBox5.TabStop = false;
            // 
            // scb_status3
            // 
            this.scb_status3.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.scb_status3.BorderColor = System.Drawing.Color.LightSteelBlue;
            this.scb_status3.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.scb_status3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.scb_status3.Font = new System.Drawing.Font("宋体", 10F);
            this.scb_status3.FormattingEnabled = true;
            this.scb_status3.ItemBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.scb_status3.ItemHeight = 18;
            this.scb_status3.Location = new System.Drawing.Point(295, 20);
            this.scb_status3.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.scb_status3.MouseColor = System.Drawing.Color.Orange;
            this.scb_status3.MouseGradientColor = System.Drawing.Color.Orange;
            this.scb_status3.Name = "scb_status3";
            this.scb_status3.Size = new System.Drawing.Size(90, 24);
            this.scb_status3.TabIndex = 24;
            this.scb_status3.WaterText = "";
            // 
            // btn_di3
            // 
            this.btn_di3.Enabled = false;
            this.btn_di3.Image = global::AppMonitor.Properties.Resources.remove_16px;
            this.btn_di3.Location = new System.Drawing.Point(391, 22);
            this.btn_di3.Name = "btn_di3";
            this.btn_di3.Size = new System.Drawing.Size(20, 20);
            this.btn_di3.TabIndex = 22;
            this.btn_di3.UseVisualStyleBackColor = true;
            this.btn_di3.Click += new System.EventHandler(this.btn_di3_Click);
            // 
            // scb_condition3
            // 
            this.scb_condition3.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.scb_condition3.BorderColor = System.Drawing.Color.LightSteelBlue;
            this.scb_condition3.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.scb_condition3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.scb_condition3.Enabled = false;
            this.scb_condition3.Font = new System.Drawing.Font("宋体", 10F);
            this.scb_condition3.FormattingEnabled = true;
            this.scb_condition3.ItemBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.scb_condition3.ItemHeight = 18;
            this.scb_condition3.Location = new System.Drawing.Point(98, 19);
            this.scb_condition3.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.scb_condition3.MouseColor = System.Drawing.Color.Orange;
            this.scb_condition3.MouseGradientColor = System.Drawing.Color.Orange;
            this.scb_condition3.Name = "scb_condition3";
            this.scb_condition3.Size = new System.Drawing.Size(192, 24);
            this.scb_condition3.TabIndex = 23;
            this.scb_condition3.WaterText = "";
            this.scb_condition3.SelectedIndexChanged += new System.EventHandler(this.scb_condition3_SelectedIndexChanged);
            // 
            // rb_q2
            // 
            this.rb_q2.AutoSize = true;
            this.rb_q2.Enabled = false;
            this.rb_q2.Location = new System.Drawing.Point(8, 21);
            this.rb_q2.Name = "rb_q2";
            this.rb_q2.Size = new System.Drawing.Size(38, 21);
            this.rb_q2.TabIndex = 21;
            this.rb_q2.TabStop = true;
            this.rb_q2.Text = "且";
            this.rb_q2.UseVisualStyleBackColor = true;
            this.rb_q2.CheckedChanged += new System.EventHandler(this.CheckBoxGroup2_CheckedChange);
            // 
            // rb_h2
            // 
            this.rb_h2.AutoSize = true;
            this.rb_h2.Enabled = false;
            this.rb_h2.Location = new System.Drawing.Point(52, 21);
            this.rb_h2.Name = "rb_h2";
            this.rb_h2.Size = new System.Drawing.Size(38, 21);
            this.rb_h2.TabIndex = 22;
            this.rb_h2.TabStop = true;
            this.rb_h2.Text = "或";
            this.rb_h2.UseVisualStyleBackColor = true;
            this.rb_h2.CheckedChanged += new System.EventHandler(this.CheckBoxGroup2_CheckedChange);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.scb_status2);
            this.groupBox4.Controls.Add(this.scb_status1);
            this.groupBox4.Controls.Add(this.btn_di2);
            this.groupBox4.Controls.Add(this.scb_condition1);
            this.groupBox4.Controls.Add(this.label1);
            this.groupBox4.Controls.Add(this.rb_q1);
            this.groupBox4.Controls.Add(this.rb_h1);
            this.groupBox4.Controls.Add(this.scb_condition2);
            this.groupBox4.Location = new System.Drawing.Point(6, 17);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(415, 92);
            this.groupBox4.TabIndex = 25;
            this.groupBox4.TabStop = false;
            // 
            // scb_status2
            // 
            this.scb_status2.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.scb_status2.BorderColor = System.Drawing.Color.LightSteelBlue;
            this.scb_status2.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.scb_status2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.scb_status2.Font = new System.Drawing.Font("宋体", 10F);
            this.scb_status2.FormattingEnabled = true;
            this.scb_status2.ItemBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.scb_status2.ItemHeight = 18;
            this.scb_status2.Location = new System.Drawing.Point(296, 57);
            this.scb_status2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.scb_status2.MouseColor = System.Drawing.Color.Orange;
            this.scb_status2.MouseGradientColor = System.Drawing.Color.Orange;
            this.scb_status2.Name = "scb_status2";
            this.scb_status2.Size = new System.Drawing.Size(90, 24);
            this.scb_status2.TabIndex = 23;
            this.scb_status2.WaterText = "";
            // 
            // scb_status1
            // 
            this.scb_status1.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.scb_status1.BorderColor = System.Drawing.Color.LightSteelBlue;
            this.scb_status1.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.scb_status1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.scb_status1.Font = new System.Drawing.Font("宋体", 10F);
            this.scb_status1.FormattingEnabled = true;
            this.scb_status1.ItemBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.scb_status1.ItemHeight = 18;
            this.scb_status1.Location = new System.Drawing.Point(296, 19);
            this.scb_status1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.scb_status1.MouseColor = System.Drawing.Color.Orange;
            this.scb_status1.MouseGradientColor = System.Drawing.Color.Orange;
            this.scb_status1.Name = "scb_status1";
            this.scb_status1.Size = new System.Drawing.Size(90, 24);
            this.scb_status1.TabIndex = 22;
            this.scb_status1.WaterText = "";
            // 
            // btn_di2
            // 
            this.btn_di2.Enabled = false;
            this.btn_di2.Image = global::AppMonitor.Properties.Resources.remove_16px;
            this.btn_di2.Location = new System.Drawing.Point(391, 59);
            this.btn_di2.Name = "btn_di2";
            this.btn_di2.Size = new System.Drawing.Size(20, 20);
            this.btn_di2.TabIndex = 21;
            this.btn_di2.UseVisualStyleBackColor = true;
            this.btn_di2.Click += new System.EventHandler(this.btn_di2_Click);
            // 
            // rb_q1
            // 
            this.rb_q1.AutoSize = true;
            this.rb_q1.Enabled = false;
            this.rb_q1.Location = new System.Drawing.Point(8, 58);
            this.rb_q1.Name = "rb_q1";
            this.rb_q1.Size = new System.Drawing.Size(38, 21);
            this.rb_q1.TabIndex = 17;
            this.rb_q1.TabStop = true;
            this.rb_q1.Text = "且";
            this.rb_q1.UseVisualStyleBackColor = true;
            this.rb_q1.CheckedChanged += new System.EventHandler(this.CheckBoxGroup1_CheckedChange);
            // 
            // rb_h1
            // 
            this.rb_h1.AutoSize = true;
            this.rb_h1.Enabled = false;
            this.rb_h1.Location = new System.Drawing.Point(52, 58);
            this.rb_h1.Name = "rb_h1";
            this.rb_h1.Size = new System.Drawing.Size(38, 21);
            this.rb_h1.TabIndex = 18;
            this.rb_h1.TabStop = true;
            this.rb_h1.Text = "或";
            this.rb_h1.UseVisualStyleBackColor = true;
            this.rb_h1.CheckedChanged += new System.EventHandler(this.CheckBoxGroup1_CheckedChange);
            // 
            // scb_condition2
            // 
            this.scb_condition2.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.scb_condition2.BorderColor = System.Drawing.Color.LightSteelBlue;
            this.scb_condition2.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.scb_condition2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.scb_condition2.Enabled = false;
            this.scb_condition2.Font = new System.Drawing.Font("宋体", 10F);
            this.scb_condition2.FormattingEnabled = true;
            this.scb_condition2.ItemBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.scb_condition2.ItemHeight = 18;
            this.scb_condition2.Location = new System.Drawing.Point(98, 56);
            this.scb_condition2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.scb_condition2.MouseColor = System.Drawing.Color.Orange;
            this.scb_condition2.MouseGradientColor = System.Drawing.Color.Orange;
            this.scb_condition2.Name = "scb_condition2";
            this.scb_condition2.Size = new System.Drawing.Size(192, 24);
            this.scb_condition2.TabIndex = 19;
            this.scb_condition2.WaterText = "";
            this.scb_condition2.SelectedIndexChanged += new System.EventHandler(this.scb_condition2_SelectedIndexChanged);
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
            this.scb_template.Location = new System.Drawing.Point(484, 5);
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
            // ConditionTaskForm
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
            this.Name = "ConditionTaskForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "条件任务";
            this.TitleCenter = false;
            this.TitleColor = System.Drawing.Color.White;
            this.Load += new System.EventHandler(this.ConditionTaskForm_Load);
            this.contextMenuStrip1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private CCWin.SkinControl.SkinComboBox scb_condition1;
        private System.Windows.Forms.Label label1;
        private CCWin.SkinControl.SkinListView customShellListView;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private CCWin.SkinControl.SkinTextBox task_name;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private CCWin.SkinControl.SkinTextBox shell;
        private CCWin.SkinControl.SkinTextBox shell_name;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.LinkLabel linkLabel1;
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
        private System.Windows.Forms.RadioButton rb_q1;
        private System.Windows.Forms.RadioButton rb_h1;
        private CCWin.SkinControl.SkinComboBox scb_condition2;
        private CCWin.SkinControl.SkinComboBox scb_condition3;
        private System.Windows.Forms.RadioButton rb_h2;
        private System.Windows.Forms.RadioButton rb_q2;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button btn_di2;
        private System.Windows.Forms.Button btn_di3;
        private CCWin.SkinControl.SkinComboBox scb_status3;
        private CCWin.SkinControl.SkinComboBox scb_status2;
        private CCWin.SkinControl.SkinComboBox scb_status1;
    }
}