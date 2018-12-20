using AppMonitor.Bex;
using AppMonitor.Model;
using CCWin.SkinControl;
using log4net;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using Tamir.SharpSsh.jsch;

namespace AppMonitor.Froms
{
    public partial class MonitorItemForm : CCWin.Skin_Metro
    {
        private static ILog logger = LogManager.GetLogger("LogFileAppender");
        int tabIndex = 0;
        string build_file = "";
        string ctl_file = "";
        string tomcat_name = "";
        SessionConfig config;
        MonitorForm parentForm = null;
        MonitorItemConfig monitorConfig = null;
        bool get_tomcat_port_run = false;
        bool get_ice_port_run = false;
        bool get_spboot_port_run = false;

        /// <summary>
        /// index tabIndex
        /// </summary>
        /// <param name="form"></param>
        /// <param name="index"></param>
        /// <param name="_config"></param>
        /// <param name="mConfig"></param>
        public MonitorItemForm(MonitorForm form, int index, SessionConfig _config, MonitorItemConfig mConfig = null)
        {
            InitializeComponent();
            SkinUtil.SetFormSkin(this);
            parentForm = form;
            tabIndex = index;
            config = _config;
            monitorConfig = mConfig;
        }

        private void MonitorItemForm_Load(object sender, EventArgs e)
        {
            if (null != monitorConfig)
            {
                if (monitorConfig.spring != null)
                {
                    stb_app_name.Text = monitorConfig.spring.AppName;
                    if (string.IsNullOrWhiteSpace(monitorConfig.spring.ShFileDir))
                    {
                        stb_sh_dir.Text = string.Format("/home/{0}/bin", config.UserName);
                    }
                    else
                    {
                        stb_sh_dir.Text = monitorConfig.spring.ShFileDir;
                    }
                    stb_build_file.Text = monitorConfig.spring.BuildFileName;
                    stb_ctl_file.Text = monitorConfig.spring.CrlFileName;                    
                    if (string.IsNullOrWhiteSpace(monitorConfig.spring.HomeUrl))
                    {
                        stb_home_url.Text = string.Format("http://{0}:[port]", config.Host);
                    }
                    else
                    {
                        stb_home_url.Text = monitorConfig.spring.HomeUrl;
                    }
                    if (string.IsNullOrWhiteSpace(monitorConfig.spring.ProjectSourceDir))
                    {
                        stb_project_source_dir.Text = string.Format("/home/{0}/sources", config.UserName);
                    }
                    else
                    {
                        stb_project_source_dir.Text = monitorConfig.spring.ProjectSourceDir;
                    }
                    stb_project_svn.Text = monitorConfig.spring.ProjectSvnUrl;
                }
                else if (monitorConfig.tomcat != null)
                {
                    stb_tomcat_name.Text = monitorConfig.tomcat.TomcatName;
                    stb_tomcat_path.Text = monitorConfig.tomcat.TomcatDir;
                    stb_tomcat_port.Text = monitorConfig.tomcat.TomcatPort;
                }
                else if (monitorConfig.nginx != null)
                {
                    stb_nginx_name.Text = monitorConfig.nginx.NginxName;
                    stb_nginx_path.Text = monitorConfig.nginx.NginxPath;
                    stb_nginx_path.Text = monitorConfig.nginx.NginxConfig;
                }
                else if (monitorConfig.ice != null)
                {
                    stb_ice_appname.Text = monitorConfig.ice.AppName;
                    stb_ice_srvpath.Text = monitorConfig.ice.IceSrvDir;
                    stb_ice_servername.Text = monitorConfig.ice.ServerName;
                    stb_ice_ports.Text = monitorConfig.ice.NodePorts;
                }

                TabPage page = tabControl1.TabPages[tabIndex];
                for (int i = tabControl1.TabCount - 1; i >= 0; i--)
                {
                    try
                    {
                        if (page != tabControl1.TabPages[i])
                        {
                            tabControl1.TabPages[i].Parent = null;
                        }
                    }
                    catch { }
                }
            }
            else
            {
                stb_home_url.Text = string.Format("http://{0}:[port]", config.Host);
                stb_sh_dir.Text = string.Format("/home/{0}/bin", config.UserName);
                stb_project_source_dir.Text = string.Format("/home/{0}/sources", config.UserName);
                tabControl1.SelectedIndex = tabIndex;
            }

            stb_app_name.SkinTxt.TextChanged += AppName_TextChanged;
            stb_build_file.SkinTxt.KeyUp += sh_file_KeyUp;
            stb_ctl_file.SkinTxt.KeyUp += sh_file_KeyUp;

            stb_tomcat_path.SkinTxt.TextChanged += Tomcat_TextChanged;
            stb_tomcat_name.SkinTxt.KeyUp += tomcat_name_KeyUp;
        }

