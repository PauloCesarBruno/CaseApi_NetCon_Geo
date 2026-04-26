using CaseApi_NetCon_Geo.Application.DTOs;
using CaseApi_NetCon_Geo.Application.Validators;
using FluentAssertions;
using Xunit;

namespace CaseApi_NetCon_Geo.Tests;

public class FeasibilityRequestValidatorTests
{
    [Fact]
    public void Validate_ShouldFail_WhenLatitudeIsNull()
    {
        var validator = new FeasibilityRequestValidator();

        var request = new FeasibilityRequest
        {
            Latitude = null,
            Longitude = -43.182978,
            Radius = 100,
            Page = 1
        };

        var result = validator.Validate(request);

        result.IsValid.Should().BeFalse();
        //Falhar o teste de Latitude null (apenas um exemplo , você pode criar testes semelhantes para Longitude e Radius - Paulo Bruno)
       //result.IsValid.Should().BeTrue();
        result.Errors.Should().Contain(x => x.ErrorMessage == "latitude is mandatory");
    }

    [Fact]
    public void Validate_ShouldFail_WhenRadiusIsLessThan10()
    {
        var validator = new FeasibilityRequestValidator();

        var request = new FeasibilityRequest
        {
            Latitude = -22.910159,
            Longitude = -43.182978,
            Radius = 5,
            Page = 1
        };

        var result = validator.Validate(request);

        result.IsValid.Should().BeFalse();
        result.Errors.Should().Contain(x => x.ErrorMessage == "radius must be between 10 and 1000");
    }

    [Fact]
    public void Validate_ShouldPass_WhenRequestIsValid()
    {
        var validator = new FeasibilityRequestValidator();

        var request = new FeasibilityRequest
        {
            Latitude = -22.910159,
            Longitude = -43.182978,
            Radius = 100,
            Page = 1
        };

        var result = validator.Validate(request);

        result.IsValid.Should().BeTrue();
    }
}