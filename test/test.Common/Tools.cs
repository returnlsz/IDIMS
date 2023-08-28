using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;

namespace test.Common
{
    public class Tools
    {
        public static string CreateValidateString()
        {
            string chars = "abcdefghijklmnopqrstuvwxyz";
            Random r = new(DateTime.Now.Millisecond);
            string validatestring = "";
            int length = 4;
            for (int i = 0;i<length;i++)
            {
                validatestring += chars[r.Next(chars.Length)];
            }
            return validatestring;
        }

        public static Byte[] CreateValidateCodeBuffer(string validatecode)
        {
            Bitmap bitmap = new(200, 60);

            Graphics g = Graphics.FromImage(bitmap);
            g.Clear(Color.White);

            Font font = new("微软雅黑", 12, FontStyle.Bold | FontStyle.Italic);
            var size = g.MeasureString(validatecode, font);

            Bitmap bitmaptext = new(Convert.ToInt32(Math.Ceiling(size.Width)), Convert.ToInt32(Math.Ceiling(size.Height)));
            Graphics gtext = Graphics.FromImage(bitmaptext);

            RectangleF rf = new(0, 0, bitmap.Width, bitmap.Height);
            LinearGradientBrush brush = new(rf, Color.Red, Color.DarkBlue, 1.2f, true);

            gtext.DrawString(validatecode, font, brush, 0, 0);

            g.DrawImage(bitmaptext, 10, 10, 190, 50);

            MemoryStream memoryStream = new();
            bitmap.Save(memoryStream, ImageFormat.Jpeg);

            return memoryStream.ToArray();
        }
    }
}
