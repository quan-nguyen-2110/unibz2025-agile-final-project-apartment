using Application.Apartments.Commands;
using Application.Apartments.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ApartmentController(IMediator mediator) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAll()
        => Ok(await mediator.Send(new GetAllApartmentsQuery()));

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
        => Ok(await mediator.Send(new GetApartmentByIdQuery(id)));

    [HttpPost]
    public async Task<IActionResult> Create(CreateApartmentCommand cmd)
        => Ok(await mediator.Send(cmd));

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, UpdateApartmentCommand cmd)
    {
        if (id != cmd.Id) return BadRequest("ID mismatch");
        await mediator.Send(cmd);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await mediator.Send(new DeleteApartmentCommand(id));
        return NoContent();
    }
}
