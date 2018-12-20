using AppMonitor.Bex;
using AppMonitor.Froms;
using AppMonitor.Nodel;
using log4net;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using Tamir.SharpSsh;
using Tamir.SharpSsh.jsch;
using YSTools;

namespace AppMonitor.Plugin
{
    public partial class SftpLinuxForm : Form
    {
        private static ILog logger = LogManager.GetLogger("LogFileAppender");

        public string dir = "", listViewTag = "Detail";
        SftpForm sftpForm = null;
        Session session = null;
        // ssh
        Channel m_Channel = null;
        SshUser user = null;
        SshShell shell = null;
        ChannelSftp sftpChannel = null;
        public static bool RUN_CUT = true;
        private bool success = false;
        public delegate void LoadFilesResult();
        private Queue<string[]> COPY_QUEUE = new Queue<string[]>();

        public SftpLinuxForm(SftpForm sftpForm, SshUser user)
        {
            InitializeComponent();
            this.sftpForm = sftpForm;
            this.user = user;
        }

        private void sftpLinuxForm_Load(object sender, EventArgs e)
        {
            splitContainer1.SplitterDistance = 0;

            listView2.View = View.Details;

            Connect();            
        }

        public void Connect()
        {
            shell = new SshShell(user.Host, user.UserName, YSEncrypt.DecryptB(user.Password, KeysUtil.PassKey));

            shell.Connect(user.Port);

            m_Channel = shell.getChannel();
            session = shell.getSession();

            sftpChannel = (ChannelSftp)session.openChannel("sftp");
            sftpChannel.connect();

            ThreadPool.QueueUserWorkItem((a) =>
            {
                string line = null;
                while (RUN_CUT && shell.ShellOpened)
                {
                    success = true;
                    logger.Debug("Successed...");
                    sftpForm.HideTool();

                    System.Threading.Thread.Sleep(100);
                    while ((line = m_Channel.GetMessage()) != null)
                    {
                        Console.WriteLine(line);
                    }
                }

                logger.Debug("Disconnecting...");
                Disconnection();
                logger.Debug("OK");
                
            });

            dir = sftpChannel.getHome();

            text_adress.Text = dir;

            LoadDirFilesToListView(dir);

            SetContentMenuItem(true);
        }

        public void Disconnection()
        {
            try
            {
                RUN_CUT = false;
                exit();

                if (null != shell)
                {
                    shell.Close();
                }
                if (null != m_Channel)
                {
                    m_Channel.disconnect();
                }
                if (null != sftpChannel)
                {
                    sftpChannel.disconnect();
                }
                logger.Debug("断开Ssh...OK");
            }
            catch (Exception ex)
            {
                logger.Error("断开链接异常：" + ex.Message, ex);
            }
        }

        public SshUser getSshUser()
        {
            return user;
        }

        public Object downloadFile(string src, string dst)
        {
            FileInfo file = new FileInfo(dst);
            if(file.Exists){
                string ext = file.Extension, path = null;
                for(int i = 1; i < 1000; i ++){
                    path = dst.Substring(0, dst.Length - ext.Length) + " " + i + ext;
                    file = new FileInfo(path);
                    if(!file.Exists){
                        dst = path;
                        break;
                    }
                }                
            }
            sftpChannel.get(src, dst);
            return null;
        }

        public void SendShell(string cmd)
        {
            this.BeginInvoke((MethodInvoker)delegate()
            {
                byte[] byteArray = System.Text.Encoding.Default.GetBytes(cmd + "\n");
                m_Channel.WriteBytes(byteArray);
            });
        }

        public void exit()
        {
            byte[] byteArray = System.Text.Encoding.Default.GetBytes("exit\n");
            m_Channel.WriteBytes(byteArray);
        }

