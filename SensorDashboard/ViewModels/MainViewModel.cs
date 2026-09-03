using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using SensorDashboard;
using SensorDashboard.Services;

namespace SensorDashboard.ViewModels;

public partial class MainViewModel : ViewModelBase
{
    [ObservableProperty] public partial string Greeting { get; set; } = "Welcome to Avalonia!";
    [ObservableProperty] public ViewModelBase currentViewModel;
    private ViewModelBase _cameraDashboardViewModel;
    private ViewModelBase _irCameraDashboardViewModel;
    private ViewModelBase _settingsDashboardViewModel;
    private SensorClientService _sensorClientService;
    
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


    public MainViewModel(SensorClientService sensorClientService)
    {   
        _cameraDashboardViewModel = new CameraDashboardViewModel();
        _irCameraDashboardViewModel = new IrCameraDashboardViewModel();
        _settingsDashboardViewModel = new SettingsDashboardViewModel();
        _sensorClientService = sensorClientService;
        _sensorClientService.StartListening();
        currentViewModel = _settingsDashboardViewModel;
    }

}