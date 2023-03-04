using HomeSwapTravel. Application.Common.Interfaces.Persistence;
using AutoMapper;
using HomeSwapTravel.Application.Common.Exceptions;
using HomeSwapTravel.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace HomeSwapTravel.Application.Reviews.Commands.UpdateReviewContent;

public record UpdateReviewCommand(int ReviewId, string Content) : IRequest<Unit>;

public class UpdateReviewCommandHandler : IRequestHandler<UpdateReviewCommand, Unit>
{
    private readonly IReviewRepository _reviewRepository;
    private readonly IMapper _mapper;

    public UpdateReviewCommandHandler(IReviewRepository reviewRepository, IMapper mapper)
    {
        _reviewRepository = reviewRepository;
        _mapper = mapper;
    }

    public async Task<Unit> Handle(UpdateReviewCommand request, CancellationToken cancellationToken)
    {
        var review = await _reviewRepository.GetAsync(request.ReviewId);

        if (review == null)
        {
            throw new NotFoundException(nameof(Review), request.ReviewId);
        }

        await _reviewRepository.UpdateContentAsync(review, request.Content);
        
        return Unit.Value;
    }
}
