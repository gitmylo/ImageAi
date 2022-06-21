using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;

namespace ImageAi.AI
{
    public class Reader
    {
        public static List<LineData> data;
        private static string lastPath;
        public static void Read(string path, Action<LineData> dataCallback)
        {
            if (path != lastPath)
            {
                data = new List<LineData>();
                var stream = File.OpenText(path);
                stream.ReadLine();
                while (!stream.EndOfStream)
                {
                    var line = stream.ReadLine();
                    var dataPiece = LineData.parse(line);
                    data.Add(dataPiece);
                    dataCallback(dataPiece);
                }
                stream.Close();
            }
            else
            {
                foreach (var dataPiece in data)
                {
                    dataCallback(dataPiece);
                }
            }
        }

        public static List<LineData> readAndGetLineData(string path)
        {
            if (path != lastPath)
            {
                data = new List<LineData>();
                var stream = File.OpenText(path);
                stream.ReadLine();
                while (!stream.EndOfStream)
                {
                    var line = stream.ReadLine();
                    var dataPiece = LineData.parse(line);
                    data.Add(dataPiece);
                }
                stream.Close();
            }

            return data;
        }
    }

    public class LineData
    {
        //CSV data: r,g,b,colorRightR,colorRightG,colorRightB,ColorDownR,ColorDownG,ColorDownB,ColorLeftR,ColorLeftG,ColorLeftB,ColorUpR,ColorUpG,ColorUpB
        
        
        public Color color;
        public Color colorRight;
        public Color colorDown;
        public Color colorLeft;
        public Color colorUp;
        
        public static LineData parse(string csvLine)
        {
            var data = csvLine.Split(',');
            var lineData = new LineData()
            {
                color = Color.FromArgb(int.Parse(data[0]), int.Parse(data[1]), int.Parse(data[2])),
                colorRight = Color.FromArgb(int.Parse(data[3]), int.Parse(data[4]), int.Parse(data[5])),
                colorDown = Color.FromArgb(int.Parse(data[6]), int.Parse(data[7]), int.Parse(data[8])),
                colorLeft = Color.FromArgb(int.Parse(data[9]), int.Parse(data[10]), int.Parse(data[11])),
                colorUp = Color.FromArgb(int.Parse(data[12]), int.Parse(data[13]), int.Parse(data[14]))
            };
            return lineData;
        }
    }
}