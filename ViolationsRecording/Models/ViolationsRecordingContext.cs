using Microsoft.EntityFrameworkCore;
using ViolationsRecording.Models.Entities;

namespace ViolationsRecording.Models;

public class ViolationsRecordingContext : DbContext
{
    // Таблицы базы данных
    public DbSet<Brand> Brands => Set<Brand>();
    public DbSet<Model> Models => Set<Model>();
    public DbSet<Color> Colors => Set<Color>();
    public DbSet<StateNumber> StateNumbers => Set<StateNumber>();
    public DbSet<Car> Cars => Set<Car>();
    public DbSet<Driver> Drivers => Set<Driver>();
    public DbSet<Person> Persons => Set<Person>();
    public DbSet<ViolationType> ViolationTypes => Set<ViolationType>();
    public DbSet<ViolationFact> ViolationFacts => Set<ViolationFact>();


    public ViolationsRecordingContext()
    {
        Database.EnsureDeleted();
        Database.EnsureCreated();
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);

        // строка подключения
        optionsBuilder
            // подключение lazy loading, сначала установить NuGet-пакет Microsoft.EntityFrameworkCore.Proxies
            .UseLazyLoadingProxies()
            .UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=ViolationsRecordingDb;Trusted_Connection=True;");
    } // OnConfiguring

}
