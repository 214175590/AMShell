using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tamir.SharpSsh.jsch;

namespace AppMonitor.Plugin
{

    public delegate void ProgressDelegate(string id, long percent, long cm, long max, int elapsed);

    public delegate void TransfersEndDelegate(string id);

    public class MyProgressMonitor : SftpProgressMonitor
    {
        private long c = 0;
        private long max = 0;
        private long percent = -1;
        int elapsed = -1;

        System.Timers.Timer timer;

        private ProgressDelegate progress;
        private TransfersEndDelegate transferEnd;
        private string id;

        public MyProgressMonitor(string id, ProgressDelegate progress, TransfersEndDelegate end)
        {
            this.id = id;
            this.progress = progress;
            this.transferEnd = end;
        }

        public override void init(int op, String src, String dest, long max)
        {
            this.max = max;
            elapsed = 0;
            timer = new System.Timers.Timer(1000);
            timer.Start();
            timer.Elapsed += new System.Timers.ElapsedEventHandler(timer_Elapsed);
        }

        public override bool count(long c)
        {
            this.c += c;
            if (percent >= this.c * 100 / max) { return true; }
            percent = this.c * 100 / max;

            //string note = ("Transfering... [Elapsed time: " + elapsed + "]");

            progress(id, percent, this.c, max, elapsed);
            return true;
        }

        public override void end()
        {
            timer.Stop();
            timer.Dispose();
            //string note = ("Done in " + elapsed + " seconds!");

            transferEnd(id);
        }

        private void timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            this.elapsed++;
        }

    }
}
