using AppMonitor.Bex;
using AppMonitor.Model;
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
    public partial class NginxMappingItemForm : CCWin.Skin_Metro
    {
        NginxMonitorUrl pro = null;
        MonitorItemConfig itemConfig = null;
        SessionConfig seConfig;
        public NginxMappingItemForm(SessionConfig seConfig, MonitorItemConfig itemConfig)
        {
            InitializeComponent();
            SkinUtil.SetFormSkin(this);
            this.itemConfig = itemConfig;
            this.seConfig = seConfig;
        }

        private void NginxMappingItemForm_Load(object sender, EventArgs e)
        {
            if(pro == null){
                stb_url.Text = string.Format("http://{0}", this.seConfig.Host);
                stb_host.Text = "http://ip:port";
                cb_check.Checked = true;
            }
        }

        public void SetNginxMonitorUrl(NginxMonitorUrl pro)
        {
            this.pro = pro;

            stb_url.Text = pro.url;
            stb_host.Text = pro.host;
            cb_check.Checked = pro.check;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            bool isnew = false;
            if(this.pro == null){
                pro = new NginxMonitorUrl();
                pro.RunStatus = RunState.NoCheck;
                isnew = true;
            }
            pro.url = stb_url.Text;
            pro.host = stb_host.Text;
            pro.check = cb_check.Checked;

            if(isnew){
                itemConfig.nginx.MonitorList.Add(pro);
            }

            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
