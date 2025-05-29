using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using ViolationsRecording.Models.Entities.Configuration;

namespace ViolationsRecording.Models.Entities;


[EntityTypeConfiguration(typeof(PersonConfiguration))]
public partial class Person : INotifyPropertyChanged
{
    public int Id { get; set; }

    private string _surname = string.Empty;
    public string Surname
    {
        get => _surname;
        set
        {
            _surname = value;

            OnPropertyChanged("Surname");
        }
    }

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

    private string _patronymic = string.Empty;
    public string Patronymic
    {
        get => _patronymic;
        set
        {
            _patronymic = value;

            OnPropertyChanged("Patronymic");
        }
    }

    private string _passport = string.Empty;
    public string Passport
    {
        get => _passport;
        set
        {
            _passport = value;

            OnPropertyChanged("Passport");
        }
    }

    private string _photoPath = string.Empty;
    public string PhotoPath
    {
        get => _photoPath;
        set
        {
            _photoPath = value;

            OnPropertyChanged("PhotoPath");
        }
    }


    public virtual List<CarOwner> CarOwners { get; set; } = null!;
    public virtual List<Car> Cars { get; set; } = null!;


    public static void Copy(Person orig, Person copy)
    {
        copy._surname = orig._surname;
        copy._name = orig._name;
        copy._patronymic = orig._patronymic;
        copy._passport = orig._passport;
        copy._photoPath = orig._photoPath;
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
