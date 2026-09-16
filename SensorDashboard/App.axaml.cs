using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using SensorDashboard.ViewModels;
using SensorDashboard.Views;
using Microsoft.Extensions.DependencyInjection;
using SensorDashboard.Services;
using SensorDashboard.Models;
using SensorDashboard.GrpcClient;

namespace SensorDashboard;

public partial class App : Application
{
    private bool _debug = false;
    public override void Initialize()
    {
        AvaloniaXamlLoader.Load(this);
    }

    public override void OnFrameworkInitializationCompleted()
    {   
        var serviceCollection = new ServiceCollection();
        if (_debug)
        {
            serviceCollection.AddSingleton<ISensorClientService, FakeSensorClientService>();  
        }
        else
        {
            serviceCollection.AddSingleton<ISensorClientService, SensorClientService>();
        }

        
        
        serviceCollection.AddSingleton<SensorState>();
        serviceCollection.AddSingleton<CameraDashboardViewModel>();
        serviceCollection.AddSingleton<IrCameraDashboardViewModel>();
        serviceCollection.AddSingleton<SettingsDashboardViewModel>();
        serviceCollection.AddSingleton<MainViewModel>();
        serviceCollection.AddSingleton<GeneralSettingsViewModel>();
        serviceCollection.AddSingleton<NetworkSettingsViewModel>();
        serviceCollection.AddSingleton<BackgroundCameraViewModel>();
        serviceCollection.AddSingleton<BackgroundIrCameraViewModel>();
        var serviceProvider = serviceCollection.BuildServiceProvider();
        
        
        if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
        {
            desktop.MainWindow = new MainWindow
            {
                DataContext = serviceProvider.GetRequiredService<MainViewModel>(),
            };
        }

        base.OnFrameworkInitializationCompleted();
    }
} 