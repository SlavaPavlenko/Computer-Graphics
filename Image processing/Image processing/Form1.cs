using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Imaging;

namespace Image_processing
{
    public partial class Form1 : Form
    {
        Bitmap bmp;
        public Form1()
        {
            InitializeComponent();
            original_pictureBox.Load("C:\\Users\\SunRay\\Documents\\Computer-Graphics\\Image processing\\Image processing\\picture1.jpg");
        }

        private void Process_button_Click(object sender, EventArgs e)
        {
            //преобразование в оттенки серого
            int newColor;
            bmp = new Bitmap(original_pictureBox.Image);
            for (int i = 1; i < original_pictureBox.Width; i++)
                for (int j = 1; j < original_pictureBox.Height; j++)
                {
                    newColor = Convert.ToInt32(0.3 * bmp.GetPixel(i, j).R + 0.59 * bmp.GetPixel(i, j).G + 0.11 * bmp.GetPixel(i, j).B);
                    bmp.SetPixel(i, j, Color.FromArgb(newColor, newColor, newColor));
                }
            grey_pictureBox.Image = bmp;
            Bitmap bmp2 = new Bitmap(grey_pictureBox.Image);
            if (edge_textBox.Text == "")
                EdgeDetection(bmp2, 0);
            else
                EdgeDetection(bmp2,  Convert.ToDouble(edge_textBox.Text));
            alg1_pictureBox.Image = bmp2;
        }

        //градиентный метод выделения границ
        public static void EdgeDetection(Bitmap bmp, double edge)
        {
            Bitmap bSrc = (Bitmap)bmp.Clone();
            BitmapData bmpData = bmp.LockBits(new Rectangle(0, 0, bmp.Width, bmp.Height), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
            BitmapData bmpSrc = bSrc.LockBits(new Rectangle(0, 0, bSrc.Width, bSrc.Height), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);

            int lineWidth = bmpData.Stride;
            unsafe
            {
                byte* point = (byte*)(void*)bmpData.Scan0;
                byte* pointSrc = (byte*)(void*)bmpSrc.Scan0;
                int offset = lineWidth - bmp.Width * 3;

                for (int y = 0; y < bmp.Height; y++)
                {
                    for (int x = 0; x < bmp.Width; x++)
                    {
                        //  | p0 |  p1  |
                        //  |    |  p2  |
                        var p0 = ToGray(pointSrc);
                        var p1 = ToGray(pointSrc + 3);
                        var p2 = ToGray(pointSrc + 3 + lineWidth);
                        if (Math.Abs(p1 - p2) + Math.Abs(p1 - p0) > edge)
                            point[0] = point[1] = point[2] = 255;
                        else
                            point[0] = point[1] = point[2] = 0;
                        point += 3;
                        pointSrc += 3;
                    }
                    point += offset;
                    pointSrc += offset;
                }
            }
            bmp.UnlockBits(bmpData);
            bSrc.UnlockBits(bmpSrc);
        }
        static unsafe float ToGray(byte* bgr)
        {
            return bgr[2] * 0.3f + bgr[1] * 0.59f + bgr[0] * 0.11f;
        }

        //А = 128(32)   В = 1/2       0  -1   0
        //                       М=  -1   5  -1
        //                            0  -1   0
    }
}