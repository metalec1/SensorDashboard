using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using SensorDashboard.ViewModels;
using SensorDashboard.Views;
using Microsoft.Extensions.DependencyInjection;
using SensorDashboard.Services;
using SensorDashboard.Models;

namespace SensorDashboard;

public partial class App : Application
{
    public override void Initialize()
    {
        AvaloniaXamlLoader.Load(this);
    }

    public override void OnFrameworkInitializationCompleted()
    {   
        var serviceCollection = new ServiceCollection();
        serviceCollection.AddSingleton<SensorClientService>();
        serviceCollection.AddSingleton<SensorState>();
        serviceCollection.AddSingleton<CameraDashboardViewModel>();
        serviceCollection.AddSingleton<IrCameraDashboardViewModel>();
        serviceCollection.AddSingleton<SettingsDashboardViewModel>();
        serviceCollection.AddSingleton<MainViewModel>();
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