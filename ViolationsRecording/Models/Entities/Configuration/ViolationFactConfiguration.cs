using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ViolationsRecording.Models.Entities.Configuration;

public class ViolationFactConfiguration : IEntityTypeConfiguration<ViolationFact>
{
    void IEntityTypeConfiguration<ViolationFact>.Configure(EntityTypeBuilder<ViolationFact> builder)
    {
        builder
            .HasOne(v => v.CarOwner)
            .WithMany(c => c.ViolationFacts)
            .HasForeignKey(v => v.CarOwnerId);

        builder
            .HasOne(v => v.ViolationType)
            .WithMany(vt => vt.ViolationFacts)
            .HasForeignKey(v => v.ViolationTypeId);

        builder.ToTable(t => t.HasCheckConstraint("FixationDate", "FixationDate < GetDate()"));

        var violationFacts = new List<ViolationFact> {
            new ViolationFact { Id = 1, CarOwnerId = 1, ViolationTypeId = 1, FixationDate = DateTime.Parse("12-05-2025") },
            new ViolationFact { Id = 2, CarOwnerId = 5, ViolationTypeId = 3, FixationDate = DateTime.Parse("14-05-2025") },
            new ViolationFact { Id = 3, CarOwnerId = 6, ViolationTypeId = 5, FixationDate = DateTime.Parse("17-05-2025") },
            new ViolationFact { Id = 4, CarOwnerId = 3, ViolationTypeId = 4, FixationDate = DateTime.Parse("05-05-2025") },
            new ViolationFact { Id = 5, CarOwnerId = 9, ViolationTypeId = 11, FixationDate = DateTime.Parse("10-05-2025") },
            new ViolationFact { Id = 6, CarOwnerId = 12, ViolationTypeId = 7, FixationDate = DateTime.Parse("22-05-2025") },
            new ViolationFact { Id = 7, CarOwnerId = 6, ViolationTypeId = 9, FixationDate = DateTime.Parse("03-05-2025") },
            new ViolationFact { Id = 8, CarOwnerId = 2, ViolationTypeId = 3, FixationDate = DateTime.Parse("08-05-2025") },
            new ViolationFact { Id = 9, CarOwnerId = 6, ViolationTypeId = 4, FixationDate = DateTime.Parse("10-05-2025") },
            new ViolationFact { Id = 10, CarOwnerId = 7, ViolationTypeId = 11, FixationDate = DateTime.Parse("11-05-2025") },
            new ViolationFact { Id = 11, CarOwnerId = 4, ViolationTypeId = 10, FixationDate = DateTime.Parse("25-05-2025") },
            new ViolationFact { Id = 12, CarOwnerId = 12, ViolationTypeId = 5, FixationDate = DateTime.Parse("09-05-2025") },
            new ViolationFact { Id = 13, CarOwnerId = 10, ViolationTypeId = 7, FixationDate = DateTime.Parse("07-05-2025") },
        };
        builder.HasData(violationFacts);
    }
}