using FluentValidation;
using FluentValidation.Results;
using GeometryServiceAPI.Controllers;
using GeometryServiceAPI.Models;
using LoggerService;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace GeometryService.Tests.XUnit.Controllers
{
    public class TriangleControllerTests
    {
        [Fact]
        public void CheckRightTriangle_ReturnsOk_ForRightTriangle()
        {
            // Arrange
            var validatorMock = new Mock<IValidator<TriangleInputModel>>();
            validatorMock.Setup(validator => validator.Validate(It.IsAny<TriangleInputModel>())).Returns(new ValidationResult());

            var loggerMock = new Mock<ILoggerManager>();


            var controller = new TriangleController(validatorMock.Object, loggerMock.Object);
            var model = new TriangleInputModel { SideA = 3, SideB = 4, SideC = 5 };

            // Act
            var result = controller.CheckRightTriangle(model);

            // Assert
            Assert.IsType<OkObjectResult>(result);
            var okResult = result as OkObjectResult;
            Assert.Equal("Yes, this is a right triangle.", okResult.Value);
        }

        [Fact]
        public void CheckRightTriangle_ReturnsOk_ForNot_RightTriangle()
        {
            // Arrange
            var validatorMock = new Mock<IValidator<TriangleInputModel>>();
            validatorMock.Setup(validator => validator.Validate(It.IsAny<TriangleInputModel>())).Returns(new ValidationResult());

            var loggerMock = new Mock<ILoggerManager>();


            var controller = new TriangleController(validatorMock.Object, loggerMock.Object);
            var model = new TriangleInputModel { SideA = 3, SideB = 4, SideC = 6 };

            // Act
            var result = controller.CheckRightTriangle(model);

            // Assert
            Assert.IsType<OkObjectResult>(result);
            var okResult = result as OkObjectResult;
            Assert.Equal("No, this is not a right triangle.", okResult.Value);
        }
    }
}
