using AutoMapper;
using HomeSwapTravel.Application.Common.Mappings;
using HomeSwapTravel.Domain.Entities;
using HomeSwapTravel.Domain.Enums;
using Microsoft.Extensions.DependencyInjection.Models;

namespace HomeSwapTravel.Application.Homes.Queries.GetHomesWithPagination;

public class HomeBriefDto : IMapFrom<Home>
{
    public string? Title { get; set; }
    public HomeRating Rating { get; set; }
}