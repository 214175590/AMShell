using AppMonitor.Bex;
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
    public partial class InputForm : CCWin.Skin_Metro
    {
        private FormResult result;
        public delegate void FormResult(string result);
        public InputForm()
        {
            InitializeComponent();
            SkinUtil.SetFormSkin(this);
        }

        public InputForm(string msg, string value, FormResult result) : this()
        {
            this.info.Text = msg;
            this.input.Text = value == null ? "" : value;
            this.input.WaterText = msg;
            this.result = result;
        }

        private void InputForm_Load(object sender, EventArgs e)
        {
            this.input.SkinTxt.KeyUp += SkinTxt_KeyUp;
        }

        void SkinTxt_KeyUp(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter){
                btn_sure_Click(null, null);
            }
        }

        private void btn_sure_Click(object sender, EventArgs e)
        {
            if(result != null){
                result(this.input.Text);
            }
            this.Close();
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
