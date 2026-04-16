namespace Petrix.Application.DTOs.Pet
{
    public class CreatePetRequest
    {
        public string Name { get; set; } = null!;
        public string Species { get; set; } = null!;
        public string? Breed { get; set; }
        public DateTime? BirthDate { get; set; }
        public decimal? Weight { get; set; }
        public string? Notes { get; set; }
        public Guid CustomerId { get; set; }
    }
}