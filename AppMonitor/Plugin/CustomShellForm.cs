using AppMonitor.Bex;
using AppMonitor.Model;
using FastColoredTextBoxNS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AppMonitor.Plugin
{
    public partial class CustomShellForm : CCWin.Skin_Metro
    {
        CmdShell shell = null;
        SessionConfig config;
        string uuid = "";

        public CustomShellForm(SessionConfig _config, string name)
        {
            InitializeComponent();
            SkinUtil.SetFormSkin(this);
            config = _config;
            uuid = name;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string name = stb_name.Text;
            string cmdstr = cmd.Text;
            if(string.IsNullOrWhiteSpace(name)){
                MessageBox.Show(this, "请定义一个名称");
                return;
            }
            if (string.IsNullOrWhiteSpace(cmdstr))
            {
                MessageBox.Show(this, "请输入要执行的命令");
                return;
            }
            List<TaskShell> cmdList = new List<TaskShell>();
            string[] cmds = cmdstr.Split('\n');
            TaskShell task = null;
            foreach(string c in cmds){
                if (!string.IsNullOrWhiteSpace(c.Trim()))
                {
                    task = new TaskShell();
                    task.Uuid = Guid.NewGuid().ToString("N");
                    task.Name = "";
                    task.Shell = c.Trim();
                    cmdList.Add(task);
                }                
            }
            bool isnew = false;
            if(shell == null){
                shell = new CmdShell();
                shell.Uuid = Guid.NewGuid().ToString("N");
                shell.Target = uuid;
                isnew = true;
            }            
            shell.Name = name;
            shell.Type = "自定义脚本";
            shell.TaskType = TaskType.Default;
            shell.ShellList = cmdList;
            if (isnew)
            {
                config.CustomShellList.Add(shell);
            }

            AppConfig.Instance.SaveConfig(2);

            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CustomScriptForm_Load(object sender, EventArgs e)
        {
            if (null != shell)
            {
                stb_name.Text = shell.Name;
                cmd.Clear();
                foreach (TaskShell task in shell.ShellList)
                {
                    cmd.AppendText(task.Shell + "\n");
                }
            }            
        }

        public void SetUpdater(CmdShell cmds)
        {
            shell = cmds;
        }
        
    }
}
