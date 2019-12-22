using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _3D
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        Bitmap bmp;
        Graphics g;
        Pen pen = new Pen(Color.Yellow, 1);
        Point_3D[,] alfabeta = new Point_3D[40, 40];
        Point_3D[,] axonom = new Point_3D[40, 40];
        Point_3D[,] screen = new Point_3D[40, 40];

        public double r = 90;
        public double f = -Math.PI / 2;
        public double q = Math.PI / 2;
        public double a;
        public double b;
        public double g1;
        public Color backgrColor = Color.Black;
        const int min = 25;
        const int max = 300;
        public double kx;
        public double ky;
        public double kz;
        public double dx;
        public double dy;
        public double dz;
        const int k = 2;

        private Point_3D CalcCoord(double a, double b)
        {
            Point_3D tmp = new Point_3D();
            tmp.X = r * a;
            tmp.Y = r * b;
            tmp.Z = r * k * a * b / (Math.Pow(a, 2) + Math.Pow(b, 2));
            return tmp;
        }

        // Первод в аксонометрические координаты. 
        private Point_3D CalcCoordAx(Point_3D old, double f, double q)
        {
            Point_3D tmp = new Point_3D();
            tmp.X = old.X * Math.Cos(f) + old.Y * Math.Sin(f);
            tmp.Y = -old.X * Math.Sin(f) * Math.Cos(q) + old.Y * Math.Cos(f) * Math.Cos(q) + old.Z * Math.Sin(q);
            tmp.Z = old.X * Math.Sin(f) * Math.Sin(q) - old.Y * Math.Cos(f) * Math.Sin(q) + old.Z * Math.Cos(q);
            return tmp;
        }
        private Point_3D PovorotX(Point_3D old)
        {
            Point_3D tmp = new Point_3D();
            tmp.X = old.X;
            tmp.Y = old.Y * Math.Cos(a) - old.Z * Math.Sin(a);
            tmp.Z = old.Y * Math.Sin(a) + old.Z * Math.Cos(a);
            return tmp;
        }
        private void PovorotXDlaAxom()
        {
            int i = 0;
            int j = 0;
            for (i = 0; i <= 39; i++)
            {
                for (j = 0; j <= 39; j++)
                {

                    axonom[i, j] = PovorotX(axonom[i, j]);
                }
            }
        }
        private Point_3D PovorotY(Point_3D old)
        {
            Point_3D tmp = new Point_3D();
            tmp.X = old.X * Math.Cos(b) + old.Z * Math.Sin(b);
            tmp.Y = old.Y;
            tmp.Z = -old.X * Math.Sin(b) + old.Z * Math.Cos(b);
            return tmp;
        }
        private void PovorotYDlaAxom()
        {
            int i = 0;
            int j = 0;
            for (i = 0; i <= 39; i++)
            {
                for (j = 0; j <= 39; j++)
                {

                    axonom[i, j] = PovorotY(axonom[i, j]);
                }
            }
        }
        private Point_3D PovorotZ(Point_3D old)
        {
            Point_3D tmp = new Point_3D();
            tmp.X = old.X * Math.Cos(g1) - old.Y * Math.Sin(g1);
            tmp.Y = old.X * Math.Sin(g1) + old.Y * Math.Cos(g1);
            tmp.Z = old.Z;
            return tmp;
        }
        private void PovorotZDlaAxom()
        {
            int i = 0;
            int j = 0;
            for (i = 0; i <= 39; i++)
            {
                for (j = 0; j <= 39; j++)
                {

                    axonom[i, j] = PovorotZ(axonom[i, j]);
                }
            }
        }
        private Point_3D Mashtabirovanie(Point_3D old)
        {
            Point_3D tmp = new Point_3D();
            tmp.X = old.X * kx;
            tmp.Y = old.Y * ky;
            tmp.Z = old.Z * kz;
            return tmp;
        }
        private void MashtabirovanieDlaAxom()
        {
            int i = 0;
            int j = 0;
            for (i = 0; i <= 39; i++)
            {
                for (j = 0; j <= 39; j++)
                {

                    axonom[i, j] = Mashtabirovanie(axonom[i, j]);
                }
            }
        }
        private Point_3D Peremeshenie(Point_3D old)
        {
            Point_3D tmp = new Point_3D();
            tmp.X = old.X + dx;
            tmp.Y = old.Y + dy;
            tmp.Z = old.Z + dz;
            return tmp;
        }
        private void PeremeshenieDlaAxom()
        {
            int i = 0;
            int j = 0;
            for (i = 0; i <= 39; i++)
            {
                for (j = 0; j <= 39; j++)
                {

                    axonom[i, j] = Peremeshenie(axonom[i, j]);
                }
            }
        }
        // Перевод в экранные координаты.
        private Point_3D CalcCoordSc(Point_3D old)
        {
            int x = pictureBox2.ClientSize.Width / 2;
            int y = pictureBox2.ClientSize.Height / 2;

            Point_3D tmp = new Point_3D();
            tmp.X = Convert.ToInt32(x + old.X);
            tmp.Y = Convert.ToInt32(y + old.Y);
            return tmp;
        }


        // Заполнение матрицы 3D координат.
        private void fillMatr3D()
        {
            int i = 0;
            int j = 0;
            for (b = -2; b <= 2; b += 0.1)
            {
                j = 0;
                for (a = -2; a <= 2; a += 0.1)
                {
                    alfabeta[i, j] = CalcCoord(a, b);
                    j++;
                }
                i++;
            }

        }



        // Заполнение матрицы аксонометрических координат.
        private void MatrToAxon()
        {
            int i = 0;
            int j = 0;
            for (i = 0; i <= 39; i++)
            {
                for (j = 0; j <= 39; j++)
                {

                    axonom[i, j] = CalcCoordAx(alfabeta[i, j], f, q);
                }
            }
        }



        // Заполнение экрана.
        private void fillMatrScreen()
        {
            for (int i = 0; i <= 39; i++)
            {

                for (int j = 0; j <= 39; j++)
                {

                    screen[i, j] = CalcCoordSc(axonom[i, j]);
                }
            }
        }


        // Рисование фигуры.
        private void Draw()
        {
            for (int i = 0; i < 39; i++)
            {
                for (int j = 0; j < 39; j++)
                {
                    if (j != 39)
                    {
                        Point p1 = new Point(screen[i, j].X, screen[i, j].Y);
                        Point p2 = new Point(screen[i, j + 1].X, screen[i, j + 1].Y);
                        g.DrawLine(pen, p1, p2);
                    }
                    else
                    {
                        Point_3D p1 = new Point_3D(screen[i, 16].X, screen[i, 16].Y);
                        Point_3D p2 = new Point_3D(screen[i, 0].X, screen[i, 0].Y);
                        g.DrawLine(pen, p1, p2);
                    }
                }
            }
            for (int i = 0; i <= 39; i++)
            {

                for (int j = 0; j <= 39; j++)
                {
                    if (i != 39)
                    {
                        Point_3D p1 = new Point_3D(screen[i, j].X, screen[i, j].Y);
                        Point_3D p2 = new Point_3D(screen[i + 1, j].X, screen[i + 1, j].Y);
                        g.DrawLine(pen, p1, p2);
                    }
                    else
                    {

                        Point_3D p1 = new Point_3D(screen[i, j].X, screen[i, j].Y);
                        Point_3D p2 = new Point_3D(screen[i, j].X + 1, screen[i, j].Y + 1);
                        g.DrawLine(pen, p1, p2);


                    }
                }
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            g.Clear(backgrColor);
            fillMatr3D();
            MatrToAxon();
            fillMatrScreen();
            Draw();
        }

        #region

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }
        #endregion

        private void button3_Click_1(object sender, EventArgs e)
        {
            g.Clear(backgrColor);
            if (textBoxOX.Text != "") { this.a = Convert.ToDouble(textBoxOX.Text); PovorotXDlaAxom(); } else a = 0;
            if (textBoxOY.Text != "") { this.b = Convert.ToDouble(textBoxOY.Text); PovorotYDlaAxom(); } else b = 0;
            if (textBoxOZ.Text != "") { this.g1 = Convert.ToDouble(textBoxOZ.Text); PovorotZDlaAxom(); } else g1 = 0;


            fillMatrScreen();
            pictureBox2.Refresh();
            Draw();
            pictureBox2.Image = bmp;
        }
        private void button1_Click_1(object sender, EventArgs e)
        {
            g.Clear(backgrColor);
            if (textBoxKX.Text != "") { this.kx = Convert.ToDouble(textBoxKX.Text); } else kx = 1;
            if (textBoxKY.Text != "") { this.ky = Convert.ToDouble(textBoxKY.Text); } else ky = 1;
            if (textBoxKZ.Text != "") { this.kz = Convert.ToDouble(textBoxKZ.Text); } else kz = 1;

            MashtabirovanieDlaAxom();
            fillMatrScreen();
            pictureBox2.Refresh();
            Draw();
            pictureBox2.Image = bmp;
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            g.Clear(backgrColor);
            if (textBoxDX.Text != "") { this.dx = Convert.ToDouble(textBoxDX.Text); } else dx = 0;
            if (textBoxDY.Text != "") { this.dy = Convert.ToDouble(textBoxDY.Text); } else dy = 0;
            if (textBoxDZ.Text != "") { this.dz = Convert.ToDouble(textBoxDZ.Text); } else dz = 0;

            PeremeshenieDlaAxom();

            fillMatrScreen();
            pictureBox2.Refresh();
            Draw();
            pictureBox2.Image = bmp;
        }
    }
}
