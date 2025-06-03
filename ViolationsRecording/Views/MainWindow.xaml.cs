using System.Windows;
using System.Windows.Controls.Primitives;
using ViolationsRecording.Controllers;
using ViolationsRecording.Models.Entities;
using ViolationsRecording.Views.QueryParamsViews;


namespace ViolationsRecording.Views;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    private readonly string MessageNoItemSelectedToEdit = "Данные для изменения не выбраны";
    private readonly string MessageNoItemSelectedToDelete = "Данные для удаления не выбраны";

    private List<string> styles = ["dark", "light"];
    private ViolationsRecordingController _controller;

    public MainWindow() : this(new ViolationsRecordingController()) { }
    public MainWindow(ViolationsRecordingController ViolationsRecordingController)
    {
        InitializeComponent();

        _controller = ViolationsRecordingController;
        DgdBrands.ItemsSource = _controller.GetAllBrands();
        DgdModels.ItemsSource = _controller.GetAllModels();
        DgdStateNumbers.ItemsSource = _controller.GetAllStateNumbers();
        DgdColors.ItemsSource = _controller.GetAllColors();
        DgdCars.ItemsSource = _controller.GetAllCars();
        DgdPersons.ItemsSource = _controller.GetAllPersons();
        DgdCarOwners.ItemsSource = _controller.GetAllCarOwners();
        DgdViolationTypes.ItemsSource = _controller.GetAllViolationTypes();
        DgdViolationFacts.ItemsSource = _controller.GetAllViolationFacts();

        //_filteredCars = _controller.GetCarsWithModel("X5");
        //DgdCarQueries.ItemsSource = _filteredCars;
    }


    private void OpenCards_Click(object sender, RoutedEventArgs e)
    {

        var carOwners = _controller.GetAllCarOwners();

        var prefix = "/Assets/CarOwners/";
        carOwners.ForEach(c => c.Person.PhotoPath = (c.Person.PhotoPath.StartsWith(prefix) ? "" : prefix) + c.Person.PhotoPath);
        var win = new CarOwnersCardsWindow(carOwners.ToList());

        win.ShowDialog();
        e.Handled = true;
    } // ClientsCards_Click


    #region Запросы
    private void GetCarsWithBrandAndModelAndColor_Click(object sender, RoutedEventArgs e)
    {
        string brand = "", model = "", color = ""; 
        try
        {
            var brandWin = new ComboBoxParamWindow("Бренд", _controller.GetBrandNames());
            if (brandWin.ShowDialog() == true)
                brand = brandWin.OutPut;

            var modelWin = new ComboBoxParamWindow("Модель", _controller.GetModelNamesWithBrand(brand));
            if (modelWin.ShowDialog() == true)
                model = modelWin.OutPut;

            var colorWin = new ComboBoxParamWindow("Цвет", _controller.GetColorNames());
            if (colorWin.ShowDialog() == true)
                color = colorWin.OutPut;

            DgdQueries.ItemsSource = _controller.GetCarsWithBrandAndModelAndColor(brand, model, color);
            TbcMainWindow.SelectedItem = TbiQueries;
        }

        catch (Exception ex)
        {
            MessageBox.Show($"{ex.Message}\n{ex.StackTrace}",
                            $"Ошибка {ex.TargetSite?.ToString()}",
                            MessageBoxButton.OK,
                            MessageBoxImage.Error);
        }

        e.Handled = true;
    }


    private void GetViolationalFactWithFineMoreThan_Click(object sender, RoutedEventArgs e)
    {
        double fineAmount = 0;
        try
        {
            var fineAmountWin = new DoubleParamWindow("Штраф больше чем");
            if (fineAmountWin.ShowDialog() == true)
                fineAmount = fineAmountWin.OutPut;

            DgdQueries.ItemsSource = _controller.GetViolationalFactWithFineMoreThan(fineAmount);
            TbcMainWindow.SelectedItem = TbiQueries;
        }

        catch (Exception ex)
        {
            MessageBox.Show($"{ex.Message}\n{ex.StackTrace}",
                            $"Ошибка {ex.TargetSite?.ToString()}",
                            MessageBoxButton.OK,
                            MessageBoxImage.Error);
        }

        e.Handled = true;
    }


    private void GetViolationTypeByPassport_Click(object sender, RoutedEventArgs e)
    {
        string passport = "";
        try
        {
            var passportWin = new ComboBoxParamWindow("Пасспорт", _controller.GetPassports());
            if (passportWin.ShowDialog() == true)
                passport = passportWin.OutPut;

            DgdQueries.ItemsSource = _controller.GetViolationTypeByPassport(passport);
            TbcMainWindow.SelectedItem = TbiQueries;
        }

        catch (Exception ex)
        {
            MessageBox.Show($"{ex.Message}\n{ex.StackTrace}",
                            $"Ошибка {ex.TargetSite?.ToString()}",
                            MessageBoxButton.OK,
                            MessageBoxImage.Error);
        }

        e.Handled = true;
    }


    private void GetCarByFixationDateInRange_Click(object sender, RoutedEventArgs e)
    {
        (DateTime, DateTime) range = (DateTime.Now.AddDays(-5), DateTime.Now);
        try
        {
            var rangeWin = new DatePeriodParamsWindow();
            if (rangeWin.ShowDialog() == true)
            {
                range.Item1 = rangeWin.Output.lo;
                range.Item2 = rangeWin.Output.hi;
            }

            DgdQueries.ItemsSource = _controller.GetCarByFixationDateInRange(range.Item1, range.Item2);
            TbcMainWindow.SelectedItem = TbiQueries;
        }

        catch (Exception ex)
        {
            MessageBox.Show($"{ex.Message}\n{ex.StackTrace}",
                            $"Ошибка {ex.TargetSite?.ToString()}",
                            MessageBoxButton.OK,
                            MessageBoxImage.Error);
        }

        e.Handled = true;
    }


    private void GetViolationTypeByProductionYear_Click(object sender, RoutedEventArgs e)
    {
        int productionYearLo = 0, productionYearHi = 0;
        try
        {
            var productionYearWin = new YearParamWindow("Нижняя граница года выпуска");
            if (productionYearWin.ShowDialog() == true)
                productionYearLo = productionYearWin.Output;

            var productionYearHiWin = new YearParamWindow("Нижняя граница года выпуска");
            if (productionYearHiWin.ShowDialog() == true)
                productionYearHi = productionYearHiWin.Output;

            DgdQueries.ItemsSource = _controller.GetViolationTypeByProductionYear(productionYearLo, productionYearHi);
            TbcMainWindow.SelectedItem = TbiQueries;
        }

        catch (Exception ex)
        {
            MessageBox.Show($"{ex.Message}\n{ex.StackTrace}",
                            $"Ошибка {ex.TargetSite?.ToString()}",
                            MessageBoxButton.OK,
                            MessageBoxImage.Error);
        }

        e.Handled = true;
    }


    private void GetCarWithInsuranceCapitalAmount_Click(object sender, RoutedEventArgs e)
    {
        try
        {
            DgdQueries.ItemsSource = _controller.GetCarWithInsuranceCapitalAmount();
            TbcMainWindow.SelectedItem = TbiQueries;
        }

        catch (Exception ex)
        {
            MessageBox.Show($"{ex.Message}\n{ex.StackTrace}",
                            $"Ошибка {ex.TargetSite?.ToString()}",
                            MessageBoxButton.OK,
                            MessageBoxImage.Error);
        }

        e.Handled = true;
    }


    private void GetGroupByStateNumberWithViolationAmountAndFine_Click(object sender, RoutedEventArgs e)
    {
        try
        {

            DgdQueries.ItemsSource = _controller.GetGroupByStateNumberWithViolationAmountAndFine();
            TbcMainWindow.SelectedItem = TbiQueries;
        }

        catch (Exception ex)
        {
            MessageBox.Show($"{ex.Message}\n{ex.StackTrace}",
                            $"Ошибка {ex.TargetSite?.ToString()}",
                            MessageBoxButton.OK,
                            MessageBoxImage.Error);
        }

        e.Handled = true;
    }


    private void Query8_Click(object sender, RoutedEventArgs e)
    {
        try
        {
            DgdQueries.ItemsSource = _controller.Query8();
            TbcMainWindow.SelectedItem = TbiQueries;
        }

        catch (Exception ex)
        {
            MessageBox.Show($"{ex.Message}\n{ex.StackTrace}",
                            $"Ошибка {ex.TargetSite?.ToString()}",
                            MessageBoxButton.OK,
                            MessageBoxImage.Error);
        }

        e.Handled = true;
    }


    private void Query9_Click(object sender, RoutedEventArgs e)
    {
        
        try
        {
            DgdQueries.ItemsSource = _controller.Query9();
            TbcMainWindow.SelectedItem = TbiQueries;
        }

        catch (Exception ex)
        {
            MessageBox.Show($"{ex.Message}\n{ex.StackTrace}",
                            $"Ошибка {ex.TargetSite?.ToString()}",
                            MessageBoxButton.OK,
                            MessageBoxImage.Error);
        }

        e.Handled = true;
    }

    #endregion


    private void AddViolationFact_Click(object sender, RoutedEventArgs e)
    {
        ViolationFactWindow rfWin = new ViolationFactWindow(_controller);

        if (rfWin.ShowDialog() == true)
            _controller.Add(rfWin.ViolationFactData);
        DgdViolationFacts.ItemsSource = _controller.GetAllViolationFacts();

        e.Handled = true;
    }

    private void EditViolationFact_Click(object sender, RoutedEventArgs e)
    {
        try
        {
            var selectedItem = (ViolationFact)DgdViolationFacts.SelectedItems[0]!;
            if (selectedItem == null)
                throw new Exception(MessageNoItemSelectedToEdit);

            ViolationFactWindow vfW = new ViolationFactWindow(selectedItem, _controller);

            if (vfW.ShowDialog() == true)
            {
                ViolationFact.Copy(vfW.ViolationFactData, selectedItem);
                _controller.Update(selectedItem);
            }

            DgdViolationFacts.ItemsSource = _controller.GetAllViolationFacts();
        }
        catch (Exception ex)
        {
            MessageBox.Show($"{ex.Message}\n{ex.StackTrace}",
                            $"Ошибка {ex.TargetSite?.ToString()}",
                            MessageBoxButton.OK,
                            MessageBoxImage.Error);
        }

        e.Handled = true;
    }

    private void DeleteViolationFact_Click(object sender, RoutedEventArgs e)
    {
        try
        {
            var selectedItem = (ViolationFact)DgdViolationFacts.SelectedItems[0]!;
            if (selectedItem == null)
                throw new Exception(MessageNoItemSelectedToDelete);

            _controller.RemoveViolationFactById(selectedItem.Id);
        }
        catch (Exception ex)
        {
            MessageBox.Show($"{ex.Message}\n{ex.StackTrace}",
                            $"Ошибка {ex.TargetSite?.ToString()}",
                            MessageBoxButton.OK,
                            MessageBoxImage.Error);
        }

        e.Handled = true;
    }


    private void Popup_LostFocus(object sender, RoutedEventArgs e)
    {
        if (sender is FrameworkElement element && element.ToolTip is Popup popup)
        {
            popup.IsOpen = false;
        }
        e.Handled = true;
    }


    #region Работа с темами
    private void LightTheme_Click(object sender, RoutedEventArgs e)
    {
        ThemeChanged("light");
        e.Handled = true;
    }
    private void DarkTheme_Click(object sender, RoutedEventArgs e)
    {
        ThemeChanged("dark");
        e.Handled = true;
    }

    private void ThemeChanged(string themeName)
    {
        string style = themeName;
        var uri = new Uri($"Resources/{style}.xaml", UriKind.Relative);

        ResourceDictionary rd = (ResourceDictionary)Application.LoadComponent(uri);

        Application.Current.Resources.MergedDictionaries.Add(rd);
    }
    #endregion

    #region Навигация
    private void Exit_Click(object sender, RoutedEventArgs e)
    {
        Application.Current.Shutdown();

        e.Handled = true;
    }


    private void GoToBrands_Click(object sender, RoutedEventArgs e)
    {
        TbcMainWindow.SelectedItem = TbiBrands;
    }
    private void GoToModels_Click(object sender, RoutedEventArgs e)
    {
        TbcMainWindow.SelectedItem = TbiModels;
    }
    private void GoToStateNumbers_Click(object sender, RoutedEventArgs e)
    {
        TbcMainWindow.SelectedItem = TbiStateNumbers;
    }
    private void GoToColors_Click(object sender, RoutedEventArgs e)
    {
        TbcMainWindow.SelectedItem = TbiColors;
    }
    private void GoToCars_Click(object sender, RoutedEventArgs e)
    {
        TbcMainWindow.SelectedItem = TbiCars;
    }
    private void GoToPersons_Click(object sender, RoutedEventArgs e)
    {
        TbcMainWindow.SelectedItem = TbiPersons;
    }
    private void GoToCarOwners_Click(object sender, RoutedEventArgs e)
    {
        TbcMainWindow.SelectedItem = TbiCarOwners;
    }
    private void GoToViolationTypes_Click(object sender, RoutedEventArgs e)
    {
        TbcMainWindow.SelectedItem = TbiViolationTypes;
    }
    private void GoToViolationFacts_Click(object sender, RoutedEventArgs e)
    {
        TbcMainWindow.SelectedItem = TbiViolationFacts;
    }
    #endregion

    private void WindowLoaded(object sender, RoutedEventArgs e)
    {
        ThemeChanged("light");

        e.Handled = true;
    }
}