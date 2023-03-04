using FluentValidation;

namespace HomeSwapTravel.Application.Homes.Commands.CreateHome;

public class CreateHomeCommandValidator : AbstractValidator<CreateHomeCommand>
{
    public CreateHomeCommandValidator()
    {
        RuleFor(p => p.Bathrooms)
            .NotEmpty().WithMessage("Bathroom count is required")
            .GreaterThan(0).WithMessage("Bathroom count must be grater than 0");
            

        RuleFor(p => p.Bedrooms)
            .NotEmpty().WithMessage("Bedroom count is required")
            .GreaterThan(0).WithMessage("Bedroom count must be grater than 0");
            

        RuleFor(p => p.SurfaceArea)
            .NotNull().WithMessage("Surface area is required");

        When(p => p.SurfaceArea != null, () =>
        {
            RuleFor(p => p.SurfaceArea.Value)
            .NotEmpty().WithMessage("Surface area is required")
            .GreaterThan(0).WithMessage("Surface area must be grater than 0");
            
        });

        RuleFor(p => p.Address)
            .NotNull().WithMessage("Address is required");
       
        RuleFor(p => p.HomeDescription)
            .NotNull().WithMessage("Home description is required")
            .Must(d => d == null || d.Length >= 50).WithMessage("Home description requires at least 50 symbols");
       
        RuleFor(p => p.NeighborhoodDescription)
            .NotNull().WithMessage("Neighborhood description is required")
            .Must(d => d == null || d.Length >= 50).WithMessage("Neighborhood description requires at least 50 symbols");  
    }
}