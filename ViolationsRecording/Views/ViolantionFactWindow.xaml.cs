
using System.Windows;
using ViolationsRecording.Controllers;
using ViolationsRecording.Models.Entities;

namespace ViolationsRecording.Views;

/// <summary>
/// Interaction logic for RentalFact.xaml
/// </summary>
public partial class ViolationFactWindow : Window
{
    public ViolationFact ViolationFactData { get; private set; } = new ViolationFact();

    public ViolationFactWindow(ViolationsRecordingController controller) : this(new ViolationFact(), controller) { }
    public ViolationFactWindow(ViolationFact violationFactData, ViolationsRecordingController controller)
    {
        InitializeComponent();

        ViolationFact.Copy(violationFactData, ViolationFactData);
        this.DataContext = ViolationFactData;

        CbxCarOwner.ItemsSource = controller.GetAllCarOwners();
        CbxCarOwner.DisplayMemberPath = "CarOwnerData";

        CbxViolationType.ItemsSource = controller.GetAllViolationTypes();
        CbxViolationType.DisplayMemberPath = "Name";
    }

    private void OK_Click(object sender, RoutedEventArgs e)
    {
        this.DialogResult = true;
    }
}
