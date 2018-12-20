using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace AppMonitor
{
    public class TextBoxWriter : TextWriter
    {
        RichTextBox textBox;
        delegate void WriteFunc(string value);
        WriteFunc write;
        WriteFunc writeLine;

        public TextBoxWriter(RichTextBox textBox)
        {
            this.textBox = textBox;
            write = Write;
            writeLine = WriteLine;
        }


        // 使用UTF-16避免不必要的编码转换
        public override Encoding Encoding
        {
            get { return Encoding.Unicode; }
        }


        // 最低限度需要重写的方法
        public override void Write(string value)
        {
            if (textBox.InvokeRequired)
                textBox.BeginInvoke(write, value);
            else
                textBox.AppendText(value);
        }


        // 为提高效率直接处理一行的输出
        public override void WriteLine(string value)
        {
            if (textBox.InvokeRequired)
                textBox.BeginInvoke(writeLine, value);
            else
            {
                textBox.AppendText(value);
                textBox.AppendText(this.NewLine);
            }
        }


    }
}
