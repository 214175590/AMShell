using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AppMonitor.Model
{
    public class MonitorItem
    {
    }

    public class SpringBootMonitorItem : MonitorItem
    {
        public string Uuid { get; set; }

        public int Index = 0;

        public String AppName { get; set; }

        public String HomeUrl { get; set; }

        public String ShFileDir { get; set; }

        public String BuildFileName { get; set; }

        public String CrlFileName { get; set; }

        public bool NeedAdd { get; set; }

        public String ProjectSourceDir { get; set; }

        public String ProjectSvnUrl { get; set; }

        public RunState RunStatus { get; set; }
    }

    public class IceMonitorItem : MonitorItem
    {
        public string Uuid { get; set; }

        public int Index = 3;

        public String AppName { get; set; }

        public String ServerName { get; set; }

        public String NodePorts { get; set; }

        public String IceSrvDir { get; set; }

        public RunState RunStatus { get; set; }

        public IceProjectAttr Project { get; set; }
    }

    public class IceProjectAttr
    {
        public String LocalCodePath { get; set; }

        public String LocalIceXmlPath { get; set; }

        public String MavenSetting { get; set; }
    }

    public class TomcatMonitorItem : MonitorItem
    {
        public string Uuid { get; set; }

        public int Index = 1;

        public String TomcatName { get; set; }

        public String TomcatDir { get; set; }

        public String TomcatPort { get; set; }

        public RunState RunStatus { get; set; }
    }

    public class NginxMonitorItem : MonitorItem
    {
        public string Uuid { get; set; }

        public int Index = 2;

        public String NginxName { get; set; }

        public String NginxPath { get; set; }

        public String NginxConfig { get; set; }

        public List<NginxMonitorUrl> MonitorList { get; set; }

        public RunState RunStatus { get; set; }

        public JObject Config { get; set; }
    }

    public class NginxMonitorUrl {
        public bool check { get; set; }

        public String url { get; set; }

        public String host { get; set; }

        public RunState RunStatus { get; set; }
    }

    public enum RunState
    {
        NoCheck, // 未检查
        Normal, // 正常
        AbNormal // 异常
    }

    public class ConditionItem
    {
        public int Index { get; set; }

        public MonitorItem Item { get; set; }

        public override string ToString()
        {
            string str = "";
            if(Index == 0){
                str = "[Springboot] " + ((SpringBootMonitorItem)Item).AppName;
            }
            else if (Index == 1)
            {
                str = "[Tomcat] " + ((TomcatMonitorItem)Item).TomcatName;
            }
            else if (Index == 2)
            {
                str = "[Nginx] " + ((NginxMonitorItem)Item).NginxName;
            }
            else if (Index == 3)
            {
                str = "[Ice] " + ((IceMonitorItem)Item).AppName;
            }
            return str;
        }
    }

}
