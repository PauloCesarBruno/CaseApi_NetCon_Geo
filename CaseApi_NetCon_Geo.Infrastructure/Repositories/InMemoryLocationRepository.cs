using CaseApi_NetCon_Geo.Application.Interfaces;
using CaseApi_NetCon_Geo.Domain.Entities;
using CaseApi_NetCon_Geo.Infrastructure.Models;
using System.Text.Json;


namespace CaseApi_NetCon_Geo.Infrastructure.Repositories;

public class InMemoryLocationRepository : ILocationRepository
{
    private readonly List<Location> _data;

    public InMemoryLocationRepository()
    {
        var path = Path.Combine(AppContext.BaseDirectory, "Data/dataset_v2.json");

        var json = File.ReadAllText(path);

        var raw = JsonSerializer.Deserialize<List<JsonLocation>>(json,
            new JsonSerializerOptions { PropertyNameCaseInsensitive = true })!;

        _data = raw
            .Where(x => x.geometry != null && x.geometry.Any())
            .Where(x => x.geometry.First().x.HasValue && x.geometry.First().y.HasValue)
            .Select(x => new Location
            {
                Id = x.id,
                Name = x.name,
                Status = x.status,
                Latitude = x.geometry.First().y!.Value,
                Longitude = x.geometry.First().x!.Value
            })
            .ToList();
    }

    public Task<IReadOnlyList<Location>> GetAllAsync()
    {
        return Task.FromResult<IReadOnlyList<Location>>(_data);
    }
}