using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace AppMonitor
{
    public class MessageUtils
    {
        public static readonly string EMPTY = "";
        public static readonly string T = "";
        public static readonly string T0m = "[0m";
        public static readonly string Tm = "[m";
        public static readonly string TK = "[K";
        public static readonly string T0131 = "[01;31m";
        public static readonly string T0132 = "[01;32m";
        public static readonly string T0134 = "[01;34m";
        public static readonly string T0136 = "[01;36m";
        public static readonly string T3042 = "[30;42m";

        public static List<Message> FormatMessage(List<Message> msgList, string message)
        {
            if (msgList == null)
            {
                msgList = new List<Message>();
            }
            Message msg = null;
            if (message.IndexOf(T0m) == -1 && message.IndexOf(Tm) == -1 && message.IndexOf(TK) == -1)
            {
                msg = new Message();
                msg.Text = message;
                msgList.Add(msg);
            }
            else
            {
                message = message.Replace(TK, "");
                message = message.Replace(Tm, T0m);

                string[] arrs = message.Split(new string[] { T0m }, StringSplitOptions.None);
                string str = null;
                int index = -1;
                foreach (string line in arrs)
                {
                    str = line.Replace("\r\n", "\n");
                    if ((index = str.IndexOf(T0131)) != -1)
                    {
                        SplitMsg(msgList, str, index, T0131, Color.IndianRed, Color.Empty);                        
                    }
                    else if ((index = str.IndexOf(T0132)) != -1)
                    {
                        SplitMsg(msgList, str, index, T0132, Color.LawnGreen, Color.Empty);
                    }
                    else if ((index = str.IndexOf(T0134)) != -1)
                    {
                        SplitMsg(msgList, str, index, T0134, Color.RoyalBlue, Color.Empty);
                    }
                    else if ((index = str.IndexOf(T0136)) != -1)
                    {
                        SplitMsg(msgList, str, index, T0136, Color.PowderBlue, Color.Empty);
                    }
                    else if ((index = str.IndexOf(T3042)) != -1)
                    {
                        SplitMsg(msgList, str, index, T3042, Color.CadetBlue, Color.Green);
                    }
                    else
                    {
                        msg = new Message();
                        msg.Text = str;
                        msgList.Add(msg);
                    }
                }
            }            
            return msgList;
        }

        private static void SplitMsg(List<Message> msgList, string str, int index, string flag, Color color, Color back)
        {
            Message msg = null;
            if (index > 0)
            {
                string str1 = str.Substring(0, index);
                msg = new Message();
                msg.Text = str1;
                msgList.Add(msg);
            }

            string str2 = str.Substring(index + flag.Length);
            msg = new Message();
            msg.Text = str2;
            msg.Color = color;
            if (back != Color.Empty)
            {
                msg.BackColor = back;
            }            
            msgList.Add(msg);
        }
    }

    public class Message {
        public string Text { get; set; }

        private Color _color = Color.CadetBlue;
        public Color Color {
            get
            {
                return _color;
            }
            set
            {
                _color = value;
            }
        }

        private Color _backColor = Color.FromArgb(255, 20, 20, 20);
        public Color BackColor
        {
            get
            {
                return _backColor;
            }
            set
            {
                _backColor = value;
            }
        }
    }
}
