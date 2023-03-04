using HomeSwapTravel.WebUI.Controllers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using HomeSwapTravel.Application.Requests.Commands.CreateRequest;
using HomeSwapTravel.Application.Requests.Commands.DeleteRequest;
using HomeSwapTravel.Application.Requests.Commands.UpdateRequestState;
using HomeSwapTravel.Application.Requests.Queries.GetRequests;
using Application.Requests.Queries;
using Application.Requests.Queries.GetSentRequests;

namespace WebUI.Controllers;

[Authorize]
public class RequestsController : ApiControllerBase
{
    [HttpGet("Received")]
    public async Task<ActionResult<List<RequestDto>>> GetReceived()
    {
        return await Mediator.Send(new GetReceivedRequestsQuery());
    }

    [HttpGet("Sent")]
    public async Task<ActionResult<List<RequestDto>>> GetSent()
    {
        return await Mediator.Send(new GetSentRequestsQuery());
    }

    [HttpPost]
    public async Task<ActionResult<int>> Create(CreateRequestCommand command)
    {
        return await Mediator.Send(command);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> Update(int id, UpdateRequestStateCommand command)
    {
        if (id != command.RequestId)
        {
            return BadRequest();
        }
        
        await Mediator.Send(command);

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        await Mediator.Send(new DeleteRequestCommand(id));

        return NoContent();
    }
}
