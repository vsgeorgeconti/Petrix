using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Petrix.Domain.Entities;
namespace Petrix.Infrastructure.Persistence.Configurations
{
    public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.HasIndex(u => u.DocumentNumber).IsUnique();

            builder.Property(x => x.Name)
                    .IsRequired()
                    .HasMaxLength(150);
            builder.Property(x => x.DocumentNumber)
                   .HasMaxLength(14)
                   .IsRequired()
                   .HasColumnType("char(14)");
                    
            builder.Property(x => x.Email)
                   .HasMaxLength(255);
            builder.Property(x => x.Phone)
                   .HasMaxLength(11);
            

        }
    }
}