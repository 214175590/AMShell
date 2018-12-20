using AppMonitor.Froms;
using AppMonitor.Plugin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AppMonitor.Bex
{
    public class ShellForm
    {
        MonitorForm monitorForm = null;
        SftpLinuxForm sftpForm = null;
        public ShellForm(MonitorForm monitorForm)
        {
            this.monitorForm = monitorForm;
        }

        public ShellForm(SftpLinuxForm sftpForm)
        {
            this.sftpForm = sftpForm;
        }

        public Object RunSftpShell(string cmd, string src, string dst, bool isview = true, bool log = true)
        {
            if(null != monitorForm){
                return monitorForm.RunSftpShell(string.Format("{0} {1} {2}", cmd, src, dst), isview, log);
            }
            else if (null != sftpForm)
            {
                return sftpForm.downloadFile(src, dst);
            }
            return null;
        }

    }
}
