using AppMonitor.Bex;
using AppMonitor.Model;
using AppMonitor.Plugin;
using log4net;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace AppMonitor.Froms
{
    public partial class NginxMonitorForm : MonitorBaseForm
    {
        private static ILog logger = LogManager.GetLogger("LogFileAppender");
        MonitorForm monitorForm = null;
        MonitorItemConfig itemConfig = null;
        SessionConfig seConfig;
        YSTools.YSHttpUtility http = new YSTools.YSHttpUtility();
        int timer = 30, resetTimer = 30, firstTimer = 0, ftime = 3;
        bool check_flag = false, isfirst = true;
        bool get_nginx_conf_run = false;

        public NginxMonitorForm(MonitorForm _form, SessionConfig _config, MonitorItemConfig _itemConfig, int index)
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

        private void NginxMonitorForm_Load(object sender, EventArgs e)
        {
            ReflushMonitorItem();

            ReflushMonitorUrl();

            RenderCustomShellList();

            // 启动定时器
            timer1.Enabled = true;
            timer1.Start();

            // 
            if (itemConfig.nginx.Config != null && itemConfig.nginx.Config["startWay"] != null)
            {
                if (itemConfig.nginx.Config["startWay"].ToString() == "2")
                {
                    nginxpathsStart.Checked = false;
                    nginxpathcnginxconf.Checked = true;
                }
            }
        }

        public override void ReflushMonitorItem()
        {
            l_name.Text = itemConfig.nginx.NginxName;
            l_nginx_path.Text = itemConfig.nginx.NginxPath;

            l_nginx_conf.Text = itemConfig.nginx.NginxConfig;

            l_visit_url.Text = "http://" + seConfig.Host;
            
        }

        public void ReflushMonitorUrl()
        {
            List<NginxMonitorUrl> lists = itemConfig.nginx.MonitorList;
            projects.Items.Clear();
            ListViewItem item = null;
            ListViewItem.ListViewSubItem subItem = null;
            foreach (NginxMonitorUrl pro in lists)
            {
                item = new ListViewItem();
                item.Tag = pro;
                item.Name = pro.url;
                item.Text = pro.url;
                item.ImageIndex = 0;

                subItem = new ListViewItem.ListViewSubItem();
                subItem.Text = pro.host;
                item.SubItems.Add(subItem);

                projects.Items.Add(item);
            }
        }

        public void CheckNginx(bool force = false)
        {
            timer = resetTimer;
            progressBar1.Value = timer;

            monitorForm.GetShellResult("ps -ef|grep nginx", new ShellResultDelegate(CheckNginxResult), force);            
        }

        public void CheckNginxResult(string s)
        {
            if(s != null && s.IndexOf(" master process ") != -1){
                SetStatus(1);

                // 检车监控项
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
                    itemConfig.nginx.RunStatus = RunState.Normal;
                    pic_run_state.BackgroundImage = Properties.Resources.green_light_48;
                    label_status.Text = "Nginx运行正常";
                    this.skinToolTip1.SetToolTip(pic_run_state, label_status.Text);
                    btn_start.Enabled = false;
                    btn_stop.Enabled = true;

                    monitorForm.SetNodeIcon("task-" + uuid, 1);
                }
                else
                {
                    itemConfig.nginx.RunStatus = RunState.AbNormal;
                    pic_run_state.BackgroundImage = Properties.Resources.org_light_48;
                    label_status.Text = "Nginx无法访问";
                    this.skinToolTip1.SetToolTip(pic_run_state, "Nginx无法访问，请检查问题");
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
                    NginxMonitorUrl pro = null;
                    foreach (ListViewItem item in projects.Items)
                    {
                        pro = (NginxMonitorUrl) item.Tag;
                        if(pro.check){
                            CheckItem(pro.url, item);
                        }
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
                NginxMonitorUrl pro = (NginxMonitorUrl)item.Tag;
                if(status == 1){
                    pro.RunStatus = RunState.Normal;
                    item.ImageIndex = 1;
                }
                else if(status == 2){
                    pro.RunStatus = RunState.AbNormal;
                    item.ImageIndex = 2;
                }
            });
        }
        #region 定时任务

        public void RenderCustomShellList()
        {
            customShellListView.Items.Clear();
            ListViewItem item = null;
            ListViewItem.ListViewSubItem subItem = null;
            foreach (CmdShell cmds in seConfig.CustomShellList)
            {
                if (cmds.Target == itemConfig.tomcat.Uuid)
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
                if (cmds.Target == itemConfig.tomcat.Uuid)
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
            ThreadPool.QueueUserWorkItem((a) =>
            {

                string shdir = itemConfig.nginx.NginxPath;
                if (null != shdir)
                {
                    if (shdir.EndsWith("/"))
                    {
                        shdir = shdir.Substring(0, shdir.Length - 1);
                    }
                    shdir = shdir.Substring(0, shdir.LastIndexOf("/") + 1);
                }

                string shell = task.Shell;
                if (shell.Contains("{nginx_dir}"))
                {
                    shell = shell.Replace("{nginx_dir}", shdir);
                }

                if (shell.Contains("{nginx}"))
                {
                    shell = shell.Replace("{nginx}", itemConfig.nginx.NginxPath);
                }

                shell = shell.Replace("//", "/");

                monitorForm.RunShell(shell, false);
            });
        }
        #endregion

        private void btn_start_Click(object sender, EventArgs e)
        {
            btn_start.Enabled = false;
            string cmd = itemConfig.nginx.NginxPath + " -s start";
            if (itemConfig.nginx.Config != null && itemConfig.nginx.Config["startWay"] != null)
            {
                if(itemConfig.nginx.Config["startWay"].ToString() == "2"){
                    cmd = itemConfig.nginx.NginxPath + " -c " + itemConfig.nginx.NginxConfig;
                }
            }
            monitorForm.RunShell(cmd, false, true);
        }

        private void btn_stop_Click(object sender, EventArgs e)
        {
            btn_stop.Enabled = false;
            monitorForm.RunShell(itemConfig.nginx.NginxPath + " -s stop", false, true);
        }

        private void btn_restart_Click(object sender, EventArgs e)
        {
            monitorForm.RunShell(itemConfig.nginx.NginxPath + " -s reload", false, true);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            CheckNginx(true);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (timer < 1)
            {
                if (!check_flag)
                {
                    // 超时的情况
                    SetStatus(0);
                }
                CheckNginx();
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
                    CheckNginx();
                }                
            }

            timer--;
            progressBar1.Value = timer;

            // 检查定时任务
            checkTimedTask();
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                if (get_nginx_conf_run)
                {
                    return;
                }
                get_nginx_conf_run = true;
                linkLabel2.Enabled = false;

                string targetxml = MainForm.TEMP_DIR + string.Format("nginx-{0}.conf", DateTime.Now.ToString("MMddHHmmss"));
                targetxml = targetxml.Replace("\\", "/");
                string serverxml = l_nginx_conf.Text;

                TextEditorForm editor = new TextEditorForm();
                editor.Show(this);

                editor.LoadRemoteFile(new ShellForm(monitorForm), serverxml, targetxml);
            }
            catch { }

            get_nginx_conf_run = false;
            linkLabel2.Enabled = true; 
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string url = l_visit_url.Text;
            if (!string.IsNullOrWhiteSpace(url))
            {
                Process.Start(url);
            }
        }

        private void 条件任务ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ConditionTaskForm form = new ConditionTaskForm(seConfig, itemConfig.nginx.Index);
            form.setCallback(new ConditionTaskForm.AsyncCallback(addConditionTaskFinish));
            form.ShowDialog(this);
        }

        public void addConditionTaskFinish(CmdShell cs)
        {
            cs.Target = itemConfig.nginx.Uuid;

            seConfig.CustomShellList.Add(cs);

            AppConfig.Instance.SaveConfig(2);

            RenderCustomShellList();
        }

        private void CustomTimeTaskToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TimedTaskForm form = new TimedTaskForm(itemConfig.nginx.Index);
            form.setCallback(new TimedTaskForm.AsyncCallback(addTimedTaskFinish));
            form.ShowDialog(this);
        }

        public void addTimedTaskFinish(CmdShell cs)
        {
            cs.Target = itemConfig.nginx.Uuid;

            seConfig.CustomShellList.Add(cs);

            AppConfig.Instance.SaveConfig(2);

            RenderCustomShellList();
        }

        private void projects_MouseUp(object sender, MouseEventArgs e)
        {
            if (projects.SelectedItems.Count > 0)
            {
                contextMenuStrip1.Show(projects, e.Location);
            }
        }

        private void newItemToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NginxMappingItemForm form = new NginxMappingItemForm(seConfig, itemConfig);
            form.ShowDialog(this);

            ReflushMonitorUrl();
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (projects.SelectedItems.Count > 0)
            {
                try
                {
                    ListViewItem item = projects.SelectedItems[0];
                    NginxMonitorUrl pro = (NginxMonitorUrl)item.Tag;

                    NginxMappingItemForm form = new NginxMappingItemForm(seConfig, itemConfig);
                    form.SetNginxMonitorUrl(pro);
                    form.ShowDialog(this);

                    ReflushMonitorUrl();
                }
                catch { }  
            }
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (projects.SelectedItems.Count > 0)
            {
                try
                {
                    ListViewItem item = projects.SelectedItems[0];
                    DialogResult dr = MessageBox.Show(this, "您确定要删除此项吗？", "警告", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                    if(dr == System.Windows.Forms.DialogResult.OK){
                        projects.Items.Remove(item);
                    }
                }
                catch { }  
            }
        }

        private void visitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (projects.SelectedItems.Count > 0)
            {
                try
                {
                    ListViewItem item = projects.SelectedItems[0];
                    NginxMonitorUrl pro = (NginxMonitorUrl)item.Tag;
                    Process.Start(pro.url);
                }
                catch { }                
            }
        }

        private void visit2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (projects.SelectedItems.Count > 0)
            {
                try
                {
                    ListViewItem item = projects.SelectedItems[0];
                    NginxMonitorUrl pro = (NginxMonitorUrl)item.Tag;
                    Process.Start(pro.host);
                }
                catch { }
            }
        }

        private void button6_MouseUp(object sender, MouseEventArgs e)
        {
            contextMenu3.Show(custom_btn, new Point(e.X, e.Y));
        }

        private void btn_run_Click(object sender, EventArgs e)
        {
            string cmdstr = shellView.Text;
            if (!string.IsNullOrWhiteSpace(cmdstr))
            {
                string[] cmdArr = cmdstr.Split('\n');
                foreach (string cmd in cmdArr)
                {
                    monitorForm.RunShell(cmd.Trim(), true);
                    Thread.Sleep(100);
                }
            }  
        }

        private void customShellListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (customShellListView.SelectedItems.Count > 0)
            {
                ListViewItem item = customShellListView.SelectedItems[0];
                if (null != item)
                {
                    CmdShell cmds = (CmdShell)item.Tag;
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
                            sb.AppendLine(string.Format("{0} - {1}", task.DateTime, task.Shell));
                        }
                    }
                    shellView.Text = sb.ToString();
                    if (cmds.TaskType == TaskType.Default)
                    {
                        btn_run.Enabled = true;
                    }
                    return;
                }
            }
            btn_run.Enabled = false;
            shellView.Text = "";
        }

        private void customShellListView_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && customShellListView.SelectedItems.Count > 0)
            {
                contextMenuStrip2.Show(customShellListView, e.Location);
            }
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

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            if (customShellListView.SelectedItems.Count > 0)
            {
                try
                {
                    ListViewItem item = customShellListView.SelectedItems[0];
                    CmdShell cmds = (CmdShell)item.Tag;
                    if(cmds.TaskType == TaskType.Default){
                        CustomShellForm form = new CustomShellForm(seConfig, itemConfig.nginx.Uuid);
                        form.SetUpdater(cmds);
                        form.ShowDialog(this);

                        shellView.Text = "";
                        btn_run.Enabled = false;
                        RenderCustomShellList();
                    }
                    else if (cmds.TaskType == TaskType.Timed)
                    {
                        TimedTaskForm form = new TimedTaskForm(itemConfig.nginx.Index);
                        form.setCallback(new TimedTaskForm.AsyncCallback(editTaskFinish));
                        form.SetUpdater(cmds);
                        form.ShowDialog(this);
                    }
                    else if (cmds.TaskType == TaskType.Condition)
                    {
                        ConditionTaskForm form = new ConditionTaskForm(seConfig, itemConfig.nginx.Index);
                        form.setCallback(new ConditionTaskForm.AsyncCallback(editTaskFinish));
                        form.SetUpdater(cmds);
                        form.ShowDialog(this);
                    }
                }
                catch { }
            }
        }

        public void editTaskFinish(CmdShell cs)
        {
            shellView.Text = "";
            btn_run.Enabled = false;

            AppConfig.Instance.SaveConfig(2);
            RenderCustomShellList();
        }

        private void 自定义命令ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CustomShellForm form = new CustomShellForm(seConfig, itemConfig.nginx.Uuid);
            form.ShowDialog(this);

            RenderCustomShellList();
        }

        private void nginxStartWayClick(object sender, EventArgs e)
        {
            ToolStripMenuItem menu = (ToolStripMenuItem)sender;
            string tag = menu.Tag.ToString();
            if (itemConfig.nginx.Config == null)
            {
                itemConfig.nginx.Config = new Newtonsoft.Json.Linq.JObject();
            }
            if (itemConfig.nginx.Config["startWay"] == null)
            {
                itemConfig.nginx.Config.Add("startWay", tag);
            }
            else
            {
                itemConfig.nginx.Config["startWay"] = tag;
            }
            
            if(tag == "1"){
                nginxpathsStart.Checked = true;
                nginxpathcnginxconf.Checked = false;
            }
            else
            {
                nginxpathsStart.Checked = false;
                nginxpathcnginxconf.Checked = true;
            }
            AppConfig.Instance.SaveConfig(2);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            startBtnMenu.Show(button1, new Point(18, 28));
        }

        
    }
}
