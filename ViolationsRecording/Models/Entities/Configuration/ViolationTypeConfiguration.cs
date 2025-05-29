using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ViolationsRecording.Models.Entities.Configuration;

public class ViolationTypeConfiguration : IEntityTypeConfiguration<ViolationType>
{
    void IEntityTypeConfiguration<ViolationType>.Configure(EntityTypeBuilder<ViolationType> builder)
    {
        builder
            .Property("Name")
            .IsRequired();

        builder
            .HasIndex("Name")
            .IsUnique();

        builder
            .ToTable(t => t.HasCheckConstraint("FineAmount", "FineAmount > 0"));

        builder
        .HasMany(co => co.CarOwners)
        .WithMany(v => v.ViolationTypes)
        .UsingEntity<ViolationFact>(
            vf => vf
            .HasOne(vf1 => vf1.CarOwner)
            .WithMany(c => c.ViolationFacts)
            .HasForeignKey(vf1 => vf1.CarOwnerId),
            vf => vf
            .HasOne(vf2 => vf2.ViolationType)
            .WithMany(vt => vt.ViolationFacts)
            .HasForeignKey(vf2 => vf2.ViolationTypeId)
        );

        var violationTypes = new List<ViolationType>
        {
            new() { Id = 1, Name = "Превышение скорости", FineAmount = 500 },
            new() { Id = 2, Name = "Проезд на красный", FineAmount = 1000 },
            new() { Id = 3, Name = "Непристёгнутый ремень", FineAmount = 1000 },
            new() { Id = 4, Name = "Разговор по телефону", FineAmount = 1500 },
            new() { Id = 5, Name = "Выезд на встречку", FineAmount = 5000 },
            new() { Id = 6, Name = "Парковка в неположенном месте", FineAmount = 1500 },
            new() { Id = 7, Name = "Отсутствие страховки", FineAmount = 800 },
            new() { Id = 8, Name = "Управление без прав", FineAmount = 2500 },
            new() { Id = 9, Name = "Нарушение правил поворота", FineAmount = 1000 },
            new() { Id = 10, Name = "Проезд под знак «Въезд запрещён»", FineAmount = 1500 },
            new() { Id = 11, Name = "Неправильный обгон", FineAmount = 3000 },
            new() { Id = 12, Name = "Остановка на пешеходном переходе", FineAmount = 2000 },
        };
        builder.HasData(violationTypes);
    }
}
