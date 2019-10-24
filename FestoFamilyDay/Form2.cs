using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Gma.QrCodeNet.Encoding;
using Gma.QrCodeNet.Encoding.Windows.Render;

namespace FestoFamilyDay
{
    public partial class Form2 : Form
    {
        string str;
        public Form2(string m)
        {
            str = m;
            InitializeComponent();
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            ShowCode(e.Graphics);
        }
        private void ShowCode(Graphics g)
        {
            QrEncoder qrEncoder = new QrEncoder(ErrorCorrectionLevel.L);
            QrCode qrCode = qrEncoder.Encode(str);

            FixedModuleSize moduleSize = new FixedModuleSize(2, QuietZoneModules.Two);
            GraphicsRenderer render = new GraphicsRenderer(moduleSize, Brushes.Black, Brushes.White);
            render.Draw(g, qrCode.Matrix);
        }

        private void btnSaveFile_Click(object sender, EventArgs e)
        {
            QrEncoder qrEncoder = new QrEncoder(ErrorCorrectionLevel.L);
            QrCode code = new QrCode();
            qrEncoder.TryEncode(str, out code);

            const int modelSizeInPixels = 4;

            GraphicsRenderer render = new GraphicsRenderer(
                new FixedModuleSize(modelSizeInPixels, QuietZoneModules.Two),
                Brushes.Black,
                Brushes.White);

            string fileName = Application.ExecutablePath + "New.png";

            using (FileStream stream = new FileStream(fileName, FileMode.Create))
            {
                render.WriteToStream(code.Matrix, System.Drawing.Imaging.ImageFormat.Png, stream);
            }
        }
    }
}
