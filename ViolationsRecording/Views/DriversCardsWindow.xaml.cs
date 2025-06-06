using System.Windows;
using ViolationsRecording.Models.Entities;

namespace ViolationsRecording.Views;

/// <summary>
/// Логика взаимодействия для ClientsCardsWindow.xaml
/// </summary>
public partial class DriversCardsWindow : Window
{
    private List<Driver> _drivers;
    public DriversCardsWindow(List<Driver> drivers) {
        InitializeComponent();

        _drivers = drivers;
    } // ClientsCardsWindow

    private void Window_Load(object sender, RoutedEventArgs e) {
        LbxDriversCards.ItemsSource = _drivers;

        
        e.Handled = true;
    } // Window_Load
}
