using System;
using System.Threading.Tasks;
using SensorDashboard.GrpcClient;

namespace SensorDashboard.Services;

public class FakeSensorClientService : ISensorClientService
{   
    public event Action<SensorReading>? SensorReadingReceived;
    public void StartListening()
    {
        
        _ = Task.Run (async() =>
        {
            int counter = 0;
            
            while (true)
            {
                double _speed = (double)(counter / 1.1); 
                bool _isActive = (counter % 2 == 0);
                await Task.Delay(1000); 
                var reading = new SensorReading(
                    DateTime.UtcNow,
                    " Default: Hello you are subscribed",
                    _speed,
                    _isActive
                );
                Console.WriteLine(reading);
                SensorReadingReceived?.Invoke(reading);
                counter++;
            }
        });
    }
}