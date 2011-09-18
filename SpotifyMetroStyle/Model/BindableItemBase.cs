using System;
using System.Collections.Generic;
using Windows.UI.Xaml.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Media;

namespace Spotify.MetroStyle.Model
{
    public class BindableItemBase : IBindableItem
    {

        public BindableItemBase(string title, string subtitle, string description) : this(title, subtitle, description, null) { }        

        public BindableItemBase(string title, string subtitle, string description, ImageSource image)
        {
            this.Title = title;
            this.Subtitle = subtitle;
            this.Description = description;
            this.Image = image;
        }

        #region IBindableItem
        private ImageSource _image;
        public ImageSource Image
        {
            get
            {
                return this._image;
            }
            set
            {
                if (this._image != value)
                {
                    this._image = value;
                    NotifyPropertyChanged("Image");
                }
            }
        }

        private string _title;
        public virtual string Title
        {
            get
            {
                return _title;
            }
            set
            {
                if (this._title != value)
                {
                    this._title = value;
                    NotifyPropertyChanged("Title");
                }
            }
        }

        private string _subtitle;
        public string Subtitle
        {
            get
            {
                return _subtitle;
            }
            set
            {
                if (this._subtitle != value)
                {
                    this._subtitle = value;
                    NotifyPropertyChanged("Subtitle");
                }
            }
        }

        private string _description;
        public string Description
        {
            get
            {
                return _description;
            }
            set
            {
                if (this._description != value)
                {
                    this._description = value;
                    NotifyPropertyChanged("Description");
                }
            }
        }
        #endregion

        #region INotifyPropertyChanged
        public event Windows.UI.Xaml.Data.PropertyChangedEventHandler PropertyChanged;

        public void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new Windows.UI.Xaml.Data.PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}
