using Avalonia.Controls;
using Avalonia.Interactivity;
using FluentIcons.Avalonia;
using LibVLCSharp.Shared;

namespace Avalonia.Media.Libvlc
{

    public partial class MediaPlayerControls : UserControl
    {
        public static readonly DirectProperty<MediaPlayerControls, MediaPlayer> MediaPlayerProperty = AvaloniaProperty.RegisterDirect<MediaPlayerControls, MediaPlayer>(nameof(MediaPlayerControls.MediaPlayer), o => o.MediaPlayer, (o, v) => o.MediaPlayer = v);

        private MediaPlayer _mediaPlayer;

        public MediaPlayerControls()
        {
            InitializeComponent();
        }

        public MediaPlayer MediaPlayer { get => _mediaPlayer; set => SetAndRaise(MediaPlayerProperty, ref _mediaPlayer, value); }

        public void OnPlay(object sender, RoutedEventArgs e)
        {
            if (MediaPlayer != null)
            {
                MediaPlayer.Play();
            }
        }

        public void OnPause(object sender, RoutedEventArgs e)
        {
            if (MediaPlayer != null)
            {
                MediaPlayer.Pause();
            }
        }

        public void OnMute(object sender, RoutedEventArgs e)
        {
            if (MediaPlayer != null)
            {
                MediaPlayer.ToggleMute();
            }
        }

        public void OnStop(object sender, RoutedEventArgs e)
        {
            MediaPlayer?.Stop();
        }


    }
}