using Petrix.Application.Common;
using Petrix.Application.DTOs.Customer;
using Petrix.Application.Repositories;

namespace Petrix.Application.UseCases.Customer
{
    public class GetCustomerByIdUseCase
    {
        private readonly ICustomerRepository _customerRepository;

        public GetCustomerByIdUseCase(ICustomerRepository customerRepository)
        {
            this._customerRepository = customerRepository;
        }

        public async Task<ApiResponse<CustomerResponse>> GetCustomerById(Guid Id)
        {
            var customer = await _customerRepository.GetByIdAsync(Id);

            if (customer is null)
            {
                return new ApiResponse<CustomerResponse>(false, "NOT_FOUND", null, "Cliente não encontrado.");
            }

            var response = new CustomerResponse
            {
                Id = customer.Id,
                Name = customer.Name,
                DocumentNumber = customer.DocumentNumber,
                Email = customer.Email,
                Phone = customer.Phone,
                IsActive = customer.IsActive
            };

            return new ApiResponse<CustomerResponse>(true, "SUCESS", response, "Cliente encontrado com sucesso.");

        }


    }
}