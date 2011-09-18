using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spotify.MetroStyle.Model
{
    class SearchResult
    {
        public List<Artist> Artists { get; private set; }
        public List<Album> Albums { get; private set;  }
        public List<Track> Tracks { get; private set; }

        public SearchResult() { }

        public SearchResult(IEnumerable<Artist> artists, IEnumerable<Album> albums, IEnumerable<Track> tracks) : this()
        {
            this.Artists = new List<Artist>(artists);
            this.Albums = new List<Album>(albums);
            this.Tracks = new List<Track>(tracks);
        }

        public void AddArtists(IEnumerable<Artist> artists)
        {
            this.Artists.AddRange(artists);
        }

        public void AddAlbums(IEnumerable<Album> albums)
        {
            this.Albums.AddRange(albums);
        }

        public void AddTracks(IEnumerable<Track> tracks)
        {
            this.Tracks.AddRange(tracks);
        }
    }
}
