using AppMonitor.Bex;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace AppMonitor.Froms
{
    public partial class QuickCommandManageForm : CCWin.Skin_Metro
    {
        SessionConfig config = null;
        DataGridViewRow currRow = null;

        public QuickCommandManageForm(SessionConfig _config)
        {
            InitializeComponent();
            SkinUtil.SetFormSkin(this);
            config = _config;
        }

        private void QuickCommandManageForm_Load(object sender, EventArgs e)
        {
            
            RenderList();
        }

        public void RenderList()
        {
            if (config.ShellList.Count > 0)
            {
                string shell = null;
                int index = 0;
                bool needCr = false;
                skinDataGridView1.Rows.Clear();
                DataGridViewRow row = null;
                DataGridViewTextBoxCell textCell = null;
                DataGridViewCheckBoxCell checkCell = null;
                DataGridViewButtonCell btnCell = null;
                foreach (string cmd in config.ShellList)
                {
                    try
                    {
                        shell = cmd;
                        if (shell.EndsWith("\n"))
                        {
                            needCr = true;
                            shell = shell.Substring(0, shell.Length - 1);
                        }
                        else
                        {
                            needCr = false;
                        }

                        row = new DataGridViewRow();
                        textCell = new DataGridViewTextBoxCell();
                        textCell.Value = index;
                        row.Cells.Add(textCell);

                        textCell = new DataGridViewTextBoxCell();
                        textCell.Value = shell;
                        row.Cells.Add(textCell);

                        checkCell = new DataGridViewCheckBoxCell();
                        checkCell.Value = needCr;
                        row.Cells.Add(checkCell);

                        btnCell = new DataGridViewButtonCell();
                        btnCell.Value = "删除";
                        row.Cells.Add(btnCell);

                        skinDataGridView1.Rows.Add(row);
                    }
                    catch { }
                    index++;                    
                }
            }


        }

        private void button1_Click(object sender, EventArgs e)
        {
            // 新增
            CustomScriptForm form = new CustomScriptForm(config);
            form.ShowDialog(this);

            RenderList();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void skinDataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int row = e.RowIndex;
            int cell = e.ColumnIndex;
            if (row >= 0)
            {
                button1.Enabled = true;
                if (cell == 3)
                { // 删除

                    DataGridViewCell indexCell = currRow.Cells[0];
                    if (null != indexCell)
                    {
                        int index = (int)indexCell.Value;
                        DialogResult dr = MessageBox.Show("确认删除此项吗？", "提示", MessageBoxButtons.OKCancel);
                        if (dr == DialogResult.OK)
                        {
                            //用户选择确认的操作
                            DefaultConfig.RemoveShellListItem(config.ShellList, index);
                            skinDataGridView1.Rows.RemoveAt(row);
                        }
                    }
                }
                else if (cell == 2)
                {
                    DataGridViewCell indexCell = currRow.Cells[0];
                    if (null != indexCell)
                    {
                        DataGridViewTextBoxCell textCell = (DataGridViewTextBoxCell) currRow.Cells[1];
                        string cmd = (string)textCell.Value;
                        int index = (int)indexCell.Value;                        
                        DataGridViewCheckBoxCell checkCell = (DataGridViewCheckBoxCell)skinDataGridView1.Rows[row].Cells[cell];
                        if (null != checkCell)
                        {
                            bool isChecked = Convert.ToBoolean(checkCell.EditedFormattedValue);
                            if(isChecked){
                                cmd += "\n";
                            }
                            DefaultConfig.UpdateShellListItem(config.ShellList, index, cmd);
                        }
                    }
                }
            }
            else
            {
                button1.Enabled = false;
            }
        }

        private void skinDataGridView1_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            int row = e.RowIndex;
            int cell = e.ColumnIndex;
            if (row >= 0)
            {
                currRow = skinDataGridView1.Rows[row];
            }
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CustomScriptForm form = new CustomScriptForm(config);
            form.ShowDialog(this);

            RenderList();
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (null != currRow)
            {
                DataGridViewCell indexCell = currRow.Cells[0];
                if (null != indexCell)
                {
                    int index = (int) indexCell.Value;
                    CustomScriptForm form = new CustomScriptForm(config, index);
                    form.ShowDialog(this);

                    RenderList();
                }
            }
        }

        private void removeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataGridViewCell indexCell = currRow.Cells[0];
            if (null != indexCell)
            {
                int index = (int)indexCell.Value;
                DialogResult dr = MessageBox.Show("确认删除此项吗？", "提示", MessageBoxButtons.OKCancel);
                if (dr == DialogResult.OK)
                {
                    //用户选择确认的操作
                    DefaultConfig.RemoveShellListItem(config.ShellList, index);
                    skinDataGridView1.Rows.Remove(currRow);
                    currRow = null;
                }
            }
        }

        private void skinDataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (null != currRow)
            {
                int row = e.RowIndex;
                if(row > 0){
                    DataGridViewCell indexCell = currRow.Cells[0];
                    if (null != indexCell)
                    {
                        int index = (int)indexCell.Value;
                        string cmd = (string) skinDataGridView1.Rows[row].Cells[1].Value;
                        bool isChecked = Convert.ToBoolean(currRow.Cells[2].Value);
                        if(isChecked){
                            cmd += "\n";
                        }
                        DefaultConfig.UpdateShellListItem(config.ShellList, index, cmd);
                    }                    
                }                
            }            
        }


    }
}
