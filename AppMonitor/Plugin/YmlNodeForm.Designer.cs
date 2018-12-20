namespace AppMonitor.Plugin
{
    partial class YmlNodeForm
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
            System.Windows.Forms.TreeListViewItemCollection.TreeListViewItemCollectionComparer treeListViewItemCollectionComparer2 = new System.Windows.Forms.TreeListViewItemCollection.TreeListViewItemCollectionComparer();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(YmlNodeForm));
            this.parent = new CCWin.SkinControl.SkinTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.name = new CCWin.SkinControl.SkinTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.value = new CCWin.SkinControl.SkinTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.common = new CCWin.SkinControl.SkinTextBox();
            this.btn_sure = new System.Windows.Forms.Button();
            this.btn_cancel = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this._treeView = new System.Windows.Forms.TreeListView();
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.imageList2 = new System.Windows.Forms.ImageList(this.components);
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // parent
            // 
            this.parent.BackColor = System.Drawing.Color.Transparent;
            this.parent.DownBack = null;
            this.parent.Icon = null;
            this.parent.IconIsButton = false;
            this.parent.IconMouseState = CCWin.SkinClass.ControlState.Normal;
            this.parent.IsPasswordChat = '\0';
            this.parent.IsSystemPasswordChar = false;
            this.parent.Lines = new string[0];
            this.parent.Location = new System.Drawing.Point(102, 43);
            this.parent.Margin = new System.Windows.Forms.Padding(0);
            this.parent.MaxLength = 32767;
            this.parent.MinimumSize = new System.Drawing.Size(28, 28);
            this.parent.MouseBack = null;
            this.parent.MouseState = CCWin.SkinClass.ControlState.Normal;
            this.parent.Multiline = false;
            this.parent.Name = "parent";
            this.parent.NormlBack = null;
            this.parent.Padding = new System.Windows.Forms.Padding(5);
            this.parent.ReadOnly = true;
            this.parent.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.parent.Size = new System.Drawing.Size(464, 28);
            // 
            // 
            // 
            this.parent.SkinTxt.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.parent.SkinTxt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.parent.SkinTxt.Font = new System.Drawing.Font("微软雅黑", 9.75F);
            this.parent.SkinTxt.Location = new System.Drawing.Point(5, 5);
            this.parent.SkinTxt.Name = "BaseText";
            this.parent.SkinTxt.ReadOnly = true;
            this.parent.SkinTxt.Size = new System.Drawing.Size(454, 18);
            this.parent.SkinTxt.TabIndex = 0;
            this.parent.SkinTxt.WaterColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(127)))), ((int)(((byte)(127)))));
            this.parent.SkinTxt.WaterText = "父节点属性名称";
            this.parent.TabIndex = 0;
            this.parent.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.parent.WaterColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(127)))), ((int)(((byte)(127)))));
            this.parent.WaterText = "父节点属性名称";
            this.parent.WordWrap = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(17, 51);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "父属性名称：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(29, 95);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "属性名称：";
            // 
            // name
            // 
            this.name.BackColor = System.Drawing.Color.Transparent;
            this.name.DownBack = null;
            this.name.Icon = null;
            this.name.IconIsButton = false;
            this.name.IconMouseState = CCWin.SkinClass.ControlState.Normal;
            this.name.IsPasswordChat = '\0';
            this.name.IsSystemPasswordChar = false;
            this.name.Lines = new string[0];
            this.name.Location = new System.Drawing.Point(102, 87);
            this.name.Margin = new System.Windows.Forms.Padding(0);
            this.name.MaxLength = 32767;
            this.name.MinimumSize = new System.Drawing.Size(28, 28);
            this.name.MouseBack = null;
            this.name.MouseState = CCWin.SkinClass.ControlState.Normal;
            this.name.Multiline = false;
            this.name.Name = "name";
            this.name.NormlBack = null;
            this.name.Padding = new System.Windows.Forms.Padding(5);
            this.name.ReadOnly = false;
            this.name.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.name.Size = new System.Drawing.Size(464, 28);
            // 
            // 
            // 
            this.name.SkinTxt.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.name.SkinTxt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.name.SkinTxt.Font = new System.Drawing.Font("微软雅黑", 9.75F);
            this.name.SkinTxt.Location = new System.Drawing.Point(5, 5);
            this.name.SkinTxt.Name = "BaseText";
            this.name.SkinTxt.Size = new System.Drawing.Size(454, 18);
            this.name.SkinTxt.TabIndex = 0;
            this.name.SkinTxt.WaterColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(127)))), ((int)(((byte)(127)))));
            this.name.SkinTxt.WaterText = "属性名称";
            this.name.TabIndex = 2;
            this.name.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.name.WaterColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(127)))), ((int)(((byte)(127)))));
            this.name.WaterText = "属性名称";
            this.name.WordWrap = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Location = new System.Drawing.Point(41, 141);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 3;
            this.label3.Text = "属性值：";
            // 
            // value
            // 
            this.value.BackColor = System.Drawing.Color.Transparent;
            this.value.DownBack = null;
            this.value.Icon = null;
            this.value.IconIsButton = false;
            this.value.IconMouseState = CCWin.SkinClass.ControlState.Normal;
            this.value.IsPasswordChat = '\0';
            this.value.IsSystemPasswordChar = false;
            this.value.Lines = new string[0];
            this.value.Location = new System.Drawing.Point(102, 133);
            this.value.Margin = new System.Windows.Forms.Padding(0);
            this.value.MaxLength = 32767;
            this.value.MinimumSize = new System.Drawing.Size(28, 28);
            this.value.MouseBack = null;
            this.value.MouseState = CCWin.SkinClass.ControlState.Normal;
            this.value.Multiline = false;
            this.value.Name = "value";
            this.value.NormlBack = null;
            this.value.Padding = new System.Windows.Forms.Padding(5);
            this.value.ReadOnly = false;
            this.value.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.value.Size = new System.Drawing.Size(464, 28);
            // 
            // 
            // 
            this.value.SkinTxt.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.value.SkinTxt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.value.SkinTxt.Font = new System.Drawing.Font("微软雅黑", 9.75F);
            this.value.SkinTxt.Location = new System.Drawing.Point(5, 5);
            this.value.SkinTxt.Name = "BaseText";
            this.value.SkinTxt.Size = new System.Drawing.Size(454, 18);
            this.value.SkinTxt.TabIndex = 0;
            this.value.SkinTxt.WaterColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(127)))), ((int)(((byte)(127)))));
            this.value.SkinTxt.WaterText = "属性值";
            this.value.TabIndex = 2;
            this.value.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.value.WaterColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(127)))), ((int)(((byte)(127)))));
            this.value.WaterText = "属性值";
            this.value.WordWrap = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Location = new System.Drawing.Point(53, 186);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 12);
            this.label4.TabIndex = 5;
            this.label4.Text = "备注：";
            // 
            // common
            // 
            this.common.BackColor = System.Drawing.Color.Transparent;
            this.common.DownBack = null;
            this.common.Icon = null;
            this.common.IconIsButton = false;
            this.common.IconMouseState = CCWin.SkinClass.ControlState.Normal;
            this.common.IsPasswordChat = '\0';
            this.common.IsSystemPasswordChar = false;
            this.common.Lines = new string[0];
            this.common.Location = new System.Drawing.Point(102, 178);
            this.common.Margin = new System.Windows.Forms.Padding(0);
            this.common.MaxLength = 32767;
            this.common.MinimumSize = new System.Drawing.Size(28, 28);
            this.common.MouseBack = null;
            this.common.MouseState = CCWin.SkinClass.ControlState.Normal;
            this.common.Multiline = false;
            this.common.Name = "common";
            this.common.NormlBack = null;
            this.common.Padding = new System.Windows.Forms.Padding(5);
            this.common.ReadOnly = false;
            this.common.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.common.Size = new System.Drawing.Size(464, 28);
            // 
            // 
            // 
            this.common.SkinTxt.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.common.SkinTxt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.common.SkinTxt.Font = new System.Drawing.Font("微软雅黑", 9.75F);
            this.common.SkinTxt.Location = new System.Drawing.Point(5, 5);
            this.common.SkinTxt.Name = "BaseText";
            this.common.SkinTxt.Size = new System.Drawing.Size(454, 18);
            this.common.SkinTxt.TabIndex = 0;
            this.common.SkinTxt.WaterColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(127)))), ((int)(((byte)(127)))));
            this.common.SkinTxt.WaterText = "备注";
            this.common.TabIndex = 4;
            this.common.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.common.WaterColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(127)))), ((int)(((byte)(127)))));
            this.common.WaterText = "备注";
            this.common.WordWrap = true;
            // 
            // btn_sure
            // 
            this.btn_sure.Location = new System.Drawing.Point(491, 228);
            this.btn_sure.Name = "btn_sure";
            this.btn_sure.Size = new System.Drawing.Size(75, 27);
            this.btn_sure.TabIndex = 6;
            this.btn_sure.Text = "确定";
            this.btn_sure.UseVisualStyleBackColor = true;
            this.btn_sure.Click += new System.EventHandler(this.btn_sure_Click);
            // 
            // btn_cancel
            // 
            this.btn_cancel.Location = new System.Drawing.Point(396, 228);
            this.btn_cancel.Name = "btn_cancel";
            this.btn_cancel.Size = new System.Drawing.Size(75, 27);
            this.btn_cancel.TabIndex = 7;
            this.btn_cancel.Text = "取消";
            this.btn_cancel.UseVisualStyleBackColor = true;
            this.btn_cancel.Click += new System.EventHandler(this.btn_cancel_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this._treeView);
            this.panel1.Location = new System.Drawing.Point(102, 71);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(464, 191);
            this.panel1.TabIndex = 1;
            this.panel1.Visible = false;
            // 
            // _treeView
            // 
            this._treeView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader2,
            this.columnHeader3});
            treeListViewItemCollectionComparer2.Column = 0;
            treeListViewItemCollectionComparer2.SortOrder = System.Windows.Forms.SortOrder.None;
            this._treeView.Comparer = treeListViewItemCollectionComparer2;
            this._treeView.GridLines = true;
            this._treeView.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this._treeView.LabelWrap = false;
            this._treeView.Location = new System.Drawing.Point(0, -1);
            this._treeView.MultiSelect = false;
            this._treeView.Name = "_treeView";
            this._treeView.PlusMinusLineColor = System.Drawing.Color.Teal;
            this._treeView.Size = new System.Drawing.Size(464, 152);
            this._treeView.SmallImageList = this.imageList2;
            this._treeView.Sorting = System.Windows.Forms.SortOrder.None;
            this._treeView.TabIndex = 1;
            this._treeView.UseCompatibleStateImageBehavior = false;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "属性";
            this.columnHeader2.Width = 240;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "值";
            this.columnHeader3.Width = 210;
            // 
            // imageList2
            // 
            this.imageList2.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList2.ImageStream")));
            this.imageList2.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList2.Images.SetKeyName(0, "Folder_open_16px.png");
            this.imageList2.Images.SetKeyName(1, "item_16px.png");
            this.imageList2.Images.SetKeyName(2, "gray_light_16px.png");
            this.imageList2.Images.SetKeyName(3, "openSession.png");
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(381, 157);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 27);
            this.button1.TabIndex = 2;
            this.button1.Text = "选定";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(299, 157);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 27);
            this.button2.TabIndex = 3;
            this.button2.Text = "取消";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // YmlNodeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::AppMonitor.Properties.Resources.skin_12;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.CaptionFont = new System.Drawing.Font("微软雅黑", 9F);
            this.ClientSize = new System.Drawing.Size(589, 273);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btn_cancel);
            this.Controls.Add(this.btn_sure);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.common);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.value);
            this.Controls.Add(this.name);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.parent);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(589, 273);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(589, 273);
            this.Name = "YmlNodeForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "新增/修改节点";
            this.TitleCenter = false;
            this.TitleColor = System.Drawing.Color.White;
            this.Load += new System.EventHandler(this.YmlNodeForm_Load);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CCWin.SkinControl.SkinTextBox parent;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private CCWin.SkinControl.SkinTextBox name;
        private System.Windows.Forms.Label label3;
        private CCWin.SkinControl.SkinTextBox value;
        private System.Windows.Forms.Label label4;
        private CCWin.SkinControl.SkinTextBox common;
        private System.Windows.Forms.Button btn_sure;
        private System.Windows.Forms.Button btn_cancel;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TreeListView _treeView;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ImageList imageList2;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
    }
}