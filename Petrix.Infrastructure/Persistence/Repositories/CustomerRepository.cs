using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Petrix.Application.Repositories;
using Petrix.Domain.Entities;

namespace Petrix.Infrastructure.Persistence.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly AppDbContext _context;
        public CustomerRepository(AppDbContext context)
        {
            this._context = context;
        }
        public async Task AddAsync(Customer customer) => await _context.Customers.AddAsync(customer);
        public void Delete(Customer customer) => _context.Customers.Remove(customer);
        public async Task<IEnumerable<Customer>> GetAllAsync() => await _context.Customers.AsNoTracking().ToListAsync();
        public async Task<Customer?> GetByIdAsync(Guid id) => await _context.Customers.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
        public async Task SaveChangesAsync() => await _context.SaveChangesAsync();
        public void Update(Customer customer) => _context.Customers.Update(customer);
    }
}