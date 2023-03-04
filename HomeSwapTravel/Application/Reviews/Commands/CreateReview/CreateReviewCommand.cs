using HomeSwapTravel.Application.Common.Interfaces.Identity;
using HomeSwapTravel.Application.Common.Interfaces.Persistence;
using AutoMapper;
using HomeSwapTravel.Application.Common.Exceptions;
using HomeSwapTravel.Application.Common.Mappings;
using HomeSwapTravel.Domain.Entities;
using HomeSwapTravel.Domain.Enums;
using MediatR;
using Application.Common.Interfaces.Persistence;

namespace HomeSwapTravel.Application.Reviews.Commands.CreateReview;

public class CreateReviewCommand : IRequest<int>, IMapFrom<Review>
{
    public int HomeId { get; set; }
    public DateTime ReviewDate { get; set; }
    public HomeRating Rating { get; set; }
    public string? Content { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<CreateReviewCommand, Review>()
            .ForMember(dest => dest.Id, opt => opt.Ignore())
            .ForMember(dest => dest.ReviewerId, opt => opt.Ignore())
            .ForMember(dest => dest.HomeReviews, opt => opt.Ignore());
    }
}


public class CreateReviewCommandHandler : IRequestHandler<CreateReviewCommand, int>
{
    private readonly IHomeReviewRepository _homeReviewRepository;
    private readonly IMapper _mapper;
    private readonly ICurrentUserService _currentUserService;
    private readonly IHomeOwnerService _homeOwnerService;
    private readonly IHomeRepository _homeRepository;

    public CreateReviewCommandHandler(IHomeReviewRepository homeReviewRepository, IMapper mapper, ICurrentUserService currentUserService, IHomeOwnerService homeOwnerService, IHomeRepository homeRepository)
    {
        _homeReviewRepository = homeReviewRepository;
        _mapper = mapper;
        _currentUserService = currentUserService;
        _homeOwnerService = homeOwnerService;
        _homeRepository = homeRepository;
    }

    public async Task<int> Handle(CreateReviewCommand request, CancellationToken cancellationToken)
    {
        var homeOwner = await _homeOwnerService.GetHomeOwnerAsync(_currentUserService.UserId);

        bool? didCurrentUserVisitHome = homeOwner.VisitedHomes
            .Where(h => h.HomeId == request.HomeId) != null;

        if (didCurrentUserVisitHome is null || didCurrentUserVisitHome == false)
        {
            throw new ForbiddenAccessException();
        }
        
        Review review = _mapper.Map<Review>(request);
        review.ReviewerId = homeOwner.Id;

        var result = await _homeReviewRepository.AddAsync(new HomeReview() { Review = review, HomeId = request.HomeId });

        await _homeRepository.RecalculateRatingAsync(request.HomeId);

        return result.ReviewId;
    }
}