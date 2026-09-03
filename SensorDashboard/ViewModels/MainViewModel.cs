using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace SensorDashboard.ViewModels;

public partial class MainViewModel : ViewModelBase
{
    [ObservableProperty] public partial string Greeting { get; set; } = "Welcome to Avalonia!";
    [ObservableProperty] public ViewModelBase currentViewModel;
    private ViewModelBase _cameraDashboardViewModel;
    private ViewModelBase _irCameraDashboardViewModel;
    private ViewModelBase _settingsDashboardViewModel;

    [RelayCommand]
    public void ShowSettingsDashboard()
    {
        CurrentViewModel = _settingsDashboardViewModel;
    }

    [RelayCommand]
    public void ShowCameraDashboard()
    {
        CurrentViewModel = _cameraDashboardViewModel;
    }

    [RelayCommand]
    public void ShowIrCameraDashboard()
    {
        CurrentViewModel = _irCameraDashboardViewModel;
    }


    public MainViewModel()
    {   
        _cameraDashboardViewModel = new CameraDashboardViewModel();
        _irCameraDashboardViewModel = new IrCameraDashboardViewModel();
        _settingsDashboardViewModel = new SettingsDashboardViewModel();
        currentViewModel = _settingsDashboardViewModel;
    }

}