using System;
using System.Threading.Tasks;
using Grpc.Core;
using Grpc.Net.Client;
using SensorDashboard;

namespace SensorDashboard.Services;

public class SensorClientService : IDisposable
{   
    private GrpcChannel channel;
    private SensorService.SensorServiceClient client;

    public SensorClientService(string grpcServerAddress = "http://localhost:5291")
    {
        channel = GrpcChannel.ForAddress(grpcServerAddress);
        client = new SensorService.SensorServiceClient(channel);
    }

    public void StartListening()
    {
        
        var call = client.SubscribeToSensor(new SensorUpdateRequest());
        _ = Task.Run (async() =>
        {
            await foreach (var update in call.ResponseStream.ReadAllAsync())
            {
                Console.WriteLine(update);
            }
        });
    }

    public void Dispose()
    {
        channel.Dispose();
    }

}