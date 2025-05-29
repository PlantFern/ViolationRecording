using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using ViolationsRecording.Models.Entities.Configuration;

namespace ViolationsRecording.Models.Entities;

[EntityTypeConfiguration(typeof(ModelConfiguration))]
public partial class Model : INotifyPropertyChanged
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

    public int BrandId { get; set; }

    private Brand _brand = null!;
    public virtual Brand Brand
    {
        get => _brand;
        set
        {
            _brand = value;

            OnPropertyChanged("Brand");
        }
    }


    public virtual List<Car> Cars { get; set; } = new List<Car>();


    public static void Copy(Model orig, Model copy)
    {
        copy._name = orig._name;
        copy._brand = orig._brand;
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
