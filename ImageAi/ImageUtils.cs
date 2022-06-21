using System;
using System.Drawing;
using System.Linq;

namespace ImageAi
{
    public static class ImageUtils
    {
        public static int size = 16;

        public static Bitmap PadImage(Bitmap originalImage)
        {
            int largestDimension = Math.Max(originalImage.Height, originalImage.Width);
            Size squareSize = new Size(largestDimension, largestDimension);
            Bitmap squareImage = new Bitmap(squareSize.Width, squareSize.Height);
            using (Graphics graphics = Graphics.FromImage(squareImage))
            {
                graphics.FillRectangle(Brushes.Black, 0, 0, squareSize.Width, squareSize.Height);
                graphics.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
                graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;

                graphics.DrawImage(originalImage, (squareSize.Width / 2) - (originalImage.Width / 2),
                    (squareSize.Height / 2) - (originalImage.Height / 2), originalImage.Width, originalImage.Height);
            }

            return squareImage;
        }

        public static Bitmap ResizeImage(Bitmap originalImage)
        {
            Bitmap resizedImage = new Bitmap(size, size);
            using (Graphics graphics = Graphics.FromImage(resizedImage))
            {
                graphics.FillRectangle(Brushes.White, 0, 0, size, size);
                graphics.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
                graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;

                graphics.DrawImage(originalImage, 0, 0, size, size);
            }

            return resizedImage;
        }

        public static Bitmap SetupImage(Bitmap image)
        {
            return ResizeImage(PadImage(image));
        }

        public static string[] GetAllImagesInDirectoryRecursive(string directory)
        {
            string[] files = System.IO.Directory.GetFiles(directory);
            string[] directories = System.IO.Directory.GetDirectories(directory);
            foreach (string d in directories)
            {
                string[] moreFiles = GetAllImagesInDirectoryRecursive(d);
                files = files.Concat(moreFiles).ToArray();
            }

            return files;
        }

        public static Bitmap GenerateRandomImage()
        {
            int width = size;
            int height = size;
            Random r = new Random();
            Bitmap image = new Bitmap(width, height);

            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    Color color = Color.FromArgb(r.Next(256), r.Next(256), r.Next(256));
                    image.SetPixel(x, y, color);
                }
            }

            return image;
        }

        public static ColorDirection GetAverageFromRadiusOnImage(Bitmap image, int x, int y, int radius)
        {
            var cd = new ColorDirection();
            //k = 0 -> right, k = 1 -> down, k = 2 -> left, k = 3 -> up
            //Get the average color of the pixels in the radius from the center pixel (x, y)
            avgPerColor avg = new avgPerColor();
            for (int i = -radius; i <= radius; i++)
            {
                for (int j = -radius; j <= radius; j++)
                {
                    if (x + i >= 0 && x + i < image.Width && y + j >= 0 && y + j < image.Height)
                    {
                        //check if the pixel is within the radius
                        if (i * i + j * j <= radius * radius)
                        {
                            //check if the pixel is in the right direction
                            if (x + i > x) // right
                            {
                                Color color = image.GetPixel(x + i, y + j);
                                avg.right.red += color.R;
                                avg.right.green += color.G;
                                avg.right.blue += color.B;
                                avg.right.count++;
                            }
                            if (y + j > y) // down
                            {
                                Color color = image.GetPixel(x + i, y + j);
                                avg.down.red += color.R;
                                avg.down.green += color.G;
                                avg.down.blue += color.B;
                                avg.down.count++;
                            }
                            if (x + i < x) // left
                            {
                                Color color = image.GetPixel(x + i, y + j);
                                avg.left.red += color.R;
                                avg.left.green += color.G;
                                avg.left.blue += color.B;
                                avg.left.count++;
                            }
                            if (y + j < y) // up
                            {
                                Color color = image.GetPixel(x + i, y + j);
                                avg.up.red += color.R;
                                avg.up.green += color.G;
                                avg.up.blue += color.B;
                                avg.up.count++;
                            }
                        }
                    }
                }
                
            }
            
            if (avg.right.count == 0) avg.right.count = 1;
            if (avg.down.count == 0) avg.down.count = 1;
            if (avg.left.count == 0) avg.left.count = 1;
            if (avg.up.count == 0) avg.up.count = 1;
            
            cd.ColorRight = Color.FromArgb(avg.right.red / avg.right.count, avg.right.green / avg.right.count, avg.right.blue / avg.right.count);
            cd.ColorDown = Color.FromArgb(avg.down.red / avg.down.count, avg.down.green / avg.down.count, avg.down.blue / avg.down.count);
            cd.ColorLeft = Color.FromArgb(avg.left.red / avg.left.count, avg.left.green / avg.left.count, avg.left.blue / avg.left.count);
            cd.ColorUp = Color.FromArgb(avg.up.red / avg.up.count, avg.up.green / avg.up.count, avg.up.blue / avg.up.count);

            return cd;
        }

        public static Bitmap Blur(Bitmap image, int radius)
        {
            Bitmap blurredImage = new Bitmap(image.Width, image.Height);
            for (int x = 0; x < image.Width; x++)
            {
                for (int y = 0; y < image.Height; y++)
                {
                    Color
                        color = Color
                            .Transparent; //disabled right now //GetAverageFromRadiusOnImage(image, x, y, radius);
                    blurredImage.SetPixel(x, y, color);
                }
            }

            return blurredImage;
        }

        public static int GetCloseNessToColor(Color color, Color color2)
        {
            int red = Math.Abs(color.R - color2.R);
            int green = Math.Abs(color.G - color2.G);
            int blue = Math.Abs(color.B - color2.B);
            return red + green + blue;
        }
    }

    public class ColorDirection
    {
        public Color ColorLeft;
        public Color ColorRight;
        public Color ColorUp;
        public Color ColorDown;
    }

    public class avgPerColor
    {
        public avgColor left = new avgColor()
            , right = new avgColor()
            , up = new avgColor(), 
            down = new avgColor();
    }

    public class avgColor
    {
        public int red, green, blue, count;
    }
}