using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using Tamir.SharpSsh;
using Tamir.SharpSsh.java.io;
using Tamir.SharpSsh.jsch;
using Tamir.Streams;

namespace AppMonitor
{
    public partial class Form1 : Form
    {
        SshShell shell;
        Channel m_Channel;
        string cmd = "";

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string host = tb_host.Text;
                string acc = tb_acc.Text;
                string pwd = tb_pwd.Text;

                shell = new SshShell(host, acc, pwd);

                //shell.RedirectToConsole();

                shell.Connect(22);

                m_Channel = shell.getChannel();
                
                string line = null;
                ThreadPool.QueueUserWorkItem((a) =>
                {
                    while (shell.ShellOpened)
                    {
                        System.Threading.Thread.Sleep(100);

                        while ((line = m_Channel.GetMessage()) != null)
                        {
                            ShowLogger(line);
                        }
                    }

                    Console.Write("Disconnecting...");
                    shell.Close();
                    Console.WriteLine("OK");
                });               

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            button1_Click(null, null);
        }

        public void ShowLogger(string line)
        {
            this.BeginInvoke((MethodInvoker)delegate()
            {
                line = line.Replace("\r\r", "");
                if(!line.EndsWith("\n")){
                    line += "\n";
                }
                List<Message> msgList = new List<Message>();
                if(line.StartsWith(cmd + "\r\n")){
                    string str1 = line.Substring(0, (cmd + "\r\n").Length);
                    msgList.Add(new Message() { 
                        Text = str1,
                        Color = Color.Red
                    });
                    MessageUtils.FormatMessage(msgList, line.Substring((cmd + "\r\n").Length));
                }
                else
                {
                    MessageUtils.FormatMessage(msgList, line);
                }
                foreach (Message msg in msgList)
                {
                    if(msg != null && msg.Text != null){
                        rtb_log.SelectionColor = msg.Color;
                        rtb_log.SelectionBackColor = msg.BackColor;
                        rtb_log.AppendText(msg.Text); 
                    }                     
                }

                rtb_log.Select(rtb_log.TextLength, 0);
                rtb_log.Focus();
                //滚动到控件光标处 
                rtb_log.ScrollToCaret();
                tb_shell.Focus();
            });
        }

        private void run_Click(object sender, EventArgs e)
        {
            cmd = tb_shell.Text;
            byte[] byteArray = System.Text.Encoding.Default.GetBytes(cmd + "\n");

            m_Channel.WriteBytes(byteArray);

            tb_shell.Text = "";
        }

        private void tb_shell_KeyUp(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter){
                run_Click(null, null);
            }            
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            System.Environment.Exit(0);
        }

    }
    
}

