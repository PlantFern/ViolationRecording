using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using ViolationsRecording.Models.Entities.Configuration;

namespace ViolationsRecording.Models.Entities;


[EntityTypeConfiguration(typeof(StateNumberConfiguration))]
public class StateNumber : INotifyPropertyChanged
{
    public int Id { get; set; }

    private string _stateNumberName = string.Empty;
    public string StateNumberName
    {
        get => _stateNumberName;
        set
        {
            _stateNumberName = value;

            OnPropertyChanged("StateNumberName");
        }
    }

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

    public static void Copy(StateNumber orig, StateNumber copy)
    {
        copy._stateNumberName = orig._stateNumberName;
        copy._car = orig._car;
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