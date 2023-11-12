using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Templates;
using Avalonia.Interactivity;
using LibVLCSharp.Shared;

namespace Avalonia.Media.Libvlc
{
    public partial class MediaPlayerElement : UserControl
    {
        public static readonly FuncTemplate<Control?> DefaultControlsTemplate = new(() => new MediaPlayerControls());
        
        public static readonly DirectProperty<MediaPlayerElement, string> SourceProperty = AvaloniaProperty.RegisterDirect<MediaPlayerElement, string>(nameof(Source), o => o.Source, (o, v) => o.Source = v);

        public static readonly StyledProperty<ITemplate<Control?>> ControlsTemplateProperty =
                AvaloniaProperty.Register<MediaPlayerElement, ITemplate<Control?>>(nameof(ControlsTemplate), DefaultControlsTemplate);

        private string _source;

        private VideoView? _videoView;


        public MediaPlayerElement()
        {
            var playbackControls = this.ControlsTemplate.Build();

            _videoView = new VideoView()
            {
                DataContext = this,
                Content = playbackControls,
            };

            playbackControls.DataContext = _videoView;
            this.Content = _videoView;

            // Do later
            // this.VideoView.Bind(VideoView.SourceProperty, )
        }

        public string Source
        {
            get => _source;
            set
            {
                this.SetAndRaise(SourceProperty, ref _source, value);
                this._videoView.Source = value;
            }
        }

        /// <summary>
        /// Gets the <see cref="MediaPlayer"/> instance
        /// </summary>
        public MediaPlayer? MediaPlayer => this._videoView.MediaPlayer;


        // TEMPLATES
        public ITemplate<Control?> ControlsTemplate
        {
            get => GetValue(ControlsTemplateProperty);
            set => SetValue(ControlsTemplateProperty, value);
        }

    }
}
