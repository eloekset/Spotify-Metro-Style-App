using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spotify.MetroStyle.Model
{
    public class Track : SearchResultItemBase
    {            
        private decimal _length;
        public decimal Length
        {
            get { return _length; }
            set
            {
                if (this._length != value)
                {
                    this._length = value;
                    NotifyPropertyChanged("Length");
                }
            }
        }

        private int _trackNumber;
        public int TrackNumber
        {
            get { return _trackNumber; }
            set
            {
                if (this._trackNumber != value)
                {
                    this._trackNumber = value;
                    NotifyPropertyChanged("TrackNumber");
                }
            }
        }

        private Album _album;
        public Album Album
        {
            get { return this._album; }
            set
            {
                if (this._album != value)
                {
                    this._album = value;
                    NotifyPropertyChanged("Album");
                }
            }
        }

        private List<Artist> _artists = new List<Artist>();
        public List<Artist> Artists
        {
            get { return this._artists; }
            set
            {
                if (this._artists != value)
                {
                    this._artists = value;
                    NotifyPropertyChanged("Artists");
                }
            }
        }

        public Track(string name, decimal popularity, IEnumerable<ExternalId> externalIds, decimal length, string href, int trackNumber, Album album, IEnumerable<Artist> artists)
            : base(name, popularity, externalIds, href)
        {
            this.Length = length;
            this.TrackNumber = trackNumber;
            this.Album = album;
            if (artists != null)
                this.Artists.AddRange(artists);
        }
    }
}
