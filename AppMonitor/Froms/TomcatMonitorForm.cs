using AppMonitor.Bex;
using AppMonitor.Model;
using AppMonitor.Plugin;
using log4net;
using Newtonsoft.Json.Linq;
using System;
using System.Collections;
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
using Tamir.SharpSsh.java.util;
using Tamir.SharpSsh.jsch;
using YSTools;

namespace AppMonitor.Froms
{
    public partial class TomcatMonitorForm : MonitorBaseForm
    {
        private static ILog logger = LogManager.GetLogger("LogFileAppender");
        MonitorForm monitorForm = null;
        MonitorItemConfig itemConfig = null;
        SessionConfig seConfig;
        YSTools.YSHttpUtility http = new YSTools.YSHttpUtility();
        int timer = 30, resetTimer = 30;
        bool check_flag = false;
        bool get_tomcat_xml_run = false;

        public TomcatMonitorForm(MonitorForm _form, SessionConfig _config, MonitorItemConfig _itemConfig)
        {
            InitializeComponent();
            monitorForm = _form;
            seConfig = _config;
            itemConfig = _itemConfig;
            timer = AppConfig.Instance.MConfig.MonitorTimer;
            resetTimer = timer;
            progressBar1.Maximum = timer;
        }

        private void TomcatMonitorForm_Load(object sender, EventArgs e)
        {
            ReflushMonitorItem();

            RenderCustomShellList();

            // 启动定时器
            timer1.Enabled = true;
            timer1.Start();

            // 加载项目列表
            LoadProjectList();
        }

        public override void ReflushMonitorItem()
        {
            l_name.Text = itemConfig.tomcat.TomcatName;
            string soudir = itemConfig.tomcat.TomcatDir;
            if (soudir != null)
            {
                if (!soudir.EndsWith("/"))
                    soudir += "/";
                l_tomcat_path.Text = soudir;
            }

            l_xml_path.Text = soudir + "conf/server.xml";

            l_visit_url.Text = "http://" + seConfig.Host + ":" + itemConfig.tomcat.TomcatPort;

            tb_port.Text = itemConfig.tomcat.TomcatPort;

            CheckItem();
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

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string url = l_visit_url.Text;
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

                // 加载项目列表
                LoadProjectList();
            }
            timer--;
            progressBar1.Value = timer;

            // 检查定时任务
            checkTimedTask();
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

                string shdir = itemConfig.tomcat.TomcatDir;
                if (null != shdir)
                {
                    if (!shdir.EndsWith("/"))
                    {
                        shdir += "/";
                    }
                }

                string shell = task.Shell;
                if (shell.Contains("{tomcat_dir}"))
                {
                    shell = shell.Replace("{tomcat_dir}", shdir);
                }

                if (shell.Contains("{tomcat_webapps}"))
                {
                    shell = shell.Replace("{tomcat_webapps}", shdir + "webapps/");
                }

                if (shell.Contains("{tomcat_logs}"))
                {
                    shell = shell.Replace("{tomcat_logs}", shdir + "logs/");
                }

                if (shell.Contains("{tomcat_startup}"))
                {
                    shell = shell.Replace("{tomcat_startup}", shdir + "bin/startup.sh");
                }

                if (shell.Contains("{tomcat_shutdown}"))
                {
                    shell = shell.Replace("{tomcat_shutdown}", shdir + "bin/shutdown.sh");
                }
                
                shell = shell.Replace("//", "/");

