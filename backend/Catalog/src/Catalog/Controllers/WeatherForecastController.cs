using Catalog.Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using Catalog.Application.Tracks.Dtos;
using Catalog.Application.Playlists.Dtos;

namespace Catalog.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    public WeatherForecastController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<IActionResult>  Get(CancellationToken cancellationToken)
    {
        var tracks = await _unitOfWork.Playlists.Query().Include(p => p.PlaylistTracks).ThenInclude(pl => pl.Track).ToListAsync();

        var result = _mapper.Map<List<PlaylistDto>>(tracks);

        await _unitOfWork.SaveAsync(cancellationToken);

        return Ok(result);
    }
}
