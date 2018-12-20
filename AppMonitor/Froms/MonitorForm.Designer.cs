namespace AppMonitor.Froms
{
    partial class MonitorForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MonitorForm));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tab_terminal = new System.Windows.Forms.TabPage();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tstb_shell = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStrip_more_sh = new System.Windows.Forms.ToolStripDropDownButton();
            this.toolStripDropDownButton1 = new System.Windows.Forms.ToolStripDropDownButton();
            this.newQuickConmandToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.quickShellManageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rtb_log = new System.Windows.Forms.RichTextBox();
            this.shellMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.复制ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.粘贴ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copyPasteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.findToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.selectAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fullScreenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tab_sftp = new System.Windows.Forms.TabPage();
            this.rtb_sftp_log = new System.Windows.Forms.RichTextBox();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.tstb_sftp = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripDropDownButton2 = new System.Windows.Forms.ToolStripDropDownButton();
            this.getserverFilepathlocalFilepathToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.putlocalFilepathserverFilepathToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolbtn_opensftp = new System.Windows.Forms.ToolStripButton();
            this.tab_monitor = new System.Windows.Forms.TabPage();
            this.right_panel = new System.Windows.Forms.Panel();
            this.left_panel = new System.Windows.Forms.Panel();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.treeConMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.newItemToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.springBootAppToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.tomcatToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.nginxToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.iceSrvToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.treeNodeConMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.newItemToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.springBootAppToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tomcatToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nginxToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editItemToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.removeItemToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.tabControl1.SuspendLayout();
            this.tab_terminal.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.shellMenu.SuspendLayout();
            this.tab_sftp.SuspendLayout();
            this.toolStrip2.SuspendLayout();
            this.tab_monitor.SuspendLayout();
            this.left_panel.SuspendLayout();
            this.treeConMenu.SuspendLayout();
            this.treeNodeConMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Appearance = System.Windows.Forms.TabAppearance.FlatButtons;
            this.tabControl1.Controls.Add(this.tab_terminal);
            this.tabControl1.Controls.Add(this.tab_sftp);
            this.tabControl1.Controls.Add(this.tab_monitor);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Multiline = true;
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(930, 601);
            this.tabControl1.TabIndex = 0;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            this.tabControl1.SizeChanged += new System.EventHandler(this.tabControl1_SizeChanged);
            this.tabControl1.KeyUp += new System.Windows.Forms.KeyEventHandler(this.tabControl1_KeyUp);
            // 
            // tab_terminal
            // 
            this.tab_terminal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tab_terminal.Controls.Add(this.listBox1);
            this.tab_terminal.Controls.Add(this.toolStrip1);
            this.tab_terminal.Controls.Add(this.rtb_log);
            this.tab_terminal.Location = new System.Drawing.Point(4, 25);
            this.tab_terminal.Name = "tab_terminal";
            this.tab_terminal.Padding = new System.Windows.Forms.Padding(3);
            this.tab_terminal.Size = new System.Drawing.Size(922, 572);
            this.tab_terminal.TabIndex = 1;
            this.tab_terminal.Text = "Terminal";
            this.tab_terminal.UseVisualStyleBackColor = true;
            // 
            // listBox1
            // 
            this.listBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.listBox1.Font = new System.Drawing.Font("宋体", 10F);
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(5, 383);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(198, 160);
            this.listBox1.TabIndex = 3;
            this.listBox1.Visible = false;
            this.listBox1.DoubleClick += new System.EventHandler(this.listBox1_DoubleClick);
            this.listBox1.KeyUp += new System.Windows.Forms.KeyEventHandler(this.listBox1_KeyUp);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.toolStrip1.BackColor = System.Drawing.Color.White;
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripSeparator1,
            this.tstb_shell,
            this.toolStripSeparator2,
            this.toolStrip_more_sh,
            this.toolStripDropDownButton1});
            this.toolStrip1.Location = new System.Drawing.Point(3, 542);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.toolStrip1.Size = new System.Drawing.Size(885, 25);
            this.toolStrip1.TabIndex = 2;
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // tstb_shell
            // 
            this.tstb_shell.AutoSize = false;
            this.tstb_shell.BackColor = System.Drawing.Color.White;
            this.tstb_shell.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tstb_shell.Enabled = false;
            this.tstb_shell.Font = new System.Drawing.Font("Courier New", 14F);
            this.tstb_shell.ForeColor = System.Drawing.Color.DimGray;
            this.tstb_shell.HideSelection = false;
            this.tstb_shell.Name = "tstb_shell";
            this.tstb_shell.Size = new System.Drawing.Size(810, 22);
            this.tstb_shell.Text = "在此输入Shell指令";
            this.tstb_shell.Enter += new System.EventHandler(this.tstb_shell_Enter);
            this.tstb_shell.Leave += new System.EventHandler(this.tstb_shell_Leave);
            this.tstb_shell.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tstb_shell_KeyDown);
            this.tstb_shell.KeyUp += new System.Windows.Forms.KeyEventHandler(this.tstb_shell_KeyUp);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStrip_more_sh
            // 
            this.toolStrip_more_sh.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStrip_more_sh.Image = global::AppMonitor.Properties.Resources.Terminal_24px;
            this.toolStrip_more_sh.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStrip_more_sh.Name = "toolStrip_more_sh";
            this.toolStrip_more_sh.Size = new System.Drawing.Size(29, 22);
            this.toolStrip_more_sh.Text = "toolStripDropDownButton1";
            // 
            // toolStripDropDownButton1
            // 
            this.toolStripDropDownButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripDropDownButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newQuickConmandToolStripMenuItem,
            this.quickShellManageToolStripMenuItem});
            this.toolStripDropDownButton1.Image = global::AppMonitor.Properties.Resources.custom_24px;
            this.toolStripDropDownButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton1.Name = "toolStripDropDownButton1";
            this.toolStripDropDownButton1.Size = new System.Drawing.Size(29, 22);
            this.toolStripDropDownButton1.Text = "toolStripDropDownButton1";
            // 
            // newQuickConmandToolStripMenuItem
            // 
            this.newQuickConmandToolStripMenuItem.Name = "newQuickConmandToolStripMenuItem";
            this.newQuickConmandToolStripMenuItem.Size = new System.Drawing.Size(225, 22);
            this.newQuickConmandToolStripMenuItem.Text = "New Quick Conmand";
            this.newQuickConmandToolStripMenuItem.Click += new System.EventHandler(this.newQuickConmandToolStripMenuItem_Click);
            // 
            // quickShellManageToolStripMenuItem
            // 
            this.quickShellManageToolStripMenuItem.Name = "quickShellManageToolStripMenuItem";
            this.quickShellManageToolStripMenuItem.Size = new System.Drawing.Size(225, 22);
            this.quickShellManageToolStripMenuItem.Text = "Quick Command Manage";
            this.quickShellManageToolStripMenuItem.Click += new System.EventHandler(this.quickShellManageToolStripMenuItem_Click);
            // 
            // rtb_log
            // 
            this.rtb_log.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rtb_log.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.rtb_log.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rtb_log.ContextMenuStrip = this.shellMenu;
            this.rtb_log.Font = new System.Drawing.Font("Courier New", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtb_log.ForeColor = System.Drawing.Color.CadetBlue;
            this.rtb_log.Location = new System.Drawing.Point(3, 3);
            this.rtb_log.Name = "rtb_log";
            this.rtb_log.ReadOnly = true;
            this.rtb_log.Size = new System.Drawing.Size(914, 533);
            this.rtb_log.TabIndex = 1;
            this.rtb_log.Text = "";
            this.rtb_log.KeyDown += new System.Windows.Forms.KeyEventHandler(this.rtb_log_KeyDown);
            this.rtb_log.KeyUp += new System.Windows.Forms.KeyEventHandler(this.rtb_log_KeyUp);
            this.rtb_log.MouseDown += new System.Windows.Forms.MouseEventHandler(this.rtb_log_MouseDown);
            // 
            // shellMenu
            // 
            this.shellMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.复制ToolStripMenuItem,
            this.粘贴ToolStripMenuItem,
            this.copyPasteToolStripMenuItem,
            this.findToolStripMenuItem,
            this.selectAllToolStripMenuItem,
            this.fullScreenToolStripMenuItem});
            this.shellMenu.Name = "shellMenu";
            this.shellMenu.Size = new System.Drawing.Size(161, 136);
            // 
            // 复制ToolStripMenuItem
            // 
            this.复制ToolStripMenuItem.Image = global::AppMonitor.Properties.Resources.copy;
            this.复制ToolStripMenuItem.Name = "复制ToolStripMenuItem";
            this.复制ToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.复制ToolStripMenuItem.Text = "&Copy";
            this.复制ToolStripMenuItem.Click += new System.EventHandler(this.复制ToolStripMenuItem_Click);
            // 
            // 粘贴ToolStripMenuItem
            // 
            this.粘贴ToolStripMenuItem.Image = global::AppMonitor.Properties.Resources.paste;
            this.粘贴ToolStripMenuItem.Name = "粘贴ToolStripMenuItem";
            this.粘贴ToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.粘贴ToolStripMenuItem.Text = "&Paste";
            this.粘贴ToolStripMenuItem.Click += new System.EventHandler(this.粘贴ToolStripMenuItem_Click);
            // 
            // copyPasteToolStripMenuItem
            // 
            this.copyPasteToolStripMenuItem.Image = global::AppMonitor.Properties.Resources.view_16px;
            this.copyPasteToolStripMenuItem.Name = "copyPasteToolStripMenuItem";
            this.copyPasteToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.copyPasteToolStripMenuItem.Text = "&CopyAndPaste";
            this.copyPasteToolStripMenuItem.Click += new System.EventHandler(this.copyPasteToolStripMenuItem_Click);
            // 
            // findToolStripMenuItem
            // 
            this.findToolStripMenuItem.Image = global::AppMonitor.Properties.Resources.find;
            this.findToolStripMenuItem.Name = "findToolStripMenuItem";
            this.findToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.findToolStripMenuItem.Text = "&Find";
            this.findToolStripMenuItem.Click += new System.EventHandler(this.findToolStripMenuItem_Click);
            // 
            // selectAllToolStripMenuItem
            // 
            this.selectAllToolStripMenuItem.Name = "selectAllToolStripMenuItem";
            this.selectAllToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.selectAllToolStripMenuItem.Text = "&Select All";
            this.selectAllToolStripMenuItem.Click += new System.EventHandler(this.selectAllToolStripMenuItem_Click);
            // 
            // fullScreenToolStripMenuItem
            // 
            this.fullScreenToolStripMenuItem.Image = global::AppMonitor.Properties.Resources.fullScreen;
            this.fullScreenToolStripMenuItem.Name = "fullScreenToolStripMenuItem";
            this.fullScreenToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.fullScreenToolStripMenuItem.Text = "&Full Screen";
            this.fullScreenToolStripMenuItem.Click += new System.EventHandler(this.fullScreenToolStripMenuItem_Click);
            // 
            // tab_sftp
            // 
            this.tab_sftp.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tab_sftp.Controls.Add(this.rtb_sftp_log);
            this.tab_sftp.Controls.Add(this.toolStrip2);
            this.tab_sftp.Location = new System.Drawing.Point(4, 25);
            this.tab_sftp.Name = "tab_sftp";
            this.tab_sftp.Padding = new System.Windows.Forms.Padding(3);
            this.tab_sftp.Size = new System.Drawing.Size(922, 572);
            this.tab_sftp.TabIndex = 2;
            this.tab_sftp.Text = "Sftp";
            this.tab_sftp.UseVisualStyleBackColor = true;
            // 
            // rtb_sftp_log
            // 
            this.rtb_sftp_log.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rtb_sftp_log.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.rtb_sftp_log.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rtb_sftp_log.ContextMenuStrip = this.shellMenu;
            this.rtb_sftp_log.Font = new System.Drawing.Font("Courier New", 14.25F);
            this.rtb_sftp_log.ForeColor = System.Drawing.Color.CadetBlue;
            this.rtb_sftp_log.Location = new System.Drawing.Point(3, 3);
            this.rtb_sftp_log.Name = "rtb_sftp_log";
            this.rtb_sftp_log.ReadOnly = true;
            this.rtb_sftp_log.Size = new System.Drawing.Size(915, 536);
            this.rtb_sftp_log.TabIndex = 4;
            this.rtb_sftp_log.Text = "";
            this.rtb_sftp_log.KeyDown += new System.Windows.Forms.KeyEventHandler(this.rtb_sftp_log_KeyDown);
            this.rtb_sftp_log.KeyUp += new System.Windows.Forms.KeyEventHandler(this.rtb_sftp_log_KeyUp);
            this.rtb_sftp_log.MouseDown += new System.Windows.Forms.MouseEventHandler(this.rtb_sftp_log_MouseDown);
            // 
            // toolStrip2
            // 
            this.toolStrip2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.toolStrip2.BackColor = System.Drawing.Color.White;
            this.toolStrip2.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStrip2.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripSeparator3,
            this.tstb_sftp,
            this.toolStripSeparator4,
            this.toolStripDropDownButton2,
            this.toolbtn_opensftp});
            this.toolStrip2.Location = new System.Drawing.Point(2, 542);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.toolStrip2.Size = new System.Drawing.Size(879, 25);
            this.toolStrip2.TabIndex = 3;
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // tstb_sftp
            // 
            this.tstb_sftp.AutoSize = false;
            this.tstb_sftp.BackColor = System.Drawing.Color.White;
            this.tstb_sftp.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tstb_sftp.Enabled = false;
            this.tstb_sftp.Font = new System.Drawing.Font("Courier New", 14F);
            this.tstb_sftp.ForeColor = System.Drawing.Color.DimGray;
            this.tstb_sftp.HideSelection = false;
            this.tstb_sftp.Name = "tstb_sftp";
            this.tstb_sftp.Size = new System.Drawing.Size(810, 22);
            this.tstb_sftp.Text = "在此输入Sftp指令";
            this.tstb_sftp.Enter += new System.EventHandler(this.sftp_text_enter);
            this.tstb_sftp.Leave += new System.EventHandler(this.sftp_text_leave);
            this.tstb_sftp.KeyUp += new System.Windows.Forms.KeyEventHandler(this.tstb_sftp_KeyUp);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripDropDownButton2
            // 
            this.toolStripDropDownButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripDropDownButton2.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.getserverFilepathlocalFilepathToolStripMenuItem,
            this.putlocalFilepathserverFilepathToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.toolStripDropDownButton2.Image = global::AppMonitor.Properties.Resources.Terminal_24px;
            this.toolStripDropDownButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton2.Name = "toolStripDropDownButton2";
            this.toolStripDropDownButton2.Size = new System.Drawing.Size(29, 22);
            this.toolStripDropDownButton2.Text = "toolStripDropDownButton1";
            // 
            // getserverFilepathlocalFilepathToolStripMenuItem
            // 
            this.getserverFilepathlocalFilepathToolStripMenuItem.Name = "getserverFilepathlocalFilepathToolStripMenuItem";
            this.getserverFilepathlocalFilepathToolStripMenuItem.Size = new System.Drawing.Size(276, 22);
            this.getserverFilepathlocalFilepathToolStripMenuItem.Text = "get [server filepath] [local filepath]";
            this.getserverFilepathlocalFilepathToolStripMenuItem.Click += new System.EventHandler(this.sftp_quick_click);
            // 
            // putlocalFilepathserverFilepathToolStripMenuItem
            // 
            this.putlocalFilepathserverFilepathToolStripMenuItem.Name = "putlocalFilepathserverFilepathToolStripMenuItem";
            this.putlocalFilepathserverFilepathToolStripMenuItem.Size = new System.Drawing.Size(276, 22);
            this.putlocalFilepathserverFilepathToolStripMenuItem.Text = "put [local filepath] [server filepath]";
            this.putlocalFilepathserverFilepathToolStripMenuItem.Click += new System.EventHandler(this.sftp_quick_click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(276, 22);
            this.helpToolStripMenuItem.Text = "help&";
            this.helpToolStripMenuItem.Click += new System.EventHandler(this.sftp_quick_click);
            // 
            // toolbtn_opensftp
            // 
            this.toolbtn_opensftp.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolbtn_opensftp.Image = global::AppMonitor.Properties.Resources.ftp;
            this.toolbtn_opensftp.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolbtn_opensftp.Name = "toolbtn_opensftp";
            this.toolbtn_opensftp.Size = new System.Drawing.Size(23, 22);
            this.toolbtn_opensftp.Text = "toolStripButton1";
            this.toolbtn_opensftp.Click += new System.EventHandler(this.toolbtn_opensftp_Click);
            // 
            // tab_monitor
            // 
            this.tab_monitor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tab_monitor.Controls.Add(this.right_panel);
            this.tab_monitor.Controls.Add(this.left_panel);
            this.tab_monitor.Location = new System.Drawing.Point(4, 25);
            this.tab_monitor.Name = "tab_monitor";
            this.tab_monitor.Padding = new System.Windows.Forms.Padding(3);
            this.tab_monitor.Size = new System.Drawing.Size(922, 572);
            this.tab_monitor.TabIndex = 0;
            this.tab_monitor.Text = "Monitor";
            this.tab_monitor.UseVisualStyleBackColor = true;
            // 
            // right_panel
            // 
            this.right_panel.BackColor = System.Drawing.SystemColors.Control;
            this.right_panel.Location = new System.Drawing.Point(250, 0);
            this.right_panel.Name = "right_panel";
            this.right_panel.Size = new System.Drawing.Size(670, 570);
            this.right_panel.TabIndex = 2;
            // 
            // left_panel
            // 
            this.left_panel.Controls.Add(this.treeView1);
            this.left_panel.Location = new System.Drawing.Point(0, 0);
            this.left_panel.Name = "left_panel";
            this.left_panel.Size = new System.Drawing.Size(245, 570);
            this.left_panel.TabIndex = 1;
            // 
            // treeView1
            // 
            this.treeView1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(230)))), ((int)(((byte)(235)))));
            this.treeView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.treeView1.ContextMenuStrip = this.treeConMenu;
            this.treeView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeView1.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.treeView1.FullRowSelect = true;
            this.treeView1.ImageIndex = 0;
            this.treeView1.ImageList = this.imageList1;
            this.treeView1.Indent = 12;
            this.treeView1.ItemHeight = 30;
            this.treeView1.Location = new System.Drawing.Point(0, 0);
            this.treeView1.Name = "treeView1";
            this.treeView1.SelectedImageIndex = 0;
            this.treeView1.Size = new System.Drawing.Size(245, 570);
            this.treeView1.TabIndex = 0;
            this.treeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterSelect);
            this.treeView1.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.treeView1_NodeMouseClick);
            // 
            // treeConMenu
            // 
            this.treeConMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newItemToolStripMenuItem1});
            this.treeConMenu.Name = "treeConMenu";
            this.treeConMenu.Size = new System.Drawing.Size(133, 26);
            // 
            // newItemToolStripMenuItem1
            // 
            this.newItemToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.springBootAppToolStripMenuItem2,
            this.tomcatToolStripMenuItem1,
            this.nginxToolStripMenuItem1,
            this.iceSrvToolStripMenuItem});
            this.newItemToolStripMenuItem1.Name = "newItemToolStripMenuItem1";
            this.newItemToolStripMenuItem1.Size = new System.Drawing.Size(132, 22);
            this.newItemToolStripMenuItem1.Text = "New Item";
            // 
            // springBootAppToolStripMenuItem2
            // 
            this.springBootAppToolStripMenuItem2.Name = "springBootAppToolStripMenuItem2";
            this.springBootAppToolStripMenuItem2.Size = new System.Drawing.Size(170, 22);
            this.springBootAppToolStripMenuItem2.Text = "SpringBoot App";
            this.springBootAppToolStripMenuItem2.Click += new System.EventHandler(this.NewItemMenuItemClick);
            // 
            // tomcatToolStripMenuItem1
            // 
            this.tomcatToolStripMenuItem1.Name = "tomcatToolStripMenuItem1";
            this.tomcatToolStripMenuItem1.Size = new System.Drawing.Size(170, 22);
            this.tomcatToolStripMenuItem1.Text = "Tomcat";
            this.tomcatToolStripMenuItem1.Click += new System.EventHandler(this.NewItemMenuItemClick);
            // 
            // nginxToolStripMenuItem1
            // 
            this.nginxToolStripMenuItem1.Name = "nginxToolStripMenuItem1";
            this.nginxToolStripMenuItem1.Size = new System.Drawing.Size(170, 22);
            this.nginxToolStripMenuItem1.Text = "Nginx";
            this.nginxToolStripMenuItem1.Click += new System.EventHandler(this.NewItemMenuItemClick);
            // 
            // iceSrvToolStripMenuItem
            // 
            this.iceSrvToolStripMenuItem.Name = "iceSrvToolStripMenuItem";
            this.iceSrvToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
            this.iceSrvToolStripMenuItem.Text = "IceSrv";
            this.iceSrvToolStripMenuItem.Click += new System.EventHandler(this.NewItemMenuItemClick);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "gray_light_48.png");
            this.imageList1.Images.SetKeyName(1, "green_light_48.png");
            this.imageList1.Images.SetKeyName(2, "org_light_48.png");
            this.imageList1.Images.SetKeyName(3, "Terminal_24px.png");
            // 
            // treeNodeConMenu
            // 
            this.treeNodeConMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newItemToolStripMenuItem,
            this.editItemToolStripMenuItem,
            this.removeItemToolStripMenuItem});
            this.treeNodeConMenu.Name = "contextMenuStrip1";
            this.treeNodeConMenu.Size = new System.Drawing.Size(154, 70);
            // 
            // newItemToolStripMenuItem
            // 
            this.newItemToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.springBootAppToolStripMenuItem,
            this.tomcatToolStripMenuItem,
            this.nginxToolStripMenuItem});
            this.newItemToolStripMenuItem.Name = "newItemToolStripMenuItem";
            this.newItemToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
            this.newItemToolStripMenuItem.Text = "New Item";
            // 
            // springBootAppToolStripMenuItem
            // 
            this.springBootAppToolStripMenuItem.Name = "springBootAppToolStripMenuItem";
            this.springBootAppToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
            this.springBootAppToolStripMenuItem.Text = "SpringBoot App";
            this.springBootAppToolStripMenuItem.Click += new System.EventHandler(this.NewItemMenuItemClick);
            // 
            // tomcatToolStripMenuItem
            // 
            this.tomcatToolStripMenuItem.Name = "tomcatToolStripMenuItem";
            this.tomcatToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
            this.tomcatToolStripMenuItem.Text = "Tomcat";
            this.tomcatToolStripMenuItem.Click += new System.EventHandler(this.NewItemMenuItemClick);
            // 
            // nginxToolStripMenuItem
            // 
            this.nginxToolStripMenuItem.Name = "nginxToolStripMenuItem";
            this.nginxToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
            this.nginxToolStripMenuItem.Text = "Nginx";
            this.nginxToolStripMenuItem.Click += new System.EventHandler(this.NewItemMenuItemClick);
            // 
            // editItemToolStripMenuItem
            // 
            this.editItemToolStripMenuItem.Name = "editItemToolStripMenuItem";
            this.editItemToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
            this.editItemToolStripMenuItem.Text = "Edit Item";
            this.editItemToolStripMenuItem.Click += new System.EventHandler(this.editItemToolStripMenuItem_Click);
            // 
            // removeItemToolStripMenuItem
            // 
            this.removeItemToolStripMenuItem.Name = "removeItemToolStripMenuItem";
            this.removeItemToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
            this.removeItemToolStripMenuItem.Text = "Remove Item";
            this.removeItemToolStripMenuItem.Click += new System.EventHandler(this.removeItemToolStripMenuItem_Click);
            // 
            // timer1
            // 
            this.timer1.Interval = 300;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // MonitorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(930, 601);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "MonitorForm";
            this.ShowInTaskbar = false;
            this.Text = "MonitorForm";
            this.Load += new System.EventHandler(this.MonitorForm_Load);
            this.SizeChanged += new System.EventHandler(this.MonitorForm_SizeChanged);
            this.tabControl1.ResumeLayout(false);
            this.tab_terminal.ResumeLayout(false);
            this.tab_terminal.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.shellMenu.ResumeLayout(false);
            this.tab_sftp.ResumeLayout(false);
            this.tab_sftp.PerformLayout();
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            this.tab_monitor.ResumeLayout(false);
            this.left_panel.ResumeLayout(false);
            this.treeConMenu.ResumeLayout(false);
            this.treeNodeConMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tab_monitor;
        private System.Windows.Forms.TabPage tab_terminal;
        private System.Windows.Forms.RichTextBox rtb_log;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripTextBox tstb_shell;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ContextMenuStrip shellMenu;
        private System.Windows.Forms.ToolStripMenuItem 复制ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 粘贴ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem selectAllToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem findToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fullScreenToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip treeNodeConMenu;
        private System.Windows.Forms.ToolStripMenuItem newItemToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tomcatToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nginxToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem springBootAppToolStripMenuItem;
        private System.Windows.Forms.ToolStripDropDownButton toolStrip_more_sh;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton1;
        private System.Windows.Forms.ToolStripMenuItem newQuickConmandToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem quickShellManageToolStripMenuItem;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ToolStripMenuItem editItemToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem removeItemToolStripMenuItem;
        private System.Windows.Forms.TabPage tab_sftp;
        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripTextBox tstb_sftp;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton2;
        private System.Windows.Forms.ToolStripButton toolbtn_opensftp;
        private System.Windows.Forms.ToolStripMenuItem getserverFilepathlocalFilepathToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem putlocalFilepathserverFilepathToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.RichTextBox rtb_sftp_log;
        private System.Windows.Forms.Panel left_panel;
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Panel right_panel;
        private System.Windows.Forms.ContextMenuStrip treeConMenu;
        private System.Windows.Forms.ToolStripMenuItem newItemToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem springBootAppToolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem tomcatToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem nginxToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem copyPasteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem iceSrvToolStripMenuItem;
        private System.Windows.Forms.ListBox listBox1;
    }
}