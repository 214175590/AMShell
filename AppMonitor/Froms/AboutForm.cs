using AppMonitor.Bex;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AppMonitor.Froms
{
    public partial class AboutForm : CCWin.Skin_Metro
    {
        public AboutForm()
        {
            InitializeComponent();
            SkinUtil.SetFormSkin(this);
        }

        private void AboutForm_Load(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("http://blog.yinsin.net");
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("http://v.yinsin.net");
        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("http://www.yinsin.net");
        }
    }
}
