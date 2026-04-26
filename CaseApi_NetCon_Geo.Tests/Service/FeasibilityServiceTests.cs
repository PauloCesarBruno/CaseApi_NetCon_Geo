using CaseApi_NetCon_Geo.Application.Interfaces;
using CaseApi_NetCon_Geo.Application.Services;
using CaseApi_NetCon_Geo.Domain.Entities;
using CaseApi_NetCon_Geo.Domain.Enums;
using FluentAssertions;
using Xunit;

namespace CaseApi_NetCon_Geo.Tests;

public class FeasibilityServiceTests
{
    [Fact]
    public async Task Get_ShouldReturnOnlyActiveAndReservedLocations()
    {
        var service = new FeasibilityService(new FakeLocationRepository());

        var result = await service.Get(-22.910159, -43.182978, 1000);

        result.Should().OnlyContain(x =>
            x.Nome == "CTO-ACTIVE" ||
            x.Nome == "CTO-RESERVED"
        );
    }

    [Fact]
    public async Task Get_ShouldReturnLocationsOrderedByShortestDistance()
    {
        var service = new FeasibilityService(new FakeLocationRepository());

        var result = (await service.Get(-22.910159, -43.182978, 1000)).ToList();

        result.Should().BeInAscendingOrder(x => x.Radius);
    }

    [Fact]
    public async Task Get_ShouldReturnOnlyLocationsInsideRadius()
    {
        var service = new FeasibilityService(new FakeLocationRepository());

        var result = await service.Get(-22.910159, -43.182978, 50);

        result.Should().OnlyContain(x => x.Radius <= 50);
    }
}

public class FakeLocationRepository : ILocationRepository
{
    public Task<IReadOnlyList<Location>> GetAllAsync()
    {
        IReadOnlyList<Location> data = new List<Location>
        {
            new Location
            {
                Id = 1,
                Name = "CTO-ACTIVE",
                Status = LocationStatus.ACTIVE,
                Latitude = -22.910159,
                Longitude = -43.182978
            },
            new Location
            {
                Id = 2,
                Name = "CTO-RESERVED",
                Status = LocationStatus.RESERVED,
                Latitude = -22.910302,
                Longitude = -43.184067
            },
            new Location
            {
                Id = 3,
                Name = "CTO-DECOMMISSIONED",
                Status = "DECOMMISSIONED",
                Latitude = -22.910159,
                Longitude = -43.182978
            },
            new Location
            {
                Id = 4,
                Name = "CTO-PLANNED",
                Status = "PLANNED",
                Latitude = -22.910159,
                Longitude = -43.182978
            }
        };


        //Um exemplo de como Fazer falhar o teste de STATUS 
        //(Para testar colocar virhgulas, chaves etc... corretamente ao descomentar - Paulo Bruno)
        //
        //    new Location
        //    {
        //        Id = 5,
        //        Name = "CTO-ERRADO",
        //        Status = LocationStatus.ACTIVE,
        //        Latitude = -22.910159,
        //        Longitude = -43.182978
        //    }
        //};

        return Task.FromResult(data);
    }
}