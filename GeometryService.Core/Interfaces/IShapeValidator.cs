using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeometryService.Core.Interfaces
{
    public interface IShapeValidator
    {
        bool IsRightTriangle(IShape shape);
    }
}
