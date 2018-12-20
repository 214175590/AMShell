using AppMonitor.Bex;
using AppMonitor.Model;
using AppMonitor.Nodel;
using FarsiLibrary.Win;
using log4net;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using Tamir.SharpSsh.jsch;
using YSTools;

namespace AppMonitor.Plugin
{
    public partial class SftpForm : CCWin.Skin_Metro
    {
        private static ILog logger = LogManager.GetLogger("LogFileAppender");
        SftpWinForm leftForm = null;
        SftpLinuxForm rightForm = null;
        SshUser user = null;
        private int idnum = 100000;
        private bool localToRemoteRun = false, remoteToLocalRun = false, transfering = false;
        private string remote_path = null;
        private delegate void CreateLinuxDirCallback();
        private delegate void GetItemCallback(TransferItem item);

        Queue<TransferItem> remoteQueue = new Queue<TransferItem>();
        Queue<TransferItem> localQueue = new Queue<TransferItem>();
        List<TransferItem> remoteList = new List<TransferItem>();
        List<TransferItem> localList = new List<TransferItem>();

        Dictionary<string, int> TIMEDIC = new Dictionary<string, int>();
        Dictionary<string, long> BYTEDIC = new Dictionary<string, long>();

        public SftpForm(SshUser user)
        {
            InitializeComponent();
            SkinUtil.SetFormSkin(this);
            this.user = user;
        }

        private void SftpForm_Load(object sender, EventArgs e)
        {
            LoadLeftForm();
            if(user != null){
                text_host.Text = user.Host;
                text_pass.Text = "";
                text_username.Text = user.UserName;
                text_port.Text = "" + user.Port;
                LoadRightForm(user);
            }
        }

        public void HideTool()
        {
            this.BeginInvoke((MethodInvoker)delegate()
            {
                text_host.Enabled = false;
                text_pass.Enabled = false;
                text_username.Enabled = false;
                text_port.Enabled = false;
                toolStripButton7.Enabled = false;

                if (null != rightForm)
                {
                    SshUser user = rightForm.getSshUser();
                    if (null != user)
                    {
                        status_info.Text = user.Host + "@" + user.UserName;
                    }
                }
                WriteLog2("Connect Success...\n");
            });
        }

        public void CloseTab(SftpLinuxForm form)
        {
            form.Disconnection();
            form.Close();
            panel2.Controls.Remove(form);
        }

        public void LoadRightForm(SshUser sshUser)
        {
            rightForm = new SftpLinuxForm(this, sshUser);
            rightForm.FormBorderStyle = FormBorderStyle.None;
            rightForm.TopLevel = false;
            rightForm.Dock = DockStyle.Fill;
            rightForm.Show();

            panel2.Controls.Add(rightForm);

            WriteLog2("Start Connect...\n");
        }

        public void LoadLeftForm()
        {
            leftForm = new SftpWinForm(this);
            leftForm.FormBorderStyle = FormBorderStyle.None;
            leftForm.TopLevel = false;
            leftForm.Dock = DockStyle.Fill;
            leftForm.Show();

            panel1.Controls.Add(leftForm);
        }

        public void StartL2R()
        {
            ThreadPool.QueueUserWorkItem((a) =>
            {
                localToRemoteRun = true;
                if (localQueue.Count > 0)
                {
                    while (localToRemoteRun)
                    {
                        try
                        {
                            if (!transfering)
                            {
                                Thread.Sleep(100);
                                RunLocalToRemote();
                            }                            
                        }
                        catch { }
                        Thread.Sleep(100);
                    }
                }                
                localToRemoteRun = false;
            });
        }

        public void StopL2R()
        {
            localToRemoteRun = false;
        }

        public void StartR2L()
        {
            ThreadPool.QueueUserWorkItem((a) =>
            {
                remoteToLocalRun = true;
                if (remoteQueue.Count > 0)
                {
                    while (remoteToLocalRun)
                    {
                        try
                        {
                            RunRemoteToLocal();
                        }
                        catch { }
                        Thread.Sleep(100);
                    }
                }                
                remoteToLocalRun = false;
            });
        }

        public void StopR2L()
        {
            remoteToLocalRun = false;
        }

