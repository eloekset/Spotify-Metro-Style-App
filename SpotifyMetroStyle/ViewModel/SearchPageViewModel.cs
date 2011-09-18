using System;
using System.Collections.Generic;
using Windows.UI.Xaml.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Spotify.MetroStyle.Model;
using Spotify.MetroStyle.Util;
using Windows.UI.Xaml.Input;

namespace Spotify.MetroStyle.ViewModel
{
    public class SearchPageViewModel : INotifyPropertyChanged
    {
        #region Properties

        private string _searchText;
        public string SearchText
        {
            get { return _searchText; }
            set
            {
                if (this._searchText != value)
                {
                    _searchText = value;
                    NotifyPropertyChanged("SearchText");
                }
            }
        }

        private ICommand _searchCommand;
        public ICommand SearchCommand
        {
            get
            {
                if (_searchCommand == null)
                    _searchCommand = new RelayCommand(this.SearchSpotifyAsync, p => true);//p => !string.IsNullOrEmpty(this.SearchText));

                return _searchCommand;
            }
        }
        
        private SearchResultAlbum _albums;
        public SearchResultAlbum Albums
        {
            get { return this._albums; }
            private set
            {
                if (this._albums != value)
                {
                    this._albums = value;
                    NotifyPropertyChanged("Albums");
                    NotifyPropertyChanged("NumberOfAlbums");
                }
            }
        }

        private SearchResultArtist _artists;
        public SearchResultArtist Artists
        {
            get { return this._artists; }
            private set
            {
                if (this._artists != value)
                {
                    this._artists = value;
                    NotifyPropertyChanged("Artists");
                    NotifyPropertyChanged("NumberOfArtists");
                }
            }
        }

        private SearchResultTrack _tracks;
        public SearchResultTrack Tracks
        {
            get { return this._tracks; }
            private set
            {
                if (this._tracks != value)
                {
                    this._tracks = value;
                    NotifyPropertyChanged("Tracks");
                    NotifyPropertyChanged("NumberOfTracks");
                }
            }
        }

        public int NumberOfAlbums
        {
            get { return _albums.Info.NumberOfResults; }
        }

        public int NumberOfArtists
        {
            get { return _artists.Info.NumberOfResults; }
        }

        public int NumberOfTracks
        {
            get { return _tracks.Info.NumberOfResults; }
        }

        public string PageTitle
        {
            get { return "Spotify Browser"; }
        }

        private List<SearchResultItemBase> _resultList = new List<SearchResultItemBase>();
        public List<SearchResultItemBase> ResultList
        {
            get { return _resultList; }
            private set
            {
                if (this._resultList != value)
                {
                    this._resultList = value;
                    NotifyPropertyChanged("ResultList");
                }
            }
        }
        #endregion  // Properties

        #region Constructors
        public SearchPageViewModel()
        {
            this.Albums = new SearchResultAlbum(new SearchResultInfo("album"), null);
            this.Artists = new SearchResultArtist(new SearchResultInfo("artist"), null);
            this.Tracks = new SearchResultTrack(new SearchResultInfo("track"), null);
        }
        #endregion

        #region Methods
        public void SearchSpotifyAsync()
        {
            var query = this.SearchText;
            var spotify = new SpotifyHelper("test");
            spotify.SearchAlbumsAsync(query, this.SearchAlbumsCallback);
            spotify.SearchArtistsAsync(query, this.SearchArtistsCallback);
            spotify.SearchTracksAsync(query, this.SearchTracksCallback);
        }

        private void SearchAlbumsCallback(SearchResultAlbum albums)
        {            
            this.Albums = albums;
        }

        private void SearchArtistsCallback(SearchResultArtist artists)
        {
            
            this.Artists = artists;
        }

        private void SearchTracksCallback(SearchResultTrack tracks)
        {
            this.Tracks = tracks;
        }

        public void ShowSearchResultFor(string whatFor)
        {
            if (whatFor == "albums")
            {
                var list = new List<SearchResultItemBase>(this.Albums.Albums);
                this.ResultList = list;
            }
            else if (whatFor == "artists")
            {
                var list = new List<SearchResultItemBase>(this.Artists.Artists);
                this.ResultList = list;
            }
            else if (whatFor == "tracks")
            {
                var list = new List<SearchResultItemBase>(this.Tracks.Tracks);
                this.ResultList = list;
            }
        }

        #endregion

        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;

        public void NotifyPropertyChanged(string propertyName)
        {
            if (this.PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}
