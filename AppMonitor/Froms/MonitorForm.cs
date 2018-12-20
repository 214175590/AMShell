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
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using Tamir.SharpSsh;
using Tamir.SharpSsh.jsch;
using YSTools;

namespace AppMonitor.Froms
{
    public partial class MonitorForm : Form
    {
        private static ILog logger = LogManager.GetLogger("LogFileAppender");

        List<string> sshCmdList = new List<string>();
        List<string> sftpCmdList = new List<string>();
        int sshCmdIndex = 0;
        int sftpCmdIndex = 0;

        bool RUN_CUT = true;
        int GET_SSH_STEP = 0;
        string GET_SSH_CMD = "";
        string curr_path = "";
        StringBuilder GET_SSH_SB = new StringBuilder();

        SshShell shell = null;
        Session session = null;
        // ssh
        Channel m_Channel = null;
        SessionConfig config = null;
        // sftp
        ChannelSftp sftpChannel = null;

        FullScreenMonitorForm fullScreenForm = null;

        int timer_num = 0;
        TreeNode currSelectNode = null;
        RichTextBox currShellBox = null;

        public MonitorForm(SessionConfig _config)
        {
            config = _config;
            InitializeComponent();
        }

        private void MonitorForm_Load(object sender, EventArgs e)
        {
            this.FormClosed += MonitorForm_FormClosed;
            currShellBox = rtb_log;
            tstb_shell.TextBox.TabStop = false;

            adjustShellTextSize();
            timer1.Start();

            ((Action)delegate()
            {
                CheckParam();

                InitSsh();

            }).BeginInvoke(null, null);
        }

        protected override bool ProcessCmdKey(ref System.Windows.Forms.Message msg, Keys keyData)
        {
            if (keyData == Keys.Tab)
            {
                if (msg.HWnd == tstb_shell.TextBox.Handle)
                {
                    StartShowCandidate();
                    return true;
                }                
            }
            //如果想要焦点保持在原控件则返回true
            return false;
        }

        public SessionConfig getSessionConfig()
        {
            return config;
        }

        public ChannelSftp getSftp()
        {
            return sftpChannel;
        }

        void MonitorForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            //Disconnection();
        }

        // 自动调整面板
        public void adjustShellTextSize()
        {
            Size size = new Size(this.Size.Width - 95, 19);
            tstb_shell.Size = size;
            tstb_sftp.Size = size;

            toolStrip2.Location = toolStrip1.Location;

            rtb_sftp_log.Size = rtb_log.Size;

            left_panel.Size = new System.Drawing.Size(left_panel.Size.Width, (toolStrip1.Location.Y + toolStrip1.Size.Height + 6));
            int fwid = rtb_log.Size.Width - right_panel.Location.X;

            Control[] cons = right_panel.Controls.Find("WorkForm", true);
            if (null != cons)
            {
                right_panel.Size = new System.Drawing.Size(fwid * cons.Length, left_panel.Size.Height);
                int index = 0;
                foreach (Control ctl in cons)
                {
                    ctl.Size = new Size(fwid, left_panel.Size.Height);
                    ctl.Location = new Point(fwid * index, 0);
                    index++;
                }
            }

            tab_monitor.Refresh();
            tab_sftp.Refresh();
        }

        public void CheckParam()
        {
            SshSettingForm form = null;
            while (string.IsNullOrWhiteSpace(config.Host)
                || string.IsNullOrWhiteSpace(config.UserName)
                || string.IsNullOrWhiteSpace(config.Password))
            {
                form = new SshSettingForm();
                form.ShowDialog(this);
            }
        }

        #region SSH
        public void InitSsh()
        {
            try
            {
                ShowLogger(string.Format("In connection {1}#{0} ...", config.Host, config.UserName));

                shell = new SshShell(config.Host, config.UserName, YSEncrypt.DecryptB(config.Password, KeysUtil.PassKey));

                //shell.RedirectToConsole();
                shell.Connect(config.Port);

                m_Channel = shell.getChannel();

                session = shell.getSession();

                Channel sftpc = session.openChannel("sftp");
                sftpc.connect();
                sftpChannel = (ChannelSftp)sftpc;

                curr_path = sftpChannel.getHome();
                curr_path = Utils.PathEndAddSlash(curr_path);

                ThreadPool.QueueUserWorkItem((a) =>
                {
                    this.BeginInvoke((MethodInvoker)delegate()
                    {
                        tstb_shell.Enabled = true;
                        tstb_sftp.Enabled = true;

                        RenderMonitorItems();

                        RendeQuickCommandList();
                    });
                });

                ThreadPool.QueueUserWorkItem((a) =>
                {
                    string line = null;
                    while (RUN_CUT && shell.ShellOpened)
                    {
                        System.Threading.Thread.Sleep(100);
                        while ((line = m_Channel.GetMessage()) != null)
                        {
                            ShowLogger(line);
                        }
                    }

                    logger.Debug("Disconnecting...");
                    shell.Close();
                    logger.Debug("OK");
                });

                ThreadPool.QueueUserWorkItem((a) =>
                {
                    string line = null;
                    while (RUN_CUT && shell.ShellOpened)
                    {
                        System.Threading.Thread.Sleep(100);

                        while ((line = sftpChannel.GetMessage()) != null)
                        {
                            ShowSftpLogger(line);
                        }
                    }

                    logger.Debug("Disconnecting...");
                    shell.Close();
                    logger.Debug("OK");
                });

            }
            catch (Exception ex)
            {
                logger.Error("连接服务器异常：" + ex.Message, ex);
                ShowLogger(ex.TargetSite.Name + " " + ex.Message);
            }
        }

        public void Disconnection(bool needRemove = false)
        {
            try
            {
                RUN_CUT = false;
                SendShell("exit");

                if (null != shell)
                {
                    shell.Close();
                }                
                if (null != m_Channel && m_Channel.isConnected())
                {
                    m_Channel.disconnect();
                }
                if (null != sftpChannel && sftpChannel.isConnected())
                {
                    sftpChannel.disconnect();
                }
            }
            catch (Exception ex)
            {
                logger.Error("断开链接异常：" + ex.Message, ex);
            }
        }

