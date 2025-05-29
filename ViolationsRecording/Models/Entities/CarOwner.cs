using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using ViolationsRecording.Models.Entities.Configuration;

namespace ViolationsRecording.Models.Entities;


[EntityTypeConfiguration(typeof(CarOwnerConfiguration))]
public partial class CarOwner : INotifyPropertyChanged
{
    public int Id { get; set; }

    public int PersonId { get; set; }

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

    private bool _isOwner;
    public bool IsOwner
    {
        get => _isOwner;
        set
        {
            _isOwner = value;

            OnPropertyChanged("IsOwner");
        }
    }


    public virtual List<ViolationType> ViolationTypes { get; set; } = null!;
    public virtual List<ViolationFact> ViolationFacts { get; set; } = null!;



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
