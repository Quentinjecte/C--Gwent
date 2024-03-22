using System;
using System.Drawing;
using System.Text;

namespace C__GC
{
    internal class MapParser
    {
        private const string DefaultAsciiChars = "#@%=&*:-. ";
        private string _asciiChars;

        public MapParser(string asciiChars = DefaultAsciiChars)
        {
            _asciiChars = asciiChars;
        }

        public string ParseBitmap(Bitmap image, int width)
        {
            if (image == null)
            {
                throw new ArgumentNullException(nameof(image));
            }

            Bitmap resizedImage = ResizeImg(image, width);
            string asciiMap = BitmapToStr(resizedImage);
            return asciiMap;
        }

        private string BitmapToStr(Bitmap image)
        {
            StringBuilder sb = new StringBuilder();
            for (int h = 0; h < image.Height; h++)
            {
                for (int w = 0; w < image.Width; w++)
                {
                    Color pixelColor = image.GetPixel(w, h);
                    int index = (int)(pixelColor.GetBrightness() * (_asciiChars.Length - 1));
                    sb.Append(_asciiChars[index]);
                }
                sb.AppendLine();
            }
            return sb.ToString();
        }

        internal Bitmap Load(string path)
        {
            Bitmap img = null;
            try
            {
                img = new Bitmap(path, true);
            }
            catch (ArgumentException)
            {
                Console.WriteLine("There was an error. Check the path to the image file.");
            }
            return img;
        }

        private Bitmap ResizeImg(Bitmap inputBitmap, int asciiWidth)
        {
            int asciiHeight = (int)Math.Ceiling((double)inputBitmap.Height * asciiWidth / inputBitmap.Width);
            Bitmap result = new Bitmap(asciiWidth, asciiHeight);
            using (Graphics g = Graphics.FromImage(result))
            {
                g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                g.DrawImage(inputBitmap, 0, 0, asciiWidth, asciiHeight);
            }
            return result;
        }
    }
}
