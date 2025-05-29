using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ViolationsRecording.Models.Entities.Configuration;

public class CarOwnerConfiguration : IEntityTypeConfiguration<CarOwner>
{
    void IEntityTypeConfiguration<CarOwner>.Configure(EntityTypeBuilder<CarOwner> builder)
    {
        builder
            .HasOne(co => co.Car)
            .WithMany(c => c.CarOwners)
            .HasForeignKey(co => co.CarId);

        builder
            .HasOne(co => co.Person)
            .WithMany(p => p.CarOwners)
            .HasForeignKey(co => co.PersonId);

        builder
            .HasMany(co => co.ViolationTypes)
            .WithMany(v => v.CarOwners)
            .UsingEntity<ViolationFact>(
                vf => vf
                .HasOne(vf2 => vf2.ViolationType)
                .WithMany(vt => vt.ViolationFacts)
                .HasForeignKey(vf2 => vf2.ViolationTypeId),
                vf => vf
                .HasOne(vf1 => vf1.CarOwner)
                .WithMany(c => c.ViolationFacts)
                .HasForeignKey(vf1 => vf1.CarOwnerId)
            );

        var carOwners = new List<CarOwner>
        {
            new(){Id = 1, PersonId = 1, CarId = 1, IsOwner = true},
            new(){Id = 2, PersonId = 1, CarId = 2, IsOwner = true},
            new(){Id = 3, PersonId = 2, CarId = 1, IsOwner = false},
            new(){Id = 4, PersonId = 3, CarId = 7, IsOwner = true},
            new(){Id = 5, PersonId = 5, CarId = 3, IsOwner = false},
            new(){Id = 6, PersonId = 7, CarId = 8, IsOwner = false},
            new(){Id = 7, PersonId = 10, CarId = 7, IsOwner = false},
            new(){Id = 8, PersonId = 11, CarId = 4, IsOwner = true},
            new(){Id = 9, PersonId = 8, CarId = 2, IsOwner = true},
            new(){Id = 10, PersonId = 6, CarId = 9, IsOwner = false},
            new(){Id = 11, PersonId = 7, CarId = 10, IsOwner = false},
            new(){Id = 12, PersonId = 9, CarId = 3, IsOwner = true},
            new(){Id = 13, PersonId = 14, CarId = 5, IsOwner = true},
        };
        builder.HasData(carOwners);
    }
}
