using AppMonitor.Model;
using log4net;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;

namespace AppMonitor.Bex
{
    public class AppConfig
    {
        private static ILog logger = LogManager.GetLogger("LogFileAppender");
        private static AppConfig appConfig = null;
        private static readonly string CONFIG_KEY = "Ud_&d2$7#{f92}2Kl>dDh<n23;d";
        private static readonly string MC_NAME = "conf.json";

        public static AppConfig Instance
        {
            get
            {
                if (null == appConfig)
                {
                    appConfig = new AppConfig();
                    appConfig.LoadConfig();
                }
                return appConfig;
            }
        }

        private MainConfig _main_config = new MainConfig();
        public MainConfig MConfig
        {
            get { return _main_config; }
            set { _main_config = value; }
        }

        private Dictionary<string, SessionConfig> _session_config_dic = new Dictionary<string, SessionConfig>();
        public Dictionary<string, SessionConfig> SessionConfigDict
        {
            get { return _session_config_dic; }
            set { _session_config_dic = value; }
        }

        public void LoadConfig()
        {
            // 初始化主配置            
            try
            {
                MainConfig config = null;
                if (File.Exists(MainForm.CONF_DIR + MC_NAME))
                {
                    string mconfig = YSTools.YSFile.readFileToString(MainForm.CONF_DIR + MC_NAME, false, CONFIG_KEY);
                    if (!string.IsNullOrWhiteSpace(mconfig))
                    {
                        config = JsonConvert.DeserializeObject<MainConfig>(mconfig);
                        if(null != config){
                            MConfig = config;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                logger.Error("加载Main配置文件异常：" + ex.Message);
                logger.Error("--->" + MC_NAME);
            }

            // 初始化session配置
            SessionConfigDict = new Dictionary<string, SessionConfig>();

            DirectoryInfo direct = new DirectoryInfo(MainForm.SESSION_DIR);
            if (direct.Exists)
            {
                FileInfo[] files = direct.GetFiles();
                string content = null;
                SessionConfig sessionConfig = null;
                foreach(FileInfo file in files){
                    try
                    {
                        if (file.Name.EndsWith(".json"))
                        {
                            content = YSTools.YSFile.readFileToString(file.FullName, false, CONFIG_KEY);
                            if (!string.IsNullOrWhiteSpace(content))
                            {
                                sessionConfig = JsonConvert.DeserializeObject<SessionConfig>(content);
                                if (null != sessionConfig)
                                {
                                    SessionConfigDict.Add(sessionConfig.SessionId, sessionConfig);
                                }
                            }                            
                        }
                    }catch(Exception ex){
                        logger.Error("加载Session配置文件异常：" + ex.Message);
                        logger.Error("--->" + file.Name);
                    }                    
                }
            }

        }

        /// <summary>
        /// 保存配置
        /// 0 保存全部
        /// 1 保存 MainConfig
        /// 2 保存 SessionConfig
        /// </summary>
        /// <param name="type"></param>
        public void SaveConfig(int type = 0)
        {
            if(type == 0 || type == 1){
                try
                {
                    string mconfig = JsonConvert.SerializeObject(MConfig, Formatting.Indented);
                    if (!string.IsNullOrWhiteSpace(mconfig))
                    {
                        YSTools.YSFile.writeFileByString(MainForm.CONF_DIR + MC_NAME, mconfig, false, CONFIG_KEY);
                    }
                }
                catch (Exception ex)
                {
                    logger.Error("保存Main配置文件异常：" + ex.Message);
                    logger.Error("--->" + MC_NAME);
                }
            }

            if (type == 0 || type == 2)
            {
                string sconfig = null, scname = null;
                int index = 0;
                List<string> newFiles = new List<string>();
                foreach (KeyValuePair<string, SessionConfig> item in SessionConfigDict)
                {
                    try
                    {
                        sconfig = JsonConvert.SerializeObject(item.Value, Formatting.Indented);
                        if (!string.IsNullOrWhiteSpace(sconfig))
                        {
                            scname = string.Format("session{0}.json", index);
                            YSTools.YSFile.writeFileByString(MainForm.SESSION_DIR + scname, sconfig, false, CONFIG_KEY);
                            newFiles.Add(scname);
                            index++;
                        }
                    }
                    catch (Exception ex)
                    {
                        logger.Error("保存Session配置文件异常：" + ex.Message);
                        logger.Error("--->" + item.Key);
                    }
                }

                DirectoryInfo dirs = new DirectoryInfo(MainForm.SESSION_DIR);
                FileInfo[] files = dirs.GetFiles();
                foreach(FileInfo file in files){
                    if (!newFiles.Contains(file.Name))
                    {
                        file.Delete();
                    }
                }
            }
            
        }
    }

    public class MainConfig
    {
        private Dictionary<string, SchemeColor> _scheme_config_dic = new Dictionary<string, SchemeColor>();
        public Dictionary<string, SchemeColor> SchemeConfigDict
        {
            get { return _scheme_config_dic; }
            set { _scheme_config_dic = value; }
        }

        private string _guid = Guid.NewGuid().ToString("N");
        public string UserId
        {
            get {return _guid;}
            set { _guid = value; }
        }

        private int _skin_index = 0;
        public int SkinIndex
        {
            get { return _skin_index; }
            set { _skin_index = value; }
        }

        private bool _onstart_show_sess_mgt = false;
        public bool OnstartShowSessMgt
        {
            get { return _onstart_show_sess_mgt; }
            set { _onstart_show_sess_mgt = value; }
        }

        private int _monitor_timer = 30;
        public int MonitorTimer
        {
            get { return _monitor_timer; }
            set { _monitor_timer = value; }
        }

        private bool _show_menubar = true;
        public bool ShowMenuBar
        {
            get { return _show_menubar; }
            set { _show_menubar = value; }
        }

        private bool _show_statusbar = true;
        public bool ShowStatusBar
        {
            get { return _show_statusbar; }
            set { _show_statusbar = value; }
        }
    }

    public class SessionConfig 
    {
        private int _index = 1;
        public int Index
        {
            get { return _index; }
            set { _index = value; }
        }

        private string _session_id = "";
        public string SessionId
        {
            get { return _session_id; }
            set { _session_id = value; }
        }

        private string _name = "New Session";
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        private string _host = "";
        public string Host
        {
            get { return _host; }
            set { _host = value; }
        }

        private int _port = 22;
        public int Port
        {
            get { return _port; }
            set { _port = value; }
        }

        private string _protocol = "SSH";
        public string Protocol
        {
            get { return _protocol; }
            set { _protocol = value; }
        }

        private string _method = "Password";
        public string Method
        {
            get { return _method; }
            set { _method = value; }
        }

        private string _userName = "";
        public string UserName
        {
            get { return _userName; }
            set { _userName = value; }
        }

        private string _password = "";
        public string Password
        {
            get { return _password; }
            set { _password = value; }
        }

        private bool _remenber_pwd = true;
        public bool RemenberPwd
        {
            get { return _remenber_pwd; }
            set { _remenber_pwd = value; }
        }

        private string _central_server_config = "";
        public string CentralServerConfigDir
        {
            get { return _central_server_config; }
            set { _central_server_config = value; }
        }

        private ColorTheme _theme = new ColorTheme();
        public ColorTheme Theme
        {
            get { return _theme; }
            set { _theme = value; }
        }

        private List<MonitorItemConfig> _monitorConfigList = new List<MonitorItemConfig>();
        public List<MonitorItemConfig> MonitorConfigList
        {
            get { return _monitorConfigList; }
            set { _monitorConfigList = value; }
        }

        private List<CmdShell> _customShellList = new List<CmdShell>();
        public List<CmdShell> CustomShellList
        {
            get { return _customShellList; }
            set { _customShellList = value; }
        }

        private List<string> _shellList = new List<string>();
        public List<string> ShellList
        {
            get {
                return _shellList; 
            }
            set { _shellList = value; }
        }

        public SessionConfig Clone()
        {
            SessionConfig conf = new SessionConfig();
            conf.Index = AppConfig.Instance.SessionConfigDict.Count + 1;
            conf.SessionId = "S" + YSTools.YSDateTime.ConvertDateTimeToLong();
            conf.Name = this.Name;
            conf.Password = this.Password;
            conf.UserName = this.UserName;
            conf.Host = this.Host;
            conf.Port = this.Port;
            conf.Method = this.Method;
            conf.Protocol = this.Protocol;
            conf.RemenberPwd = this.RemenberPwd;            
            conf.ShellList = new List<string>();
            conf.Theme = this.Theme.Clone();
            conf.MonitorConfigList = new List<MonitorItemConfig>();
            
            return conf;
        }
    }

    public class ColorTheme
    {
        private string _color_scheme = "Default Scheme";
        public string ColorScheme
        {
            get { return _color_scheme; }
            set { _color_scheme = value; }
        }

        private string _font_name = "Courier New";
        public string FontName
        {
            get { return _font_name; }
            set { _font_name = value; }
        }

        private int _fontSize = 11;
        public int FontSize
        {
            get { return _fontSize; }
            set { _fontSize = value; }
        }

        public ColorTheme Clone()
        {
            ColorTheme ct = new ColorTheme();
            ct.FontName = this.FontName;
            ct.FontSize = this.FontSize;
            ct.ColorScheme = this.ColorScheme;
            return ct;
        }
    }

    public class SchemeColor
    {
        private string _scheme_name = "Default Scheme";
        public string CchemeName
        {
            get { return _scheme_name; }
            set { _scheme_name = value; }
        }

        private Color _backgroup_color = Color.Black;
        public Color BackgroundColor
        {
            get { return _backgroup_color; }
            set { _backgroup_color = value; }
        }

        private Color _normal_text_color = Color.CadetBlue;
        public Color NormalTextColor
        {
            get { return _normal_text_color; }
            set { _normal_text_color = value; }
        }

        private Color _t0134_color = Color.RoyalBlue;
        public Color T0134Color
        {
            get { return _t0134_color; }
            set { _t0134_color = value; }
        }

        private Color _t0136_color = Color.PowderBlue;
        public Color T0136Color
        {
            get { return _t0136_color; }
            set { _t0136_color = value; }
        }

        private Color _t3042_color = Color.CadetBlue;
        public Color T3042Color
        {
            get { return _t3042_color; }
            set { _t3042_color = value; }
        }

        private Color _font_back_color = Color.Green;
        public Color FontBackColor
        {
            get { return _font_back_color; }
            set { _font_back_color = value; }
        }

    }

    public class MonitorItemConfig
    {
        public SpringBootMonitorItem spring { get; set; }

        public TomcatMonitorItem tomcat { get; set; }

        public NginxMonitorItem nginx { get; set; }

        public IceMonitorItem ice { get; set; }
    }

}
