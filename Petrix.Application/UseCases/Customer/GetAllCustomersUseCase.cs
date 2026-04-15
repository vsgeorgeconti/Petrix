using Petrix.Application.Common;
using Petrix.Application.DTOs.Customer;
using Petrix.Application.Repositories;

namespace Petrix.Application.UseCases.Customer
{
    public class GetAllCustomersUseCase
    {
        private readonly ICustomerRepository _customerRepository;
        public GetAllCustomersUseCase(ICustomerRepository customerRepository)
        {
            this._customerRepository = customerRepository;
        }

        public async Task<ApiResponse<IEnumerable<CustomerResponse>>> GetAllAsync()
        {
            var customers = await _customerRepository.GetAllAsync();
            if (customers is null)
                return new ApiResponse<IEnumerable<CustomerResponse>>(false, "NOT_FOUND", null, "Nenhum cliente encontrado.");


            var responses = customers.Select(c => new CustomerResponse
            {
                Id = c.Id,
                Name = c.Name,
                DocumentNumber = c.DocumentNumber,
                Phone = c.Phone,
                Email = c.Email,
                IsActive = c.IsActive
            });

            return new ApiResponse<IEnumerable<CustomerResponse>>(true,"SUCESS", responses, "Clientes encontrados.");
        }

    }
}