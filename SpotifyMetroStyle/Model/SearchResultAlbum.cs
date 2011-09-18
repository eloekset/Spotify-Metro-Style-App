using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spotify.MetroStyle.Model
{
    public class SearchResultAlbum : SearchResultBase
    {

        private List<Album> _albums = new List<Album>();
        public List<Album> Albums
        {
            get { return this._albums; }
            set
            {
                if (this._albums != value)
                {
                    this._albums = value;
                    NotifyPropertyChanged("Albums");
                }
            }
        }

        public SearchResultAlbum()
            : this(new SearchResultInfo("album"), null)
        { 

        }

        public SearchResultAlbum(SearchResultInfo info, IEnumerable<Album> albums)
            : base(info)
        {
            if (albums != null)                
                this.Albums.AddRange(albums);
        }

    }
}
