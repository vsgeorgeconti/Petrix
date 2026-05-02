using Petrix.Application.Common;
using Petrix.Application.DTOs.Pet;
using Petrix.Application.Repositories;

namespace Petrix.Application.UseCases.Pet
{
    public class UpdatePetUseCase
    {
        private readonly IPetRepository _petRepository;
        public UpdatePetUseCase(IPetRepository petRepository)
        {
            _petRepository = petRepository;
        }
        public async Task<ApiResponse<PetResponse>> UpdatePet(Guid id, UpdatePetRequest request)
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

            pet.Name = request.Name;
            pet.BirthDate = request.BirthDate;
            pet.Breed = request.Breed;
            pet.Notes = request.Notes;
            pet.Weight = request.Weight;
            pet.UpdatedAt = DateTime.UtcNow;

            _petRepository.Update(pet);
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

            return new ApiResponse<PetResponse>(
                true,
                "SUCCESS",
                response,
                "Pet atualizado com sucesso."
            );
        }
    }
}