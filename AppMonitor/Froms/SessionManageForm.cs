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
    public partial class SessionManageForm : CCWin.Skin_Metro
    {
        private SessionConfig copy_session = null;
        private SessionConfig curr_session = null;
        private ListViewItem selectedRow = null;

        public SessionManageForm()
        {
            InitializeComponent();
            SkinUtil.SetFormSkin(this);
        }

        private void SessionManageForm_Load(object sender, EventArgs e)
        {
            
            if (AppConfig.Instance.MConfig.OnstartShowSessMgt)
            {
                checkBox_onstart.Checked = true;
            }

            RenderData();
        }

        public void ChangeView()
        {
            if (iconListToolStripMenuItem.Checked)
            {
                listView.View = View.LargeIcon;
            }
            else if (listToolStripMenuItem.Checked)
            {
                listView.View = View.List;
            }
            else if (detailToolStripMenuItem.Checked)
            {
                listView.View = View.Details;
            }
        }

        public void RenderData()
        {
            listView.Items.Clear();

            Dictionary<string, SessionConfig> _session_config_dic = AppConfig.Instance.SessionConfigDict;
            
            foreach (KeyValuePair<string, SessionConfig> item in _session_config_dic)
            {
                AddTableRow(item.Value);                
            }
        }

        public void AddTableRow(SessionConfig conf)
        {
            ListViewItem viewItem = null;
            ListViewItem.ListViewSubItem subitem = null;
            if (null != conf)
            {
                viewItem = new ListViewItem();
                viewItem.Tag = conf;
                viewItem.Text = conf.Name;
                viewItem.ImageIndex = 0;

                subitem = new ListViewItem.ListViewSubItem();
                subitem.Text = conf.Host;
                viewItem.SubItems.Add(subitem);

                subitem = new ListViewItem.ListViewSubItem();
                subitem.Text = "" + conf.Port;
                viewItem.SubItems.Add(subitem);

                subitem = new ListViewItem.ListViewSubItem();
                subitem.Text = conf.Protocol;
                viewItem.SubItems.Add(subitem);

                subitem = new ListViewItem.ListViewSubItem();
                subitem.Text = conf.UserName;
                viewItem.SubItems.Add(subitem);

                listView.Items.Add(viewItem);
            }            
        }

        private void DeleteItem()
        {
            if (selectedRow != null)
            {
                string delid = curr_session.SessionId;

                DialogResult dr = MessageBox.Show("确认删除此项吗？", "提示", MessageBoxButtons.OKCancel);
                if (dr == DialogResult.OK)
                {
                    listView.Items.Remove(selectedRow);

                    if (AppConfig.Instance.SessionConfigDict.ContainsKey(delid))
                    {
                        AppConfig.Instance.SessionConfigDict.Remove(delid);
                    }                   

                    if (copy_session == curr_session)
                    {
                        copy_session = null;
                    }
                    curr_session = null;

                    AppConfig.Instance.SaveConfig(2);
                }
            }
        }

        private void line_select_click(bool ischeck)
        {
            if (ischeck)
            {
                selectedRow = listView.SelectedItems[0];
                curr_session = selectedRow.Tag as SessionConfig;
                ischeck = true;
            }
            else
            {
                selectedRow = null;
                curr_session = null;
            }

            toolSaveAll.Enabled = ischeck;
            toolCopy.Enabled = ischeck;
            toolDelete.Enabled = ischeck;
            toolProperties.Enabled = ischeck;
            toolPaste.Enabled = copy_session != null;

            connectToolStripMenuItem.Enabled = ischeck;
            saveAllToolStripMenuItem.Enabled = ischeck;
            copyToolStripMenuItem.Enabled = ischeck;
            pasteToolStripMenuItem.Enabled = copy_session != null;
            renameToolStripMenuItem.Enabled = ischeck;
            deleteToolStripMenuItem.Enabled = ischeck;
            propertiesToolStripMenuItem.Enabled = ischeck;

            button_conn.Enabled = ischeck;
        }

        private void button_conn_Click(object sender, EventArgs e)
        {
            this.Close();
            // 连接
            Program.MAIN.OpenSshSessionWindow(curr_session);
        }

        private void toolCopy_Click(object sender, EventArgs e)
        {
            if (null != curr_session)
            {
                copy_session = curr_session;

                toolPaste.Enabled = copy_session != null;
                pasteToolStripMenuItem.Enabled = copy_session != null;
            } 
        }

        private void toolPaste_Click(object sender, EventArgs e)
        {
            if (null != copy_session)
            {
                SessionConfig sc = copy_session.Clone();
                AddTableRow(sc);
                AppConfig.Instance.SessionConfigDict.Add(sc.SessionId, sc);
            }
        }

        private void toolDelete_Click(object sender, EventArgs e)
        {
            DeleteItem();
        }

        private void toolProperties_Click(object sender, EventArgs e)
        {
            if (null != curr_session)
            {
                SshSettingForm form = new SshSettingForm(curr_session);
                form.ShowDialog(this);

                RenderData();
            }            
        }

        private void newSessionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SshSettingForm form = new SshSettingForm();
            form.ShowDialog(this);

            RenderData();   
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void SaveAll_Click(object sender, EventArgs e)
        {
            AppConfig.Instance.SaveConfig(2);
        }

        private void renameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(selectedRow != null){
                selectedRow.BeginEdit();
            }
        }

        private void checkBox_onstart_CheckedChanged(object sender, EventArgs e)
        {
            AppConfig.Instance.MConfig.OnstartShowSessMgt = checkBox_onstart.Checked;

            AppConfig.Instance.SaveConfig(1);
        }

        private void listView_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            var c = listView.SelectedItems;
            if (c.Count > 0)
            {
                line_select_click(true);
            }
            else
            {
                line_select_click(false);
            }
        }

        private void ViewToolMenuItem_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem item = sender as ToolStripMenuItem;
            if (item != null)
            {
                iconListToolStripMenuItem.Checked = false;
                listToolStripMenuItem.Checked = false;
                detailToolStripMenuItem.Checked = false;

                item.Checked = true;

                ChangeView();
            }
        }

        private void listView_AfterLabelEdit(object sender, LabelEditEventArgs e)
        {
            int index = e.Item;
            string name = e.Label;
            ListViewItem item = listView.Items[index];
            if (null != item)
            {
                SessionConfig conf = item.Tag as SessionConfig;
                if(string.IsNullOrWhiteSpace(name)){
                    e.CancelEdit = true;
                }
                else
                {
                    conf.Name = name;
                }                
            }
        }

        private void SessionManageForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            // 保存
            AppConfig.Instance.SaveConfig(2);
        }

        private void listView_KeyUp(object sender, KeyEventArgs e)
        {
            var c = listView.SelectedItems;
            if (c.Count > 0)
            {
                if (e.KeyCode == Keys.Delete)
                {
                    DeleteItem();
                }
                else if (e.KeyCode == Keys.F2)
                {
                    renameToolStripMenuItem_Click(null, null);
                }
                else if (e.KeyCode == Keys.C && e.Control)
                {
                    toolCopy_Click(null, null);
                }
                else if (e.KeyCode == Keys.V && e.Control)
                {
                    toolPaste_Click(null, null);
                }
            }                        
        }


    }
}
