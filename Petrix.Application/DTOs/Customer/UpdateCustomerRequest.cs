namespace Petrix.Application.DTOs.Customer
{
    public class UpdateCustomerRequest
    {
        public string Name { get; set; } = null!;
        public string? Email { get; set; }
        public string? Phone { get; set; }
    }
}