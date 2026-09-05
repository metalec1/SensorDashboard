namespace SensorDashboard.ViewModels;

using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;


public partial class SettingsDashboardViewModel : ViewModelBase
{
    [ObservableProperty] public partial ViewModelBase CurrentMiniViewModel { get; set; }
    private ViewModelBase _generalSettingsViewModel;
    private ViewModelBase _networkSettingsViewModel;

    [RelayCommand]
    public void OpenGeneralSettings()
    {
        if (CurrentMiniViewModel != _generalSettingsViewModel)
        {
            CurrentMiniViewModel = _generalSettingsViewModel;
        }
        else
        {
            CurrentMiniViewModel = null;
        }


    }

    [RelayCommand]
    public void OpenNetworkSettings()
    {
        
        if (CurrentMiniViewModel != _networkSettingsViewModel)
        {
            CurrentMiniViewModel = _networkSettingsViewModel;
        }
        else
        {
            CurrentMiniViewModel = null;
        }
    }
    
  
    public void CloseSettingsMiniView()
    {
        CurrentMiniViewModel = null;
    }

    public SettingsDashboardViewModel(GeneralSettingsViewModel generalSettingsViewModel, NetworkSettingsViewModel networkSettingsViewModel)
    {
        _generalSettingsViewModel = generalSettingsViewModel;
        _networkSettingsViewModel = networkSettingsViewModel;
        CurrentMiniViewModel = null;

    }
}