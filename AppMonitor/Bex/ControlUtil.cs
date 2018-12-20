using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace AppMonitor.Bex
{
    public class ControlUtil
    {

        public static void delayHide(Control control, int millis)
        {
            ThreadPool.QueueUserWorkItem((a) =>
            {
                control.BeginInvoke((MethodInvoker)delegate()
                {
                    Thread.Sleep(millis);

                    control.Visible = false;
                });
            });            
        }

        public static void delayClearText(DelayDelegate dele, int millis)
        {
            ThreadPool.QueueUserWorkItem((a) =>
            {
                Thread.Sleep(millis);
                dele();
            });
        }

    }

    public delegate void DelayDelegate();
}
