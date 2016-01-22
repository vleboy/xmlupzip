using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace xmlupzip
{
       static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            string strFullPath = System.Windows.Forms.Application.ExecutablePath;
            string strFileName = System.IO.Path.GetFileName(strFullPath);
            string strFolder = strFullPath.Substring(0, strFullPath.Length - strFileName.Length);
            bool iscreatnew = false;
            string par = "";
            Mutex _mutex = new Mutex(true, "jsbn_Mutex", out iscreatnew);
            if (args.Length != 0)
            {
                String parameter = Regex.Match(args[0], @"(?<=://).+?(?=:|/|\Z)").Value;
                string[] paras = parameter.Split('&');
                foreach (var item in paras)
                {
                    par = item.ToString();
                   // MessageBox.Show(item);
                }

            }
            if (!iscreatnew)
            {

                Application.Exit();
            }
            else if(par == "cms")
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new Form1());
            }
            else if(par == "product")
            {

                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new Form2());
            }
            else
            {
               // Application.EnableVisualStyles();
              //  Application.SetCompatibleTextRenderingDefault(false);
              //  Application.Run(new Form2());


                   MessageBox.Show("输入错误");
                   System.Environment.Exit(0);

            }

        }
    }
}



