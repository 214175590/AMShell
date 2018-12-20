using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AppMonitor.Model
{
    public class TransferItem
    {
        public string Id { get; set; }
        public string Name { get; set; }

        public TransferStatus Status { get; set; }

        public long Progress { get; set; }

        public string Size { get; set; }

        public string LocalPath { get; set; }

        public string RemotePath { get; set; }

        public string Speed { get; set; }

        public string TimeLeft { get; set; }

    }

    public enum TransferStatus
    {
        Wait, Transfers, Success, Failed, Cancel
    }
}
