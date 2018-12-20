using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AppMonitor.Bex
{
    public class Utils
    {

        public static MonitorItemConfig getMonitorItemConfig(List<MonitorItemConfig> monitorConfigList, string uuid)
        {
            MonitorItemConfig itemConfig = null;
            foreach (var item in monitorConfigList)
            {
                if (null != item.spring && item.spring.Uuid == uuid)
                {
                    itemConfig = item;
                    break;
                }
                else if (null != item.tomcat && item.tomcat.Uuid == uuid)
                {
                    itemConfig = item;
                    break;
                }
                else if (null != item.nginx && item.nginx.Uuid == uuid)
                {
                    itemConfig = item;
                    break;
                }
                else if (null != item.ice && item.ice.Uuid == uuid)
                {
                    itemConfig = item;
                    break;
                }
            }
            return itemConfig;
        }

        public static int getMonitorItemIndex(MonitorItemConfig itemConfig)
        {
            int index = -1;
            if (itemConfig.nginx != null)
            {
                index = itemConfig.nginx.Index;
            }
            else if (itemConfig.spring != null)
            {
                index = itemConfig.spring.Index;
            }
            else if (itemConfig.tomcat != null)
            {
                index = itemConfig.tomcat.Index;
            }
            else if (itemConfig.ice != null)
            {
                index = itemConfig.ice.Index;
            }
            return index;
        }

        public static string getFileSize(long size)
        {
            if (size < 1024)
            {
                return size + "Bytes";
            }
            else if (size < 1024 * 1024)
            {
                return (size / 1024) + "KB";
            }
            else if (size < 1024 * 1024 * 1024)
            {
                return (size / (1024 * 1024)) + "MB";
            }
            else if ((size / 1024) < 1024 * 1024 * 1024)
            {
                return (size / (1024 * 1024 * 1024)) + "GB";
            }
            else if ((size / (1024 * 1024)) < 1024 * 1024 * 1024)
            {
                return ((size / (1024 * 1024) / 1024)) + "TB";
            }
            else
            {
                return "";
            }
        }

        public static string CalculaSpeed(long startByte, long endByte, long max, int start, int end)
        {
            float time = (end - start)/1000.0f;
            return getFileSize((long)((endByte - startByte) / time)) + "/S";
        }

        public static string CalculaTimeLeft(long startByte, long endByte, long max, int start, int end)
        {
            int time = (end - start);
            long millis = ((time * (max - endByte)) / (endByte - startByte)) / 1000;
            long s = millis % 60;
            long m = millis / 60;
            long h = m / 60;
            m = m % 60;
            string timeLeft = (h < 10 ? "0" : "") + h + ":" + (m < 10 ? "0" : "") + m + ":" + (s < 10 ? "0" : "") + s;
            return timeLeft;
        }

        public static string getLinuxName(string name)
        {
            if(name.Contains(" ")){
                return "\"" + name + "\"";
            }
            return name;
        }

        public static bool isLinuxRootPath(string pathname)
        {
            return (pathname == "." || pathname == "..");
        }

        public static string getLinuxPathDir(string remotePath)
        {
            string dir = "/";
            int index = remotePath.LastIndexOf("/");
            if (index > 0)
            {
                dir = remotePath.Substring(0, index);
            }
            return dir;
        }

        /// <summary>
        /// 判断目标是文件夹还是目录(目录包括磁盘)
        /// </summary>
        /// <param name="filepath">文件名</param>
        /// <returns></returns>
        public static bool IsDir(string filepath)
        {
            FileInfo fi = new FileInfo(filepath);
            if ((fi.Attributes & FileAttributes.Directory) != 0)
                return true;
            else
            {
                return false;
            }
        }

        public static void CopyDir(string fromDir, string toDir)
        {
            if (!Directory.Exists(fromDir))
                return;

            if (!Directory.Exists(toDir))
            {
                Directory.CreateDirectory(toDir);
            }

            string[] files = Directory.GetFiles(fromDir);
            foreach (string formFileName in files)
            {
                string fileName = Path.GetFileName(formFileName);
                string toFileName = Path.Combine(toDir, fileName);
                File.Copy(formFileName, toFileName);
            }
            string[] fromDirs = Directory.GetDirectories(fromDir);
            foreach (string fromDirName in fromDirs)
            {
                string dirName = Path.GetFileName(fromDirName);
                string toDirName = Path.Combine(toDir, dirName);
                CopyDir(fromDirName, toDirName);
            }
        }

        public static void createParentDir(DirectoryInfo dire)
        {
            if(!dire.Exists){
                if(dire.Parent.Exists){
                    dire.Create();
                }
                else
                {
                    createParentDir(dire.Parent);
                }
            }
        }

        public static string PathEndAddSlash(string path)
        {
            if(!path.EndsWith("/")){
                path += "/";
            }
            return path;
        }

        public static string PathWinToLinux(string path)
        {
            return path.Replace("\\", "/");
        }

    }
}
