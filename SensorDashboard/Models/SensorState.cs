using System;
using Avalonia.Threading;
using CommunityToolkit.Mvvm.ComponentModel;
using SensorDashboard.Models;
using SensorDashboard.Services;

namespace SensorDashboard.Models;

public partial class SensorState : ObservableObject
{
    [ObservableProperty] public partial DateTime Timestamp { get; set; }
    [ObservableProperty] public partial string Message { get; set; }
    [ObservableProperty] public partial double Speed { get; set; }
    [ObservableProperty] public partial bool IsActive { get; set; }
    
        
    public SensorState(ISensorClientService sensorClientService)
    {
        sensorClientService.SensorReadingReceived += UpdateSensorValues;
        
    }

    public void UpdateSensorValues(SensorReading reading)
    {   
        Dispatcher.UIThread.Post(() =>
            {
                Timestamp = reading.Timestamp;
                Message = reading.Message;
                Speed = reading.Speed;
                IsActive = reading.IsActive;
            }
        );
        
    }
}