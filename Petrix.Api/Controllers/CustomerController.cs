using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Petrix.Application.DTOs.Customer;
using Petrix.Application.UseCases.Customer;

namespace Petrix.Api.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/v1/customers")]
    public class CustomerController : ControllerBase
    {
        private readonly CreateCustomerUseCase _createCustomerUseCase;
        private readonly UpdateCustomerUseCase _updateCustomerUseCase;
        private readonly DeleteCustomerUseCase _deleteCustomerUseCase;
        private readonly GetCustomerByIdUseCase _getCustomerByIdUseCase;
        private readonly GetAllCustomersUseCase _getAllCustomersUseCase;

        public CustomerController(CreateCustomerUseCase createCustomerUseCase, UpdateCustomerUseCase updateCustomerUseCase, DeleteCustomerUseCase deleteCustomerUseCase, GetCustomerByIdUseCase getCustomerByIdUseCase, GetAllCustomersUseCase getAllCustomersUseCase)
        {
            _createCustomerUseCase = createCustomerUseCase;
            _updateCustomerUseCase = updateCustomerUseCase;
            _deleteCustomerUseCase = deleteCustomerUseCase;
            _getAllCustomersUseCase = getAllCustomersUseCase;
            _getCustomerByIdUseCase = getCustomerByIdUseCase;
        }

        [HttpPost]
        public async Task<IActionResult> CreateCustomer([FromBody] CreateCustomerRequest request)
        {
            var result = await _createCustomerUseCase.CreateCustomer(request);

            if (result.Success == true)
                return Created();
            if (result.Code == "NOT_FOUND")
                return NotFound();
            if (result.Code == "DOCUMENT_EXISTS")
                return Conflict();

            return BadRequest();
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCustomer(Guid id, [FromBody] UpdateCustomerRequest request)
        {
            var result = await _updateCustomerUseCase.Update(id, request);

            if (result.Success == true)
                return Ok();
            if (result.Code == "NO_CONTENT")
                return NoContent();
            if (result.Code == "NOT_FOUND")
                return NotFound();

            return BadRequest();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCustomer(Guid id)
        {
            var result = await _deleteCustomerUseCase.Delete(id);

            if (result.Success == true)
                return Ok();
            if (result.Code == "NOT_FOUND")
                return NotFound();

            return BadRequest();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCustomerById(Guid id)
        {
            var result = await _getCustomerByIdUseCase.GetCustomerById(id);
            if (result.Success == true)
                return Ok();
            if (result.Code == "NOT_FOUND")
                return NotFound();

            return BadRequest();
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCustomers()
        {
            var result = await _getAllCustomersUseCase.GetAllAsync();
            if (result.Success == true)
                return Ok();
            if (result.Code == "NOT_FOUND")
                return NotFound();
            return BadRequest();
        }




    }
}