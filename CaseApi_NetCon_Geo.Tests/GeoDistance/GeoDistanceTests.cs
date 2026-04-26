using CaseApi_NetCon_Geo.Domain.Helpers;
using FluentAssertions;
using Xunit;

namespace CaseApi_NetCon_Geo.Tests;

public class GeoDistanceTests
{
    [Fact]
    public void Calculate_ShouldReturnZero_WhenCoordinatesAreEqual()
    {
        var latitude = -22.910159;
        var longitude = -43.182978;

        var result = GeoDistance.Calculate(latitude, longitude, latitude, longitude);

        result.Should().BeApproximately(0, 0.01);
        //Forçar erro no valor esperado
        //Assert.True(result > 1); // Faz Falhar (Paulo Bruno)
    }

    [Fact]
    public void Calculate_ShouldReturnDistanceGreaterThanZero_WhenCoordinatesAreDifferent()
    {
        var result = GeoDistance.Calculate(
            -22.910159,
            -43.182978,
            -22.910302,
            -43.184067
        );

        result.Should().BeGreaterThan(0);
    }

    //Usar mesmas coordenadas Faz Falhar (Paulo Bruno)
    //[Fact]
    // public void Deve_Falhar_Com_Coordenadas_Iguais()
    // {
    //     var result = GeoDistance.Calculate(
    //         -22.910159,
    //         -43.182978,
    //         -22.910159,
    //         -43.182978
    //     );

    //     Assert.True(result > 0); // vai falhar
    // }
}



