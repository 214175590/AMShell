using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AppMonitor.Nodel
{
    public class SshUser
    {
        public string UserName { get; set; }

        public string Password { get; set; }

        public string Host { get; set; }

        public int Port { get; set; }

    }
}
