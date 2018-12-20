using AppMonitor.Bex;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace AppMonitor.Froms
{
    public partial class TextFindForm : CCWin.Skin_Metro
    {
        public delegate string GetContentMethod();
        public delegate void FindCallback(string str, int index);
        public delegate void ReplaceCallback(string str, string res, bool isAll);
        private bool openReplace = false;
        private GetContentMethod getContent;
        private FindCallback findCall;
        private ReplaceCallback replaceCall;
        private string tempCont = null, tempStr = null;
        private Regex reg1 = null, reg2 = null;
        private Match match1 = null, match2 = null;
        private List<string> findHisList = new List<string>();

        public TextFindForm(GetContentMethod method, FindCallback findCall, bool openReplace = false)
        {
            InitializeComponent();
            SkinUtil.SetFormSkin(this);
            this.openReplace = openReplace;
            this.getContent = method;
            this.findCall = findCall;
        }

        public TextFindForm(GetContentMethod method, FindCallback findCall, ReplaceCallback replaceCall)
            : this(method, findCall, true)
        {
            this.replaceCall = replaceCall;
        }

        private void regex_CheckedChanged(object sender, EventArgs e)
        {
            if (cb_regex.Checked)
            {
                cb_case.Enabled = false;
                cb_case.Checked = false;
                cb_whole.Enabled = false;
                cb_whole.Checked = false;
            }
            else
            {
                cb_case.Enabled = true;
                cb_whole.Enabled = true;
            }
        }

        private void find_Click(object sender, EventArgs e)
        {
            FindStr();
        }
        
        private void btn_replace_find_Click(object sender, EventArgs e)
        {
            ReplaceStr();

            bool result = FindStr();
        }

        private void btn_replace_Click(object sender, EventArgs e)
        {
            ReplaceStr();
        }

        private void btn_replace_all_Click(object sender, EventArgs e)
        {
            string res = text_res.Text;
            if(res.Length > 0){
                ReplaceStr(res, true);
            }
        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void TextFindForm_Load(object sender, EventArgs e)
        {
            if (!this.openReplace)
            {
                text_target.Enabled = false;
                btn_replace.Enabled = false;
                btn_replace_all.Enabled = false;
                btn_replace_find.Enabled = false;
            }
        }

        private void addFindHisItem(string str) {
            if (null != str && str.Length > 0 && !findHisList.Contains(str))
            {
                findHisList.Add(str);

                text_res.Items.Add(str);
            }
        }

        private void text_res_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || cb_immed.Checked)
            {
                FindStr();
            }
        }

        public bool FindStr()
        {
            bool finds = false;
            string text = text_res.Text;
            info.Text = "";
            if (text != "")
            {
                string content = getContent();
                bool caseDx = cb_case.Checked;
                bool whole = cb_whole.Checked;
                bool regex = cb_regex.Checked;

                if (tempCont != content || text != tempStr)
                {
                    string fmt = null;
                    if (whole)
                    {
                        fmt = "[^\u4e00-\u9fa50-9a-zA-Z]+{0}[^\u4e00-\u9fa50-9a-zA-Z]+";
                    }

                    reg1 = new Regex(fmt == null ? text : string.Format(fmt, text));
                    reg2 = null;
                    if (caseDx)
                    {
                        if (text.ToUpper() != text.ToLower())
                        {
                            reg1 = new Regex(fmt == null ? text.ToUpper() : string.Format(fmt, text.ToUpper()));
                            reg2 = new Regex(fmt == null ? text.ToLower() : string.Format(fmt, text.ToLower()));
                        }
                    }

                    match1 = reg1.Match(content);
                    match2 = null;
                    if (reg2 != null)
                    {
                        match2 = reg2.Match(content);
                    }
                }
                else
                {
                    match1 = reg1.Match(content, match1.Index + match1.Length);
                    if (reg2 != null)
                    {
                        match2 = reg2.Match(content, match2.Index + match2.Length);
                    }
                }


                if (null != match1 && match1.Success) //当查找成功时候
                {
                    tempCont = content;
                    tempStr = text;
                    addFindHisItem(text);
                    finds = true;

                    findCall(text, match1.Index);
                }
                else if (null != match2 && match2.Success) //当查找成功时候
                {
                    tempCont = content;
                    tempStr = text;
                    addFindHisItem(text);
                    finds = true;

                    findCall(text, match2.Index);
                }
                else
                {
                    info.Text = "没有找到结果";
                }
            }
            return finds;
        }

        public void ReplaceStr(string res = null, bool isAll = false)
        {
            string target = text_target.Text;
            replaceCall(target, res, isAll);
        }

    }
}
