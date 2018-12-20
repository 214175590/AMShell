using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace AppMonitor.Plugin
{
    public class YmlItem
    {
        public string Uuid { get; set; }
        public int ImageIndex {get; set; }
        public string Key {get; set; }
        public string Value {get; set; }
        public int Level {get; set; }

        public int SpcCount { get; set; }
        public string Common {get; set; }
        public YmlItem Parent {get; set; }
    }
}
