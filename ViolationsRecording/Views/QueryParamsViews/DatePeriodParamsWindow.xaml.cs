using System.Windows;

namespace ViolationsRecording.Views.QueryParamsViews;

/// <summary>
/// Interaction logic for DatePeriodParamsWindow.xaml
/// </summary>
public partial class DatePeriodParamsWindow : Window
{
    public (DateTime lo, DateTime hi) Output { get; set; }
    public DatePeriodParamsWindow()
    {
        InitializeComponent();
    }

    private void OK_Click(object sender, RoutedEventArgs e)
    {
        if(DpHigh.SelectedDate > DateTime.Now)
            throw new Exception("Период не может превышать нынишний год");
        if (DpHigh.SelectedDate < DpLow.SelectedDate) 
            throw new Exception ("Нижняя граница превышает верхнюю");
        Output = (DpLow.SelectedDate.Value, DpHigh.SelectedDate.Value);

        this.DialogResult = true;
    }
}
