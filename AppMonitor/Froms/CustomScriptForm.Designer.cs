namespace AppMonitor.Froms
{
    partial class CustomScriptForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CustomScriptForm));
            this.stb_shell = new CCWin.SkinControl.SkinTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cb_cr = new System.Windows.Forms.CheckBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.label_info = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // stb_shell
            // 
            this.stb_shell.BackColor = System.Drawing.Color.Transparent;
            this.stb_shell.DownBack = null;
            this.stb_shell.Icon = null;
            this.stb_shell.IconIsButton = false;
            this.stb_shell.IconMouseState = CCWin.SkinClass.ControlState.Normal;
            this.stb_shell.IsPasswordChat = '\0';
            this.stb_shell.IsSystemPasswordChar = false;
            this.stb_shell.Lines = new string[0];
            this.stb_shell.Location = new System.Drawing.Point(20, 72);
            this.stb_shell.Margin = new System.Windows.Forms.Padding(0);
            this.stb_shell.MaxLength = 32767;
            this.stb_shell.MinimumSize = new System.Drawing.Size(28, 28);
            this.stb_shell.MouseBack = null;
            this.stb_shell.MouseState = CCWin.SkinClass.ControlState.Normal;
            this.stb_shell.Multiline = false;
            this.stb_shell.Name = "stb_shell";
            this.stb_shell.NormlBack = null;
            this.stb_shell.Padding = new System.Windows.Forms.Padding(5);
            this.stb_shell.ReadOnly = false;
            this.stb_shell.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.stb_shell.Size = new System.Drawing.Size(513, 28);
            // 
            // 
            // 
            this.stb_shell.SkinTxt.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.stb_shell.SkinTxt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.stb_shell.SkinTxt.Font = new System.Drawing.Font("微软雅黑", 9.75F);
            this.stb_shell.SkinTxt.Location = new System.Drawing.Point(5, 5);
            this.stb_shell.SkinTxt.Name = "BaseText";
            this.stb_shell.SkinTxt.Size = new System.Drawing.Size(503, 18);
            this.stb_shell.SkinTxt.TabIndex = 0;
            this.stb_shell.SkinTxt.WaterColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(127)))), ((int)(((byte)(127)))));
            this.stb_shell.SkinTxt.WaterText = "请输入Shell脚本命令";
            this.stb_shell.TabIndex = 0;
            this.stb_shell.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.stb_shell.WaterColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(127)))), ((int)(((byte)(127)))));
            this.stb_shell.WaterText = "请输入Shell脚本命令";
            this.stb_shell.WordWrap = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("宋体", 10F);
            this.label1.Location = new System.Drawing.Point(18, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 14);
            this.label1.TabIndex = 1;
            this.label1.Text = "Shell：";
            // 
            // cb_cr
            // 
            this.cb_cr.AutoSize = true;
            this.cb_cr.BackColor = System.Drawing.Color.Transparent;
            this.cb_cr.Location = new System.Drawing.Point(21, 114);
            this.cb_cr.Name = "cb_cr";
            this.cb_cr.Size = new System.Drawing.Size(78, 16);
            this.cb_cr.TabIndex = 2;
            this.cb_cr.Text = "Append CR";
            this.cb_cr.UseVisualStyleBackColor = false;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(366, 176);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 25);
            this.button1.TabIndex = 3;
            this.button1.Text = "保存";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(458, 176);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 25);
            this.button2.TabIndex = 4;
            this.button2.Text = "取消";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label_info
            // 
            this.label_info.BackColor = System.Drawing.Color.Transparent;
            this.label_info.Font = new System.Drawing.Font("宋体", 10F);
            this.label_info.ForeColor = System.Drawing.Color.Red;
            this.label_info.Location = new System.Drawing.Point(94, 137);
            this.label_info.Name = "label_info";
            this.label_info.Size = new System.Drawing.Size(393, 22);
            this.label_info.TabIndex = 5;
            this.label_info.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // CustomScriptForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::AppMonitor.Properties.Resources.skin_12;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.CaptionFont = new System.Drawing.Font("微软雅黑", 9F);
            this.ClientSize = new System.Drawing.Size(554, 222);
            this.Controls.Add(this.label_info);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.cb_cr);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.stb_shell);
            this.HelpButton = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(554, 222);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(554, 222);
            this.Name = "CustomScriptForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Custom Quick Command";
            this.TitleCenter = false;
            this.TitleColor = System.Drawing.Color.White;
            this.Load += new System.EventHandler(this.CustomScriptForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CCWin.SkinControl.SkinTextBox stb_shell;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox cb_cr;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label_info;
    }
}