using Avalonia.Controls;
using Avalonia.Data;
using FluentIcons.Avalonia;
using FluentIcons.Common;
using LibVLCSharp.Shared;

namespace Avalonia.Media.Libvlc
{

    public partial class MediaPlayerControls : UserControl
    {
        public MediaPlayerControls()
        {
            InitializeComponent();
           
        }

        public IBrush Background { get => this.Controls.Background; set => this.Controls.Background = value; }
    }
}