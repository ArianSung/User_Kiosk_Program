using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace User_Kiosk_Program
{
    public static class ImageHelper
    {
        public static Bitmap ResizeImage(Image sourceImage, Size targetSize)
        {
            if (sourceImage == null || targetSize.Width <= 0 || targetSize.Height <= 0)
            {
                return new Bitmap(targetSize.Width > 0 ? targetSize.Width : 1,
                                  targetSize.Height > 0 ? targetSize.Height : 1);
            }

            var resultBitmap = new Bitmap(targetSize.Width, targetSize.Height, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
            resultBitmap.SetResolution(sourceImage.HorizontalResolution, sourceImage.VerticalResolution);

            using (var g = Graphics.FromImage(resultBitmap))
            {
                g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                float sourceRatio = (float)sourceImage.Width / sourceImage.Height;
                float targetRatio = (float)targetSize.Width / targetSize.Height;
                float scaleWidth, scaleHeight;

                if (sourceRatio > targetRatio)
                {
                    scaleWidth = targetSize.Width;
                    scaleHeight = targetSize.Width / sourceRatio;
                }
                else
                {
                    scaleHeight = targetSize.Height;
                    scaleWidth = targetSize.Height * sourceRatio;
                }

                float posX = (targetSize.Width - scaleWidth) / 2;
                float posY = (targetSize.Height - scaleHeight) / 2;
                g.DrawImage(sourceImage, posX, posY, scaleWidth, scaleHeight);
            }
            return resultBitmap;
        }
    }
}
