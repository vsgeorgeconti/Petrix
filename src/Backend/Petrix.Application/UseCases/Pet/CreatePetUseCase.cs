using Petrix.Application.Common;
using Petrix.Application.DTOs.Pet;
using Petrix.Application.Repositories;
using Petrix.Domain.Enums;

namespace Petrix.Application.UseCases.Pet
{
    public class CreatePetUseCase
    {
        private readonly IPetRepository _petRepository;
        private readonly ICustomerRepository _customerRepository;
        public CreatePetUseCase(IPetRepository petRepository, ICustomerRepository customerRepository)
        {
            _petRepository = petRepository;
            _customerRepository = customerRepository;
        }

        public async Task<ApiResponse<PetResponse>> CreatePet(CreatePetRequest request)
        {
            if (request is null)
                return new ApiResponse<PetResponse>(false, "NO_CONTENT", null, "Requisição está em branco.");

            if (string.IsNullOrWhiteSpace(request.Name))
                return new ApiResponse<PetResponse>(false, "NOT_FOUND", null, "Nome do pet está em branco.");

            if (request.CustomerId == Guid.Empty)
                return new ApiResponse<PetResponse>(false, "NOT_FOUND", null, "Dono do pet está em branco.");

            var customer = await _customerRepository.GetByIdAsync(request.CustomerId);
            if (customer is null)
                return new ApiResponse<PetResponse>(false, "NOT_FOUND", null, "Dono do pet não encontrado.");

            if (!Enum.TryParse<Species>(request.Species, ignoreCase: true, out var species))
            {
                return new ApiResponse<PetResponse>(false, "INVALID_SPECIES", null, "Espécie inválida.");
            }

            var pet = Domain.Entities.Pet.Create(request.Name, species, request.Breed, request.BirthDate, request.Weight, request.Notes, customer.Id);

            await _petRepository.AddAsync(pet);
            await _petRepository.SaveChangesAsync();

            var response = new PetResponse
            {
                Id = pet.Id,
                Name = pet.Name,
                BirthDate = pet.BirthDate,
                Breed = pet.Breed,
                CustomerId = pet.CustomerId,
                IsActive = pet.IsActive,
                Notes = pet.Notes,
                Species = pet.Species.ToString(),
                Weight = pet.Weight
            };

            return new ApiResponse<PetResponse>(true, "SUCCESS", response, "Pet cadastrado com sucesso.");
        }
    }
}