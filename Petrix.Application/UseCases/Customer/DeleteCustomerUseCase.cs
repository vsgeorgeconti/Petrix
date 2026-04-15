using Petrix.Application.Common;
using Petrix.Application.DTOs.Customer;
using Petrix.Application.Repositories;

namespace Petrix.Application.UseCases.Customer
{
    public class DeleteCustomerUseCase
    {
        private readonly ICustomerRepository _customerRepository;
        public DeleteCustomerUseCase(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public async Task<ApiResponse<CustomerResponse>> Delete(Guid id)
        {
            var customer = await _customerRepository.GetByIdAsync(id);
            if (customer is null)
                return new ApiResponse<CustomerResponse>(false, "NOT_FOUND", null, "Cliente não encontrado.");

            _customerRepository.Delete(customer);
            await _customerRepository.SaveChangesAsync();

            return new ApiResponse<CustomerResponse>(true, "SUCESS", null, "Cliente deletado.");
        }

    }
}