using System.Windows;
using System.Windows.Controls;

namespace ViolationsRecording.Views.QueryParamsViews;

/// <summary>
/// Interaction logic for ComboBoxParamWindow.xaml
/// </summary>
public partial class ComboBoxParamWindow : Window
{
    public string OutPut { get; set; } = "";

    public ComboBoxParamWindow(string fieldName, List<string> collection)
    {
        InitializeComponent();

        LblInput.Content = fieldName; 
        CbxOutput.ItemsSource = collection;
    }

    private void OK_Click(object sender, RoutedEventArgs e)
    {
        OutPut = CbxOutput.SelectedItem.ToString()!;

        this.DialogResult = true;
    }
}
