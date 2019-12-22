using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3D
{
    class Point_3D
    {
        public double X;
        public double Y;
        public double Z;

        public Point_3D(int x, int y, int z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        public Point_3D(float x, float y, float z)
        {
            X = (double)x;
            Y = (double)y;
            Z = (double)z;
        }

        public Point_3D(double x, double y, double z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        public Point_3D()
        {
        }
    }
}