        public void Reconnection()
        {
            Disconnection();

            InitSsh();
        }

        public void GetShellResult(string cmd, ShellResultDelegate shellResult, bool force = false)
        {
            if (tabControl1.SelectedIndex == 0 || GET_SSH_STEP != 0)
            {
                //return;
            }
            GET_SSH_SB.Clear();
            GET_SSH_CMD = cmd;
            GET_SSH_STEP = 1;
            RunShell(cmd, false, force);
            int timer = 100;
            ThreadPool.QueueUserWorkItem((a) =>
            {
                while (GET_SSH_STEP != 0 && timer > 0)
                {
                    Thread.Sleep(10);
                    timer--;
                }

                GET_SSH_STEP = 0;
                string result = GET_SSH_SB.ToString();
                GET_SSH_SB.Clear();
                shellResult(result);
            });
        }

        public void RunShell(string cmd, bool isview = true, bool force = false)
        {
            tabControl1.BeginInvoke((MethodInvoker)delegate()
            {
                if (tabControl1.SelectedIndex != 0 || force)
                {
                    sshCmdList.Add(cmd);
                    sshCmdIndex = sshCmdList.Count - 1;
                    SendShell(cmd, isview, force);
                }
            });                        
        }

        private void SendShell(string cmd, bool isview = true, bool force = false)
        {
            this.BeginInvoke((MethodInvoker)delegate()
            {
                if (isview && tabControl1.SelectedIndex != 0)
                {
                    tabControl1.SelectedIndex = 0;
                }
                byte[] byteArray = System.Text.Encoding.Default.GetBytes(cmd + "\n");
                m_Channel.WriteBytes(byteArray);
            });
        }

        public void ShowLogger(string line)
        {
            this.BeginInvoke((MethodInvoker)delegate()
            {
                try
                {
                    line = line.Replace("\r\r", "");
                    if (!line.EndsWith("\n"))
                    {
                        line += "\n";
                    }
                    List<Message> msgList = new List<Message>();
                    string curr = "";
                    if (sshCmdList.Count > 0)
                    {
                        curr = sshCmdList[sshCmdList.Count - 1];
                    }
                    // 
                    if (line.StartsWith(curr + "\r\n"))
                    {
                        if (GET_SSH_CMD == curr && GET_SSH_STEP == 1)
                        {
                            GET_SSH_STEP = 2;
                            GET_SSH_SB.Append(line);
                        }
                        else
                        {
                            string str1 = line.Substring(0, (curr + "\r\n").Length);
                            msgList.Add(new Message()
                            {
                                Text = str1,
                                Color = Color.Red
                            });
                            MessageUtils.FormatMessage(msgList, line.Substring((curr + "\r\n").Length));
                        }
                    }
                    else
                    {
                        if (GET_SSH_STEP == 2)
                        {
                            GET_SSH_SB.Append(line);
                            if(line.IndexOf("]$") != -1){
                                GET_SSH_STEP = 0;
                            }
                        }
                        else
                        {
                            MessageUtils.FormatMessage(msgList, line);
                        }
                    }
                    foreach (Message msg in msgList)
                    {
                        if (msg != null && msg.Text != null)
                        {
                            rtb_log.SelectionColor = msg.Color;
                            rtb_log.SelectionBackColor = msg.BackColor;
                            rtb_log.AppendText(msg.Text);
                        }
                    }

                    rtb_log.Focus();
                    rtb_log.SelectionStart = rtb_log.TextLength + 1000;
                    rtb_log.ScrollToCaret();
                    tstb_shell.Focus();

                    if (line == "connect Auth fail\n")
                    {
                        InputSshPwdForm form = new InputSshPwdForm(new InputSshPwdForm.WritePwd(SetSshPwdConnect), config.Host, config.UserName);
                        form.ShowDialog(this);
                    }
                }
                catch (Exception ex)
                {
                    logger.Error("显示SSH结果异常：" + ex.Message, ex);
                }
            });
        }

        public void SetSshPwdConnect(string pwd, bool remenberPwd)
        {
            config.Password = YSEncrypt.EncryptA(pwd, KeysUtil.PassKey);
            if (remenberPwd)
            {
                config.RemenberPwd = true;
                AppConfig.Instance.SaveConfig(2);
            }

            ((Action)delegate()
            {
                InitSsh();
            }).BeginInvoke(null, null);
        }

        public void ShowSftpLogger(string line)
        {
            this.BeginInvoke((MethodInvoker)delegate()
            {
                try
                {
                    line = line.Replace("\r\r", "");
                    if (!line.EndsWith("\n"))
                    {
                        line += "\n";
                    }
                    List<Message> msgList = new List<Message>();
                    string curr = "";
                    if (sftpCmdList.Count > 0)
                    {
                        curr = sftpCmdList[sftpCmdList.Count - 1];
                    }
                    if (line == (curr + "\n"))
                    {
                        msgList.Add(new Message()
                        {
                            Text = line,
                            Color = Color.Red
                        });
                    }
                    else
                    {
                        MessageUtils.FormatMessage(msgList, line);
                    }
                    foreach (Message msg in msgList)
                    {
                        if (msg != null && msg.Text != null)
                        {
                            rtb_sftp_log.SelectionColor = msg.Color;
                            rtb_sftp_log.SelectionBackColor = msg.BackColor;
                            rtb_sftp_log.AppendText(msg.Text);
                        }
                    }

                    rtb_sftp_log.Focus();
                    rtb_sftp_log.SelectionStart = rtb_sftp_log.TextLength + 1000;
                    rtb_sftp_log.ScrollToCaret();
                    tstb_sftp.Focus();
                }
                catch (Exception ex)
                {
                    logger.Error("显示SFTP结果异常：" + ex.Message, ex);
                }
            });
        }

