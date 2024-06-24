using System.Net;
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

    [HttpPost("map")]
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
    [HttpPost("add")]
    public async Task<IActionResult> AddActor([FromBody] NewActorDTO newActorDto)
    {
        try
        {
            int Id = await _actorService.AddActorAsync(newActorDto);
            return Ok(Id);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpDelete("remove/{idActor}")]
    public async Task<IActionResult> RemoveActor([FromHeader] int idActor)
    {
        try
        {
            await _actorService.RemoveActorAsync(idActor);
            return NoContent();
        }
        catch (BadRequestException e)
        {
            return BadRequest(e.Message);
        }
        catch (Exception e)
        {
            return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
        }
    }
}