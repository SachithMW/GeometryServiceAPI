using GeometryService.Core.Implementations;
using GeometryService.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeometryService.Core.Implementations
{
    public class TriangleValidator : IShapeValidator
    {
        // Implement IsRightShape for triangles
        public bool IsRightTriangle(IShape shape)
        {
            if (shape is Triangle triangle)
            {
                double[] sides = { triangle.SideA, triangle.SideB, triangle.SideC };
                Array.Sort(sides);

                //Used Pythagoras theorem to check where it's a right triangle
                return Math.Pow(sides[0], 2) + Math.Pow(sides[1], 2) == Math.Pow(sides[2], 2); 
            }
            return false;
        }
    }
}
