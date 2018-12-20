using AppMonitor.Bex;
using AppMonitor.Model;
using CCWin.SkinControl;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using Tamir.SharpSsh.java.lang;

namespace AppMonitor.Froms
{
    public partial class TimedTaskForm : CCWin.Skin_Metro
    {
        private CmdShell cmdShell;
        private int index = -1;
        private string[] typeArr = { "springboot", "tomcat", "nginx", "ice"};
        public TimedTaskForm(int _index)
        {
            InitializeComponent();
            SkinUtil.SetFormSkin(this);
            this.index = _index;
        }

        public delegate void AsyncCallback(CmdShell shell);

        private AsyncCallback callback;
        private bool isClickItem = false;

        public void setCallback(AsyncCallback _callback)
        {
            this.callback = _callback;
        }

        public void SetUpdater(CmdShell cmds)
        {
            cmdShell = cmds;
        }

        private void TimedTaskForm_Load(object sender, EventArgs e)
        {
            date.MinDate = DateTime.Now;
            scb_cycle.SelectedIndex = 0;

            if (null != cmdShell)
            {
                task_name.Text = cmdShell.Name;

                if (cmdShell.ShellList != null)
                {
                    JObject obj = null;
                    foreach(TaskShell task in cmdShell.ShellList){
                        obj = new JObject();
                        obj.Add("time", task.DateTime);
                        obj.Add("name", task.Name);
                        obj.Add("code", task.Shell);
                        AddTaskItem(obj);
                    }
                }
            }

            scb_template.Location = new Point(532, 157);
            var_list.Location = new Point(532, 277);

            task_name.SkinTxt.KeyUp += AllKeyUp;
            shell.SkinTxt.KeyUp += AllKeyUp;
            shell_name.SkinTxt.KeyUp += AllKeyUp;

            init();
        }
        
        public void init()
        {
            ThreadPool.QueueUserWorkItem((a) =>
            {
                this.BeginInvoke((MethodInvoker)delegate()
                {
                    string json = YSTools.YSFile.readFileToString(MainForm.CONF_DIR + "shell_temp.json");
                    JObject obj = JsonConvert.DeserializeObject<JObject>(json);
                    JObject shellTemp = (JObject)obj["task_shell_temp"][typeArr[index]];
                    if (null != shellTemp)
                    {
                        ListViewItem item = null;
                        ListViewItem.ListViewSubItem subItem = null;
                        foreach (var o in shellTemp)
                        {
                            item = new ListViewItem();
                            item.Tag = o;
                            item.Text = o.Key;

                            subItem = new ListViewItem.ListViewSubItem();
                            subItem.Text = o.Value.ToString();

                            item.SubItems.Add(subItem);
                            scb_template.Items.Add(item);
                        }
                    }

                    JArray varsTemp = (JArray)obj["vars_temp"][typeArr[index]];
                    if (null != varsTemp)
                    {
                        ListViewItem item = null;
                        ListViewItem.ListViewSubItem subItem = null;
                        foreach (var o in varsTemp)
                        {
                            item = new ListViewItem();
                            item.Tag = o;
                            item.Text = o["value"].ToString();

                            subItem = new ListViewItem.ListViewSubItem();
                            subItem.Text = o["desc"].ToString();

                            item.SubItems.Add(subItem);
                            var_list.Items.Add(item);
                        }
                    }

                });
            });
        }



        private void skinComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = scb_cycle.SelectedIndex;

            date.Visible = true;
            date.Enabled = true;
            week_panel.Visible = false;
            date.MinDate = DateTime.Now.AddYears(-10);
            label3.Text = "日期：";

            if(index == 0){ // 一次
                date.MinDate = DateTime.Now;
            }
            else if (index == 1)
            {
                // 每天                
                date.Enabled = false;                
            }
            else if (index == 2)
            {
                // 每周
                week_panel.Visible = true;
                label3.Text = "星期：";
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            scb_template.Visible = !scb_template.Visible;
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var_list.Visible = !var_list.Visible;
        }

        private void var_list_MouseClick(object sender, MouseEventArgs e)
        {
            isClickItem = true;
            var c = var_list.SelectedItems;
            if (c.Count > 0)
            {
                var_list.Visible = false;
                ListViewItem item = (ListViewItem)var_list.SelectedItems[0];
                if (null != item)
                {
                    string s = shell.Text;
                    string vars = item.Text;
                    int idx = shell.SkinTxt.SelectionStart;
                    s = s.Insert(idx, string.Format("{{{0}}}", vars));
                    shell.Text = s;
                    shell.SkinTxt.SelectionStart = idx + vars.Length + 2;
                    shell.SkinTxt.Focus();
                }
            }
        }

        private void var_list_MouseUp(object sender, MouseEventArgs e)
        {
            if (!isClickItem)
            {
                var_list.Visible = false;
            }
            isClickItem = false;
        }

        private void scb_template_MouseClick(object sender, MouseEventArgs e)
        {
            isClickItem = true;
            var c = scb_template.SelectedItems;
            if (c.Count > 0)
            {
                scb_template.Visible = false;
                ListViewItem item = (ListViewItem)scb_template.SelectedItems[0];
                if (null != item)
                {
                    shell_name.Text = item.Text;
                    shell.Text = item.SubItems[1].Text;
                }
            }
        }

