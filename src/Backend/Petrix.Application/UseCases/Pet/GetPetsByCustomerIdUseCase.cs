using Petrix.Application.Common;
using Petrix.Application.DTOs.Pet;
using Petrix.Application.Repositories;

namespace Petrix.Application.UseCases.Pet
{
    public class GetPetsByCustomerIdUseCase
    {
        private readonly IPetRepository _petRepository;
        private readonly ICustomerRepository _customerRepository;

        public GetPetsByCustomerIdUseCase(IPetRepository petRepository, ICustomerRepository customerRepository)
        {
            _petRepository = petRepository;
            _customerRepository = customerRepository;
        }

        public async Task<ApiResponse<IEnumerable<PetResponse>>> GetByCustomerId(Guid customerId)
        {
            var customer = await _customerRepository.GetByIdAsync(customerId);
            if (customer is null)
            {
                return new ApiResponse<IEnumerable<PetResponse>>(
                    false,
                    "NOT_FOUND",
                    null,
                    "Cliente não encontrado."
                );
            }

            var pets = await _petRepository.GetPetsByCustomerIdAsync(customerId);
            if (pets is null)
            {
                return new ApiResponse<IEnumerable<PetResponse>>(
                    false,
                    "NOT_FOUND",
                    null,
                    "Nenhum pet encontrado para este cliente."
                );
            }

            var response = pets.Select(p => new PetResponse
            {
                Id = p.Id,
                Name = p.Name,
                BirthDate = p.BirthDate,
                Breed = p.Breed,
                CustomerId = p.CustomerId,
                IsActive = p.IsActive,
                Notes = p.Notes,
                Species = p.Species.ToString(),
                Weight = p.Weight
            });

            return new ApiResponse<IEnumerable<PetResponse>>(
                true,
                "SUCCESS",
                response,
                "Pets encontrados com sucesso."
            );
        }
    }
}