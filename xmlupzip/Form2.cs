using FileHelper;
using Ionic.Zip;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using XMLHELPER;

namespace xmlupzip
{
    public partial class Form2 : Form
    {
        string strFullPath = "";
        string strFileName = "";
        string root = "";
        string tmpFileDirNames = "Temp";
        string tmpFileDirUrl = "";  //临时文件夹路径
        string xmlFileNames = "xml.xml";//xml文件文件名字
        string xmlFileUrl = ""; //xml文件路径
        public Form2()
        {
            InitializeComponent();
            strFullPath = System.Windows.Forms.Application.ExecutablePath;
            strFileName = System.IO.Path.GetFileName(strFullPath);
            root = strFullPath.Substring(0, strFullPath.Length - strFileName.Length);
            tmpFileDirUrl = root + tmpFileDirNames;
            xmlFileUrl = root + tmpFileDirNames + '\\' + xmlFileNames;
        }

        private void chick2_bt_Click(object sender, EventArgs e)
        {
            CreateFilsDir();//创建文件夹

            System.Diagnostics.Process.Start(tmpFileDirUrl); //打开文件夹

            chick2_bt.Enabled = false;
        }

        private bool CreateFilsDir()
        {
            try
            {
                if (Directory.Exists(tmpFileDirUrl))
                {
                    IOHelper.DeleteDir(new DirectoryInfo(tmpFileDirUrl));
                }
                Thread.Sleep(2000);

                IOHelper.CreateDir(tmpFileDirUrl);         //创建目录
                return true;
            }
            catch (Exception ex)
            {
                // throw new Exception(ex.Message);
                return false;
            }
        }

        private void zip2_bt_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();

            sfd.AddExtension = true;
            sfd.DefaultExt = ".zip";



            if (sfd.ShowDialog() == DialogResult.OK)

            {

                string fileName = sfd.FileName;

                toXml();
                Zip(fileName);
                Thread.Sleep(3000);
                delTemFiles();
                MessageBox.Show("生成成功！！！！");
                System.Environment.Exit(0);
            }
        }

        private void delTemFiles()
        {
            DirectoryInfo x = new DirectoryInfo(tmpFileDirUrl);
            IOHelper.DeleteDir(x);
        }

