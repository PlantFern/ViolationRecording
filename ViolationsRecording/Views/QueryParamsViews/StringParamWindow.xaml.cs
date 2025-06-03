using System.Windows;

namespace ViolationsRecording.Views.QueryParamsViews;

/// <summary>
/// Interaction logic for StringParamWindow.xaml
/// </summary>
public partial class StringParamWindow : Window
{
    public string OutPut { get; set; } = "";
    public StringParamWindow(string fieldName)
    {
        InitializeComponent();

        LblInput.Content = fieldName;
    }

    private void OK_Click(object sender, RoutedEventArgs e)
    {
        OutPut = TbxOutput.Text;

        this.DialogResult = true;
    }
}
