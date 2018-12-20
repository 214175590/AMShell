using AppMonitor.Bex;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using YSTools;

namespace AppMonitor.Froms
{
    public partial class SshSettingForm : CCWin.Skin_Metro
    {
        private static SessionConfig config = null;

        public SshSettingForm(SessionConfig _config = null)
        {
            config = _config;
            InitializeComponent();
        }

        private void SshSettingForm_Load(object sender, EventArgs e)
        {
            SkinUtil.SetFormSkin(this);

            cb_protocol.SelectedIndex = 0;
            cb_method.SelectedIndex = 0;
            cb_scheme.SelectedIndex = 0;
            cb_fontName.SelectedIndex = 0;
            cb_fontSize.SelectedIndex = 2;

            if (null != config)
            {
                InitUI();
            }

            treeView1.ExpandAll();
        }

        public SessionConfig getSessionConfig()
        {
            return config;
        }

        public void InitUI()
        {
            tb_host.Text = config.Host;
            tb_name.Text = config.Name;
            tb_password.Text = YSEncrypt.DecryptB(config.Password, KeysUtil.PassKey);
            tb_userName.Text = config.UserName;

            cb_protocol.SelectedItem = config.Protocol;
            cb_method.SelectedItem = config.Method;
            cb_scheme.SelectedItem = config.Theme.ColorScheme;
            cb_fontName.SelectedItem = config.Theme.FontName;
            cb_fontSize.SelectedItem = config.Theme.FontSize;
            cb_remenber_pwd.Checked = config.RemenberPwd;           

        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_Ok_Click(object sender, EventArgs e)
        {
            // 保存
            if (config == null)
            {
                config = new SessionConfig();
                config.Index = AppConfig.Instance.SessionConfigDict.Count + 1;
                config.SessionId = "S" + YSTools.YSDateTime.ConvertDateTimeToLong();
                config.Name = string.IsNullOrWhiteSpace(tb_name.Text) ? "New Session" + config.Index : tb_name.Text;
                config.Host = tb_host.Text;
                config.Port = (int) nud_port.Value;
                config.Protocol = cb_protocol.SelectedItem.ToString();
                config.Method = cb_method.SelectedItem.ToString();
                config.RemenberPwd = cb_remenber_pwd.Checked;
                config.UserName = tb_userName.Text;
                config.Password = YSEncrypt.EncryptA(tb_password.Text, KeysUtil.PassKey);

                ColorTheme theme = new ColorTheme();
                theme.ColorScheme = cb_scheme.SelectedItem.ToString();
                theme.FontName = cb_fontName.SelectedItem.ToString();
                theme.FontSize = Convert.ToInt32(cb_fontSize.SelectedItem.ToString());

                config.Theme = theme;

                AppConfig.Instance.SessionConfigDict.Add(config.Index + config.Name, config);
            }
            else
            {
                config.Name = string.IsNullOrWhiteSpace(tb_name.Text) ? "New Session" + config.Index : tb_name.Text;
                config.Host = tb_host.Text;
                config.Port = (int)nud_port.Value;
                config.Protocol = cb_protocol.SelectedItem.ToString();
                config.Method = cb_method.SelectedItem.ToString();
                config.RemenberPwd = cb_remenber_pwd.Checked;
                config.UserName = tb_userName.Text;
                config.Password = YSEncrypt.EncryptA(tb_password.Text, KeysUtil.PassKey);

                config.Theme.ColorScheme = cb_scheme.SelectedItem.ToString();
                config.Theme.FontName = cb_fontName.SelectedItem.ToString();
                config.Theme.FontSize = Convert.ToInt32(cb_fontSize.SelectedItem.ToString());

                if (AppConfig.Instance.SessionConfigDict.ContainsKey(config.SessionId))
                {
                    AppConfig.Instance.SessionConfigDict.Remove(config.SessionId);
                }
                AppConfig.Instance.SessionConfigDict.Add(config.SessionId, config);
            }
            // 保存
            AppConfig.Instance.SaveConfig();

            this.Close();
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            string name = treeView1.SelectedNode.Name;
            if (name == "Connection")
            {
                tabControl1.SelectedIndex = 0;
            }
            else if (name == "Authentication")
            {
                tabControl1.SelectedIndex = 1;
            }
            else if (name == "Setting")
            {
                tabControl1.SelectedIndex = 2;
            }
            else if (name == "Appearance")
            {
                tabControl1.SelectedIndex = 3;
            }
        }
    }
}
