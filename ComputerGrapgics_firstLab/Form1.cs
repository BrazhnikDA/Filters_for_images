using ComputerGraphics_firstLab.allFilters;
using ComputerGraphics_firstLab.allFilters.PointsFilters;
using ComputerGraphics_firstLab.allFilters.MatrixFilters;
using ComputerGraphics_firstLab.allFilters.ColorBalance;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;
using ComputerGraphics_firstLab.allFilters.MatrixFilters.Mat_morphology;

namespace ComputerGraphics_firstLab
{
    public partial class Form1 : Form
    {
        Stack<Bitmap> historyChangeBack = new Stack<Bitmap>();          // История измений изображения
        Stack<Bitmap> historyChangeForward = new Stack<Bitmap>();       // Вернуть картинку после шага назад, на шаг вперёд
        bool IsSaved = true;               // Сохранена ли картинка после изменений
        Bitmap image;                      // Загруженное изображение 

        SettingsMathMorphology settings; 
        public Form1()
        {
            InitializeComponent();
            settings = new SettingsMathMorphology();
        }

        private void открытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (IsSaved)
            {
                OpenImage();
                labelSizeImage.Text = "Size: " + image.Width.ToString() + "-" + image.Height.ToString(); 
            }
            else
            {
                DialogResult result = MessageBox.Show("Действительно открыть? Если Вы нажмете 'Да' то все изменения могут быть утерянны ", "Выход из программы", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.No)
                {

                }
                if (result == DialogResult.Yes)
                {
                    OpenImage();   
                }
            } 
        }