        public void TransferFilesToRemote(List<Object> filesList)
        {
            // DirectoryInfo、FileInfo      
            string dir = rightForm.getCurrDir();
            FileInfo file = null;
            DirectoryInfo dire = null;
            foreach(Object obj in filesList){
                if (obj is DirectoryInfo)
                {
                    dire = (DirectoryInfo) obj;
                    ParseDireToQueue(dir, dire);
                }
                else if (obj is FileInfo)
                {
                    file = (FileInfo) obj;
                    ParseFileToQueue(dir, file);
                }
            }

            StartL2R();
        }

        private void ParseDireToQueue(string dir, DirectoryInfo dire)
        {
            FileInfo[] files = dire.GetFiles();
            foreach (FileInfo file1 in files)
            {
                ParseFileToQueue(dir + dire.Name + "/", file1);
            }
            DirectoryInfo[] dires = dire.GetDirectories();
            if (null != dires)
            {
                foreach (DirectoryInfo d in dires)
                {
                    ParseDireToQueue(dir + dire.Name + "/", d);
                }
            }
        }

        private void ParseFileToQueue(string dir, FileInfo file)
        {
            TransferItem item = new TransferItem();
            item.Id = "L2R" + (idnum++);
            item.Name = file.Name;
            item.LocalPath = file.FullName;
            item.RemotePath = dir + file.Name;
            item.Status = TransferStatus.Wait;
            item.Size = Utils.getFileSize(file.Length);
            item.Progress = 0;
            item.Speed = "0 kb/s";

            AddItemToListView(item);
            localQueue.Enqueue(item);
        }

        public void TransferFilesToLocal(List<Object> filesList)
        {
            //ChannelSftp.LsEntry  getDirFiles
            string local = leftForm.getCurrDir();
            string remote = rightForm.getCurrDir();
            Tamir.SharpSsh.jsch.ChannelSftp.LsEntry entry = null;
            foreach (Object obj in filesList)
            {
                if (obj is Tamir.SharpSsh.jsch.ChannelSftp.LsEntry)
                {
                    entry = (Tamir.SharpSsh.jsch.ChannelSftp.LsEntry)obj;
                    if(entry.getAttrs().isDir()){
                        ParseDirEntryToQueue(local, remote, entry);
                    }
                    else
                    {
                        ParseEntryToQueue(local, remote, entry);
                    }
                }
            }

            StartR2L();
        }

        private void ParseDirEntryToQueue(string local, string remote, Tamir.SharpSsh.jsch.ChannelSftp.LsEntry dirs)
        {
            remote = remote + dirs.getFilename() + "/";
            local = local + dirs.getFilename() + "/";
            ArrayList filesList = rightForm.getDirFiles(remote);
            Tamir.SharpSsh.jsch.ChannelSftp.LsEntry entry = null;
            foreach (var obj in filesList)
            {
                if (obj is Tamir.SharpSsh.jsch.ChannelSftp.LsEntry)
                {
                    entry = (Tamir.SharpSsh.jsch.ChannelSftp.LsEntry)obj;
                    if (entry.getAttrs().isDir())
                    {
                        if (!Utils.isLinuxRootPath(entry.getFilename()))
                        {
                            ParseDirEntryToQueue(local, remote, entry);
                        }                        
                    }
                    else
                    {
                        ParseEntryToQueue(local, remote, entry);
                    }
                }
            }
        }

        private void ParseEntryToQueue(string local, string remote, Tamir.SharpSsh.jsch.ChannelSftp.LsEntry file)
        {
            TransferItem item = new TransferItem();
            item.Id = "R2L" + (idnum++);
            item.Name = file.getFilename();
            item.LocalPath = local + file.getFilename();
            item.RemotePath = remote + file.getFilename();
            item.Status = TransferStatus.Wait;
            item.Size = Utils.getFileSize(file.getAttrs().getSize());
            item.Progress = 0;
            item.Speed = "0 kb/s";

            AddItemToListView(item);
            remoteQueue.Enqueue(item);
        }

