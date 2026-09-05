using System;
using Avalonia.Controls;
using Avalonia.Media.Imaging;
using Avalonia.Platform;
using CommunityToolkit.Mvvm.ComponentModel;

namespace SensorDashboard.ViewModels;

public partial class BackgroundCameraViewModel : ViewModelBase
{
    [ObservableProperty] public partial Bitmap PathToCameraImage { get; set; }
    private readonly Bitmap _pathToCameraImage = new Bitmap(AssetLoader.Open(new Uri("avares://SensorDashboard/Assets/images/polje_narava.jpg")));

    public BackgroundCameraViewModel()
    {
        PathToCameraImage = _pathToCameraImage;
    }

}