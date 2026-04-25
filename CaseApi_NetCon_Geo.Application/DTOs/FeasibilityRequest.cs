namespace CaseApi_NetCon_Geo.Application.DTOs;

public class FeasibilityRequest
{
    public double? Latitude { get; set; }
    public double? Longitude { get; set; }
    public int? Radius { get; set; }
    public int Page { get; set; } = 1;
}