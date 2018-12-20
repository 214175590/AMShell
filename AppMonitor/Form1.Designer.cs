namespace AppMonitor
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.tb_acc = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tb_pwd = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.tb_shell = new System.Windows.Forms.TextBox();
            this.run = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.tb_host = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.rtb_log = new System.Windows.Forms.RichTextBox();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tb_acc
            // 
            this.tb_acc.Location = new System.Drawing.Point(258, 15);
            this.tb_acc.Name = "tb_acc";
            this.tb_acc.Size = new System.Drawing.Size(107, 21);
            this.tb_acc.TabIndex = 0;
            this.tb_acc.Text = "gxb";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(211, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "用户名";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(384, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "密码";
            // 
            // tb_pwd
            // 
            this.tb_pwd.Location = new System.Drawing.Point(421, 17);
            this.tb_pwd.Name = "tb_pwd";
            this.tb_pwd.Size = new System.Drawing.Size(158, 21);
            this.tb_pwd.TabIndex = 2;
            this.tb_pwd.Text = "Echinac2p.com12#$";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(601, 16);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 4;
            this.button1.Text = "登录";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // tb_shell
            // 
            this.tb_shell.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tb_shell.Location = new System.Drawing.Point(12, 48);
            this.tb_shell.Name = "tb_shell";
            this.tb_shell.Size = new System.Drawing.Size(817, 21);
            this.tb_shell.TabIndex = 6;
            this.tb_shell.KeyUp += new System.Windows.Forms.KeyEventHandler(this.tb_shell_KeyUp);
            // 
            // run
            // 
            this.run.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.run.Location = new System.Drawing.Point(835, 47);
            this.run.Name = "run";
            this.run.Size = new System.Drawing.Size(44, 23);
            this.run.TabIndex = 7;
            this.run.Text = "run";
            this.run.UseVisualStyleBackColor = true;
            this.run.Click += new System.EventHandler(this.run_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(20, 17);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 12);
            this.label3.TabIndex = 9;
            this.label3.Text = "主机";
            // 
            // tb_host
            // 
            this.tb_host.Location = new System.Drawing.Point(61, 13);
            this.tb_host.Name = "tb_host";
            this.tb_host.Size = new System.Drawing.Size(130, 21);
            this.tb_host.TabIndex = 8;
            this.tb_host.Text = "192.168.20.106";
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.rtb_log);
            this.panel1.Location = new System.Drawing.Point(12, 75);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(867, 483);
            this.panel1.TabIndex = 10;
            // 
            // rtb_log
            // 
            this.rtb_log.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.rtb_log.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rtb_log.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtb_log.Font = new System.Drawing.Font("Courier New", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtb_log.ForeColor = System.Drawing.Color.CadetBlue;
            this.rtb_log.Location = new System.Drawing.Point(0, 0);
            this.rtb_log.Name = "rtb_log";
            this.rtb_log.ReadOnly = true;
            this.rtb_log.Size = new System.Drawing.Size(867, 483);
            this.rtb_log.TabIndex = 0;
            this.rtb_log.Text = "";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(891, 570);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tb_host);
            this.Controls.Add(this.run);
            this.Controls.Add(this.tb_shell);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tb_pwd);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tb_acc);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "简易Shell";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tb_acc;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tb_pwd;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox tb_shell;
        private System.Windows.Forms.Button run;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tb_host;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RichTextBox rtb_log;
    }
}

