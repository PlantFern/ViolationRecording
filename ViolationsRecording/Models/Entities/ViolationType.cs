using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using ViolationsRecording.Models.Entities.Configuration;

namespace ViolationsRecording.Models.Entities;

[EntityTypeConfiguration(typeof(ViolationTypeConfiguration))]
public partial class ViolationType : INotifyPropertyChanged
{
    public int Id { get; set; }

    private string _name = string.Empty;
    public string Name
    {
        get => _name;
        set
        {
            _name = value;

            OnPropertyChanged("Name");
        }
    }

    private double _fineAmount;
    public double FineAmount
    {
        get => _fineAmount;
        set
        {
            _fineAmount = value;

            OnPropertyChanged("FineAmount");
        }
    }


    public virtual List<CarOwner> CarOwners { get; set; } = null!;
    public virtual List<ViolationFact> ViolationFacts { get; set; } = null!;


    public static void Copy(ViolationType orig, ViolationType copy)
    {
        copy._name = orig._name;
        copy._fineAmount = orig._fineAmount;
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