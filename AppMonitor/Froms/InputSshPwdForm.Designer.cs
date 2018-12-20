namespace AppMonitor.Froms
{
    partial class InputSshPwdForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InputSshPwdForm));
            this.password = new CCWin.SkinControl.SkinTextBox();
            this.label_name = new CCWin.SkinControl.SkinLabel();
            this.cb_remenber = new CCWin.SkinControl.SkinCheckBox();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // password
            // 
            this.password.BackColor = System.Drawing.Color.Transparent;
            this.password.DownBack = null;
            this.password.Icon = null;
            this.password.IconIsButton = false;
            this.password.IconMouseState = CCWin.SkinClass.ControlState.Normal;
            this.password.IsPasswordChat = '●';
            this.password.IsSystemPasswordChar = true;
            this.password.Lines = new string[0];
            this.password.Location = new System.Drawing.Point(137, 47);
            this.password.Margin = new System.Windows.Forms.Padding(0);
            this.password.MaxLength = 32767;
            this.password.MinimumSize = new System.Drawing.Size(28, 28);
            this.password.MouseBack = null;
            this.password.MouseState = CCWin.SkinClass.ControlState.Normal;
            this.password.Multiline = false;
            this.password.Name = "password";
            this.password.NormlBack = null;
            this.password.Padding = new System.Windows.Forms.Padding(5);
            this.password.ReadOnly = false;
            this.password.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.password.Size = new System.Drawing.Size(284, 28);
            // 
            // 
            // 
            this.password.SkinTxt.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.password.SkinTxt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.password.SkinTxt.Font = new System.Drawing.Font("微软雅黑", 9.75F);
            this.password.SkinTxt.Location = new System.Drawing.Point(5, 5);
            this.password.SkinTxt.Name = "BaseText";
            this.password.SkinTxt.PasswordChar = '●';
            this.password.SkinTxt.Size = new System.Drawing.Size(274, 18);
            this.password.SkinTxt.TabIndex = 0;
            this.password.SkinTxt.UseSystemPasswordChar = true;
            this.password.SkinTxt.WaterColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(127)))), ((int)(((byte)(127)))));
            this.password.SkinTxt.WaterText = "请输入密码";
            this.password.TabIndex = 0;
            this.password.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.password.WaterColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(127)))), ((int)(((byte)(127)))));
            this.password.WaterText = "请输入密码";
            this.password.WordWrap = true;
            // 
            // label_name
            // 
            this.label_name.BackColor = System.Drawing.SystemColors.Control;
            this.label_name.BorderColor = System.Drawing.Color.White;
            this.label_name.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label_name.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label_name.Location = new System.Drawing.Point(18, 51);
            this.label_name.Name = "label_name";
            this.label_name.Size = new System.Drawing.Size(116, 23);
            this.label_name.TabIndex = 1;
            this.label_name.Text = "xx的密码：";
            this.label_name.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cb_remenber
            // 
            this.cb_remenber.AutoSize = true;
            this.cb_remenber.BackColor = System.Drawing.Color.Transparent;
            this.cb_remenber.Checked = true;
            this.cb_remenber.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cb_remenber.ControlState = CCWin.SkinClass.ControlState.Normal;
            this.cb_remenber.DownBack = null;
            this.cb_remenber.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cb_remenber.Location = new System.Drawing.Point(29, 97);
            this.cb_remenber.MouseBack = null;
            this.cb_remenber.Name = "cb_remenber";
            this.cb_remenber.NormlBack = null;
            this.cb_remenber.SelectedDownBack = null;
            this.cb_remenber.SelectedMouseBack = null;
            this.cb_remenber.SelectedNormlBack = null;
            this.cb_remenber.Size = new System.Drawing.Size(75, 21);
            this.cb_remenber.TabIndex = 2;
            this.cb_remenber.Text = "记住密码";
            this.cb_remenber.UseVisualStyleBackColor = false;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(346, 94);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 28);
            this.button1.TabIndex = 3;
            this.button1.Text = "确定";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // InputSshPwdForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::AppMonitor.Properties.Resources.skin_12;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.CaptionFont = new System.Drawing.Font("微软雅黑", 9F);
            this.ClientSize = new System.Drawing.Size(440, 140);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.cb_remenber);
            this.Controls.Add(this.label_name);
            this.Controls.Add(this.password);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(440, 140);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(440, 140);
            this.Name = "InputSshPwdForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "InputSshPwdForm";
            this.TitleCenter = false;
            this.TitleColor = System.Drawing.Color.White;
            this.Load += new System.EventHandler(this.InputSshPwdForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CCWin.SkinControl.SkinTextBox password;
        private CCWin.SkinControl.SkinLabel label_name;
        private CCWin.SkinControl.SkinCheckBox cb_remenber;
        private System.Windows.Forms.Button button1;
    }
}