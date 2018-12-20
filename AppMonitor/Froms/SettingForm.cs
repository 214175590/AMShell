using AppMonitor.Bex;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AppMonitor.Froms
{
    public partial class SettingForm : CCWin.Skin_Metro
    {
        public SettingForm()
        {
            InitializeComponent();
            SkinUtil.SetFormSkin(this);
        }

        private void SettingForm_Load(object sender, EventArgs e)
        {
            cb_showMenuBar.Checked = AppConfig.Instance.MConfig.ShowMenuBar;
            cb_showStatusBar.Checked = AppConfig.Instance.MConfig.ShowStatusBar;
            monitorTimer.Value = AppConfig.Instance.MConfig.MonitorTimer;

            DirectoryInfo dire = new DirectoryInfo(MainForm.APP_DIR + "\\skin");
            if(dire.Exists){
                FileInfo[] files = dire.GetFiles();
                ListViewItem item = null;
                int index = 0;
                foreach(FileInfo file in files){
                    imageList1.Images.Add(new Bitmap(file.FullName));
                    item = new ListViewItem();
                    item.Tag = index;
                    item.Text = file.Name;
                    item.ImageIndex = index;
                    item.Checked = index == AppConfig.Instance.MConfig.SkinIndex;
                    listView1.Items.Add(item);
                    index++;
                }
                
            }

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                ListViewItem item = listView1.SelectedItems[0];
                foreach(ListViewItem o in listView1.Items){
                    o.Checked = false;
                }
                item.Checked = true;
            }
        }

        private void SettingForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            //AppConfig.Instance.SaveConfig(1);
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in listView1.Items)
            {
                if (item.Checked)
                {
                    AppConfig.Instance.MConfig.SkinIndex = Convert.ToInt32(item.Tag.ToString());
                    break;
                }
            }

            AppConfig.Instance.SaveConfig(1);

            this.Close();
        }

        private void cb_showStatusBar_CheckedChanged(object sender, EventArgs e)
        {
            AppConfig.Instance.MConfig.ShowStatusBar = cb_showStatusBar.Checked;            
        }

        private void cb_showMenuBar_CheckedChanged(object sender, EventArgs e)
        {
            AppConfig.Instance.MConfig.ShowMenuBar = cb_showMenuBar.Checked;
        }

        private void monitorTimer_ValueChanged(object sender, EventArgs e)
        {
            AppConfig.Instance.MConfig.MonitorTimer = (int) monitorTimer.Value;
        }
    }
}
