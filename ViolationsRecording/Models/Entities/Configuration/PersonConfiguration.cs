using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ViolationsRecording.Models.Entities.Configuration;

public class PersonConfiguration : IEntityTypeConfiguration<Person>
{
    void IEntityTypeConfiguration<Person>.Configure(EntityTypeBuilder<Person> builder)
    {
        builder
            .Property("Surname")
            .IsRequired();

        builder
            .Property("Name")
            .IsRequired();

        builder
            .Property("Patronymic")
            .IsRequired();

        builder
            .Property("Passport")
            .IsRequired();

        builder
            .HasIndex(b => b.Passport)
            .IsUnique();

        builder
            .HasIndex(b => b.PhotoPath)
            .IsUnique();

        var persons = new List<Person> {
            new Person
            {
                Id = 1,
                Surname = "Морозов",
                Name = "Андрей",
                Patronymic = "Андреевич",
                Passport = "6789 012345",
                PhotoPath = "man_001.jpg",
            },
            new Person
            {
                Id = 2,
                Surname = "Васильев",
                Name = "Алексей",
                Patronymic = "Алексеевич",
                Passport = "7890 123456",
                PhotoPath = "man_002.jpg",
            },
            new Person
            {
                Id = 3,
                Surname = "Павлов",
                Name = "Павел",
                Patronymic = "Павлович",
                Passport = "8901 234567",
                PhotoPath = "man_003.jpg",
            },
            new Person  
            {
                Id = 4,
                Surname = "Крылов",
                Name = "Максим",
                Patronymic = "Максимович",
                Passport = "9012 345678",
                PhotoPath = "man_004.jpg",
            },
            new Person
            {
                Id = 5,
                Surname = "Тарасов",
                Name = "Олег",
                Patronymic = "Олегович",
                Passport = "0123 456789",
                PhotoPath = "man_005.jpg",
            },
            new Person
            {
                Id = 6,
                Surname = "Фёдоров",
                Name = "Фёдор",
                Patronymic = "Фёдорович",
                Passport = "1234 567891",
                PhotoPath = "man_006.jpg",
            },
            new Person
            {
                Id = 7,
                Surname = "Белов",
                Name = "Виктор",
                Patronymic = "Викторович",
                Passport = "2345 678912",
                PhotoPath = "man_007.jpg",
            },
            new Person
            {
                Id = 8,
                Surname = "Громов",
                Name = "Игорь",
                Patronymic = "Игоревич",
                Passport = "3456 789123",
                PhotoPath = "man_008.jpg",
            },
            new Person
            {
                Id = 9,
                Surname = "Орлов",
                Name = "Георгий",
                Patronymic = "Георгиевич",
                Passport = "4567 890134",
                PhotoPath = "man_009.jpg",
            },
            new Person
            {
                Id = 10,
                Surname = "Поляков",
                Name = "Николай",
                Patronymic = "Николаевич",
                Passport = "5678 901245",
                PhotoPath = "man_010.jpg",
            },
            new Person
            {
                Id = 11,
                Surname = "Романов",
                Name = "Роман",
                Patronymic = "Романович",
                Passport = "6789 012356",
                PhotoPath = "man_011.jpg",
            },
            new Person
            {
                Id = 12,
                Surname = "Соколов",
                Name = "Владимир",
                Patronymic = "Владимирович",
                Passport = "7890 123467",
                PhotoPath = "man_012.jpg",
            },
            new Person
            {
                Id = 13,
                Surname = "Титов",
                Name = "Тимофей",
                Patronymic = "Тимофеевич",
                Passport = "8901 234578",
                PhotoPath = "man_013.jpg",
            },
            new Person
            {
                Id = 14,
                Surname = "Ушаков",
                Name = "Анатолий",
                Patronymic = "Анатольевич",
                Passport = "9012 345689",
                PhotoPath = "man_014.jpg",
            },
            new Person
            {
                Id = 15,
                Surname = "Цветкова",
                Name = "Ярослава",
                Patronymic = "Станиславовна",
                Passport = "0123 456790",
                PhotoPath = "woman_004.jpg",
            }
        };
        builder.HasData(persons);
    }
}
