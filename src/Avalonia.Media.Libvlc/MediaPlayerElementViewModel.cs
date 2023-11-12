using Avalonia.Controls;
using LibVLCSharp.Shared;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Avalonia.Media.Libvlc
{
    internal class MediaPlayerElementViewModel : ReactiveObject
    {
        private string _source;

        public MediaPlayerElementViewModel()
        {
            this.LibVLC = new LibVLC();
            this.MediaPlayer = new MediaPlayer(this.LibVLC);

        }

        // PROPERTIES
        public LibVLC LibVLC { get; private set; }

        public MediaPlayer MediaPlayer { get; private set; }

        public string Source
        {
            get => _source;
            set
            {
                this.RaiseAndSetIfChanged(ref _source, value);
                if (value != null)
                {
                    MediaPlayer.Media = new LibVLCSharp.Shared.Media(LibVLC, new Uri(_source));
                }
            }
        }

        // COMMANDS
        public void Play()
        {
            this.MediaPlayer.Play();
        }
        public bool CanPlay() => !this.MediaPlayer.IsPlaying && this.MediaPlayer.Media != null;

        public void Stop()
        {
            this.MediaPlayer.Stop();
        }

        public bool CanStop() => this.MediaPlayer.Media != null && this.MediaPlayer.IsPlaying;


        public void Pause()
        {
            this.MediaPlayer.Pause();
        }

        public bool CanPause() => this.MediaPlayer.Media != null && this.MediaPlayer.IsPlaying;

        public void Mute()
        {
            this.MediaPlayer.Mute = true; ;
        }

        public bool CanMute() => this.MediaPlayer.Media != null && this.MediaPlayer.IsPlaying;

        public void Unmute()
        {
            this.MediaPlayer.Mute = false;
        }

        public bool CanUnmute() => this.CanMute();

        public void ToggleMute()
        {
            this.MediaPlayer.ToggleMute();
        }

        public void Fullscreen(string trueFalse)
        {
            if (bool.TryParse(trueFalse, out var val))
                this.MediaPlayer.Fullscreen = val;
        }
    }
}