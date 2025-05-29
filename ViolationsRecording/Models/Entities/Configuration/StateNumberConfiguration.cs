using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ViolationsRecording.Models.Entities.Configuration;

public class StateNumberConfiguration : IEntityTypeConfiguration<StateNumber>
{
    void IEntityTypeConfiguration<StateNumber>.Configure(EntityTypeBuilder<StateNumber> builder)
    {
        builder
            .Property("StateNumberName")
            .IsRequired();

        builder
            .HasIndex(s => s.StateNumberName)
            .IsUnique();

        builder
            .HasOne(s => s.Car)
            .WithOne(c => c.StateNumber)
            .HasForeignKey<Car>(s => s.StateNumberId);

        var stateNumbers = new List<StateNumber>
        {
            new() { Id = 1, StateNumberName = "А123ВС77" },
            new() { Id = 2, StateNumberName = "М456КТ99" },
            new() { Id = 3, StateNumberName = "Т789ОР197" },
            new() { Id = 4, StateNumberName = "Р321НЕ116" },
            new() { Id = 5, StateNumberName = "С654МН190" },
            new() { Id = 6, StateNumberName = "Е987ХК161" },
            new() { Id = 7, StateNumberName = "Н111СО178" },
            new() { Id = 8, StateNumberName = "О222АА102" },
            new() { Id = 9, StateNumberName = "К333РУ750" },
            new() { Id = 10, StateNumberName = "У444ТР93" },
            new() { Id = 11, StateNumberName = "Х555ЕК36" },
            new() { Id = 12, StateNumberName = "В666ОМ86" },
        };
        builder.HasData(stateNumbers);
    }
}