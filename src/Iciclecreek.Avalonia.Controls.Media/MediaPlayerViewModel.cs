using Avalonia.Controls;
using Avalonia.Metadata;
using LibVLCSharp.Shared;
using ReactiveUI;
using System.Diagnostics;

namespace Iciclecreek.Avalonia.Controls.Media
{
    public class MediaPlayerViewModel : ReactiveObject
    {
        private MediaPlayer _mediaPlayer;

        public MediaPlayerViewModel()
        {
            if (Design.IsDesignMode)
            {
                _mediaPlayer = new MediaPlayer(new LibVLCSharp.Shared.Media(null, "http://commondatastorage.googleapis.com/gtv-videos-bucket/sample/BigBuckBunny.mp4"));
            }
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
                _mediaPlayer.LengthChanged += (sender, e) => this.RaisePropertyChanged(nameof(Length));
                _mediaPlayer.Muted += (sender, e) => this.RaisePropertyChanged(nameof(IsMuted));
                _mediaPlayer.Unmuted += (sender, e) => this.RaisePropertyChanged(nameof(IsMuted));
                _mediaPlayer.EndReached += (sender, e) => ThreadPool.QueueUserWorkItem((x) =>
                {
                    _mediaPlayer.Stop();
                    _mediaPlayer.Time = 0;
                });
            }
        }

        public bool IsPlaying => _mediaPlayer.IsPlaying;

        public void Play() => _mediaPlayer.Play();

        [DependsOn(nameof(IsPlaying))]
        public bool CanPlay() => !_mediaPlayer.IsPlaying;

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

        public void ToggleCloseCaption()
        {
            if (_mediaPlayer.Spu != -1)
                _mediaPlayer.SetSpu(-1);
            else
                _mediaPlayer.SetSpu(0);
        }

        public bool IsCloseCaptioned => _mediaPlayer.Spu == -1;

        public bool IsMuted => _mediaPlayer.Mute;

        public int Volume { get => _mediaPlayer.Volume; set => _mediaPlayer.Volume = value; }

        public bool IsSeekable => _mediaPlayer.IsSeekable;

        public long Time
        {
            get => _mediaPlayer.Time;
            set { _mediaPlayer.Time = value; }
        }

        public long Length => _mediaPlayer.Length;

        public float Rate
        {
            get => _mediaPlayer.Rate;
            set
            {
                var rate = _mediaPlayer.Rate;
                this.RaiseAndSetIfChanged(ref rate, value);
                _mediaPlayer.SetRate(value);
            }
        }

        public void SetRate(object rate)
        {
            if (float.TryParse(rate?.ToString(), out var rateValue))
            {
                Rate = rateValue;
            }
        }

        public bool CanSetRate(string rate) => true;


        public void Download()
        {
            Process.Start(new ProcessStartInfo() { FileName = this.MediaPlayer.Media.Mrl, UseShellExecute = true });
        }
    }
}
