using FluentValidation;
using GeometryServiceAPI.Models;

namespace GeometryServiceAPI.Middleware
{
    public class TriangleInputModelValidator : AbstractValidator<TriangleInputModel>
    {
        public TriangleInputModelValidator()
        {
            RuleFor(x => x.SideA).GreaterThan(0).WithMessage("SideA must be greater than 0.");
            RuleFor(x => x.SideB).GreaterThan(0).WithMessage("SideB must be greater than 0.");
            RuleFor(x => x.SideC).GreaterThan(0).WithMessage("SideC must be greater than 0."); 
        }   
    }
}
