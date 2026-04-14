using Petrix.Domain.Enums;

namespace Petrix.Domain.Entities
{
    public class Role : BaseEntity
    {
        public string Description { get; set; } = null!;
        public AccessLevel AccessLevel {get; set;}        
        
    }
}