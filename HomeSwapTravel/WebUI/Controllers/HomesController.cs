using HomeSwapTravel.Application.Common.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using HomeSwapTravel.Application.Homes.Commands.CreateHome;
using HomeSwapTravel.Application.Homes.Commands.DeleteHome;
using HomeSwapTravel.Application.Homes.Commands.UpdateHome;
using HomeSwapTravel.Application.Homes.Queries.GetHome;
using HomeSwapTravel.Application.Homes.Queries.GetHomesWithPagination;

namespace HomeSwapTravel.WebUI.Controllers;

[Authorize]
public class HomesController : ApiControllerBase
{
    [HttpGet("{id}")]
    public async Task<ActionResult<HomeDto>> GetHome([FromQuery] GetHomeQuery query)
    {
        return await Mediator.Send(query);
    }
    
    [HttpGet]
    public async Task<ActionResult<PaginatedList<HomeBriefDto>>> GetHomesWithPagination([FromQuery] GetHomesWithPaginationQuery query)
    {
        return await Mediator.Send(query);
    }
    
    [HttpPost]
    public async Task<ActionResult<int>> Create(CreateHomeCommand command)
    {
        return await Mediator.Send(command);
    }
    
    [HttpPut("{id}")]
    public async Task<ActionResult> Update(int id, UpdateHomeCommand command)
    {
        if (id != command.HomeId)
        {
            return BadRequest();
        }

        await Mediator.Send(command);

        return NoContent();
    }
    
    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        await Mediator.Send(new DeleteHomeCommand(id));

        return NoContent();
    }
}