using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Drawing;
using System.IO;
using System.Drawing.Imaging;

namespace eProjectsSemIII.Libs
{
    public class ImagesClass
    {
        private HttpPostedFileBase Images;
        public ImagesClass(HttpPostedFileBase Images)
        {
            this.Images = Images;
        }
        public void CreateNewImage(string fileSaveName, int width, int height)
        {
            Bitmap bmpOut = new Bitmap(width, height);
            Graphics g = Graphics.FromImage(bmpOut);
            g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
            g.FillRectangle(Brushes.White, 0, 0, width, height);
            g.DrawImage(new Bitmap(this.Images.InputStream), 0, 0, width, height);
            MemoryStream stream = new MemoryStream();
            bmpOut.Save(stream, ImageFormat.Jpeg);
            bmpOut.Save(fileSaveName);
        }
    }
}