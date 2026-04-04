using Microsoft.EntityFrameworkCore;
using Petrix.Application.Interfaces;
using Petrix.Domain.Entities;

namespace Petrix.Infrastructure.Persistence.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _context;

        public UserRepository(AppDbContext context)
        {
            this._context = context;
        }

        public async Task AddAsync(User user) => await _context.Users.AddAsync(user);
        public async Task<User?> GetByIdAsync(Guid id) => await _context.Users.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
        public async Task<User?> GetByEmailAsync(string email) => await _context.Users.AsNoTracking().FirstOrDefaultAsync(x => x.Email == email);
        public async Task SaveChangesAsync() =>  await _context.SaveChangesAsync();
        public void Delete(User user) => _context.Users.Remove(user);
        public void Update(User user) => _context.Users.Update(user);
        
    }
}