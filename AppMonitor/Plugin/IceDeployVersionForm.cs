using AppMonitor.Bex;
using AppMonitor.Model;
using FastColoredTextBoxNS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Tamir.SharpSsh.jsch;

namespace AppMonitor.Plugin
{
    public partial class IceDeployVersionForm : CCWin.Skin_Metro
    {
        AppMonitor.Froms.MonitorForm monitorForm;
        SessionConfig config;
        IceMonitorItem ice;
        private bool run = false;
        private int step = 0;
        private string mavenHome;
        private Color backColor0 = Color.FromArgb(255, 80, 80, 80);
        private Color backColor1 = Color.FromArgb(255, 73, 178, 230);
        private Color backColor2 = Color.FromArgb(255, 28, 135, 70);

        public IceDeployVersionForm(AppMonitor.Froms.MonitorForm monitorForm, SessionConfig _config, IceMonitorItem ice)
        {
            InitializeComponent();
            SkinUtil.SetFormSkin(this);
            this.monitorForm = monitorForm;
            config = _config;
            this.ice = ice;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            stb_icexml.Enabled = checkBox1.Checked;
            btn_choose_xml.Enabled = checkBox1.Checked;
        }

        private void stb_local_pdir_DragDrop(object sender, DragEventArgs e)
        {
            String[] files = e.Data.GetData(DataFormats.FileDrop, false) as String[];
            stb_local_pdir.Text = files[0];
            this.stb_local_pdir.SkinTxt.Cursor = System.Windows.Forms.Cursors.IBeam; //还原鼠标形状
        }

        private void stb_icexml_DragDrop(object sender, DragEventArgs e)
        {
            String[] files = e.Data.GetData(DataFormats.FileDrop, false) as String[];
            stb_icexml.Text = files[0];
            this.stb_icexml.SkinTxt.Cursor = System.Windows.Forms.Cursors.IBeam; //还原鼠标形状
        }

        private void stb_maven_xml_DragDrop(object sender, DragEventArgs e)
        {
            String[] files = e.Data.GetData(DataFormats.FileDrop, false) as String[];
            stb_maven_xml.Text = files[0];
            this.stb_maven_xml.SkinTxt.Cursor = System.Windows.Forms.Cursors.IBeam; //还原鼠标形状
        }

        private void IceDeployVersionForm_Load(object sender, EventArgs e)
        {
            stb_remote_pdir.Text = ice.IceSrvDir;
            if(ice.Project != null){
                if(null != ice.Project.LocalCodePath){
                    stb_local_pdir.Text = ice.Project.LocalCodePath;
                }
                if (null != ice.Project.LocalIceXmlPath)
                {
                    stb_icexml.Text = ice.Project.LocalIceXmlPath;
                }
                if (null != ice.Project.MavenSetting)
                {
                    stb_maven_xml.Text = ice.Project.MavenSetting;
                }
            }

            stb_local_pdir.SkinTxt.TextChanged += stb_local_pdir_TextChanged;

            stb_local_pdir.SkinTxt.AllowDrop = true;
            stb_local_pdir.SkinTxt.DragDrop += stb_local_pdir_DragDrop;
            stb_local_pdir.SkinTxt.DragEnter += stb_local_pdir_DragEnter;

            stb_icexml.SkinTxt.AllowDrop = true;
            stb_icexml.SkinTxt.DragDrop += stb_icexml_DragDrop;
            stb_icexml.SkinTxt.DragEnter += stb_icexml_DragEnter;


            stb_maven_xml.SkinTxt.AllowDrop = true;
            stb_maven_xml.SkinTxt.DragDrop += stb_maven_xml_DragDrop;
            stb_maven_xml.SkinTxt.DragEnter += stb_maven_xml_DragEnter;

            if (stb_maven_xml.Text == "")
            {
                try
                {
                    CmdResult result = Command.run("mvn -v");
                    if (result.isFailed())
                    {
                        errorLabel.Text = "检测到未安装Maven或者未设置Maven环境变量，需手动打包";
                    }
                    else if (result.isSuccess())
                    {
                        // Maven home: F:\Server\apache-maven-3.3.9\bin\..
                        int index = result.result.IndexOf("Maven home:");
                        if (index != -1)
                        {
                            int len = result.result.IndexOf("..", index);
                            string line = result.result.Substring(index, len - index);
                            len = "Maven home:".Length;
                            mavenHome = line.Substring(len, line.IndexOf("bin\\") - len);
                            mavenHome = Utils.PathWinToLinux(mavenHome.Trim());
                            if (File.Exists(mavenHome + "conf/settings.xml"))
                            {
                                stb_maven_xml.Text = mavenHome + "conf/settings.xml";
                            }
                            else
                            {
                                errorLabel.Text = mavenHome + "conf/settings.xml 未找到，请手动指定";
                            }
                        }
                    }
                }
                catch(Exception ex) {
                    Console.WriteLine(ex.Message);
                }
            }            
        }

