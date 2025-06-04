using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ViolationsRecording.Models.Entities.Configuration;

public class DriverConfiguration : IEntityTypeConfiguration<Driver>
{
    void IEntityTypeConfiguration<Driver>.Configure(EntityTypeBuilder<Driver> builder)
    {
        builder
            .Property("DriverLicense")
            .IsRequired();

        builder
            .HasIndex(b => b.DriverLicense)
            .IsUnique();

        // Настройка отношения "многие ко многим" между Driver и Car
        builder
            .HasMany(c => c.Cars)
            .WithMany(cl => cl.Drivers)
            .UsingEntity<ViolationFact>(
                violationFact => violationFact
                .HasOne(violationFact1 => violationFact1.Car)
                .WithMany(cl => cl.ViolationFacts)
                .HasForeignKey(violationFact1 => violationFact1.CarId),
                violationFact => violationFact
                .HasOne(violationFact2 => violationFact2.Driver)
                .WithMany(c => c.ViolationFacts)
                .HasForeignKey(violationFact2 => violationFact2.DriverId)
        );

        // Настройка отношения "многие ко многим" между Driver и ViolationType
        builder
            .HasMany(c => c.ViolationTypes)
            .WithMany(cl => cl.Drivers)
            .UsingEntity<ViolationFact>(
                violationFact => violationFact
                .HasOne(violationFact1 => violationFact1.ViolationType)
                .WithMany(cl => cl.ViolationFacts)
                .HasForeignKey(violationFact1 => violationFact1.ViolationTypeId),
                violationFact => violationFact
                .HasOne(violationFact2 => violationFact2.Driver)
                .WithMany(c => c.ViolationFacts)
                .HasForeignKey(violationFact2 => violationFact2.DriverId)
        );


        builder
            .HasOne(p => p.Person)
            .WithOne(d => d.Driver)
            .HasForeignKey<Driver>(d => d.PersonId);

        var drivers = new List<Driver>
        {
            new(){Id = 1, DriverLicense = "77 01 123456", PersonId = 1},
            new(){Id = 2, DriverLicense = "78 04 654321", PersonId = 2},
            new(){Id = 3, DriverLicense = "50 23 345678", PersonId = 3},
            new(){Id = 4, DriverLicense = "99 18 987654", PersonId = 4},
            new(){Id = 5, DriverLicense = "66 22 112233", PersonId = 5},
            new(){Id = 6, DriverLicense = "77 11 001122", PersonId = 6},
            new(){Id = 7, DriverLicense = "23 33 778899", PersonId = 7},
            new(){Id = 8, DriverLicense = "78 09 998877", PersonId = 8},
            new(){Id = 9, DriverLicense = "01 01 445566", PersonId = 9},
            new(){Id = 10, DriverLicense = "52 10 223344", PersonId = 10},
            new(){Id = 11, DriverLicense = "29 06 110099", PersonId = 11},
            new(){Id = 12, DriverLicense = "63 17 556677", PersonId = 12},
            new(){Id = 13, DriverLicense = "16 14 889900", PersonId = 13},
        };
        builder.HasData(drivers);
    }
}