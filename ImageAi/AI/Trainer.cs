using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace ImageAi.AI
{
    public class Trainer
    {
        public static void Train(string[] images, StreamWriter fileStream, int radius)
        {
            //CSV data: r,g,b,colorRightR,colorRightG,colorRightB,ColorDownR,ColorDownG,ColorDownB,ColorLeftR,ColorLeftG,ColorLeftB,ColorUpR,ColorUpG,ColorUpB
            //Pixel data: r,g,b

            fileStream.Write("r,g,b,colorRightR,colorRightG,colorRightB,ColorDownR,ColorDownG,ColorDownB,ColorLeftR,ColorLeftG,ColorLeftB,ColorUpR,ColorUpG,ColorUpB");
            
            foreach (var imgString in images)
            {
                var img = new Bitmap(imgString);
                img = ImageUtils.SetupImage(img);
                int width = img.Width;
                int height = img.Height;
                for (int x = 0; x < width; x++)
                {
                    for (int y = 0; y < height; y++)
                    {
                        var pixel = img.GetPixel(x, y);
                        var avg = ImageUtils.GetAverageFromRadiusOnImage(img, x, y, radius);
                        //right down left up
                        fileStream.Write("\n" + pixel.R + "," + pixel.G + "," + pixel.B + ","
                                         + avg.ColorRight.R + "," + avg.ColorRight.G + "," + avg.ColorRight.B + ","
                                         + avg.ColorDown.R + "," + avg.ColorDown.G + "," + avg.ColorDown.B + ","
                                         + avg.ColorLeft.R + "," + avg.ColorLeft.G + "," + avg.ColorLeft.B + ","
                                         + avg.ColorUp.R + "," + avg.ColorUp.G + "," + avg.ColorUp.B);
                    }
                }
                img.Dispose();
            }
            
            fileStream.Close();
            MessageBox.Show("Done Training");
        }
    }
}