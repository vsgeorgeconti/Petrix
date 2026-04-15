using Petrix.Application.Common;
using Petrix.Application.DTOs.Customer;
using Petrix.Application.Repositories;

namespace Petrix.Application.UseCases.Customer
{
    public class CreateCustomerUseCase
    {
        private readonly ICustomerRepository _customerRepository;
        public CreateCustomerUseCase(ICustomerRepository customerRepository)
        {
            this._customerRepository = customerRepository;
        }

        public async Task<ApiResponse<CustomerResponse>> CreateCustomer (CreateCustomerRequest createCustomerRequest)
        {
            if(createCustomerRequest is null)
                return new ApiResponse<CustomerResponse>(false, "NO_CONTENT", null, "Corpo da requisição está em branco.");

            if (string.IsNullOrWhiteSpace(createCustomerRequest.DocumentNumber))
                return new ApiResponse<CustomerResponse>(false, "NOT_FOUND", null, "Favor digitar o documento do cliente.");

            if (string.IsNullOrWhiteSpace(createCustomerRequest.Name))
                return new ApiResponse<CustomerResponse>(false, "NOT_FOUND", null, "Favor digitar o nome do cliente.");

            var exists = _customerRepository.GetByDocumentNumberAsync(createCustomerRequest.DocumentNumber);

            if (exists is not null)
                return new ApiResponse<CustomerResponse>(false, "DOCUMENT_EXISTS", null, "Documento já cadastrado, favor verificar.");

            var customer = Domain.Entities.Customer.Create(createCustomerRequest.Name, createCustomerRequest.DocumentNumber, createCustomerRequest.Email, createCustomerRequest.Phone);

            await _customerRepository.AddAsync(customer);
            await _customerRepository.SaveChangesAsync();

            var response = new CustomerResponse { 
                Id = customer.Id, 
                Name = customer.Name, 
                DocumentNumber = customer.DocumentNumber, 
                Email = customer.Email, 
                Phone = customer.Phone, 
                IsActive = customer.IsActive 
            };

            return new ApiResponse<CustomerResponse>(true, "SUCESS", response, "Cliente cadastrado com sucesso.");
        }
    }
}