        private void AddItemToListView(TransferItem obj)
        {
            ListViewItem item = new ListViewItem();
            item.Name = obj.Id;
            item.Tag = obj;
            item.Text = obj.Name;

            ListViewItem.ListViewSubItem subItem = new ListViewItem.ListViewSubItem();
            subItem.Text = obj.Status.ToString();
            item.SubItems.Add(subItem);

            subItem = new ListViewItem.ListViewSubItem();
            subItem.Text = obj.Progress + "%";
            item.SubItems.Add(subItem);

            subItem = new ListViewItem.ListViewSubItem();
            subItem.Text = obj.Size;
            item.SubItems.Add(subItem);

            subItem = new ListViewItem.ListViewSubItem();
            subItem.Text = obj.LocalPath;
            item.SubItems.Add(subItem);

            subItem = new ListViewItem.ListViewSubItem();
            subItem.Text = obj.RemotePath;
            item.SubItems.Add(subItem);

            subItem = new ListViewItem.ListViewSubItem();
            subItem.Text = obj.Speed;
            item.SubItems.Add(subItem);

            subItem = new ListViewItem.ListViewSubItem();
            subItem.Text = obj.TimeLeft;
            item.SubItems.Add(subItem);

            listView3.Items.Add(item);
        }

        private void getTransferItem(string flag, GetItemCallback callback)
        {
            TransferItem item = null;
            this.BeginInvoke((MethodInvoker)delegate()
            {
                if (flag == "L2R")
                {
                    TransferItem obj = localQueue.Count > 0 ? localQueue.Dequeue() : null;
                    if (null != obj)
                    {
                        if (checkTransferItem(obj))
                        {
                            item = obj;
                            localList.Add(item);
                            callback(item);
                        }
                        else
                        {
                            getTransferItem(flag, callback);
                        }
                    }
                    else
                    {
                        callback(null);
                    }
                }
                else
                {
                    TransferItem obj = remoteQueue.Count > 0 ? remoteQueue.Dequeue() : null;
                    if (null != obj)
                    {
                        if (checkTransferItem(obj))
                        {
                            item = obj;
                            remoteList.Add(item);
                            callback(item);
                        }
                        else
                        {
                            getTransferItem(flag, callback);
                        }
                    }
                    else
                    {
                        callback(null);
                    }
                }
            });
        }

