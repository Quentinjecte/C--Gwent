﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Linq;
using System.Reflection.Emit;
using System.Reflection.Metadata;
using System.Runtime.InteropServices.Marshalling;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;
using System.Reflection;

namespace C__GC
{

    internal class MapParser
    {
        public string ParseBitmap(string path, int width)
        {
            Bitmap img = null;
            img = Load(path);
            if (img == null) { return null; };
            img = ResizeImg(img, width);
            string str = BitmapToStr(img);
            str = str.Replace("&nbsp;", " ").Replace("<BR>", "\n");
            return str;
        }

        private string BitmapToStr(Bitmap image)
        {
            Boolean toggle = false;
            StringBuilder sb = new StringBuilder();
            for (int h = 0; h < image.Height; h++)
            {
                for (int w = 0; w < image.Width; w++)
                {
                    Color pixelColor = image.GetPixel(w, h);
                    //Average out the RGB components to find the Gray Color
                    int red = (pixelColor.R + pixelColor.G + pixelColor.B) / 3;
                    int green = (pixelColor.R + pixelColor.G + pixelColor.B) / 3;
                    int blue = (pixelColor.R + pixelColor.G + pixelColor.B) / 3;
                    Color grayColor = Color.FromArgb(red, green, blue);
                    //Use the toggle flag to minimize height-wise stretch
                    if (!toggle)
                    {
                        int index = (grayColor.R * 10) / 255;
                        sb.Append(_AsciiChars[index]);
                        if (_AsciiChars[index] == "#")
                        {
                            TileTypes.Grass.Render();
                        }
                        if (_AsciiChars[index] == "%")
                        {
                            TileTypes.Dirts.Render();
                        }
                        else if (_AsciiChars[index] == " ")
                        {
                            TileTypes.Water.Render();
                        }
                        else if (_AsciiChars[index] == "@")
                        {
                            TileTypes.Rock.Render();
                        }
                    }
                }
                if (!toggle)
                {
                    sb.Append("<BR>");
                    toggle = true;
                }
                else
                {
                    toggle = false;
                }
            }
            return sb.ToString();
        }

        private string[] _AsciiChars = { "#", "#", "@", "%", "=", "+", "*", ":", "-", ".", "&nbsp;" };

        private Bitmap Load(string path)
        {
            Bitmap img = null;
            try
            {
                // Retrieve the image.
                img = new Bitmap(path, true);

                int x, y;

                // Loop through the images pixels to reset color.
                for (x = 0; x < img.Width; x++)
                {
                    for (y = 0; y < img.Height; y++)
                    {
                        Color pixelColor = img.GetPixel(x, y);
                        Color newColor = Color.FromArgb(pixelColor.R, 0, 0);
                        img.SetPixel(x, y, newColor);
                    }
                }
                return img;
            }
            catch (ArgumentException)
            {
                Console.WriteLine("There was an error." +
                    "Check the path to the image file.");
            }
            return null;
        }
        private Bitmap ResizeImg(Bitmap inputBitmap, int asciiWidth)
        {
            //int asciiWidth = 100;
            int asciiHeight = 0;
            //Calculate the new Height of the image from its width
            asciiHeight = (int)Math.Ceiling((double)inputBitmap.Height * asciiWidth / inputBitmap.Width);
            //Create a new Bitmap and define its resolution
            Bitmap result = new Bitmap(asciiWidth, asciiHeight);
            Graphics g = Graphics.FromImage((System.Drawing.Image)result);
            //The interpolation mode produces high quality images
            g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
            g.DrawImage(inputBitmap, 0, 0, asciiWidth, asciiHeight);
            g.Dispose();
            return result;
        }

    }

    public class Tile
    {

    }

    public class TileTypes
    {
        public static readonly TileType Water;
        public static readonly TileType Grass;
        public static readonly TileType Dirts;
        public static readonly TileType Rock;

        static TileTypes()
        {
            Water = new TileType("Water", ConsoleColor.Black, ConsoleColor.Black, " ");
            Grass = new TileType("Grass", ConsoleColor.DarkGreen, ConsoleColor.DarkGreen, "#");
            Dirts = new TileType("Dirts", ConsoleColor.DarkGray, ConsoleColor.DarkGray, "%");
            Rock = new TileType("Rock", ConsoleColor.Gray, ConsoleColor.Gray, "@");
        }
    }

    public class TileType
    {
        public string Name { get; set; }
        public ConsoleColor BackColor { get; set; }

        public ConsoleColor ForeColor { get; set; }

        public string RenderString { get; set; }

        public TileType(string name,
            ConsoleColor backColor,
            ConsoleColor foreColor,
            string renderString)
        {
            this.Name = name;
            this.BackColor = backColor;
            this.ForeColor = foreColor;
            this.RenderString = renderString;
        }

        public void Render()
        {
            Console.BackgroundColor = BackColor;
            Console.ForegroundColor = ForeColor;
            Console.Write(RenderString);
        }
    }

}
