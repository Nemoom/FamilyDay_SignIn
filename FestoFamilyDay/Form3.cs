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
using System.Drawing.Printing;

namespace FestoFamilyDay
{
    public partial class Form3 : Form
    {
        string str;
        public Form3(string m)
        {
            str = m;
            InitializeComponent();
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {            
            ShowCode(e.Graphics);
            Font printFont = new Font("MetaPlusLF", 15);
            e.Graphics.DrawString("John", printFont, Brushes.Black, 627, 715);//设置签名左上角的位置
        }
        private void ShowCode(Graphics g)
        {
            QrEncoder qrEncoder = new QrEncoder(ErrorCorrectionLevel.L);
            QrCode qrCode = qrEncoder.Encode(str);

            FixedModuleSize moduleSize = new FixedModuleSize(4, QuietZoneModules.Two);
            GraphicsRenderer render = new GraphicsRenderer(moduleSize, Brushes.Black, Brushes.White);
            Point mP = new Point(627,595);//设置二维码左上角的位置
            render.Draw(g, qrCode.Matrix,mP);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //printDocument.PrinterSettings可以获取或设置计算机默认打印相关属性或参数，如：printDocument.PrinterSettings.PrinterName获得默认打印机打印机名称
            //printDocument.DefaultPageSettings //可以获取或设置打印页面参数信息、如是纸张大小，是否横向打印等

            //设置文档名
            printDocument1.DocumentName = "签到卡";//设置完后可在打印对话框及队列中显示（默认显示document）
            
            //printDocument1.Print(); //打印

            //设置纸张大小（可以不设置取，取默认设置）
            PaperSize ps = new PaperSize("Your Paper Name", 100, 70);
            ps.RawKind = 9; //如果是自定义纸张，就要大于118，（A4值为9，详细纸张类型与值的对照请看http://msdn.microsoft.com/zh-tw/library/system.drawing.printing.papersize.rawkind(v=vs.85).aspx）
            printDocument1.DefaultPageSettings.PaperSize = ps;

            ////打印开始前
            //printDocument.BeginPrint += new PrintEventHandler(printDocument_BeginPrint);
            ////打印输出（过程）
            //printDocument.PrintPage += new PrintPageEventHandler(printDocument_PrintPage);
            ////打印结束
            //printDocument.EndPrint += new PrintEventHandler(printDocument_EndPrint);

            ////跳出打印对话框，提供打印参数可视化设置，如选择哪个打印机打印此文档等
            //PrintDialog pd = new PrintDialog();
            //pd.Document = printDocument1;
            //if (DialogResult.OK == pd.ShowDialog()) //如果确认，将会覆盖所有的打印参数设置
            //{
            //页面设置对话框（可以不使用，其实PrintDialog对话框已提供页面设置）
            PageSetupDialog psd = new PageSetupDialog();
            psd.Document = printDocument1;
            psd.EnableMetric = true;
            if (DialogResult.OK == psd.ShowDialog())
            {
                //printDocument1.Print(); //打印
                //打印预览
                PrintPreviewDialog ppd = new PrintPreviewDialog();
                ppd.Document = printDocument1;
                if (DialogResult.OK == ppd.ShowDialog())
                    printDocument1.Print(); //打印

            }
            //}
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            button1_Click(sender, e);
        }
    }
}
