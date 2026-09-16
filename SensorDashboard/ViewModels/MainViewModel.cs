using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using SensorDashboard.Services;
using SensorDashboard.GrpcClient;

namespace SensorDashboard.ViewModels;

public partial class MainViewModel : ViewModelBase
{
    [ObservableProperty] public partial string Greeting { get; set; } = "Welcome to Avalonia!";
    [ObservableProperty] public partial ViewModelBase CurrentViewModel {get; set; }
    [ObservableProperty] public partial ViewModelBase BackgroundViewModel { get; set; }
    [ObservableProperty] public partial int GridRowSpanBackground { get; set; }
    [ObservableProperty] public partial int GridColumnSpanBackground { get; set; }
    [ObservableProperty] public partial int GridColumnBackground { get; set; }
    [ObservableProperty] public partial int GridRowBackground { get; set; }
    
    private readonly int _gridColumnSpanCamera = 10; 
    private readonly int _gridRowSpanCamera = 8; 
    private readonly int _gridRowCamera = 0; 
    private readonly int _gridColumnCamera = 0; 
    
    
    private readonly int _gridColumnSpanIrCamera = 8; 
    private readonly int _gridRowSpanIrCamera = 6; 
    private readonly int _gridRowIrCamera = 1; 
    private readonly int _gridColumnIrCamera = 1; 
    
    
    
    private ViewModelBase _cameraDashboardViewModel;
    private ViewModelBase _irCameraDashboardViewModel;
    private SettingsDashboardViewModel _settingsDashboardViewModel;
    private ViewModelBase _backgroudCameraViewModel;
    private ViewModelBase _backgroudIrCameraViewModel;
    private ISensorClientService _sensorClientService;
    
    
    [RelayCommand]
    public void ShowSettingsDashboard()
    {
        if (CurrentViewModel == _settingsDashboardViewModel)
        {
            if (BackgroundViewModel == _backgroudCameraViewModel)
            {
                ShowCameraDashboard();
            }
            else if (BackgroundViewModel == _backgroudIrCameraViewModel)
            {
                ShowIrCameraDashboard();
            }
        }
        else
        {
            CurrentViewModel = _settingsDashboardViewModel;
        }

        
        
    }

    [RelayCommand]
    public void ShowCameraDashboard()
    {   
        _settingsDashboardViewModel.CloseSettingsMiniView();
        GridRowSpanBackground = _gridRowSpanCamera;
        GridColumnSpanBackground = _gridColumnSpanCamera;
        GridColumnBackground = _gridColumnCamera;
        GridRowBackground = _gridRowCamera;
        BackgroundViewModel = _backgroudCameraViewModel;
        CurrentViewModel = _cameraDashboardViewModel;
        
    }

    [RelayCommand]
    public void ShowIrCameraDashboard()
    {   
        _settingsDashboardViewModel.CloseSettingsMiniView();
        GridRowSpanBackground = _gridRowSpanIrCamera;
        GridColumnSpanBackground = _gridColumnSpanIrCamera;
        GridColumnBackground = _gridColumnIrCamera;
        GridRowBackground = _gridRowIrCamera;
        BackgroundViewModel = _backgroudIrCameraViewModel;
        CurrentViewModel = _irCameraDashboardViewModel;
        
    }


    public MainViewModel(ISensorClientService sensorClientService, CameraDashboardViewModel cameraDashboardViewModel, 
        IrCameraDashboardViewModel irCameraDashboardViewModel, SettingsDashboardViewModel settingsDashboardViewModel, 
        BackgroundCameraViewModel backgroundCameraViewModel, BackgroundIrCameraViewModel backgroundIrCameraViewModel)
    {   
        _cameraDashboardViewModel = cameraDashboardViewModel;
        _irCameraDashboardViewModel = irCameraDashboardViewModel;
        _settingsDashboardViewModel = settingsDashboardViewModel;
        _backgroudCameraViewModel = backgroundCameraViewModel;
        _backgroudIrCameraViewModel = backgroundIrCameraViewModel;
        _sensorClientService = sensorClientService;
        _sensorClientService.StartListening();
        GridRowSpanBackground = _gridRowSpanCamera;
        GridColumnSpanBackground = _gridColumnSpanCamera;
        GridColumnBackground = _gridColumnCamera;
        GridRowBackground = _gridRowCamera;
        
        BackgroundViewModel = _backgroudCameraViewModel;
        CurrentViewModel = _settingsDashboardViewModel;
    }

}