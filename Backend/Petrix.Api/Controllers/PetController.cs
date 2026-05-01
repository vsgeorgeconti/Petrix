using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Petrix.Application.DTOs.Pet;
using Petrix.Application.UseCases.Pet;

namespace Petrix.Api.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/v1/pets")]
    public class PetController : ControllerBase
    {
        private readonly CreatePetUseCase _createPetUseCase;
        private readonly GetPetByIdUseCase _getPetByIdUseCase;
        private readonly GetAllPetsUseCase _getAllPetsUseCase;
        private readonly UpdatePetUseCase _updatePetUseCase;
        private readonly DeletePetUseCase _deletePetUseCase;

        private readonly GetPetsByCustomerIdUseCase _getPetsByCustomerIdUseCase;

        public PetController(CreatePetUseCase createPetUseCase, GetPetByIdUseCase getPetByIdUseCase, GetAllPetsUseCase getAllPetsUseCase, UpdatePetUseCase updatePetUseCase, DeletePetUseCase deletePetUseCase, GetPetsByCustomerIdUseCase getPetsByCustomerIdUseCase)
        {
            _createPetUseCase = createPetUseCase;
            _getPetByIdUseCase = getPetByIdUseCase;
            _getAllPetsUseCase = getAllPetsUseCase;
            _updatePetUseCase = updatePetUseCase;
            _deletePetUseCase = deletePetUseCase;
            _getPetsByCustomerIdUseCase = getPetsByCustomerIdUseCase;
        }

        [HttpPost]
        public async Task<IActionResult> CreatePet([FromBody] CreatePetRequest request)
        {
            var result = await _createPetUseCase.CreatePet(request);
            if (result.Success == true)
                return Ok(result);
            if (result.Code == "NOT_FOUND")
                return NotFound(result);

            return BadRequest(result);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPetById(Guid id)
        {
            var result = await _getPetByIdUseCase.GetById(id);
            if (result.Success == true)
                return Ok(result);
            if (result.Code == "NOT_FOUND")
                return NotFound(result);

            return BadRequest(result);
        }
        [HttpGet]
        public async Task<IActionResult> GetAllPets()
        {
            var result = await _getAllPetsUseCase.GetAllAsync();
            if (result.Success == true)
                return Ok(result);
            if (result.Code == "NOT_FOUND")
                return NotFound(result);

            return BadRequest(result);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePet(Guid id, [FromBody] UpdatePetRequest request)
        {
            var result = await _updatePetUseCase.UpdatePet(id, request);
            if (result.Success == true)
                return Ok(result);
            if (result.Code == "NOT_FOUND")
                return NotFound(result);

            return BadRequest(result);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePet(Guid id)
        {
            var result = await _deletePetUseCase.DeletePet(id);
            if (result.Success == true)
                return Ok(result);
            if (result.Code == "NOT_FOUND")
                return NotFound(result);

            return BadRequest(result);
        }
        [HttpGet("customer/{customerId}")]
        public async Task<IActionResult> GetPetsByCustomerId(Guid customerId)
        {
            var result = await _getPetsByCustomerIdUseCase.GetByCustomerId(customerId);
            if (result.Success == true)
                return Ok(result);
            if (result.Code == "NOT_FOUND")
                return NotFound(result);

            return BadRequest(result);
        }
    }
}