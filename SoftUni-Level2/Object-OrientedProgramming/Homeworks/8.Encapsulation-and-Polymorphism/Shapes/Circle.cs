using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shapes
{
    public class Circle : BasicShape, IShape
    {
        public Circle(double width)
            : base(width, width)
        {
        }
        
        public override double CalculateArea()
        {
            return Math.PI * this.Width * this.Width;
        }

        public override double CalculatePerimeter()
        {
            return 2 * Math.PI * this.Width;
        }
    }
}