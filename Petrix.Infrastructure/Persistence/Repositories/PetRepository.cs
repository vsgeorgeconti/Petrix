using Microsoft.EntityFrameworkCore;
using Petrix.Application.Repositories;
using Petrix.Domain.Entities;

namespace Petrix.Infrastructure.Persistence.Repositories
{
    public class PetRepository : IPetRepository
    {
        private readonly AppDbContext _context;

        public PetRepository(AppDbContext context)
        {
            this._context = context;
        }
        public async Task AddAsync(Pet pet) => await _context.Pets.AddAsync(pet);

        public void Delete(Pet pet) => _context.Pets.Remove(pet);

        public async Task<IEnumerable<Pet>> GetAllAsync() => await _context.Pets.AsNoTracking().ToListAsync();

        public async Task<Pet?> GetByIdAsync(Guid id) => await _context.Pets.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);

        public async Task SaveChangesAsync() => await _context.SaveChangesAsync();

        public void Update(Pet pet) => _context.Update(pet);
    }
}