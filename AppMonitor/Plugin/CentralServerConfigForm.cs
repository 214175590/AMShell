using AppMonitor.Bex;
using AppMonitor.Froms;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Tamir.SharpSsh.jsch;

namespace AppMonitor.Plugin
{
    public partial class CentralServerConfigForm : CCWin.Skin_Metro
    {
        private MonitorForm monitorForm;
        private string cfgDir = "", remoteCfgPath = "";
        private string resContent = "";
        public CentralServerConfigForm(MonitorForm form)
        {
            InitializeComponent();
            SkinUtil.SetFormSkin(this);
            this.monitorForm = form;
        }

        private void CentralServerConfigForm_Load(object sender, EventArgs e)
        {
            if(monitorForm != null){
                this.Text = "Docker公共配置 - " + monitorForm.getSessionConfig().Host;
                cfgDir = MainForm.TEMP_DIR + monitorForm.getSessionConfig().Host;
                cfgDir = cfgDir.Replace("\\", "/");
                if (!Directory.Exists(cfgDir))
                {
                    Directory.CreateDirectory(cfgDir);
                }

                string cfgPath = monitorForm.getSessionConfig().CentralServerConfigDir;
                if (string.IsNullOrWhiteSpace(cfgPath))
                {
                    string home = monitorForm.getSftp().getHome();
                    if (!home.EndsWith("/"))
                    {
                        home += "/";
                    }
                    remoteCfgPath = home + "docker/central-server-config";
                    monitorForm.getSessionConfig().CentralServerConfigDir = remoteCfgPath;
                    AppConfig.Instance.SaveConfig(2);
                }
                else
                {
                    remoteCfgPath = cfgPath;
                }                

                stb_remote_dir.Text = remoteCfgPath;

                LoadRemoteYmls();
            }
            else
            {
                btn_reload.Enabled = false;
                btn_show.Enabled = false;
                下载到本地ToolStripMenuItem.Enabled = false;
                上传到服务器ToolStripMenuItem.Enabled = false;
                更改文件名ToolStripMenuItem.Enabled = false;
                删除文件ToolStripMenuItem.Enabled = false;
                this.AllowDrop = true;
            }
        }


        public void LoadRemoteYmls()
        {
            
            btn_reload.Enabled = false;
            ArrayList fileList = monitorForm.getDirFiles(remoteCfgPath);
            if (null != fileList)
            {
                if (fileList.Count > 0)
                {
                    label1.Visible = false;

                    listView1.Items.Clear();
                    ListViewItem item = null;
                    ChannelSftp.LsEntry file = null;
                    YmlFile yml = null;
                    string remotePath = "", localPath = "";
                    for (int i = 0; i < fileList.Count; i++)
                    {
                        object obj = fileList[i];
                        if (obj is ChannelSftp.LsEntry)
                        {
                            file = (ChannelSftp.LsEntry)obj;
                            try
                            {
                                yml = new YmlFile();
                                yml.correct = true;
                                yml.localName = file.getFilename();
                                yml.localPath = cfgDir + "/";
                                yml.remoteName = file.getFilename();
                                yml.remotePath = remoteCfgPath + "/";
                                yml.status = YmlFileState.NoModif;

                                item = new ListViewItem();
                                item.Text = file.getFilename();
                                item.Tag = yml;
                                item.ImageIndex = 1;

                                remotePath = yml.remotePath + yml.remoteName;
                                localPath = yml.localPath + yml.localName;

                                downloadFile(remotePath, localPath);

                                listView1.Items.Add(item);
                            }
                            catch { }
                        }
                    }

                }
                else
                {
                    label1.Text = "暂无文件";
                    label1.Visible = true;
                }
            }
            else
            {
                label1.Text = "加载失败";
                label1.Visible = true;
            }

            btn_reload.Enabled = true;
            
        }

        public void downloadFile(string src, string dst)
        {
            try
            {
                FileInfo file = new FileInfo(dst);
                if (file.Exists)
                {
                    file.Delete();
                }
            }
            catch { }            
            monitorForm.getSftp().get(src, dst);
        }

