using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ViolationsRecording.Models.Entities.Configuration;

public class ViolationFactConfiguration : IEntityTypeConfiguration<ViolationFact>
{
    void IEntityTypeConfiguration<ViolationFact>.Configure(EntityTypeBuilder<ViolationFact> builder)
    {
        builder
            .HasOne(v => v.Driver)
            .WithMany(c => c.ViolationFacts)
            .HasForeignKey(v => v.DriverId)
            .OnDelete(DeleteBehavior.Restrict);

        builder
            .HasOne(v => v.ViolationType)
            .WithMany(vt => vt.ViolationFacts)
            .HasForeignKey(v => v.ViolationTypeId)
            .OnDelete(DeleteBehavior.Restrict);

        builder
            .HasOne(v => v.Car)
            .WithMany(vt => vt.ViolationFacts)
            .HasForeignKey(v => v.CarId);

        builder.ToTable(t => t.HasCheckConstraint("FixationDate", "FixationDate < GetDate()"));

        var violationFacts = new List<ViolationFact> {
            new ViolationFact { Id = 1, DriverId = 2, CarId = 1, ViolationTypeId = 1, FixationDate = DateTime.Parse("12-05-2025") },
            new ViolationFact { Id = 2, DriverId = 5, CarId = 3, ViolationTypeId = 3, FixationDate = DateTime.Parse("14-05-2025") },
            new ViolationFact { Id = 3, DriverId = 6, CarId = 2, ViolationTypeId = 5, FixationDate = DateTime.Parse("17-05-2025") },
            new ViolationFact { Id = 4, DriverId = 3, CarId = 1, ViolationTypeId = 4, FixationDate = DateTime.Parse("05-05-2025") },
            new ViolationFact { Id = 5, DriverId = 9, CarId = 5, ViolationTypeId = 11, FixationDate = DateTime.Parse("10-05-2025") },
            new ViolationFact { Id = 6, DriverId = 12, CarId = 7, ViolationTypeId = 7, FixationDate = DateTime.Parse("22-05-2025") },
            new ViolationFact { Id = 7, DriverId = 6, CarId = 8, ViolationTypeId = 9, FixationDate = DateTime.Parse("03-05-2025") },
            new ViolationFact { Id = 8, DriverId = 2, CarId = 1, ViolationTypeId = 3, FixationDate = DateTime.Parse("08-05-2025") },
            new ViolationFact { Id = 9, DriverId = 6, CarId = 3, ViolationTypeId = 4, FixationDate = DateTime.Parse("10-05-2025") },
            new ViolationFact { Id = 10, DriverId = 7, CarId = 4, ViolationTypeId = 11, FixationDate = DateTime.Parse("11-05-2025") },
            new ViolationFact { Id = 11, DriverId = 4, CarId = 2, ViolationTypeId = 10, FixationDate = DateTime.Parse("25-05-2025") },
            new ViolationFact { Id = 12, DriverId = 12, CarId = 8, ViolationTypeId = 5, FixationDate = DateTime.Parse("09-05-2025") },
            new ViolationFact { Id = 13, DriverId = 10, CarId = 3, ViolationTypeId = 7, FixationDate = DateTime.Parse("07-05-2025") },
        };
        builder.HasData(violationFacts);
    }
}