        private void tstb_shell_Enter(object sender, EventArgs e)
        {
            string text = tstb_shell.Text;
            if (text == "在此输入Shell指令")
            {
                tstb_shell.ForeColor = Color.Black;
                tstb_shell.Text = "";
            }
        }

        private void tstb_shell_Leave(object sender, EventArgs e)
        {
            string text = tstb_shell.Text;
            if (string.IsNullOrWhiteSpace(text))
            {
                tstb_shell.ForeColor = Color.DarkGray;
                tstb_shell.Text = "在此输入Shell指令";
            }
        }

        private void tstb_shell_KeyUp(object sender, KeyEventArgs e)
        {
            string cmd = "";
            if (e.KeyCode == Keys.Enter)
            {
                string currCmd = tstb_shell.Text;
                if (listBox1.Visible)
                {
                    SureListBoxChooseItem();
                    return;
                }
                else
                {
                    if (currCmd == "exit")
                    {
                        foreach (KeyValuePair<FATabStripItem, MonitorForm> item in MainForm.TAB_MONITOR)
                        {
                            if (item.Value == this)
                            {
                                ThreadPool.QueueUserWorkItem((a) =>
                                {
                                    Program.MAIN.CloseFaTab(item.Key);
                                });
                                break;
                            }
                        }
                    }
                    else if (currCmd.TrimStart().StartsWith("tailf ") || currCmd.TrimStart().StartsWith("tail "))
                    {
                        int index = currCmd.Trim().LastIndexOf(" ");
                        string path = currCmd.Substring(index + 1);

                    }                                           
                    else
                    {
                        RunShell(currCmd, true, true);
                        if (currCmd.TrimStart().StartsWith("cd "))
                        {
                            //curr_path = "":
                            string path = currCmd.Replace("cd ", "").Trim();
                            curr_path = getCdPath(path);
                            sftpChannel.cd(curr_path);
                        } 
                    }
                    tstb_shell.Text = "";
                }                
            }
            else if (e.KeyCode == Keys.Escape)
            {
                if (null != fullScreenForm)
                {
                    fullScreenForm.Exit();
                }
            }            
            else if (e.KeyCode == Keys.Up)
            {
                if(listBox1.Visible){
                    if (listBox1.SelectedIndex > 0)
                    {
                        listBox1.SelectedIndex = listBox1.SelectedIndex - 1;
                    }
                }
                else if (sshCmdIndex > 0 && sshCmdIndex < sshCmdList.Count)
                {
                    cmd = sshCmdList[--sshCmdIndex];
                }
            }
            else if (e.KeyCode == Keys.Down)
            {
                if (listBox1.Visible)
                {
                    if (listBox1.SelectedIndex < listBox1.Items.Count - 1)
                    {
                        listBox1.SelectedIndex = listBox1.SelectedIndex + 1;
                    }
                }
                else if (sshCmdIndex < (sshCmdList.Count - 1))
                {
                    cmd = sshCmdList[++sshCmdIndex];
                }
            }

            if (cmd != "")
            {
                tstb_shell.Text = cmd;
                tstb_shell.Select(tstb_shell.TextLength + cmd.Length, 0);//光标定位到文本最后
                tstb_shell.ScrollToCaret();//滚动到光标处
                tstb_shell.Focus();//获取焦点
            }
        }

        private string getCdPath(string path)
        {
            string disPath = curr_path;
            if (path.StartsWith("/"))
            {
                try
                {
                    ArrayList vv = sftpChannel.ls(path);
                    if (vv.Count > 1)
                    {
                        disPath = Utils.PathEndAddSlash(path);
                    }
                }
                catch { }
            }
            else if (path.StartsWith("~/"))
            {
                path = Utils.PathEndAddSlash(sftpChannel.getHome()) + path.Substring(2);
                try
                {
                    ArrayList vv = sftpChannel.ls(path);
                    if (vv.Count > 1)
                    {
                        disPath = Utils.PathEndAddSlash(path);
                    }
                }
                catch { }
            }
            else if (path == "~")
            {
                disPath = Utils.PathEndAddSlash(sftpChannel.getHome());
            }
            else if (path == "..")
            {
                if (disPath != "/")
                {
                    if (disPath.EndsWith("/"))
                    {
                        disPath = disPath.Substring(0, disPath.Length - 1);
                    }
                    disPath = Utils.PathEndAddSlash(disPath.Substring(0, disPath.LastIndexOf("/")));
                }
            }
            else
            {          
                try
                {
                    if (path.StartsWith("./"))
                    {
                        path = path.Substring(2);
                    } 
                    path = disPath + path;

                    ArrayList vv = sftpChannel.ls(path);
                    if (vv.Count > 1)
                    {
                        disPath = Utils.PathEndAddSlash(path);
                    }
                }
                catch { }
            }
            return disPath;
        }
        #endregion

