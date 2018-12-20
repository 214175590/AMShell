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
    public partial class ConditionTaskForm : CCWin.Skin_Metro
    {
        private CmdShell cmdShell;
        private SessionConfig config;
        private int index = -1;
        private string[] typeArr = { "springboot", "tomcat", "nginx", "ice"};
        private JObject conditionTemp = new JObject();
        public delegate void RenderFinishDelegate(int index);

        public ConditionTaskForm(SessionConfig seConfig, int _index)
        {
            InitializeComponent();
            SkinUtil.SetFormSkin(this);
            this.config = seConfig;
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

        private void ConditionTaskForm_Load(object sender, EventArgs e)
        {
            scb_template.Location = new Point(532, 157);
            var_list.Location = new Point(532, 277);

            task_name.SkinTxt.KeyUp += AllKeyUp;
            shell.SkinTxt.KeyUp += AllKeyUp;
            shell_name.SkinTxt.KeyUp += AllKeyUp;

            init();

            if (null == cmdShell)
            {
                InitCondition(1, null);
            }
            else
            {
                task_name.Text = cmdShell.Name;
                if (cmdShell.ShellList != null)
                {
                    JObject obj = null;
                    foreach (TaskShell task in cmdShell.ShellList)
                    {
                        obj = new JObject();
                        obj.Add("name", task.Name);
                        obj.Add("code", task.Shell);
                        AddTaskItem(obj);
                    }
                }

                InitCondition(1, new RenderFinishDelegate(RenderConditionFinish));
                // 5c818d723df447819a595d02373d2a6c,N;&5c818d723df447819a595d02373d2a6c,N;|5c818d723df447819a595d02373d2a6c,N
                
            }            
        }

        public void RenderConditionFinish(int index)
        {
            string condition = cmdShell.Condition;
            string[] items = condition.Split(';');            
            if (items.Length >= index)
            {
                string[] arrs = items[index - 1].Split(',');
                ConditionItem ci = null;
                SpringBootMonitorItem spring = null;
                TomcatMonitorItem tomcat = null;
                NginxMonitorItem nginx = null;
                string uuid = "", itemUuid = "";
                int itemIndex = 0;
                SkinComboBox combo = null;
                if (index == 1)
                {
                    combo = scb_condition1;
                }
                else if (index == 2)
                {
                    combo = scb_condition2;
                }
                else if (index == 3)
                {
                    combo = scb_condition3;
                }
                foreach (var item in combo.Items)
                {
                    ci = (ConditionItem)item;
                    if(ci.Index == 0){
                        spring = (SpringBootMonitorItem) ci.Item;
                        uuid = spring.Uuid;
                        itemIndex = spring.Index;
                    }
                    else if (ci.Index == 1)
                    {
                        tomcat = (TomcatMonitorItem)ci.Item;
                        uuid = spring.Uuid;
                        itemIndex = spring.Index;
                    }
                    else if (ci.Index == 2)
                    {
                        nginx = (NginxMonitorItem)ci.Item;
                        uuid = spring.Uuid;
                        itemIndex = spring.Index;
                    }

                    if (index == 1)
                    {
                        itemUuid = arrs[0];
                    }
                    else
                    {
                        itemUuid = arrs[0].Substring(1);
                    }
                    if (uuid == itemUuid)
                    {
                        combo.SelectedItem = item;
                        InitConditionStatus(index, itemIndex);
                        break;
                    }
                }
                // ========================
                if (index == 1)
                {
                    scb_status1.SelectedIndex = arrs[1] == "Y" ? 1 : 0;
                    if (items.Length >= 2)
                    {
                        if (items[index].Substring(0, 1) == "&")
                        {
                            rb_q1.Checked = true;
                        }
                        else
                        {
                            rb_h1.Checked = true;
                        }
                        InitCondition(2, new RenderFinishDelegate(RenderConditionFinish));
                    }
                }
                else if (index == 2)
                {
                    scb_status2.SelectedIndex = arrs[1] == "Y" ? 1 : 0;
                    if (items.Length >= 3)
                    {
                        if (items[index].Substring(0, 1) == "&")
                        {
                            rb_q2.Checked = true;
                        }
                        else
                        {
                            rb_h2.Checked = true;
                        }
                        InitCondition(3, new RenderFinishDelegate(RenderConditionFinish));
                    }
                }
                else if (index == 3)
                {
                    scb_status3.SelectedIndex = arrs[1] == "Y" ? 1 : 0;
                }
            }
        }

        public void InitConditionStatus(int index, int itemIndex)
        {
            if (index == 1)
            {
                scb_status1.Items.Clear();
                if (itemIndex == 0 || itemIndex == 1)
                {
                    scb_status1.Items.Add(conditionTemp["d1"]);
                    scb_status1.Items.Add(conditionTemp["d3"]);
                }
                else
                {
                    scb_status1.Items.Add(conditionTemp["d2"]);
                    scb_status1.Items.Add(conditionTemp["d4"]);
                }
            }
            else if (index == 2)
            {
                scb_status2.Items.Clear();
                if (itemIndex == 0 || itemIndex == 1)
                {
                    scb_status2.Items.Add(conditionTemp["d1"]);
                    scb_status2.Items.Add(conditionTemp["d3"]);
                }
                else
                {
                    scb_status2.Items.Add(conditionTemp["d2"]);
                    scb_status2.Items.Add(conditionTemp["d4"]);
                }
            }
            else if (index == 3)
            {
                scb_status3.Items.Clear();
                if (itemIndex == 0 || itemIndex == 1)
                {
                    scb_status3.Items.Add(conditionTemp["d1"]);
                    scb_status3.Items.Add(conditionTemp["d3"]);
                }
                else
                {
                    scb_status3.Items.Add(conditionTemp["d2"]);
                    scb_status3.Items.Add(conditionTemp["d4"]);
                }
            }
        }
        
        public void init()
        {
            ThreadPool.QueueUserWorkItem((a) =>
            {
                this.BeginInvoke((MethodInvoker)delegate()
                {
                    string json = YSTools.YSFile.readFileToString(MainForm.CONF_DIR + "shell_temp.json");
                    JObject obj = JsonConvert.DeserializeObject<JObject>(json);

                    conditionTemp = (JObject)obj["condition_temp"];                    

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

        public void InitCondition(int index, RenderFinishDelegate dele)
        {
            ThreadPool.QueueUserWorkItem((a) =>
            {
                this.BeginInvoke((MethodInvoker)delegate()
                {
                    if (index == 1)
                    {
                        scb_condition1.Items.Clear();
                    }
                    else if (index == 2)
                    {
                        scb_condition2.Items.Clear();
                    }
                    else if (index == 3)
                    {
                        scb_condition3.Items.Clear();
                    }
                    ConditionItem condi = null;
                    foreach (MonitorItemConfig item in config.MonitorConfigList)
                    {
                        condi = new ConditionItem();
                        if (item.spring != null)
                        {
                            condi.Index = item.spring.Index;
                            condi.Item = item.spring;
                        }
                        else if (item.tomcat != null)
                        {
                            condi.Index = item.tomcat.Index;
                            condi.Item = item.tomcat;
                        }
                        else if (item.nginx != null)
                        {
                            condi.Index = item.nginx.Index;
                            condi.Item = item.nginx;
                        }
                        else if (item.ice != null)
                        {
                            condi.Index = item.ice.Index;
                            condi.Item = item.ice;
                        }

                        if (index == 1)
                        {
                            scb_condition1.Items.Add(condi);
                        }
                        else if (index == 2)
                        {
                            if (scb_condition1.SelectedItem == null 
                                || scb_condition1.SelectedItem.ToString() != condi.ToString())
                            {
                                scb_condition2.Items.Add(condi);
                            }                            
                        }
                        else if (index == 3)
                        {
                            if (scb_condition1.SelectedItem == null
                                || scb_condition1.SelectedItem.ToString() != condi.ToString())
                            {
                                if (scb_condition2.SelectedItem == null
                                || scb_condition2.SelectedItem.ToString() != condi.ToString())
                                {
                                    scb_condition3.Items.Add(condi);
                                }
                            }                            
                        }
                    }                    
                    if (null != dele)
                    {
                        dele(index);
                    }                    
                });
                System.Threading.Thread.Sleep(300);
            });
        }


        private void scb_condition1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Object item = scb_condition1.SelectedItem;
            if (null != item)
            {
                ConditionItem condi = (ConditionItem)item;
                scb_status1.Items.Clear();
                if (condi.Index == 0 || condi.Index == 1)
                {
                    scb_status1.Items.Add(conditionTemp["d1"]);
                    scb_status1.Items.Add(conditionTemp["d3"]);
                }
                else
                {
                    scb_status1.Items.Add(conditionTemp["d2"]);
                    scb_status1.Items.Add(conditionTemp["d4"]);
                }
                scb_status1.SelectedIndex = 0;
            }
            rb_q1.Enabled = true;
            rb_h1.Enabled = true;

            btn_di2_Click(null, null);

            InitCondition(2, null);
        }

        private void scb_condition2_SelectedIndexChanged(object sender, EventArgs e)
        {
            Object item = scb_condition2.SelectedItem;
            if (null != item)
            {
                ConditionItem condi = (ConditionItem)item;
                scb_status2.Items.Clear();
                if (condi.Index == 0 || condi.Index == 1)
                {
                    scb_status2.Items.Add(conditionTemp["d1"]);
                    scb_status2.Items.Add(conditionTemp["d3"]);
                }
                else
                {
                    scb_status2.Items.Add(conditionTemp["d2"]);
                    scb_status2.Items.Add(conditionTemp["d4"]);
                }
                scb_status2.SelectedIndex = 0;
            }
            rb_q2.Enabled = true;
            rb_h2.Enabled = true;

            btn_di2.Enabled = true;

            btn_di3_Click(null, null);

            InitCondition(3, null);
        }

        private void scb_condition3_SelectedIndexChanged(object sender, EventArgs e)
        {
            Object item = scb_condition3.SelectedItem;
            if (null != item)
            {
                ConditionItem condi = (ConditionItem)item;
                scb_status3.Items.Clear();
                if (condi.Index == 0 || condi.Index == 1)
                {
                    scb_status3.Items.Add(conditionTemp["d1"]);
                    scb_status3.Items.Add(conditionTemp["d3"]);
                }
                else
                {
                    scb_status3.Items.Add(conditionTemp["d2"]);
                    scb_status3.Items.Add(conditionTemp["d4"]);
                }
                scb_status3.SelectedIndex = 0;
            }
            btn_di3.Enabled = true;
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
            item.Text = obj["name"].ToString();

            ListViewItem.ListViewSubItem subItem = new ListViewItem.ListViewSubItem();
            subItem.Text = obj["code"].ToString();
            item.SubItems.Add(subItem);

            customShellListView.Items.Add(item);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string name = task_name.Text;
            int count = customShellListView.Items.Count;

            Object item1 = scb_condition1.SelectedItem;
            Object item2 = scb_condition2.SelectedItem;
            Object item3 = scb_condition3.SelectedItem;

            if (string.IsNullOrWhiteSpace(name))
            {
                MessageBox.Show(this, "请输入任务名称");
                task_name.Focus();
            }
            else if (item1 == null)
            {
                MessageBox.Show(this, "请至少选择一个条件");
            }
            else if (count == 0)
            {
                MessageBox.Show(this, "请添加任务指令脚本(Shell)");
                shell_name.Focus();
            }
            else
            {
                string condition = "";
                ConditionItem ci1 = (ConditionItem)item1;
                condition += getItemUuid(ci1) + "," + (scb_status1.SelectedIndex == 1 ? "Y" : "N");
                if(item2 != null){
                    ConditionItem ci2 = (ConditionItem)item2;
                    condition += getItemCondi(1) + getItemUuid(ci2) + "," + (scb_status2.SelectedIndex == 1 ? "Y" : "N");

                    if (item3 != null)
                    {
                        ConditionItem ci3 = (ConditionItem)item2;
                        condition += getItemCondi(2) + getItemUuid(ci3) + "," + (scb_status3.SelectedIndex == 1 ? "Y" : "N");
                    }
                }
                
                ListView.ListViewItemCollection coll = customShellListView.Items;
                if (null == cmdShell)
                {
                    cmdShell = new CmdShell();
                    cmdShell.Uuid = Guid.NewGuid().ToString("N");
                }
                JObject obj = null;
                JArray list = new JArray();
                List<TaskShell> shellList = new List<TaskShell>();
                TaskShell task = null;
                cmdShell.Name = name;
                cmdShell.TaskType = TaskType.Condition;
                cmdShell.Condition = condition;
                cmdShell.Type = "条件任务";
                foreach(ListViewItem item in coll){
                    obj = (JObject)item.Tag;
                    task = new TaskShell();
                    task.Uuid = Guid.NewGuid().ToString("N");
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

        private string getItemUuid(ConditionItem ci)
        {
            string uuid = "";
            if(ci.Index == 0){
                uuid = ((SpringBootMonitorItem)ci.Item).Uuid;
            }
            else if (ci.Index == 1)
            {
                uuid = ((TomcatMonitorItem)ci.Item).Uuid;
            }
            else if (ci.Index == 2)
            {
                uuid = ((NginxMonitorItem)ci.Item).Uuid;
            }
            return uuid;
        }

        private string getItemCondi(int index)
        {
            string ci = "";
            if(index == 1){
                ci = rb_q1.Checked ? "&" : "|";
            }
            else
            {
                ci = rb_q2.Checked ? "&" : "|";
            }
            return ";" + ci;
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
            if(e.Control && e.KeyCode == Keys.S){
                button2_Click(null, null);
            }
        }

        private void CheckBoxGroup1_CheckedChange(object sender, EventArgs e)
        {
            scb_condition2.Enabled = true;
            btn_di2.Enabled = true;
            InitCondition(2, null);

        }

        private void CheckBoxGroup2_CheckedChange(object sender, EventArgs e)
        {
            scb_condition3.Enabled = true;
            btn_di3.Enabled = true;
            InitCondition(3, null);

        }

        private void btn_di2_Click(object sender, EventArgs e)
        {
            scb_condition2.SelectedItem = null;
            scb_status2.Items.Clear();
            btn_di2.Enabled = false;

            rb_q2.Enabled = false;
            rb_q2.Checked = false;
            rb_h2.Enabled = false;
            rb_h2.Checked = false;

            scb_condition3.SelectedItem = null;
            scb_condition3.Enabled = false;
            btn_di3.Enabled = false;
        }

        private void btn_di3_Click(object sender, EventArgs e)
        {
            scb_condition3.SelectedItem = null;
            scb_status3.Items.Clear();
            btn_di3.Enabled = false;
        }

        private void customShellListView_MouseUp(object sender, MouseEventArgs e)
        {
            scb_template.Visible = false;
            var_list.Visible = false;
        }

    }
}
