using CaseApi_NetCon_Geo.Application.Interfaces;
using CaseApi_NetCon_Geo.Domain.DTOs;
using CaseApi_NetCon_Geo.Domain.Enums;
using CaseApi_NetCon_Geo.Domain.Helpers;


namespace CaseApi_NetCon_Geo.Application.Services;

public class FeasibilityService
{
    private readonly ILocationRepository _repo;

    public FeasibilityService(ILocationRepository repo)
    {
        _repo = repo;
    }

    public async Task<IEnumerable<FeasibilityResponseDto>> Get(double lat, double lon, double radius)
    {
        var data = await _repo.GetAllAsync();

        return data
            .Where(x => x.Status is LocationStatus.ACTIVE or LocationStatus.RESERVED)
            .Select(x =>
            {
                var distance = GeoDistance.Calculate(lat, lon, x.Latitude, x.Longitude);

                return new FeasibilityResponseDto(
                    x.Id,
                    x.Name,
                    x.Latitude,
                    x.Longitude,
                    Math.Round(distance, 2)
                );
            })
            .Where(x => x.Radius <= radius)
            .OrderBy(x => x.Radius);
    }
}