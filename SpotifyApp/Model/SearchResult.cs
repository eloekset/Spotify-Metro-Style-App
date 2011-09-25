using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spotify.Metro.Model
{
    public class SearchResult
    {
        public static readonly string ArtistsGroupTitle = "artists";
        public static readonly string AlbumsGroupTitle = "albums";
        public static readonly string TracksGroupTitle = "tracks";

        public List<SearchResultGroup> SearchResultGroups { get; private set; }

        public SearchResultGroup this[string title]
        {
            get
            {
                return this.GetOrCreateGroup(title);
            }
        }

        public void AddArtists(IEnumerable<ArtistSearchResult> artists)
        {
            this.GetOrCreateGroup(ArtistsGroupTitle).AddRange(artists);
        }

        public void AddAlbums(IEnumerable<SearchResultItem> albums)
        {
            this.GetOrCreateGroup(AlbumsGroupTitle).AddRange(albums);
        }

        public void AddTracks(IEnumerable<SearchResultItem> tracks)
        {
            this.GetOrCreateGroup(TracksGroupTitle).AddRange(tracks);
        }

        private SearchResultGroup GetOrCreateGroup(string title)
        {
            if (this.SearchResultGroups == null)
                this.SearchResultGroups = new List<SearchResultGroup>();

            SearchResultGroup group = (from g in this.SearchResultGroups
                                      where g.Title == title
                                      select g).FirstOrDefault();

            if (group == null)
            {
                group = new SearchResultGroup { Title = title };
                this.SearchResultGroups.Add(group);
            }

            return group;
        }        
    }
}