        void sh_file_KeyUp(object sender, KeyEventArgs e)
        {
            var tb = sender as TextBox;
            if (tb.Tag.ToString() == "build")
            {
                build_file = stb_build_file.Text;
            }
            else if (tb.Tag.ToString() == "ctl")
            {
                ctl_file = stb_ctl_file.Text;
            }

        }

        void tomcat_name_KeyUp(object sender, KeyEventArgs e)
        {
            tomcat_name = stb_tomcat_name.Text;
        }

        void AppName_TextChanged(object sender, EventArgs e)
        {
            string appname = stb_app_name.Text;
            if (!string.IsNullOrWhiteSpace(appname))
            {
                if (string.IsNullOrWhiteSpace(build_file))
                {
                    stb_build_file.Text = appname + "_build.sh";
                }
                if (string.IsNullOrWhiteSpace(ctl_file))
                {
                    stb_ctl_file.Text = appname + "_ctl.sh";
                }
            }
        }

        void Tomcat_TextChanged(object sender, EventArgs e)
        {
            string path = stb_tomcat_path.Text;
            if (!string.IsNullOrWhiteSpace(path))
            {
                if (string.IsNullOrWhiteSpace(tomcat_name))
                {
                    try
                    {
                        stb_tomcat_name.Text = path.Substring(path.LastIndexOf("/") + 1);
                    }
                    catch { }
                }

                if (string.IsNullOrWhiteSpace(stb_tomcat_port.Text))
                {
                    try
                    {
                        if (get_tomcat_port_run)
                        {
                            return;
                        }
                        get_tomcat_port_run = true;
                        if (!path.EndsWith("/"))
                        {
                            path += "/";
                        }
                        string serverxml = path + "conf/server.xml";
                        string targetxml = MainForm.TEMP_DIR + string.Format("server-{0}.xml", DateTime.Now.ToString("MMddHHmmss"));
                        targetxml = targetxml.Replace("\\", "/");
                        parentForm.RunSftpShell(string.Format("get {0} {1}", serverxml, targetxml), false, false);
                        ThreadPool.QueueUserWorkItem((a) => {
                            Thread.Sleep(500);

                            List<Hashtable> list = YSTools.YSXml.readXml(targetxml, "Server");
                            if(list != null && list.Count > 0){
                                List<Hashtable> serviceList = null;
                                string port = null;
                                foreach(Hashtable one in list){
                                    if (one["NodeName"].ToString() == "Service")
                                    {
                                        serviceList = (List<Hashtable>) one["ChildList"];
                                        foreach (Hashtable two in serviceList)
                                        {
                                            if (two["NodeName"].ToString() == "Connector")
                                            {
                                                port = two["port"].ToString();

                                                break;
                                            }
                                        }
                                        if(port != null){
                                            break;
                                        }
                                    }
                                }

                                stb_tomcat_port.BeginInvoke((MethodInvoker)delegate()
                                {
                                   stb_tomcat_port.Text = port == null ? "8080" : port;
                                });
                            }
                            get_tomcat_port_run = false;

                            File.Delete(targetxml);
                        });
                    }
                    catch { }
                }
            }
        }

