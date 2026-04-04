namespace Petrix.Application.DTOs.Auth
{
    public class RegisterResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public string Email { get; set; } = null!;

        public RegisterResponse(Guid id, string name, string email)
        {
            Id = id;
            Name = name;
            Email = email;
        }
    }
}