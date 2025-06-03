using System.Windows;
using ViolationsRecording.Infrastructure;

namespace ViolationsRecording.Views.QueryParamsViews;

/// <summary>
/// Interaction logic for DoubleParamWindow.xaml
/// </summary>
public partial class DoubleParamWindow : Window
{
    public double OutPut { get; set; }
    public DoubleParamWindow(string fieldName)
    {
        InitializeComponent();

        LblInput.Content = fieldName;
    }

    private void OK_Click(object sender, RoutedEventArgs e)
    {
        OutPut = Guard.Against.IsDouble(TbxOutput.Text, "Введенное значение не является типом Double");

        this.DialogResult = true;
    }
}
