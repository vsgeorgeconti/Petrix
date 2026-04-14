using Petrix.Domain.Enums;

namespace Petrix.Domain.Entities
{
    public class Pet : BaseEntity
    {
        public string Name { get; set; } = null!;
        public Species Species { get; set; }
        public string? Breed { get; set; }
        public DateTime? BirthDate { get; set; }
        public decimal? Weight { get; set; }
        public string? Notes { get; set; }
        public Guid CustomerId { get; set; }
        public Customer Customer { get; set; } = null!;

        public static Pet Create(string name, Species species, string? breed, DateTime? bithdate, decimal? weight, string? notes, Guid customerId)
        {
            return new Pet
            {
                Id = Guid.NewGuid(),
                Name = name,
                Species = species,
                Breed = breed,
                BirthDate = bithdate,
                Weight = weight,
                Notes = notes,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,
                IsActive = true,
                CustomerId = customerId
            };
        }


    }
}