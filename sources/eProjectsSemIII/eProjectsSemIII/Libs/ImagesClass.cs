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

        public void ResizeAndCreateImage(string fileNameSave, int maxWidthSize)
        {
            int intNewWidth;
            int intNewHeight;
            System.Drawing.Image imgInput = System.Drawing.Image.FromStream(this.Images.InputStream);
            ImageCodecInfo myImageCodecInfo;
            myImageCodecInfo = GetEncoderInfo("image/jpeg");
            System.Drawing.Imaging.Encoder myEncoder = System.Drawing.Imaging.Encoder.Quality;
            EncoderParameters myEncoderParameters = new EncoderParameters(1);
            EncoderParameter myEncoderParameter;

            int intOldWidth = imgInput.Width;
            int intOldHeight = imgInput.Height;
            int intMaxSide;
            intMaxSide = intOldWidth;
            if (intMaxSide > maxWidthSize)
            {
                double dblCoef = maxWidthSize / (double)intMaxSide;
                intNewWidth = Convert.ToInt32(dblCoef * intOldWidth);
                intNewHeight = Convert.ToInt32(dblCoef * intOldHeight);
            }
            else
            {
                intNewWidth = intOldWidth;
                intNewHeight = intOldHeight;
            }
            Bitmap bmpResized = new Bitmap(imgInput, intNewWidth, intNewHeight);
            //Phần EncoderParameter cho phép bạn chỉnh chất lượng hình ảnh ở đây mình để chất lượng tốt //nhất là 100L;
            myEncoderParameter = new EncoderParameter(myEncoder, 100L);
            myEncoderParameters.Param[0] = myEncoderParameter;
            //Lưu ảnh;
            bmpResized.Save(fileNameSave, myImageCodecInfo, myEncoderParameters);

            //Giải phóng tài nguyên;
            //Buffer.Close();
            imgInput.Dispose();
            bmpResized.Dispose();
        }
        private ImageCodecInfo GetEncoderInfo(String mimeType)
        {
            int j;
            ImageCodecInfo[] encoders;
            encoders = ImageCodecInfo.GetImageEncoders();
            for (j = 0; j < encoders.Length; ++j)
            {
                if (encoders[j].MimeType == mimeType)
                    return encoders[j];
            }
            return null;
        }
    }
}