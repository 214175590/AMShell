using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AppMonitor.Bex
{
    public class DefaultConfig
    {
        public static string SHELL_1 = "ps -ef | grep tomcat&";
        public static string SHELL_2 = "ps -ef | grep java&";
        public static string SHELL_3 = "tailf ../logs/[name].{date}.log";
        public static string SHELL_4 = "scp [user]@[host]:[filepath] [filepath]";
        public static string SHELL_5 = "rm -rf [file/dir]";


        public static void InitDefaultShellList(List<string> shellList)
        {
            if (!shellList.Contains(SHELL_1))
            {
                shellList.Add(SHELL_1);
            }
            if (!shellList.Contains(SHELL_2))
            {
                shellList.Add(SHELL_2);
            }
            if (!shellList.Contains(SHELL_3))
            {
                shellList.Add(SHELL_3);
            }
            if (!shellList.Contains(SHELL_4))
            {
                shellList.Add(SHELL_4);
            }
            if (!shellList.Contains(SHELL_5))
            {
                shellList.Add(SHELL_5);
            }

            AppConfig.Instance.SaveConfig(2);
        }

        public static void UpdateShellListItem(List<string> shellList, int index, string cmd)
        {
            if (index < shellList.Count)
            {
                shellList[index] = cmd;
            }
            else if (!shellList.Contains(cmd))
            {
                shellList.Add(cmd);
            }

            AppConfig.Instance.SaveConfig(2);
        }

        public static void RemoveShellListItem(List<string> shellList, int index)
        {
            if (index < shellList.Count)
            {
                shellList.RemoveAt(index);
            }
            AppConfig.Instance.SaveConfig(2);
        }


    }
}
