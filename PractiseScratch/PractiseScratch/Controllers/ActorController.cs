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

    [HttpDelete("remove/{idActor:int}")]
    public async Task<IActionResult> RemovedAssignedActor(int idActor)
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

    [HttpPut("update/{idActor:int}")]
    public async Task<IActionResult> ChangeActor([FromBody]ActorUpdateDTO actorUpdateDto,int idActor)
    {
        try
        {
            await _actorService.ChangeActor(idActor, actorUpdateDto);
            return NoContent();
        }
        catch (NotFoundException e)
        {
            return NotFound(e.Message);
        }
        catch (Exception e)
        {
            return Conflict(e.Message);
        }
    }

    [HttpGet("list")]
    public async Task<IActionResult> GetListOfActors([FromQuery]string? name,[FromQuery] string? surname)
    {
        try
        {
            var listOfActors = await _actorService.GetListOfAllActors(name,surname);
            return Ok(listOfActors);
        }
        catch (NotFoundException e)
        {
            return NotFound(e.Message);
        }
        catch (BadRequestException e)
        {
            return BadRequest(e.Message);
        }
        catch (Exception e)
        {
            return Conflict(e.Message);
        }
    }
}