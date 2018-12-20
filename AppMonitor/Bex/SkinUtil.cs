using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AppMonitor.Bex
{
    public class SkinUtil
    {

        public static void SetFormSkin(Form form)
        {
            int index = AppConfig.Instance.MConfig.SkinIndex;
            DirectoryInfo dire = new DirectoryInfo(MainForm.APP_DIR + "\\skin");
            if (dire.Exists)
            {
                FileInfo[] files = dire.GetFiles();
                int i = 0;
                foreach (FileInfo file in files)
                {
                    if(index == i){
                        form.BackgroundImage = new Bitmap(file.FullName);
                        form.BackgroundImageLayout = ImageLayout.Stretch; 
                        break;
                    }
                    i++;
                }
            }                                   
        }


    }
}
