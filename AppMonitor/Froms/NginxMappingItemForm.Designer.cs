namespace AppMonitor.Froms
{
    partial class NginxMappingItemForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NginxMappingItemForm));
            this.stb_url = new CCWin.SkinControl.SkinTextBox();
            this.stb_host = new CCWin.SkinControl.SkinTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cb_check = new System.Windows.Forms.CheckBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // stb_url
            // 
            this.stb_url.BackColor = System.Drawing.Color.Transparent;
            this.stb_url.DownBack = null;
            this.stb_url.Icon = null;
            this.stb_url.IconIsButton = false;
            this.stb_url.IconMouseState = CCWin.SkinClass.ControlState.Normal;
            this.stb_url.IsPasswordChat = '\0';
            this.stb_url.IsSystemPasswordChar = false;
            this.stb_url.Lines = new string[0];
            this.stb_url.Location = new System.Drawing.Point(126, 48);
            this.stb_url.Margin = new System.Windows.Forms.Padding(0);
            this.stb_url.MaxLength = 32767;
            this.stb_url.MinimumSize = new System.Drawing.Size(28, 28);
            this.stb_url.MouseBack = null;
            this.stb_url.MouseState = CCWin.SkinClass.ControlState.Normal;
            this.stb_url.Multiline = false;
            this.stb_url.Name = "stb_url";
            this.stb_url.NormlBack = null;
            this.stb_url.Padding = new System.Windows.Forms.Padding(5);
            this.stb_url.ReadOnly = false;
            this.stb_url.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.stb_url.Size = new System.Drawing.Size(326, 28);
            // 
            // 
            // 
            this.stb_url.SkinTxt.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.stb_url.SkinTxt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.stb_url.SkinTxt.Font = new System.Drawing.Font("微软雅黑", 9.75F);
            this.stb_url.SkinTxt.Location = new System.Drawing.Point(5, 5);
            this.stb_url.SkinTxt.Name = "BaseText";
            this.stb_url.SkinTxt.Size = new System.Drawing.Size(316, 18);
            this.stb_url.SkinTxt.TabIndex = 0;
            this.stb_url.SkinTxt.WaterColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(127)))), ((int)(((byte)(127)))));
            this.stb_url.SkinTxt.WaterText = "项目访问的地址，为Nginx服务器的地址";
            this.stb_url.TabIndex = 0;
            this.stb_url.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.stb_url.WaterColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(127)))), ((int)(((byte)(127)))));
            this.stb_url.WaterText = "项目访问的地址，为Nginx服务器的地址";
            this.stb_url.WordWrap = true;
            // 
            // stb_host
            // 
            this.stb_host.BackColor = System.Drawing.Color.Transparent;
            this.stb_host.DownBack = null;
            this.stb_host.Icon = null;
            this.stb_host.IconIsButton = false;
            this.stb_host.IconMouseState = CCWin.SkinClass.ControlState.Normal;
            this.stb_host.IsPasswordChat = '\0';
            this.stb_host.IsSystemPasswordChar = false;
            this.stb_host.Lines = new string[0];
            this.stb_host.Location = new System.Drawing.Point(126, 103);
            this.stb_host.Margin = new System.Windows.Forms.Padding(0);
            this.stb_host.MaxLength = 32767;
            this.stb_host.MinimumSize = new System.Drawing.Size(28, 28);
            this.stb_host.MouseBack = null;
            this.stb_host.MouseState = CCWin.SkinClass.ControlState.Normal;
            this.stb_host.Multiline = false;
            this.stb_host.Name = "stb_host";
            this.stb_host.NormlBack = null;
            this.stb_host.Padding = new System.Windows.Forms.Padding(5);
            this.stb_host.ReadOnly = false;
            this.stb_host.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.stb_host.Size = new System.Drawing.Size(326, 28);
            // 
            // 
            // 
            this.stb_host.SkinTxt.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.stb_host.SkinTxt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.stb_host.SkinTxt.Font = new System.Drawing.Font("微软雅黑", 9.75F);
            this.stb_host.SkinTxt.Location = new System.Drawing.Point(5, 5);
            this.stb_host.SkinTxt.Name = "BaseText";
            this.stb_host.SkinTxt.Size = new System.Drawing.Size(316, 18);
            this.stb_host.SkinTxt.TabIndex = 0;
            this.stb_host.SkinTxt.WaterColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(127)))), ((int)(((byte)(127)))));
            this.stb_host.SkinTxt.WaterText = "项目实际的地址，为Nginx反向代理的地址";
            this.stb_host.TabIndex = 1;
            this.stb_host.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.stb_host.WaterColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(127)))), ((int)(((byte)(127)))));
            this.stb_host.WaterText = "项目实际的地址，为Nginx反向代理的地址";
            this.stb_host.WordWrap = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label1.Location = new System.Drawing.Point(44, 51);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 19);
            this.label1.TabIndex = 2;
            this.label1.Text = "访问地址：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label2.Location = new System.Drawing.Point(44, 106);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 19);
            this.label2.TabIndex = 3;
            this.label2.Text = "实际地址：";
            // 
            // cb_check
            // 
            this.cb_check.AutoSize = true;
            this.cb_check.BackColor = System.Drawing.Color.Transparent;
            this.cb_check.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.cb_check.Location = new System.Drawing.Point(126, 157);
            this.cb_check.Name = "cb_check";
            this.cb_check.Size = new System.Drawing.Size(132, 16);
            this.cb_check.TabIndex = 4;
            this.cb_check.Text = "是否检测可访问状态";
            this.cb_check.UseVisualStyleBackColor = false;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(330, 205);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(68, 25);
            this.button1.TabIndex = 5;
            this.button1.Text = "保存";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(418, 205);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(68, 25);
            this.button2.TabIndex = 6;
            this.button2.Text = "取消";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // NginxMappingItemForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::AppMonitor.Properties.Resources.skin_12;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.CaptionFont = new System.Drawing.Font("微软雅黑", 9F);
            this.ClientSize = new System.Drawing.Size(510, 250);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.cb_check);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.stb_host);
            this.Controls.Add(this.stb_url);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(510, 250);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(510, 250);
            this.Name = "NginxMappingItemForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Nginx Mapping Item";
            this.TitleCenter = false;
            this.TitleColor = System.Drawing.Color.White;
            this.Load += new System.EventHandler(this.NginxMappingItemForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CCWin.SkinControl.SkinTextBox stb_url;
        private CCWin.SkinControl.SkinTextBox stb_host;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox cb_check;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
    }
}