using Avalonia.Controls;
using Avalonia.Interactivity;

namespace Sample.Views;

public partial class MainView : UserControl
{
    public MainView()
    {
        InitializeComponent();
    }

    public void Detach_Click(object? sender, RoutedEventArgs e)
    {
        this.Video1Grid.Children.Remove(this.Video1);
    }

    public void Visibility_Click(object? sender, RoutedEventArgs e)
    {
        this.Video1Grid.IsVisible = !this.Video1Grid.IsVisible;
    }

}
