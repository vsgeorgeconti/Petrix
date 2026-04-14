using Petrix.Domain.Entities;

namespace Petrix.Application.Repositories
{
    public interface IPetRepository
    {
        Task<Pet?> GetByIdAsync(Guid id);
        Task<IEnumerable<Pet>>GetAllAsync();
        Task AddAsync(Pet pet);
        void Update(Pet pet);
        void Delete(Pet pet);
        Task SaveChangesAsync();
    }
}