namespace AppMonitor.Froms
{
    partial class SettingForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingForm));
            this.label1 = new System.Windows.Forms.Label();
            this.monitorTimer = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.listView1 = new System.Windows.Forms.ListView();
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.buttonSave = new System.Windows.Forms.Button();
            this.cb_showMenuBar = new System.Windows.Forms.CheckBox();
            this.cb_showStatusBar = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.monitorTimer)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(29, 49);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(116, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "项目监控间隔时间：";
            // 
            // monitorTimer
            // 
            this.monitorTimer.Location = new System.Drawing.Point(151, 46);
            this.monitorTimer.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.monitorTimer.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.monitorTimer.Name = "monitorTimer";
            this.monitorTimer.Size = new System.Drawing.Size(94, 23);
            this.monitorTimer.TabIndex = 1;
            this.monitorTimer.Value = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.monitorTimer.ValueChanged += new System.EventHandler(this.monitorTimer_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(251, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(20, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "秒";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Location = new System.Drawing.Point(101, 125);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 17);
            this.label3.TabIndex = 3;
            this.label3.Text = "皮肤：";
            // 
            // listView1
            // 
            this.listView1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listView1.CheckBoxes = true;
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader5});
            this.listView1.LargeImageList = this.imageList1;
            this.listView1.Location = new System.Drawing.Point(151, 121);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(605, 159);
            this.listView1.TabIndex = 5;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.SelectedIndexChanged += new System.EventHandler(this.listView1_SelectedIndexChanged);
            // 
            // columnHeader5
            // 
            this.columnHeader5.Width = 136;
            // 
            // imageList1
            // 
            this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageList1.ImageSize = new System.Drawing.Size(136, 80);
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(655, 455);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(101, 30);
            this.buttonSave.TabIndex = 6;
            this.buttonSave.Text = "Close";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // cb_showMenuBar
            // 
            this.cb_showMenuBar.AutoSize = true;
            this.cb_showMenuBar.BackColor = System.Drawing.Color.Transparent;
            this.cb_showMenuBar.Location = new System.Drawing.Point(152, 84);
            this.cb_showMenuBar.Name = "cb_showMenuBar";
            this.cb_showMenuBar.Size = new System.Drawing.Size(119, 21);
            this.cb_showMenuBar.TabIndex = 7;
            this.cb_showMenuBar.Text = "Show Menu Bar";
            this.cb_showMenuBar.UseVisualStyleBackColor = false;
            this.cb_showMenuBar.CheckedChanged += new System.EventHandler(this.cb_showMenuBar_CheckedChanged);
            // 
            // cb_showStatusBar
            // 
            this.cb_showStatusBar.AutoSize = true;
            this.cb_showStatusBar.BackColor = System.Drawing.Color.Transparent;
            this.cb_showStatusBar.Location = new System.Drawing.Point(304, 84);
            this.cb_showStatusBar.Name = "cb_showStatusBar";
            this.cb_showStatusBar.Size = new System.Drawing.Size(121, 21);
            this.cb_showStatusBar.TabIndex = 8;
            this.cb_showStatusBar.Text = "Show Status Bar";
            this.cb_showStatusBar.UseVisualStyleBackColor = false;
            this.cb_showStatusBar.CheckedChanged += new System.EventHandler(this.cb_showStatusBar_CheckedChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Location = new System.Drawing.Point(101, 87);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(44, 17);
            this.label4.TabIndex = 9;
            this.label4.Text = "组件：";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.label5.Location = new System.Drawing.Point(271, 49);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(76, 17);
            this.label5.TabIndex = 10;
            this.label5.Text = "(重启后生效)";
            // 
            // SettingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::AppMonitor.Properties.Resources.skin_12;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.CaptionFont = new System.Drawing.Font("微软雅黑", 9F);
            this.ClientSize = new System.Drawing.Size(779, 509);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cb_showStatusBar);
            this.Controls.Add(this.cb_showMenuBar);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.monitorTimer);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SettingForm";
            this.Text = "Setting";
            this.TitleCenter = false;
            this.TitleColor = System.Drawing.Color.White;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.SettingForm_FormClosed);
            this.Load += new System.EventHandler(this.SettingForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.monitorTimer)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown monitorTimer;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.CheckBox cb_showMenuBar;
        private System.Windows.Forms.CheckBox cb_showStatusBar;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
    }
}