using Blazor.Domain.Interfaces.Entities;

namespace Blazor.Domain.Entities
{
    public class BaseEntity : IBaseEntity
    {
        public long Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
