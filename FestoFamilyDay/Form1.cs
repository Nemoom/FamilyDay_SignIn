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

namespace FestoFamilyDay
{
    public partial class Form1 : Form
    {
        int stepIndex = 0;//签名登记进行到第几步，panel N置于最顶层。打印完成panel置顶，stepIndex=1
        int ChildID = 1;//每打印一张加1
        string str = "";//每个签到人员的唯一8位编号， 
        public Form1()
        {
            InitializeComponent();
            panel1.BringToFront();
            stepIndex = 1;
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
                        else if (radioButton2.Checked)
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
                        if (radioButton1.Checked)
                        {
                            str = "01"+ str.Substring(2);
                        }
                        else if (radioButton2.Checked)
                        {
                            str = "02" + str.Substring(2);
                        }
                        else if (radioButton2.Checked)
                        {
                            str = "03" + str.Substring(2);
                        }
                        else if (radioButton4.Checked)
                        {
                            str = "04" + str.Substring(2);
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
                        if (radioButton5.Checked)
                        {
                            str = str.Substring(0, 2) + "01" + str.Substring(2);
                        }
                        else if (radioButton6.Checked)
                        {
                            str = str.Substring(0, 2) + "02" + str.Substring(2);
                        }
                        else if (radioButton7.Checked)
                        {
                            str = str.Substring(0, 2) + "03" + str.Substring(2);
                        }
                        else if (radioButton8.Checked)
                        {
                            str = str.Substring(0, 2) + "04" + str.Substring(2);
                        }
                        else if (radioButton9.Checked)
                        {
                            str = str.Substring(0, 2) + "05" + str.Substring(2);
                        }
                        else if (radioButton10.Checked)
                        {
                            str = str.Substring(0, 2) + "06" + str.Substring(2);
                        }
                        else if (radioButton11.Checked)
                        {
                            str = str.Substring(0, 2) + "07" + str.Substring(2);
                        }
                        else if (radioButton12.Checked)
                        {
                            str = str.Substring(0, 2) + "08" + str.Substring(2);
                        }
                        else
                        {
                            if (MessageBox.Show("No gift?", "Confirm", MessageBoxButtons.OKCancel) == DialogResult.OK)
                            {
                                str = str.Substring(0, 2) + "00" + str.Substring(2);
                            }                            
                        }
                    }
                    
                    Form3 f3 = new Form3(str);
                    f3.Show();
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
    }
}
