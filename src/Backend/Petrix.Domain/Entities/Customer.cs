using Petrix.Domain.Exceptions;
using Petrix.Domain.Utils;

namespace Petrix.Domain.Entities
{
    public class Customer : BaseEntity
    {
        public string Name { get; set; } = null!;
        public string DocumentNumber { get; set; } = null!;
        public string? Email { get; set; }
        public string? Phone { get; set; }    
        public ICollection<Pet> Pets { get; set; } = [];   

        public static Customer Create(string name, string documentNumber, string? email, string? phone)
        {
            
            if (!CpfValidator.IsValid(documentNumber))
                throw new ValidationException("CPF inválido.");
                
            return new Customer
            {
                Id = Guid.NewGuid(),
                Name = name,
                DocumentNumber = DocumentNumberFormatter.FormatCpf(documentNumber),
                Email = email,
                Phone = phone,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,
                IsActive = true   
            };
        }
    }
}