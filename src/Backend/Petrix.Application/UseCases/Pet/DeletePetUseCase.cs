using Petrix.Application.Common;
using Petrix.Application.DTOs.Pet;
using Petrix.Application.Repositories;

namespace Petrix.Application.UseCases.Pet
{
    public class DeletePetUseCase
    {
        private readonly IPetRepository _petRepository;
        public DeletePetUseCase(IPetRepository petRepository)
        {
            _petRepository = petRepository;
        }
        public async Task<ApiResponse<PetResponse>> DeletePet(Guid id)
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

            _petRepository.Delete(pet);
            await _petRepository.SaveChangesAsync();

            return new ApiResponse<PetResponse>(
                true,
                "SUCCESS",
                null,
                "Pet deletado com sucesso."
            );
        }

    }
}