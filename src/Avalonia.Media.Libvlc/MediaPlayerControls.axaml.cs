using Avalonia.Controls;
using Avalonia.Data;
using Avalonia.Interactivity;
using FluentIcons.Avalonia;
using LibVLCSharp.Shared;
using ReactiveUI;

namespace Avalonia.Media.Libvlc
{

    public partial class MediaPlayerControls : UserControl
    {
        public static readonly DirectProperty<MediaPlayerControls, MediaPlayer> MediaPlayerProperty =
            AvaloniaProperty.RegisterDirect<MediaPlayerControls, MediaPlayer>(nameof(MediaPlayer), o => o.MediaPlayer, (o, value) => o.MediaPlayer = value);
        private MediaPlayer _mediaPlayer;

        public MediaPlayerControls()
        {
            // FluentIcons.Common.Symbol
            InitializeComponent();

            this.Bind(MediaPlayerProperty, new Binding("MediaPlayer", BindingMode.OneWay));
        }

        public MediaPlayer MediaPlayer
        {
            get => _mediaPlayer;
            set
            {
                if (value != null)
                {
                    SetAndRaise(MediaPlayerProperty, ref _mediaPlayer, value);
                    this.Controls.DataContext = new MediaPlayerViewModel() { MediaPlayer = value };
                }
            }
        }

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