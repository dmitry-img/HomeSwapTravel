using System.Runtime.Serialization;
using Application.Common.Models;
using Application.Requests.Queries;
using Application.Reviews;
using AutoMapper;
using HomeSwapTravel.Application.Common.Mappings;
using HomeSwapTravel.Application.Homes.Commands.CreateHome;
using HomeSwapTravel.Application.Homes.Commands.UpdateHome;
using HomeSwapTravel.Application.Homes.Queries.GetHome;
using HomeSwapTravel.Application.Homes.Queries.GetHomesWithPagination;
using HomeSwapTravel.Application.Requests.Commands.CreateRequest;
using HomeSwapTravel.Application.Reviews.Commands.CreateReview;
using HomeSwapTravel.Domain.Entities;
using Microsoft.Extensions.DependencyInjection.Models;

namespace HomeSwapTravel.Application.UnitTests.Common.Mappings;

public class MappingTests
{
    private readonly IConfigurationProvider _configuration;
    private readonly IMapper _mapper;

    public MappingTests()
    {
        _configuration = new MapperConfiguration(config =>
            config.AddProfile<MappingProfile>());

        _mapper = _configuration.CreateMapper();
    }

    [Test]
    public void ShouldHaveValidConfiguration()
    {
        _configuration.AssertConfigurationIsValid();
    }

    [Test]
    [TestCase(typeof(CreateHomeCommand), typeof(Home))]
    [TestCase(typeof(UpdateHomeCommand), typeof(Home))]
    [TestCase(typeof(Home), typeof(HomeDto))]
    [TestCase(typeof(Home), typeof(HomeBriefDto))]
    [TestCase(typeof(CreateRequestCommand), typeof(Request))]
    [TestCase(typeof(Request), typeof(RequestDto))]
    [TestCase(typeof(CreateReviewCommand), typeof(Review))]
    [TestCase(typeof(Review), typeof(ReviewDto))]
    [TestCase(typeof(HomeOwner), typeof(HomeOwnerDto))]

    public void ShouldSupportMappingFromSourceToDestination(Type source, Type destination)
    {
        var instance = GetInstanceOf(source);

        _mapper.Map(instance, source, destination);
    }

    private object GetInstanceOf(Type type)
    {
        if (type.GetConstructor(Type.EmptyTypes) != null)
            return Activator.CreateInstance(type)!;

        // Type without parameterless constructor
        return FormatterServices.GetUninitializedObject(type);
    }
}
