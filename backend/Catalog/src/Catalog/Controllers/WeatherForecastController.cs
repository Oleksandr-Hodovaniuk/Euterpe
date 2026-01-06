using Catalog.Application.Interfaces;
using Microsoft.EntityFrameworkCore;
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
    public async Task<IActionResult>  Get(CancellationToken cancellationToken)
    {
        var tracks = await _unitOfWork.PlaylistTracks
            .Query()
            .OrderBy(pt => pt.AddedAt)
            .Select(pt => pt.Track)
            .ToListAsync();


        await _unitOfWork.SaveAsync(cancellationToken);

        return Ok(tracks);
    }
}
