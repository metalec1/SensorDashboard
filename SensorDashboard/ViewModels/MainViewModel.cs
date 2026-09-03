using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using SensorDashboard.Services;
using SensorDashboard.Models;

namespace SensorDashboard.ViewModels;

public partial class MainViewModel : ViewModelBase
{
    [ObservableProperty] public partial string Greeting { get; set; } = "Welcome to Avalonia!";
    [ObservableProperty] public partial ViewModelBase CurrentViewModel {get; set; }
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


    public MainViewModel(SensorClientService sensorClientService, CameraDashboardViewModel cameraDashboardViewModel, IrCameraDashboardViewModel irCameraDashboardViewModel, SettingsDashboardViewModel settingsDashboardViewModel)
    {   
        _cameraDashboardViewModel = cameraDashboardViewModel;
        _irCameraDashboardViewModel = irCameraDashboardViewModel;
        _settingsDashboardViewModel = settingsDashboardViewModel;
        _sensorClientService = sensorClientService;
        _sensorClientService.StartListening();
        CurrentViewModel = _settingsDashboardViewModel;
    }

}