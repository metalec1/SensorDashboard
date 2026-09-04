using Avalonia;
using Avalonia.Controls.Primitives;

namespace SensorDashboard.Controls;

public class SensorStatusIndicator : TemplatedControl
{
    public static readonly StyledProperty<bool> IsActiveProperty =
        AvaloniaProperty.Register<SensorStatusIndicator, bool>(nameof(IsActive));
        
    

    public bool IsActive
    {
        get => GetValue(IsActiveProperty);
        set => SetValue(IsActiveProperty, value);
    }
}