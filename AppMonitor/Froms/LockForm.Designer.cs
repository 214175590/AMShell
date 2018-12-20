namespace AppMonitor.Froms
{
    partial class LockForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LockForm));
            this.stb_pwd = new CCWin.SkinControl.SkinTextBox();
            this.info = new CCWin.SkinControl.SkinLabel();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // stb_pwd
            // 
            this.stb_pwd.BackColor = System.Drawing.Color.Transparent;
            this.stb_pwd.DownBack = null;
            this.stb_pwd.Icon = null;
            this.stb_pwd.IconIsButton = false;
            this.stb_pwd.IconMouseState = CCWin.SkinClass.ControlState.Normal;
            this.stb_pwd.IsPasswordChat = '★';
            this.stb_pwd.IsSystemPasswordChar = false;
            this.stb_pwd.Lines = new string[0];
            this.stb_pwd.Location = new System.Drawing.Point(29, 75);
            this.stb_pwd.Margin = new System.Windows.Forms.Padding(0);
            this.stb_pwd.MaxLength = 32767;
            this.stb_pwd.MinimumSize = new System.Drawing.Size(28, 28);
            this.stb_pwd.MouseBack = null;
            this.stb_pwd.MouseState = CCWin.SkinClass.ControlState.Normal;
            this.stb_pwd.Multiline = false;
            this.stb_pwd.Name = "stb_pwd";
            this.stb_pwd.NormlBack = null;
            this.stb_pwd.Padding = new System.Windows.Forms.Padding(5);
            this.stb_pwd.ReadOnly = false;
            this.stb_pwd.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.stb_pwd.Size = new System.Drawing.Size(320, 28);
            // 
            // 
            // 
            this.stb_pwd.SkinTxt.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.stb_pwd.SkinTxt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.stb_pwd.SkinTxt.Font = new System.Drawing.Font("微软雅黑", 9.75F);
            this.stb_pwd.SkinTxt.Location = new System.Drawing.Point(5, 5);
            this.stb_pwd.SkinTxt.Name = "BaseText";
            this.stb_pwd.SkinTxt.PasswordChar = '★';
            this.stb_pwd.SkinTxt.Size = new System.Drawing.Size(310, 18);
            this.stb_pwd.SkinTxt.TabIndex = 0;
            this.stb_pwd.SkinTxt.WaterColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(127)))), ((int)(((byte)(127)))));
            this.stb_pwd.SkinTxt.WaterText = "请输入解锁密码，只用于本次解锁";
            this.stb_pwd.TabIndex = 0;
            this.stb_pwd.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.stb_pwd.WaterColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(127)))), ((int)(((byte)(127)))));
            this.stb_pwd.WaterText = "请输入解锁密码，只用于本次解锁";
            this.stb_pwd.WordWrap = true;
            // 
            // info
            // 
            this.info.AutoSize = true;
            this.info.BackColor = System.Drawing.Color.Transparent;
            this.info.BorderColor = System.Drawing.Color.White;
            this.info.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.info.Location = new System.Drawing.Point(29, 43);
            this.info.Name = "info";
            this.info.Size = new System.Drawing.Size(92, 17);
            this.info.TabIndex = 1;
            this.info.Text = "请输入解锁密码";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Transparent;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.ForeColor = System.Drawing.Color.Teal;
            this.button1.Location = new System.Drawing.Point(287, 132);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 26);
            this.button1.TabIndex = 2;
            this.button1.Text = "解锁";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Visible = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.Transparent;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.button2.Location = new System.Drawing.Point(197, 132);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 26);
            this.button2.TabIndex = 3;
            this.button2.Text = "退出软件";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Visible = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.Transparent;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.button3.Location = new System.Drawing.Point(197, 131);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 26);
            this.button3.TabIndex = 5;
            this.button3.Text = "取消";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.Color.Transparent;
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button4.ForeColor = System.Drawing.Color.Teal;
            this.button4.Location = new System.Drawing.Point(287, 131);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 26);
            this.button4.TabIndex = 4;
            this.button4.Text = "锁定";
            this.button4.UseVisualStyleBackColor = false;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // LockForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::AppMonitor.Properties.Resources.skin_12;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.CaptionFont = new System.Drawing.Font("微软雅黑", 9F);
            this.ClientSize = new System.Drawing.Size(379, 175);
            this.ControlBox = false;
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.info);
            this.Controls.Add(this.stb_pwd);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "LockForm";
            this.Text = "Lock";
            this.TitleCenter = false;
            this.TitleColor = System.Drawing.Color.White;
            this.Load += new System.EventHandler(this.LockForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CCWin.SkinControl.SkinTextBox stb_pwd;
        private CCWin.SkinControl.SkinLabel info;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
    }
}