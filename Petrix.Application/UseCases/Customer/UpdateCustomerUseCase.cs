using Petrix.Application.Common;
using Petrix.Application.DTOs.Customer;
using Petrix.Application.Repositories;

namespace Petrix.Application.UseCases.Customer
{
    public class UpdateCustomerUseCase
    {
        private readonly ICustomerRepository _customerRepository;
        public UpdateCustomerUseCase(ICustomerRepository customerRepository)
        {
            this._customerRepository = customerRepository;
        }
        public async Task<ApiResponse<CustomerResponse>> Update(Guid id, UpdateCustomerRequest updateCustomerRequest)
        {
            if(updateCustomerRequest is null)
                return new ApiResponse<CustomerResponse>(false, "NO_CONTENT", null, "Corpo da requisição está em branco.");


            var customer = await _customerRepository.GetByIdAsync(id);
            if(customer is null)
                return new ApiResponse<CustomerResponse>(false,"NOT_FOUND", null, "Cliente não encontrado");

            customer.Name = updateCustomerRequest.Name;
            customer.Email = updateCustomerRequest.Email ?? customer.Email;
            customer.Phone = updateCustomerRequest.Phone ?? customer.Phone;
            customer.UpdatedAt = DateTime.UtcNow;
            
            _customerRepository.Update(customer);
            await _customerRepository.SaveChangesAsync();

            var response = new CustomerResponse
            {
              Id = customer.Id,
              Name = customer.Name,
              DocumentNumber = customer.DocumentNumber,
              Phone = customer.Phone,
              Email = customer.Email,
              IsActive = customer.IsActive
            };
          
            return  new ApiResponse<CustomerResponse>(true, "SUCCESS", response, "Cliente atualizado com sucesso.");
        }
    }
}