using CommunityToolkit.Mvvm.ComponentModel;
using SensorDashboard.Models;

namespace SensorDashboard.ViewModels;

public partial class CameraDashboardViewModel : ViewModelBase
{
    [ObservableProperty] public partial SensorState CurrentSensorState {get; set; }
    public CameraDashboardViewModel(SensorState sensorState)
    {
        CurrentSensorState = sensorState;
    }
    


}