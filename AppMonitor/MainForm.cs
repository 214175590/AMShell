using AppMonitor.Bex;
using AppMonitor.Froms;
using AppMonitor.Nodel;
using AppMonitor.Plugin;
using FarsiLibrary.Win;
using log4net;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace AppMonitor
{
    public partial class MainForm : CCWin.Skin_Metro
    {
        private static ILog logger = LogManager.GetLogger("LogFileAppender");
        public static readonly string APP_DIR = Application.StartupPath;
        public static string MyDocuments = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        public static string SESSION_DIR = APP_DIR + "\\session\\";
        public static string CONF_DIR = APP_DIR + "\\conf\\";
        public static string HELP_DIR = APP_DIR + "\\help\\";
        public static string TEMP_DIR = APP_DIR + "\\temp\\";
        public static Dictionary<FATabStripItem, MonitorForm> TAB_MONITOR = new Dictionary<FATabStripItem, MonitorForm>();
        private static int TAB_INDEX = 1;
        public static bool isLock = false;
        public LockForm lockForm = null;
        public static string appName = "AMShell";
        public static double appVersion = 1.1d;

        public MainForm()
        {
            InitializeComponent();
            SkinUtil.SetFormSkin(this);
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            try
            {
                this.Text = appName + " v" + appVersion;

                string str = YSTools.YSFile.readFileToString(MyDocuments + "\\." + appName);
                if(!string.IsNullOrWhiteSpace(str)){
                    MessageBox.Show(str);
                    Application.Exit();
                }
            }
            catch { }

            tsp_font_fimily.SelectedIndex = 3;
            tsp_font_size.SelectedIndex = 0;

            init();
            ThreadPool.QueueUserWorkItem((a) => {
                if (AppConfig.Instance.MConfig.OnstartShowSessMgt)
                {
                    this.BeginInvoke((MethodInvoker)delegate()
                    {
                        SessionManageForm form = new SessionManageForm();
                        form.ShowDialog(this);

                        RenderSessionList();
                    });                    
                }
            });
        }

        #region 初始化
        public void init()
        {
            // 创建目录
            if (!Directory.Exists(SESSION_DIR))
            {
                Directory.CreateDirectory(SESSION_DIR);
            }
            if (!Directory.Exists(CONF_DIR))
            {
                Directory.CreateDirectory(CONF_DIR);
            }
            if (!Directory.Exists(HELP_DIR))
            {
                Directory.CreateDirectory(HELP_DIR);
            }
            if (!Directory.Exists(TEMP_DIR))
            {
                Directory.CreateDirectory(TEMP_DIR);
            }            

            // 渲染Session列表
            RenderSessionList();

        }        
        
        #endregion

        #region Tool 事件

        #region 新建SSH Session
        private void tool_newSession_Click(object sender, EventArgs e)
        {
            SshSettingForm ssForm = new SshSettingForm();
            ssForm.ShowDialog(this);

            SessionConfig sessionConfig = ssForm.getSessionConfig();
            if (null != sessionConfig)
            {
                RenderSessionList();

                OpenSshSessionWindow(sessionConfig);
            }            
        }
        #endregion

        #region 打开Session
        void sessionItem_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem item = sender as ToolStripMenuItem;
            SessionConfig sessionConfig = (SessionConfig) item.Tag;
            if (null != sessionConfig)
            {
                OpenSshSessionWindow(sessionConfig);

                RenderSessionList();
            }
        }

        public void OpenSshSessionWindow(SessionConfig sessionConfig)
        {
            FATabStripItem page = new FATabStripItem();

            MonitorForm form = new MonitorForm(sessionConfig);
            form.FormBorderStyle = FormBorderStyle.None;
            form.TopLevel = false;
            form.Dock = DockStyle.Fill;
            form.Show();

            page.Tag = sessionConfig;
            page.Name = "page-" + TAB_INDEX;
            page.Title = string.Format("{0} {1}", faTab.Items.Count + 1, sessionConfig.Name);
            page.Controls.Add(form);

            TAB_MONITOR.Add(page, form);

            faTab.Items.Add(page);
            faTab.SelectedItem = page;

            page.ContextMenuStrip = contextMenuStrip1;

            TAB_INDEX++;

            tsl_info1.Text = sessionConfig.Host + "@" + sessionConfig.UserName;
        }

        public void RenderSessionList()
        {
            tool_open.DropDownItems.Clear();
            tool_attr.DropDownItems.Clear();

            Dictionary<string, SessionConfig> _session_config_dic = AppConfig.Instance.SessionConfigDict;
            ToolStripMenuItem sessionItem = null, sessionAttrItem = null;
            foreach (KeyValuePair<string, SessionConfig> item in _session_config_dic)
            {
                sessionItem = new ToolStripMenuItem();
                sessionItem.Image = Properties.Resources.monitor;
                sessionItem.Text = string.Format("{0} {1}", item.Value.Index, item.Value.Name);
                sessionItem.ToolTipText = "";
                sessionItem.Tag = item.Value;
                tool_open.DropDownItems.Add(sessionItem);

                sessionItem.Click += sessionItem_Click;

                sessionAttrItem = new ToolStripMenuItem();
                sessionAttrItem.Image = Properties.Resources.monitor;
                sessionAttrItem.Text = string.Format("{0} {1}", item.Value.Index, item.Value.Name);
                sessionAttrItem.ToolTipText = "";
                sessionAttrItem.Tag = item.Value;
                tool_attr.DropDownItems.Add(sessionAttrItem);

                sessionAttrItem.Click += sessionAttrItem_Click;
            }
        }
        #endregion

        #region session属性设置
        void sessionAttrItem_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem item = sender as ToolStripMenuItem;
            SessionConfig sessionConfig = (SessionConfig)item.Tag;

            SshSettingForm ssForm = new SshSettingForm(sessionConfig);
            ssForm.ShowDialog(this);

            RenderSessionList();
        }
        #endregion

        #region 关闭Tab
        public void CloseFaTab(FATabStripItem tab, bool autoDisconn = false)
        {
            this.BeginInvoke((MethodInvoker)delegate()
            {
                
                if (TAB_MONITOR.ContainsKey(tab))
                {
                    MonitorForm form = TAB_MONITOR[tab];
                    TAB_MONITOR.Remove(tab);
                    form.Disconnection();
                    form.Close();
                    faTab.Items.Remove(tab);
                }
            });            
        }

        private void faTab_TabStripItemClosing(TabStripItemClosingEventArgs e)
        {
            FATabStripItem tab = e.Item;
            this.BeginInvoke((MethodInvoker)delegate()
            {
                if (TAB_MONITOR.ContainsKey(tab))
                {
                    MonitorForm form = TAB_MONITOR[tab];
                    TAB_MONITOR.Remove(tab);
                    form.Disconnection();
                    form.Close();
                }
            });
        }

        private void faTab_TabStripItemClosed(object sender, EventArgs e)
        {

        }

        public void FatabContentMenuShow(bool show)
        {
            FATabStripItem tab = faTab.SelectedItem;
            if(tab != null){
                tab.ContextMenuStrip = show ? contextMenuStrip1 : null;
            }
            faTab.ContextMenuStrip = show ? contextMenuStrip1 : null;
        }
        #endregion
        

        private void tool_open_Click(object sender, EventArgs e)
        {
            SessionManageForm form = new SessionManageForm();
            form.ShowDialog(this);

            RenderSessionList();
        }

        private void tool_ssh_Click(object sender, EventArgs e)
        {
            Process.Start(System.Windows.Forms.Application.ExecutablePath);
        }

        #endregion

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            ExitApp();
        }

        // 打开ftp窗口
        private void tool_ftp_Click(object sender, EventArgs e)
        {
            SshUser user = null;
            FATabStripItem tab = (FATabStripItem)faTab.SelectedItem;
            if (tab != null)
            {
                SessionConfig sessionConfig = (SessionConfig)tab.Tag;
                if (null != sessionConfig)
                {
                    user = new SshUser();
                    user.Host = sessionConfig.Host;
                    user.UserName = sessionConfig.UserName;
                    user.Password = sessionConfig.Password;
                    user.Port = sessionConfig.Port;
                }                 
            }
            //new SftpForm(user).Show();
            if (null != user)
            {
                string host = "\"" + user.Host + "\"";
                string username = "\"" + user.UserName + "\"";
                string password = "\"" + user.Password + "\"";
                string port = "\"" + user.Port + "\"";  

                Process process = new Process();
                process.StartInfo.FileName = APP_DIR + "\\AMSftp.exe";
                process.StartInfo.Arguments = host + " " + username + " " + password + " " + port;  
                process.StartInfo.UseShellExecute = true;
                //启动  
                process.Start();  
            }
            else
            {
                Process.Start(APP_DIR + "\\AMSftp.exe");
            }
        }

        private void shellHelpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShellHelpForm form = new ShellHelpForm();
            form.Show(this);
        }

        private void tool_copy_Click(object sender, EventArgs e)
        {
            FATabStripItem tab = (FATabStripItem)faTab.SelectedItem;
            if (tab != null && TAB_MONITOR.ContainsKey(tab))
            {
                MonitorForm form = TAB_MONITOR[tab];
                form.CallCopy();
            }            
        }

        private void tool_paste_Click(object sender, EventArgs e)
        {
            FATabStripItem tab = (FATabStripItem)faTab.SelectedItem;
            if (tab != null && TAB_MONITOR.ContainsKey(tab))
            {
                MonitorForm form = TAB_MONITOR[tab];
                form.CallPaste();
            } 
        }

        private void tool_find_Click(object sender, EventArgs e)
        {
            FATabStripItem tab = (FATabStripItem)faTab.SelectedItem;
            if (tab != null && TAB_MONITOR.ContainsKey(tab))
            {
                MonitorForm form = TAB_MONITOR[tab];
                form.CallFind();
            } 
        }

        private void tool_fullscreen_Click(object sender, EventArgs e)
        {
            FATabStripItem tab = (FATabStripItem)faTab.SelectedItem;
            if (tab != null && TAB_MONITOR.ContainsKey(tab))
            {
                MonitorForm form = TAB_MONITOR[tab];
                form.CallFullScreen();
            } 
        }

        private void notifyIcon1_Click(object sender, EventArgs e)
        {
            if(isLock){
                lockForm.showForm();
                lockForm.Show(this);
            }
            else
            {
                if(this.WindowState == FormWindowState.Minimized){
                    this.WindowState = FormWindowState.Normal;
                }
                this.Activate();
            }
        }

        private void tool_lock_Click(object sender, EventArgs e)
        {
            if (!isLock || lockForm == null)
            {
                lockForm = new LockForm();
                lockForm.showForm();
                lockForm.Show(this);
            }
            else
            {
                lockForm.showForm();
                lockForm.Show(this);
            }
        }

        public void Lock()
        {
            isLock = true;
            this.Visible = false;
            lockMenuItem.Text = "UnLock";
            lockForm.Hide();
        }

        public void unLockForm()
        {
            lockForm.Hide();
            this.Visible = true;
            lockForm = null;
            isLock = false;
            lockMenuItem.Text = "Lock";

            if (this.WindowState == FormWindowState.Minimized)
            {
                this.WindowState = FormWindowState.Normal;
            }
            this.Activate();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // 退出软件
            ExitApp();
        }

        private void lockMenuItem_Click(object sender, EventArgs e)
        {
            tool_lock_Click(null, null);
        }

        private void newSessionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tool_newSession_Click(null, null);
        }

        private void openSessionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tool_open_Click(null, null);
        }

        private void toolBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (toolBarToolStripMenuItem.Checked)
            {
                toolBarToolStripMenuItem.Checked = false;
                AppConfig.Instance.MConfig.ShowMenuBar = false;
                toolStrip1.Visible = false;
            }
            else
            {
                toolBarToolStripMenuItem.Checked = true;
                AppConfig.Instance.MConfig.ShowMenuBar = true;
                toolStrip1.Visible = true;
            }
            AppConfig.Instance.SaveConfig(1);
        }

        private void statusBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (statusBarToolStripMenuItem.Checked)
            {
                statusBarToolStripMenuItem.Checked = false;
                AppConfig.Instance.MConfig.ShowStatusBar = false;
                tool_bottom.Visible = false;
            }
            else
            {
                statusBarToolStripMenuItem.Checked = true;
                AppConfig.Instance.MConfig.ShowStatusBar = true;
                tool_bottom.Visible = true;
            }
            AppConfig.Instance.SaveConfig(1);
        }

        private void menuItem_exit_Click(object sender, EventArgs e)
        {
            ExitApp();
        }

        public void ExitApp()
        {
            // 退出软件
            System.Environment.Exit(0);
        }

        private void tool_setting_Click(object sender, EventArgs e)
        {
            SettingForm form = new SettingForm();
            form.ShowDialog(this);

            statusBarToolStripMenuItem.Checked = AppConfig.Instance.MConfig.ShowStatusBar;
            tool_bottom.Visible = AppConfig.Instance.MConfig.ShowStatusBar;

            toolBarToolStripMenuItem.Checked = AppConfig.Instance.MConfig.ShowMenuBar;
            toolStrip1.Visible = AppConfig.Instance.MConfig.ShowMenuBar;

            SkinUtil.SetFormSkin(this);
        }

        private void faTab_TabStripItemSelectionChanged(TabStripItemChangedEventArgs e)
        {
            FATabStripItem tab = (FATabStripItem)faTab.SelectedItem;
            if (tab != null && TAB_MONITOR.ContainsKey(tab))
            {
                SessionConfig sessionConfig = (SessionConfig) tab.Tag;
                if(null != sessionConfig){
                    tsl_info1.Text = sessionConfig.Host + "@" + sessionConfig.UserName;
                }                
            }
        }

        private void lockSceenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tool_lock_Click(null, null);
        }

        private void fullSceenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tool_fullscreen_Click(null, null);
        }

        private void tool_help_Click(object sender, EventArgs e)
        {
            shellHelpToolStripMenuItem_Click(null, null);
        }

        private void abourtAppMonitorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutForm form = new AboutForm();
            form.ShowDialog(this);
        }

        private void appMonitorHelpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            AppConfig.Instance.SaveConfig();
        }

        private void menuItem_lookAttr_Click(object sender, EventArgs e)
        {
            FATabStripItem tab = (FATabStripItem)faTab.SelectedItem;
            if (tab != null && TAB_MONITOR.ContainsKey(tab))
            {
                MonitorForm form = TAB_MONITOR[tab];
                SessionConfig sessionConfig = form.getSessionConfig();
                if (null != sessionConfig)
                {
                    SshSettingForm ssForm = new SshSettingForm(sessionConfig);
                    ssForm.ShowDialog(this);

                    RenderSessionList();
                }                
            }
        }

        private void commonConfigsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FATabStripItem tab = (FATabStripItem)faTab.SelectedItem;
            if (tab != null && TAB_MONITOR.ContainsKey(tab))
            {
                MonitorForm form = TAB_MONITOR[tab];
                CentralServerConfigForm configForm = new CentralServerConfigForm(form);
                configForm.Show(this);
            }
            else
            {
                CentralServerConfigForm configForm = new CentralServerConfigForm(null);
                configForm.Show(this);
            }
        }
        

    }
}
