using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ViolationsRecording.Models.Entities.Configuration;

public class ModelConfiguration : IEntityTypeConfiguration<Model>
{
    void IEntityTypeConfiguration<Model>.Configure(EntityTypeBuilder<Model> builder)
    {
        builder
            .Property("Name")
            .IsRequired();

        builder
            .Property("BrandId")
            .IsRequired();

        builder
            .HasOne(m => m.Brand)
            .WithMany(b => b.Models)
            .HasForeignKey(m => m.BrandId);

        var models = new List<Model> {
            new Model { Id = 1, Name = "Camry", BrandId = 1 },
            new Model { Id = 2, Name = "Corolla", BrandId = 1 },
            new Model { Id = 3, Name = "RAV4", BrandId = 1 },
            new Model { Id = 4, Name = "Mustang", BrandId = 2 },
            new Model { Id = 5, Name = "Fiesta", BrandId = 2 },
            new Model { Id = 6, Name = "Focus", BrandId = 2 },
            new Model { Id = 7, Name = "3 Series", BrandId = 3 },
            new Model { Id = 8, Name = "5 Series", BrandId = 3 },
            new Model { Id = 9, Name = "X5", BrandId = 3 },
            new Model { Id = 10, Name = "C-Class", BrandId = 4 },
            new Model { Id = 11, Name = "E-Class", BrandId = 4 },
            new Model { Id = 12, Name = "S-Class", BrandId = 4 },
            new Model { Id = 13, Name = "A3", BrandId = 5 },
            new Model { Id = 14, Name = "Q7", BrandId = 5 },
            new Model { Id = 15, Name = "A4", BrandId = 5 }
        };
        builder.HasData(models);
    }
}