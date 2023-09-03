using FluentValidation;
using GeometryService.Core.Implementations;
using GeometryService.Core.Interfaces;
using GeometryServiceAPI.Models;
using LoggerService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GeometryServiceAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TriangleController : ControllerBase
    {
        private readonly IValidator<TriangleInputModel> _validator;
        private ILoggerManager _logger;

        public TriangleController(IValidator<TriangleInputModel> validator, ILoggerManager logger)
        {
            _validator = validator; 
            _logger = logger;

        }

        /// <summary>
        /// Check if a triangle is a right triangle.
        /// </summary>
        /// <remarks>
        /// This endpoint takes the side lengths of a triangle and checks if it is a right triangle.
        /// </remarks>
        /// <param name="model">The model containing triangle side lengths.</param>
        /// <returns>
        /// <para>HTTP 200 OK if the triangle is a right triangle.</para>
        /// <para>HTTP 400 Bad Request if the input is invalid or the triangle is not a right triangle.</para>
        /// </returns>
        /// 
        [HttpPost("checkrighttriangle")]
        public IActionResult CheckRightTriangle([FromBody] TriangleInputModel triangleModel)
        {
            //Handle the logs


            // Validate input using FluentValidation
            var validationResult = _validator.Validate(triangleModel);

            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }

            _logger.LogInfo($"Checking Trainagle For Values SideA {triangleModel.SideA} SideB {triangleModel.SideB} SideC {triangleModel.SideC}" );


            // Create a Triangle instance
            IShape triangle = new Triangle(triangleModel.SideA, triangleModel.SideB, triangleModel.SideC);

            // Check if it's a right triangle
            var validator = new TriangleValidator();
            bool isRightTriangle = validator.IsRightTriangle(triangle);

            if (isRightTriangle)
            {
                return Ok("Yes, this is a right triangle.");
            }
            else
            {
                return Ok("No, this is not a right triangle.");
            }
        }
    }
}
