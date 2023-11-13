using Avalonia.Metadata;
using LibVLCSharp.Shared;
using ReactiveUI;

namespace Avalonia.Media.Libvlc
{
    public class MediaPlayerViewModel : ReactiveObject
    {
        private MediaPlayer _mediaPlayer;

        public MediaPlayerViewModel()
        {
        }

        public MediaPlayer MediaPlayer
        {
            get => _mediaPlayer;
            set
            {
                _mediaPlayer = value ?? throw new ArgumentNullException(nameof(MediaPlayer));
                _mediaPlayer.Paused += (sender, e) => this.RaisePropertyChanged(nameof(IsPlaying));
                _mediaPlayer.Stopped += (sender, e) => this.RaisePropertyChanged(nameof(IsPlaying));
                _mediaPlayer.Playing += (sender, e) => this.RaisePropertyChanged(nameof(IsPlaying));
                _mediaPlayer.VolumeChanged += (sender, e) => this.RaisePropertyChanged(nameof(Volume));
                _mediaPlayer.TimeChanged += (sender, e) => this.RaisePropertyChanged(nameof(Time));
                _mediaPlayer.Muted += (sender, e) => this.RaisePropertyChanged(nameof(IsMuted));
                _mediaPlayer.Unmuted += (sender, e) => this.RaisePropertyChanged(nameof(IsMuted));
            }
        }

        public bool IsPlaying => _mediaPlayer.IsPlaying;

        public void Play() => _mediaPlayer.Play();
        
        [DependsOn(nameof(IsPlaying))]
        public bool CanPlay() => !_mediaPlayer.IsPlaying ;

        public void Stop() => _mediaPlayer.Stop();
        
        [DependsOn(nameof(IsPlaying))]
        public bool CanStop() => _mediaPlayer.IsPlaying;

        public void Pause() => _mediaPlayer.Pause();

        [DependsOn(nameof(IsPlaying))]
        public bool CanPause() => _mediaPlayer.IsPlaying;

        public void TogglePlayPause()
        {
            if (_mediaPlayer.IsPlaying)
            {
                _mediaPlayer.Pause();
            }
            else
            {
                _mediaPlayer.Play();
            }
        }

        public void Mute() => _mediaPlayer.Mute = true;

        [DependsOn(nameof(IsMuted))]
        public bool CanMute() => !IsMuted;

        public void Unmute() => _mediaPlayer.Mute = false;

        [DependsOn(nameof(IsMuted))]
        public bool CanUnmute() => IsMuted;

        public void ToggleMute() => _mediaPlayer.Mute = !_mediaPlayer.Mute;

        public bool IsMuted => _mediaPlayer.Mute;

        public int Volume { get => _mediaPlayer.Volume; set => _mediaPlayer.Volume = value; }

        public bool IsSeekable => _mediaPlayer.IsSeekable;

        public long Time
        {
            get => _mediaPlayer.Time;
            set {  _mediaPlayer.Time = value; this.RaisePropertyChanged(nameof(Time)); }    
        }

        public long Length => _mediaPlayer.Length;
    }
}
