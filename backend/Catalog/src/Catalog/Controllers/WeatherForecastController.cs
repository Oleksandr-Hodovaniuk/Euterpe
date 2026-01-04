using Catalog.Application.Interfaces;
using Catalog.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Catalog.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{
    private readonly IUnitOfWork _unitOfWork;

    public WeatherForecastController(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;   
    }
    private static readonly string[] Summaries =
    [
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    ];

    [HttpGet]
    public async Task<IEnumerable<Track>>  Get()
    {
        return await _unitOfWork.Tracks.GetAllAsync();
    }
}
