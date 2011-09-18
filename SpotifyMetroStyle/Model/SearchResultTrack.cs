using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spotify.MetroStyle.Model
{
    public class SearchResultTrack : SearchResultBase
    {
        private List<Track> _tracks = new List<Track>();
        public List<Track> Tracks
        {
            get { return _tracks; }
            set
            {
                if (this._tracks != value)
                {
                    this._tracks = value;
                    NotifyPropertyChanged("Tracks");
                }
            }
        }

        public SearchResultTrack()
            : this(new SearchResultInfo("track"), null)
        {

        }

        public SearchResultTrack(SearchResultInfo info, IEnumerable<Track> tracks)
            : base(info)
        {
            if (tracks != null)
                this.Tracks.AddRange(tracks);
        }
    }
}
