using Domain.Entities;
using HomeSwapTravel.Domain.Common;
using HomeSwapTravel.Domain.Enums;

namespace HomeSwapTravel.Domain.Entities;

public class Request : BaseEntity
{
    public string? SenderId { get; set; }
    public string? ReceiverId { get; set; }
    public DateTime RequestDate { get; set; }
    public RequestStatus Status { get; set; }
    public int AvailablePeriodId { get; set; }
    public AvailablePeriod? AvailablePeriod { get; set; }
}