        private void сохранитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (mainPicture.Image != null)
            {
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Title = "Сохранить картинку как...";
                sfd.OverwritePrompt = true;
                sfd.CheckPathExists = true;
                sfd.Filter = "Image Files(*.jpg)|*.JPG|Image Files(*.png)|*.PNG|Image Files(*.bmp)|*.BMP|All files(*.*)|*.*";
                sfd.ShowHelp = true;

                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        mainPicture.Image.Save(sfd.FileName);
                        IsSaved = true; // Изображение сохранено
                    }
                    catch
                    {
                        MessageBox.Show("Ошибка с файлом");
                    }
                }
            }
        }

        private void OpenImage()
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Image files|*.png;*.jpg;*.bmp|All files(*.*)|*.*";

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                image = new Bitmap(dialog.FileName);
                mainPicture.Image = image;
                mainPicture.Refresh();
                IsSaved = true;
            }
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (IsSaved)
            {
                this.Close();
            }
            else
            {
                DialogResult result = MessageBox.Show("Действительно выйти? Если Вы нажмете 'Да' то все изменения будут утерянны ", "Выход из программы", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.No)
                {

                }
                if (result == DialogResult.Yes)
                {
                    Application.Exit();
                }
            }
        }

        private void инверсияToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filters filter = new InvertFilter();
            backgroundWorker1.RunWorkerAsync(filter);
            historyChangeBack.Push(image);
        }     

        private void размытиеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filters filter = new BlurFilter();
            backgroundWorker1.RunWorkerAsync(filter);
            historyChangeBack.Push(image);
        }

        private void полутоновыйToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filters filter = new GrayScaleFilter();
            backgroundWorker1.RunWorkerAsync(filter);
            historyChangeBack.Push(image);
        }

        private void сепияToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filters filter = new SepiaFilter();
            backgroundWorker1.RunWorkerAsync(filter);
            historyChangeBack.Push(image);
        }

        private void яркостьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filters filter = new BrightnessFilter();
            backgroundWorker1.RunWorkerAsync(filter);
            historyChangeBack.Push(image);
        }

        private void растяжениеГистограммыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filters filter = new LinearStretchingHistogram();
            backgroundWorker1.RunWorkerAsync(filter);
            historyChangeBack.Push(image);
        }

        private void гауссаРазмытиеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filters filter = new GaussFilter();
            backgroundWorker1.RunWorkerAsync(filter);
            historyChangeBack.Push(image);
        }

        private void серыйМирToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filters filter = new GreyWorld();
            backgroundWorker1.RunWorkerAsync(filter);
            historyChangeBack.Push(image);
        }

        private void волна60ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filters filter = new Waves60Filter();
            backgroundWorker1.RunWorkerAsync(filter);
            historyChangeBack.Push(image);
        }

        private void волна30ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filters filter = new Waves30Filter();
            backgroundWorker1.RunWorkerAsync(filter);
            historyChangeBack.Push(image);
        }


        private void перенос50ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filters filter = new TransferFilter();
            backgroundWorker1.RunWorkerAsync(filter);
            historyChangeBack.Push(image);
        }

        private void поворотToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filters filter = new RotateFilter();
            backgroundWorker1.RunWorkerAsync(filter);
            historyChangeBack.Push(image);
        }

        private void стеклоToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filters filter = new GlassFilter();
            backgroundWorker1.RunWorkerAsync(filter);
            historyChangeBack.Push(image);
        }

        private void зеркалоToolStripMenuItem_Click(object sender, EventArgs e)
        {
            historyChangeBack.Push(image);
            Bitmap temp = image;
            Bitmap bmap = (Bitmap)temp.Clone();
            bmap.RotateFlip(RotateFlipType.Rotate180FlipY);
            image = (Bitmap)bmap.Clone();

            mainPicture.Image = image;
            mainPicture.Refresh();

            IsSaved = false;
        }

        private void медианныйФильтрToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Filters filter = new MedianFilter(4);
            backgroundWorker1.RunWorkerAsync(filter);
            historyChangeBack.Push(image);
        }

        private void резкостьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filters filter = new SharpnessFilter();
            backgroundWorker1.RunWorkerAsync(filter);
            historyChangeBack.Push(image);
        }

        private void повыситьРезкостьэToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filters filter = new SharpeningFilter();
            backgroundWorker1.RunWorkerAsync(filter);
            historyChangeBack.Push(image);
        }

        private void размытиеВДвиженииToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filters filter = new MotionBlurFilter();
            backgroundWorker1.RunWorkerAsync(filter);
            historyChangeBack.Push(image);
        }

        private void dilationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            /*Dilatation filter = new Dilatation();
            mainPicture.Image = filter.Apply(image); 
            mainPicture.Refresh();
            */
            Filters filter = new Dilation(settings.Size);
            backgroundWorker1.RunWorkerAsync(filter);
            historyChangeBack.Push(image);
        }


        private void erosionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filters filter = new Erosion(settings.Size);
            backgroundWorker1.RunWorkerAsync(filter);
            historyChangeBack.Push(image);
        }
        private void каналRToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filters filter = new R();
            backgroundWorker1.RunWorkerAsync(filter);
            historyChangeBack.Push(image);
        }

        private void каналGToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filters filter = new G();
            backgroundWorker1.RunWorkerAsync(filter);
            historyChangeBack.Push(image);
        }

        private void каналBToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Filters filter = new B();
            backgroundWorker1.RunWorkerAsync(filter);
            historyChangeBack.Push(image);
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            Bitmap newImage = ((Filters)e.Argument).processImage(image, backgroundWorker1);
            if (backgroundWorker1.CancellationPending != true)
            {
                image = newImage;
                IsSaved = false;    // Фильтр отработал, измениения не сохранены 
            }
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;
            Text = "Обработка изображений " + (progressBar1.Value + 1).ToString() + "%";
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (!e.Cancelled)
            {
                mainPicture.Image = image;
                mainPicture.Refresh();
            }
            progressBar1.Value = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            backgroundWorker1.CancelAsync();
        }

        private void buttonBack_Click(object sender, EventArgs e)
        {
            if (historyChangeBack.Count == 0) { return; };

            historyChangeForward.Push(image);

            image = (Bitmap)historyChangeBack.Peek();
            historyChangeBack.Pop();

            mainPicture.Image = image;
            mainPicture.Refresh();
        }

        private void buttonForward_Click(object sender, EventArgs e)
        {
            if (historyChangeForward.Count == 0) { return; };

            historyChangeBack.Push(image);

            image = (Bitmap)historyChangeForward.Peek();
            historyChangeForward.Pop();

            mainPicture.Image = image;
            mainPicture.Refresh();
        }

        private void настройкиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (settings.IsDisposed)
            {
                settings = new SettingsMathMorphology();
                settings.Show();
            }
            else
            {
                settings.Show();
            }
        }
    }
}
