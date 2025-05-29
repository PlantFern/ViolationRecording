using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using ViolationsRecording.Models.Entities.Configuration;

namespace ViolationsRecording.Models.Entities;


[EntityTypeConfiguration(typeof(ViolationFactConfiguration))]
public class ViolationFact : INotifyPropertyChanged
{
    public int Id { get; set; }

    public int CarOwnerId { get; set; }

    private CarOwner _carOwner = null!;
    public virtual CarOwner CarOwner
    {
        get => _carOwner;
        set
        {
            _carOwner = value;

            OnPropertyChanged("CarOwner");
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


    public static void Copy(ViolationFact orig, ViolationFact copy)
    {
        copy._carOwner = orig._carOwner;
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