        private void scb_template_MouseUp(object sender, MouseEventArgs e)
        {
            if (!isClickItem)
            {
                scb_template.Visible = false;
            }
            isClickItem = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // 新增
            string timestr = "";
            // 1、获取执行周期
            int index = scb_cycle.SelectedIndex;
            timestr += index + "|";
            // 2、获取执行日期,除了每天周期不需要知道日期，其他都需要知道日期
            string rq = "";
            if(index == 0){// 一次
                rq = date.Value.ToString("yyyy-MM-dd");
            }
            else if (index == 1)
            { 
                // 每天
                rq = "";       
            }
            else if(index == 2)
            {
                // 每周
                rq += (week1.Checked ? ",1" : "");
                rq += (week2.Checked ? ",2" : "");
                rq += (week3.Checked ? ",3" : "");
                rq += (week4.Checked ? ",4" : "");
                rq += (week5.Checked ? ",5" : "");
                rq += (week6.Checked ? ",6" : "");
                rq += (week0.Checked ? ",7" : "");
                if (!string.IsNullOrWhiteSpace(rq))
                {
                    rq = rq.Substring(1);
                }
            }
            else if (index == 3)
            {
                // 每月
                rq = date.Value.ToString("dd");
            }
            else if (index == 4)
            {
                // 每年
                rq = date.Value.ToString("MM-dd");
            }
            timestr += rq + "|";
            // 3、获取执行时间
            timestr += time.Value.ToString("HH:mm:ss");

            string name = shell_name.Text;
            string code = shell.Text;

            if (string.IsNullOrWhiteSpace(name))
            {
                MessageBox.Show(this, "请输入指令名称");
                shell_name.Focus();
            }
            else if (string.IsNullOrWhiteSpace(code))
            {
                MessageBox.Show(this, "请输入指令脚本(Shell)");
                shell.Focus();
            }
            else
            {
                JObject obj = new JObject();
                obj.Add("time", timestr);
                obj.Add("name", name);
                obj.Add("code", code);
                AddTaskItem(obj);

                shell.Text = "";
                shell_name.Text = "";
            }
        }

        private void AddTaskItem(JObject obj)
        {
            ListViewItem item = new ListViewItem();
            item.Tag = obj;
            item.Text = obj["time"].ToString();

            ListViewItem.ListViewSubItem subItem = new ListViewItem.ListViewSubItem();
            subItem.Text = obj["name"].ToString();
            item.SubItems.Add(subItem);

            subItem = new ListViewItem.ListViewSubItem();
            subItem.Text = obj["code"].ToString();
            item.SubItems.Add(subItem);

            customShellListView.Items.Add(item);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string name = task_name.Text;
            int count = customShellListView.Items.Count;
            if (string.IsNullOrWhiteSpace(name))
            {
                MessageBox.Show(this, "请输入任务名称");
                task_name.Focus();
            }
            else if (count == 0)
            {
                MessageBox.Show(this, "请添加任务指令脚本(Shell)");
                shell_name.Focus();
            }
            else
            {
                ListView.ListViewItemCollection coll = customShellListView.Items;
                if (null == cmdShell)
                {
                    cmdShell = new CmdShell();
                    cmdShell.Type = "定时任务";
                    cmdShell.TaskType = TaskType.Timed;
                }                
                cmdShell.Name = name;
                
                JObject obj = null;
                JArray list = new JArray();
                List<TaskShell> shellList = new List<TaskShell>();
                TaskShell task = null;
                
                foreach(ListViewItem item in coll){
                    obj = (JObject)item.Tag;
                    task = new TaskShell();
                    task.Uuid = Guid.NewGuid().ToString("N");
                    task.DateTime = obj["time"].ToString();
                    task.Shell = obj["code"].ToString();
                    task.Name = obj["name"].ToString();
                    shellList.Add(task);
                }
                cmdShell.ShellList = shellList;

                if (null != this.callback)
                {
                    this.callback(cmdShell);
                }

                this.Close();
            }
        }

        private void deleteItemToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var c = customShellListView.SelectedItems;
            if (c.Count > 0)
            {
                if(MessageBox.Show(this, "您确定要删除此记录吗？", "警告", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
                {
                    ListViewItem item = (ListViewItem)customShellListView.SelectedItems[0];
                    if (null != item)
                    {
                        customShellListView.Items.Remove(item);
                    }
                }                
            }
        }

        private void upToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var c = customShellListView.SelectedItems;
            if (c.Count > 0)
            {
                int len = customShellListView.Items.Count;
                int index = customShellListView.SelectedIndices[0];
                if (index > 0)
                {
                    JObject[] list = new JObject[len];
                    for (int i = 0; i < len; i++)
                    {
                        list[i] = (JObject)customShellListView.Items[i].Tag;
                    }
                    JObject temp = list[index];
                    list[index] = list[index - 1];
                    list[index - 1] = temp;

                    customShellListView.Items.Clear();

                    foreach (JObject obj in list)
                    {
                        AddTaskItem(obj);
                    }
                }
            }
        }

        private void downToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var c = customShellListView.SelectedItems;
            if (c.Count > 0)
            {
                int len = customShellListView.Items.Count;
                int index = customShellListView.SelectedIndices[0];
                if (index < len - 1)
                {
                    JObject[] list = new JObject[len];
                    for (int i = 0; i < len; i++)
                    {
                        list[i] = (JObject)customShellListView.Items[i].Tag;
                    }
                    JObject temp = list[index];
                    list[index] = list[index + 1];
                    list[index + 1] = temp;

                    customShellListView.Items.Clear();

                    foreach (JObject obj in list)
                    {
                        AddTaskItem(obj);
                    }
                }
            }
        }

        private void shell_Enter(object sender, EventArgs e)
        {
            scb_template.Visible = false;
            var_list.Visible = false;
        }

        private void shell_name_Enter(object sender, EventArgs e)
        {
            scb_template.Visible = false;
            var_list.Visible = false;
        }

        private void AllKeyUp(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.S)
            {
                button2_Click(null, null);
            }
        }

        private void customShellListView_MouseUp(object sender, MouseEventArgs e)
        {
            scb_template.Visible = false;
            var_list.Visible = false;
        }

    }
}
