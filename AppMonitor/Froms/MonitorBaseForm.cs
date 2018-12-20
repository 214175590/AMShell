using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AppMonitor.Froms
{
    public partial class MonitorBaseForm : Form
    {
        public MonitorBaseForm()
        {
            InitializeComponent();
        }

        private void MonitorBaseForm_Load(object sender, EventArgs e)
        {

        }

        public virtual void CloseForm()
        {
            this.Close();
        }

        public virtual void ReflushMonitorItem()
        {
        }
        
    }
}
