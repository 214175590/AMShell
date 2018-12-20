namespace AppMonitor.Froms
{
    partial class SshSettingForm
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
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("Authentication");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("Connection", new System.Windows.Forms.TreeNode[] {
            treeNode1});
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("Setting");
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("Appearance");
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SshSettingForm));
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.nud_port = new System.Windows.Forms.NumericUpDown();
            this.cb_protocol = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tb_host = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tb_name = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cb_remenber_pwd = new System.Windows.Forms.CheckBox();
            this.cb_method = new System.Windows.Forms.ComboBox();
            this.tb_userName = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.tb_password = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.cb_fontSize = new System.Windows.Forms.ComboBox();
            this.cb_fontName = new System.Windows.Forms.ComboBox();
            this.btn_edit_theme = new System.Windows.Forms.Button();
            this.cb_scheme = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.rtb_preview = new System.Windows.Forms.RichTextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btn_Ok = new System.Windows.Forms.Button();
            this.btn_Cancel = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nud_port)).BeginInit();
            this.tabPage2.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // treeView1
            // 
            this.treeView1.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.treeView1.Location = new System.Drawing.Point(19, 41);
            this.treeView1.Name = "treeView1";
            treeNode1.Name = "Authentication";
            treeNode1.Text = "Authentication";
            treeNode2.Name = "Connection";
            treeNode2.NodeFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            treeNode2.Text = "Connection";
            treeNode3.Name = "Setting";
            treeNode3.NodeFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            treeNode3.Text = "Setting";
            treeNode4.Name = "Appearance";
            treeNode4.NodeFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            treeNode4.Text = "Appearance";
            this.treeView1.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode2,
            treeNode3,
            treeNode4});
            this.treeView1.Size = new System.Drawing.Size(192, 386);
            this.treeView1.TabIndex = 1;
            this.treeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterSelect);
            // 
            // tabControl1
            // 
            this.tabControl1.Alignment = System.Windows.Forms.TabAlignment.Left;
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Location = new System.Drawing.Point(181, 41);
            this.tabControl1.Multiline = true;
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(479, 386);
            this.tabControl1.TabIndex = 2;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Location = new System.Drawing.Point(22, 4);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(453, 378);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "tab_conn";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.nud_port);
            this.groupBox1.Controls.Add(this.cb_protocol);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.tb_host);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.tb_name);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(20, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(422, 192);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "General";
            // 
            // nud_port
            // 
            this.nud_port.Location = new System.Drawing.Point(103, 135);
            this.nud_port.Maximum = new decimal(new int[] {
            65000,
            0,
            0,
            0});
            this.nud_port.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nud_port.Name = "nud_port";
            this.nud_port.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.nud_port.Size = new System.Drawing.Size(80, 21);
            this.nud_port.TabIndex = 7;
            this.nud_port.Value = new decimal(new int[] {
            22,
            0,
            0,
            0});
            // 
            // cb_protocol
            // 
            this.cb_protocol.DisplayMember = "SSH";
            this.cb_protocol.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_protocol.FormattingEnabled = true;
            this.cb_protocol.Items.AddRange(new object[] {
            "SSH"});
            this.cb_protocol.Location = new System.Drawing.Point(103, 60);
            this.cb_protocol.Name = "cb_protocol";
            this.cb_protocol.Size = new System.Drawing.Size(275, 20);
            this.cb_protocol.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(14, 137);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(83, 12);
            this.label4.TabIndex = 5;
            this.label4.Text = "Port Number：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(14, 63);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 4;
            this.label3.Text = "Protocol：";
            // 
            // tb_host
            // 
            this.tb_host.BackColor = System.Drawing.Color.White;
            this.tb_host.Location = new System.Drawing.Point(103, 96);
            this.tb_host.Name = "tb_host";
            this.tb_host.Size = new System.Drawing.Size(275, 21);
            this.tb_host.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 100);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "Host：";
            // 
            // tb_name
            // 
            this.tb_name.BackColor = System.Drawing.Color.White;
            this.tb_name.Location = new System.Drawing.Point(103, 23);
            this.tb_name.Name = "tb_name";
            this.tb_name.Size = new System.Drawing.Size(275, 21);
            this.tb_name.TabIndex = 1;
            this.tb_name.Text = "New Session";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "Name：";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.groupBox2);
            this.tabPage2.Location = new System.Drawing.Point(22, 4);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(453, 378);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tab_authen";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cb_remenber_pwd);
            this.groupBox2.Controls.Add(this.cb_method);
            this.groupBox2.Controls.Add(this.tb_userName);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.tb_password);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Location = new System.Drawing.Point(20, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(422, 176);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Authentication";
            // 
            // cb_remenber_pwd
            // 
            this.cb_remenber_pwd.AutoSize = true;
            this.cb_remenber_pwd.Checked = true;
            this.cb_remenber_pwd.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cb_remenber_pwd.Location = new System.Drawing.Point(15, 146);
            this.cb_remenber_pwd.Name = "cb_remenber_pwd";
            this.cb_remenber_pwd.Size = new System.Drawing.Size(120, 16);
            this.cb_remenber_pwd.TabIndex = 7;
            this.cb_remenber_pwd.Text = "记住用户名与密码";
            this.cb_remenber_pwd.UseVisualStyleBackColor = true;
            // 
            // cb_method
            // 
            this.cb_method.DisplayMember = "SSH";
            this.cb_method.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_method.FormattingEnabled = true;
            this.cb_method.Items.AddRange(new object[] {
            "Password"});
            this.cb_method.Location = new System.Drawing.Point(103, 22);
            this.cb_method.Name = "cb_method";
            this.cb_method.Size = new System.Drawing.Size(279, 20);
            this.cb_method.TabIndex = 6;
            // 
            // tb_userName
            // 
            this.tb_userName.BackColor = System.Drawing.Color.White;
            this.tb_userName.Location = new System.Drawing.Point(103, 59);
            this.tb_userName.Name = "tb_userName";
            this.tb_userName.Size = new System.Drawing.Size(279, 21);
            this.tb_userName.TabIndex = 1;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(14, 63);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(71, 12);
            this.label6.TabIndex = 4;
            this.label6.Text = "User Name：";
            // 
            // tb_password
            // 
            this.tb_password.BackColor = System.Drawing.Color.White;
            this.tb_password.Location = new System.Drawing.Point(103, 96);
            this.tb_password.Name = "tb_password";
            this.tb_password.PasswordChar = '*';
            this.tb_password.Size = new System.Drawing.Size(279, 21);
            this.tb_password.TabIndex = 3;
            this.tb_password.UseSystemPasswordChar = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(14, 100);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(65, 12);
            this.label7.TabIndex = 2;
            this.label7.Text = "Password：";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(14, 26);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(53, 12);
            this.label8.TabIndex = 0;
            this.label8.Text = "Method：";
            // 
            // tabPage3
            // 
            this.tabPage3.Location = new System.Drawing.Point(22, 4);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(453, 378);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "tab_setting";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.groupBox4);
            this.tabPage4.Controls.Add(this.groupBox3);
            this.tabPage4.Location = new System.Drawing.Point(22, 4);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Size = new System.Drawing.Size(453, 378);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "tab_app";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.cb_fontSize);
            this.groupBox4.Controls.Add(this.cb_fontName);
            this.groupBox4.Controls.Add(this.btn_edit_theme);
            this.groupBox4.Controls.Add(this.cb_scheme);
            this.groupBox4.Controls.Add(this.label11);
            this.groupBox4.Controls.Add(this.label12);
            this.groupBox4.Controls.Add(this.label13);
            this.groupBox4.Location = new System.Drawing.Point(20, 113);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(422, 140);
            this.groupBox4.TabIndex = 3;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Color and Font";
            // 
            // cb_fontSize
            // 
            this.cb_fontSize.DisplayMember = "SSH";
            this.cb_fontSize.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_fontSize.FormattingEnabled = true;
            this.cb_fontSize.Items.AddRange(new object[] {
            "9",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17",
            "18",
            "19",
            "20",
            "22",
            "24",
            "26",
            "28",
            "30",
            "32",
            "36",
            "40"});
            this.cb_fontSize.Location = new System.Drawing.Point(103, 97);
            this.cb_fontSize.Name = "cb_fontSize";
            this.cb_fontSize.Size = new System.Drawing.Size(87, 20);
            this.cb_fontSize.TabIndex = 10;
            // 
            // cb_fontName
            // 
            this.cb_fontName.DisplayMember = "SSH";
            this.cb_fontName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_fontName.FormattingEnabled = true;
            this.cb_fontName.Items.AddRange(new object[] {
            "Courier New"});
            this.cb_fontName.Location = new System.Drawing.Point(103, 59);
            this.cb_fontName.Name = "cb_fontName";
            this.cb_fontName.Size = new System.Drawing.Size(219, 20);
            this.cb_fontName.TabIndex = 8;
            // 
            // btn_edit_theme
            // 
            this.btn_edit_theme.Location = new System.Drawing.Point(331, 20);
            this.btn_edit_theme.Name = "btn_edit_theme";
            this.btn_edit_theme.Size = new System.Drawing.Size(84, 23);
            this.btn_edit_theme.TabIndex = 7;
            this.btn_edit_theme.Text = "Edit Scheme";
            this.btn_edit_theme.UseVisualStyleBackColor = true;
            // 
            // cb_scheme
            // 
            this.cb_scheme.DisplayMember = "SSH";
            this.cb_scheme.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_scheme.FormattingEnabled = true;
            this.cb_scheme.Items.AddRange(new object[] {
            "Default Scheme"});
            this.cb_scheme.Location = new System.Drawing.Point(103, 21);
            this.cb_scheme.Name = "cb_scheme";
            this.cb_scheme.Size = new System.Drawing.Size(219, 20);
            this.cb_scheme.TabIndex = 6;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(14, 62);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(71, 12);
            this.label11.TabIndex = 4;
            this.label11.Text = "Font Name：";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(14, 99);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(71, 12);
            this.label12.TabIndex = 2;
            this.label12.Text = "Font Size：";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(14, 25);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(89, 12);
            this.label13.TabIndex = 0;
            this.label13.Text = "Color Scheme：";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.rtb_preview);
            this.groupBox3.Location = new System.Drawing.Point(20, 12);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(422, 93);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Preview";
            // 
            // rtb_preview
            // 
            this.rtb_preview.Enabled = false;
            this.rtb_preview.Location = new System.Drawing.Point(6, 19);
            this.rtb_preview.Name = "rtb_preview";
            this.rtb_preview.Size = new System.Drawing.Size(410, 67);
            this.rtb_preview.TabIndex = 0;
            this.rtb_preview.Text = "";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Location = new System.Drawing.Point(203, 42);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(12, 384);
            this.panel1.TabIndex = 3;
            // 
            // btn_Ok
            // 
            this.btn_Ok.Location = new System.Drawing.Point(492, 437);
            this.btn_Ok.Name = "btn_Ok";
            this.btn_Ok.Size = new System.Drawing.Size(75, 25);
            this.btn_Ok.TabIndex = 4;
            this.btn_Ok.Text = "Ok";
            this.btn_Ok.UseVisualStyleBackColor = true;
            this.btn_Ok.Click += new System.EventHandler(this.btn_Ok_Click);
            // 
            // btn_Cancel
            // 
            this.btn_Cancel.Location = new System.Drawing.Point(576, 437);
            this.btn_Cancel.Name = "btn_Cancel";
            this.btn_Cancel.Size = new System.Drawing.Size(75, 25);
            this.btn_Cancel.TabIndex = 5;
            this.btn_Cancel.Text = "Cancel";
            this.btn_Cancel.UseVisualStyleBackColor = true;
            this.btn_Cancel.Click += new System.EventHandler(this.btn_Cancel_Click);
            // 
            // SshSettingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::AppMonitor.Properties.Resources.skin_12;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.CaptionFont = new System.Drawing.Font("微软雅黑", 9F);
            this.ClientSize = new System.Drawing.Size(671, 482);
            this.Controls.Add(this.btn_Cancel);
            this.Controls.Add(this.btn_Ok);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.treeView1);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(671, 482);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(671, 482);
            this.Name = "SshSettingForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "New Session Properties";
            this.TitleCenter = false;
            this.TitleColor = System.Drawing.Color.White;
            this.Load += new System.EventHandler(this.SshSettingForm_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nud_port)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.tabPage4.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btn_Ok;
        private System.Windows.Forms.Button btn_Cancel;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tb_name;
        private System.Windows.Forms.TextBox tb_host;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cb_protocol;
        private System.Windows.Forms.NumericUpDown nud_port;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox cb_method;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tb_password;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox tb_userName;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.CheckBox cb_remenber_pwd;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.ComboBox cb_scheme;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btn_edit_theme;
        private System.Windows.Forms.ComboBox cb_fontSize;
        private System.Windows.Forms.ComboBox cb_fontName;
        private System.Windows.Forms.RichTextBox rtb_preview;
    }
}