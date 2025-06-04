using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ViolationsRecording.Models.Entities.Configuration;

public class CarConfiguration : IEntityTypeConfiguration<Car>
{
    void IEntityTypeConfiguration<Car>.Configure(EntityTypeBuilder<Car> builder)
    {
        builder
            .ToTable(t => t.HasCheckConstraint("ProductionYear", "ProductionYear > 1900"));

        builder
            .ToTable(t => t.HasCheckConstraint("InsuranceCost", "InsuranceCost > 100000"));

        // между Car и Model
        builder
            .HasOne(c => c.Model)
            .WithMany(c => c.Cars)
            .HasForeignKey(c => c.ModelId);

        // между Car и Color
        builder
            .HasOne(c => c.Color)
            .WithMany(c => c.Cars)
            .HasForeignKey(c => c.ColorId);

        // Настройка отношения "многие ко многим" между Car и Driver
        builder
            .HasMany(c => c.Drivers)
            .WithMany(p => p.Cars)
            .UsingEntity<ViolationFact>(
                violationFact => violationFact
                .HasOne(violationFact1 => violationFact1.Driver)
                .WithMany(p => p.ViolationFacts)
                .HasForeignKey(violationFact1 => violationFact1.DriverId),
                violationFact => violationFact
                .HasOne(violationFact2 => violationFact2.Car)
                .WithMany(c => c.ViolationFacts)
                .HasForeignKey(carOwner2 => carOwner2.CarId)
        );

        // Настройка отношения "многие ко многим" между Car и ViolationType
        builder
            .HasMany(c => c.ViolationTypes)
            .WithMany(p => p.Cars)
            .UsingEntity<ViolationFact>(
                violationFact => violationFact
                .HasOne(violationFact1 => violationFact1.ViolationType)
                .WithMany(p => p.ViolationFacts)
                .HasForeignKey(violationFact1 => violationFact1.ViolationTypeId),
                violationFact => violationFact
                .HasOne(violationFact2 => violationFact2.Car)
                .WithMany(c => c.ViolationFacts)
                .HasForeignKey(carOwner2 => carOwner2.CarId)
        );

        builder
            .HasOne(c => c.Owner)
            .WithMany(o => o.Cars)
            .HasForeignKey(c => c.OwnerId);

        var cars = new List<Car> {
            new() { Id = 1, ModelId = 1, ColorId = 1, ProductionYear = 1997, StateNumberId = 1, InsuranceCost = 5_500_000, OwnerId = 2 },
            new() { Id = 2, ModelId = 2, ColorId = 2, ProductionYear = 2003, StateNumberId = 2, InsuranceCost = 4_550_000, OwnerId = 4 },
            new() { Id = 3, ModelId = 6, ColorId = 3, ProductionYear = 2002, StateNumberId = 3, InsuranceCost = 6_700_000, OwnerId = 6},
            new() { Id = 4, ModelId = 4, ColorId = 4, ProductionYear = 2001, StateNumberId = 4, InsuranceCost = 5_450_000, OwnerId = 3 },
            new() { Id = 5, ModelId = 5, ColorId = 5, ProductionYear = 1995, StateNumberId = 5, InsuranceCost = 7_800_000, OwnerId = 3 },
            new() { Id = 6, ModelId = 3, ColorId = 6, ProductionYear = 1995, StateNumberId = 6, InsuranceCost = 7_000_000, OwnerId = 6 },
            new() { Id = 7, ModelId = 7, ColorId = 7, ProductionYear = 1998, StateNumberId = 7, InsuranceCost = 8_770_000, OwnerId = 4 },
            new() { Id = 8, ModelId = 8, ColorId = 8, ProductionYear = 1997, StateNumberId = 8, InsuranceCost = 7_800_000, OwnerId = 1 },
            new() { Id = 9, ModelId = 9, ColorId = 9, ProductionYear = 2002, StateNumberId = 9, InsuranceCost = 8_780_000, OwnerId = 8 },
            new() { Id = 10, ModelId = 10, ColorId = 10, ProductionYear = 2001, StateNumberId = 10, InsuranceCost = 7_800_000, OwnerId = 9 }
        };
        builder.HasData(cars);
    }
}
