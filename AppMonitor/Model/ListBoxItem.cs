using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AppMonitor.Model
{
    public class ListBoxItem
    {
        public string Text { get; set; }

        public string Value { get; set; }

        public Object Tag { get; set; }

        public override string ToString()
        {
            return Text;
        }

    }
}
