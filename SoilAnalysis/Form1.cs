using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SoilAnalysis
{
    public partial class Form1 : Form
    {
        List<PictureBox> pictureBoxes = new List<PictureBox>();
        string[] files;

        public Form1()
        {
            InitializeComponent();
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                pbPreview.Image = null;

                ClearImages();

                files = openFileDialog.FileNames;

                pictureBoxes.AddRange(files.Select(
                        x => new PictureBox
                        {
                            Width = 160,
                            Height = 120,
                            Image = new Bitmap(x),
                            SizeMode = PictureBoxSizeMode.Zoom
                        }
                    )
                );

                flImages.Controls.AddRange(pictureBoxes.ToArray());

                pictureBoxes.ForEach(x =>
                {
                    x.Click += thumbnail_Click;
                });
            }
        }

        private void thumbnail_Click(object sender, EventArgs e)
        {
            PictureBox pb = (PictureBox)sender;
            pbPreview.Image = pb.Image;

        }

        private void ClearImages()
        {

            foreach (PictureBox pb in pictureBoxes)
            {
                Image image = pb.Image;

                pb.Parent = null;
                pb.Image = null;

                image.Dispose();
                pb.Dispose();

                flImages.Controls.Remove(pb);
            }

            pictureBoxes.Clear();
        }

        private void groupBox4_Enter(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
