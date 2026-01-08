using Catalog.Application.Tracks.Commands;
using Catalog.Application.Tracks.Queries;
using Microsoft.AspNetCore.Mvc;

namespace Catalog.Controllers;

public class TracksController : ApiControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetTracks(CancellationToken cancellationToken)
    {
        return Ok(await Mediator.Send(new GetTraksQuery(), cancellationToken));
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Delete([FromRoute] Guid id, CancellationToken cancellationToken)
    {
        await Mediator.Send(new DeleteTrackCommand(id), cancellationToken);

        return NoContent();
    }
}
