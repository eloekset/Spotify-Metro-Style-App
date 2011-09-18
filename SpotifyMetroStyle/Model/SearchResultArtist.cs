using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spotify.MetroStyle.Model
{
    public class SearchResultArtist : SearchResultBase
    {

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

        public SearchResultArtist()
            : this(new SearchResultInfo("artist"), null)
        {

        }

        public SearchResultArtist(SearchResultInfo info, IEnumerable<Artist> artists)
            : base(info)
        {
            if (artists != null)
                this.Artists.AddRange(artists);
        }
    }
}
