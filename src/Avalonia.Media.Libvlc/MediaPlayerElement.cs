//using Avalonia;
//using Avalonia.Controls;
//using Avalonia.Controls.Templates;
//using Avalonia.Data;
//using Avalonia.Interactivity;
//using Avalonia.Metadata;
//using LibVLCSharp.Shared;

//namespace Avalonia.Media.Libvlc
//{
//    public partial class MediaPlayerElement : UserControl
//    {
//        //public static readonly FuncTemplate<Control?> DefaultControlsTemplate = new(() =>
//        //{
//        //    var controls = new MediaPlayerControls()
//        //    {
//        //        [!MediaPlayerControls.MediaPlayerProperty] = new Binding("")
//        //    };
//        //    return controls;
//        //});

//        public static readonly DirectProperty<MediaPlayerElement, string> SourceProperty = AvaloniaProperty.RegisterDirect<MediaPlayerElement, string>(nameof(Source), o => o.Source, (o, v) => o.Source = v);

//        //public static readonly StyledProperty<ITemplate<Control?>> ControlsTemplateProperty =
//        //        AvaloniaProperty.Register<MediaPlayerElement, ITemplate<Control?>>(nameof(ControlsTemplate), DefaultControlsTemplate);

//        private string _source;

//        private VideoView? _videoView;


//        public MediaPlayerElement()
//        {
//            // var playbackControls = (this.Content == null) ? this.ControlsTemplate.Build() : this.Content;

//            _videoView = new VideoView();

//            // Do later
//            // this.VideoView.Bind(VideoView.SourceProperty, )
//        }

//        public string Source
//        {
//            get => _source;
//            set
//            {
//                this.SetAndRaise(SourceProperty, ref _source, value);
//                this._videoView.Source = value;
//            }
//        }

//        /// <summary>
//        /// Gets the <see cref="MediaPlayer"/> instance
//        /// </summary>
//        public MediaPlayer? MediaPlayer => this._videoView.MediaPlayer;


//        [Content]
//        public object Content
//        {
//            get => this._videoView.Content;
//            set
//            {
//                // SetValue(ContentProperty, value);
//                this._videoView.Content = value;
//            }
//        }

//    }
//}
