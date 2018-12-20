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
    public partial class FullScreenMonitorForm : Form
    {
        MonitorForm form = null;
        public FullScreenMonitorForm(MonitorForm _form)
        {
            form = _form;
            InitializeComponent();
        }

        private void FullScreenMonitorForm_KeyUp(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Escape){
                Exit();
            }
        }

        private void FullScreenMonitorForm_Load(object sender, EventArgs e)
        {
            int SH = Screen.PrimaryScreen.Bounds.Height;
            int SW = Screen.PrimaryScreen.Bounds.Width;

            this.Size = new Size(SW, SH);
            this.Location = new Point(0, 0);

            this.Controls.Add(form);
        }

        public void Exit(){
            this.Controls.Remove(form);
            this.Close();
            form.ExitFullScreen();
        }
    }
}
