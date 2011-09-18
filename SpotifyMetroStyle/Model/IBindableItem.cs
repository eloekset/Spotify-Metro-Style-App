using System;
using Windows.UI.Xaml.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Media;

namespace Spotify.MetroStyle.Model
{
    interface IBindableItem : INotifyPropertyChanged
    {
        ImageSource Image { get; set; }
        string Title { get; set; }
        string Subtitle { get; set; }
        string Description { get; set; }
    }
}
