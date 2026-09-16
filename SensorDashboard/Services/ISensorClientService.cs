using System;
using SensorDashboard.Models;

namespace SensorDashboard.Services;

public interface ISensorClientService
{
    public event Action<SensorReading>? SensorReadingReceived;
    public void StartListening();
}