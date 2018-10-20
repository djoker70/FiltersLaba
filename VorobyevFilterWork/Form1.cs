using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VorobyevFilterWork.MathematicalMorphology;
using VorobyevFilterWork.MatrixFilters;
using VorobyevFilterWork.Other;
using VorobyevFilterWork.PointFilters;

namespace VorobyevFilterWork
{
    public partial class Form1 : Form
    {
        Bitmap image;

        protected bool[,] kernel = null;

        public Form1()
        {
            InitializeComponent();
        }

        public bool[,] getKernel()
        {
            return this.kernel;
        }

        public void setKernel(bool[,] kernelFoSet)
        {
            this.kernel = kernelFoSet;
        }

        private void открытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Image files | *.png; *.jpg; *.bmp | All Files(*.*) | *.*";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                image = new Bitmap(dialog.FileName);
                pictureBox1.Image = image;
                pictureBox1.Refresh();
            }
        }
        private void сохранитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "Jpeg Image|*.jpg|Bitmap Image|*.bmp|Gif Image|*.gif";
            saveFileDialog1.Title = "Сохранить изображение";
            saveFileDialog1.ShowDialog();

            if (saveFileDialog1.FileName != "")
            {
                FileStream fs = (FileStream)saveFileDialog1.OpenFile();

                switch (saveFileDialog1.FilterIndex)
                {
                    case 1:
                        this.pictureBox1.Image.Save(fs, ImageFormat.Jpeg);
                        break;
                    case 2:
                        this.pictureBox1.Image.Save(fs, ImageFormat.Bmp);
                        break;
                    case 3:
                        this.pictureBox1.Image.Save(fs, ImageFormat.Gif);
                        break;
                }
                fs.Close();
            }
        }

        private void инверсияToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InverterFilter filter = new InverterFilter();
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            Bitmap newImage = ((Filters)e.Argument).processImage(image, backgroundWorker1);
            if (backgroundWorker1.CancellationPending != true)
                image = newImage;
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (!e.Cancelled)
            {
                pictureBox1.Image = image;
                pictureBox1.Refresh();
            }
            progressBar1.Value = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            backgroundWorker1.CancelAsync();
        }

        private void размытиеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filters filter = new BlurFilter();
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void гаусToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filters filter = new GaussianFilter();
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void чернобелоеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GrayScaleFilter filter = new GrayScaleFilter();
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void сепияToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SepiaFilter filter = new SepiaFilter();
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void увеличениеЯркостиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            IncreaseBrightnessFilter filter = new IncreaseBrightnessFilter();
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void собельToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SobelFilter filter = new SobelFilter();
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void резкостьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HarshnessFilter filter = new HarshnessFilter();
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void смещениеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TransferFilter filter = new TransferFilter();
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void вращениеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RotationFilter filter = new RotationFilter();
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void волна1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            WaveOneFilter filter = new WaveOneFilter();
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void волна2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            WaveTwoFilter filter = new WaveTwoFilter();
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void стеклоToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GlassFilter filter = new GlassFilter();
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void motionBlurToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filters filter = new MotionBlurFilter();
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void резкостьToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Filters filter = new SharpnessFilter();
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void шарраToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ScharrFilter filter = new ScharrFilter();
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void прюиттаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PruittFilter filter = new PruittFilter();
            backgroundWorker1.RunWorkerAsync(filter);
        }
        
        private void расширениеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (kernel != null)
            {
                Dilation filter = new Dilation(kernel);
                backgroundWorker1.RunWorkerAsync(filter);
            } else
            {
                Dilation filter = new Dilation();
                backgroundWorker1.RunWorkerAsync(filter);
            }
        }

        private void сужениеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (kernel != null)
            {
                Erosion filter = new Erosion(kernel);
                backgroundWorker1.RunWorkerAsync(filter);
            }
            else
            {
                Erosion filter = new Erosion();
                backgroundWorker1.RunWorkerAsync(filter);
            }
        }

        private void открытиеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (kernel != null)
            {
                Opening filter = new Opening(kernel);
                backgroundWorker1.RunWorkerAsync(filter);
            }
            else
            {
                Opening filter = new Opening();
                backgroundWorker1.RunWorkerAsync(filter);
            }
        }

        private void закрытиеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (kernel != null)
            {
                Closing filter = new Closing(kernel);
                backgroundWorker1.RunWorkerAsync(filter);
            }
            else
            {
                Closing filter = new Closing();
                backgroundWorker1.RunWorkerAsync(filter);
            }
        }

        private void медианныйToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MedianFilter filter = new MedianFilter();
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void серыйМирToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GrayWorldFilter filter = new GrayWorldFilter();
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void blackHatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (kernel != null)
            {
                BlackHat filter = new BlackHat(kernel);
                backgroundWorker1.RunWorkerAsync(filter);
            }
            else
            {
                BlackHat filter = new BlackHat();
                backgroundWorker1.RunWorkerAsync(filter);
            }
        }

        private void задатьСтруктурныйЭлементToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form form2 = new Form2(this);
            form2.ShowDialog();
        }

        private void линейнаяКоррекцияToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LinearCorrection filter = new LinearCorrection();
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void тиснениеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StamplingFilter filter = new StamplingFilter();
            backgroundWorker1.RunWorkerAsync(filter);
        }

        private void коррекцияСОпорнымЦветомToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Color destColor = new Color();
            Random rnd = new Random();
            int randomWidth = rnd.Next(0, image.Width);
            int randomHeight = rnd.Next(0, image.Height);
            destColor = image.GetPixel(randomWidth, randomHeight);
            Bitmap tmpImg = new Bitmap(this.pictureBox2.Width, this.pictureBox2.Height);
            for (int i = 0; i < pictureBox2.Width; i++)
            {
                for (int j = 0; j < pictureBox2.Height; j++)
                {
                    tmpImg.SetPixel(i, j, destColor);
                }
            }
            this.pictureBox2.Image = tmpImg;
            this.pictureBox2.Refresh();
            referenceСolorСorrection filter = new referenceСolorСorrection(destColor);
            backgroundWorker1.RunWorkerAsync(filter);
        }
    }
}
