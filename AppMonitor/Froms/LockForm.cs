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
    public partial class LockForm : CCWin.Skin_Metro
    {
        public string lockPwd = null;
        public LockForm()
        {
            InitializeComponent();
            SkinUtil.SetFormSkin(this);
        }

        private void LockForm_Load(object sender, EventArgs e)
        {
            
        }

        public void showForm()
        {
            if (MainForm.isLock)
            {
                button1.Visible = true;
                button2.Visible = true;
                button3.Visible = false;
                button4.Visible = false;
            }
            else
            {
                button1.Visible = false;
                button2.Visible = false;
                button3.Visible = true;
                button4.Visible = true;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // 退出软件
            System.Environment.Exit(0);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string pwd = stb_pwd.Text;
            if(pwd == lockPwd){
                Program.MAIN.unLockForm();
            }
            else
            {
                MessageBox.Show(this, "密码不正确");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            // 锁定
            string pwd = stb_pwd.Text;
            if (string.IsNullOrWhiteSpace(pwd))
            {
                MessageBox.Show(this, "请输入解锁密码，并牢记");
            }
            else
            {
                lockPwd = pwd;
                stb_pwd.Text = "";
                
                Program.MAIN.Lock();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // 取消
            this.Close();
        }
    }
}
