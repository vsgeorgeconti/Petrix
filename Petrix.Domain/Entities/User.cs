
namespace Petrix.Domain.Entities
{
    public class User : BaseEntity
    {
        //public Company CompanyId {get; set;}
        //public Role RoleId { get; set; }
        //public string DocumentNumber { get; set; } = null!;
        //public DateTime BirthDate { get; set; }
        //public string? Phone { get; set; }
        //public ServiceTier ServiceTier { get; set; }

        public string Name { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string PasswordHash { get; set; } = null!;

        public static User Create(string name, string email, string passwordHash)
        {
            return new User
            {
                Id = Guid.NewGuid(),
                Name = name,
                Email = email,
                PasswordHash = passwordHash,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,
                IsActive = true,
            };

        }
    }
}