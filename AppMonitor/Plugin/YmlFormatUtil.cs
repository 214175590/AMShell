using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace AppMonitor.Plugin
{
    public class YmlFormatUtil
    {

        public static List<YmlLine> FormatYml(string content, bool beautify = false)
        {
            List<YmlLine> list = new List<YmlLine>();
            string[] lines = content.Split('\n');
            YmlLine ylText = null;
            int index1 = -1, index2 = -1, count = 0, num = 0;
            string startStr = null, endStr = null, line = "";
            string key = null, value = null, mh = ":";
            List<int> levels = new List<int>();
            for(int i = 0, k = lines.Length; i < k; i++){
                line = lines[i];

                if(line.TrimStart().StartsWith("#")){
                    ylText = new YmlLine()
                    {
                        Text = line + "\n",
                        Color = Color.Gray
                    };
                    list.Add(ylText);
                }
                else
                {
                    // 非整行注释

                    // 美化
                    if (beautify)
                    {
                        count = StartSpaceCount(line);
                        if (count == 0)
                        {
                            levels.Clear();
                        }
                        // level
                        if (!levels.Contains(count))
                        {
                            levels.Add(count);
                            levels.Sort();
                        }
                        num = levels.IndexOf(count) * 4;
                        if (num > count)
                        {
                            line = GetSpace(num - count) + line;
                        }
                    }                    

                    // 行中有井号，但不是首位#
                    index2 = line.IndexOf("#");
                    if(index2 > 0){
                        startStr = line.Substring(0, index2);

                        index1 = startStr.IndexOf(":");
                        if (index1 > 0)
                        {
                            // key
                            key = startStr.Substring(0, index1);
                            ylText = new YmlLine()
                            {
                                Text = key,
                                Color = Color.OrangeRed
                            };
                            list.Add(ylText);
                            // :
                            ylText = new YmlLine()
                            {
                                Text = mh,
                                Color = Color.Violet
                            };
                            list.Add(ylText);
                            // value
                            value = startStr.Substring(index1 + 1);
                            ylText = new YmlLine()
                            {
                                Text = value,
                                Color = getTextColor(value)
                            };
                            list.Add(ylText);
                        }
                        else
                        {
                            ylText = new YmlLine()
                            {
                                Text = "#" + startStr,
                                Color = Color.Gray
                            };
                            list.Add(ylText);
                        }

                        // 注释掉的部分
                        endStr = line.Substring(index2);
                        ylText = new YmlLine()
                        {
                            Text = endStr + "\n",
                            Color = Color.Gray
                        };
                        list.Add(ylText);
                    }
                    else
                    {
                        // 行中无井号
                        startStr = line;

                        index1 = startStr.IndexOf(":");
                        if (index1 > 0)
                        {
                            // key
                            key = startStr.Substring(0, index1);
                            ylText = new YmlLine()
                            {
                                Text = key,
                                Color = Color.OrangeRed
                            };
                            list.Add(ylText);
                            // :
                            ylText = new YmlLine()
                            {
                                Text = mh,
                                Color = Color.Violet
                            };
                            list.Add(ylText);
                            // value
                            value = startStr.Substring(index1 + 1);
                            ylText = new YmlLine()
                            {
                                Text = value + "\n",
                                Color = getTextColor(value)
                            };
                            list.Add(ylText);
                        }
                        else
                        {
                            // 行中无井号,且是不合规的配置值
                            if (string.IsNullOrWhiteSpace(line))
                            {
                                ylText = new YmlLine()
                                {
                                    Text = line + "\n",
                                    Color = Color.OrangeRed
                                };
                            }
                            else
                            {
                                ylText = new YmlLine()
                                {
                                    Text = "#" + line + "\n",
                                    Color = Color.Gray
                                };
                            }                            
                            list.Add(ylText);                            
                        }
                    }
                }
            }
            return list;
        }

        public static List<YmlItem> FormatYmlToTree(string content)
        {
            List<YmlItem> lists = new List<YmlItem>();
            string[] lines = content.Split('\n');
            YmlItem item = null;
            string startStr = "";
            List<YmlItem> levels = new List<YmlItem>();
            int index1 = -1, index2 = -1, index = 0;
            foreach(string line in lines){
                if(string.IsNullOrWhiteSpace(line)){
                    item = new YmlItem();
                    item.Uuid = "T" + (index++);
                    item.ImageIndex = 2;
                    item.Key = "#" + line;
                    item.Value = "";
                    item.Level = 0;
                    item.Common = "";

                    lists.Add(item);
                    continue;
                }
                if(line.TrimStart().StartsWith("#")){
                    item = new YmlItem();
                    item.Uuid = "T" + (index++);
                    item.ImageIndex = 2;
                    item.Key = line;
                    item.Value = "";
                    item.Level = 0;
                    item.Common = "";

                    lists.Add(item);
                }
                else
                {
                    item = new YmlItem();
                    item.Uuid = "T" + (index++);
                    item.ImageIndex = 0;
                    item.Key = "";
                    item.Value = "";
                    item.Level = 0;
                    item.Common = "";

                    item.SpcCount = StartSpaceCount(line);
                    if (item.SpcCount == 0)
                    {
                        levels.Clear();
                        item.Level = 0;
                    }
                    else
                    {
                        // level
                        for (int i = levels.Count - 1; i >= 0; i-- )
                        {
                            if (levels[i].SpcCount < item.SpcCount)
                            {
                                item.Level = levels[i].Level + 1;
                                item.Parent = levels[i];
                                break;
                            }
                        }
                    }
                    levels.Add(item);

                    index2 = line.IndexOf("#");
                    if (index2 > 0)
                    {
                        startStr = line.Substring(0, index2);
                        item.Common = line.Substring(index2);
                    }
                    else
                    {
                        startStr = line;
                    }

                    index1 = startStr.IndexOf(":");
                    if (index1 > 0)
                    {
                        item.Key = startStr.Substring(0, index1).TrimStart();
                        item.Value = startStr.Substring(index1 + 1).Trim();
                    }
                    else
                    {
                        item.Key = startStr.TrimStart();
                        item.Common = "--格式错误--";
                    }

                    if (!string.IsNullOrWhiteSpace(item.Value))
                    {
                        item.ImageIndex = 1;
                    }

                    lists.Add(item);
                }
            }

            return lists;
        }

        public static int StartSpaceCount(string line)
        {
            int count = 0;
            string c = "";
            for (int i = 0, k = line.Length; i < k; i++ )
            {
                c = line.Substring(i, 1);
                if(c != " "){
                    break;
                }
                count++;
            }
            return count;
        }

        public static string GetSpace(int size)
        {
            string c = "";
            for (int i = 0; i < size; i++)
            {
                c += " ";
            }
            return c;
        }

        public static YmlError ValidateYml(string content)
        {
            YmlError result = null;
            string[] lines = content.Split('\n');
            int index1 = -1, index2 = -1, lineIndex = 1, index = 0;
            string startStr = null;
            foreach (string line in lines)
            {
                if (!line.TrimStart().StartsWith("#"))
                {
                    if (line.IndexOf("	") != -1 && line.Substring(0, line.IndexOf("	")).IndexOf("#") == -1)
                    {
                        result = new YmlError();
                        result.line = lineIndex;
                        result.index = content.IndexOf("	", index);
                        result.msg = string.Format("第{0}行，位置{1}包含Tab符", lineIndex, line.IndexOf("	"));
                        break;
                    }
                    else if (!string.IsNullOrWhiteSpace(line))
                    {
                        index2 = line.IndexOf("#");
                        if (index2 > 0)
                        {
                            startStr = line.Substring(0, index2);
                            index1 = startStr.IndexOf(":");
                            if (index1 <= 0)
                            {
                                result = new YmlError();
                                result.line = lineIndex;
                                result.index = index;
                                result.msg = string.Format("第{0}行，格式不正确，缺少冒号", lineIndex);
                                break;
                            }
                        }
                        else
                        {
                            index1 = line.IndexOf(":");
                            if (index1 <= 0)
                            {
                                result = new YmlError();
                                result.line = lineIndex;
                                result.index = index;
                                result.msg = string.Format("第{0}行，格式不正确，缺少冒号", lineIndex);
                                break;
                            }
                        }
                    }
                }
                
                lineIndex++;
                index += line.Length;
            }        
            return result;
        }

        public static Color getTextColor(string str)
        {
            Color color = Color.DarkCyan;
            if(!string.IsNullOrWhiteSpace(str)){
                if (str.Trim() == "true" || str.Trim() == "false")
                {
                    color = Color.Red;
                }
                else
                {
                    Match m = Regex.Match(str.Trim(), @"^(-?\d+)(\.\d+)?$");
                    if (m.Success)
                    {
                        color = Color.YellowGreen;
                    }
                }
            }            
            return color;
        }

    }

    public class YmlLine {
        public string Text { get; set; }

        private Color _color = Color.CadetBlue;
        public Color Color
        {
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

        private Font _font = new Font("Courier New", 11, FontStyle.Regular);
        public Font Font
        {
            get
            {
                return _font;
            }
            set
            {
                _font = value;
            }
        }
    }

    public class YmlFile
    {
        public string localPath { get; set; }
        public string localName { get; set; }
        public string remoteName { get; set; }
        public string remotePath { get; set; }
        public YmlFileState status { get; set; }
        public bool correct { get; set; }
    }

    public enum YmlFileState
    {
        NoModif, Modif, NoAsync
    }

    public class YmlError
    {
        public string msg { get; set; }

        public int line { get; set; }

        public int index { get; set; }
    }

}
