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
    public partial class SpringBootMonitorForm : MonitorBaseForm
    {
        private static ILog logger = LogManager.GetLogger("LogFileAppender");
        MonitorForm monitorForm = null;
        MonitorItemConfig itemConfig = null;
        SessionConfig seConfig;
        YSTools.YSHttpUtility http = new YSTools.YSHttpUtility();
        int timer = 30, resetTimer = 30;
        bool check_flag = false;

        public SpringBootMonitorForm(MonitorForm _form, SessionConfig _config, MonitorItemConfig _itemConfig)
        {
            InitializeComponent();
            monitorForm = _form;
            seConfig = _config;
            itemConfig = _itemConfig;
            timer = AppConfig.Instance.MConfig.MonitorTimer;
            resetTimer = timer;
            progressBar1.Maximum = timer;
        }

        public override void CloseForm()
        {
            this.Close();
        }

        private void SpringBootMonitorForm_Load(object sender, EventArgs e)
        {
            ReflushMonitorItem();

            RenderCustomShellList();

            // 启动定时器
            timer1.Enabled = true;
            timer1.Start();
        }

        public override void ReflushMonitorItem()
        {
            l_appname.Text = itemConfig.spring.AppName;
            string soudir = itemConfig.spring.ProjectSourceDir;
            if (soudir != null)
            {
                if (!soudir.EndsWith("/"))
                    soudir += "/";
                l_source_path.Text = soudir + itemConfig.spring.AppName;
            }

            string dir = itemConfig.spring.ShFileDir;
            if (null != dir)
            {
                if (!dir.EndsWith("/"))
                {
                    dir += "/";
                }
                l_build_path.Text = dir + itemConfig.spring.BuildFileName;
            }

            l_ctl_path.Text = dir + itemConfig.spring.CrlFileName;

            string homeUrl = itemConfig.spring.HomeUrl;
            if (!string.IsNullOrWhiteSpace(homeUrl))
            {
                l_pro_visit_url.Text = homeUrl;
                CheckItem();
            }
            else
            {
                l_pro_visit_url.Text = "http://" + seConfig.Host + ":[port]/";
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
                if (cmds.Target == itemConfig.spring.Uuid)
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
                if (cmds.Target == itemConfig.spring.Uuid)
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

                string shdir = itemConfig.spring.ShFileDir;
                if (null != shdir)
                {
                    if (!shdir.EndsWith("/"))
                    {
                        shdir += "/";
                    }
                }

                string shell = task.Shell;
                if (shell.Contains("{sh_bin_dir}"))
                {
                    shell = shell.Replace("{sh_bin_dir}", shdir);
                }

                if (shell.Contains("{project_dir}"))
                {
                    shell = shell.Replace("{project_dir}", l_source_path.Text);
                }

                if (shell.Contains("{build_sh_file}"))
                {
                    shell = shell.Replace("{build_sh_file}", itemConfig.spring.BuildFileName);
                }

                if (shell.Contains("{ctl_sh_file}"))
                {
                    shell = shell.Replace("{ctl_sh_file}", itemConfig.spring.CrlFileName);
                }
                shell = shell.Replace("//", "/");

                monitorForm.RunShell(shell, false);
            });
        }
        #endregion

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string url = l_pro_visit_url.Text;
            if (!string.IsNullOrWhiteSpace(url))
            {
                Process.Start(url);
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (timer < 1)
            {
                if (!check_flag)
                {
                    SetStatus(0);
                }
                CheckItem();
            }
            timer--;
            progressBar1.Value = timer;

            // 检查定时任务
            checkTimedTask();
        }

        public void CheckItem()
        {
            try
            {
                button5.Enabled = false;
                button5.Text = "检测中..";

                timer = resetTimer;
                progressBar1.Value = timer;

                string uri = l_pro_visit_url.Text;
                //HttpUtil.get(uri, new DownloadStringCompletedEventHandler(AsyncDownloadCompleted));

                RequestHttpWebRequest req = new RequestHttpWebRequest();
                req.GetResponseAsync(new RequestInfo(uri), x =>
                {
                    try
                    {
                        if (x.StatusCode == HttpStatusCode.OK || x.StatusCode == HttpStatusCode.Found)
                        {
                            // 正常
                            SetStatus(1);
                        }
                        else
                        {
                            // 异常
                            SetStatus(0);
                        }
                    }
                    catch (Exception ex)
                    {
                        SetStatus(0);
                        logger.Error("http请求异常：" + ex.Message, ex);
                    }                    
                });
            }
            catch (Exception e)
            {
                if (e.Message.IndexOf("未能为 SSL/TLS 安全通道建立信任关系") != -1)
                {
                    ServicePointManager.ServerCertificateValidationCallback = (sender, certificate, chain, sslPolicyErrors) => true;
                    CheckItem();
                }
                logger.Error("http请求异常：" + e.Message, e);
            }

            button5.Enabled = true;
            button5.Text = "立即检测";
        }

        private void AsyncDownloadCompleted(object sender, DownloadStringCompletedEventArgs e)
        {
            try
            {
                // 返回结果在 e.Result 里
                string html = e.Result;
                if (e.Error == null || string.IsNullOrWhiteSpace(html))
                {
                    // 正常
                    SetStatus(1);
                    return;
                }
                else if (e.Error != null)
                {
                    string error = e.Error.Message;
                    logger.Error("异步Http请求异常：" + error, e.Error);
                }
                // 异常
                SetStatus(0);
            }
            catch (Exception ex)
            {
                if (ex.InnerException.Message.IndexOf("未能为 SSL/TLS 安全通道建立信任关系") != -1)
                {
                    ServicePointManager.ServerCertificateValidationCallback = (ser, certificate, chain, sslPolicyErrors) => true;
                    CheckItem();
                }
            }
        }

        private void btn_start_Click(object sender, EventArgs e)
        {
            btn_start.Enabled = false;
            monitorForm.RunShell("cd " + itemConfig.spring.ShFileDir, false, true);
            monitorForm.RunShell("./" + itemConfig.spring.CrlFileName + " start", false, true);
        }

        private void btn_stop_Click(object sender, EventArgs e)
        {
            btn_stop.Enabled = false;
            monitorForm.RunShell("cd " + itemConfig.spring.ShFileDir, false, true);
            monitorForm.RunShell("./" + itemConfig.spring.CrlFileName + " stop", false, true);
        }

        private void btn_restart_Click(object sender, EventArgs e)
        {
            btn_start.Enabled = false;
            btn_stop.Enabled = false;
            monitorForm.RunShell("cd " + itemConfig.spring.ShFileDir, false, true);
            monitorForm.RunShell("./" + itemConfig.spring.CrlFileName + " restart", false, true);
        }

        private void btn_build_Click(object sender, EventArgs e)
        {
            monitorForm.RunShell("cd " + itemConfig.spring.ShFileDir, false, true);
            monitorForm.RunShell("./" + itemConfig.spring.BuildFileName, false, true);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            CheckItem();
        }

        public void SetStatus(int status)
        {
            check_flag = true;
            this.BeginInvoke((MethodInvoker)delegate() {
                string tag = this.Tag.ToString();
                string uuid = tag.Substring(3);
                if (status > 0)
                {
                    itemConfig.spring.RunStatus = RunState.Normal;
                    pic_run_state.BackgroundImage = Properties.Resources.green_light_48;
                    label_status.Text = "程序运行正常";
                    this.skinToolTip1.SetToolTip(pic_run_state, label_status.Text);
                    btn_start.Enabled = false;
                    btn_stop.Enabled = true;

                    monitorForm.SetNodeIcon("task-" + uuid, 1);
                }
                else
                {
                    itemConfig.spring.RunStatus = RunState.AbNormal;
                    pic_run_state.BackgroundImage = Properties.Resources.org_light_48;
                    label_status.Text = "程序无法访问";
                    this.skinToolTip1.SetToolTip(pic_run_state, "程序无法访问，请检查问题");
                    btn_start.Enabled = true;
                    btn_stop.Enabled = false;

                    monitorForm.SetNodeIcon("task-" + uuid, 2);
                }    
            });                    
        }

        private void 自定义命令ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CustomShellForm form = new CustomShellForm(seConfig, itemConfig.spring.Uuid);
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
            TimedTaskForm form = new TimedTaskForm(itemConfig.spring.Index);
            form.setCallback(new TimedTaskForm.AsyncCallback(addTimedTaskFinish));
            form.ShowDialog(this);
        }

        public void addTimedTaskFinish(CmdShell cs)
        {
            cs.Target = itemConfig.spring.Uuid;

            seConfig.CustomShellList.Add(cs);

            AppConfig.Instance.SaveConfig(2);

            RenderCustomShellList();
        }

        private void 条件任务ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ConditionTaskForm form = new ConditionTaskForm(seConfig, itemConfig.spring.Index);
            form.setCallback(new ConditionTaskForm.AsyncCallback(addConditionTaskFinish));
            form.ShowDialog(this);
        }

        public void addConditionTaskFinish(CmdShell cs)
        {
            cs.Target = itemConfig.spring.Uuid;

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
                    CustomShellForm form = new CustomShellForm(seConfig, itemConfig.spring.Uuid);
                    form.SetUpdater(cmds);
                    form.ShowDialog(this);

                    shellView.Text = "";
                    btn_run.Enabled = false;
                    RenderCustomShellList();
                }
                else if (cmds.TaskType == TaskType.Timed)
                {
                    TimedTaskForm form = new TimedTaskForm(itemConfig.spring.Index);
                    form.setCallback(new TimedTaskForm.AsyncCallback(editTaskFinish));
                    form.SetUpdater(cmds);
                    form.ShowDialog(this);
                }
                else if (cmds.TaskType == TaskType.Condition)
                {
                    ConditionTaskForm form = new ConditionTaskForm(seConfig, itemConfig.spring.Index);
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

    }
}
