using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spotify.Metro.Model
{
    public class SearchResultTracks : SearchResultBase<TrackSearchResult>
    {
        public List<TrackSearchResult> Tracks
        {
            get { return this._innerList; }
            set
            {
                if (this._innerList != value)
                {
                    this._innerList = value;
                    this.OnPropertyChanged("Tracks");
                }
            }
        }

        public SearchResultTracks() : base(new SearchResultInfo()) { }
    }
}
