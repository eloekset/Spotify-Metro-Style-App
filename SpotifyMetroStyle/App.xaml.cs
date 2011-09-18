using Expression.Blend.SampleData.SampleDataSource;
using System;
using System.Linq;
using Windows.ApplicationModel.Activation;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Data;

namespace Spotify.MetroStyle
{
    partial class App
    {
        // TODO: Create a data model appropriate for your problem domain to replace the sample data
        private static SampleDataSource _sampleData;

        public App()
        {
            InitializeComponent();
        }

        protected override void OnLaunched(LaunchActivatedEventArgs args)
        {
            //ShowSplit(null);
            ShowSearch();
            Window.Current.Activate();
            //SpotifyHelper spotify = new SpotifyHelper("eloekset@msn.com");
            //SearchResultAlbum result = spotify.SearchForAlbums("the");
        }        

        public static void ShowCollection()
        {
            var page = new CollectionPage();
            if (_sampleData == null) _sampleData = new SampleDataSource(page.BaseUri);
            page.Items = _sampleData.GroupedCollections.Select((obj) => (Object)obj);
            Window.Current.Content = page;
        }

        public static void ShowSplit(IGroupInfo collection)
        {
            var page = new SplitPage();
            if (_sampleData == null) _sampleData = new SampleDataSource(page.BaseUri);
            if (collection == null) collection = _sampleData.GroupedCollections.First();
            page.Items = collection;
            page.Context = collection.Key;
            Window.Current.Content = page;
        }

        public static void ShowSearch()
        {
            var page = new View.SearchPage();
            Window.Current.Content = page;
        }
    }
}
