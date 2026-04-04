using Microsoft.EntityFrameworkCore;

namespace Petrix.Infrastructure.Persistence
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
    : base(options)
        {
            
        }

    }
}