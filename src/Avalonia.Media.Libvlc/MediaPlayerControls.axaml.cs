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
        public MediaPlayerControls()
        {
            // FluentIcons.Common.Symbol
            InitializeComponent();
        }

        public MediaPlayer MediaPlayer { get => (DataContext as VideoView)?.MediaPlayer; }         // set => SetAndRaise(MediaPlayerProperty, ref _mediaPlayer, value); }

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