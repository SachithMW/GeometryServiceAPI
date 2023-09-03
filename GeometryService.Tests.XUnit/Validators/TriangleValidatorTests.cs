using GeometryService.Core.Implementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace GeometryService.Tests.XUnit.Validators
{
    public class TriangleValidatorTests
    {
        [Fact]
        public void IsRightShape_Returns_True_For_RightTriangle()
        {
            // Arrange
            var validator = new TriangleValidator();
            var triangle = new Triangle(3, 4, 5);

            // Act
            bool isRightShape = validator.IsRightTriangle(triangle);

            // Assert
            Assert.True(isRightShape);
        }

        [Fact]
        public void IsRightShape_Returns_False_For_NonRightTriangle()
        {
            // Arrange
            var validator = new TriangleValidator();
            var triangle = new Triangle(3, 4, 6);

            // Act
            bool isRightShape = validator.IsRightTriangle(triangle);

            // Assert
            Assert.False(isRightShape);
        }
    }
}
