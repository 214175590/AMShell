using AppMonitor.Bex;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AppMonitor.Froms
{
    public partial class ShellHelpForm : CCWin.Skin_Metro
    {
        public ShellHelpForm()
        {
            InitializeComponent();
            SkinUtil.SetFormSkin(this);
        }

        private void ShellHelpForm_Load(object sender, EventArgs e)
        {
            
            tree.ExpandAll();
        }

        private void tree_AfterSelect(object sender, TreeViewEventArgs e)
        {
            string name = tree.SelectedNode.Name;
            string path = MainForm.APP_DIR + "\\help\\" + name + ".html";
            if (File.Exists(path))
            {
                web.Navigate(path);
            }            
        }
    }
}
