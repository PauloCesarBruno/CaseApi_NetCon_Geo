namespace CaseApi_NetCon_Geo.Domain.DTOs;

public record FeasibilityResponseDto(
    int Id,
    string Nome,
    double Latitude,
    double Longitude,
    double Radius
);