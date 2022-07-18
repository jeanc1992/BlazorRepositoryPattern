namespace Blazor.Domain.Interfaces.Entities
{
    public interface IBaseEntity
    {
        long Id { get; set; }
        DateTime CreatedAt { get; set; }
        DateTime? UpdatedAt { get; set; }
    }
}
