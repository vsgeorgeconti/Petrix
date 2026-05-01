using Petrix.Application.Common;
using Petrix.Application.DTOs.Pet;
using Petrix.Application.Repositories;

namespace Petrix.Application.UseCases.Pet
{
    public class GetPetByIdUseCase
    {
        private readonly IPetRepository _petRepository;
        public GetPetByIdUseCase(IPetRepository petRepository)
        {
            _petRepository = petRepository;
        }

        public async Task<ApiResponse<PetResponse>> GetById(Guid id)
        {
            var pet = await _petRepository.GetByIdAsync(id);
            if (pet is null)
            {
                return new ApiResponse<PetResponse>(
                   false,
                    "NOT_FOUND",
                    null,
                    "Pet não encontrado."
                );
            }

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

            return new ApiResponse<PetResponse>(
                true,
                "SUCCESS",
                Data: response,
                Message: "Pet encontrado com sucesso."
            );
        }
    }
}