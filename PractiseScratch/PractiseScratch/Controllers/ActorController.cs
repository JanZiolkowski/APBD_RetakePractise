using Microsoft.AspNetCore.Mvc;
using PractiseScratch.Dtos.Request;
using PractiseScratch.Exceptions;
using PractiseScratch.Services.Interfaces;

namespace PractiseScratch.Controllers;
[Route("api/actors")]
[ApiController]
public class ActorController:ControllerBase
{
    private IActorService _actorService;

    public ActorController(IActorService actorService)
    {
        _actorService = actorService;
    }

    [HttpPost]
    public async Task<IActionResult> MapActorToMovie([FromBody]MapDTO mapDto)
    {
        try
        {
            await _actorService.AssignActorToMovie(mapDto);
            return NoContent();
        }
        catch (NotFoundException e)
        {
            return NotFound(e.Message);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }

    }
}