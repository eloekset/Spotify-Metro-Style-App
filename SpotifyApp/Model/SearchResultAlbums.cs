using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spotify.Metro.Model
{
    public class SearchResultAlbums : SearchResultBase<AlbumSearchResult>
    {
         public List<AlbumSearchResult> Albums
        {
            get { return this._innerList; }
            set
            {
                if (this._innerList != value)
                {
                    this._innerList = value;
                    this.OnPropertyChanged("Albums");
                }
            }
        }

        public SearchResultAlbums() : base(new SearchResultInfo()) { }
    }
}
