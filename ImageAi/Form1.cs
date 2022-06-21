using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ImageAi.AI;

namespace ImageAi
{
    public partial class Form1 : Form
    {
        public string imagesPath;
        public string[] imagePaths;

        public string dataSetPath;
        public Form1()
        {
            InitializeComponent();
        }

        private void LoadImages_Click(object sender, EventArgs e)
        {
            ImagesFolder.ShowDialog();
            imagesPath = ImagesFolder.SelectedPath;
            imagePaths = ImageUtils.GetAllImagesInDirectoryRecursive(imagesPath);
        }

        private void LoadDataset_Click(object sender, EventArgs e)
        {
            SaveTrainData.ShowDialog();
        }

        private void TrainButton_Click(object sender, EventArgs e)
        {
            var file = dataSetPath;
            var stream = File.CreateText(file);
            Trainer.Train(imagePaths, stream, (int) RadiusAmount.Value);
        }

        private void SaveTrainData_FileOk(object sender, CancelEventArgs e)
        {
            dataSetPath = SaveTrainData.FileName;
        }

        private void GenerateButton_Click(object sender, EventArgs e)
        {
            PreviewBox.Image = Generator.Generate(dataSetPath, (int) StepCount.Value, (int) RadiusAmount.Value);
        }

        private void ResAmount_ValueChanged(object sender, EventArgs e)
        {
            ImageUtils.size = (int) ResAmount.Value;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            PreviewBox.Image = Generator.Step((Bitmap) PreviewBox.Image, dataSetPath, (int) RadiusAmount.Value);
        }
    }
}