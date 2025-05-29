using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ViolationsRecording.Models.Entities.Configuration;

public class BrandConfiguration : IEntityTypeConfiguration<Brand>
{
    void IEntityTypeConfiguration<Brand>.Configure(EntityTypeBuilder<Brand> builder)
    {
        builder
            .Property("Name")
            .IsRequired();

        builder
            .HasIndex(b => b.Name)
            .IsUnique();

        var brands = new List<Brand> {
            new Brand { Id = 1, Name = "Toyota" },
            new Brand { Id = 2, Name = "Ford" },
            new Brand { Id = 3, Name = "BMW" },
            new Brand { Id = 4, Name = "Mercedes" },
            new Brand { Id = 5, Name = "Audi" }
        };
        builder.HasData(brands);
    }
}