        private void toXml()
        {
            string f = "";
            List<string> listImg = new List<string>();
            listImg = toImages();

            XMLHelper.CreateXmlDocument(xmlFileUrl, "template", "1.0", "UTF-8", "yes");
            XMLHelper.CreateOrUpdateXmlNodeByXPath(xmlFileUrl, "/template", "object", "", true);
            for (int i = 0; i < listImg.Count; i++)
            {
               var x = System.IO.Path.GetFileName(listImg[i]);
                if (x == "pc_main.jpg")
                {
                    XMLHelper.CreateXmlNodeByXPath(xmlFileUrl, "/template/object", "pc_coverImage", "", "name", "pc_main.jpg");
                }
                if (x == "ap_main.jpg")
                {
                    XMLHelper.CreateXmlNodeByXPath(xmlFileUrl, "/template/object", "ap_coverImage", "", "name", "ap_main.jpg");
                }
                if (x == "wx_main.jpg")
                {
                    XMLHelper.CreateXmlNodeByXPath(xmlFileUrl, "/template/object", "wx_coverImage", "", "name", "wx_main.jpg");
                }
            }
               
           
            
            

            XMLHelper.CreateOrUpdateXmlNodeByXPath(xmlFileUrl, "/template/object", "pc_slidesImages", "", true);
            XMLHelper.CreateOrUpdateXmlNodeByXPath(xmlFileUrl, "/template/object", "pc_detailImages", "", true);
            XMLHelper.CreateOrUpdateXmlNodeByXPath(xmlFileUrl, "/template/object", "pc_serviceImages", "", true);
            XMLHelper.CreateOrUpdateXmlNodeByXPath(xmlFileUrl, "/template/object", "pc_clothShootImages", "", true);
            XMLHelper.CreateOrUpdateXmlNodeByXPath(xmlFileUrl, "/template/object", "pc_cosmeticImages", "", true);
            XMLHelper.CreateOrUpdateXmlNodeByXPath(xmlFileUrl, "/template/object", "pc_baseSampleImages", "", true); 
            XMLHelper.CreateOrUpdateXmlNodeByXPath(xmlFileUrl, "/template/object", "pc_processImages", "", true);

            
           
            XMLHelper.CreateOrUpdateXmlNodeByXPath(xmlFileUrl, "/template/object", "ap_slidesImages", "", true);
            XMLHelper.CreateOrUpdateXmlNodeByXPath(xmlFileUrl, "/template/object", "ap_detailImages", "", true);
            XMLHelper.CreateOrUpdateXmlNodeByXPath(xmlFileUrl, "/template/object", "ap_serviceImages", "", true);
            XMLHelper.CreateOrUpdateXmlNodeByXPath(xmlFileUrl, "/template/object", "ap_clothShootImages", "", true);
            XMLHelper.CreateOrUpdateXmlNodeByXPath(xmlFileUrl, "/template/object", "ap_cosmeticImages", "", true);
            XMLHelper.CreateOrUpdateXmlNodeByXPath(xmlFileUrl, "/template/object", "ap_baseSampleImages", "", true);
            XMLHelper.CreateOrUpdateXmlNodeByXPath(xmlFileUrl, "/template/object", "ap_processImages", "", true);

           
           
            XMLHelper.CreateOrUpdateXmlNodeByXPath(xmlFileUrl, "/template/object", "wx_slidesImages", "", true);
            XMLHelper.CreateOrUpdateXmlNodeByXPath(xmlFileUrl, "/template/object", "wx_detailImages", "", true);
            XMLHelper.CreateOrUpdateXmlNodeByXPath(xmlFileUrl, "/template/object", "wx_serviceImages", "", true);
            XMLHelper.CreateOrUpdateXmlNodeByXPath(xmlFileUrl, "/template/object", "wx_clothShootImages", "", true);
            XMLHelper.CreateOrUpdateXmlNodeByXPath(xmlFileUrl, "/template/object", "wx_cosmeticImages", "", true);
            XMLHelper.CreateOrUpdateXmlNodeByXPath(xmlFileUrl, "/template/object", "wx_baseSampleImages", "", true);
            XMLHelper.CreateOrUpdateXmlNodeByXPath(xmlFileUrl, "/template/object", "wx_processImages", "", true);
            for (int i = 0; i < listImg.Count; i++)
            {
                f = System.IO.Path.GetFileName(listImg[i]);
                switch (f.Substring(0,2))
                {

                    case "pc":
                        {
                            switch(f.Substring(3,2))
                            {
                                case "sl":
                                    {


                                        XMLHelper.CreateXmlNodeByXPath(xmlFileUrl, "/template/object/pc_slidesImages", "image", "", "name", f, "weight", (listImg.Count - i).ToString());

                                        //  XMLHelper.CreateXmlNodeByXPath(xmlFileUrl, "/template/object/slidesImages", "image", "", "name", f, "weight", f.Substring(f.IndexOf("_") + 1, 2));
                                        // XMLHelper.CreateXmlNodeByXPath(xmlFileUrl, "/template/object/detailImages", "image", "", "name",f);
                                    }
                                    break;
                                case "de":
                                    {



                                        XMLHelper.CreateXmlNodeByXPath(xmlFileUrl, "/template/object/pc_detailImages", "image", "", "name", f, "weight", (listImg.Count - i).ToString());
                                        //XMLHelper.CreateXmlNodeByXPath(xmlFileUrl, "/template/object/detailImages", "image", "", "name", f, "weight", f.Substring(f.IndexOf("_") + 1, 2));
                                        // XMLHelper.CreateXmlNodeByXPath(xmlFileUrl, "/template/object/detailImages", "image", "", "name",f);
                                    }
                                    break;
                                case "se":
                                    {



                                        XMLHelper.CreateXmlNodeByXPath(xmlFileUrl, "/template/object/pc_serviceImages", "image", "", "name", f, "weight", (listImg.Count - i).ToString());
                                        // XMLHelper.CreateXmlNodeByXPath(xmlFileUrl, "/template/object/serviceImages", "image", "", "name", f, "weight", f.Substring(f.IndexOf("_") + 1, 2));
                                        // XMLHelper.CreateXmlNodeByXPath(xmlFileUrl, "/template/object/detailImages", "image", "", "name",f);
                                    }
                                    break;
                                case "cl":
                                    {
                                        XMLHelper.CreateXmlNodeByXPath(xmlFileUrl, "/template/object/pc_clothShootImages", "image", "", "name", f, "weight", (listImg.Count - i).ToString());
                                        //  XMLHelper.CreateXmlNodeByXPath(xmlFileUrl, "/template/object/clothShootImages", "image", "", "name", f, "weight", f.Substring(f.IndexOf("_") + 1, 2));
                                        //  XMLHelper.CreateXmlNodeByXPath(xmlFileUrl, "/template/object/clothShootImages", "image", "", "name",f);
                                    }
                                    break;
                                case "co":
                                    {
                                        XMLHelper.CreateXmlNodeByXPath(xmlFileUrl, "/template/object/pc_cosmeticImages", "image", "", "name", f, "weight", (listImg.Count - i).ToString());
                                        //XMLHelper.CreateXmlNodeByXPath(xmlFileUrl, "/template/object/cosmeticImages", "image", "", "name", f, "weight", f.Substring(f.IndexOf("_") + 1, 2));
                                        // XMLHelper.CreateXmlNodeByXPath(xmlFileUrl, "/template/object/cosmeticImages", "image", "", "name",f);
                                    }
                                    break;
                                case "ba":
                                    {
                                        XMLHelper.CreateXmlNodeByXPath(xmlFileUrl, "/template/object/pc_baseSampleImages", "image", "", "name", f, "weight", (listImg.Count - i).ToString());
                                        //XMLHelper.CreateXmlNodeByXPath(xmlFileUrl, "/template/object/baseSampleImages", "image", "", "name", f, "weight", f.Substring(f.IndexOf("_")+1,2));
                                        //  XMLHelper.CreateXmlNodeByXPath(xmlFileUrl, "/template/object/baseSampleImages", "image", "", "name",f);
                                    }
                                    break;
                                case "pr":
                                    {
                                        XMLHelper.CreateXmlNodeByXPath(xmlFileUrl, "/template/object/pc_processImages", "image", "", "name", f, "weight", (listImg.Count - i).ToString());
                                        //XMLHelper.CreateXmlNodeByXPath(xmlFileUrl, "/template/object/processImages", "image", "", "name", f, "weight", f.Substring(f.IndexOf("_") + 1, 2));
                                        //  XMLHelper.CreateXmlNodeByXPath(xmlFileUrl, "/template/object/baseSampleImages", "image", "", "name",f);
                                    }
                                    break;
                                default:
                                    break;
                            }
                        }
                        break;
                    case "ap":
                        {
                            switch(f.Substring(3,2))
                            {
                                case "sl":
                                    {


                                        XMLHelper.CreateXmlNodeByXPath(xmlFileUrl, "/template/object/ap_slidesImages", "image", "", "name", f, "weight", (listImg.Count - i).ToString());

                                        //  XMLHelper.CreateXmlNodeByXPath(xmlFileUrl, "/template/object/slidesImages", "image", "", "name", f, "weight", f.Substring(f.IndexOf("_") + 1, 2));
                                        // XMLHelper.CreateXmlNodeByXPath(xmlFileUrl, "/template/object/detailImages", "image", "", "name",f);
                                    }
                                    break;
                                case "de":
                                    {



                                        XMLHelper.CreateXmlNodeByXPath(xmlFileUrl, "/template/object/ap_detailImages", "image", "", "name", f, "weight", (listImg.Count - i).ToString());
                                        //XMLHelper.CreateXmlNodeByXPath(xmlFileUrl, "/template/object/detailImages", "image", "", "name", f, "weight", f.Substring(f.IndexOf("_") + 1, 2));
                                        // XMLHelper.CreateXmlNodeByXPath(xmlFileUrl, "/template/object/detailImages", "image", "", "name",f);
                                    }
                                    break;
                                case "se":
                                    {



                                        XMLHelper.CreateXmlNodeByXPath(xmlFileUrl, "/template/object/ap_serviceImages", "image", "", "name", f, "weight", (listImg.Count - i).ToString());
                                        // XMLHelper.CreateXmlNodeByXPath(xmlFileUrl, "/template/object/serviceImages", "image", "", "name", f, "weight", f.Substring(f.IndexOf("_") + 1, 2));
                                        // XMLHelper.CreateXmlNodeByXPath(xmlFileUrl, "/template/object/detailImages", "image", "", "name",f);
                                    }
                                    break;
                                case "cl":
                                    {
                                        XMLHelper.CreateXmlNodeByXPath(xmlFileUrl, "/template/object/ap_clothShootImages", "image", "", "name", f, "weight", (listImg.Count - i).ToString());
                                        //  XMLHelper.CreateXmlNodeByXPath(xmlFileUrl, "/template/object/clothShootImages", "image", "", "name", f, "weight", f.Substring(f.IndexOf("_") + 1, 2));
                                        //  XMLHelper.CreateXmlNodeByXPath(xmlFileUrl, "/template/object/clothShootImages", "image", "", "name",f);
                                    }
                                    break;
                                case "co":
                                    {
                                        XMLHelper.CreateXmlNodeByXPath(xmlFileUrl, "/template/object/ap_cosmeticImages", "image", "", "name", f, "weight", (listImg.Count - i).ToString());
                                        //XMLHelper.CreateXmlNodeByXPath(xmlFileUrl, "/template/object/cosmeticImages", "image", "", "name", f, "weight", f.Substring(f.IndexOf("_") + 1, 2));
                                        // XMLHelper.CreateXmlNodeByXPath(xmlFileUrl, "/template/object/cosmeticImages", "image", "", "name",f);
                                    }
                                    break;
                                case "ba":
                                    {
                                        XMLHelper.CreateXmlNodeByXPath(xmlFileUrl, "/template/object/ap_baseSampleImages", "image", "", "name", f, "weight", (listImg.Count - i).ToString());
                                        //XMLHelper.CreateXmlNodeByXPath(xmlFileUrl, "/template/object/baseSampleImages", "image", "", "name", f, "weight", f.Substring(f.IndexOf("_")+1,2));
                                        //  XMLHelper.CreateXmlNodeByXPath(xmlFileUrl, "/template/object/baseSampleImages", "image", "", "name",f);
                                    }
                                    break;
                                case "pr":
                                    {
                                        XMLHelper.CreateXmlNodeByXPath(xmlFileUrl, "/template/object/ap_processImages", "image", "", "name", f, "weight", (listImg.Count - i).ToString());
                                        //XMLHelper.CreateXmlNodeByXPath(xmlFileUrl, "/template/object/processImages", "image", "", "name", f, "weight", f.Substring(f.IndexOf("_") + 1, 2));
                                        //  XMLHelper.CreateXmlNodeByXPath(xmlFileUrl, "/template/object/baseSampleImages", "image", "", "name",f);
                                    }
                                    break;
                                default:
                                    break;
                            }

                        }
                        break;
                    case "wx":
                        {
                            switch(f.Substring(3,2))
                            {
                                case "sl":
                                    {


                                        XMLHelper.CreateXmlNodeByXPath(xmlFileUrl, "/template/object/wx_slidesImages", "image", "", "name", f, "weight", (listImg.Count - i).ToString());

                                        //  XMLHelper.CreateXmlNodeByXPath(xmlFileUrl, "/template/object/slidesImages", "image", "", "name", f, "weight", f.Substring(f.IndexOf("_") + 1, 2));
                                        // XMLHelper.CreateXmlNodeByXPath(xmlFileUrl, "/template/object/detailImages", "image", "", "name",f);
                                    }
                                    break;
                                case "de":
                                    {



                                        XMLHelper.CreateXmlNodeByXPath(xmlFileUrl, "/template/object/wx_detailImages", "image", "", "name", f, "weight", (listImg.Count - i).ToString());
                                        //XMLHelper.CreateXmlNodeByXPath(xmlFileUrl, "/template/object/detailImages", "image", "", "name", f, "weight", f.Substring(f.IndexOf("_") + 1, 2));
                                        // XMLHelper.CreateXmlNodeByXPath(xmlFileUrl, "/template/object/detailImages", "image", "", "name",f);
                                    }
                                    break;
                                case "se":
                                    {



                                        XMLHelper.CreateXmlNodeByXPath(xmlFileUrl, "/template/object/wx_serviceImages", "image", "", "name", f, "weight", (listImg.Count - i).ToString());
                                        // XMLHelper.CreateXmlNodeByXPath(xmlFileUrl, "/template/object/serviceImages", "image", "", "name", f, "weight", f.Substring(f.IndexOf("_") + 1, 2));
                                        // XMLHelper.CreateXmlNodeByXPath(xmlFileUrl, "/template/object/detailImages", "image", "", "name",f);
                                    }
                                    break;
                                case "cl":
                                    {
                                        XMLHelper.CreateXmlNodeByXPath(xmlFileUrl, "/template/object/wx_clothShootImages", "image", "", "name", f, "weight", (listImg.Count - i).ToString());
                                        //  XMLHelper.CreateXmlNodeByXPath(xmlFileUrl, "/template/object/clothShootImages", "image", "", "name", f, "weight", f.Substring(f.IndexOf("_") + 1, 2));
                                        //  XMLHelper.CreateXmlNodeByXPath(xmlFileUrl, "/template/object/clothShootImages", "image", "", "name",f);
                                    }
                                    break;
                                case "co":
                                    {
                                        XMLHelper.CreateXmlNodeByXPath(xmlFileUrl, "/template/object/wx_cosmeticImages", "image", "", "name", f, "weight", (listImg.Count - i).ToString());
                                        //XMLHelper.CreateXmlNodeByXPath(xmlFileUrl, "/template/object/cosmeticImages", "image", "", "name", f, "weight", f.Substring(f.IndexOf("_") + 1, 2));
                                        // XMLHelper.CreateXmlNodeByXPath(xmlFileUrl, "/template/object/cosmeticImages", "image", "", "name",f);
                                    }
                                    break;
                                case "ba":
                                    {
                                        XMLHelper.CreateXmlNodeByXPath(xmlFileUrl, "/template/object/wx_baseSampleImages", "image", "", "name", f, "weight", (listImg.Count - i).ToString());
                                        //XMLHelper.CreateXmlNodeByXPath(xmlFileUrl, "/template/object/baseSampleImages", "image", "", "name", f, "weight", f.Substring(f.IndexOf("_")+1,2));
                                        //  XMLHelper.CreateXmlNodeByXPath(xmlFileUrl, "/template/object/baseSampleImages", "image", "", "name",f);
                                    }
                                    break;
                                case "pr":
                                    {
                                        XMLHelper.CreateXmlNodeByXPath(xmlFileUrl, "/template/object/wx_processImages", "image", "", "name", f, "weight", (listImg.Count - i).ToString());
                                        //XMLHelper.CreateXmlNodeByXPath(xmlFileUrl, "/template/object/processImages", "image", "", "name", f, "weight", f.Substring(f.IndexOf("_") + 1, 2));
                                        //  XMLHelper.CreateXmlNodeByXPath(xmlFileUrl, "/template/object/baseSampleImages", "image", "", "name",f);
                                    }
                                    break;
                                default:
                                    break;
                            }
                        }
                        break;
                }
              
            }


        }

        private void Zip(string zipname)
        {
            string strFullPath = System.Windows.Forms.Application.ExecutablePath;
            string strFileName = System.IO.Path.GetFileName(strFullPath);
            string strFolder = strFullPath.Substring(0, strFullPath.Length - strFileName.Length);
            string strZipName = strFolder + "zip.zip";

            using (ZipFile zip = new ZipFile(Encoding.UTF8))
            {
                zip.AddDirectory(tmpFileDirUrl, "");
                zip.Comment = "This zip was created at " + System.DateTime.Now.ToString("G");
                zip.Save(zipname);
            }


           

        }

        private List<string> toImages()
        {

            List<string> x = new List<string>();
            string[] files = Directory.GetFiles(tmpFileDirUrl);//得到文件
            foreach (string file in files)//循环文件
            {
                x.Add(file);
            }
            x.Sort();
            return x;
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }
    }
}