        public void RenderMonitorItems()
        {
            if (null != config.MonitorConfigList && config.MonitorConfigList.Count > 0)
            {
                MonitorBaseForm workForm = null;
                MonitorItemConfig itemConfig = null;
                TreeNode node = null;
                TreeNode[] nodes = null;
                int iceindex = 0, nginxindex = 0;
                for (int i = 0, k = config.MonitorConfigList.Count; i < k; i++)
                {
                    itemConfig = config.MonitorConfigList[i];                    

                    node = new TreeNode();                    
                    node.ImageIndex = 0;
                    node.SelectedImageIndex = 0;
                    node.ContextMenuStrip = treeNodeConMenu;
                    
                    if (null != itemConfig.spring)
                    {
                        itemConfig.spring.RunStatus = RunState.NoCheck;
                        node.Name = "task-" + itemConfig.spring.Uuid;
                        workForm = new SpringBootMonitorForm(this, config, itemConfig);
                        workForm.Tag = "sp-" + itemConfig.spring.Uuid;
                        node.Text = itemConfig.spring.AppName;
                    }
                    else if (null != itemConfig.tomcat)
                    {
                        itemConfig.tomcat.RunStatus = RunState.NoCheck;
                        node.Name = "task-" + itemConfig.tomcat.Uuid;
                        workForm = new TomcatMonitorForm(this, config, itemConfig);
                        workForm.Tag = "to-" + itemConfig.tomcat.Uuid;
                        node.Text = itemConfig.tomcat.TomcatName;
                    }
                    else if (null != itemConfig.nginx)
                    {
                        itemConfig.nginx.RunStatus = RunState.NoCheck;
                        node.Name = "task-" + itemConfig.nginx.Uuid;
                        workForm = new NginxMonitorForm(this, config, itemConfig, nginxindex);
                        workForm.Tag = "ng-" + itemConfig.nginx.Uuid;
                        node.Text = itemConfig.nginx.NginxName;
                    }
                    else if (null != itemConfig.ice)
                    {
                        itemConfig.ice.RunStatus = RunState.NoCheck;
                        node.Name = "task-" + itemConfig.ice.Uuid;
                        workForm = new IceMonitorForm(this, config, itemConfig, iceindex++);
                        workForm.Tag = "ng-" + itemConfig.ice.Uuid;
                        node.Text = itemConfig.ice.AppName;
                    }
                    workForm.Name = "WorkForm";
                    workForm.TopLevel = false;
                    workForm.Visible = true;
                    workForm.Location = new Point(workForm.Size.Width + (i + 1), 0);

                    nodes = treeView1.Nodes.Find(node.Name, false);
                    if (null != nodes && nodes.Length > 0)
                    {
                        nodes[0].Text = node.Text;
                        workForm = null;
                        node = null;
                        continue;
                    }
                    else
                    {
                        node.Tag = workForm;
                        node.ToolTipText = node.Text;
                        if (null == currSelectNode)
                        {
                            currSelectNode = node;
                        }

                        treeView1.Nodes.Add(node);

                        right_panel.Controls.Add(workForm);
                    }                    
                }
                treeView1.SelectedNode = currSelectNode;
            }
        }

        public void RendeQuickCommandList()
        {
            toolStrip_more_sh.DropDownItems.Clear();
            if (config.ShellList.Count == 0)
            {
                DefaultConfig.InitDefaultShellList(config.ShellList);
            }
            ToolStripMenuItem menuItem = null;
            int index = 0;
            string shell = null;
            foreach (string cmd in config.ShellList)
            {
                shell = cmd.Replace("\n", "&");
                menuItem = new ToolStripMenuItem();
                menuItem.Text = shell;
                menuItem.Tag = index++;
                menuItem.Click += run_custom_script;
                toolStrip_more_sh.DropDownItems.Add(menuItem);
            }
        }

        #region 显示区域右键菜单事件
        public void CallCopy()
        {
            复制ToolStripMenuItem_Click(null, null);
        }

        private void 复制ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                string text = currShellBox.SelectedText;
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

        public void CallPaste()
        {
            粘贴ToolStripMenuItem_Click(null, null);
        }

