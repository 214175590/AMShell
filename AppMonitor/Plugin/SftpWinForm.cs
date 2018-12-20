using AppMonitor.Bex;
using AppMonitor.Froms;
using log4net;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace AppMonitor.Plugin
{
    public partial class SftpWinForm : Form
    {
        private static ILog logger = LogManager.GetLogger("LogFileAppender");

        public string listViewTag = "Detail";
        public string dir = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
        SftpForm sftpForm = null;
        public delegate void LoadFilesResult();
        private Queue<string[]> COPY_QUEUE = new Queue<string[]>();

        public SftpWinForm(SftpForm sftpForm)
        {
            InitializeComponent();
            this.sftpForm = sftpForm;
        }

        private void sftpWinForm_Load(object sender, EventArgs e)
        {
            splitContainer1.SplitterDistance = 0;
            listView1.View = View.Details;

            text_adress.Text = dir;

            RefreshFiles();

            SetContentMenuItem(true);
        }

        public void RefreshFiles()
        {
            LoadDirFilesToListView(dir);
        }

        public void LoadDirFilesToListView(string path, LoadFilesResult result = null)
        {
            this.BeginInvoke((MethodInvoker)delegate()
            {
                try
                {
                    DirectoryInfo dire = new DirectoryInfo(path);
                    if(dire.Exists){
                        listView1.Items.Clear();
                        LargeImages.Images.Clear();
                        SmallImages.Images.Clear();
                
                        FileInfo[] files = dire.GetFiles();
                        DirectoryInfo[] dires = dire.GetDirectories();
                        Icon icon = null;
                        ListViewItem item = null;
                        ListViewItem.ListViewSubItem subItem = null;
                        LargeImages.Images.Add(Properties.Resources.filen_64px);
                        LargeImages.Images.Add(Properties.Resources.folder_64px);
                        SmallImages.Images.Add(Properties.Resources.filen_16px);
                        SmallImages.Images.Add(Properties.Resources.folder_16px);
                        int index = 2;

                        item = new ListViewItem();
                        item.Text = "..";

                        subItem = new ListViewItem.ListViewSubItem();
                        subItem.Text = "";
                        item.SubItems.Add(subItem);

                        subItem = new ListViewItem.ListViewSubItem();
                        subItem.Text = "文件夹";
                        item.SubItems.Add(subItem);

                        subItem = new ListViewItem.ListViewSubItem();
                        subItem.Text = "";
                        item.SubItems.Add(subItem);

                        item.ImageIndex = 1;
                        listView1.Items.Add(item);

                        foreach (DirectoryInfo file in dires)
                        {
                            item = new ListViewItem();
                            item.Text = file.Name;
                            item.Tag = file;

                            subItem = new ListViewItem.ListViewSubItem();
                            subItem.Text = "";
                            item.SubItems.Add(subItem);

                            subItem = new ListViewItem.ListViewSubItem();
                            subItem.Text = "文件夹";
                            item.SubItems.Add(subItem);

                            subItem = new ListViewItem.ListViewSubItem();
                            subItem.Text = file.LastWriteTime.ToString("yyyy-MM-dd, HH:mm:ss");
                            item.SubItems.Add(subItem);
                            item.ImageIndex = 1;
                            listView1.Items.Add(item);
                            //Console.WriteLine(file.Name + " - " + file.ToString());
                        }
                        foreach(FileInfo file in files){
                            if(file.Extension == ".lnk"){
                                continue;
                            }

                            icon = Icon.ExtractAssociatedIcon(file.FullName);
                            LargeImages.Images.Add(icon.ToBitmap());
                            SmallImages.Images.Add(icon.ToBitmap());
                            item = new ListViewItem();
                            item.Text = file.Name;
                            item.Tag = file;

                            subItem = new ListViewItem.ListViewSubItem();
                            subItem.Text = Utils.getFileSize(file.Length);
                            item.SubItems.Add(subItem);

                            subItem = new ListViewItem.ListViewSubItem();
                            subItem.Text = file.Extension;
                            item.SubItems.Add(subItem);

                            subItem = new ListViewItem.ListViewSubItem();
                            subItem.Text = file.LastWriteTime.ToString("yyyy-MM-dd, HH:mm:ss");
                            item.SubItems.Add(subItem);
                            item.ImageIndex = index++;
                            listView1.Items.Add(item);
                            //Console.WriteLine(file.Name + " - " + file.ToString());
                        }
                        if (null != result)
                        {
                            result();
                        }
                    }
                    else
                    {
                        MessageBox.Show(this, "目录不存在", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception e)
                {
                    logger.Error("加载数据失败：" + e.Message, e);
                }
            });
        }

        public string getCurrDir()
        {
            dir = dir.Replace("\\", "/");
            if (!dir.EndsWith("/"))
            {
                return dir + "/";
            }
            return dir;
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int count = listView1.SelectedItems.Count;
            SetContentMenuItem(count == 0);

            if (count == 1)
            {
                SetContentMenuItem2(true);
            }
            else if (count > 1)
            {
                SetContentMenuItem2(false);
            }
        }

        private void SetContentMenuItem(bool nulls)
        {
            viewToolStripMenuItem.Visible = nulls;
            newFolderToolStripMenuItem.Visible = nulls;
            refreshToolStripMenuItem.Visible = nulls;

            transferToolStripMenuItem.Visible = !nulls;
            copyToolStripMenuItem.Visible = !nulls;
            renameToolStripMenuItem.Visible = !nulls;
            deleteToolStripMenuItem.Visible = !nulls;
            openToolStripMenuItem.Visible = !nulls;
        }

        private void SetContentMenuItem2(bool view)
        {
            newFolderToolStripMenuItem.Visible = view;
            renameToolStripMenuItem.Visible = view;
            openToolStripMenuItem.Visible = view;
        }

        private void text_adress_KeyUp(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter){
                DirectoryInfo dire = new DirectoryInfo(text_adress.Text);
                if (dire.Exists)
                {
                    string tempdir = text_adress.Text;                    
                    LoadDirFilesToListView(tempdir, () =>
                    {
                        dir = tempdir;
                    });
                }
                else
                {
                    MessageBox.Show(this, "目录不存在", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void OpenUpDir()
        {
            // 上一层
            DirectoryInfo dire = new DirectoryInfo(dir);
            if (dire.Parent != null && dire.Parent.Exists)
            {
                string tempdir = dire.Parent.FullName;
                LoadDirFilesToListView(tempdir, () =>
                {
                    text_adress.Text = tempdir;
                    dir = tempdir;
                });
            }
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            // 刷新
            RefreshFiles();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            OpenUpDir();
        }

        private void refreshToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // 刷新
            RefreshFiles();
        }

        private void transferToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int count = listView1.SelectedItems.Count;
            if (count > 0)
            {
                List<Object> fileList = new List<object>();
                foreach (ListViewItem item in listView1.SelectedItems)
                {
                    fileList.Add(item.Tag);
                }
                sftpForm.TransferFilesToRemote(fileList);
            }            
        }

        private void splitContainer1_Panel2_Resize(object sender, EventArgs e)
        {
            text_adress.Size = new Size(splitContainer1.Size.Width - 130, text_adress.Size.Height);
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int count = listView1.SelectedItems.Count;
            if (count == 1)
            {
                Object tag = listView1.SelectedItems[0].Tag;
                if(tag is DirectoryInfo){
                    DirectoryInfo dire = (DirectoryInfo)tag;
                    string tempdir = dire.FullName;
                    // 刷新
                    LoadDirFilesToListView(tempdir, () => {
                        dir = tempdir;
                        text_adress.Text = tempdir;
                    });
                }
                else if (tag is FileInfo)
                {
                    FileInfo file = (FileInfo)tag;
                    try
                    {
                        Process.Start(file.FullName);
                    }
                    catch { }
                }
            }
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int count = listView1.SelectedItems.Count;
            if (count == 1)
            {
                Object tag = listView1.SelectedItems[0].Tag;
                if (tag is FileInfo)
                {
                    FileInfo file = (FileInfo)tag;
                    try
                    {
                        Process.Start(file.FullName);
                    }
                    catch { }                    
                }
            }            
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int count = listView1.SelectedItems.Count;
            if (count > 0)
            {
                string dirs = getCurrDir();
                foreach (ListViewItem item in listView1.SelectedItems)
                {
                    COPY_QUEUE.Enqueue(new string[] { dirs, item.Text });
                }
                pasteToolStripMenuItem.Enabled = true;
            }
        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (COPY_QUEUE.Count > 0)
            {
                string[] items = null;
                string path1, path2;
                string currDir = getCurrDir();
                for (int i = 0, k = COPY_QUEUE.Count; i < k; i++)
                {
                    items = COPY_QUEUE.Dequeue();
                    path1 = items[0] + items[1];
                    path2 = currDir + items[1];
                    if (Utils.IsDir(path1))
                    {
                        Utils.CopyDir(path1, path2);
                    }
                    else
                    {
                        new FileInfo(path1).CopyTo(path2);
                    }
                }
                pasteToolStripMenuItem.Enabled = false;

                ThreadPool.QueueUserWorkItem((a) =>
                {
                    Thread.Sleep(500);
                    // 刷新
                    LoadDirFilesToListView(dir);
                });
            }
        }

        private void newFolderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InputForm form = new InputForm("请输入文件夹名称", "", new InputForm.FormResult((name) =>
            {
                if (!string.IsNullOrWhiteSpace(name))
                {
                    DirectoryInfo dire = new DirectoryInfo(getCurrDir() + name);
                    if(!dire.Exists){
                        dire.Create();
                    }
                    else
                    {
                        MessageBox.Show(this, "目录已存在");
                    }

                    ThreadPool.QueueUserWorkItem((a) =>
                    {
                        Thread.Sleep(500);
                        RefreshFiles();
                    });
                }
                else
                {
                    MessageBox.Show(this, "名称不能为空");
                }
            }));
            form.ShowDialog(this);
        }

        private void renameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int count = listView1.SelectedItems.Count;
            if (count == 1)
            {
                ListViewItem item = listView1.SelectedItems[0];
                Object tag = item.Tag;
                string msg = "请输入文件夹的新名称";
                if (tag is FileInfo)
                {
                    msg = "请输入文件的新名称";
                }
                string oldName = item.Text;
                InputForm form = new InputForm(msg, oldName, new InputForm.FormResult((newName) =>
                {
                    if (oldName != newName)
                    {
                        string dirs = getCurrDir();
                        string path1 = dirs + oldName;
                        string path2 = dirs + newName;
                        if (tag is FileInfo)
                        {
                            FileInfo file = new FileInfo(path2);
                            if (!file.Exists)
                            {
                                new FileInfo(path1).MoveTo(path2);
                            }
                        }
                        else if (tag is DirectoryInfo)
                        {
                            DirectoryInfo dire = new DirectoryInfo(path2);
                            if (!dire.Exists)
                            {
                                new DirectoryInfo(path1).MoveTo(path2);
                            }
                        }

                        ThreadPool.QueueUserWorkItem((a) =>
                        {
                            Thread.Sleep(500);
                            RefreshFiles();
                        });
                    }
                }));
                form.ShowDialog(this);
            }  
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int count = listView1.SelectedItems.Count;
            if (count == 1)
            {
                ListViewItem item = listView1.SelectedItems[0];
                Object tag = item.Tag;
                string path = getCurrDir() + item.Text;
                if (tag is FileInfo)
                {
                    FileInfo file = new FileInfo(path);
                    if (file.Exists)
                    {
                        file.Delete();
                    }
                }
                else if (tag is DirectoryInfo)
                {
                    DirectoryInfo dire = new DirectoryInfo(path);
                    if (dire.Exists)
                    {
                        dire.Delete(true);
                    }
                }

                ThreadPool.QueueUserWorkItem((a) =>
                {
                    Thread.Sleep(500);
                    RefreshFiles();
                });
            } 
        }

        private void propertiesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int count = listView1.SelectedItems.Count;
            if (count == 1)
            {
                ListViewItem item = listView1.SelectedItems[0];
                string path = getCurrDir() + item.Text;

                FileAttr.ShowFileProperties(path);
            }            
        }

        private void listView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                ListViewItem row = listView1.SelectedItems[0];
                int index = listView1.SelectedIndices[0];
                string name = row.Text;
                if(name == ".." && index == 0){
                    OpenUpDir();
                }
                else
                {
                    Object tag = row.Tag;
                    if (tag is DirectoryInfo)
                    {
                        string tempdir = ((DirectoryInfo)tag).FullName;
                        LoadDirFilesToListView(tempdir, () =>
                        {
                            dir = tempdir;
                            text_adress.Text = dir;
                        });
                    }
                    else if (tag is FileInfo)
                    {
                        string path = ((FileInfo)tag).FullName;
                        Process.Start(path);
                    }
                }
                
            }
        }

        private void listView1_MouseUp(object sender, MouseEventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                int index = listView1.SelectedIndices[0];
                string name = listView1.SelectedItems[0].Text;
                if (name == ".." && index == 0)
                {
                    listView1.ContextMenuStrip = null;
                    ThreadPool.QueueUserWorkItem((a) =>
                    {
                        Thread.Sleep(100);
                        this.BeginInvoke((MethodInvoker)delegate()
                        {
                            listView1.ContextMenuStrip = contextMenuStrip1;
                        });
                    });
                }
            }
        }

        private void ChangeView(object sender, EventArgs e)
        {
            ToolStripMenuItem c = (ToolStripMenuItem)sender;
            string tag = c.Tag.ToString();

            ChangeListView(tag);
        }

        private void toolStripSplitButton1_ButtonClick(object sender, EventArgs e)
        {
            string tag = listViewTag;
            if (listViewTag == "Large")
            {
                tag = "Small";
            }
            else if (listViewTag == "Small")
            {
                tag = "List";
            }
            else if (listViewTag == "List")
            {
                tag = "Detail";
            }
            else if (listViewTag == "Detail")
            {
                tag = "Large";
            }
            ChangeListView(tag);
        }

        private void ChangeListView(string tag)
        {
            try
            {
                largeIconTool.Checked = tag == "Large";
                largeIconTool2.Checked = tag == "Large";
                smallIconTool.Checked = tag == "Small";
                smallIconTool2.Checked = tag == "Small";
                listTool.Checked = tag == "List";
                listTool2.Checked = tag == "List";
                detailTool.Checked = tag == "Detail";
                detailTool2.Checked = tag == "Detail";

                if (tag == "Large")
                {
                    listView1.View = View.LargeIcon;
                }
                else if (tag == "Small")
                {
                    listView1.View = View.SmallIcon;
                }
                else if (tag == "List")
                {
                    listView1.View = View.List;
                }
                else if (tag == "Detail")
                {
                    listView1.View = View.Details;
                }
                listViewTag = tag;
            }
            catch (Exception e)
            {
                logger.Error("更改列表显示方式异常：" + e.Message, e);
            }
        }

    }
}