        void stb_local_pdir_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Link;
                this.stb_local_pdir.SkinTxt.Cursor = System.Windows.Forms.Cursors.Arrow;  //指定鼠标形状（更好看）  
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        void stb_icexml_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Link;
                this.stb_icexml.SkinTxt.Cursor = System.Windows.Forms.Cursors.Arrow;  //指定鼠标形状（更好看）  
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        void stb_maven_xml_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Link;
                this.stb_maven_xml.SkinTxt.Cursor = System.Windows.Forms.Cursors.Arrow;  //指定鼠标形状（更好看）  
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        void stb_local_pdir_TextChanged(object sender, EventArgs e)
        {
            string dir = stb_local_pdir.Text;
            string path = stb_icexml.Text;
            if (!string.IsNullOrWhiteSpace(dir) && string.IsNullOrWhiteSpace(path))
            {
                if (Directory.Exists(dir))
                {
                    dir = dir.Replace("\\", "/");
                    if(!dir.EndsWith("/")){
                        dir += "/";
                    }
                    path = string.Format("{0}icedeploy/config/{1}.xml", dir, ice.AppName);
                    if (File.Exists(path))
                    {
                        stb_icexml.Text = path;
                    }
                }
            }            
        }

        private void btn_choose_xml_Click(object sender, EventArgs e)
        {
            string dir = stb_local_pdir.Text;
            if(!string.IsNullOrWhiteSpace(dir)){
                openFileDialog1.InitialDirectory = dir;
            }
            DialogResult dr = openFileDialog1.ShowDialog(this);
            if (dr == System.Windows.Forms.DialogResult.OK)
            {
                string[] path = openFileDialog1.FileNames;
                stb_icexml.Text = path[0];
            }
        }

