using AppMonitor.Bex;
using AppMonitor.Model;
using AppMonitor.Plugin;
using log4net;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace AppMonitor.Froms
{
    public partial class IceMonitorForm : MonitorBaseForm
    {
        private static ILog logger = LogManager.GetLogger("LogFileAppender");
        MonitorForm monitorForm = null;
        MonitorItemConfig itemConfig = null;
        SessionConfig seConfig;
        YSTools.YSHttpUtility http = new YSTools.YSHttpUtility();
        int timer = 30, resetTimer = 30, firstTimer = 0, ftime = 3;
        bool check_flag = false, isfirst = true;
        bool get_srvxml_run = false;

        public IceMonitorForm(MonitorForm _form, SessionConfig _config, MonitorItemConfig _itemConfig, int index)
        {
            InitializeComponent();
            monitorForm = _form;
            seConfig = _config;
            itemConfig = _itemConfig;
            timer = AppConfig.Instance.MConfig.MonitorTimer + index * 3;
            resetTimer = timer;
            progressBar1.Maximum = timer;
            ftime = 3 + index * 3;
        }

        public override void CloseForm()
        {
            this.Close();
        }

        private void IceMonitorForm_Load(object sender, EventArgs e)
        {
            ReflushMonitorItem();

            RenderCustomShellList();

            // 启动定时器
            timer1.Enabled = true;
            timer1.Start();
        }

        public override void ReflushMonitorItem()
        {
            l_appname.Text = itemConfig.ice.AppName;
            string srcdir = itemConfig.ice.IceSrvDir;
            if (srcdir != null)
            {
                if (!srcdir.EndsWith("/"))
                    srcdir += "/";
                l_pro_path.Text = srcdir;
            }
            l_node_port.Text = itemConfig.ice.NodePorts;
            l_server_name.Text = itemConfig.ice.ServerName;

            if (itemConfig.ice.NodePorts != null)
            {
                string[] ports = itemConfig.ice.NodePorts.Split(',');
                ListViewItem item = null;
                foreach(string port in ports){
                    item = new ListViewItem();
                    item.Text = string.Format("http://{0}:{1}", seConfig.Host, port);
                    item.Tag = port;
                    projects.Items.Add(item);
                }
            }
        }

        #region 定时任务
        public void RenderCustomShellList()
        {
            customShellListView.Items.Clear();
            ListViewItem item = null;
            ListViewItem.ListViewSubItem subItem = null;
            foreach (CmdShell cmds in seConfig.CustomShellList)
            {
                if (cmds.Target == itemConfig.ice.Uuid)
                {
                    item = new ListViewItem();
                    item.Tag = cmds;
                    item.Name = cmds.Name;
                    item.Text = cmds.Name;

                    subItem = new ListViewItem.ListViewSubItem();
                    subItem.Text = cmds.Type;
                    item.SubItems.Add(subItem);

                    customShellListView.Items.Add(item);
                }
            }
        }

        public void checkTimedTask()
        {
            var now = DateTime.Now;
            String[] dts = null;
            string week = "";
            foreach (CmdShell cmds in seConfig.CustomShellList)
            {
                if (cmds.Target == itemConfig.ice.Uuid)
                {
                    if (cmds.TaskType == TaskType.Timed)
                    {
                        if (null != cmds.ShellList)
                        {
                            dts = null;
                            foreach (TaskShell task in cmds.ShellList)
                            {
                                dts = task.DateTime.Split('|');
                                if (dts[0] == "0")
                                {// 一次
                                    if (now.ToString("yyyy-MM-dd") == dts[1] && now.ToString("HH:mm:ss") == dts[2])
                                    {
                                        // 执行
                                        runTaskShell(cmds, task);
                                    }
                                }
                                else if (dts[0] == "1")
                                {// 每天
                                    if (now.ToString("HH:mm:ss") == dts[2])
                                    {
                                        // 执行
                                        runTaskShell(cmds, task);
                                    }
                                }
                                else if (dts[0] == "2")
                                {// 每周
                                    week = DateTime.Now.DayOfWeek.ToString("d");
                                    if (dts[1].Contains(week) && now.ToString("HH:mm:ss") == dts[2])
                                    {
                                        // 执行
                                        runTaskShell(cmds, task);
                                    }
                                }
                                else if (dts[0] == "3")
                                {// 每月
                                    if (now.ToString("dd") == dts[1] && now.ToString("HH:mm:ss") == dts[2])
                                    {
                                        // 执行
                                        runTaskShell(cmds, task);
                                    }
                                }
                                else if (dts[0] == "4")
                                {// 每年
                                    if (now.ToString("MM-dd") == dts[1] && now.ToString("HH:mm:ss") == dts[2])
                                    {
                                        // 执行
                                        runTaskShell(cmds, task);
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        public void runTaskShell(CmdShell cmds, TaskShell task)
        {
            ThreadPool.QueueUserWorkItem((a) => {

                string srvdir = itemConfig.ice.IceSrvDir;
                if (null != srvdir)
                {
                    if (!srvdir.EndsWith("/"))
                    {
                        srvdir += "/";
                    }
                }

                string shell = task.Shell;
                if (shell.Contains("{icesrv_dir}"))
                {
                    shell = shell.Replace("{icesrv_dir}", srvdir);
                }

                if (shell.Contains("{server_name}"))
                {
                    shell = shell.Replace("{server_name}", l_server_name.Text);
                }

                if (shell.Contains("{adminsh}"))
                {
                    shell = shell.Replace("{adminsh}", srvdir + "bin/admin.sh");
                }
                shell = shell.Replace("//", "/");

                monitorForm.RunShell(shell, false);
            });
        }
        #endregion


        private void timer1_Tick(object sender, EventArgs e)
        {
            if (timer < 1)
            {
                if (!check_flag)
                {
                    SetStatus(0);
                }
                CheckIceServer();
            }
            if (isfirst)
            {
                if (firstTimer < ftime)
                {
                    firstTimer++;
                }
                else
                {
                    isfirst = false;
                    CheckIceServer();
                }
            }

            timer--;
            progressBar1.Value = timer;

            // 检查定时任务
            checkTimedTask();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            CheckIceServer();
        }

        public void CheckIceServer()
        {
            timer = resetTimer;
            progressBar1.Value = timer;

            monitorForm.RunShell(l_pro_path.Text + "bin/admin.sh", false);

            monitorForm.GetShellResult("server state " + itemConfig.ice.ServerName, new ShellResultDelegate(CheckIceServerResult));
        }

        public void CheckIceServerResult(string s)
        {
            monitorForm.RunShell("quit", false);
            if (s != null && s.IndexOf("active (pid =") != -1)
            {
                SetStatus(1);

                // 检测监控项
                StartCheckItems();
            }
            else
            {
                SetStatus(0);
            }
        }

        public void SetStatus(int status)
        {
            check_flag = true;
            this.BeginInvoke((MethodInvoker)delegate()
            {
                string tag = this.Tag.ToString();
                string uuid = tag.Substring(3);
                if (status > 0)
                {
                    itemConfig.ice.RunStatus = RunState.Normal;
                    pic_run_state.BackgroundImage = Properties.Resources.green_light_48;
                    label_status.Text = "程序运行正常";
                    this.skinToolTip1.SetToolTip(pic_run_state, label_status.Text);
                    btn_start.Enabled = false;
                    btn_stop.Enabled = true;

                    monitorForm.SetNodeIcon("task-" + uuid, 1);
                }
                else
                {
                    itemConfig.ice.RunStatus = RunState.AbNormal;
                    pic_run_state.BackgroundImage = Properties.Resources.org_light_48;
                    label_status.Text = "程序无法访问";
                    this.skinToolTip1.SetToolTip(pic_run_state, "程序无法访问，请检查问题");
                    btn_start.Enabled = true;
                    btn_stop.Enabled = false;

                    monitorForm.SetNodeIcon("task-" + uuid, 2);
                }
            });
        }

        public void StartCheckItems()
        {
            ThreadPool.QueueUserWorkItem((a) =>
            {
                this.BeginInvoke((MethodInvoker)delegate()
                {
                    foreach (ListViewItem item in projects.Items)
                    {
                        CheckItem(item.Text, item);
                    }
                });
            });
        }

        public void CheckItem(string uri, ListViewItem item)
        {
            try
            {
                RequestHttpWebRequest req = new RequestHttpWebRequest();
                req.GetResponseAsync(new RequestInfo(uri), x =>
                {
                    try
                    {
                        if (x.StatusCode == HttpStatusCode.OK || x.StatusCode == HttpStatusCode.Found)
                        {
                            // 正常
                            SetListItemStatus(item, 1);
                        }
                        else
                        {
                            // 异常
                            SetListItemStatus(item, 2);
                        }
                    }
                    catch (Exception ex)
                    {
                        // 异常
                        SetListItemStatus(item, 2);
                        logger.Error("http请求异常：" + ex.Message, ex);
                    }
                });
            }
            catch (Exception e)
            {
                if (e.Message.IndexOf("未能为 SSL/TLS 安全通道建立信任关系") != -1)
                {
                    ServicePointManager.ServerCertificateValidationCallback = (sender, certificate, chain, sslPolicyErrors) => true;
                    CheckItem(uri, item);
                }
                logger.Error("http请求异常：" + e.Message, e);
            }
        }

        public void SetListItemStatus(ListViewItem item, int status)
        {
            this.BeginInvoke((MethodInvoker)delegate()
            {
                if (status == 1)
                {
                    item.ImageIndex = 1;
                }
                else if (status == 2)
                {
                    item.ImageIndex = 2;
                }
            });
        }

        private void btn_start_Click(object sender, EventArgs e)
        {
            btn_start.Enabled = false;
            monitorForm.RunShell(l_pro_path.Text + "bin/admin.sh", false, true);
            monitorForm.RunShell("server start " + itemConfig.ice.ServerName, false, true);
            monitorForm.RunShell("quit", false, true);
        }

        private void btn_stop_Click(object sender, EventArgs e)
        {
            btn_stop.Enabled = false;
            monitorForm.RunShell(l_pro_path.Text + "bin/admin.sh", false, true);
            monitorForm.RunShell("server stop " + itemConfig.ice.ServerName, false, true);
            monitorForm.RunShell("quit", false, true);
        }

        private void btn_restart_Click(object sender, EventArgs e)
        {
            monitorForm.RunShell(l_pro_path.Text + "bin/admin.sh", false, true);
            monitorForm.RunShell("server stop " + itemConfig.ice.ServerName, false, true);
            monitorForm.RunShell("server start " + itemConfig.ice.ServerName, false, true);
            monitorForm.RunShell("quit", false, true);
        }

        private void btn_build_Click(object sender, EventArgs e)
        {
            btn_update.Enabled = false;
            monitorForm.RunShell(l_pro_path.Text + "bin/admin.sh", false, true);
            monitorForm.GetShellResult(string.Format("application update config/{0}.xml", itemConfig.ice.AppName), new ShellResultDelegate(UpdateConfigResult), true);
        }

        public void UpdateConfigResult(string s)
        {
            monitorForm.RunShell("quit", false);

            btn_update.BeginInvoke((MethodInvoker)delegate()
            {
                btn_update.Enabled = true;
            });            
        }

        private void 自定义命令ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CustomShellForm form = new CustomShellForm(seConfig, itemConfig.ice.Uuid);
            form.ShowDialog(this);

            RenderCustomShellList();
        }

        private void customShellListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(customShellListView.SelectedItems.Count > 0){
                ListViewItem item = customShellListView.SelectedItems[0];
                if(null != item){
                    CmdShell cmds = (CmdShell) item.Tag;
                    StringBuilder sb = new StringBuilder();
                    foreach (TaskShell task in cmds.ShellList)
                    {
                        if (cmds.TaskType == TaskType.Default)
                        {
                            sb.AppendLine(task.Shell);
                        }
                        else if (cmds.TaskType == TaskType.Timed)
                        {
                            sb.AppendLine(string.Format("{0} - {1}", task.DateTime, task.Shell));
                        }
                        else if (cmds.TaskType == TaskType.Condition)
                        {
                            sb.AppendLine(string.Format("{0} - {1}", cmds.Condition, task.Shell));
                        }
                    }
                    shellView.Text = sb.ToString();
                    if(cmds.TaskType == TaskType.Default){
                        btn_run.Enabled = true;
                    }
                    return;
                }
            }
            btn_run.Enabled = false;
            shellView.Text = "";
        }

        private void button6_MouseUp(object sender, MouseEventArgs e)
        {
            contextMenu.Show(custom_btn, new Point(e.X, e.Y));
        }

        private void btn_run_Click(object sender, EventArgs e)
        {
            string cmdstr = shellView.Text;
            if(!string.IsNullOrWhiteSpace(cmdstr)){
                string[] cmdArr = cmdstr.Split('\n');
                foreach(string cmd in cmdArr){
                    monitorForm.RunShell(cmd.Trim(), true, true);
                    Thread.Sleep(100);
                }
            }            
        }

        private void CustomTimeTask_Click(object sender, EventArgs e)
        {
            TimedTaskForm form = new TimedTaskForm(itemConfig.ice.Index);
            form.setCallback(new TimedTaskForm.AsyncCallback(addTimedTaskFinish));
            form.ShowDialog(this);
        }

        public void addTimedTaskFinish(CmdShell cs)
        {
            cs.Target = itemConfig.ice.Uuid;

            seConfig.CustomShellList.Add(cs);

            AppConfig.Instance.SaveConfig(2);

            RenderCustomShellList();
        }

        private void 条件任务ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ConditionTaskForm form = new ConditionTaskForm(seConfig, itemConfig.ice.Index);
            form.setCallback(new ConditionTaskForm.AsyncCallback(addConditionTaskFinish));
            form.ShowDialog(this);
        }

        public void addConditionTaskFinish(CmdShell cs)
        {
            cs.Target = itemConfig.ice.Uuid;

            seConfig.CustomShellList.Add(cs);

            AppConfig.Instance.SaveConfig(2);

            RenderCustomShellList();
        }

        private void customShellListView_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && customShellListView.SelectedItems.Count > 0)
            {
                contextMenuStrip2.Show(customShellListView, e.Location);
            }
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            try
            {
                ListViewItem item = customShellListView.SelectedItems[0];
                CmdShell cmds = (CmdShell)item.Tag;
                if (cmds.TaskType == TaskType.Default)
                {
                    CustomShellForm form = new CustomShellForm(seConfig, itemConfig.ice.Uuid);
                    form.SetUpdater(cmds);
                    form.ShowDialog(this);

                    shellView.Text = "";
                    btn_run.Enabled = false;
                    RenderCustomShellList();
                }
                else if (cmds.TaskType == TaskType.Timed)
                {
                    TimedTaskForm form = new TimedTaskForm(itemConfig.ice.Index);
                    form.setCallback(new TimedTaskForm.AsyncCallback(editTaskFinish));
                    form.SetUpdater(cmds);
                    form.ShowDialog(this);
                }
                else if (cmds.TaskType == TaskType.Condition)
                {
                    ConditionTaskForm form = new ConditionTaskForm(seConfig, itemConfig.ice.Index);
                    form.setCallback(new ConditionTaskForm.AsyncCallback(editTaskFinish));
                    form.SetUpdater(cmds);
                    form.ShowDialog(this);
                }
            }
            catch { }
        }

        public void editTaskFinish(CmdShell cs)
        {
            shellView.Text = "";
            btn_run.Enabled = false;
            
            AppConfig.Instance.SaveConfig(2);
            RenderCustomShellList();
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            if (customShellListView.SelectedItems.Count > 0)
            {
                try
                {
                    ListViewItem item = customShellListView.SelectedItems[0];
                    DialogResult dr = MessageBox.Show(this, "您确定要删除此项吗？", "警告", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                    if (dr == System.Windows.Forms.DialogResult.OK)
                    {
                        customShellListView.Items.Remove(item);
                        CmdShell cmds = (CmdShell)item.Tag;
                        seConfig.CustomShellList.Remove(cmds);

                        AppConfig.Instance.SaveConfig(2);
                    }
                }
                catch { }
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                if (get_srvxml_run)
                {
                    return;
                }
                get_srvxml_run = true;
                linkLabel1.Enabled = false;

                string targetxml = MainForm.TEMP_DIR + string.Format("srv-{0}.xml", DateTime.Now.ToString("MMddHHmmss"));
                targetxml = targetxml.Replace("\\", "/");
                string serverxml = string.Format("{0}config/{1}.xml", l_pro_path.Text, l_appname.Text);

                TextEditorForm editor = new TextEditorForm();
                editor.Show(this);

                editor.LoadRemoteFile(new ShellForm(monitorForm), serverxml, targetxml);
            }
            catch { }

            get_srvxml_run = false;
            linkLabel1.Enabled = true; 
        }

        private void visitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (projects.SelectedItems.Count > 0)
            {
                string url = projects.SelectedItems[0].Text;
                Process.Start(url);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            IceDeployVersionForm form = new IceDeployVersionForm(monitorForm, seConfig, itemConfig.ice);
            form.ShowDialog(this);

        }

    }
}
