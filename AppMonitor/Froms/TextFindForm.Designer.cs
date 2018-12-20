namespace AppMonitor.Froms
{
    partial class TextFindForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TextFindForm));
            this.btn_replace = new System.Windows.Forms.Button();
            this.btn_find = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.text_target = new CCWin.SkinControl.SkinComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.text_res = new CCWin.SkinControl.SkinComboBox();
            this.btn_replace_all = new System.Windows.Forms.Button();
            this.btn_replace_find = new System.Windows.Forms.Button();
            this.btn_close = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cb_regex = new System.Windows.Forms.CheckBox();
            this.cb_immed = new System.Windows.Forms.CheckBox();
            this.cb_whole = new System.Windows.Forms.CheckBox();
            this.cb_case = new System.Windows.Forms.CheckBox();
            this.info = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_replace
            // 
            this.btn_replace.Location = new System.Drawing.Point(172, 360);
            this.btn_replace.Name = "btn_replace";
            this.btn_replace.Size = new System.Drawing.Size(100, 27);
            this.btn_replace.TabIndex = 11;
            this.btn_replace.Text = "Replace";
            this.btn_replace.UseVisualStyleBackColor = true;
            this.btn_replace.Click += new System.EventHandler(this.btn_replace_Click);
            // 
            // btn_find
            // 
            this.btn_find.Location = new System.Drawing.Point(172, 324);
            this.btn_find.Name = "btn_find";
            this.btn_find.Size = new System.Drawing.Size(100, 27);
            this.btn_find.TabIndex = 10;
            this.btn_find.Text = "Find";
            this.btn_find.UseVisualStyleBackColor = true;
            this.btn_find.Click += new System.EventHandler(this.find_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(15, 83);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 9;
            this.label2.Text = "替换：";
            // 
            // text_target
            // 
            this.text_target.BaseColor = System.Drawing.Color.Silver;
            this.text_target.BorderColor = System.Drawing.Color.Silver;
            this.text_target.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.text_target.FormattingEnabled = true;
            this.text_target.ItemBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.text_target.Location = new System.Drawing.Point(62, 78);
            this.text_target.MouseColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.text_target.MouseGradientColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.text_target.Name = "text_target";
            this.text_target.Size = new System.Drawing.Size(322, 22);
            this.text_target.TabIndex = 8;
            this.text_target.WaterText = "";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(15, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 7;
            this.label1.Text = "查找：";
            // 
            // text_res
            // 
            this.text_res.BaseColor = System.Drawing.Color.Silver;
            this.text_res.BorderColor = System.Drawing.Color.Silver;
            this.text_res.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.text_res.DropBackColor = System.Drawing.SystemColors.Control;
            this.text_res.FormattingEnabled = true;
            this.text_res.ItemBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.text_res.ItemHoverForeColor = System.Drawing.Color.Teal;
            this.text_res.Location = new System.Drawing.Point(62, 41);
            this.text_res.MouseColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.text_res.MouseGradientColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.text_res.Name = "text_res";
            this.text_res.Size = new System.Drawing.Size(322, 22);
            this.text_res.TabIndex = 6;
            this.text_res.WaterText = "";
            this.text_res.KeyUp += new System.Windows.Forms.KeyEventHandler(this.text_res_KeyUp);
            // 
            // btn_replace_all
            // 
            this.btn_replace_all.Location = new System.Drawing.Point(285, 360);
            this.btn_replace_all.Name = "btn_replace_all";
            this.btn_replace_all.Size = new System.Drawing.Size(100, 27);
            this.btn_replace_all.TabIndex = 13;
            this.btn_replace_all.Text = "Replace All";
            this.btn_replace_all.UseVisualStyleBackColor = true;
            this.btn_replace_all.Click += new System.EventHandler(this.btn_replace_all_Click);
            // 
            // btn_replace_find
            // 
            this.btn_replace_find.Location = new System.Drawing.Point(285, 324);
            this.btn_replace_find.Name = "btn_replace_find";
            this.btn_replace_find.Size = new System.Drawing.Size(100, 27);
            this.btn_replace_find.TabIndex = 12;
            this.btn_replace_find.Text = "Replace/Find";
            this.btn_replace_find.UseVisualStyleBackColor = true;
            this.btn_replace_find.Click += new System.EventHandler(this.btn_replace_find_Click);
            // 
            // btn_close
            // 
            this.btn_close.Location = new System.Drawing.Point(285, 395);
            this.btn_close.Name = "btn_close";
            this.btn_close.Size = new System.Drawing.Size(100, 27);
            this.btn_close.TabIndex = 14;
            this.btn_close.Text = "Close";
            this.btn_close.UseVisualStyleBackColor = true;
            this.btn_close.Click += new System.EventHandler(this.btn_close_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.cb_regex);
            this.groupBox1.Controls.Add(this.cb_immed);
            this.groupBox1.Controls.Add(this.cb_whole);
            this.groupBox1.Controls.Add(this.cb_case);
            this.groupBox1.Location = new System.Drawing.Point(17, 123);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(367, 148);
            this.groupBox1.TabIndex = 15;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "选项";
            // 
            // cb_regex
            // 
            this.cb_regex.AutoSize = true;
            this.cb_regex.Location = new System.Drawing.Point(217, 94);
            this.cb_regex.Name = "cb_regex";
            this.cb_regex.Size = new System.Drawing.Size(84, 16);
            this.cb_regex.TabIndex = 3;
            this.cb_regex.Text = "正则表达式";
            this.cb_regex.UseVisualStyleBackColor = true;
            this.cb_regex.CheckedChanged += new System.EventHandler(this.regex_CheckedChanged);
            // 
            // cb_immed
            // 
            this.cb_immed.AutoSize = true;
            this.cb_immed.Location = new System.Drawing.Point(25, 94);
            this.cb_immed.Name = "cb_immed";
            this.cb_immed.Size = new System.Drawing.Size(72, 16);
            this.cb_immed.TabIndex = 2;
            this.cb_immed.Text = "即打即找";
            this.cb_immed.UseVisualStyleBackColor = true;
            // 
            // cb_whole
            // 
            this.cb_whole.AutoSize = true;
            this.cb_whole.Location = new System.Drawing.Point(217, 53);
            this.cb_whole.Name = "cb_whole";
            this.cb_whole.Size = new System.Drawing.Size(72, 16);
            this.cb_whole.TabIndex = 1;
            this.cb_whole.Text = "整字匹配";
            this.cb_whole.UseVisualStyleBackColor = true;
            // 
            // cb_case
            // 
            this.cb_case.AutoSize = true;
            this.cb_case.Location = new System.Drawing.Point(25, 53);
            this.cb_case.Name = "cb_case";
            this.cb_case.Size = new System.Drawing.Size(84, 16);
            this.cb_case.TabIndex = 0;
            this.cb_case.Text = "区分大小写";
            this.cb_case.UseVisualStyleBackColor = true;
            // 
            // info
            // 
            this.info.AutoSize = true;
            this.info.BackColor = System.Drawing.Color.Transparent;
            this.info.ForeColor = System.Drawing.Color.Red;
            this.info.Location = new System.Drawing.Point(16, 405);
            this.info.Name = "info";
            this.info.Size = new System.Drawing.Size(0, 12);
            this.info.TabIndex = 4;
            // 
            // TextFindForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CaptionFont = new System.Drawing.Font("微软雅黑", 9F);
            this.ClientSize = new System.Drawing.Size(400, 437);
            this.Controls.Add(this.info);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btn_close);
            this.Controls.Add(this.btn_replace_all);
            this.Controls.Add(this.btn_replace_find);
            this.Controls.Add(this.btn_replace);
            this.Controls.Add(this.btn_find);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.text_target);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.text_res);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(400, 437);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(400, 437);
            this.Name = "TextFindForm";
            this.Text = "查找与替换";
            this.TitleCenter = false;
            this.TitleColor = System.Drawing.Color.White;
            this.Load += new System.EventHandler(this.TextFindForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_replace;
        private System.Windows.Forms.Button btn_find;
        private System.Windows.Forms.Label label2;
        private CCWin.SkinControl.SkinComboBox text_target;
        private System.Windows.Forms.Label label1;
        private CCWin.SkinControl.SkinComboBox text_res;
        private System.Windows.Forms.Button btn_replace_all;
        private System.Windows.Forms.Button btn_replace_find;
        private System.Windows.Forms.Button btn_close;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox cb_case;
        private System.Windows.Forms.CheckBox cb_whole;
        private System.Windows.Forms.CheckBox cb_regex;
        private System.Windows.Forms.CheckBox cb_immed;
        private System.Windows.Forms.Label info;

    }
}