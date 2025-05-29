

using ViolationsRecording.Models;
using ViolationsRecording.Models.Entities;

namespace ViolationsRecording.Controllers;

public class ViolationsRecordingController(ViolationsRecordingContext db)
{
    public ViolationsRecordingController() : this(new ViolationsRecordingContext()) { }

    #region Получение всех записей для всех таблиц
    public List<Brand> GetAllBrands => db.Brands.ToList();
    public List<Model> GetAllModels => db.Models.ToList();
    public List<Color> GetAllColors => db.Colors.ToList();
    public List<StateNumber> GetAllStateNumbers => db.StateNumbers.ToList();
    public List<Car> GetAllCars => db.Cars.ToList();
    public List<Person> GetAllPersons => db.Persons.ToList();
    public List<CarOwner> GetAllCarOwners => db.CarOwners.ToList();
    public List<ViolationType> GetAllViolationTypes => db.ViolationTypes.ToList();
    public List<ViolationFact> GetViolationFacts => db.ViolationFacts.ToList();
    #endregion


}
