using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;

namespace Spotify.Metro.Model
{
    public class SearchResultItem : INotifyPropertyChanged
    {

        private SearchResultGroup _group;
        public SearchResultGroup Group
        {
            get
            {
                return this._group;
            }

            set
            {
                if (this._group != value)
                {
                    this._group = value;
                    this.OnPropertyChanged("Group");
                }
            }
        }

        private string _title = string.Empty;
        public string Title
        {
            get
            {
                return this._title;
            }

            set
            {
                if (this._title != value)
                {
                    this._title = value;
                    this.OnPropertyChanged("Title");
                }
            }
        }

        private string _subtitle = string.Empty;
        public virtual string Subtitle
        {
            get
            {
                return this._subtitle;
            }

            set
            {
                if (this._subtitle != value)
                {
                    this._subtitle = value;
                    this.OnPropertyChanged("Subtitle");
                }
            }
        }

        private ImageSource _image = null;
        private Uri _imageBaseUri = null;
        private String _imagePath = null;
        public ImageSource Image
        {
            get
            {
                if (_image == null && _imageBaseUri != null && _imagePath != null)
                {
                    _image = new BitmapImage(new Uri(_imageBaseUri, _imagePath));
                }
                return this._image;
            }

            set
            {
                if (this._image != value)
                {
                    this._image = value;
                    this._imageBaseUri = null;
                    this._imagePath = null;
                    this.OnPropertyChanged("Image");
                }
            }
        }

        public void SetImage(Uri baseUri, String path)
        {
            _image = null;
            _imageBaseUri = baseUri;
            _imagePath = path;
            this.OnPropertyChanged("Image");
        }

        private string _link = string.Empty;
        public string Link
        {
            get
            {
                return this._link;
            }

            set
            {
                if (this._link != value)
                {
                    this._link = value;
                    this.OnPropertyChanged("Link");
                }
            }
        }

        private string _category = string.Empty;
        public string Category
        {
            get
            {
                return this._category;
            }

            set
            {
                if (this._category != value)
                {
                    this._category = value;
                    this.OnPropertyChanged("Category");
                }
            }
        }

        private string _description = string.Empty;
        public string Description
        {
            get
            {
                return this._description;
            }

            set
            {
                if (this._description != value)
                {
                    this._description = value;
                    this.OnPropertyChanged("Description");
                }
            }
        }

        private string _content = string.Empty;
        public string Content
        {
            get
            {
                return this._content;
            }

            set
            {
                if (this._content != value)
                {
                    this._content = value;
                    this.OnPropertyChanged("Content");
                }
            }
        }

        private decimal _popularity = decimal.MinusOne;
        public decimal Popularity
        {
            get { return this._popularity; }
            set
            {
                if (this._popularity != value)
                {
                    this._popularity = value;
                    this.OnPropertyChanged("Popularity");
                }
            }
        }

        public string Href
        {
            get { return this.Link; }
            set
            {
                if (this.Link != value)
                {
                    this.Link = value;
                    this.OnPropertyChanged("Href");
                }
            }
        }

        public string Name
        {
            get { return this.Title; }
            set
            {
                if (this.Title != value)
                {
                    this.Title = value;
                    this.OnPropertyChanged("Name");
                }
            }
        }

        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string propertyName)
        {
            if (this.PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}
