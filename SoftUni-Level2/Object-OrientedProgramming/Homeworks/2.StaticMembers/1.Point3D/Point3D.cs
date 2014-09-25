using System;

namespace Space
{
    class Point3D
    {
        private double x;
        private double y;
        private double z;

        private static readonly Point3D startingPoint;

        static Point3D()
        {
            Point3D.startingPoint = new Point3D(0, 0, 0);
        }

        public Point3D(double x, double y, double z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }

        public static Point3D StartingPoint
        {
            get { return Point3D.startingPoint; }
        }

        public double X
        {
            get { return this.x; }
        }
        public double Y
        {
            get { return this.y; }
        }
        public double Z
        {
            get { return this.z; }
        }

        public override string ToString()
        {
            string result = string.Format("Point3D({0},{1},{2})", this.x, this.y, this.z);
            return result;
        }
    }

    class Program
    {
        static void Main()
        {
            Point3D firstPoint = new Point3D(0, 1, 2);
            Console.WriteLine(firstPoint);
            Console.WriteLine(Point3D.StartingPoint);
        }
    }
}