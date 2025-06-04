using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using ViolationsRecording.Models.Entities.Configuration;

namespace ViolationsRecording.Models.Entities;

[EntityTypeConfiguration(typeof(CarConfiguration))]
public class Car : INotifyPropertyChanged
{
    public int Id { get; set; }

    public int ModelId { get; set; }

    private Model _model = null!;
    public virtual Model Model
    {
        get => _model;
        set
        {
            _model = value;

            OnPropertyChanged("Model");
        }
    }

    public int ColorId { get; set; }

    private Color _color = null!;
    public virtual Color Color
    {
        get => _color;
        set
        {
            _color = value;

            OnPropertyChanged("Color");
        }
    }

    private int _productionYear;
    public int ProductionYear
    {
        get => _productionYear;
        set
        {
            _productionYear = value;

            OnPropertyChanged("ProductionYear");
        }
    }

    public int StateNumberId { get; set; }

    private StateNumber _stateNumber = null!;
    public virtual StateNumber StateNumber
    {
        get => _stateNumber;
        set
        {
            _stateNumber = value;

            OnPropertyChanged("StateNumber");
        }
    }

    private double _insuranceCost;
    public double InsuranceCost
    {
        get => _insuranceCost;
        set
        {
            _insuranceCost = value;

            OnPropertyChanged("InsuranceCost");
        }
    }


    public int OwnerId {  get; set; }

    private Person _owner = null!;
    public virtual Person Owner 
    {
        get => _owner;

        set
        {
            _owner = value;

            OnPropertyChanged("Owner");
        }
    }


    // ViolationFacts: вспомогательная сущность для связи "многие ко многим"
    public virtual List<ViolationFact> ViolationFacts { get; set; } = null!;

    // ViolationTypes и Drivers: Навигационные свойства, связанные через ViolationFacts
    public virtual List<ViolationType> ViolationTypes { get; set; } = null!;
    public virtual List<Driver> Drivers { get; set; } = null!;


    // 
    public static void Copy(Car orig, Car copy)
    {
        copy._model = orig._model;
        copy._color = orig._color;
        copy._productionYear = orig._productionYear;
        copy._stateNumber = orig._stateNumber;
        copy._insuranceCost = orig._insuranceCost;
    }

    public string CarData => $"{Model.Brand.Name} {Model.Name} {ProductionYear} {Color.Name}";


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
