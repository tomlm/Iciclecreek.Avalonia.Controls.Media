using Avalonia.Controls;
using Avalonia.Media;

namespace Iciclecreek.Avalonia.Controls.Media
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