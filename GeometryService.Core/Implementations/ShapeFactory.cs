using GeometryService.Core.Enums;
using GeometryService.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeometryService.Core.Implementations
{
    public class ShapeFactory : IShapeFactory
    {
        //public IShape GetShape(ShapeType shapeType, params double[] sides)
        //{
        //    switch (shapeType)
        //    {
        //        case ShapeType.Triangle:
        //            return new Triangle(sides[0], sides[1], sides[2]);
        //        // Add cases for other shape types
        //        default:
        //            throw new ArgumentException("Invalid shape type.");
        //    }
        //}
    }
}
