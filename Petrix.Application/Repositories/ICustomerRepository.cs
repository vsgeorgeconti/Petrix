using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Petrix.Domain.Entities;

namespace Petrix.Application.Repositories
{
    public interface ICustomerRepository
    {
        Task<Customer?> GetByIdAsync(Guid id);
        Task<IEnumerable<Customer>> GetAllAsync();
        Task AddAsync(Customer customer);
        void Update(Customer customer);
        void Delete(Customer customer);
        Task SaveChangesAsync();
    }
}