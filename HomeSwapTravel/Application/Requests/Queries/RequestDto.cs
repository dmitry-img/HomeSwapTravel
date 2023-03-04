using AutoMapper;
using HomeSwapTravel.Application.Common.Mappings;
using HomeSwapTravel.Application.Homes.Queries.GetHomesWithPagination;
using HomeSwapTravel.Domain.Entities;
using HomeSwapTravel.Domain.Enums;
using Microsoft.Extensions.DependencyInjection.Models;

namespace Application.Requests.Queries;

public class RequestDto : IMapFrom<Request>
{
    public string? SenderId { get; set; }
    public DateTime RequestDate { get; set; }
    public RequestStatus Status { get; set; }
    public DateTime From { get; set; }
    public DateTime To { get; set; }
    //public int HomeId { get; set; }
    //public HomeBriefDto? Home { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<Request, RequestDto>()
            .ForMember(dest => dest.From, opt => opt.MapFrom(src => src.AvailablePeriod.Period.From))
            .ForMember(dest => dest.To, opt => opt.MapFrom(src => src.AvailablePeriod.Period.To));
    }
}