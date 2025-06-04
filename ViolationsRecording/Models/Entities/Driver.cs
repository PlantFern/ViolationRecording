using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using ViolationsRecording.Models.Entities.Configuration;

namespace ViolationsRecording.Models.Entities;


[EntityTypeConfiguration(typeof(DriverConfiguration))]
public partial class Driver : INotifyPropertyChanged
{
    public int Id { get; set; }


    private string _driverLicense = string.Empty;

    public string DriverLicense
    {
        get => _driverLicense;

        set
        {
            _driverLicense = value;

            OnPropertyChanged("DriverLicense");
        }
    }


    public int PersonId { get; set; }

    // Навигационное свойство для связи "один к одному"
    private Person _person = null!;
    public virtual Person Person 
    { 
        get => _person;

        set
        {
            _person = value;

            OnPropertyChanged("Person");
        }
    }


    // ViolationFacts: вспомогательная сущность для связи "многие ко многим"
    public virtual List<ViolationFact> ViolationFacts { get; set; } = null!;

    // ViolationTypes и Cars: Навигационные свойства, связанные через ViolationFacts
    public virtual List<ViolationType> ViolationTypes { get; set; } = null!;
    public virtual List<Car> Cars { get; set; } = null!;

    
    public void Copy(Driver orig, Driver copy)
    {
        copy._driverLicense = orig._driverLicense;
        copy._person = orig._person;
    }


    #region Реализация интерфейса INotifyPropertyChanged - специфика WPF
    // Реализация интерфейса: событие зажигается в сеттере свойства
    public event PropertyChangedEventHandler? PropertyChanged;

    // Вспомогательный метод, зажигающий событие
    public void OnPropertyChanged([CallerMemberName] string propertyName = "")
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    } // OnPropertyChanged
    #endregion
}
