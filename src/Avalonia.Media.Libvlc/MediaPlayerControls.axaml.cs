using Avalonia.Controls;
using Avalonia.Data;
using LibVLCSharp.Shared;

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

        public IBrush Background { get => this.Controls.Background; set => this.Controls.Background = value; }
    }
}