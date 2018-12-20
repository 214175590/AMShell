namespace AppMonitor.Froms
{
    partial class FileAttrForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FileAttrForm));
            this.panel1 = new System.Windows.Forms.Panel();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.button1 = new System.Windows.Forms.Button();
            this.icon = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.text_type = new System.Windows.Forms.TextBox();
            this.text_host = new System.Windows.Forms.TextBox();
            this.text_location = new System.Windows.Forms.TextBox();
            this.text_size = new System.Windows.Forms.TextBox();
            this.text_modified = new System.Windows.Forms.TextBox();
            this.text_owner = new System.Windows.Forms.TextBox();
            this.text_group = new System.Windows.Forms.TextBox();
            this.text_permiss = new System.Windows.Forms.TextBox();
            this.text_name = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.icon)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Gainsboro;
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.tabControl1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(8, 30);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(431, 476);
            this.panel1.TabIndex = 0;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Location = new System.Drawing.Point(6, 10);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(422, 423);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.text_name);
            this.tabPage1.Controls.Add(this.text_permiss);
            this.tabPage1.Controls.Add(this.text_group);
            this.tabPage1.Controls.Add(this.text_owner);
            this.tabPage1.Controls.Add(this.text_modified);
            this.tabPage1.Controls.Add(this.text_size);
            this.tabPage1.Controls.Add(this.text_location);
            this.tabPage1.Controls.Add(this.text_host);
            this.tabPage1.Controls.Add(this.text_type);
            this.tabPage1.Controls.Add(this.label11);
            this.tabPage1.Controls.Add(this.label10);
            this.tabPage1.Controls.Add(this.label9);
            this.tabPage1.Controls.Add(this.label8);
            this.tabPage1.Controls.Add(this.label7);
            this.tabPage1.Controls.Add(this.label6);
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.icon);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(414, 397);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "General";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(350, 440);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 27);
            this.button1.TabIndex = 1;
            this.button1.Text = "确定";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // icon
            // 
            this.icon.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.icon.Location = new System.Drawing.Point(21, 18);
            this.icon.Name = "icon";
            this.icon.Size = new System.Drawing.Size(64, 64);
            this.icon.TabIndex = 0;
            this.icon.TabStop = false;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Silver;
            this.label2.Location = new System.Drawing.Point(17, 96);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(380, 1);
            this.label2.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.Silver;
            this.label3.Location = new System.Drawing.Point(17, 234);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(380, 1);
            this.label3.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(20, 111);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 12);
            this.label4.TabIndex = 4;
            this.label4.Text = "Type：";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(20, 141);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 12);
            this.label5.TabIndex = 5;
            this.label5.Text = "Host：";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(20, 171);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 12);
            this.label6.TabIndex = 6;
            this.label6.Text = "Location：";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(20, 201);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(41, 12);
            this.label7.TabIndex = 7;
            this.label7.Text = "Size：";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(20, 255);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(65, 12);
            this.label8.TabIndex = 8;
            this.label8.Text = "Modified：";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(20, 288);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(47, 12);
            this.label9.TabIndex = 9;
            this.label9.Text = "Owner：";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(20, 321);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(47, 12);
            this.label10.TabIndex = 10;
            this.label10.Text = "Group：";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(20, 354);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(83, 12);
            this.label11.TabIndex = 11;
            this.label11.Text = "Permissions：";
            // 
            // text_type
            // 
            this.text_type.BackColor = System.Drawing.Color.White;
            this.text_type.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.text_type.Location = new System.Drawing.Point(115, 111);
            this.text_type.Name = "text_type";
            this.text_type.ReadOnly = true;
            this.text_type.Size = new System.Drawing.Size(280, 14);
            this.text_type.TabIndex = 12;
            // 
            // text_host
            // 
            this.text_host.BackColor = System.Drawing.Color.White;
            this.text_host.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.text_host.Location = new System.Drawing.Point(115, 141);
            this.text_host.Name = "text_host";
            this.text_host.ReadOnly = true;
            this.text_host.Size = new System.Drawing.Size(280, 14);
            this.text_host.TabIndex = 13;
            // 
            // text_location
            // 
            this.text_location.BackColor = System.Drawing.Color.White;
            this.text_location.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.text_location.Location = new System.Drawing.Point(115, 171);
            this.text_location.Name = "text_location";
            this.text_location.ReadOnly = true;
            this.text_location.Size = new System.Drawing.Size(280, 14);
            this.text_location.TabIndex = 14;
            // 
            // text_size
            // 
            this.text_size.BackColor = System.Drawing.Color.White;
            this.text_size.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.text_size.Location = new System.Drawing.Point(115, 201);
            this.text_size.Name = "text_size";
            this.text_size.ReadOnly = true;
            this.text_size.Size = new System.Drawing.Size(280, 14);
            this.text_size.TabIndex = 15;
            // 
            // text_modified
            // 
            this.text_modified.BackColor = System.Drawing.Color.White;
            this.text_modified.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.text_modified.Location = new System.Drawing.Point(115, 256);
            this.text_modified.Name = "text_modified";
            this.text_modified.ReadOnly = true;
            this.text_modified.Size = new System.Drawing.Size(280, 14);
            this.text_modified.TabIndex = 16;
            // 
            // text_owner
            // 
            this.text_owner.BackColor = System.Drawing.Color.White;
            this.text_owner.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.text_owner.Location = new System.Drawing.Point(115, 289);
            this.text_owner.Name = "text_owner";
            this.text_owner.ReadOnly = true;
            this.text_owner.Size = new System.Drawing.Size(280, 14);
            this.text_owner.TabIndex = 17;
            // 
            // text_group
            // 
            this.text_group.BackColor = System.Drawing.Color.White;
            this.text_group.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.text_group.Location = new System.Drawing.Point(115, 322);
            this.text_group.Name = "text_group";
            this.text_group.ReadOnly = true;
            this.text_group.Size = new System.Drawing.Size(280, 14);
            this.text_group.TabIndex = 18;
            // 
            // text_permiss
            // 
            this.text_permiss.BackColor = System.Drawing.Color.White;
            this.text_permiss.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.text_permiss.Location = new System.Drawing.Point(115, 355);
            this.text_permiss.Name = "text_permiss";
            this.text_permiss.ReadOnly = true;
            this.text_permiss.Size = new System.Drawing.Size(280, 14);
            this.text_permiss.TabIndex = 19;
            // 
            // text_name
            // 
            this.text_name.BackColor = System.Drawing.Color.White;
            this.text_name.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.text_name.Location = new System.Drawing.Point(115, 39);
            this.text_name.Multiline = true;
            this.text_name.Name = "text_name";
            this.text_name.ReadOnly = true;
            this.text_name.Size = new System.Drawing.Size(280, 43);
            this.text_name.TabIndex = 20;
            // 
            // FileAttrForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::AppMonitor.Properties.Resources.skin_12;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.CaptionFont = new System.Drawing.Font("微软雅黑", 9F);
            this.ClientSize = new System.Drawing.Size(447, 514);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FileAttrForm";
            this.Text = "属性";
            this.TitleCenter = false;
            this.TitleColor = System.Drawing.Color.White;
            this.Load += new System.EventHandler(this.FileAttrForm_Load);
            this.panel1.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.icon)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.PictureBox icon;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox text_permiss;
        private System.Windows.Forms.TextBox text_group;
        private System.Windows.Forms.TextBox text_owner;
        private System.Windows.Forms.TextBox text_modified;
        private System.Windows.Forms.TextBox text_size;
        private System.Windows.Forms.TextBox text_location;
        private System.Windows.Forms.TextBox text_host;
        private System.Windows.Forms.TextBox text_type;
        private System.Windows.Forms.TextBox text_name;
    }
}