        private void btn_reload_Click(object sender, EventArgs e)
        {
            LoadRemoteYmls();
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                ListViewItem item = listView1.SelectedItems[0];
                foreach (ListViewItem item2 in listView1.Items)
                {
                    item2.ForeColor = Color.Black;
                }
                item.ForeColor = Color.Red;

                YmlFile file = (YmlFile)item.Tag;
                string path = file.localPath + file.localName;
                string content = YSTools.YSFile.readFileToString(path);
                if ((file.remotePath + file.remoteName) == "")
                {
                    file_label.Text = file.localPath + file.localName;
                }
                else
                {
                    file_label.Text = file.remotePath + file.remoteName;
                }                

                // 渲染
                if (tabControl1.SelectedIndex == 0)
                {
                    if (resContent != content || _treeView.Items.Count == 0)
                    {
                        resContent = content;
                        btn_save.Enabled = false;
                        btn_tree.Text = "展开全部节点";

                        // 树形
                        _treeView.Items.Clear();
                        List<YmlItem> lists = YmlFormatUtil.FormatYmlToTree(content);
                        TreeListViewItem viewItem = null, parentItem = null;
                        Dictionary<string, TreeListViewItem> _cache = new Dictionary<string, TreeListViewItem>();
                        foreach (YmlItem obj in lists)
                        {
                            viewItem = new TreeListViewItem();
                            viewItem.Tag = obj;
                            viewItem.Text = obj.Key;
                            viewItem.ImageIndex = obj.ImageIndex;

                            viewItem.SubItems.Add(obj.Value);
                            viewItem.SubItems.Add("" + obj.Level);
                            viewItem.SubItems.Add(obj.Common);

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

                        Validate(item, content);
                    }                   

                }
                else
                {
                    if (resContent != content || ymlEditor.Text == "")
                    {
                        // YML编辑器
                        ymlEditor.Text = "";
                        List<YmlLine> list = YmlFormatUtil.FormatYml(content);
                        foreach (YmlLine line in list)
                        {
                            ymlEditor.SelectionColor = line.Color;
                            ymlEditor.SelectionFont = line.Font;
                            ymlEditor.AppendText(line.Text);
                        }

                        ymlEditor.ClearUndo();

                        Validate(item, content);
                    }
                }

            }
        }

        private bool Validate(ListViewItem item, string content)
        {
            bool result = true;
            YmlFile file = (YmlFile)item.Tag;
            YmlError error = YmlFormatUtil.ValidateYml(content);
            if (error != null)
            {
                try
                {
                    if (tabControl1.SelectedIndex == 1)
                    {
                        ymlEditor.SelectionStart = error.index - 1;
                        ymlEditor.ScrollToCaret();
                        ymlEditor.Select(error.index, 0);
                        ymlEditor.Focus();
                    }
                }
                catch { }

                MessageBox.Show(this, error.msg);
                file.correct = false;
                item.ImageIndex = 3;

                result = false;
            }
            else
            {
                if (file.status == YmlFileState.NoModif)
                {
                    item.ImageIndex = 1;
                }
                else if (file.status == YmlFileState.Modif)
                {
                    item.ImageIndex = 2;
                }
                else if (file.status == YmlFileState.NoAsync)
                {
                    item.ImageIndex = 0;
                }
            }
            return result;
        }

