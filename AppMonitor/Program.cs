using AppMonitor.Bex;
using AppMonitor.Froms;
using AppMonitor.Nodel;
using AppMonitor.Plugin;
using log4net;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using Tamir.SharpSsh.java.lang;

[assembly: log4net.Config.XmlConfigurator(Watch = true)]
namespace AppMonitor
{
    public static class Program
    {
        static ILog logger = LogManager.GetLogger("LogFileAppender");
        public static MainForm MAIN = null;
        public static SshUser initUser = null;

        /*
        [DllImport("Kernel32.dll")]
        private static extern bool AllocConsole();
        [DllImport("kernel32.dll", EntryPoint = "FreeConsole")]
        private static extern bool FreeConsole();
        [DllImport("user32.dll", EntryPoint = "FindWindow")]
        extern static IntPtr FindWindow(string lpClassName, string lpWindowName);
        [DllImport("user32.dll", EntryPoint = "GetSystemMenu")]
        extern static IntPtr GetSystemMenu(IntPtr hWnd, IntPtr bRevert);
        [DllImport("user32.dll", EntryPoint = "RemoveMenu")]
        extern static IntPtr RemoveMenu(IntPtr hMenu, uint uPosition, uint uFlags);
        [DllImport("Kernel32.dll")]
        public static extern bool SetConsoleTitle(string strMessage);

        public static IntPtr windowHandle;
        */
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            if (null != args && args.Length > 3)
            {
                initUser = new SshUser();
                initUser.Host = args[0];
                initUser.UserName = args[1];
                initUser.Password = args[2];
                initUser.Port = Convert.ToInt32(args[3]);
            }
            /*AllocConsole();
            windowHandle = FindWindow(null, Process.GetCurrentProcess().MainModule.FileName);

            IntPtr closeMenu = GetSystemMenu(windowHandle, IntPtr.Zero);
            uint SC_CLOSE = 0xF060;
            RemoveMenu(closeMenu, SC_CLOSE, 0x0);
            SetConsoleTitle("调试信息");*/

            try
            {
                //处理未捕获的异常   
                Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);
                //处理UI线程异常   
                Application.ThreadException += new System.Threading.ThreadExceptionEventHandler(Application_ThreadException);
                //处理非UI线程异常   
                AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(CurrentDomain_UnhandledException);


                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);

                MAIN = new MainForm();
                Application.Run(MAIN);

                //Application.Run(new SftpForm(initUser));
            }
            catch (Exception ex)
            {
                string str = GetExceptionMsg(ex, string.Empty);
                MessageBox.Show(str, "系统错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
            //FreeConsole();
        }

        static void Application_ThreadException(object sender, System.Threading.ThreadExceptionEventArgs e)
        {
            string str = GetExceptionMsg(e.Exception, e.ToString());
            MessageBox.Show(str, "系统错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            logger.Error(str);
        }

        static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            string str = GetExceptionMsg(e.ExceptionObject as Exception, e.ToString());
            MessageBox.Show(str, "系统错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            logger.Error(str);
        }

        /// <summary>  
        /// 生成自定义异常消息  
        /// </summary>  
        /// <param name="ex">异常对象</param>  
        /// <param name="backStr">备用异常消息：当ex为null时有效</param>  
        /// <returns>异常字符串文本</returns>  
        static string GetExceptionMsg(Exception ex, string backStr)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("****************************异常文本****************************");
            sb.AppendLine("【出现时间】：" + DateTime.Now.ToString());
            if (ex != null)
            {
                sb.AppendLine("【异常类型】：" + ex.GetType().Name);
                sb.AppendLine("【异常信息】：" + ex.Message);
                sb.AppendLine("【堆栈调用】：" + ex.StackTrace);
            }
            else
            {
                sb.AppendLine("【未处理异常】：" + backStr);
            }
            sb.AppendLine("***************************************************************");
            return sb.ToString();
        } 
    }
}
