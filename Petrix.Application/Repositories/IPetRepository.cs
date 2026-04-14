using Petrix.Domain.Entities;

namespace Petrix.Application.Repositories
{
    public interface IPetRepository
    {
        Task<Pet?> GetByIdAsyc(Guid id);
        Task<IEnumerable<Pet>>GetAllAsync();
        Task AddAsync(Pet pet);
        void Upload(Pet pet);
        void Delete(Pet pet);
        Task SaveChangesAsync();
    }
}