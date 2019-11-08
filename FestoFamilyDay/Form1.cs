using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Gma.QrCodeNet.Encoding;
using Gma.QrCodeNet.Encoding.Windows.Render;
using System.IO;
using Gma.QrCodeNet.Encoding;
using Gma.QrCodeNet.Encoding.Windows.Render;
using System.Drawing.Printing;

namespace FestoFamilyDay
{
    public partial class Form1 : Form
    {
        int stepIndex = 0;//签名登记进行到第几步，panel N置于最顶层。打印完成panel置顶，stepIndex=1
        //int ChildID = 1;//每打印一张加1
        string str = "";//每个签到人员的唯一8位编号， 
        public int ChildID
        {
            get
            {
                if (File.Exists("config.ini"))
                {
                    IniFile ini = new IniFile("config.ini");
                    if (!ini.KeyExists("ChildID"))
                    {
                        return -1;
                    }
                    string s_ChildID = ini.Read("ChildID");
                    try
                    {
                        return Convert.ToInt16(s_ChildID);
                    }
                    catch (Exception)
                    {
                        return -1;
                    }
                }
                else
                {
                    return -1;
                }
            }
            set
            {
                IniFile ini = new IniFile("config.ini");
                ini.Write("ChildID", value.ToString());
            }
        }
        public int Remain_QiQuDan
        {
            get
            {
                if (File.Exists("config.ini"))
                {
                    IniFile ini = new IniFile("config.ini");
                    if (!ini.KeyExists("Remain_QiQuDan"))
                    {
                        return -1;
                    }
                    string s_ChildID = ini.Read("Remain_QiQuDan");
                    try
                    {
                        return Convert.ToInt16(s_ChildID);
                    }
                    catch (Exception)
                    {
                        return -1;
                    }
                }
                else
                {
                    return -1;
                }
            }
            set
            {
                IniFile ini = new IniFile("config.ini");
                ini.Write("Remain_QiQuDan", value.ToString());
            }
        }
        public int Remain_NaiPian
        {
            get
            {
                if (File.Exists("config.ini"))
                {
                    IniFile ini = new IniFile("config.ini");
                    if (!ini.KeyExists("Remain_NaiPian"))
                    {
                        return -1;
                    }
                    string s_ChildID = ini.Read("Remain_NaiPian");
                    try
                    {
                        return Convert.ToInt16(s_ChildID);
                    }
                    catch (Exception)
                    {
                        return -1;
                    }
                }
                else
                {
                    return -1;
                }
            }
            set
            {
                IniFile ini = new IniFile("config.ini");
                ini.Write("Remain_NaiPian", value.ToString());
            }
        }
        public int Remain_BangBangTang
        {
            get
            {
                if (File.Exists("config.ini"))
                {
                    IniFile ini = new IniFile("config.ini");
                    if (!ini.KeyExists("Remain_BangBangTang"))
                    {
                        return -1;
                    }
                    string s_ChildID = ini.Read("Remain_BangBangTang");
                    try
                    {
                        return Convert.ToInt16(s_ChildID);
                    }
                    catch (Exception)
                    {
                        return -1;
                    }
                }
                else
                {
                    return -1;
                }
            }
            set
            {
                IniFile ini = new IniFile("config.ini");
                ini.Write("Remain_BangBangTang", value.ToString());
            }
        }
        public int Remain_HaoLiYou
        {
            get
            {
                if (File.Exists("config.ini"))
                {
                    IniFile ini = new IniFile("config.ini");
                    if (!ini.KeyExists("Remain_HaoLiYou"))
                    {
                        return -1;
                    }
                    string s_ChildID = ini.Read("Remain_HaoLiYou");
                    try
                    {
                        return Convert.ToInt16(s_ChildID);
                    }
                    catch (Exception)
                    {
                        return -1;
                    }
                }
                else
                {
                    return -1;
                }
            }
            set
            {
                IniFile ini = new IniFile("config.ini");
                ini.Write("Remain_HaoLiYou", value.ToString());
            }
        }
        public int Remain_JianGuo
        {
            get
            {
                if (File.Exists("config.ini"))
                {
                    IniFile ini = new IniFile("config.ini");
                    if (!ini.KeyExists("Remain_JianGuo"))
                    {
                        return -1;
                    }
                    string s_ChildID = ini.Read("Remain_JianGuo");
                    try
                    {
                        return Convert.ToInt16(s_ChildID);
                    }
                    catch (Exception)
                    {
                        return -1;
                    }
                }
                else
                {
                    return -1;
                }
            }
            set
            {
                IniFile ini = new IniFile("config.ini");
                ini.Write("Remain_JianGuo", value.ToString());
            }
        }
        public int Remain_RuanTang
        {
            get
            {
                if (File.Exists("config.ini"))
                {
                    IniFile ini = new IniFile("config.ini");
                    if (!ini.KeyExists("Remain_RuanTang"))
                    {
                        return -1;
                    }
                    string s_ChildID = ini.Read("Remain_RuanTang");
                    try
                    {
                        return Convert.ToInt16(s_ChildID);
                    }
                    catch (Exception)
                    {
                        return -1;
                    }
                }
                else
                {
                    return -1;
                }
            }
            set
            {
                IniFile ini = new IniFile("config.ini");
                ini.Write("Remain_RuanTang", value.ToString());
            }
        }
        public int Remain_XingQiuBei
        {
            get
            {
                if (File.Exists("config.ini"))
                {
                    IniFile ini = new IniFile("config.ini");
                    if (!ini.KeyExists("Remain_XingQiuBei"))
                    {
                        return -1;
                    }
                    string s_ChildID = ini.Read("Remain_XingQiuBei");
                    try
                    {
                        return Convert.ToInt16(s_ChildID);
                    }
                    catch (Exception)
                    {
                        return -1;
                    }
                }
                else
                {
                    return -1;
                }
            }
            set
            {
                IniFile ini = new IniFile("config.ini");
                ini.Write("Remain_XingQiuBei", value.ToString());
            }
        }
        public int Remain_RouPu
        {
            get
            {
                if (File.Exists("config.ini"))
                {
                    IniFile ini = new IniFile("config.ini");
                    if (!ini.KeyExists("Remain_RouPu"))
                    {
                        return -1;
                    }
                    string s_ChildID = ini.Read("Remain_RouPu");
                    try
                    {
                        return Convert.ToInt16(s_ChildID);
                    }
                    catch (Exception)
                    {
                        return -1;
                    }
                }
                else
                {
                    return -1;
                }
            }
            set
            {
                IniFile ini = new IniFile("config.ini");
                ini.Write("Remain_RouPu", value.ToString());
            }
        }

