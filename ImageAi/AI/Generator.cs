using System;
using System.Drawing;
using System.Threading;

namespace ImageAi.AI
{
    public class Generator
    {
        public static Bitmap Generate(string modelPath, int stepCount = 10, int radius = 5)
        {
            var bitmap = ImageUtils.GenerateRandomImage();
            for (int i = 0; i < stepCount; i++) {
                bitmap = Step(bitmap, modelPath, radius);
            }

            return bitmap;
        }

        public static Bitmap Step(Bitmap input, string modelPath, int radius)
        {
            Bitmap original = input;
            int width = original.Width;
            int height = original.Height;
            
            Bitmap output = (Bitmap) original.Clone();
            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    var pixel = original.GetPixel(x, y);
                    var avgFromRadius = ImageUtils.GetAverageFromRadiusOnImage(original, x, y, radius);
                    Color closest = Color.Black;
                    int closestDistance = -1;

                    foreach (var data in Reader.readAndGetLineData(modelPath))
                    {
                        int closeNess = ImageUtils.GetCloseNessToColor(data.colorLeft, avgFromRadius.ColorLeft);
                        closeNess += ImageUtils.GetCloseNessToColor(data.colorRight, avgFromRadius.ColorRight);
                        closeNess += ImageUtils.GetCloseNessToColor(data.colorUp, avgFromRadius.ColorUp);
                        closeNess += ImageUtils.GetCloseNessToColor(data.colorDown, avgFromRadius.ColorDown);
                        if (closestDistance == -1 || closeNess < closestDistance)
                        {
                            closest = data.color;
                            closestDistance = closeNess;
                        }
                    }
                    Console.WriteLine("Pixel: " + x + " " + y + " " + closest);
                    output.SetPixel(x, y, closest);
                }
            }
            
            original.Dispose();

            return output;
        }
    }
}