﻿namespace AppMonitor.Plugin
{
    partial class CustomShellForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CustomShellForm));
            this.stb_name = new CCWin.SkinControl.SkinTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.cmd = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // stb_name
            // 
            this.stb_name.BackColor = System.Drawing.Color.Transparent;
            this.stb_name.DownBack = null;
            this.stb_name.Icon = null;
            this.stb_name.IconIsButton = false;
            this.stb_name.IconMouseState = CCWin.SkinClass.ControlState.Normal;
            this.stb_name.IsPasswordChat = '\0';
            this.stb_name.IsSystemPasswordChar = false;
            this.stb_name.Lines = new string[0];
            this.stb_name.Location = new System.Drawing.Point(109, 33);
            this.stb_name.Margin = new System.Windows.Forms.Padding(0);
            this.stb_name.MaxLength = 32767;
            this.stb_name.MinimumSize = new System.Drawing.Size(28, 28);
            this.stb_name.MouseBack = null;
            this.stb_name.MouseState = CCWin.SkinClass.ControlState.Normal;
            this.stb_name.Multiline = false;
            this.stb_name.Name = "stb_name";
            this.stb_name.NormlBack = null;
            this.stb_name.Padding = new System.Windows.Forms.Padding(5);
            this.stb_name.ReadOnly = false;
            this.stb_name.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.stb_name.Size = new System.Drawing.Size(352, 28);
            // 
            // 
            // 
            this.stb_name.SkinTxt.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.stb_name.SkinTxt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.stb_name.SkinTxt.Font = new System.Drawing.Font("微软雅黑", 9.75F);
            this.stb_name.SkinTxt.Location = new System.Drawing.Point(5, 5);
            this.stb_name.SkinTxt.Name = "BaseText";
            this.stb_name.SkinTxt.Size = new System.Drawing.Size(342, 18);
            this.stb_name.SkinTxt.TabIndex = 0;
            this.stb_name.SkinTxt.WaterColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(127)))), ((int)(((byte)(127)))));
            this.stb_name.SkinTxt.WaterText = "命令名称";
            this.stb_name.TabIndex = 6;
            this.stb_name.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.stb_name.WaterColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(127)))), ((int)(((byte)(127)))));
            this.stb_name.WaterText = "命令名称";
            this.stb_name.WordWrap = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label1.Location = new System.Drawing.Point(13, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 20);
            this.label1.TabIndex = 7;
            this.label1.Text = "自定义名称：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label3.Location = new System.Drawing.Point(26, 71);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 20);
            this.label3.TabIndex = 10;
            this.label3.Text = "执行命令：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.label4.ForeColor = System.Drawing.Color.LightSalmon;
            this.label4.Location = new System.Drawing.Point(105, 72);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(177, 20);
            this.label4.TabIndex = 11;
            this.label4.Text = "每条命令一行，按顺序执行";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(300, 352);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 12;
            this.button1.Text = "保存";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(386, 352);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 13;
            this.button2.Text = "关闭";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // cmd
            // 
            this.cmd.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.cmd.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.cmd.Location = new System.Drawing.Point(17, 104);
            this.cmd.Multiline = true;
            this.cmd.Name = "cmd";
            this.cmd.Size = new System.Drawing.Size(444, 237);
            this.cmd.TabIndex = 14;
            // 
            // CustomShellForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::AppMonitor.Properties.Resources.skin_12;
            this.CaptionFont = new System.Drawing.Font("微软雅黑", 9F);
            this.ClientSize = new System.Drawing.Size(475, 390);
            this.Controls.Add(this.cmd);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.stb_name);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(475, 390);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(475, 390);
            this.Name = "CustomShellForm";
            this.Text = "自定义脚本";
            this.TitleCenter = false;
            this.TitleColor = System.Drawing.Color.White;
            this.Load += new System.EventHandler(this.CustomScriptForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CCWin.SkinControl.SkinTextBox stb_name;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox cmd;
    }
}