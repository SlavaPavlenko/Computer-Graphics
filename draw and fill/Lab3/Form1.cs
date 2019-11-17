using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Draw_and_fill
{
    public partial class Form1 : Form
    {
        private void Swap(ref int x, ref int y)
        {
            int buffer = x;
            x = y;
            y = buffer;
        }
        //Функции для рисования окружностей
        public void DrawCircle(int x, int y, int x0, int y0, Bitmap bitmap, Color color)
        {
            bitmap.SetPixel(x + x0, y + y0, color);
            bitmap.SetPixel(x + x0, -y + y0, color);
            bitmap.SetPixel(-x + x0, y + y0, color);
            bitmap.SetPixel(-x + x0, -y + y0, color);
            bitmap.SetPixel(y + x0, x + y0, color);
            bitmap.SetPixel(y + x0, -x + y0, color);
            bitmap.SetPixel(-y + x0, x + y0, color);
            bitmap.SetPixel(-y + x0, -x + y0, color);
        }
        public void BrezenhemCircle(int x0, int y0, int radius, Bitmap bitmap, Color color)
        {
            int x = 0;
            int y = radius;
            int e = 3 - 2 * radius;
            while (y >= x)
            {
                DrawCircle(x, y, x0, y0, bitmap, color);
                if (e <= 0)
                {
                    e += 4 * x + 6;
                }
                else
                {
                    e += 4 * (x - y) + 10;
                    y--;
                }
                x++;
            }
        }
        //Рекурсия с "затравкой"
        public void Fill(int x, int y, Bitmap bitmap, Color color)
        {
            Color colorToFill = bitmap.GetPixel(x, y);
            bitmap.SetPixel(x, y, color);
            //проверяем границы
            if ((x > 1) && (x < bitmap.Width - 1) && (y > 1) && (y < bitmap.Height - 1))
            {
                //right
                if (bitmap.GetPixel(x + 1, y) == colorToFill)
                    Fill(x + 1, y, bitmap, color);
                //up
                if (bitmap.GetPixel(x, y + 1) == colorToFill)
                    Fill(x, y + 1, bitmap, color);
                //left
                if (bitmap.GetPixel(x - 1, y) == colorToFill)
                    Fill(x - 1, y, bitmap, color);
                //down
                if (bitmap.GetPixel(x, y - 1) == colorToFill)
                    Fill(x, y - 1, bitmap, color);
            }
        }
        public void FillPatter(int x, int y, Bitmap bitmap, Color[,] color_pattern, int w, int h)
        {
            Color colorToFill = bitmap.GetPixel(x, y);
            int xleft = x;
            int xright = x + 1;
            //Налево
            while ((xleft >= 0) && (bitmap.GetPixel(xleft, y) == colorToFill))
            {
                bitmap.SetPixel(xleft, y, color_pattern[xleft % w, y % h]);
                xleft--;
            }
            xleft++;
            //Направо
            while ((xright < bitmap.Width - 1) && (bitmap.GetPixel(xright, y) == colorToFill))
            {
                bitmap.SetPixel(xright, y, color_pattern[xright % w, y % h]);
                xright++;
            }
            xright--;
            //Направо вниз
            int tmpX = xleft;
            while ((tmpX <= xright) && (y != 0))
            {
                while ((tmpX <= xright) && (bitmap.GetPixel(tmpX, y - 1) != colorToFill))
                    tmpX++;
                if (tmpX <= xright)
                    FillPatter(tmpX, y - 1, bitmap, color_pattern, w, h);
                tmpX++;
            }
            //Направо вверх
            tmpX = xleft;
            while ((tmpX <= xright) && (y + 1 != bitmap.Height))
            {
                while ((tmpX <= xright) && (bitmap.GetPixel(tmpX, y + 1) != colorToFill))
                    tmpX++;
                if (tmpX <= xright)
                    FillPatter(tmpX, y + 1, bitmap, color_pattern, w, h);
                tmpX++;
            }
        }
        //естественный алгоритм рисования линий
        public void DrawNaturalLine(double x, double y, double X, double Y, Bitmap bitmap, Color color)
        {
            double x0;
            double x1;
            double y0;
            double y1;
            bool flag = false;
            //вертикальные линии
            if ((X - x) == 0)
            {
                y0 = (y < Y) ? y : Y;
                y1 = (y < Y) ? Y : y;
                for (int i = Convert.ToInt32(y0); i <= y1; i++)
                {
                    bitmap.SetPixel(Convert.ToInt32(x), i, color);
                }
            }
            else
            {
                double a = (Y - y) / (X - x);
                double b = y - a * x;
                if (Math.Abs(X - x) < Math.Abs(Y - y))
                {
                    x0 = y;
                    x1 = Y;
                    flag = true;
                }
                else
                {
                    x0 = x;
                    x1 = X;
                }
                if (x1 < x0)
                {
                    double z = x1;
                    x1 = x0;
                    x0 = z;
                }
                if (flag)
                    for (int i = Convert.ToInt32(x0); i <= x1; i++)
                        bitmap.SetPixel(Convert.ToInt32((i - b) / a), i, color);
                else
                    for (int i = Convert.ToInt32(x0); i <= x1; i++)
                        bitmap.SetPixel(i, Convert.ToInt32(i * a + b), color);
            }
        }
        public void DrawBresenhemLine(int x0, int y0, int x1, int y1, Bitmap bitmap, Color color)
        {
            bool check = Math.Abs(y1 - y0) > Math.Abs(x1 - x0);

            if (check)
            {
                Swap(ref x0, ref y0);
                Swap(ref x1, ref y1);
            }
            if (x0 > x1)
            {
                Swap(ref x0, ref x1);
                Swap(ref y0, ref y1);
            }

            double dx = x1 - x0;
            double dy = Math.Abs(y1 - y0);
            double m = dy / dx;
            double e = m - 0.5;
            int ystep;
            if (y0 < y1)
                ystep = 1;
            else
                ystep = -1;

            int y = y0;
            for (int x = x0; x <= x1; x++)
            {
                bitmap.SetPixel(check ? y : x, check ? x : y, color);
                if (e >= 0)
                {
                    y += ystep;
                    e += m - 1;
                }
                else
                    e += m;
            }
        }

        public void ZatravkaMod(int x, int y, Bitmap bitmap, Color color)
        {
            Color backcolor = bitmap.GetPixel(x, y);
            int xl = x;
            int xr = x + 1;
            //Налево          
            while ((xl >= 0) && (bitmap.GetPixel(xl, y) == backcolor))
            {
                bitmap.SetPixel(xl, y, color);
                xl--;
            }
            xl++;
            //Направо
            while ((xr < bitmap.Width - 1) && (bitmap.GetPixel(xr, y) == backcolor))
            {
                bitmap.SetPixel(xr, y, color);
                xr++;
            }
            xr--;

            //Направо снизу
            int tmp_x = xl;
            while ((tmp_x <= xr) && (y != 0))
            {
                while ((tmp_x <= xr) && (bitmap.GetPixel(tmp_x, y - 1) != backcolor))
                    tmp_x++;
                if (tmp_x <= xr)
                    ZatravkaMod(tmp_x, y - 1, bitmap, color);
                tmp_x++;
            }
            //Направо сверху
            tmp_x = xl;
            while ((tmp_x <= xr) && (y + 1 != bitmap.Height))
            {
                while ((tmp_x <= xr) && (bitmap.GetPixel(tmp_x, y + 1) != backcolor))
                    tmp_x++;
                if (tmp_x <= xr)
                    ZatravkaMod(tmp_x, y + 1, bitmap, color);
                tmp_x++;
            }
        }
        public Form1()
        {
            InitializeComponent();
            //pictureBox1.BackColor = Color.PaleTurquoise; 
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Bitmap bitmap = new Bitmap(9000, 9000);

            Color[,] c = new Color[2, 2];
            c[0, 0] = Color.Yellow;
            c[0, 1] = Color.Black;
            c[1, 0] = Color.Yellow;
            c[1, 1] = Color.Black;
 
            BrezenhemCircle(50, 50, 30, bitmap, Color.Black);
            Fill(50, 50, bitmap, Color.Red);

            DrawBresenhemLine(100, 0, 180, 80, bitmap, Color.Black);

            DrawNaturalLine(200, 0, 280, 80, bitmap, Color.Black);

            BrezenhemCircle(50, 150, 30, bitmap, Color.Black);
            ZatravkaMod(50, 150, bitmap, Color.Green);

            BrezenhemCircle(50, 250, 30, bitmap, Color.Black);
            FillPatter(50, 250, bitmap, c, 2, 2);

            pictureBox1.Image = bitmap;
        }
        private void button2_Click(object sender, EventArgs e)
        {
            Bitmap bitmap = new Bitmap(1, 1);
            pictureBox1.Image = bitmap;
        }
    }
}
