namespace CaseApi_NetCon_Geo.Domain.Entities;

public record Location
{
    public int Id { get; init; }
    public string Name { get; init; }
    public string Status { get; init; }
    public double Latitude { get; init; }
    public double Longitude { get; init; }
}