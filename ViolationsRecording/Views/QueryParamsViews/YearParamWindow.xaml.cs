using ViolationsRecording.Infrastructure;
using System.Windows;

namespace ViolationsRecording.Views.QueryParamsViews;

/// <summary>
/// Interaction logic for DateParamWindow.xaml
/// </summary>
public partial class YearParamWindow : Window
{
    public int Output { get; set; }
    public YearParamWindow(string fieldName)
    {
        InitializeComponent();

        LblInput.Content = fieldName;
    }

    private void OK_Click(object sender, RoutedEventArgs e)
    {
        Output = Guard.Against.IsInt(TbxOutput.Text, "Введенное значение не является типом Int");
        Guard.Against.NotInRange(Output, 2000, DateTime.Now.Year, "Введенный год меньше 2000 и больше текщего года");

        this.DialogResult = true;
    }
}