        void SrvPath_TextChanged(object sender, EventArgs e)
        {
            string path = stb_ice_srvpath.Text;
            if (!string.IsNullOrWhiteSpace(path))
            {
                string appname = stb_ice_appname.Text;

                if (!string.IsNullOrWhiteSpace(appname) && string.IsNullOrWhiteSpace(stb_ice_ports.Text))
                {
                    try
                    {
                        if (get_ice_port_run)
                        {
                            return;
                        }
                        get_ice_port_run = true;
                        if (!path.EndsWith("/"))
                        {
                            path += "/";
                        }
                        string serverxml = string.Format("{0}config/{1}.xml", path, appname);
                        string targetxml = MainForm.TEMP_DIR + string.Format("srv-{0}.xml", DateTime.Now.ToString("MMddHHmmss"));
                        targetxml = targetxml.Replace("\\", "/");
                        parentForm.RunSftpShell(string.Format("get {0} {1}", serverxml, targetxml), false, false);
                        ThreadPool.QueueUserWorkItem((a) =>
                        {
                            Thread.Sleep(500);

                            List<Hashtable> list = YSTools.YSXml.readXml(targetxml, "icegrid");
                            if (list != null && list.Count > 0)
                            {
                                List<Hashtable> appList = null, nodeList = null;
                                List<Hashtable> serverList = null;
                                string ports = "", nodeName = "", serverName = "";
                                foreach (Hashtable one in list)
                                {
                                    if (one["NodeName"].ToString() == "application")
                                    {
                                        appList = (List<Hashtable>)one["ChildList"];
                                        foreach (Hashtable two in appList)
                                        {
                                            if (two["NodeName"].ToString() == "node")
                                            {
                                                nodeName = two["name"].ToString();
                                                nodeList = (List<Hashtable>)two["ChildList"];
                                                foreach (Hashtable four in nodeList)
                                                {
                                                    if (four["NodeName"].ToString() == "server-instance")
                                                    {
                                                        ports += "," + four["serverport"].ToString();
                                                    }
                                                }

                                            }

                                            if (two["NodeName"].ToString() == "server-template")
                                            {
                                                serverList = (List<Hashtable>)two["ChildList"];
                                                foreach (Hashtable four in serverList)
                                                {
                                                    if (four["NodeName"].ToString() == "icebox")
                                                    {
                                                        serverName = four["id"].ToString();
                                                        serverName = serverName.Substring(0, serverName.IndexOf("$")) + "1";
                                                        break;
                                                    }
                                                }
                                            }

                                            if (ports != "")
                                            {
                                                break;
                                            }
                                        }
                                    }
                                }
                                                                
                                stb_ice_ports.BeginInvoke((MethodInvoker)delegate()
                                {
                                    stb_ice_servername.Text = serverName;
                                    stb_ice_ports.Text = ports == "" ? "8082" : ports.Substring(1);
                                });
                            }
                            get_ice_port_run = false;

                            File.Delete(targetxml);
                        });
                    }
                    catch { }
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int index = tabControl1.SelectedIndex;
            bool isnew = false;
            if (monitorConfig == null)
            {
                isnew = true;                
            }
            else
            {
                index = tabIndex;
            }
            if (index == 0)
            { // springboot
                SpringBootMonitorItem item = new SpringBootMonitorItem();                
                item.AppName = stb_app_name.Text;
                item.BuildFileName = stb_build_file.Text;
                item.CrlFileName = stb_ctl_file.Text;
                item.ShFileDir = stb_sh_dir.Text;
                if (item.ShFileDir.EndsWith("/"))
                {
                    item.ShFileDir = item.ShFileDir.Substring(0, item.ShFileDir.Length);
                }
                item.ProjectSourceDir = stb_project_source_dir.Text;
                if (item.ProjectSourceDir.EndsWith("/"))
                {
                    item.ProjectSourceDir = item.ProjectSourceDir.Substring(0, item.ProjectSourceDir.Length);
                }
                item.HomeUrl = stb_home_url.Text;
                item.RunStatus = RunState.NoCheck;
                if (string.IsNullOrWhiteSpace(item.HomeUrl))
                {
                    item.HomeUrl = "http://" + config.Host + ":8080/";
                }
                if (string.IsNullOrWhiteSpace(item.AppName) || hasNonChar(item.AppName))
                {
                    MessageBox.Show(this, "请填写应用名称，且不能包含'\",:;|");
                    return;
                }
                else if (string.IsNullOrWhiteSpace(item.ShFileDir))
                {
                    MessageBox.Show(this, "请填写应用脚本目录");
                    return;
                }
                else if (string.IsNullOrWhiteSpace(item.BuildFileName))
                {
                    MessageBox.Show(this, "请填写应用编译脚本文件名称");
                    return;
                }
                else if (string.IsNullOrWhiteSpace(item.CrlFileName))
                {
                    MessageBox.Show(this, "请填写应用控制脚本文件名称");
                    return;
                }
                else if (string.IsNullOrWhiteSpace(item.ProjectSourceDir))
                {
                    MessageBox.Show(this, "请填写应用代码存放目录");
                    return;
                }

                item.NeedAdd = cb_need_add.Checked;
                if (item.NeedAdd)
                {
                    item.ProjectSvnUrl = stb_project_svn.Text;
                    if (string.IsNullOrWhiteSpace(item.ProjectSvnUrl))
                    {
                        MessageBox.Show(this, "请填写应用SVN地址");
                        return;
                    }
                }
                if (isnew)
                {
                    item.Uuid = Guid.NewGuid().ToString("N");
                    monitorConfig = new MonitorItemConfig();
                }
                else
                {
                    item.Uuid = monitorConfig.spring.Uuid;
                }
                monitorConfig.spring = item;
            }
            else if (index == 1)
            { // tomcat
                TomcatMonitorItem item = new TomcatMonitorItem();                
                item.TomcatName = stb_tomcat_name.Text;
                item.TomcatDir = stb_tomcat_path.Text;
                item.TomcatPort = stb_tomcat_port.Text;
                item.RunStatus = RunState.NoCheck;
                if (string.IsNullOrWhiteSpace(item.TomcatName) || hasNonChar(item.TomcatName))
                {
                    MessageBox.Show(this, "请填写Tomcat名称，且不能包含'\",:;|");
                    return;
                }
                else if (string.IsNullOrWhiteSpace(item.TomcatDir))
                {
                    MessageBox.Show(this, "请填写Tomcat根目录");
                    return;
                }
                else if (string.IsNullOrWhiteSpace(item.TomcatPort))
                {
                    item.TomcatPort = "8080";
                }
                if (isnew)
                {
                    item.Uuid = Guid.NewGuid().ToString("N");
                    monitorConfig = new MonitorItemConfig();
                }
                else
                {
                    item.Uuid = monitorConfig.tomcat.Uuid;
                }
                monitorConfig.tomcat = item;
            }
            else if (index == 2)
            { // nginx
                NginxMonitorItem item = new NginxMonitorItem();                
                item.NginxName = stb_nginx_name.Text;
                item.NginxPath = stb_nginx_path.Text;
                item.NginxConfig = stb_nginx_conf.Text;
                item.RunStatus = RunState.NoCheck;
                if (string.IsNullOrWhiteSpace(item.NginxName) || hasNonChar(item.NginxName))
                {
                    MessageBox.Show(this, "请填写Nginx名称，且不能包含'\",:;|");
                    return;
                }
                else if (string.IsNullOrWhiteSpace(item.NginxPath))
                {
                    MessageBox.Show(this, "请填写Nginx执行文件完整路径");
                    return;
                }
                else if (string.IsNullOrWhiteSpace(item.NginxConfig))
                {
                    MessageBox.Show(this, "请填写Nginx配置文件完整路径");
                    return;
                }
                if (isnew)
                {
                    monitorConfig = new MonitorItemConfig();
                    item.Uuid = Guid.NewGuid().ToString("N");
                }
                else
                {
                    item.Uuid = monitorConfig.nginx.Uuid;
                }
                monitorConfig.nginx = item;
            }
            else if (index == 3)
            { // ice
                IceMonitorItem item = new IceMonitorItem();
                item.AppName = stb_ice_appname.Text;
                item.IceSrvDir = stb_ice_srvpath.Text;
                item.NodePorts = stb_ice_ports.Text;
                item.ServerName = stb_ice_servername.Text;
                item.RunStatus = RunState.NoCheck;
                if (string.IsNullOrWhiteSpace(item.AppName) || hasNonChar(item.AppName))
                {
                    MessageBox.Show(this, "请填写项目名称，且不能包含'\",:;|");
                    return;
                }
                else if (string.IsNullOrWhiteSpace(item.IceSrvDir))
                {
                    MessageBox.Show(this, "请填写项目Ice目录完整路径");
                    return;
                }
                else if (string.IsNullOrWhiteSpace(item.ServerName))
                {
                    MessageBox.Show(this, "请填写Ice服务名称");
                    return;
                }
                else if (string.IsNullOrWhiteSpace(item.NodePorts))
                {
                    MessageBox.Show(this, "请填写项目使用的端口号，多个以逗号(,)分隔");
                    return;
                }
                if (isnew)
                {
                    monitorConfig = new MonitorItemConfig();
                    item.Uuid = Guid.NewGuid().ToString("N");
                }
                else
                {
                    item.Uuid = monitorConfig.ice.Uuid;
                }
                monitorConfig.ice = item;
            }


            if (isnew)
            {
                config.MonitorConfigList.Add(monitorConfig);
            }

            AppConfig.Instance.SaveConfig(2);

            if (null != parentForm && monitorConfig.spring != null)
            {
                // TODO 执行checkout
                if (monitorConfig.spring.NeedAdd)
                {
                    string home = parentForm.getSftp().getHome();
                    string buildStr = YSTools.YSFile.readFileToString(MainForm.CONF_DIR + "__build.sh");
                    string ctlStr = YSTools.YSFile.readFileToString(MainForm.CONF_DIR + "__ctl.sh");
                    if (monitorConfig.spring.ProjectSourceDir.StartsWith(home))
                    {
                        string path = monitorConfig.spring.ProjectSourceDir.Substring(home.Length);
                        if (path.StartsWith("/"))
                        {
                            path = path.Substring(1);
                        }
                        buildStr = buildStr.Replace("_sourcePath_", "~/" + path);
                        ctlStr = ctlStr.Replace("_sourcePath_", "~/" + path);
                    }
                    else
                    {
                        buildStr = buildStr.Replace("_sourcePath_", monitorConfig.spring.ProjectSourceDir);
                        ctlStr = ctlStr.Replace("_sourcePath_", monitorConfig.spring.ProjectSourceDir);
                    }
                    buildStr = buildStr.Replace("_projectName_", monitorConfig.spring.AppName);
                    ctlStr = ctlStr.Replace("_projectName_", monitorConfig.spring.AppName);
                    ctlStr = ctlStr.Replace("_disconfigUrl_", stb_disconfig_url.Text);                    

                    string localBuild = MainForm.CONF_DIR + monitorConfig.spring.BuildFileName;
                    string localCtl = MainForm.CONF_DIR + monitorConfig.spring.CrlFileName;
                    string remoteBuild = monitorConfig.spring.ShFileDir + "/" + monitorConfig.spring.BuildFileName;
                    string remoteCtl = monitorConfig.spring.ShFileDir + "/" + monitorConfig.spring.CrlFileName;

                    YSTools.YSFile.writeFileByString(localBuild, buildStr);
                    YSTools.YSFile.writeFileByString(localCtl, ctlStr);

                    ThreadPool.QueueUserWorkItem((a) =>
                    {
                        Thread.Sleep(500);
                        parentForm.BeginInvoke((MethodInvoker)delegate()
                        {
                            parentForm.getSftp().put(localBuild, remoteBuild, ChannelSftp.OVERWRITE);
                            parentForm.getSftp().put(localCtl, remoteCtl, ChannelSftp.OVERWRITE);

                            parentForm.RunShell("cd " + monitorConfig.spring.ProjectSourceDir, true);
                            parentForm.RunShell("svn checkout " + monitorConfig.spring.ProjectSvnUrl, true);

                            File.Delete(localBuild);
                            File.Delete(localCtl);
                        });
                    });
                }                
            }

            this.Close();
        }

        private bool hasNonChar(string str)
        {
            if(str != null){
                return str.Contains(",") || str.Contains("|") || str.Contains(";")
                    || str.Contains("\"") || str.Contains("'") || str.Contains(":");
            }
            return false;
        }

        private void cb_need_add_CheckedChanged(object sender, EventArgs e)
        {
            stb_project_svn.Enabled = cb_need_add.Checked;
            stb_disconfig_url.Enabled = cb_need_add.Checked;
        }

        private void stb_sh_dir_IconClick(object sender, EventArgs e)
        {
            stb_sh_dir.Text = "/home/" + config.UserName + "/bin";
        }

        private void stb_project_source_dir_IconClick(object sender, EventArgs e)
        {
            stb_project_source_dir.Text = "/home/" + config.UserName + "/sources";
        }

        private void skinTextBox2_IconClick(object sender, EventArgs e)
        {
            string appname = stb_ice_appname.Text;
            if (!string.IsNullOrWhiteSpace(appname))
            {
                stb_ice_srvpath.Text = "/home/" + config.UserName + "/" + appname;
            }
        }

        private void stb_home_url_Enter(object sender, EventArgs e)
        {
            string sdir = stb_project_source_dir.Text;
            string appname = stb_app_name.Text;
            string url = stb_home_url.Text;
            if(!string.IsNullOrWhiteSpace(sdir) && !string.IsNullOrWhiteSpace(appname) && url.EndsWith("[port]")){
                try
                {
                    if (get_spboot_port_run)
                    {
                        return;
                    }
                    get_spboot_port_run = true;
                    if (!sdir.EndsWith("/"))
                    {
                        sdir += "/";
                    }
                    string serverxml = string.Format("{0}{1}/src/main/resources/config/application-dev.yml", sdir, appname);
                    string targetxml = MainForm.TEMP_DIR + string.Format("application-dev-{0}.yml", DateTime.Now.ToString("MMddHHmmss"));
                    targetxml = targetxml.Replace("\\", "/");
                    parentForm.RunSftpShell(string.Format("get {0} {1}", serverxml, targetxml), false, false);
                    ThreadPool.QueueUserWorkItem((a) =>
                    {
                        Thread.Sleep(500);
                        string port = "", ctx = "";
                        string yml = YSTools.YSFile.readFileToString(targetxml);
                        if(!string.IsNullOrWhiteSpace(yml)){
                            string[] lines = yml.Split('\n');
                            bool find = false;                            
                            int index = 0, start = 0;
                            foreach(string line in lines){
                                if (line.Trim().StartsWith("server:"))
                                {
                                    find = true;
                                    start = index;
                                }
                                else if(find && line.Trim().StartsWith("port:")){
                                    port = line.Substring(line.IndexOf(":") + 1).Trim();
                                }
                                else if (find && line.Trim().StartsWith("context-path:"))
                                {
                                    ctx = line.Substring(line.IndexOf(":") + 1).Trim();
                                }
                                if (index - start > 4 && start > 0)
                                {
                                    break;
                                }
                                index++;
                            }
                        }

                        if (port != "")
                        {
                            stb_home_url.BeginInvoke((MethodInvoker)delegate()
                            {
                                stb_home_url.Text = string.Format("http://{0}:{1}{2}", config.Host, port, ctx);
                            });
                        }
                        
                        get_spboot_port_run = false;

                        File.Delete(targetxml);
                    });
                }
                catch(Exception ex) {
                    logger.Error("Error", ex);
                }

            }
        }

        private void stb_ice_servername_Enter(object sender, EventArgs e)
        {
            SrvPath_TextChanged(null, null);
        }
    }
}
