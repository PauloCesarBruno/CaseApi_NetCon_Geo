using FluentValidation;
using CaseApi_NetCon_Geo.Application.DTOs;

namespace CaseApi_NetCon_Geo.Application.Validators;

public class FeasibilityRequestValidator : AbstractValidator<FeasibilityRequest>
{
    public FeasibilityRequestValidator()
    {
      
        RuleFor(x => x.Latitude)
            .NotNull().WithMessage("latitude is mandatory")
            .InclusiveBetween(-90, 90).WithMessage("latitude out of range");

        
        RuleFor(x => x.Longitude)
            .NotNull().WithMessage("longitude is mandatory")
            .InclusiveBetween(-180, 180).WithMessage("longitude out of range");

        
        RuleFor(x => x.Radius)
            .NotNull().WithMessage("radius is mandatory")
            .InclusiveBetween(10, 1000).WithMessage("radius must be between 10 and 1000");

     
        RuleFor(x => x.Page)
            .GreaterThanOrEqualTo(1).WithMessage("page must be greater than 0");
    }
}