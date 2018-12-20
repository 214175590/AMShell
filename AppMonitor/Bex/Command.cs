using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AppMonitor.Bex
{
    public class Command
    {
        public static CmdResult run(String cmd)
        {
            CmdResult result = new CmdResult();
            System.Diagnostics.Process p = new System.Diagnostics.Process();
            p.StartInfo.FileName = "cmd.exe";
            p.StartInfo.UseShellExecute = false;    //是否使用操作系统shell启动
            p.StartInfo.RedirectStandardInput = true;//接受来自调用程序的输入信息
            p.StartInfo.RedirectStandardOutput = true;//由调用程序获取输出信息
            p.StartInfo.RedirectStandardError = true;//重定向标准错误输出
            p.StartInfo.CreateNoWindow = true;//不显示程序窗口
            p.Start();//启动程序

            //向cmd窗口发送输入信息
            p.StandardInput.WriteLine(cmd + "&exit");

            p.StandardInput.AutoFlush = true;
            //p.StandardInput.WriteLine("exit");
            //向标准输入写入要执行的命令。这里使用&是批处理命令的符号，表示前面一个命令不管是否执行成功都执行后面(exit)命令，如果不执行exit命令，后面调用ReadToEnd()方法会假死
            //同类的符号还有&&和||前者表示必须前一个命令执行成功才会执行后面的命令，后者表示必须前一个命令执行失败才会执行后面的命令

            //获取cmd窗口的输出信息
            result.result = p.StandardOutput.ReadToEnd();
            result.error = p.StandardError.ReadToEnd();

            p.WaitForExit();//等待程序执行完退出进程
            p.Close();

            return result;
        }

    }

    public class CmdResult {
        public String result {get; set;}

        public String error {get; set;}

        public bool isSuccess()
        {
            return result != null && result.Length > 1;
        }

        public bool isFailed()
        {
            return (error != null && error.Length > 1) && (result == null || result.Length < 1);
        }
    }
}
