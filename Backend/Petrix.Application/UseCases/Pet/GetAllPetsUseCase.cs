using Petrix.Application.Common;
using Petrix.Application.DTOs.Pet;
using Petrix.Application.Repositories;

namespace Petrix.Application.UseCases.Pet
{
    public class GetAllPetsUseCase
    {
        private readonly IPetRepository _petRepository;
        public GetAllPetsUseCase(IPetRepository petRepository)
        {
            _petRepository = petRepository;
        }
        
        public async Task<ApiResponse<IEnumerable<PetResponse>>> GetAllAsync()
        {
            var pets = await _petRepository.GetAllAsync();
            if(pets is null)
                return new ApiResponse<IEnumerable<PetResponse>>(false,"NOT_FOUND", null, "Pets não encontrados.");

            var response = pets.Select(p => new PetResponse
            {
                Id = p.Id,
                BirthDate = p.BirthDate,
                Breed = p.Breed,
                CustomerId = p.CustomerId,
                IsActive = p.IsActive,
                Name = p.Name,
                Notes = p.Notes,
                Species = p.Species.ToString(),
                Weight = p.Weight
            });
            
            return new ApiResponse<IEnumerable<PetResponse>>(true,"SUCCESS", response, "Pets encontrados.");
        }
    }
}