        private bool checkTransferItem(TransferItem obj)
        {
            TransferItem ti = null;
            foreach(ListViewItem item in listView3.Items){
                ti = (TransferItem)item.Tag;
                if(ti.Id == obj.Id){
                    if (item.SubItems[1].Text == TransferStatus.Wait.ToString())
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        private void RunLocalToRemote() {
            getTransferItem("L2R", (item) => {
                if (item != null)
                {
                    transfering = true;
                    try
                    {
                        if (RemoteExist(item.RemotePath, item.Name))
                        {
                            this.BeginInvoke((MethodInvoker)delegate()
                            {
                                DialogResult dr = MessageBox.Show(this, item.RemotePath + "已存在，是否覆盖？", "警告", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                                if (dr == System.Windows.Forms.DialogResult.Yes)
                                {
                                    WriteLog("L2R", item.Id, item.LocalPath, item.RemotePath);
                                    SftpProgressMonitor monitor = rightForm.TransfersToRemote(item.Id, item.LocalPath, item.RemotePath, ChannelSftp.OVERWRITE, new ProgressDelegate(TransfersFileProgress), new TransfersEndDelegate(TransfersFileEnd));
                                }
                                else
                                {
                                    ChangeTransferItemStatus("L2R", item.Id, TransferStatus.Cancel);
                                }
                            });
                        }
                        else
                        {
                            createRemoteDir(item.RemotePath, () =>
                            {
                                WriteLog("L2R", item.Id, item.LocalPath, item.RemotePath);
                                SftpProgressMonitor monitor = rightForm.TransfersToRemote(item.Id, item.LocalPath, item.RemotePath, ChannelSftp.OVERWRITE, new ProgressDelegate(TransfersFileProgress), new TransfersEndDelegate(TransfersFileEnd));
                            });
                        }
                    }
                    catch (Exception ex)
                    {
                        logger.Error("传输文件的到服务器时异常：" + ex.Message);
                        ChangeTransferItemStatus("L2R", item.Id, TransferStatus.Failed);
                    }
                }
                else
                {
                    localToRemoteRun = false;
                }
            });            
        }

        public void TransfersFileProgress(string id, long precent, long c, long max, int elapsed)
        {
            try
            {
                int start = 0, end = Convert.ToInt32(DateTime.Now.ToString("ffff"));
                if(TIMEDIC.ContainsKey(id)){
                    start = TIMEDIC[id];
                    TIMEDIC[id] = end;
                } else {
                    TIMEDIC.Add(id, end);
                }
                long startByte = 0, endByte = c;
                if (BYTEDIC.ContainsKey(id))
                {
                    startByte = BYTEDIC[id];
                    BYTEDIC[id] = endByte;
                } else {
                    BYTEDIC.Add(id, endByte);
                }
                this.BeginInvoke((MethodInvoker)delegate()
                {
                    TransferItem obj = null;
                    foreach (ListViewItem item in listView3.Items)
                    {
                        if (item.Name == id)
                        {
                            obj = (TransferItem)item.Tag;
                        
                            obj.Progress = precent;
                            item.SubItems[1].Text = TransferStatus.Transfers.ToString();
                            item.SubItems[2].Text = precent + "%";
                            item.SubItems[6].Text = Utils.CalculaSpeed(startByte, endByte, max, start, end);
                            item.SubItems[7].Text = Utils.CalculaTimeLeft(startByte, endByte, max, start, end);
                            break;
                        }
                    }
                });
            }
            catch(Exception ex) {
                logger.Error("传输文件的到服务器时异常：" + ex.Message, ex);
                ChangeTransferItemStatus("R2L", id, TransferStatus.Failed);
            }
            
        }

        public void TransfersFileEnd(string id)
        {
            ChangeTransferItemStatus(id.Substring(0, 3), id, TransferStatus.Success);    
        }

        private void RunRemoteToLocal()
        {
            getTransferItem("R2L", (item) =>
            {
                if (item != null)
                {
                    transfering = true;
                    try
                    {
                        if (File.Exists(item.LocalPath))
                        {
                            this.BeginInvoke((MethodInvoker)delegate()
                            {
                                DialogResult dr = MessageBox.Show(this, item.LocalPath + "已存在，是否覆盖？", "警告", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                                if (dr == System.Windows.Forms.DialogResult.Yes)
                                {
                                    WriteLog("R2L", item.Id, item.LocalPath, item.RemotePath);
                                    SftpProgressMonitor monitor = rightForm.TransfersToLocal(item.Id, item.LocalPath, item.RemotePath, ChannelSftp.OVERWRITE, new ProgressDelegate(TransfersFileProgress), new TransfersEndDelegate(TransfersFileEnd));
                                }
                                else
                                {
                                    ChangeTransferItemStatus("R2L", item.Id, TransferStatus.Cancel);
                                }
                            });
                        }
                        else
                        {
                            FileInfo file = new FileInfo(item.LocalPath);
                            if (!file.Directory.Exists)
                            {
                                Utils.createParentDir(file.Directory);
                            }
                            WriteLog("R2L", item.Id, item.LocalPath, item.RemotePath);
                            SftpProgressMonitor monitor = rightForm.TransfersToLocal(item.Id, item.LocalPath, item.RemotePath, ChannelSftp.OVERWRITE, new ProgressDelegate(TransfersFileProgress), new TransfersEndDelegate(TransfersFileEnd));
                        }
                    }
                    catch (Exception ex)
                    {
                        logger.Error("传输文件的到服务器时异常：" + ex.Message, ex);
                        ChangeTransferItemStatus("R2L", item.Id, TransferStatus.Failed);
                    }
                }
                else
                {
                    remoteToLocalRun = false;
                }
            });
        }

        private void ChangeTransferItemStatus(string flag, string id, TransferStatus status)
        {
            if (id != null)
            {
                this.BeginInvoke((MethodInvoker)delegate()
                {
                    try
                    {
                        TransferItem obj = null;
                        foreach (ListViewItem item in listView3.Items)
                        {
                            if (item.Name == id)
                            {
                                obj = (TransferItem)item.Tag;
                                obj.Status = status;
                                item.SubItems[1].Text = status.ToString();
                                break;
                            }
                        }
                        List<TransferItem> list = flag == "L2R" ? localList : remoteList;
                        foreach (TransferItem item in list)
                        {
                            if (item.Name == id)
                            {
                                item.Status = status;
                                break;
                            }
                        }
                    }
                    catch { }

                    try
                    {
                        int count = 0;
                        foreach (ListViewItem item in listView3.Items)
                        {
                            if (item.SubItems[1].Text == "Success" || item.SubItems[1].Text == "Failed")
                            {
                                count++;
                            }
                        }
                        if (count == listView3.Items.Count)
                        {
                            if(id != null){
                                if (id.Substring(0, 3) == "L2R")
                                {
                                    rightForm.RefreshFiles();

                                    removeListViewItem("Success", "L2R");
                                }
                                else
                                {
                                    leftForm.RefreshFiles();

                                    removeListViewItem("Success", "R2L");
                                }
                            }
                            else
                            {
                                rightForm.RefreshFiles();
                                leftForm.RefreshFiles();
                            }
                        }
                    }
                    catch
                    {
                    }
                    WriteLog2(status.ToString() + "\n");
                    transfering = false;
                });
            }
        }

        public void removeListViewItem(string flag, string way)
        {
            if (flag == "All")
            {
                listView3.Items.Clear();
                if (way == "L2R")
                {
                    localList.Clear();
                }
                else if(way == "R2L")
                {
                    remoteList.Clear();
                }
                else
                {
                    localList.Clear();
                    remoteList.Clear();
                }
            }
            else
            {
                int count = 0;
                foreach (ListViewItem item in listView3.Items)
                {
                    if (item.SubItems[1].Text == flag)
                    {
                        listView3.Items.Remove(item);
                        count++;
                        break;
                    }
                }
                if (way == "L2R")
                {
                    foreach (TransferItem item in localList)
                    {
                        if (item.Status.ToString() == flag)
                        {
                            localList.Remove(item);
                            count++;
                            break;
                        }
                    }
                }
                else
                {
                    foreach (TransferItem item in remoteList)
                    {
                        if (item.Status.ToString() == flag)
                        {
                            remoteList.Remove(item);
                            count++;
                            break;
                        }
                    }
                }
                if (count > 0)
                {
                    removeListViewItem(flag, way);
                }
            }
        }

        private void RemoveToList(string id)
        {
            string way = id.Substring(0, 3);
            if (way == "L2R")
            {
                foreach (TransferItem item in localList)
                {
                    if(item.Id == id){
                        localList.Remove(item);
                        return;
                    }
                }
            }
            else if (way == "R2L")
            {
                foreach (TransferItem item in remoteList)
                {
                    if (item.Id == id)
                    {
                        remoteList.Remove(item);
                        return;
                    }
                }
            }
        }

        private void WriteLog(string flag, string id, string local, string remote)
        {
            try
            {
                string log = "";
                if (flag == "L2R")
                {
                    log = string.Format("【{0}】 - [{1}] Transfers File To {2}，{3} -> {4}   ", user.Host, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), "Remote", local, remote);
                }
                else
                {
                    log = string.Format("[{0} {1}] Transfers File To {2}，{3} -> {4}   ", user.Host, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), "Local", remote, local);
                }
                WriteLog2(log);
            }
            catch(Exception e) {
                logger.Error("格式化日志报错", e);
            }
        }

        private void WriteLog2(string msg)
        {
            try
            {
                this.BeginInvoke((MethodInvoker)delegate() {
                    logtext.AppendText(msg);

                    logtext.Focus();
                    logtext.SelectionStart = logtext.TextLength + 1000;
                    logtext.ScrollToCaret();
                });                
            }
            catch (Exception e)
            {
                logger.Error("显示日志报错:" + e.Message, e);
            }
        }

        private void SftpForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            SftpLinuxForm.RUN_CUT = false;
            StopL2R();
            StopR2L();
            if (null != rightForm)
            {
                rightForm.Disconnection();
                rightForm.Close();
                rightForm = null;
            }            
        }

        private bool RemoteExist(string path, string name, bool isdir = false)
        {
            string dir = path.Substring(0, path.Length - name.Length);
            ArrayList filesList = rightForm.getDirFiles(dir);
            if (null != filesList)
            {
                Tamir.SharpSsh.jsch.ChannelSftp.LsEntry entry = null;
                foreach (Object obj in filesList)
                {
                    if (obj is Tamir.SharpSsh.jsch.ChannelSftp.LsEntry)
                    {
                        entry = (Tamir.SharpSsh.jsch.ChannelSftp.LsEntry)obj;
                        if (entry.getFilename() == name)
                        {
                            if(isdir){
                                return entry.getAttrs().isDir();
                            }
                            else
                            {
                                return true;
                            }                            
                        }
                    }
                }
            }            
            return false;
        }

        private void createRemoteDir(string remotePath, CreateLinuxDirCallback callback)
        {
            try
            {
                string dir = Utils.getLinuxPathDir(remotePath);
                if (remote_path != dir)
                {
                    rightForm.SendShell("mkdir -p " + dir);
                    remote_path = dir;
                    ThreadPool.QueueUserWorkItem((a) => {
                        if (null != callback)
                        {
                            Thread.Sleep(300);
                            callback();
                        }
                    });                    
                }
                else if (null != callback)
                {
                    callback();
                }
            }
            catch { }
        }

        private void toolStripButton7_Click(object sender, EventArgs e)
        {
            string host = text_host.Text;
            string username = text_username.Text;
            string pass = text_pass.Text;
            string port = text_port.Text;

            IPAddress ip;
            if (IPAddress.TryParse(host, out ip))
            {
                if(string.IsNullOrWhiteSpace(username)){
                    MessageBox.Show(this, "请输入用户名");
                }
                else if (string.IsNullOrWhiteSpace(pass))
                {
                    MessageBox.Show(this, "请输入密码");
                }
                else if (string.IsNullOrWhiteSpace(port))
                {
                    MessageBox.Show(this, "请输入端口号");
                }
                else
                {
                    user.Host = host;
                    user.UserName = username;
                    user.Password = YSEncrypt.EncryptA(pass, KeysUtil.PassKey);
                    user.Port = Convert.ToInt32(port);

                    LoadRightForm(user);
                }
            }
            else
            {
                MessageBox.Show(this, "Host地址不正确");
            }
        }

        private void listView3_SelectedIndexChanged(object sender, EventArgs e)
        {
            int count = listView3.SelectedItems.Count;

            removeToolStripMenuItem.Enabled = count > 0;
            removeAllToolStripMenuItem.Enabled = listView3.Items.Count > 0;

            if(localToRemoteRun || remoteToLocalRun){
                
                restartFailedsToolStripMenuItem.Enabled = false;
                restartTransfersToolStripMenuItem.Enabled = false;
            }
            else
            {
                restartFailedsToolStripMenuItem.Enabled = true;
                restartTransfersToolStripMenuItem.Enabled = true;
            }
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                string text = logtext.SelectedText;
                if (text != "")
                {
                    Clipboard.SetText(text);
                }
            }
            catch (Exception ex)
            {
                logger.Error("复制时异常：" + ex.Message, ex);
            }
        }

        private void clearToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                logtext.Clear();
            }
            catch (Exception ex)
            {
                logger.Error("清除所有日志时异常：" + ex.Message, ex);
            }
        }