                monitorForm.RunShell(shell, false);
            });
        }
        #endregion

        #region 加载tomcat项目列表
        public void LoadProjectList()
        {
            ThreadPool.QueueUserWorkItem((a) => {
                List<JObject> itemList = new List<JObject>();
                // 1、获取webapps下的项目
                ArrayList files = (ArrayList)monitorForm.RunSftpShell(string.Format("ls {0}webapps/", l_tomcat_path.Text), false, false);
                if (files != null)
                {
                    string dirname = "";
                    JObject json = null;
                    Object obj = null;
                    for (int ii = 0; ii < files.Count; ii++)
                    {
                        obj = files[ii];
                        if (obj is ChannelSftp.LsEntry)
                        {
                            dirname = ((ChannelSftp.LsEntry)obj).getFilename();
                            if (dirname.IndexOf(".") == -1 && dirname.IndexOf(":") == -1)
                            {
                                json = new JObject();
                                json.Add("name", dirname);
                                json.Add("url", l_visit_url.Text + (dirname == "ROOT" ? "" : "/" + dirname));
                                json.Add("path", l_tomcat_path.Text + "webapps/" + dirname);
                                itemList.Add(json);
                            }
                        }
                    }
                }
                // 2、获取server.xml中的映射配置
                List<JObject> itemList2 = loadTomcatServerProject();
                foreach (JObject p in itemList2)
                {
                    itemList.Add(p);
                }
                // 渲染列表
                this.BeginInvoke((MethodInvoker)delegate()
                {
                    projects.Items.Clear();
                    ListViewItem item = null;
                    ListViewItem.ListViewSubItem subItem = null;
                    foreach (JObject pro in itemList)
                    {
                        item = new ListViewItem();
                        item.Tag = pro;
                        item.Name = pro["name"].ToString();
                        item.Text = pro["url"].ToString();

                        subItem = new ListViewItem.ListViewSubItem();
                        subItem.Text = pro["path"].ToString();
                        item.SubItems.Add(subItem);
                    
                        projects.Items.Add(item);
                    }
                });
            });
        }

        public List<JObject> loadTomcatServerProject()
        {
            List<JObject> itemList = new List<JObject>();
            try
            {
                string serverxml = l_tomcat_path.Text + "conf/server.xml";
                string targetxml = MainForm.TEMP_DIR + string.Format("server-{0}.xml", DateTime.Now.ToString("MMddHHmmss"));
                targetxml = targetxml.Replace("\\", "/");
                monitorForm.RunSftpShell(string.Format("get {0} {1}", serverxml, targetxml), false, false);
                    
                List<System.Collections.Hashtable> list = YSTools.YSXml.readXml(targetxml, "Server");
                if (list != null && list.Count > 0)
                {
                    List<System.Collections.Hashtable> serviceList = null;
                    List<System.Collections.Hashtable> engineList = null;
                    List<System.Collections.Hashtable> hostList = null;
                    string port = null, docBase = "", path = "";
                    JObject json = null;
                    foreach (System.Collections.Hashtable one in list)
                    {
                        if (one["NodeName"].ToString() == "Service")
                        {
                            serviceList = (List<System.Collections.Hashtable>)one["ChildList"];
                            foreach (System.Collections.Hashtable two in serviceList)
                            {
                                if (two["NodeName"].ToString() == "Engine")
                                {
                                    engineList = (List<System.Collections.Hashtable>)two["ChildList"];
                                    foreach (System.Collections.Hashtable three in engineList)
                                    {
                                        if (three["NodeName"].ToString() == "Host")
                                        {
                                            hostList = (List<System.Collections.Hashtable>)three["ChildList"];
                                            foreach (System.Collections.Hashtable four in hostList)
                                            {
                                                if (four["NodeName"].ToString() == "Context")
                                                {
                                                    json = new JObject();
                                                    docBase = four["docBase"].ToString();
                                                    path = four["path"].ToString();
                                                    if (!docBase.EndsWith(path))
                                                    {
                                                        if (docBase.StartsWith("/"))
                                                        {
                                                            json.Add("path", docBase);
                                                        }
                                                        else
                                                        {
                                                            json.Add("path", l_tomcat_path.Text + "webapps/" + docBase);
                                                        }
                                                        json.Add("name", docBase);
                                                        json.Add("url", l_visit_url.Text + "/" + path);
                                                        
                                                        itemList.Add(json);
                                                    }                                                    
                                                }
                                            }
                                        }
                                    }

                                    break;
                                }
                            }
                            if (port != null)
                            {
                                break;
                            }
                        }
                    }

                }

                File.Delete(targetxml);
            }
            catch { }
            return itemList;
        }
        #endregion

        public void SetStatus(int status)
        {
            check_flag = true;
            this.BeginInvoke((MethodInvoker)delegate()
            {
                string tag = this.Tag.ToString();
                string uuid = tag.Substring(3);
                if (status > 0)
                {
                    itemConfig.tomcat.RunStatus = RunState.Normal;
                    pic_run_state.BackgroundImage = Properties.Resources.green_light_48;
                    label_status.Text = "运行正常";
                    this.skinToolTip1.SetToolTip(pic_run_state, label_status.Text);
                    btn_start.Enabled = false;
                    btn_stop.Enabled = true;

                    monitorForm.SetNodeIcon("task-" + uuid, 1);
                }
                else
                {
                    itemConfig.tomcat.RunStatus = RunState.AbNormal;
                    pic_run_state.BackgroundImage = Properties.Resources.org_light_48;
                    label_status.Text = "无法访问";
                    this.skinToolTip1.SetToolTip(pic_run_state, "Tomcat无法访问，请检查问题");
                    btn_start.Enabled = true;
                    btn_stop.Enabled = false;

                    monitorForm.SetNodeIcon("task-" + uuid, 2);
                }
            });
        }

        public void CheckItem()
        {
            button5.Enabled = false;
            button5.Text = "检测中..";
            try
            {
                timer = resetTimer;
                progressBar1.Value = timer;

                string uri = l_visit_url.Text;

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

        private void button5_Click(object sender, EventArgs e)
        {
            CheckItem();
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {       
            try
            {
                if (get_tomcat_xml_run)
                {
                    return;
                }
                get_tomcat_xml_run = true;
                linkLabel2.Enabled = false;

                string targetxml = MainForm.TEMP_DIR + string.Format("server-{0}.xml", DateTime.Now.ToString("MMddHHmmss"));
                targetxml = targetxml.Replace("\\", "/");
                string serverxml = l_xml_path.Text;

                TextEditorForm editor = new TextEditorForm();      
                editor.Show(this);

                editor.LoadRemoteFile(new ShellForm(monitorForm), serverxml, targetxml);
            }
            catch { }

            get_tomcat_xml_run = false;
            linkLabel2.Enabled = true;      
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (button1.Text == "修改")
            {
                tb_port.BorderStyle = BorderStyle.FixedSingle;
                tb_port.ReadOnly = false;
                tb_port.Location = new Point(tb_port.Location.X, tb_port.Location.Y - 2);
                button1.Text = "保存";
            }
            else if (button1.Text == "保存")
            {
                string port = tb_port.Text;
                if (port == itemConfig.tomcat.TomcatPort)
                {
                    label_msg.Text = "端口无变化";
                }
                else
                {
                    DialogResult dr = MessageBox.Show("修改端口后需要重启Tomcat才能生效，您确定要修改吗？", "操作提醒", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                    if (dr == System.Windows.Forms.DialogResult.OK)
                    {
                        button1.Enabled = false;
                        label_msg.Text = "修改中...";
                        try
                        {
                            string targetxml = MainForm.TEMP_DIR + string.Format("server-{0}.xml", DateTime.Now.ToString("MMddHHmmss"));
                            targetxml = targetxml.Replace("\\", "/");
                            string serverxml = l_xml_path.Text;
                            monitorForm.RunSftpShell(string.Format("get {0} {1}", serverxml, targetxml), false, false);
                            string content = YSFile.readFileToString(targetxml);
                            if (null != content)
                            {
                                content = content.Replace(itemConfig.tomcat.TomcatPort, port);

                                YSFile.writeFileByString(targetxml, content);

                                monitorForm.RunSftpShell(string.Format("put {0} {1}", targetxml, serverxml), false, false);

                                itemConfig.tomcat.TomcatPort = port;

                                AppConfig.Instance.SaveConfig(2);

                                label_msg.Text = "修改成功";
                            }
                        }
                        catch (Exception ex)
                        {
                            logger.Error("修改Tomcat端口异常：" + ex.Message, ex);
                            label_msg.Text = "修改失败";
                        }

                    }
                    else
                    {
                        tb_port.Text = itemConfig.tomcat.TomcatPort;
                    }                 
                }

                button1.Enabled = true;
                button1.Text = "修改";
                tb_port.BorderStyle = BorderStyle.None;
                tb_port.ReadOnly = true;
                tb_port.Location = new Point(tb_port.Location.X, tb_port.Location.Y + 2);

                ControlUtil.delayClearText(new DelayDelegate(labelMsg), 2000);
            }
        }

        public void labelMsg()
        {
            label_msg.BeginInvoke((MethodInvoker)delegate()
            {
                label_msg.Text = "";
            });            
        }

        private void button6_MouseUp(object sender, MouseEventArgs e)
        {
            contextMenu2.Show(custom_btn, new Point(e.X, e.Y));
        }

        private void 自定义命令ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CustomShellForm form = new CustomShellForm(seConfig, itemConfig.tomcat.Uuid);
            form.ShowDialog(this);

            RenderCustomShellList();
        }

        private void CustomTimeTaskToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TimedTaskForm form = new TimedTaskForm(itemConfig.tomcat.Index);
            form.setCallback(new TimedTaskForm.AsyncCallback(addTimedTaskFinish));
            form.ShowDialog(this);
        }

        public void addTimedTaskFinish(CmdShell cs)
        {
            cs.Target = itemConfig.tomcat.Uuid;

            seConfig.CustomShellList.Add(cs);

            AppConfig.Instance.SaveConfig(2);

            RenderCustomShellList();
        }

        private void btn_start_Click(object sender, EventArgs e)
        {
            monitorForm.RunShell(l_tomcat_path.Text + "bin/startup.sh", false, true);

            btn_stop.Enabled = true;
            btn_start.Enabled = false;

            CheckItem();
        }

        private void btn_stop_Click(object sender, EventArgs e)
        {
            monitorForm.RunShell(l_tomcat_path.Text + "bin/shutdown.sh", false, true);

            btn_stop.Enabled = false;
            btn_start.Enabled = true;

            CheckItem();
        }

        private void btn_restart_Click(object sender, EventArgs e)
        {
            monitorForm.RunShell(l_tomcat_path.Text + "bin/shutdown.sh", false, true);

            CheckItem();
            ThreadPool.QueueUserWorkItem((a) =>
            {
                Thread.Sleep(15);

                monitorForm.RunShell(l_tomcat_path.Text + "bin/startup.sh", false, true);

                CheckItem();
            });            
        }

        private void projects_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (projects.SelectedItems.Count > 0)
            {
                ListViewItem item = projects.SelectedItems[0];
                if(item != null){
                    Process.Start(item.Text);
                }
            }
        }

        private void ConditionTaskToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            ConditionTaskForm form = new ConditionTaskForm(seConfig, itemConfig.tomcat.Index);
            form.setCallback(new ConditionTaskForm.AsyncCallback(addConditionTaskFinish));
            form.ShowDialog(this);
        }

        public void addConditionTaskFinish(CmdShell cs)
        {
            cs.Target = itemConfig.tomcat.Uuid;

            seConfig.CustomShellList.Add(cs);

            AppConfig.Instance.SaveConfig(2);

            RenderCustomShellList();
        }

        private void btn_run_Click(object sender, EventArgs e)
        {
            string cmdstr = shellView.Text;
            if (!string.IsNullOrWhiteSpace(cmdstr))
            {
                string[] cmdArr = cmdstr.Split('\n');
                foreach (string cmd in cmdArr)
                {
                    monitorForm.RunShell(cmd.Trim(), true, true);
                    Thread.Sleep(100);
                }
            }  
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
                    CustomShellForm form = new CustomShellForm(seConfig, itemConfig.tomcat.Uuid);
                    form.SetUpdater(cmds);
                    form.ShowDialog(this);

                    shellView.Text = "";
                    btn_run.Enabled = false;
                    RenderCustomShellList();
                }
                else if (cmds.TaskType == TaskType.Timed)
                {
                    TimedTaskForm form = new TimedTaskForm(itemConfig.tomcat.Index);
                    form.setCallback(new TimedTaskForm.AsyncCallback(editTaskFinish));
                    form.SetUpdater(cmds);
                    form.ShowDialog(this);
                }
                else if (cmds.TaskType == TaskType.Condition)
                {
                    ConditionTaskForm form = new ConditionTaskForm(seConfig, itemConfig.tomcat.Index);
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