        private void btn_choose_dir_Click(object sender, EventArgs e)
        {
            DialogResult dr = folderBrowserDialog1.ShowDialog(this);
            if(dr == System.Windows.Forms.DialogResult.OK){
                string path = folderBrowserDialog1.SelectedPath;
                stb_local_pdir.Text = path;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string name = btn_start.Text;
            if (name == "重置状态")
            {
                btn_start.Text = "开始部署";
                errorLabel.Text = "";
                pb_state1.BackgroundImage = Properties.Resources.Circle_72px0;
                l_state1.BackColor = backColor0;
                line_state1.BackColor = backColor0;
                pb_state2.BackgroundImage = Properties.Resources.Circle_72px0;
                l_state2.BackColor = backColor0;
                line_state2.BackColor = backColor0;
                pb_state3.BackgroundImage = Properties.Resources.Circle_72px0;
                l_state3.BackColor = backColor0;
                line_state3.BackColor = backColor0;
                pb_state4.BackgroundImage = Properties.Resources.Circle_72px0;
                l_state4.BackColor = backColor0;
                return;
            }

            // 开始部署
            string local_pdir = stb_local_pdir.Text;
            string xml = stb_icexml.Text;
            string remote_pdir = stb_remote_pdir.Text;
            string mvnxml = stb_maven_xml.Text;
            if (string.IsNullOrWhiteSpace(local_pdir))
            {
                MessageBox.Show(this, "请选择本地代码目录");
                return;
            }
            if (!Directory.Exists(local_pdir))
            {
                MessageBox.Show(this, "本地代码目录不存在，请检查");
                return;
            }
            if (checkBox1.Checked && string.IsNullOrWhiteSpace(local_pdir))
            {
                MessageBox.Show(this, "请选择ice接口服务配置文件(" + ice.AppName + ".xml)");
                return;
            }
            if (string.IsNullOrWhiteSpace(remote_pdir))
            {
                MessageBox.Show(this, "请输入服务器ICE项目目录");
                return;
            }
            if (checkBox2.Checked && string.IsNullOrWhiteSpace(mvnxml))
            {
                MessageBox.Show(this, "自动打包需要配置Maven环境变量，并指定settings.xml");
                return;
            }

            if (ice.Project == null)
            {
                ice.Project = new IceProjectAttr();
            }
            ice.Project.LocalCodePath = local_pdir;
            ice.Project.LocalIceXmlPath = xml;
            ice.Project.MavenSetting = mvnxml;
            AppConfig.Instance.SaveConfig(2);

            // 开始
            run = true;
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (run)
            {
                if(step == 0){
                    gifBox1.Visible = true;
                    btn_start.Enabled = false;
                    btn_cancel.Enabled = false;
                    pb_state1.BackgroundImage = Properties.Resources.Circle_72px1;
                    l_state1.BackColor = backColor1;

                    if (checkBox2.Checked)
                    {
                        // 1、mvn clean
                        step = 1;
                        MvnClean();
                    }
                    else
                    {
                        step = 3;
                    }                                       
                } else if(step == 2){
                    // 2、mvn package 打包
                    MvnPackage();
                }
                else if (step == 3)
                {
                    // 3、上传war包
                    if (checkBox1.Checked)
                    {
                        UploadWar();
                    }
                    else
                    {
                        step = 4;
                    }
                }
                else if (step == 4)
                {
                    // 4、更新配置
                    if (checkBox1.Checked)
                    {
                        pb_state1.BackgroundImage = Properties.Resources.Circle_72px2;
                        l_state1.BackColor = backColor2;
                        line_state1.BackColor = backColor2;
                        pb_state2.BackgroundImage = Properties.Resources.Circle_72px1;
                        l_state2.BackColor = backColor1;

                        UpdateConfig();
                    }
                    else
                    {
                        step = 5;
                    }
                }
                else if (step == 5)
                {
                    // 5、重启服务

                    pb_state1.BackgroundImage = Properties.Resources.Circle_72px2;
                    l_state1.BackColor = backColor2;

                    line_state1.BackColor = backColor2;
                    pb_state2.BackgroundImage = Properties.Resources.Circle_72px2;
                    l_state2.BackColor = backColor2;

                    line_state2.BackColor = backColor2;
                    pb_state3.BackgroundImage = Properties.Resources.Circle_72px1;
                    l_state3.BackColor = backColor1;

                    RestartService();
                }
                else if (step == 6)
                {
                    // 6、完成
                    pb_state1.BackgroundImage = Properties.Resources.Circle_72px2;
                    l_state1.BackColor = backColor2;

                    line_state1.BackColor = backColor2;
                    pb_state2.BackgroundImage = Properties.Resources.Circle_72px2;
                    l_state2.BackColor = backColor2;

                    line_state2.BackColor = backColor2;
                    pb_state3.BackgroundImage = Properties.Resources.Circle_72px2;
                    l_state3.BackColor = backColor2;

                    line_state3.BackColor = backColor2;
                    pb_state4.BackgroundImage = Properties.Resources.Circle_72px2;
                    l_state4.BackColor = backColor2;

                    run = false;
                    MessageBox.Show(this, "部署完成，正在启动服务...");                    
                }
            }
            else
            {
                timer1.Stop();
                btn_start.Text = "重置状态";
                btn_start.Enabled = true;
                btn_cancel.Enabled = true;
                gifBox1.Visible = false;
            }
        }

        public void MvnClean()
        {
            try
            {
                string path = stb_local_pdir.Text;
                String cmd = "cd " + path + " & mvn clean";
                CmdResult result = Command.run(cmd);
                step = 2;
            }
            catch (Exception ex)
            {
                errorLabel.Text = "mvn clean 异常：" + ex.Message;
                run = false;
                MessageBox.Show(this, errorLabel.Text);
            }            
        }

        public void MvnPackage()
        {
            try
            {
                string path = stb_local_pdir.Text;
                DirectoryInfo dire = new DirectoryInfo(path);
                String cmd = string.Format("cd {0} & mvn package --settings {1} -DskipTests", dire.Parent.FullName, stb_maven_xml.Text);
                CmdResult result = Command.run(cmd);
                if (result.isFailed())
                {
                    errorLabel.Text = "打包失败：" + result.result;
                    run = false;
                    MessageBox.Show(this, errorLabel.Text);
                }
                else if (result.isSuccess())
                {
                    step = 3;
                }
            }
            catch (Exception ex)
            {
                errorLabel.Text = "mvn package 异常：" + ex.Message;
                run = false;
                MessageBox.Show(this, errorLabel.Text);
            }
        }

        public void UploadWar()
        {
            try
            {
                string local_pdir = stb_local_pdir.Text;
                string remote_pdir = stb_remote_pdir.Text;
                string targetDir = Utils.PathEndAddSlash(Utils.PathWinToLinux(local_pdir)) + "target/";
                DirectoryInfo dire = new DirectoryInfo(targetDir);
                FileInfo warfile = null;
                if(dire.Exists){
                    FileInfo[] files = dire.GetFiles();
                    foreach(FileInfo file in files){
                        if(file.Extension == ".war"){
                            warfile = file;
                            break;
                        }
                    }
                }
                if (null != warfile)
                {
                    string localPath = warfile.FullName;
                    string remotePath = Utils.PathEndAddSlash(remote_pdir) + "package/" + warfile.Name;

                    monitorForm.getSftp().put(localPath, remotePath, ChannelSftp.OVERWRITE);

                    step = 4;
                }
                else
                {
                    errorLabel.Text = "war上传失败：war包不存在，可能是打包失败";
                    run = false;
                    MessageBox.Show(this, errorLabel.Text);
                }   
            }
            catch (Exception ex)
            {
                errorLabel.Text = "Upload .War 异常：" + ex.Message;
                run = false;
                MessageBox.Show(this, errorLabel.Text);
            }
        }

        public void UpdateConfig()
        {
            try
            {
                string localXml = stb_icexml.Text;
                string remote_pdir = stb_remote_pdir.Text;
                string remoteXml = Utils.PathEndAddSlash(remote_pdir) + "config/" + ice.AppName + ".xml";

                monitorForm.getSftp().put(localXml, remoteXml, ChannelSftp.OVERWRITE);

                // 更新
                monitorForm.RunShell(Utils.PathEndAddSlash(remote_pdir) + "bin/admin.sh", false, true);
                monitorForm.GetShellResult(string.Format("application update config/{0}.xml", ice.AppName), (s) => {
                    monitorForm.RunShell("quit", false);

                    step = 5;
                }, true);
            }
            catch (Exception ex)
            {
                errorLabel.Text = string.Format("application update config/{0}.xml 异常：", ice.AppName) + ex.Message;
                run = false;
                MessageBox.Show(this, errorLabel.Text);
            }
        }

        public void RestartService()
        {
            try
            {
                string remote_pdir = stb_remote_pdir.Text;
                monitorForm.RunShell(Utils.PathEndAddSlash(remote_pdir) + "bin/admin.sh", false, true);
                monitorForm.RunShell("server stop " + ice.ServerName, false, true);
                monitorForm.RunShell("server start " + ice.ServerName, false, true);
                monitorForm.RunShell("quit", false, true);

                step = 6;
            }
            catch (Exception ex)
            {
                errorLabel.Text = string.Format("Restart Service 异常：", ice.AppName) + ex.Message;
                run = false;
                MessageBox.Show(this, errorLabel.Text);
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            stb_maven_xml.Enabled = checkBox2.Checked;
            btn_choose_mvnxml.Enabled = checkBox2.Checked;
        }

        private void btn_choose_mvnxml_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(mavenHome))
            {
                openFileDialog1.InitialDirectory = mavenHome;
            }
            DialogResult dr = openFileDialog1.ShowDialog(this);
            if (dr == System.Windows.Forms.DialogResult.OK)
            {
                string[] path = openFileDialog1.FileNames;
                stb_maven_xml.Text = path[0];
            }
        }

    }
}
