namespace AppMonitor.Froms
{
    partial class InputForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InputForm));
            this.input = new CCWin.SkinControl.SkinTextBox();
            this.btn_sure = new System.Windows.Forms.Button();
            this.btn_cancel = new System.Windows.Forms.Button();
            this.info = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // input
            // 
            this.input.BackColor = System.Drawing.Color.Transparent;
            this.input.DownBack = null;
            this.input.Icon = null;
            this.input.IconIsButton = false;
            this.input.IconMouseState = CCWin.SkinClass.ControlState.Normal;
            this.input.IsPasswordChat = '\0';
            this.input.IsSystemPasswordChar = false;
            this.input.Lines = new string[0];
            this.input.Location = new System.Drawing.Point(18, 97);
            this.input.Margin = new System.Windows.Forms.Padding(0);
            this.input.MaxLength = 32767;
            this.input.MinimumSize = new System.Drawing.Size(28, 28);
            this.input.MouseBack = null;
            this.input.MouseState = CCWin.SkinClass.ControlState.Normal;
            this.input.Multiline = false;
            this.input.Name = "input";
            this.input.NormlBack = null;
            this.input.Padding = new System.Windows.Forms.Padding(5);
            this.input.ReadOnly = false;
            this.input.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.input.Size = new System.Drawing.Size(415, 28);
            // 
            // 
            // 
            this.input.SkinTxt.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.input.SkinTxt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.input.SkinTxt.Font = new System.Drawing.Font("微软雅黑", 9.75F);
            this.input.SkinTxt.Location = new System.Drawing.Point(5, 5);
            this.input.SkinTxt.Name = "BaseText";
            this.input.SkinTxt.Size = new System.Drawing.Size(405, 18);
            this.input.SkinTxt.TabIndex = 0;
            this.input.SkinTxt.WaterColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(127)))), ((int)(((byte)(127)))));
            this.input.SkinTxt.WaterText = "";
            this.input.TabIndex = 0;
            this.input.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.input.WaterColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(127)))), ((int)(((byte)(127)))));
            this.input.WaterText = "";
            this.input.WordWrap = true;
            // 
            // btn_sure
            // 
            this.btn_sure.Location = new System.Drawing.Point(373, 33);
            this.btn_sure.Name = "btn_sure";
            this.btn_sure.Size = new System.Drawing.Size(60, 25);
            this.btn_sure.TabIndex = 1;
            this.btn_sure.Text = "确定";
            this.btn_sure.UseVisualStyleBackColor = true;
            this.btn_sure.Click += new System.EventHandler(this.btn_sure_Click);
            // 
            // btn_cancel
            // 
            this.btn_cancel.Location = new System.Drawing.Point(373, 62);
            this.btn_cancel.Name = "btn_cancel";
            this.btn_cancel.Size = new System.Drawing.Size(60, 25);
            this.btn_cancel.TabIndex = 2;
            this.btn_cancel.Text = "取消";
            this.btn_cancel.UseVisualStyleBackColor = true;
            this.btn_cancel.Click += new System.EventHandler(this.btn_cancel_Click);
            // 
            // info
            // 
            this.info.Location = new System.Drawing.Point(21, 37);
            this.info.Name = "info";
            this.info.Size = new System.Drawing.Size(328, 50);
            this.info.TabIndex = 3;
            // 
            // InputForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.BackgroundImage = global::AppMonitor.Properties.Resources.skin_12;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.CaptionFont = new System.Drawing.Font("微软雅黑", 9F);
            this.ClientSize = new System.Drawing.Size(451, 142);
            this.Controls.Add(this.info);
            this.Controls.Add(this.btn_cancel);
            this.Controls.Add(this.btn_sure);
            this.Controls.Add(this.input);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(451, 142);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(451, 142);
            this.Name = "InputForm";
            this.Text = "请输入";
            this.TitleCenter = false;
            this.TitleColor = System.Drawing.Color.White;
            this.Load += new System.EventHandler(this.InputForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private CCWin.SkinControl.SkinTextBox input;
        private System.Windows.Forms.Button btn_sure;
        private System.Windows.Forms.Button btn_cancel;
        private System.Windows.Forms.Label info;
    }
}