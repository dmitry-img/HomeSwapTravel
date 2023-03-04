using AutoMapper;
using HomeSwapTravel.Application.Common.Mappings;
using HomeSwapTravel.Domain.Entities;
using HomeSwapTravel.Domain.Enums;

namespace Application.Reviews;

public class ReviewDto : IMapFrom<HomeReview>
{
    public int ReviewId { get; set; }
    public string ReviewerId { get; set; }
    public DateTime ReviewDate { get; set; }
    public HomeRating Rating { get; set; }
    public string? Content { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<HomeReview, ReviewDto>()
            .ForMember(dest => dest.ReviewId, opt => opt.MapFrom(src => src.ReviewId))
            .ForMember(dest => dest.ReviewDate, opt => opt.MapFrom(src => src.Review.ReviewDate))
            .ForMember(dest => dest.Rating, opt => opt.MapFrom(src => src.Review.Rating))
            .ForMember(dest => dest.Content, opt => opt.MapFrom(src => src.Review.Content))
            .ForMember(dest => dest.ReviewerId, opt => opt.Ignore());

        profile.CreateMap<Review, ReviewDto>()
            .ForMember(dest => dest.ReviewId, opt => opt.MapFrom(src => src.Id));
    }
}