        public void LoadDirFilesToListView(string path, LoadFilesResult result = null)
        {
            this.BeginInvoke((MethodInvoker)delegate()
            {
                try
                {
                    if (null == sftpChannel)
                    {
                        return;
                    }
                    ArrayList files = sftpChannel.ls(path);
                    if (files != null)
                    {
                        ChannelSftp.LsEntry file = null;
                        listView2.Items.Clear();
                        LargeImages.Images.Clear();
                        SmallImages.Images.Clear();

                        LargeImages.Images.Add(Properties.Resources.filen_64px);
                        LargeImages.Images.Add(Properties.Resources.folder_64px);
                        SmallImages.Images.Add(Properties.Resources.filen_16px);
                        SmallImages.Images.Add(Properties.Resources.folder_16px);

                        ListViewItem item = null;
                        ListViewItem.ListViewSubItem subItem = null;
                        List<ListViewItem> itemList = new List<ListViewItem>();
                        for (int i = 0; i < files.Count; i++)
                        {
                            object obj = files[i];
                            if (obj is ChannelSftp.LsEntry)
                            {
                                file = (ChannelSftp.LsEntry)obj;
                                if (file.getFilename() == ".")
                                {
                                    continue;
                                }

                                item = new ListViewItem();
                                item.Text = file.getFilename();
                                item.Tag = file;

                                if (file.getFilename() != "..")
                                {
                                    subItem = new ListViewItem.ListViewSubItem();
                                    subItem.Text = Utils.getFileSize(file.getAttrs().getSize());
                                    item.SubItems.Add(subItem);

                                    subItem = new ListViewItem.ListViewSubItem();
                                    subItem.Text = file.getAttrs().isDir() ? "文件夹" : file.getAttrs().isLink() ? "快捷方式" : getFileExt(file.getFilename());
                                    item.SubItems.Add(subItem);

                                    subItem = new ListViewItem.ListViewSubItem();
                                    subItem.Text = file.getAttrs().getMtimeString();
                                    item.SubItems.Add(subItem);

                                    subItem = new ListViewItem.ListViewSubItem();
                                    subItem.Text = file.getAttrs().getPermissionsString();
                                    item.SubItems.Add(subItem);

                                    subItem = new ListViewItem.ListViewSubItem();
                                    subItem.Text = getFileOwner(file.getLongname());
                                    item.SubItems.Add(subItem);

                                    item.ImageIndex = file.getAttrs().isDir() ? 1 : 0;
                                    if(file.getAttrs().isDir()){
                                        listView2.Items.Add(item);
                                    }
                                    else
                                    {
                                        itemList.Add(item);
                                    }
                                }
                                else
                                {
                                    subItem = new ListViewItem.ListViewSubItem();
                                    subItem.Text = "";
                                    item.SubItems.Add(subItem);
                                    subItem = new ListViewItem.ListViewSubItem();
                                    subItem.Text = "";
                                    item.SubItems.Add(subItem);
                                    subItem = new ListViewItem.ListViewSubItem();
                                    subItem.Text = "";
                                    item.SubItems.Add(subItem);
                                    subItem = new ListViewItem.ListViewSubItem();
                                    subItem.Text = "";
                                    item.SubItems.Add(subItem);
                                    subItem = new ListViewItem.ListViewSubItem();
                                    subItem.Text = "";
                                    item.SubItems.Add(subItem);
                                    item.ImageIndex = 1;
                                    listView2.Items.Add(item);
                                }
                            }
                        }
                        foreach (ListViewItem item2 in itemList)
                        {
                            listView2.Items.Add(item2);
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
                catch(Exception e) {
                    logger.Error("加载数据失败：" + e.Message, e);
                    if(!success){
                        sftpForm.CloseTab(this);
                    }                    
                }                
            });
        }

        public string getCurrDir()
        {
            if(!dir.EndsWith("/") && dir != "/"){
                return dir + "/";
            }
            return dir;
        }

        public ArrayList getDirFiles(string path)
        {
            ArrayList list = null;
            try
            {
                list = sftpChannel.ls(path);
            }catch(Exception e){
                //logger.Error("获取Linux目录下所有文件异常：" + e.Message, e);
            }
            return list;
        }

        public void RefreshFiles()
        {
            // 刷新
            LoadDirFilesToListView(dir);
        }

        private string getFileOwner(string str)
        {
            string user = "";
            if (null != str && str.Length > 5 && str.IndexOf(" ") != -1)
            {                
                string[] arrs = str.Split(' ');
                if(arrs.Length > 3){
                    int i = 0, j = 0;
                    foreach(string s in arrs){
                        if(!string.IsNullOrWhiteSpace(s)){
                            i++;
                            if(i >= 3){
                                user = arrs[j];
                                break;
                            }
                        }
                        j++;
                    }                    
                }
            }
            return user;
        }

        private string getFileExt(string filename)
        {
            string ext = "";
            if (null != filename && filename.IndexOf(".") != -1)
            {
                ext = filename.Substring(filename.LastIndexOf(".") + 1).ToUpper() + "文件";
            }
            return ext;
        }        

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int count = listView2.SelectedItems.Count;
            SetContentMenuItem(count == 0);

            if(count == 1){
                SetContentMenuItem2(true);
                ListViewItem row = listView2.SelectedItems[0];
                ChannelSftp.LsEntry entry = (ChannelSftp.LsEntry)row.Tag;
                if(entry.getAttrs().isDir()){
                    openToolStripMenuItem.Visible = true;
                    editToolStripMenuItem.Visible = false;
                }
                else
                {
                    openToolStripMenuItem.Visible = false;
                    editToolStripMenuItem.Visible = true;
                }
            }
            else if (count > 1)
            {
                SetContentMenuItem2(false);
            }
        }

        private void SetContentMenuItem(bool nulls)
        {
            viewTool2.Visible = nulls;
            newFolderToolStripMenuItem.Visible = nulls;
            refreshToolStripMenuItem.Visible = nulls;

            transferToolStripMenuItem.Visible = !nulls;
            copyToolStripMenuItem.Visible = !nulls;
            renameToolStripMenuItem.Visible = !nulls;
            deleteToolStripMenuItem.Visible = !nulls;
            openToolStripMenuItem.Visible = !nulls;
            editToolStripMenuItem.Visible = !nulls;
        }

        private void SetContentMenuItem2(bool view)
        {
            newFolderToolStripMenuItem.Visible = view;
            renameToolStripMenuItem.Visible = view;
            openToolStripMenuItem.Visible = view;
            editToolStripMenuItem.Visible = view;
        }

        private void text_adress_KeyUp(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter){
                ArrayList list = getDirFiles(text_adress.Text);
                if (list != null)
                {
                    LoadDirFilesToListView(text_adress.Text, () => {
                        dir = text_adress.Text;
                    });
                }
                else
                {
                    MessageBox.Show(this, "目录不存在", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            // 刷新
            LoadDirFilesToListView(dir);
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            // 上一层            
            OpenUpDir();            
        }

        #region 菜单事件

        private void refreshToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // 刷新
            LoadDirFilesToListView(dir);
        }

        private void transferToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int count = listView2.SelectedItems.Count;
            if (count > 0)
            {
                List<Object> fileList = new List<object>();
                foreach (ListViewItem item in listView2.SelectedItems)
                {
                    fileList.Add(item.Tag);
                }
                sftpForm.TransferFilesToLocal(fileList);
            }
        }

        private void newFolderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InputForm form = new InputForm("请输入文件夹名称", "", new InputForm.FormResult((name) => {
                if(!string.IsNullOrWhiteSpace(name)){

                    SendShell("mkdir -p " + getCurrDir() + Utils.getLinuxName(name));

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
            int count = listView2.SelectedItems.Count;
            if (count > 0)
            {
                ListViewItem row = listView2.SelectedItems[0];
                if (row != null)
                {
                    string oldName = row.Text;
                    ChannelSftp.LsEntry entry = (ChannelSftp.LsEntry)row.Tag;
                    string msg = "请输入文件夹的新名称";
                    if(!entry.getAttrs().isDir()){
                        msg = "请输入文件的新名称";
                    }
                    InputForm form = new InputForm(msg, oldName, new InputForm.FormResult((newName) =>
                    {
                        if (oldName != newName)
                        {
                            string dirs = getCurrDir();
                            string path1 = dirs + Utils.getLinuxName(oldName);
                            string path2 = dirs + Utils.getLinuxName(newName);
                            SendShell(string.Format("mv {0} {1}", path1, path2));

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
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int count = listView2.SelectedItems.Count;
            if (count > 0)
            {
                DialogResult dr = MessageBox.Show(this, "您确定要删除选择的文件或文件夹吗？", "警告", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                if(dr == System.Windows.Forms.DialogResult.OK){
                    string dirs = getCurrDir();
                    foreach (ListViewItem item in listView2.SelectedItems)
                    {
                        SendShell("rm -rf " + dirs + Utils.getLinuxName(item.Text));
                    }

                    ThreadPool.QueueUserWorkItem((a) =>
                    {
                        Thread.Sleep(500);
                        RefreshFiles();
                    });
                }                
            }
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int count = listView2.SelectedItems.Count;
            if (count > 0)
            {
                string dirs = getCurrDir();
                foreach (ListViewItem item in listView2.SelectedItems)
                {
                    COPY_QUEUE.Enqueue(new string[]{dirs, item.Text});
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
                for (int i = 0, k = COPY_QUEUE.Count; i < k; i++ )
                {
                    items = COPY_QUEUE.Dequeue();
                    path1 = items[0] + items[1];
                    path2 = getCurrDir();
                    SendShell(string.Format("cp {0} {1}", path1, path2));
                }
                pasteToolStripMenuItem.Enabled = false;

                ThreadPool.QueueUserWorkItem((a) =>
                {
                    Thread.Sleep(500);
                    RefreshFiles();
                });
            }
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (listView2.SelectedItems.Count > 0)
            {
                ListViewItem row = listView2.SelectedItems[0];
                ChannelSftp.LsEntry entry = (ChannelSftp.LsEntry)row.Tag;
                if (!entry.getAttrs().isDir())
                {
                    try
                    {
                        string resfile = getCurrDir() + entry.getFilename();
                        string targetfile = MainForm.TEMP_DIR + string.Format("{0}.file", DateTime.Now.ToString("MMddHHmmss"));
                        targetfile = targetfile.Replace("\\", "/");

                        TextEditorForm editor = new TextEditorForm();
                        editor.Show(this);
                        editor.LoadRemoteFile(new ShellForm(this), resfile, targetfile);
                    }
                    catch { }
                }
            }
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (listView2.SelectedItems.Count > 0)
            {
                ListViewItem row = listView2.SelectedItems[0];
                ChannelSftp.LsEntry entry = (ChannelSftp.LsEntry)row.Tag;
                if (entry.getAttrs().isDir())
                {
                    if (entry.getFilename() == "..")
                    {
                        // 上一层
                        OpenUpDir();
                    }
                    else
                    {
                        // 进入下一层
                        OpenDownDir(getCurrDir() + entry.getFilename());
                    }
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
            if(listViewTag == "Large"){
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
                    listView2.View = View.LargeIcon;
                }
                else if (tag == "Small")
                {
                    listView2.View = View.SmallIcon;
                }
                else if (tag == "List")
                {
                    listView2.View = View.List;
                }
                else if (tag == "Detail")
                {
                    listView2.View = View.Details;
                }
                listViewTag = tag;
            }
            catch (Exception e)
            {
                logger.Error("更改列表显示方式异常：" + e.Message, e);
            }            
        }
        #endregion

        

        private void splitContainer1_Resize(object sender, EventArgs e)
        {
            text_adress.Size = new Size(splitContainer1.Size.Width - 130, text_adress.Size.Height);
        }

        public SftpProgressMonitor TransfersToRemote(string id, string localPath, string remotePath, int mode, ProgressDelegate progress, TransfersEndDelegate end)
        {
            SftpProgressMonitor monitor = new MyProgressMonitor(id, progress, end);
            try
            {
                sftpChannel.put(localPath, remotePath, monitor, mode);
            }
            catch(Exception e) {
                Console.WriteLine(localPath + "================>" + remotePath);
                logger.Error("put文件到服务器异常：" + e.Message, e);
            }            
            return monitor;
        }

        public SftpProgressMonitor TransfersToLocal(string id, string localPath, string remotePath, int mode, ProgressDelegate progress, TransfersEndDelegate end)
        {
            SftpProgressMonitor monitor = new MyProgressMonitor(id, progress, end);                                   
            try
            {
                sftpChannel.get(remotePath, localPath, monitor, mode);
            }
            catch { } 
            return monitor;
        }

        private void listView2_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (listView2.SelectedItems.Count > 0)
            {
                ListViewItem row = listView2.SelectedItems[0];
                ChannelSftp.LsEntry entry = (ChannelSftp.LsEntry)row.Tag;
                if (entry.getAttrs().isDir())
                {
                    if (entry.getFilename() == "..")
                    {
                        // 上一层
                        OpenUpDir();
                    }
                    else
                    {
                        // 进入下一层
                        OpenDownDir(getCurrDir() + entry.getFilename());
                    }
                }
            }
        }

        public void OpenDownDir(string dirpath)
        {
            LoadDirFilesToListView(dirpath, () =>
            {
                dir = dirpath;
                text_adress.Text = dir;
            });
            
        }

        public void OpenUpDir()
        {
            if(dir != "/" && dir.Length > 1){
                if(dir.EndsWith("/")){
                    dir = dir.Substring(0, dir.Length - 1);
                }
                string dirpath = dir;
                int index = dirpath.LastIndexOf("/");
                if(index > 0){
                    dirpath = dirpath.Substring(0, index);
                } else if(index == 0){
                    dirpath = "/";                    
                }
                LoadDirFilesToListView(dirpath, () =>
                {
                    dir = dirpath;
                    text_adress.Text = dir;
                });
            }            
        }

        private void propertiesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (listView2.SelectedItems.Count == 1)
            {
                ListViewItem row = listView2.SelectedItems[0];
                ChannelSftp.LsEntry file = (ChannelSftp.LsEntry)row.Tag;

                new FileAttrForm(file, user, getCurrDir()).Show(this);
            }
        }

        private void listView2_MouseUp(object sender, MouseEventArgs e)
        {
            if (listView2.SelectedItems.Count > 0)
            {
                int index = listView2.SelectedIndices[0];
                string name = listView2.SelectedItems[0].Text;
                if (name == ".." && index == 0)
                {
                    listView2.ContextMenuStrip = null;
                    ThreadPool.QueueUserWorkItem((a) =>
                    {
                        Thread.Sleep(100);
                        this.BeginInvoke((MethodInvoker)delegate()
                        {
                            listView2.ContextMenuStrip = contextMenuStrip1;
                        });
                    });
                }
            }
        }
        

    }
}
