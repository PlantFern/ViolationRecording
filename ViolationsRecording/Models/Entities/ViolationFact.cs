using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using ViolationsRecording.Models.Entities.Configuration;

namespace ViolationsRecording.Models.Entities;


[EntityTypeConfiguration(typeof(ViolationFactConfiguration))]
public class ViolationFact : INotifyPropertyChanged
{
    public int Id { get; set; }

    public int DriverId { get; set; }

    private Driver _driver = null!;
    public virtual Driver Driver
    {
        get => _driver;
        set
        {
            _driver = value;

            OnPropertyChanged("Driver");
        }
    }

    public int CarId { get; set; }

    private Car _car = null!;
    public virtual Car Car
    {
        get => _car;
        set
        {
            _car = value;

            OnPropertyChanged("Car");
        }
    }

    public int ViolationTypeId { get; set; }

    private ViolationType _violationType = null!;
    public virtual ViolationType ViolationType
    {
        get => _violationType;
        set
        {
            _violationType = value;

            OnPropertyChanged("ViolationType");
        }
    }

    private DateTime _fixationDate;

    public DateTime FixationDate
    {
        get => _fixationDate;
        set
        {
            _fixationDate = value;

            OnPropertyChanged("FixationDate");
        }
    }

    // Проверка является ли данный водитель владельцем автомобиля
    public bool IsOwner => Driver.Person.Passport.Equals(Car.Owner.Passport);

    public static void Copy(ViolationFact orig, ViolationFact copy)
    {
        copy._driver = orig._driver;
        copy._car = orig._car;
        copy._violationType = orig._violationType;
        copy._fixationDate = orig._fixationDate;
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