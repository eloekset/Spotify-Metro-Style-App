using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Media;

namespace Spotify.MetroStyle.Model
{
    public class Album : SearchResultItemBase
    {
        private string _imageUri;
        public string ImageUri
        {
            get { return _imageUri; }
            set
            {
                if (this._imageUri != value)
                {
                    this._imageUri = value;
                    NotifyPropertyChanged("ImageUri");
                }
            }
        }       

        private List<Artist> _artists = new List<Artist>();
        public List<Artist> Artists
        {
            get { return _artists; }
            set
            {
                if (this._artists != value)
                {
                    this._artists = value;
                    NotifyPropertyChanged("Artists");
                }
            }
        }     

        private Availability _availability;
        public Availability Availability
        {
            get { return _availability; }
            set
            {
                if (this._availability != value)
                {
                    this._availability = value;
                    NotifyPropertyChanged("Availability");
                }
            }
        }

        public Album() : base(null, decimal.MinusOne, null, null) { }

        public Album(string title, string artist, string description, string imageUri)
            : base(title, decimal.MinusOne, null, null)
        {

        }

        public Album(string name, IEnumerable<Artist> artists, decimal popularity, IEnumerable<ExternalId> externalIds, string href, Availability availability)
            : base(name, popularity, externalIds, href)
        {
            if(artists != null)
                this.Artists = artists.ToList();
            this.Availability = availability;
        }
    }
}
