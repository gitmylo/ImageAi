using System.Windows.Forms;

namespace ImageAi
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }

            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.PreviewBox = new System.Windows.Forms.PictureBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.ImagesFolder = new System.Windows.Forms.FolderBrowserDialog();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.RadiusAmount = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.ResAmount = new System.Windows.Forms.NumericUpDown();
            this.GenerateButton = new System.Windows.Forms.Button();
            this.LoadDataset = new System.Windows.Forms.Button();
            this.TrainButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.StepCount = new System.Windows.Forms.NumericUpDown();
            this.LoadImages = new System.Windows.Forms.Button();
            this.SaveTrainData = new System.Windows.Forms.SaveFileDialog();
            ((System.ComponentModel.ISupportInitialize) (this.PreviewBox)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize) (this.RadiusAmount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize) (this.ResAmount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize) (this.StepCount)).BeginInit();
            this.SuspendLayout();
            // 
            // PreviewBox
            // 
            this.PreviewBox.BackColor = System.Drawing.Color.Black;
            this.PreviewBox.Location = new System.Drawing.Point(12, 12);
            this.PreviewBox.Name = "PreviewBox";
            this.PreviewBox.Size = new System.Drawing.Size(150, 150);
            this.PreviewBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.PreviewBox.TabIndex = 0;
            this.PreviewBox.TabStop = false;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.RadiusAmount);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.ResAmount);
            this.groupBox1.Controls.Add(this.GenerateButton);
            this.groupBox1.Controls.Add(this.LoadDataset);
            this.groupBox1.Controls.Add(this.TrainButton);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.StepCount);
            this.groupBox1.Controls.Add(this.LoadImages);
            this.groupBox1.Location = new System.Drawing.Point(168, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(177, 172);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Actions";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(73, 143);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(48, 23);
            this.button1.TabIndex = 10;
            this.button1.Text = "Step";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(6, 102);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 20);
            this.label3.TabIndex = 9;
            this.label3.Text = "Rad";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // RadiusAmount
            // 
            this.RadiusAmount.Location = new System.Drawing.Point(56, 102);
            this.RadiusAmount.Maximum = new decimal(new int[] {10000, 0, 0, 0});
            this.RadiusAmount.Minimum = new decimal(new int[] {1, 0, 0, 0});
            this.RadiusAmount.Name = "RadiusAmount";
            this.RadiusAmount.Size = new System.Drawing.Size(115, 20);
            this.RadiusAmount.TabIndex = 8;
            this.RadiusAmount.Value = new decimal(new int[] {5, 0, 0, 0});
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(6, 76);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 20);
            this.label2.TabIndex = 7;
            this.label2.Text = "Res";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ResAmount
            // 
            this.ResAmount.Location = new System.Drawing.Point(56, 76);
            this.ResAmount.Maximum = new decimal(new int[] {10000, 0, 0, 0});
            this.ResAmount.Minimum = new decimal(new int[] {1, 0, 0, 0});
            this.ResAmount.Name = "ResAmount";
            this.ResAmount.Size = new System.Drawing.Size(115, 20);
            this.ResAmount.TabIndex = 6;
            this.ResAmount.Value = new decimal(new int[] {16, 0, 0, 0});
            this.ResAmount.ValueChanged += new System.EventHandler(this.ResAmount_ValueChanged);
            // 
            // GenerateButton
            // 
            this.GenerateButton.Location = new System.Drawing.Point(6, 143);
            this.GenerateButton.Name = "GenerateButton";
            this.GenerateButton.Size = new System.Drawing.Size(61, 23);
            this.GenerateButton.TabIndex = 5;
            this.GenerateButton.Text = "Generate";
            this.GenerateButton.UseVisualStyleBackColor = true;
            this.GenerateButton.Click += new System.EventHandler(this.GenerateButton_Click);
            // 
            // LoadDataset
            // 
            this.LoadDataset.Location = new System.Drawing.Point(92, 19);
            this.LoadDataset.Name = "LoadDataset";
            this.LoadDataset.Size = new System.Drawing.Size(79, 23);
            this.LoadDataset.TabIndex = 4;
            this.LoadDataset.Text = "Load Dataset";
            this.LoadDataset.UseVisualStyleBackColor = true;
            this.LoadDataset.Click += new System.EventHandler(this.LoadDataset_Click);
            // 
            // TrainButton
            // 
            this.TrainButton.Location = new System.Drawing.Point(127, 143);
            this.TrainButton.Name = "TrainButton";
            this.TrainButton.Size = new System.Drawing.Size(44, 23);
            this.TrainButton.TabIndex = 3;
            this.TrainButton.Text = "Train";
            this.TrainButton.UseVisualStyleBackColor = true;
            this.TrainButton.Click += new System.EventHandler(this.TrainButton_Click);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(6, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "Steps";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // StepCount
            // 
            this.StepCount.Location = new System.Drawing.Point(56, 50);
            this.StepCount.Maximum = new decimal(new int[] {10000, 0, 0, 0});
            this.StepCount.Minimum = new decimal(new int[] {1, 0, 0, 0});
            this.StepCount.Name = "StepCount";
            this.StepCount.Size = new System.Drawing.Size(115, 20);
            this.StepCount.TabIndex = 1;
            this.StepCount.Value = new decimal(new int[] {5, 0, 0, 0});
            // 
            // LoadImages
            // 
            this.LoadImages.Location = new System.Drawing.Point(6, 19);
            this.LoadImages.Name = "LoadImages";
            this.LoadImages.Size = new System.Drawing.Size(76, 23);
            this.LoadImages.TabIndex = 0;
            this.LoadImages.Text = "Load Images";
            this.LoadImages.UseVisualStyleBackColor = true;
            this.LoadImages.Click += new System.EventHandler(this.LoadImages_Click);
            // 
            // SaveTrainData
            // 
            this.SaveTrainData.FileName = "train.csv";
            this.SaveTrainData.Filter = "Data Files|*.csv";
            this.SaveTrainData.FileOk += new System.ComponentModel.CancelEventHandler(this.SaveTrainData_FileOk);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(364, 196);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.PreviewBox);
            this.Name = "Form1";
            this.Text = "Image AI";
            ((System.ComponentModel.ISupportInitialize) (this.PreviewBox)).EndInit();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize) (this.RadiusAmount)).EndInit();
            ((System.ComponentModel.ISupportInitialize) (this.ResAmount)).EndInit();
            ((System.ComponentModel.ISupportInitialize) (this.StepCount)).EndInit();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Button button1;

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown ResAmount;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown RadiusAmount;

        private System.Windows.Forms.NumericUpDown StepCount;

        private System.Windows.Forms.Button GenerateButton;

        private System.Windows.Forms.SaveFileDialog SaveTrainData;

        private System.Windows.Forms.Button TrainButton;
        private System.Windows.Forms.Button LoadDataset;

        private System.Windows.Forms.Label label1;

        private System.Windows.Forms.Button LoadImages;

        private System.Windows.Forms.FolderBrowserDialog ImagesFolder;
        private System.Windows.Forms.GroupBox groupBox1;

        private System.Windows.Forms.PictureBox PreviewBox;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;

        #endregion
    }
}