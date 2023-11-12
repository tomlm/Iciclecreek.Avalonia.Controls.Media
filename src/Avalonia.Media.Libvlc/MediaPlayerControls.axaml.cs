using Avalonia.Controls;
using Avalonia.Interactivity;
using LibVLCSharp.Shared;

namespace Avalonia.Media.Libvlc
{

    public partial class MediaPlayerControls : UserControl
    {
        public MediaPlayerControls()
        {
            InitializeComponent();
        }

        public MediaPlayer MediaPlayer => (DataContext as VideoView)?.MediaPlayer;

        public void OnPlay(object sender, RoutedEventArgs e)
        {
            MediaPlayer?.Play();
        }

        public void OnStop(object sender, RoutedEventArgs e)
        {
            MediaPlayer?.Stop();
        }
    }
}