        private void 粘贴ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                string text = Clipboard.GetText();
                if (text != "")
                {
                    if (currShellBox.Name == "rtb_log")
                    {
                        if (tstb_shell.Text == "在此输入Shell指令")
                        {
                            tstb_shell.ForeColor = Color.Black;
                            tstb_shell.Text = "";
                        }
                        tstb_shell.AppendText(text);
                    }
                    else if (currShellBox.Name == "rtb_sftp_log")
                    {
                        if (tstb_sftp.Text == "在此输入Sftp指令")
                        {
                            tstb_sftp.ForeColor = Color.Black;
                            tstb_sftp.Text = "";
                        }
                        tstb_sftp.AppendText(text);
                    }
                }
            }
            catch (Exception ex)
            {
                logger.Error("粘贴时异常：" + ex.Message, ex);
            }
        }        

        private void copyPasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            复制ToolStripMenuItem_Click(sender, e);

            粘贴ToolStripMenuItem_Click(sender, e);
        }

        public void CallFind()
        {
            findToolStripMenuItem_Click(null, null);
        }

        private void findToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TextFindForm form = new TextFindForm(
            new TextFindForm.GetContentMethod(() =>
            {
                return currShellBox.Text;
            }), 
            new TextFindForm.FindCallback((str, index) =>
            {
                string cont = currShellBox.Text;
                int start = cont.IndexOf(str, index);
                if (start != index && start != -1)
                {
                    index = start;
                }

                currShellBox.SelectionStart = index;
                currShellBox.ScrollToCaret();

                currShellBox.Select(index, str.Length);
                currShellBox.Focus();
            }));
            form.TopMost = true;
            form.Show(this);
        }

        private void selectAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                currShellBox.SelectAll();
            }
            catch (Exception ex)
            {
                logger.Error("选择全部时异常：" + ex.Message, ex);
            }
        }

        public void CallFullScreen()
        {
            fullScreenToolStripMenuItem_Click(null, null);
        }

        private void fullScreenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (null == fullScreenForm)
            {
                fullScreenForm = new FullScreenMonitorForm(this);
                fullScreenForm.Show();
            }
            else
            {
                fullScreenForm.Exit();
            }
        }

        public void ExitFullScreen()
        {
            fullScreenForm = null;
            foreach (KeyValuePair<FATabStripItem, MonitorForm> item in MainForm.TAB_MONITOR)
            {
                if (item.Value == this)
                {
                    item.Key.Controls.Add(this);
                    break;
                }
            }
        }

        private void rtb_log_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                if (null != fullScreenForm)
                {
                    fullScreenForm.Exit();
                }
            }
            currShellBox = rtb_log;
        }

        private void tabControl1_KeyUp(object sender, KeyEventArgs e)
        {
            rtb_log_KeyUp(sender, e);
        }
        #endregion

        private void NewItemMenuItemClick(object sender, EventArgs e)
        {
            MonitorItemForm form = null;
            ToolStripMenuItem item = sender as ToolStripMenuItem;
            if (item.Name.StartsWith("spring"))
            {
                form = new MonitorItemForm(this, 0, config);
            }
            else if (item.Name.StartsWith("tomcat"))
            {
                form = new MonitorItemForm(this, 1, config);
            }
            else if (item.Name.StartsWith("nginx"))
            {
                form = new MonitorItemForm(this, 2, config);
            }
            else if (item.Name.StartsWith("iceSrv"))
            {
                form = new MonitorItemForm(this, 3, config);
            }

            if (null != form)
            {
                form.ShowDialog(this);

            }

            // TODO
            RenderMonitorItems();

            if(treeView1.Nodes.Count == 1){
                tabControl1.SelectedIndex = 0;
                tabControl1.SelectedIndex = 2;
            }
        }

        private void rtb_log_KeyDown(object sender, KeyEventArgs e)
        {
            if (!e.Control && !e.Alt && !e.Shift)
            {
                tstb_shell.Focus();
                string chars = KeysUtil.getKeyChar(e.KeyValue, e.Shift);
                if (!string.IsNullOrWhiteSpace(chars))
                {
                    tstb_shell.AppendText(chars.ToLower());
                }
            }

            else if (e.Control && e.KeyCode == Keys.F)
            {
                findToolStripMenuItem_Click(null, null);
            }
            else if (e.Control && e.KeyCode == Keys.C)
            {
                复制ToolStripMenuItem_Click(null, null);
            }
            else if (e.Control && e.KeyCode == Keys.V)
            {
                粘贴ToolStripMenuItem_Click(null, null);
            }
            else if (e.Control && e.KeyCode == Keys.A)
            {
                selectAllToolStripMenuItem_Click(null, null);
            }
        }

        private void run_custom_script(object sender, EventArgs e)
        {
            ToolStripMenuItem item = sender as ToolStripMenuItem;
            if (null != item)
            {
                string script = item.Text;
                if (script.EndsWith("&"))
                {
                    RunShell(script.Substring(0, script.Length - 1), true, true);
                }
                else
                {
                    tstb_shell.AppendText(script);
                }
            }
        }

        private void newQuickConmandToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CustomScriptForm form = new CustomScriptForm(config);
            form.ShowDialog(this);

            RendeQuickCommandList();
        }

        private void quickShellManageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            QuickCommandManageForm form = new QuickCommandManageForm(config);
            form.ShowDialog(this);

            RendeQuickCommandList();
        }

        private void tabControl1_SizeChanged(object sender, EventArgs e)
        {
            adjustShellTextSize();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (timer_num < 2)
            {
                timer_num++;
                adjustShellTextSize();
            }
        }

        public void ShowContentMenu(Control cont, int x, int y)
        {
            treeNodeConMenu.Show(cont, x, y);
        }

        private void editItemToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TreeNode node = treeView1.SelectedNode;
            if (node != null)
            {
                string name = node.Name;
                string uuid = name.Substring(5);
                MonitorItemConfig itemConfig = null;
                if (!string.IsNullOrWhiteSpace(uuid))
                {
                    itemConfig = Utils.getMonitorItemConfig(config.MonitorConfigList, uuid);
                    int index = Utils.getMonitorItemIndex(itemConfig);
                    if (null != itemConfig)
                    {
                        MonitorItemForm itemForm = new MonitorItemForm(this, index, config, itemConfig);
                        itemForm.ShowDialog(this);

                        MonitorBaseForm workForm = node.Tag as MonitorBaseForm;
                        if (null != workForm)
                        {
                            workForm.ReflushMonitorItem();
                        }

                        RenderMonitorItems();
                    }
                }
            }
        }

        private void removeItemToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TreeNode node = treeView1.SelectedNode;
            if (node != null)
            {
                DialogResult dr = MessageBox.Show("确认删除此项吗？", "提示", MessageBoxButtons.OKCancel);
                if (dr == DialogResult.OK)
                {
                    //用户选择确认的操作
                    MonitorBaseForm workForm = node.Tag as MonitorBaseForm;
                    if (null != workForm)
                    {
                        workForm.CloseForm();
                    }
                    string name = node.Name;
                    int index = Convert.ToInt32(name.Substring(5));
                    treeView1.Nodes.Remove(node);
                    if (index >= 0)
                    {
                        config.MonitorConfigList.RemoveAt(index);

                        AppConfig.Instance.SaveConfig(2);
                    }
                }
            }
        }

        #region sftp
        private void tstb_sftp_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter)
            {
                return;
            }
            string cmd = tstb_sftp.Text;

            if (string.IsNullOrWhiteSpace(cmd))
            {
                return;
            }
            tstb_sftp.Text = "";

            RunSftpShell(cmd);
        }

        private void sftp_quick_click(object sender, EventArgs e)
        {
            ToolStripMenuItem item = (ToolStripMenuItem)sender;
            if (null != item)
            {
                string cmd = item.Text;
                if (cmd.EndsWith("&"))
                {
                    cmd = cmd.Substring(0, cmd.Length - 1);
                    RunSftpShell(cmd);
                }
                else
                {
                    tstb_sftp.Text = cmd;
                }
            }
        }

        private void sftp_text_enter(object sender, EventArgs e)
        {
            string text = tstb_sftp.Text;
            if (text == "在此输入Sftp指令")
            {
                tstb_sftp.ForeColor = Color.Black;
                tstb_sftp.Text = "";
            }
        }

        private void sftp_text_leave(object sender, EventArgs e)
        {
            string text = tstb_sftp.Text;
            if (string.IsNullOrWhiteSpace(text))
            {
                tstb_sftp.ForeColor = Color.DarkGray;
                tstb_sftp.Text = "在此输入Sftp指令";
            }
        }

        public Object RunSftpShell(string cmd, bool isview = true, bool log = true)
        {
            sftpCmdList.Add(cmd);
            sftpCmdIndex = sftpCmdList.Count - 1;
            if (isview && tabControl1.SelectedIndex != 1)
            {
                tabControl1.SelectedIndex = 1;
            }
            return SendSftpShell(cmd, log);
        }

        // 处理sftp指令
        private Object SendSftpShell(string cmd, bool log = true)
        {
            List<string> cmds = new List<string>();
            string[] cmdArr = cmd.Split(' ');
            if (null != cmdArr)
            {
                foreach (string s in cmdArr)
                {
                    if (!string.IsNullOrWhiteSpace(s))
                    {
                        cmds.Add(s);
                    }
                }
            }
            if (log)
            {
                ShowSftpLogger(cmd);
            }
            cmd = cmds[0];
            string str, result = null;
            int level = 0;
            if (cmd.Equals("quit"))
            {
                sftpChannel.quit();
                return null;
            }
            if (cmd.Equals("exit"))
            {
                sftpChannel.exit();
                return null;
            }
            if (cmd.Equals("rekey"))
            {
                session.rekey();
                return null;
            }
            if (cmd.Equals("compression"))
            {
                if (cmds.Count < 2)
                {
                    if (log) ShowSftpLogger("compression level：" + level);
                    return null;
                }
                try
                {
                    level = int.Parse((String)cmds[1]);
                    Hashtable config = new Hashtable();
                    if (level == 0)
                    {
                        config.Add("compression.s2c", "none");
                        config.Add("compression.c2s", "none");
                    }
                    else
                    {
                        config.Add("compression.s2c", "zlib,none");
                        config.Add("compression.c2s", "zlib,none");
                    }
                    session.setConfig(config);
                }
                catch { }//(Exception e){}
                return null;
            }
            if (cmd.Equals("cd") || cmd.Equals("lcd"))
            {
                if (cmds.Count < 2)
                    return null;
                String path = (String)cmds[1];
                try
                {
                    if (cmd.Equals("cd")) 
                        sftpChannel.cd(path);
                    else 
                        sftpChannel.lcd(path);
                }
                catch (SftpException ex)
                {
                    if (log) ShowSftpLogger(ex.message);
                }
                result = sftpChannel.pwd();
                if (log) ShowSftpLogger(result);
                return result;
            }
            if (cmd.Equals("rm") || cmd.Equals("rmdir") || cmd.Equals("mkdir"))
            {
                if (cmds.Count < 2)
                    return null;
                String path = (String)cmds[1];
                try
                {
                    if (cmd.Equals("rm")) sftpChannel.rm(path);
                    else if (cmd.Equals("rmdir")) sftpChannel.rmdir(path);
                    else sftpChannel.mkdir(path);
                }
                catch (SftpException ex)
                {
                    if (log) ShowSftpLogger(ex.message);
                }
            }
            if (cmd.Equals("chgrp") || cmd.Equals("chown") || cmd.Equals("chmod"))
            {
                if (cmds.Count != 3)
                    return null;
                String path = (String)cmds[2];
                int foo = 0;
                if (cmd.Equals("chmod"))
                {
                    byte[] bar = Util.getBytes((String)cmds[1]);
                    int k;
                    for (int j = 0; j < bar.Length; j++)
                    {
                        k = bar[j];
                        if (k < '0' || k > '7') { foo = -1; break; }
                        foo <<= 3;
                        foo |= (k - '0');
                    }
                    if (foo == -1)
                        return null;
                }
                else
                {
                    try
                    {
                        foo = int.Parse((String)cmds[1]);
                    }
                    catch { }//(Exception e){continue;}
                }
                try
                {
                    if (cmd.Equals("chgrp"))
                    {
                        sftpChannel.chgrp(foo, path);
                    }
                    else if (cmd.Equals("chown"))
                    {
                        sftpChannel.chown(foo, path);
                    }
                    else if (cmd.Equals("chmod"))
                    {
                        sftpChannel.chmod(foo, path);
                    }
                }
                catch (SftpException ex)
                {
                    if (log) ShowSftpLogger(ex.message);
                }
                return null;
            }
            if (cmd.Equals("pwd") || cmd.Equals("lpwd"))
            {
                str = (cmd.Equals("pwd") ? "Remote" : "Local");
                str += " Location：";
                if (cmd.Equals("pwd")) {
                    result = sftpChannel.pwd();
                    str += result;
                }
                else
                {
                    result = sftpChannel.lpwd();
                    str += result;
                }
                if (log) ShowSftpLogger(str);
                return result;
            }
            if (cmd.Equals("home"))
            {
                result = sftpChannel.getHome();
                str = "Remote User Home：" + result;
                if (log) ShowSftpLogger(str);
                return result;
            }
            if (cmd.Equals("ll") || cmd.Equals("dir"))
            {
                String path = ".";
                ArrayList vv = null;
                if (cmds.Count == 2) path = (String)cmds[1];
                try
                {
                    vv = sftpChannel.ls(path);
                    if (vv != null)
                    {
                        result = "";
                        for (int ii = 0; ii < vv.Count; ii++)
                        {
                            object obj = vv[ii];
                            if (obj is ChannelSftp.LsEntry)
                            {
                                if (log) ShowSftpLogger(obj.ToString());
                            }
                        }
                    }
                }
                catch (SftpException ex)
                {
                    if (log) ShowSftpLogger(ex.message);
                }
                return vv;
            }
            if (cmd.Equals("ls"))
            {
                String path = ".";
                ArrayList vv = null;
                if (cmds.Count == 2) path = (String)cmds[1];
                try
                {
                    vv = sftpChannel.ls(path);
                    if (vv != null)
                    {
                        StringBuilder sb = new StringBuilder();
                        for (int ii = 0; ii < vv.Count; ii++)
                        {
                            object obj = vv[ii];
                            if (obj is ChannelSftp.LsEntry)
                            {
                                sb.Append(((ChannelSftp.LsEntry)obj).getFilename()).Append("\t");
                            }
                        }
                        if (log) ShowSftpLogger(sb.ToString());
                    }
                }
                catch (SftpException ex)
                {
                    if (log) ShowSftpLogger(ex.message);
                }
                return vv;
            }
            if (cmd.Equals("lls") || cmd.Equals("ldir"))
            {
                String path = ".";
                if (cmds.Count == 2) path = (String)cmds[1];
                try
                {
                    //java.io.File file=new java.io.File(path);
                    if (!Directory.Exists(path))
                    {
                        if (log) ShowSftpLogger(path + ": No such file or directory.");
                        return null;
                    }
                    if (Directory.Exists(path))
                    {
                        String[] list = Directory.GetDirectories(path);
                        result = "";
                        for (int ii = 0; ii < list.Length; ii++)
                        {
                            result += list[ii] + "\n";
                            if (log) ShowSftpLogger(list[ii]);
                        }
                        return result;
                    }
                    if (log) ShowSftpLogger(path);
                }
                catch (Exception ex)
                {
                    if (log) ShowSftpLogger(ex.Message);
                }
                return null;
            }
            if (cmd.Equals("get") ||
                cmd.Equals("get-resume") || cmd.Equals("get-append") ||
                cmd.Equals("put") ||
                cmd.Equals("put-resume") || cmd.Equals("put-append")
                )
            {
                if (cmds.Count != 2 && cmds.Count != 3) return null;
                String p1 = (String)cmds[1];
                //	  String p2=p1;
                String p2 = ".";
                if (cmds.Count == 3) p2 = (String)cmds[2];
                try
                {
                    SftpProgressMonitor monitor = new Tamir.SharpSsh.jsch.examples.Sftp.MyProgressMonitor();
                    if (cmd.StartsWith("get"))
                    {
                        int mode = ChannelSftp.OVERWRITE;
                        if (cmd.Equals("get-resume")) { mode = ChannelSftp.RESUME; }
                        else if (cmd.Equals("get-append")) { mode = ChannelSftp.APPEND; }
                        sftpChannel.get(p1, p2, monitor, mode);
                    }
                    else
                    {
                        int mode = ChannelSftp.OVERWRITE;
                        if (cmd.Equals("put-resume")) { mode = ChannelSftp.RESUME; }
                        else if (cmd.Equals("put-append")) { mode = ChannelSftp.APPEND; }
                        sftpChannel.put(p1, p2, monitor, mode);
                    }
                }
                catch (SftpException ex)
                {
                    if (log) ShowSftpLogger(ex.message);
                }
                return null;
            }
            if (cmd.Equals("ln") || cmd.Equals("symlink") || cmd.Equals("rename"))
            {
                if (cmds.Count != 3) return null;
                String p1 = (String)cmds[1];
                String p2 = (String)cmds[2];
                try
                {
                    if (cmd.Equals("rename")) 
                        sftpChannel.rename(p1, p2);
                    else 
                        sftpChannel.symlink(p1, p2);
                }
                catch (SftpException ex)
                {
                    if (log) ShowSftpLogger(ex.message);
                }
                return null;
            }
            if (cmd.Equals("stat") || cmd.Equals("lstat"))
            {
                if (cmds.Count != 2) return null;
                String p1 = (String)cmds[1];
                SftpATTRS attrs = null;
                try
                {
                    if (cmd.Equals("stat")) attrs = sftpChannel.stat(p1);
                    else attrs = sftpChannel.lstat(p1);
                }
                catch (SftpException ex)
                {
                    if (log) ShowSftpLogger(ex.message);
                }
                if (attrs != null)
                {
                    result = attrs.ToString();
                    if (log) ShowSftpLogger(result);
                }
                return result;
            }
            if (cmd.Equals("version"))
            {
                result = sftpChannel.version();
                if (log) ShowSftpLogger("SFTP Protocol Version：" + result);
                return result;
            }
            if (cmd.Equals("help") || cmd.Equals("?"))
            {
                if (log) ShowSftpLogger(HelpData.SFTP_HELP);
                return null;
            }
            if (log) ShowSftpLogger(string.Format("bash: {0}: command not found...", cmd));

            return result;
        }


        #endregion

        private void MonitorForm_SizeChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex == 1)
            {
                tabControl1.SelectedIndex = 0;
                tabControl1.SelectedIndex = 1;
                timer_num = 0;
            }
            else if (tabControl1.SelectedIndex == 2)
            {
                tabControl1.SelectedIndex = 0;
                tabControl1.SelectedIndex = 2;
                timer_num = 0;
            }
        }

        private void toolbtn_opensftp_Click(object sender, EventArgs e)
        {
            SshUser user = null;
            if (null != config)
            {
                user = new SshUser();
                user.Host = config.Host;
                user.UserName = config.UserName;
                user.Password = config.Password;
                user.Port = config.Port;
            }
            //new SftpForm(user).Show();
            if (null != user)
            {
                string host = "\"" + user.Host + "\"";
                string username = "\"" + user.UserName + "\"";
                string password = "\"" + user.Password + "\"";
                string port = "\"" + user.Port + "\"";

                Process process = new Process();
                process.StartInfo.FileName = MainForm.APP_DIR + "\\AMSftp.exe";
                process.StartInfo.Arguments = host + " " + username + " " + password + " " + port;
                process.StartInfo.UseShellExecute = true;
                //启动  
                process.Start();
            }
            else
            {
                Process.Start(MainForm.APP_DIR + "\\AMSftp.exe");
            }
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            timer_num = 0;
            if (tabControl1.SelectedIndex == 2)
            {
                Program.MAIN.FatabContentMenuShow(false);

            }
            else
            {
                Program.MAIN.FatabContentMenuShow(true);
            }
        }

        private void treeView1_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                treeView1.SelectedNode = e.Node;
            }
        }

        public void SetNodeIcon(string nodeName, int index)
        {
            TreeNode[] nodes = treeView1.Nodes.Find(nodeName, false);
            if (null != nodes && nodes.Length > 0)
            {
                nodes[0].ImageIndex = index;
                nodes[0].SelectedImageIndex = index;
            }
        }

        private void rtb_sftp_log_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                if (null != fullScreenForm)
                {
                    fullScreenForm.Exit();
                }
            }
            currShellBox = rtb_sftp_log;

            if(e.Control && e.KeyCode == Keys.F){
                findToolStripMenuItem_Click(null, null);
            }
            else if (e.Control && e.KeyCode == Keys.C)
            {
                复制ToolStripMenuItem_Click(null, null);
            }
            else if (e.Control && e.KeyCode == Keys.V)
            {
                粘贴ToolStripMenuItem_Click(null, null);
            }
            else if (e.Control && e.KeyCode == Keys.A)
            {
                selectAllToolStripMenuItem_Click(null, null);
            }
        }

        private void rtb_sftp_log_KeyDown(object sender, KeyEventArgs e)
        {
            if (!e.Control && !e.Alt && !e.Shift)
            {
                tstb_sftp.Focus();
                string chars = KeysUtil.getKeyChar(e.KeyValue, e.Shift);
                if (!string.IsNullOrWhiteSpace(chars))
                {
                    tstb_sftp.AppendText(chars.ToLower());
                }
            }
        }

        private void rtb_log_MouseDown(object sender, MouseEventArgs e)
        {
            currShellBox = rtb_log;
        }

        private void rtb_sftp_log_MouseDown(object sender, MouseEventArgs e)
        {
            currShellBox = rtb_sftp_log;
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            foreach (TreeNode node1 in treeView1.Nodes)
            {
                node1.ForeColor = Color.Black;
            }
            
            TreeNode node = e.Node;
            node.ForeColor = Color.Red;
            MonitorBaseForm workForm = node.Tag as MonitorBaseForm;
            if (null != workForm)
            {
                workForm.Location = new Point(0, 0);
                if (currSelectNode != null && currSelectNode != node)
                {
                    MonitorBaseForm form = currSelectNode.Tag as MonitorBaseForm;
                    form.Location = new Point(form.Size.Width, 0);
                }
            }
            currSelectNode = node;
        }

        private void tstb_shell_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.OemQuestion)
            {
                // 提示
                StartShowCandidate();
            }
            else if (e.KeyCode != Keys.Enter && e.KeyCode != Keys.Up && e.KeyCode != Keys.Down)
            {
                listBox1.Visible = false;
            }
        }

        public void StartShowCandidate()
        {
            string cmd = tstb_shell.Text;
            int index = cmd.LastIndexOf(" ");
            if (index >= 0)
            {
                cmd = cmd.Substring(index + 1);
            }
            // 提示
            string word = "";
            if (!string.IsNullOrWhiteSpace(cmd))
            {
                word = getWords(cmd);
            }
            string disPath = curr_path;
            if (cmd != "")
            {
                if (cmd.IndexOf("/") != -1)
                {
                    cmd = cmd.Substring(0, cmd.LastIndexOf("/") + 1);
                }
                disPath = getCdPath(cmd);
            }
            if (disPath != "")
            {
                ShowCandidate(word, disPath);
            }
        }

        private string getWords(string str)
        {
            string c = "", res = "";
            if(!string.IsNullOrWhiteSpace(str) && !str.EndsWith(" ")){
                bool find = false;
                for (int i = str.Length; i > 0; i--)
                {
                    c = str.Substring(i - 1, 1);
                    if (c == " " || c == "/" || c == "." || c == "|")
                    {
                        find = true;
                        res = str.Substring(i);
                        break;
                    }
                }
                if (!find && res == "")
                {
                    res = str;
                }
            }            
            return res;
        }

        public void ShowCandidate(string word, string path)
        {
            ArrayList fileList = getDirFiles(path);
            if (null != fileList)
            {
                listBox1.BeginInvoke((MethodInvoker)delegate()
                {
                    listBox1.Items.Clear();
                    ChannelSftp.LsEntry file = null;
                    ListBoxItem item = null;
                    for (int i = 0; i < fileList.Count; i++)
                    {
                        object obj = fileList[i];
                        if (obj is ChannelSftp.LsEntry)
                        {
                            file = (ChannelSftp.LsEntry)obj;
                            if (file.getFilename() != "." && file.getFilename() != "..")
                            {
                                if (word == "" || file.getFilename().startsWith(word))
                                {
                                    item = new ListBoxItem();
                                    item.Text = file.getFilename();
                                    item.Tag = file;
                                    listBox1.Items.Add(item);
                                }
                            }
                        }
                    }

                    if (listBox1.Items.Count > 0)
                    {
                        listBox1.SelectedIndex = 0;
                        listBox1.Visible = true;
                    }
                });                
            }
        }

        public ArrayList getDirFiles(string path)
        {
            ArrayList list = null;
            try
            {
                list = sftpChannel.ls(path);
            }
            catch (Exception e)
            {
                //logger.Error("获取Linux目录下所有文件异常：" + e.Message, e);
            }
            return list;
        }

        private void listBox1_KeyUp(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter){
                SureListBoxChooseItem();
            }
        }

        private void listBox1_DoubleClick(object sender, EventArgs e)
        {
            SureListBoxChooseItem();
        }

        private void SureListBoxChooseItem() {
            ListBoxItem item = (ListBoxItem)listBox1.SelectedItem;
            ChannelSftp.LsEntry file = (ChannelSftp.LsEntry)item.Tag;
            string currCmd = tstb_shell.Text;
            string str = getWords(currCmd);
            string cmd = currCmd;
            if (str == "")
            {
                cmd = currCmd + item.Text;
            }
            else
            {
                cmd = currCmd.Substring(0, currCmd.Length - str.Length) + item.Text;
            }
            listBox1.Visible = false;
            if (cmd != "")
            {
                if (file.getAttrs().isDir())
                {
                    cmd += "/";
                }
                tstb_shell.ForeColor = Color.Black;
                tstb_shell.Text = cmd;
                tstb_shell.Select(tstb_shell.TextLength + cmd.Length, 0);//光标定位到文本最后
                tstb_shell.ScrollToCaret();//滚动到光标处
                tstb_shell.Focus();//获取焦点
            }
        }

    }
}
