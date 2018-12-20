using AppMonitor.Bex;
using AppMonitor.Nodel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Tamir.SharpSsh.jsch;

namespace AppMonitor.Froms
{
    public partial class FileAttrForm : CCWin.Skin_Metro
    {
        ChannelSftp.LsEntry file = null;
        SshUser user = null;
        string dir = null;

        public FileAttrForm(ChannelSftp.LsEntry file, SshUser user, String dir)
        {
            InitializeComponent();
            SkinUtil.SetFormSkin(this);
            this.file = file;
            this.user = user;
            this.dir = dir;
        }

        private void FileAttrForm_Load(object sender, EventArgs e)
        {
            this.Text = file.getFilename() + " 的属性";
            if(file.getAttrs().isDir()){
                text_type.Text = "文件夹";
                icon.BackgroundImage = Properties.Resources.folder_64px;
            }
            else
            {
                text_type.Text = getFileExt(file.getFilename());
                icon.Image = Properties.Resources.filen_64px;
            }
            text_name.Text = file.getFilename();
            text_size.Text = Utils.getFileSize(file.getAttrs().getSize());
            text_host.Text = user.Host;
            text_location.Text = dir + file.getFilename();

            text_modified.Text = file.getAttrs().getMtimeString();
            text_owner.Text = getFileOwner(file.getLongname(), 3);
            text_group.Text = getFileOwner(file.getLongname(), 4);
            text_permiss.Text = file.getAttrs().getPermissionsString();

        }

        private string getFileExt(string filename)
        {
            string ext = "";
            if (null != filename && filename.IndexOf(".") != -1)
            {
                ext = filename.Substring(filename.LastIndexOf(".") + 1).ToUpper() + "文件";
            }
            return ext;
        }

        private string getFileOwner(string str, int size)
        {
            string user = "";
            if (null != str && str.Length > 5 && str.IndexOf(" ") != -1)
            {
                string[] arrs = str.Split(' ');
                if (arrs.Length > size)
                {
                    int i = 0, j = 0;
                    foreach (string s in arrs)
                    {
                        if (!string.IsNullOrWhiteSpace(s))
                        {
                            i++;
                            if (i >= size)
                            {
                                user = arrs[j];
                                break;
                            }
                        }
                        j++;
                    }
                }
            }
            return user;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
