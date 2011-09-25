using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spotify.Metro.Model
{
    public class SearchResultArtists : SearchResultBase<ArtistSearchResult>
    {        
        public List<ArtistSearchResult> Artists
        {
            get { return this._innerList; }
            set
            {
                if (this._innerList != value)
                {
                    this._innerList = value;
                    this.OnPropertyChanged("Artists");
                }
            }
        }

        public SearchResultArtists() : base(new SearchResultInfo()) { }
    }
}
