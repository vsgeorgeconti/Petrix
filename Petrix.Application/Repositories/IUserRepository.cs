using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Petrix.Domain.Entities;

namespace Petrix.Application.Interfaces
{
    public interface IUserRepository
    {
        Task<User?> GetByIdAsync(Guid id);
        Task<User?> GetByEmailAsync(string email);
        Task AddAsync(User user);
        void Update(User user);
        void Delete(User user);
        Task SaveChangesAsync();
    }
}