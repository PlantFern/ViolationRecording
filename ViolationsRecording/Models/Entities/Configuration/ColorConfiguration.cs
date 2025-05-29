using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ViolationsRecording.Models.Entities.Configuration;

public class ColorConfiguration : IEntityTypeConfiguration<Color>
{
    void IEntityTypeConfiguration<Color>.Configure(EntityTypeBuilder<Color> builder)
    {
        builder
            .Property("Name")
            .IsRequired();

        builder
            .HasIndex(c => c.Name)
            .IsUnique();

        var colors = new List<Color> {
            new() { Id = 1, Name = "Светло-серый" },
            new() { Id = 2, Name = "Белый" },
            new() { Id = 3, Name = "Тёмно-Серый" },
            new() { Id = 4, Name = "Чёрный" },
            new() { Id = 5, Name = "Светло-Чёрный" },
            new() { Id = 6, Name = "Серебряный" },
            new() { Id = 7, Name = "Тёмно-Серебряный" },
            new() { Id = 8, Name = "Серый" },
            new() { Id = 9, Name = "Светло-Синий" },
            new() { Id = 10, Name = "Тёмно-Синий" }
        };
        builder.HasData(colors);
    }
}
