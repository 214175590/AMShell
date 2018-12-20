using AppMonitor.Bex;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AppMonitor.Froms
{
    public partial class CustomScriptForm : CCWin.Skin_Metro
    {
        SessionConfig config;
        int index = 999999;

        public CustomScriptForm(SessionConfig _config, int _inx = 999999)
        {
            InitializeComponent();
            SkinUtil.SetFormSkin(this);
            config = _config;
            index = _inx;
        }

        private void CustomScriptForm_Load(object sender, EventArgs e)
        {
            if (index != 999999 && index < config.ShellList.Count)
            {
                string shell = config.ShellList[index];
                if(shell.EndsWith("&")){
                    shell = shell.Substring(0, shell.Length - 1);
                    cb_cr.Checked = true;
                }
                stb_shell.Text = shell;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // 取消
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // 保存
            string cmd = stb_shell.Text;
            if(string.IsNullOrWhiteSpace(cmd) || cmd.Length < 2){
                label_info.Text = "请输入正确的Shell命令";
                return;
            }
            if(cb_cr.Checked){
                cmd += "&";
            }
            label_info.Text = "";

            DefaultConfig.UpdateShellListItem(config.ShellList, index, cmd);

            this.Close();
        }
    }
}
