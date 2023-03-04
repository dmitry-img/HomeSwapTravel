using System.ComponentModel.DataAnnotations.Schema;

namespace HomeSwapTravel.Domain.Common;

public abstract class BaseEntity
{
    public int Id { get; set; }
}
