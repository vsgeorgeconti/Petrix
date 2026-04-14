using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Petrix.Domain.Entities;

namespace Petrix.Infrastructure.Persistence.Configurations
{
    public class PetConfiguration : IEntityTypeConfiguration<Pet>
    {
        public void Configure(EntityTypeBuilder<Pet> builder)
        {
            builder.Property(x => x.Name)
                  .IsRequired()
                  .HasMaxLength(100);
            builder.Property(x => x.Breed)
                .HasMaxLength(100);
            builder.Property(x => x.Notes)
                .HasMaxLength(500);
            builder.Property(x => x.Weight)
                .HasPrecision(5,2);
            builder.Property(x => x.Species)
                .HasConversion<string>();
        }
    }
}