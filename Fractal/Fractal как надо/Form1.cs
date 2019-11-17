using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Fractal_как_надо
{
    public partial class Form1 : Form
    {
        string strstart = "F";
        string ruleF = "F-F++F-F";
        Graphics g;
        Pen pen;
        public Form1()
        {
            InitializeComponent();
            g = pictureBox1.CreateGraphics();
        }

        private void Draw_btn_Click(object sender, EventArgs e)
        {
            g.Clear(pictureBox1.BackColor);
            pen = new Pen(Color.Black);
            int fractalizationDegree = 1;
            try
            {
                fractalizationDegree = int.Parse(textBox1.Text);
            }
            catch { }
            string str = strstart;
            for (int i = 0; i < fractalizationDegree; i++)
                str = str.Replace("F", ruleF);
            double alpha = 0;
            int step = 10;
            int stepX = step;
            int stepY = step;
            int x = 10;
            int y = pictureBox1.Size.Height - 10;
            double c1 = 0.5;
            double c2 = 0.86;
            for (int i = 0; i < str.Length; i++)
            {
                switch (str[i])
                {
                    case 'F':
                        switch (alpha)
                        {
                            case 0:
                                stepX = step;
                                stepY = 0;
                                break;
                            case 1:
                                stepX = (int)(step * c1);
                                stepY = (int)(step * c2);
                                break;
                            case 2:
                                stepX = -(int)(step * c1);
                                stepY = (int)(step * c2);
                                break;
                            case 3:
                                stepX = -step;
                                stepY = 0;
                                break;
                            case 4:
                                stepX = -(int)(step * c1);
                                stepY = -(int)(step * c2);
                                break;
                            case 5:
                                stepX = (int)(step * c1);
                                stepY = -(int)(step * c2);
                                break;
                        }
                        g.DrawLine(pen, x, y, x + stepX, y + stepY);
                        x += stepX;
                        y += stepY;
                        break;
                    case '-':
                        alpha -= 1;
                        if (alpha < 0) alpha += 6;
                        break;
                    case '+':
                        alpha += 1;
                        if (alpha > 5) alpha -= 6;
                        break;
                }
            }
        }
    }
}
