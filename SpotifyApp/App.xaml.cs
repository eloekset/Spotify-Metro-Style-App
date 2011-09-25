using Expression.Blend.SampleData.SampleDataSource;
using System;
using System.Collections.Generic;
using Windows.ApplicationModel.Activation;
using Windows.UI.Xaml;
using Spotify.Metro.Util;
using Spotify.Metro.Model;

namespace Spotify.Metro
{
    partial class App
    {
        // TODO: Create a data model appropriate for your problem domain to replace the sample data
        private static SampleDataSource _sampleData;
        private static SearchResult _searchResult;

        public App()
        {
            InitializeComponent();
        }

        protected override void OnLaunched(LaunchActivatedEventArgs args)
        {
            //ShowGroupedCollection();
            App.Search("a-ha");
            Window.Current.Activate();
        }

        public static void Search(string query)
        {
            App._searchResult = new SearchResult();
            SpotifyHelper spotify = new SpotifyHelper("test");
            //App._searchResult.AddArtists(spotify.SearchArtists(query).Artists);
            spotify.SearchArtistsAsync(query, App.SearchArtistsCallback);
            spotify.SearchAlbumsAsync(query, App.SearchAlbumsCallback);
            spotify.SearchTracksAsync(query, App.SearchTracksCallback);
            var page = new View.GroupedCollectionPage();
            page.Groups = App._searchResult.SearchResultGroups;
            Window.Current.Content = page;
        }

        private static void SearchArtistsCallback(SearchResultArtists searchResult)
        {
            foreach (var item in searchResult.Artists)
                item.Group = App._searchResult[SearchResult.ArtistsGroupTitle];

            App._searchResult.AddArtists(searchResult.Artists);
            var page = Window.Current.Content as View.GroupedCollectionPage;
            page.Groups = App._searchResult.SearchResultGroups;
        }

        private static void SearchAlbumsCallback(SearchResultAlbums searchResult)
        {
            foreach (var item in searchResult.Albums)
                item.Group = App._searchResult[SearchResult.AlbumsGroupTitle];

            App._searchResult.AddAlbums(searchResult.Albums);
            var page = Window.Current.Content as View.GroupedCollectionPage;
            page.Groups = App._searchResult.SearchResultGroups;
        }

        private static void SearchTracksCallback(SearchResultTracks searchResult)
        {
            foreach (var item in searchResult.Tracks)
                item.Group = App._searchResult[SearchResult.TracksGroupTitle];

            App._searchResult.AddTracks(searchResult.Tracks);
            var page = Window.Current.Content as View.GroupedCollectionPage;
            page.Groups = App._searchResult.SearchResultGroups;
        }

        public static void ShowGroupedCollection()
        {
            var page = new View.GroupedCollectionPage();
            page.Groups = App._searchResult.SearchResultGroups;
            Window.Current.Content = page;
        }

        public static void ShowGroupedCollection_old()
        {
            var page = new View.GroupedCollectionPage();
            if (_sampleData == null) _sampleData = new SampleDataSource(page.BaseUri);
            page.Groups = _sampleData.GroupedCollections;
            Window.Current.Content = page;
        }

        public static void ShowCollectionSummary(IEnumerable<object> collection)
        {
            var page = new View.CollectionSummaryPage();
            if (_sampleData == null) _sampleData = new SampleDataSource(page.BaseUri);
            page.Items = collection;
            page.Item = collection;
            Window.Current.Content = page;
        }

        public static void ShowDetail(IEnumerable<object> collection, object item)
        {
            var page = new View.DetailPage();
            if (_sampleData == null) _sampleData = new SampleDataSource(page.BaseUri);
            page.Items = collection;
            page.Item = item;
            Window.Current.Content = page;
        }
    }
}