        private void listView1_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Right && listView1.SelectedItems.Count > 0)
            {
                contextMenuStrip1.Show(listView1, e.Location);
            }
        }

        private void _treeView_AfterExpand(object sender, TreeListViewEventArgs e)
        {
            if (e.Item.ImageIndex != 1 && e.Item.ImageIndex != 2)
            {
                if (e.Item.IsExpanded)
                {
                    e.Item.ImageIndex = 3;
                }
                else
                {
                    e.Item.ImageIndex = 0;
                }
            }
            
        }

        private void _treeView_AfterCollapse(object sender, TreeListViewEventArgs e)
        {
            if (e.Item.ImageIndex != 1 && e.Item.ImageIndex != 2)
            {
                if (e.Item.IsExpanded)
                {
                    e.Item.ImageIndex = 3;
                }
                else
                {
                    e.Item.ImageIndex = 0;
                }
            }
        }

        private void 校验ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                ListViewItem item = listView1.SelectedItems[0];

                string content = "";
                if (tabControl1.SelectedIndex == 0)
                {
                    string line = "";
                    StringBuilder sb = new StringBuilder();
                    foreach(TreeListViewItem treeNode in _treeView.Items){
                        line = treeNode.Text;
                        if(!line.TrimStart().StartsWith("#")){
                            line += ": " + treeNode.SubItems[0].Text;
                            line += treeNode.SubItems[2].Text;
                        }
                        sb.AppendLine(treeNode.Text);
                    }
                    content = sb.ToString();
                }
                else
                {
                    content = ymlEditor.Text;
                }

                Validate(item, content);
            }
            
        }

        private void 下载到本地ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                ListViewItem item = listView1.SelectedItems[0];
                YmlFile file = (YmlFile)item.Tag;

                string remotePath = file.remotePath + file.remoteName;
                string localPath = file.localPath + file.localName;

                downloadFile(remotePath, localPath);

                listView1_SelectedIndexChanged(null, null);
            }
        }

        private void 上传到服务器ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                ListViewItem item = listView1.SelectedItems[0];
                YmlFile file = (YmlFile)item.Tag;

                string remotePath = file.remotePath + file.remoteName;
                string localPath = file.localPath + file.localName;

                monitorForm.getSftp().put(localPath, remotePath, ChannelSftp.OVERWRITE);

                item.ImageIndex = 1;
                file.status = YmlFileState.NoModif;
            }
        }

        private void 更改文件名ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                ListViewItem item = listView1.SelectedItems[0];
                YmlFile file = (YmlFile)item.Tag;

                string oldName = file.localName;
                string msg = "请输入文件的新名称";
                InputForm form = new InputForm(msg, oldName, new InputForm.FormResult((newName) =>
                {
                    if (oldName != newName)
                    {
                        file.localName = newName;
                        string dirs = file.remotePath;
                        string path1 = dirs + Utils.getLinuxName(oldName);
                        string path2 = dirs + Utils.getLinuxName(newName);
                        monitorForm.RunShell(string.Format("mv {0} {1}", path1, path2), false, true);

                        file.remoteName = file.localName;
                        item.Text = file.localName;
                    }
                }));
                form.ShowDialog(this);
            }

            
        }

        private void 删除文件ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                ListViewItem item = listView1.SelectedItems[0];
                YmlFile file = (YmlFile)item.Tag;

                DialogResult dr = MessageBox.Show(this, "您确定要删除此文件吗？", "警告", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                if(dr == System.Windows.Forms.DialogResult.OK){
                    monitorForm.RunShell(string.Format("rm -rf {0}", file.remotePath + file.remoteName), false, true);

                    listView1.Items.Remove(item);
                }
            }
        }

        private void btn_new_Click(object sender, EventArgs e)
        {
            string oldName = "";
            string msg = "请输入文件名称（不包含.yml后缀）";
            InputForm form = new InputForm(msg, oldName, new InputForm.FormResult((newName) =>
            {
                if (oldName != newName)
                {
                    oldName = newName + ".yml";
                    string path = cfgDir + "/" + oldName;
                    YSTools.YSFile.writeFileByString(path, "#.yml File Create By AMShell - " + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));

                    listView1.Items.Add(new ListViewItem()
                    {
                        Text = oldName,
                        ImageIndex = 0,
                        Tag = new YmlFile()
                        {
                            remotePath = remoteCfgPath + "/",
                            remoteName = oldName,
                            localName = oldName,
                            localPath = cfgDir + "/",
                            status = YmlFileState.NoAsync,
                            correct = true
                        }
                    });
                }
                else
                {
                    MessageBox.Show(this, "文件名称不能为空");
                }
            }));
            form.ShowDialog(this);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                ListViewItem item = listView1.SelectedItems[0];
                YmlFile file = (YmlFile)item.Tag;

                string content = "";
                if (tabControl1.SelectedIndex == 0)
                {
                    List<string> list = getTreeNodeContent(_treeView.Items);
                    foreach(string line in list){
                        if(!string.IsNullOrWhiteSpace(line)){
                            content += line + "\n";
                        }
                    }
                }
                else
                {
                    content = ymlEditor.Text;
                }

                bool result = Validate(item, content);
                if (result)
                {
                    resContent = content;
                    YSTools.YSFile.writeFileByString(file.localPath + file.localName, content);
                    btn_save.Enabled = false;
                }
            }
        }

        private List<string> getTreeNodeContent(TreeListViewItemCollection items)
        {
            List<string> list = new List<string>();
            string line = "";
            int level = 0;
            foreach (TreeListViewItem treeNode in items)
            {
                line = treeNode.Text;
                if (!line.TrimStart().StartsWith("#"))
                {
                    line += ": ";
                    level = Convert.ToInt32(treeNode.SubItems[2].Text);
                    line = YmlFormatUtil.GetSpace(level * 4) + line;
                    line += treeNode.SubItems[1].Text;
                    line += treeNode.SubItems[3].Text;                    
                }
                if (!string.IsNullOrWhiteSpace(line))
                {
                    list.Add(line);
                }
                list.AddRange(getTreeNodeContent(treeNode.Items));
            }
            return list;
        }

        private TreeListViewItem getTreeNode(TreeListViewItemCollection items, string uuid)
        {
            TreeListViewItem node = null;
            YmlItem item = null;
            foreach (TreeListViewItem treeNode in items)
            {
                item = (YmlItem)treeNode.Tag;
                if(item.Uuid == uuid){
                    node = treeNode;
                    return node;
                }
                node = getTreeNode(treeNode.Items, uuid);
                if(null != node){
                    return node;
                }
            }
            return null;
        }

        private void ymlEditor_KeyUp(object sender, KeyEventArgs e)
        {
            if (resContent != ymlEditor.Text)
            {
                if (listView1.SelectedItems.Count > 0)
                {
                    ListViewItem item = listView1.SelectedItems[0];
                    YmlFile file = (YmlFile)item.Tag;
                    file.status = YmlFileState.Modif;
                    item.ImageIndex = 2;

                    btn_save.Enabled = true;
                }
            }           
            Ranks();
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex == 0)
            {
                btn_tree.Visible = true;
                btn_meihua.Visible = false;                
                pos_label.Text = "";
            }
            else
            {
                btn_tree.Visible = false;
                btn_meihua.Visible = true;
            }

            listView1_SelectedIndexChanged(null, null);
        }

        private void btn_meihua_Click(object sender, EventArgs e)
        {
            int index = ymlEditor.GetFirstCharIndexOfCurrentLine();
            int row = ymlEditor.GetLineFromCharIndex(index);
            int start = ymlEditor.SelectionStart;

            string content = ymlEditor.Text;
            // YML编辑器
            ymlEditor.Text = "";
            List<YmlLine> list = YmlFormatUtil.FormatYml(content, true);
            foreach (YmlLine line in list)
            {
                ymlEditor.SelectionColor = line.Color;
                ymlEditor.SelectionFont = line.Font;
                ymlEditor.AppendText(line.Text);
            }

            if(row > 10){
                index = ymlEditor.GetFirstCharIndexFromLine(row - 10);
                ymlEditor.SelectionStart = index;
                ymlEditor.SelectionLength = 0;    
                ymlEditor.ScrollToCaret();
            }

            ymlEditor.SelectionStart = start;
            ymlEditor.SelectionLength = 0;
            ymlEditor.Focus();
        }

        private void btn_tree_Click(object sender, EventArgs e)
        {
            string text = btn_tree.Text;
            if(text == "展开全部节点"){
                btn_tree.Text = "收缩全部节点";
                _treeView.ExpandAll();
            }
            else
            {
                btn_tree.Text = "展开全部节点";
                _treeView.CollapseAll();
            }
        }

        private void 编辑节点ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_treeView.SelectedItems.Count > 0)
            {
                List<YmlItem> lists = YmlFormatUtil.FormatYmlToTree(resContent);
                TreeListViewItem item = _treeView.SelectedItems[0];
                string parentId = null;
                if (null != item.Parent)
                {
                    parentId = ((YmlItem)item.Parent.Tag).Uuid;
                }
                YmlNodeForm form = new YmlNodeForm(item, lists, (ymlItem) => {
                    if (null != ymlItem)
                    {
                        string newParentId = ymlItem.Uuid;
                        if (newParentId != parentId)
                        {
                            TreeListViewItem parentNode = getTreeNode(_treeView.Items, newParentId);
                            if (null != parentNode)
                            {
                                if (null != item.Parent)
                                {
                                    item.Parent.Items.Remove(item);
                                }
                                else
                                {
                                    _treeView.Items.Remove(item);
                                }
                                parentNode.Items.Add(item);
                            }
                        }
                    }
                }, 0);
                form.ShowDialog(this);
                btn_save.Enabled = true;
            }
        }

        private void 添加子节点ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_treeView.SelectedItems.Count > 0)
            {
                TreeListViewItem parentNode = _treeView.SelectedItems[0];
                YmlItem parentObj = (YmlItem) parentNode.Tag;

                TreeListViewItem viewItem = new TreeListViewItem();
                YmlItem obj = new YmlItem()
                {
                    Key = "",
                    Value = "",
                    Level = parentObj.Level + 1,
                    Common = "",
                    Uuid = Guid.NewGuid().ToString("N"),
                    ImageIndex = 1,
                    Parent = parentObj,
                    SpcCount = (parentObj.Level + 1) * 4
                };
                viewItem.Tag = obj;
                viewItem.Text = obj.Key;
                viewItem.ImageIndex = obj.ImageIndex;

                viewItem.SubItems.Add(obj.Value);
                viewItem.SubItems.Add("" + obj.Level);
                viewItem.SubItems.Add(obj.Common);
                parentNode.Items.Add(viewItem);

                string parentId = parentObj.Uuid;
                YmlNodeForm form = new YmlNodeForm(viewItem, null, null, 1);
                form.ShowDialog(this);

                string value = viewItem.SubItems[1].Text;
                if (string.IsNullOrWhiteSpace(value))
                {
                    string key = viewItem.SubItems[0].Text;
                    if (key.Trim().StartsWith("#"))
                    {
                        obj.ImageIndex = 2;                        
                    } else {
                        obj.ImageIndex = 3;
                    }
                    viewItem.ImageIndex = obj.ImageIndex;
                }
                btn_save.Enabled = true;
            }
        }

        private void 添加顶级节点ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            TreeListViewItem viewItem = new TreeListViewItem();
            YmlItem obj = new YmlItem()
            {
                Key = "",
                Value = "",
                Level = 0,
                Common = "",
                Uuid = Guid.NewGuid().ToString("N"),
                ImageIndex = 3,
                Parent = null,
                SpcCount = 0
            };
            viewItem.Tag = obj;
            viewItem.Text = obj.Key;
            viewItem.ImageIndex = obj.ImageIndex;

            viewItem.SubItems.Add(obj.Value);
            viewItem.SubItems.Add("" + obj.Level);
            viewItem.SubItems.Add(obj.Common);

            _treeView.Items.Add(viewItem);

            YmlNodeForm form = new YmlNodeForm(viewItem, null, null, 2);
            form.ShowDialog(this);
            btn_save.Enabled = true;
        }

        private void 添加同级节点ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_treeView.SelectedItems.Count > 0)
            {
                TreeListViewItem parentNode = _treeView.SelectedItems[0];
                YmlItem parentObj = (YmlItem)parentNode.Tag;

                TreeListViewItem viewItem = new TreeListViewItem();
                YmlItem obj = new YmlItem()
                {
                    Key = "",
                    Value = "",
                    Level = parentObj.Level,
                    Common = "",
                    Uuid = Guid.NewGuid().ToString("N"),
                    ImageIndex = parentObj.ImageIndex == 2 ? 1 : parentObj.ImageIndex,
                    Parent = parentObj.Parent,
                    SpcCount = parentObj.SpcCount
                };
                viewItem.Tag = obj;
                viewItem.Text = obj.Key;
                viewItem.ImageIndex = obj.ImageIndex;

                viewItem.SubItems.Add(obj.Value);
                viewItem.SubItems.Add("" + obj.Level);
                viewItem.SubItems.Add(obj.Common);

                if (parentNode.Parent != null)
                {
                    parentNode.Parent.Items.Add(viewItem);
                }
                else
                {
                    _treeView.Items.Add(viewItem);
                }                

                YmlNodeForm form = new YmlNodeForm(viewItem, null, null, 1);
                form.ShowDialog(this);

                string value = viewItem.SubItems[1].Text;
                if (string.IsNullOrWhiteSpace(value))
                {
                    string key = viewItem.SubItems[0].Text;
                    if (key.Trim().StartsWith("#"))
                    {
                        obj.ImageIndex = 2;
                    }
                    else
                    {
                        obj.ImageIndex = 3;
                    }
                    viewItem.ImageIndex = obj.ImageIndex;
                }
                btn_save.Enabled = true;
            }            
        }

        private void 删除节点ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_treeView.SelectedItems.Count > 0)
            {
                TreeListViewItem node = _treeView.SelectedItems[0];

                DialogResult dr = MessageBox.Show(this, "删除节点将会包含所有子节点都会删除，\n您确定要删除此节点吗？", "警告", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if(dr == System.Windows.Forms.DialogResult.Yes){
                    if (node.Parent != null)
                    {
                        node.Parent.Items.Remove(node);
                    }
                    else
                    {
                        _treeView.Items.Remove(node);
                    }                    
                }
            }
            btn_save.Enabled = true;
        }

        private void 升级ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_treeView.SelectedItems.Count > 0)
            {
                TreeListViewItem node = _treeView.SelectedItems[0];
                YmlItem item = (YmlItem)node.Tag;
                if (node.Parent != null && item.Level > 0)
                {
                    TreeListViewItem parentNode = node.Parent;
                    YmlItem parentItem = (YmlItem)parentNode.Tag;                    

                    node.Parent.Items.Remove(node);
                    if (parentNode.Parent == null)
                    {
                        _treeView.Items.Add(node);
                    }
                    else
                    {
                        parentNode.Parent.Items.Add(node);
                    }

                    item.Level = parentItem.Level;
                    item.Parent = parentItem.Parent;

                    node.SubItems[2].Text = "" + item.Level;
                }
            }
            btn_save.Enabled = true;
        }

        private void 降级ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_treeView.SelectedItems.Count > 0)
            {
                TreeListViewItem node = _treeView.SelectedItems[0];
                YmlItem item = (YmlItem)node.Tag;

                TreeListViewItem preNode = getSameLevelPreNode(node, node);
                if (preNode != null)
                {
                    node.Parent.Items.Remove(node);
                    preNode.Items.Add(node);

                    item.Level = item.Level + 1;
                    item.Parent = (YmlItem)preNode.Tag;
                    node.SubItems[2].Text = "" + item.Level;
                }
                else
                {
                    TreeListViewItem nextNode = getSameLevelNextNode(node, node);
                    if (nextNode != null)
                    {
                        node.Parent.Items.Remove(node);
                        nextNode.Items.Add(node);

                        item.Level = item.Level + 1;
                        item.Parent = (YmlItem)nextNode.Tag;
                        node.SubItems[2].Text = "" + item.Level;
                    }
                }
            }
            btn_save.Enabled = true;
        }

        private TreeListViewItem getSameLevelPreNode(TreeListViewItem currNode, TreeListViewItem pnode)
        {
            TreeListViewItem preNode = pnode.PrevVisibleItem;
            if (preNode != null && preNode.Level == currNode.Level && preNode.ImageIndex != 1 && preNode.ImageIndex != 2)
            {
                return preNode;
            }
            else if (preNode != null && preNode.Level >= currNode.Level)
            {
                return getSameLevelPreNode(currNode, preNode);
            }
            return null;
        }

        private TreeListViewItem getSameLevelNextNode(TreeListViewItem currNode, TreeListViewItem nnode)
        {
            TreeListViewItem nextNode = nnode.NextVisibleItem;
            if (nextNode != null && nextNode.Level == currNode.Level && nextNode.ImageIndex != 1 && nextNode.ImageIndex != 2)
            {
                return nextNode;
            }
            else if (nextNode != null && nextNode.Level >= currNode.Level)
            {
                return getSameLevelNextNode(currNode, nextNode);
            }
            return null;
        }

        private void _treeView_MouseUp(object sender, MouseEventArgs e)
        {
            if(e.Button == System.Windows.Forms.MouseButtons.Right){
                if (_treeView.SelectedItems.Count > 0)
                {
                    TreeListViewItem node = _treeView.SelectedItems[0];
                    YmlItem item = (YmlItem)node.Tag;

                    TreeListViewItem preNode = getSameLevelPreNode(node, node);
                    bool isenable = false;
                    if (preNode != null)
                    {
                        isenable = true;
                    }
                    else
                    {
                        TreeListViewItem nextNode = getSameLevelNextNode(node, node);
                        if (nextNode != null)
                        {
                            isenable = true;
                        }
                    }
                    降级ToolStripMenuItem.Enabled = isenable;
                    升级ToolStripMenuItem.Enabled = item.Level > 0;
                }
            }
        }

        private void 复制ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string text = ymlEditor.SelectedText;
            if (text.Length > 0)
            {
                Clipboard.SetDataObject(text);
            }
        }

        private void 粘贴ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ymlEditor.Paste();            
        }

        private void 删除行ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int index = ymlEditor.GetFirstCharIndexOfCurrentLine();
            int line = ymlEditor.GetLineFromCharIndex(index);
            int length = ymlEditor.Lines[line].Length;
            ymlEditor.SelectionStart = index;
            ymlEditor.SelectionLength = length + 1;
            ymlEditor.SelectedText = "";
            ymlEditor.Focus();
        }

        private void 行注释ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int index = ymlEditor.GetFirstCharIndexOfCurrentLine();
            int line = ymlEditor.GetLineFromCharIndex(index);
            int start = ymlEditor.SelectionStart;
            string lineStr = ymlEditor.Lines[line];
            if(lineStr.TrimStart().StartsWith("#")){
                ymlEditor.SelectionStart = index + lineStr.IndexOf("#");
                ymlEditor.SelectionLength = 1;
                ymlEditor.SelectedText = "";
            }
            else
            {
                ymlEditor.SelectionStart = start;
                ymlEditor.SelectionLength = 0;
                ymlEditor.SelectedText = "#";
            }
            ymlEditor.Focus();
        }

        private void 剪切ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string text = ymlEditor.SelectedText;
            if (text.Length > 0)
            {
                ymlEditor.Cut();
            }            
        }

        /// <summary>自定义方法 --   
        ///  获取文本中(行和列)--光标--坐标位置的调用方法  
        /// </summary>  
        /// <param></param>  
        /// <returns></returns>  
        private void Ranks()
        {
            /*  得到光标行第一个字符的索引， 
             *  即从第1个字符开始到光标行的第1个字符索引*/
            int index = ymlEditor.GetFirstCharIndexOfCurrentLine();
            /*得到光标行的行号,第1行从0开始计算，习惯上我们是从1开始计算，所以+1。 */
            int line = ymlEditor.GetLineFromCharIndex(index) + 1;
            /*  SelectionStart得到光标所在位置的索引 
             *  再减去 
             *  当前行第一个字符的索引 
             *  = 光标所在的列数(从0开始)  */
            int column = ymlEditor.SelectionStart - index + 1;
            pos_label.Text = string.Format("行：{0}，列：{1}", line.ToString(), column.ToString());
        }

        private void ymlEditor_MouseDown(object sender, MouseEventArgs e)
        {
            Ranks();
        }

        private void btn_ok_Click(object sender, EventArgs e)
        {
            remoteCfgPath = stb_remote_dir.Text;
            monitorForm.getSessionConfig().CentralServerConfigDir = remoteCfgPath;
            AppConfig.Instance.SaveConfig(2);

            panel2.Visible = false;
        }

        private void btn_show_Click(object sender, EventArgs e)
        {
            panel2.Visible = true;
        }

        private void CentralServerConfigForm_DragDrop(object sender, DragEventArgs e)
        {
            try
            {
                String[] files = e.Data.GetData(DataFormats.FileDrop, false) as String[];
                YmlFile yml = null;
                FileInfo file = null;
                FileInfo firstFile = null;
                ListViewItem item = null;
                // Copy file from external application   
                foreach (string srcfile in files)
                {
                    try
                    {
                        file = new FileInfo(srcfile);                        
                        yml = new YmlFile();
                        yml.correct = true;
                        yml.localName = file.Name;
                        yml.localPath = file.DirectoryName.Replace("\\", "/") + "/";
                        yml.remoteName = "";
                        yml.remotePath = "";
                        yml.status = YmlFileState.NoModif;

                        if (!existFile(yml))
                        {
                            item = new ListViewItem();
                            item.Text = file.Name;
                            item.Tag = yml;
                            item.ImageIndex = 1;

                            if (null == firstFile)
                            {
                                firstFile = file;
                            }

                            listView1.Items.Add(item);
                        }                     
                    }
                    catch { }
                }

                if (null != firstFile)
                {
                    listView1.Items[0].Selected = true;
                }
            }
            catch (Exception e1)
            {
                MessageBox.Show(e1.Message, " Error ",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }  
        }

        private bool existFile(YmlFile yml)
        {
            YmlFile file = null;
            foreach (ListViewItem item in listView1.Items)
            {
                file = (YmlFile)item.Tag;
                if ((file.localPath + file.localName) == (yml.localPath + yml.localName))
                {
                    return true;
                }
            }
            return false;
        }

        private void 打开本地临时目录ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start(cfgDir);
        }

    }
}
