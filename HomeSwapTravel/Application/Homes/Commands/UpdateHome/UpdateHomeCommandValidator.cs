using FluentValidation;

namespace HomeSwapTravel.Application.Homes.Commands.UpdateHome;

public class UpdateHomeCommandValidator : AbstractValidator<UpdateHomeCommand>
{
    public UpdateHomeCommandValidator()
    {
        RuleFor(p => p.Bathrooms)
            .GreaterThan(0).WithMessage("Bathroom count must be grater than 0")
            .NotEmpty().WithMessage("Bathroom count is required");
        
        RuleFor(p => p.Bedrooms)
            .GreaterThan(0).WithMessage("Bedroom count must be grater than 0")
            .NotEmpty().WithMessage("Bedroom count is required");
        
        RuleFor(p => p.SurfaceArea.Value)
            .GreaterThan(0).WithMessage("Surface area must be grater than 0")
            .NotEmpty().WithMessage("Surface area is required");

        RuleFor(p => p.HomeDescription)
            .NotNull().WithMessage("Home description is required")
            .Must(d => d == null || d.Length >= 50).WithMessage("Home description requires at least 50 symbols");

        RuleFor(p => p.NeighborhoodDescription)
            .NotNull().WithMessage("Neighborhood description is required")
            .Must(d => d == null || d.Length >= 50).WithMessage("Neighborhood description requires at least 50 symbols");
    }
}