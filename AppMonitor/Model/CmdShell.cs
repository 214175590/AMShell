using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AppMonitor.Model
{
    public class CmdShell
    {
        public string Target { get; set; }

        public string Uuid { get; set; }

        public string Name { get; set; }

        public TaskType TaskType { get; set; }

        public string Type { get; set; }

        public string Condition { get; set; }

        public List<TaskShell> ShellList { get; set; }

    }

    public class TaskShell
    {
        public string Uuid { get; set; }

        public string DateTime { get; set; }        

        public string Name { get; set; }

        public string Shell { get; set; }
    }

    public enum TaskType
    {
        Default, Timed, Condition
    }

    public delegate void ShellResultDelegate(string result);

}
