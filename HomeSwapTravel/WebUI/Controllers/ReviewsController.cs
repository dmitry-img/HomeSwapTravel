using HomeSwapTravel.Application.Common.Models;
using HomeSwapTravel.WebUI.Controllers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using HomeSwapTravel.Application.Reviews.Commands.CreateReview;
using HomeSwapTravel.Application.Reviews.Commands.UpdateReviewContent;

namespace WebUI.Controllers;

[Authorize]
public class ReviewsController : ApiControllerBase
{
    [HttpPost]
    public async Task<ActionResult<int>> Create(CreateReviewCommand command)
    {
        return await Mediator.Send(command);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> Update(int id, UpdateReviewCommand command)
    {
        if (id != command.ReviewId)
        {
            return BadRequest();
        }

        await Mediator.Send(command);

        return NoContent();
    }
}
