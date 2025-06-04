

using ViolationsRecording.Models;
using ViolationsRecording.Models.Entities;

namespace ViolationsRecording.Controllers;

public partial class ViolationsRecordingController(ViolationsRecordingContext db)
{
    public ViolationsRecordingController() : this(new ViolationsRecordingContext()) { }

    #region Получение всех записей для всех таблиц
    public List<Brand> GetAllBrands() => db.Brands.ToList();
    public List<Model> GetAllModels() => db.Models.ToList();
    public List<Color> GetAllColors() => db.Colors.ToList();
    public List<StateNumber> GetAllStateNumbers() => db.StateNumbers.ToList();
    public List<Car> GetAllCars() => db.Cars.ToList();
    public List<Driver> GetAllPersons() => db.Drivers.ToList();
    public List<Person> GetAllCarOwners() => db.Persons.ToList();
    public List<ViolationType> GetAllViolationTypes() => db.ViolationTypes.ToList();
    public List<ViolationFact> GetAllViolationFacts() => db.ViolationFacts.ToList();
    #endregion


    #region CRUD
    public void Add(Brand brand)
    {
        db.Brands.Add(brand);
        db.SaveChanges();
    }

    public void Add(Model model)
    {
        db.Models.Add(model);
        db.SaveChanges();
    }

    public void Add(Color color)
    {
        db.Colors.Add(color);
        db.SaveChanges();
    }

    public void Add(StateNumber stateNumber)
    {
        db.StateNumbers.Add(stateNumber);
        db.SaveChanges();
    }

    public void Add(Car car)
    {
        db.Cars.Add(car);
        db.SaveChanges();
    }

    public void Add(Driver driver)
    {
        db.Drivers.Add(driver);
        db.SaveChanges();
    }

    public void Add(Person person)
    {
        db.Persons.Add(person);
        db.SaveChanges();
    }

    public void Add(ViolationType violationTypes)
    {
        db.ViolationTypes.Add(violationTypes);
        db.SaveChanges();
    }

    public void Add(ViolationFact violationFacts)
    {
        db.ViolationFacts.Add(violationFacts);
        db.SaveChanges();
    }


    // Изменение записи
    public void Update(Brand brand)
    {
        // получаем ссылку на изменяемую запись
        // если не нашли - выбрасывается исключение
        var brand1 = db.Brands.FirstOrDefault(b => b.Id == brand.Id);

        brand1.Name = brand.Name;

        db.Brands.Update(brand1);
        db.SaveChanges();
    }

    public void Update(Model model)
    {
        var model1 = db.Models.FirstOrDefault(m => m.Id == model.Id);

        model1.Name = model.Name;

        db.Models.Update(model1);
        db.SaveChanges();
    }

    public void Update(Color color)
    {
        var color1 = db.Colors.FirstOrDefault(c => c.Id == color.Id);

        color1.Name = color.Name;

        db.Colors.Update(color1);
        db.SaveChanges();
    }

    public void Update(StateNumber stateNumber)
    {
        var stateNumber1 = db.StateNumbers.FirstOrDefault(s => s.Id == stateNumber.Id);

        stateNumber1.StateNumberName = stateNumber.StateNumberName;

        db.StateNumbers.Update(stateNumber1);
        db.SaveChanges();
    }

    public void Update(Car car)
    {
        var car1 = db.Cars.FirstOrDefault(c => c.Id == car.Id);

        car1.Model = car.Model;
        car1.Color = car.Color;
        car1.ProductionYear = car.ProductionYear;
        car1.StateNumber = car.StateNumber;
        car1.InsuranceCost = car.InsuranceCost;

        db.Cars.Update(car1);
        db.SaveChanges();
    }

    public void Update(Driver driver)
    {
        var driver1 = db.Drivers.FirstOrDefault(c => c.Id == driver.Id);

        driver1.DriverLicense = driver.DriverLicense;
        driver1.Person = driver.Person;

        db.Drivers.Update(driver1);
        db.SaveChanges();
    }

    public void Update(Person person)
    {
        var person1 = db.Persons.FirstOrDefault(c => c.Id == person.Id);

        person1.Surname = person.Surname;
        person1.Name = person.Name;
        person1.Patronymic = person.Patronymic;
        person1.Passport = person.Passport;
        person1.PhotoPath = person.PhotoPath;

        db.Persons.Update(person1);
        db.SaveChanges();
    }

    public void Update(ViolationType violationType)
    {
        var violationType1 = db.ViolationTypes.FirstOrDefault(c => c.Id == violationType.Id);

        violationType1.Name = violationType.Name;
        violationType1.FineAmount = violationType.FineAmount;

        db.ViolationTypes.Update(violationType1);
        db.SaveChanges();
    }

    public void Update(ViolationFact violationFact)
    {
        var violationFact1 = db.ViolationFacts.FirstOrDefault(c => c.Id == violationFact.Id);

        violationFact1.Driver = violationFact.Driver;
        violationFact1.ViolationType = violationFact.ViolationType;
        violationFact1.FixationDate = violationFact.FixationDate;

        db.ViolationFacts.Update(violationFact1);
        db.SaveChanges();
    }

    // Удаление записи
    public void RemoveViolationFactById(int id)
    {
        var violationFact = db.ViolationFacts.FirstOrDefault(b => b.Id == id);
        if (violationFact == null) return;

        db.ViolationFacts.Remove(violationFact);
        db.SaveChanges();
    }
    #endregion
}
