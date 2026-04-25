using CaseApi_NetCon_Geo.Domain.Entities;


namespace CaseApi_NetCon_Geo.Application.Interfaces;

public interface ILocationRepository
{
    Task<IReadOnlyList<Location>> GetAllAsync();
}