using AppMonitor.Bex;
using FastColoredTextBoxNS;
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
    public partial class TextEditorForm : CCWin.Skin_Metro
    {
        private bool showLine = true, ischange = false;
        private string mode = "local";
        private string remote_file = null;
        private string local_file = null;
        private ShellForm shellForm = null;
        private string org_content = "";

        public TextEditorForm()
        {
            InitializeComponent();
            SkinUtil.SetFormSkin(this);
        }

        private void TextEditorForm_Load(object sender, EventArgs e)
        {
            editor.Text = "";

        }

        public void LoadLocalFile(string filepath)
        {
            mode = "local";
            remote_file = null;
            local_file = filepath;

            org_content = YSTools.YSFile.readFileToString(local_file);
            editor.Text = org_content;
        }

        public void LoadRemoteFile(ShellForm _shellForm, string remoteFile, string localFile)
        {
            try
            {
                mode = "remote";
                shellForm = _shellForm;
                remote_file = remoteFile;
                local_file = localFile;

                shellForm.RunSftpShell("get", remoteFile, localFile, false, false);

                org_content = YSTools.YSFile.readFileToString(localFile);
                editor.Text = org_content;

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        #region ±à¼­¿òÓÒ¼ü²Ëµ¥ÊÂ¼þ

        private void editor_KeyDown(object sender, KeyEventArgs e)
        {
            e.SuppressKeyPress = false;
            if (e.KeyCode == Keys.X && e.Control)
            {
                cutToolStripMenuItem_Click(null, null);
                e.SuppressKeyPress = true;
            }
            else if (e.KeyCode == Keys.C && e.Control)
            {
                copyToolStripMenuItem_Click(null, null);
                e.SuppressKeyPress = true;
            }
            else if (e.KeyCode == Keys.F && e.Control)
            {
                findToolStripMenuItem_Click(null, null);
                e.SuppressKeyPress = true;
            }
            else if (e.KeyCode == Keys.H && e.Control)
            {
                replaceToolStripMenuItem_Click(null, null);
                e.SuppressKeyPress = true;
            }
            else if (e.KeyCode == Keys.S && e.Control)
            {
                // save
                e.SuppressKeyPress = true;
            }
        }

        private void cutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string text = editor.SelectedText;
            if (text.Length > 0)
            {
                Clipboard.SetDataObject(text);
                try
                {
                    string all = editor.Text;
                    editor.Text = all.Replace(text, "");
                }
                catch { }
            }
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string text = editor.SelectedText;
            if (text.Length > 0)
            {
                Clipboard.SetDataObject(text);
            }
        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            editor.Paste();
        }

        private void selectAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            editor.SelectAll();
        }

        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (editor.CanUndo)
                editor.Undo();
        }

        private void redoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (editor.CanRedo)
                editor.Redo();
        }

        private void findToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //editor.ShowFindDialog();
            TextFindForm form = new TextFindForm(new TextFindForm.GetContentMethod(GetContent), new TextFindForm.FindCallback(FindChars), false);
            form.TopMost = true;
            form.Show(this);
        }

        private void replaceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //editor.ShowReplaceDialog();
            TextFindForm form = new TextFindForm(new TextFindForm.GetContentMethod(GetContent), new TextFindForm.FindCallback(FindChars), new TextFindForm.ReplaceCallback(ReplaceStr));
            form.TopMost = true;
            form.Show(this);
        }

        public string GetContent()
        {
            return editor.Text;
        }

        public void FindChars(string str, int index)
        {
            string cont = GetContent();
            int start = cont.IndexOf(str, index);
            if (start != index && start != -1)
            {
                index = start;
            }

            editor.SelectionStart = index;
            editor.ScrollToCaret();

            editor.Select(index, str.Length);
            editor.Focus();
        }

        public void ReplaceStr(string str, string res = null, bool isAll = false)
        {
            if (res != null && isAll)
            {
                string cont = GetContent();
                cont = cont.Replace(res, str);
                editor.Text = cont;

                editor.SelectionStart = cont.Length;
                editor.ScrollToCaret();
            }
            else
            {
                editor.SelectedText = str;
                editor.ScrollToCaret();
            }
        }

        #endregion

        private void TextEditorForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                if (ischange)
                {
                    string content = editor.Text;
                    if (!content.Equals(org_content))
                    {
                        YSTools.YSFile.writeFileByString(local_file, content);

                        if (mode == "remote")
                        {
                            shellForm.RunSftpShell("put", local_file, remote_file, false, false);
                        }
                    }
                }
            }
            catch { }
            File.Delete(local_file);
        }

        private void editor_KeyUp(object sender, KeyEventArgs e)
        {

        }

        private void editor_TextChanged(object sender, EventArgs e)
        {
            

        }

    }
}