        public Form1()
        {
            InitializeComponent();
            panel1.BringToFront();
            stepIndex = 1;
            if (ChildID==-1)
            {
                ChildID = 1;
            }
            str = ChildID.ToString().PadLeft(8, '0');
            checkRemain();
        }

        public void checkRemain()
        {
            if (Remain_QiQuDan>0)
            {
                radioButton5.Enabled = true;
            }
            else
            {
                radioButton5.Enabled = false;
            }
            if (Remain_NaiPian > 0)
            {
                radioButton6.Enabled = true;
            }
            else
            {
                radioButton6.Enabled = false;
            }
            if (Remain_BangBangTang > 0)
            {
                radioButton7.Enabled = true;
            }
            else
            {
                radioButton7.Enabled = false;
            }
            if (Remain_HaoLiYou > 0)
            {
                radioButton8.Enabled = true;
            }
            else
            {
                radioButton8.Enabled = false;
            }
            if (Remain_JianGuo > 0)
            {
                radioButton9.Enabled = true;
            }
            else
            {
                radioButton9.Enabled = false;
            }
            if (Remain_RuanTang > 0)
            {
                radioButton10.Enabled = true;
            }
            else
            {
                radioButton10.Enabled = false;
            }
            if (Remain_XingQiuBei > 0)
            {
                radioButton11.Enabled = true;
            }
            else
            {
                radioButton11.Enabled = false;
            }
            if (Remain_RouPu > 0)
            {
                radioButton12.Enabled = true;
            }
            else
            {
                radioButton12.Enabled = false;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            switch (stepIndex)
            {
                case 1:
                    panel2.Location = panel1.Location;
                    panel2.BringToFront();
                    stepIndex = 2;
                    break;
                case 2:
                    if (str=="")
                    {
                        if (radioButton1.Checked)
                        {
                            str = "01";
                        }
                        else if (radioButton2.Checked)
                        {
                            str = "02";
                        }
                        else if (radioButton3.Checked)
                        {
                            str = "03";
                        }
                        else if (radioButton4.Checked)
                        {
                            str = "04";
                        }
                    }
                    else
                    {
                        str = str.Remove(0, 2);
                        if (radioButton1.Checked)
                        {
                            str = str.Insert(0, "01");
                        }
                        else if (radioButton2.Checked)
                        {
                            str = str.Insert(0, "02");
                        }
                        else if (radioButton3.Checked)
                        {
                            str = str.Insert(0, "03");
                        }
                        else if (radioButton4.Checked)
                        {
                            str = str.Insert(0, "04");
                        }
                    }
                    panel3.Location = panel2.Location;
                    panel3.BringToFront();
                    stepIndex = 3;
                    break;
                case 3:
                    if (str == "")
                    {
                        if (radioButton5.Checked)
                        {
                            str = "01";
                        }
                        else if (radioButton6.Checked)
                        {
                            str = "02";
                        }
                        else if (radioButton7.Checked)
                        {
                            str = "03";
                        }
                        else if (radioButton8.Checked)
                        {
                            str = "04";
                        }
                        else if (radioButton9.Checked)
                        {
                            str = "05";
                        }
                        else if (radioButton10.Checked)
                        {
                            str = "06";
                        }
                        else if (radioButton11.Checked)
                        {
                            str = "07";
                        }
                        else if (radioButton12.Checked)
                        {
                            str = "08";
                        }
                        else
                        {
                            if (MessageBox.Show("No gift?", "Confirm", MessageBoxButtons.OKCancel)==DialogResult.OK)
                            {
                                str = "00";
                            }                            
                        }
                    }
                    else
                    {
                        str = str.Remove(2, 2);
                        if (radioButton5.Checked)
                        {
                            str = str.Insert(2, "01");
                        }
                        else if (radioButton6.Checked)
                        {
                            str = str.Insert(2, "02");
                        }
                        else if (radioButton7.Checked)
                        {
                            str = str.Insert(2, "03");
                        }
                        else if (radioButton8.Checked)
                        {
                            str = str.Insert(2, "04");
                        }
                        else if (radioButton9.Checked)
                        {
                            str = str.Insert(2, "05");
                        }
                        else if (radioButton10.Checked)
                        {
                            str = str.Insert(2, "06");
                        }
                        else if (radioButton11.Checked)
                        {
                            str = str.Insert(2, "07");
                        }
                        else if (radioButton12.Checked)
                        {
                            str = str.Insert(2, "08");
                        }
                        else
                        {
                            if (MessageBox.Show("No gift?", "Confirm", MessageBoxButtons.OKCancel) == DialogResult.OK)
                            {
                                str = str.Insert(2, "00");
                            }                            
                        }
                    }

                    printCode();
                    writeCSV(textBox1.Text, str);
                    if (radioButton5.Checked)
                    {
                        Remain_QiQuDan = Remain_QiQuDan - 1;
                    }
                    else if (radioButton6.Checked)
                    {
                        Remain_NaiPian = Remain_NaiPian - 1;
                    }
                    else if (radioButton7.Checked)
                    {
                        Remain_BangBangTang = Remain_BangBangTang - 1;
                    }
                    else if (radioButton8.Checked)
                    {
                        Remain_HaoLiYou = Remain_HaoLiYou - 1;
                    }
                    else if (radioButton9.Checked)
                    {
                        Remain_JianGuo = Remain_JianGuo - 1;
                    }
                    else if (radioButton10.Checked)
                    {
                        Remain_RuanTang = Remain_RuanTang - 1;
                    }
                    else if (radioButton11.Checked)
                    {
                        Remain_XingQiuBei = Remain_XingQiuBei - 1;
                    }
                    else if (radioButton12.Checked)
                    {
                        Remain_RouPu = Remain_RouPu - 1;
                    }
                    CleanSelect();
                    checkRemain();
                    panel1.Location = panel3.Location;
                    panel1.BringToFront();
                    stepIndex = 1;
                    break;
                default:
                    break;
            }
           
        }

        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {

        }

        public void writeLog(string content, params object[] logStringFormatArgs)
        {
            string line = string.Empty;

            const string LOG_DIR = "logs";
            string logFilePath = Path.Combine(LOG_DIR, DateTime.Now.ToString("yyyy-MM-dd") + ".log");
            if (!Directory.Exists(LOG_DIR)) Directory.CreateDirectory(LOG_DIR);
            line = string.IsNullOrWhiteSpace(content) ? "\r\n" : DateTime.Now.ToString("HH:mm:ss") + ": " + String.Format(content.TrimEnd(), logStringFormatArgs) + "\r\n";
            StreamWriter logFile = new StreamWriter(logFilePath, true, Encoding.UTF8);
            logFile.Write(line);
            logFile.Close();
            logFile.Dispose();

        }

        public void writeCSV(string Name, string QRCode)
        {
            string line = string.Empty;
            const string LOG_DIR = "logs";
            string csvFilePath = Path.Combine(LOG_DIR, DateTime.Now.ToString("yyyy-MM-dd") + ".csv");
            if (!Directory.Exists(LOG_DIR)) Directory.CreateDirectory(LOG_DIR);

            if (!File.Exists(csvFilePath))
            {
                //写入表头
                using (StreamWriter csvFile = new StreamWriter(csvFilePath, true, Encoding.UTF8))
                {
                    line = "Name,QRCode,Time(h:m:s)";
                    csvFile.WriteLine(line);
                }

            }
            
            using (StreamWriter csvFile = new StreamWriter(csvFilePath, true, Encoding.UTF8))
            {
                line = Name + "," + QRCode + "," + DateTime.Now.ToString("HH:mm:ss");                
                csvFile.WriteLine(line);
            }

        }

        public void CleanSelect()
        {
            textBox1.Text = "";
            radioButton1.Checked = false;
            radioButton2.Checked = false;
            radioButton3.Checked = false;
            radioButton4.Checked = false;
            radioButton5.Checked = false;
            radioButton6.Checked = false;
            radioButton7.Checked = false;
            radioButton8.Checked = false;
            radioButton9.Checked = false;
            radioButton10.Checked = false;
            radioButton11.Checked = false;
            radioButton12.Checked = false;
            ChildID++;
            str = ChildID.ToString().PadLeft(8, '0');
        }

        private void button1_Click(object sender, EventArgs e)
        {
            switch (stepIndex)
            {               
                case 2:                    
                    panel1.Location = panel2.Location;
                    panel1.BringToFront();
                    stepIndex = 1;
                    break;
                case 3:                    
                    panel2.Location = panel3.Location;
                    panel2.BringToFront();
                    stepIndex = 2;
                    break;
                default:
                    break;
            }
        }

        public void printCode()
        {
            //设置文档名
            printDocument1.DocumentName = textBox1.Text +" 签到卡";//设置完后可在打印对话框及队列中显示（默认显示document）
            printDocument1.Print(); //打印
        }

        private void printDocument1_PrintPage(object sender, PrintPageEventArgs e)
        {
            ShowCode(e.Graphics);
            Font printFont = new Font("MetaPlusLF", 15);
            e.Graphics.DrawString(textBox1.Text, printFont, Brushes.Black, 627, 715);//设置签名左上角的位置
        }

        private void ShowCode(Graphics g)
        {
            QrEncoder qrEncoder = new QrEncoder(ErrorCorrectionLevel.L);
            QrCode qrCode = qrEncoder.Encode(str);

            /*
             * FixedModuleSize---5-----165*165
             * FixedModuleSize---4-----132*132
             * FixedModuleSize---3-----99*99
             * FixedModuleSize---2-----66*66
             * FixedModuleSize---1-----33*33
             */
            FixedModuleSize moduleSize = new FixedModuleSize(4, QuietZoneModules.Two);
            GraphicsRenderer render = new GraphicsRenderer(moduleSize, Brushes.Black, Brushes.White);
            Point mP = new Point(627, 595);//设置二维码左上角的位置
            render.Draw(g, qrCode.Matrix, mP);
        }
    }
}
