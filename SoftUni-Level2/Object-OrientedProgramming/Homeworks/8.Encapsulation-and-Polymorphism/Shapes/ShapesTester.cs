using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shapes
{
    class ShapesTester
    {
        static void Main()
        {
            var triangle1 = new Triangle(2, 5, 60);
            var triangle2 = new Triangle(6, 7, 80);

            BasicShape rectangle1 = new Rectangle(5, 11);
            BasicShape rectangle2 = new Rectangle(6.5, 9.2);

            BasicShape circle1 = new Circle(6.1);
            BasicShape circle2 = new Circle(14.5);

            BasicShape[] shapes = new[] { triangle1, triangle2, rectangle1, rectangle2, circle1, circle2 };

            foreach (var shape in shapes)
            {
                Console.WriteLine(shape.GetType().Name);
                Console.WriteLine("Area => " + shape.CalculateArea());
                Console.WriteLine("Perimeter => " + shape.CalculatePerimeter());
            }
        }
    }
}