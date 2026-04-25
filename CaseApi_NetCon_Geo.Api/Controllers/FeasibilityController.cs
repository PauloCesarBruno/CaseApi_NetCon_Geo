using CaseApi_NetCon_Geo.Application.DTOs;
using CaseApi_NetCon_Geo.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace CaseApi_NetCon_Geo.Api.Controllers;

[ApiController]
[Route("api/feasibility")]
public class FeasibilityController : ControllerBase
{
    private readonly FeasibilityService _service;

    public FeasibilityController(FeasibilityService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> Get([FromQuery] FeasibilityRequest request)
    {
        var result = await _service.Get(
            request.Latitude!.Value,
            request.Longitude!.Value,
            request.Radius!.Value
        );

        var paged = result
            .Skip((request.Page - 1) * 20)
            .Take(20)
            .ToList();

        return Ok(paged);
    }
}