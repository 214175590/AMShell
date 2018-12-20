using AppMonitor.Bex;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AppMonitor.Plugin
{
    public partial class YmlNodeForm : CCWin.Skin_Metro
    {
        private TreeListViewItem treeNode = null;
        private List<YmlItem> lists;
        private YmlItem parentItem = null;
        public delegate void EditNodeCallback(YmlItem item);
        private EditNodeCallback callback;
        // 0 修改，1新增子节点，2新增顶级节点，3新增同级节点
        private int operaType = 0;

        public YmlNodeForm(TreeListViewItem item, List<YmlItem> lists, EditNodeCallback callback, int operaType)
        {
            InitializeComponent();
            SkinUtil.SetFormSkin(this);
            this.treeNode = item;
            this.lists = lists;
            this.callback = callback;
            this.operaType = operaType;
        }

        private void YmlNodeForm_Load(object sender, EventArgs e)
        {
            if (null != this.treeNode)
            {
                name.Text = this.treeNode.SubItems[0].Text;
                value.Text = this.treeNode.SubItems[1].Text;
                common.Text = this.treeNode.SubItems[3].Text;
                if (null != this.treeNode.Parent)
                {
                    parent.Text = listToNodeText(getParentText(this.treeNode.Parent));
                }

                if (operaType == 1)
                {
                    parent.Enabled = false;

                }
                else if (operaType == 2)
                {
                    parent.Enabled = false;
                    value.Enabled = false;
                }
                else if (operaType == 3)
                {
                    parent.Enabled = false;

                }
            }
            value.Focus();
            panel1.Visible = false;
            if (null != lists)
            {
                parent.SkinTxt.MouseClick += SkinTxt_MouseClick;
                RenderTree();
            }
        }

        void SkinTxt_MouseClick(object sender, MouseEventArgs e)
        {
            if (null != lists)
            {
                panel1.Visible = !panel1.Visible;
            }
        }

        private List<string> getParentText(TreeListViewItem node)
        {
            List<string> list = new List<string>();
            if(node != null){
                list.Add(node.Text);
                List<string> plist = getParentText(node.Parent);
                if (plist.Count > 0)
                {
                    list.AddRange(plist);
                }
            }
            return list;
        }

        private string listToNodeText(List<string> list)
        {
            string text = "";
            for (int i = list.Count - 1; i >= 0; i-- )
            {
                text += "." + list[i];
            }
            return text != "" ? text.Substring(1) : text;
        }

        private void RenderTree()
        {
            // 树形
            _treeView.Items.Clear();
            TreeListViewItem viewItem = null, parentItem = null;
            Dictionary<string, TreeListViewItem> _cache = new Dictionary<string, TreeListViewItem>();
            foreach (YmlItem obj in lists)
            {
                if (obj.ImageIndex == 1 || obj.ImageIndex == 2)
                {
                    continue;
                }
                viewItem = new TreeListViewItem();
                viewItem.Tag = obj;
                viewItem.Text = obj.Key;
                viewItem.ImageIndex = obj.ImageIndex;

                viewItem.SubItems.Add(obj.Value);

                if (obj.Level == 0)
                {
                    _treeView.Items.Add(viewItem);
                }
                else if (_cache.ContainsKey(obj.Parent.Uuid))
                {
                    parentItem = _cache[obj.Parent.Uuid];
                    if (null != parentItem)
                    {
                        parentItem.Items.Add(viewItem);
                    }
                }
                else
                {
                    _treeView.Items.Add(viewItem);
                }

                _cache.Add(obj.Uuid, viewItem);
            }
            _treeView.ExpandAll();
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_sure_Click(object sender, EventArgs e)
        {
            if (treeNode != null)
            {
                YmlItem item = (YmlItem)treeNode.Tag;
                item.Key = name.Text;
                item.Value = value.Text;
                item.Common = common.Text;
                if (!item.Common.TrimStart().StartsWith("#") && item.Common != "")
                {
                    item.Common = "#" + item.Common;
                }
                if(!item.Key.TrimStart().StartsWith("#")){
                    if (string.IsNullOrWhiteSpace(item.Value))
                    {
                        item.ImageIndex = 3;
                    }
                    else
                    {
                        item.ImageIndex = 1;
                    }
                }
                else
                {
                    item.ImageIndex = 2;
                }
                treeNode.SubItems[0].Text = item.Key;
                treeNode.SubItems[1].Text = item.Value;
                treeNode.SubItems[3].Text = item.Common;
                treeNode.ImageIndex = item.ImageIndex;

                if (parentItem != null)
                {
                    treeNode.SubItems[2].Text = "" + (parentItem.Level + 1);
                    item.Level = (parentItem.Level + 1);
                    item.SpcCount = item.Level * 4;
                    treeNode.SubItems[2].Text = "" + item.Level;
                    if (callback != null)
                    {
                        callback(parentItem);
                    }
                }                
            }
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (_treeView.SelectedItems.Count > 0)
            {
                TreeListViewItem item = _treeView.SelectedItems[0];
                YmlItem file = (YmlItem) item.Tag;
                parent.Text = listToNodeText(getParentText(item));

                parentItem = file;
            }

            panel1.Visible = false;
        }
    }
}
