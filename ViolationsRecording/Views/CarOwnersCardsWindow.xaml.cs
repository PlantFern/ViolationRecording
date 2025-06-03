using System.Windows;
using ViolationsRecording.Models.Entities;

namespace ViolationsRecording.Views;

/// <summary>
/// Логика взаимодействия для ClientsCardsWindow.xaml
/// </summary>
public partial class CarOwnersCardsWindow : Window
{
    private List<CarOwner> _carOwners;
    public CarOwnersCardsWindow(List<CarOwner> carOwners) {
        InitializeComponent();

        _carOwners = carOwners;
    } // ClientsCardsWindow

    private void Window_Load(object sender, RoutedEventArgs e) {
        LbxCarOwnersCards.ItemsSource = _carOwners;
        e.Handled = true;
    } // Window_Load
}