        private void selectAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                logtext.SelectAll();
            }
            catch (Exception ex)
            {
                logger.Error("选择全部时异常：" + ex.Message, ex);
            }
        }

        private void removeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (listView3.SelectedItems.Count > 0)
            {
                foreach (ListViewItem item in listView3.SelectedItems)
                {
                    TransferItem tfItem = (TransferItem)item.Tag;
                    if (null != tfItem)
                    {
                        RemoveToList(tfItem.Id);
                        listView3.Items.Remove(item);
                    }
                }
            }
        }

        private void removeAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            removeListViewItem("All", "");

            StopL2R();
            StopR2L();
        }

        private void restartFailedsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(localQueue.Count == 0 && localList.Count > 0){
                listView3.Items.Clear();
                foreach (TransferItem item in localList)
                {
                    if(item.Status == TransferStatus.Failed){
                        AddItemToListView(item);
                        localQueue.Enqueue(item);
                    }
                }
                localList.Clear();

                StartL2R();
            }
            else if (remoteQueue.Count == 0 && remoteList.Count > 0)
            {
                listView3.Items.Clear();
                foreach (TransferItem item in remoteList)
                {
                    if (item.Status == TransferStatus.Failed)
                    {
                        AddItemToListView(item);
                        remoteQueue.Enqueue(item);
                    }
                }
                remoteList.Clear();

                StartR2L();
            }
        }

        private void restartTransfersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (localQueue.Count == 0 && localList.Count > 0)
            {
                listView3.Items.Clear();
                foreach (TransferItem item in localList)
                {
                    if (item.Status != TransferStatus.Success)
                    {
                        AddItemToListView(item);
                        localQueue.Enqueue(item);
                    }
                }
                localList.Clear();

                StartL2R();
            }
            else if (remoteQueue.Count == 0 && remoteList.Count > 0)
            {
                listView3.Items.Clear();
                foreach (TransferItem item in remoteList)
                {
                    if (item.Status != TransferStatus.Success)
                    {
                        AddItemToListView(item);
                        remoteQueue.Enqueue(item);
                    }
                }
                remoteList.Clear();

                StartR2L();
            }
        }

    }
}
