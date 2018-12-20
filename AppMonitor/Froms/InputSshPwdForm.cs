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
    public partial class InputSshPwdForm : CCWin.Skin_Metro
    {
        public delegate void WritePwd(string pwd, bool remenber);
        private WritePwd pwdDelegate;
        private string host = "";
        private string userName = "";

        public InputSshPwdForm(WritePwd _pwd, string host, string userName)
        {
            InitializeComponent();
            SkinUtil.SetFormSkin(this);
            this.pwdDelegate = _pwd;
            this.host = host;
            this.userName = userName;
        }        

        private void InputSshPwdForm_Load(object sender, EventArgs e)
        {
            
            this.Text = this.host;
            label_name.Text = string.Format("请输入[{0}]的密码：", this.userName);

            password.SkinTxt.KeyUp += SkinTxt_KeyUp;
        }

        void SkinTxt_KeyUp(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter){
                string pwd = password.Text;
                if(pwd.Length > 0){
                    this.Close();

                    pwdDelegate(pwd, cb_remenber.Checked);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string pwd = password.Text;
            if (pwd.Length > 0)
            {
                this.Close();

                pwdDelegate(pwd, cb_remenber.Checked);
            }
        }
    }
}
