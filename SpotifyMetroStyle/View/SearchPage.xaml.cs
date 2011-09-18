using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using Newtonsoft.Json;
using Spotify.MetroStyle.ViewModel;
using Windows.Foundation;
using Windows.Graphics.Display;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;

namespace Spotify.MetroStyle.View
{
    public sealed partial class SearchPage
    {
        public SearchPageViewModel ViewModel
        {
            get { return this.DataContext as SearchPageViewModel; }
            private set { this.DataContext = value; }
        }

        public SearchPage()
        {
            InitializeComponent();
            this.ViewModel = new SearchPageViewModel();
        }

        private bool _ignoreReentrancy;
        void ItemListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (!this.IsSnappedOrPortrait() || _ignoreReentrancy) return;

            //Temporary: Workaround for view state change disturbing selection
            _ignoreReentrancy = true;
            //var selectedItem = ItemListView.SelectedItem;
            //this.SetCurrentViewState(this);
            //ItemListView.SelectedItem = selectedItem;
            _ignoreReentrancy = false;
        }

        void BackButton_Click(object sender, RoutedEventArgs e)
        {
            //if (this.IsSnappedOrPortrait() && ItemListView.SelectedItem != null)
            //{
            //    ItemListView.SelectedItem = null;
            //}
            //else
            //{
            //    //TODO: Construct the appropriate destination page and set its context appropriately
            //}
        }

        private Object _context;
        public Object Context
        {
            get
            {
                return this._context;
            }

            set
            {
                this._context = value;
                this.PageTitle.DataContext = value;
            }
        }

        private IEnumerable<Object> _items;
        public IEnumerable<Object> Items
        {
            get
            {
                return this._items;
            }

            set
            {
                this._items = value;
                this.CollectionViewSource.Source = value;
                if (!this.IsSnappedOrPortrait()) this.CollectionViewSource.View.MoveCurrentToFirst();
            }
        }


        private bool IsSnappedOrPortrait()
        {
            var state = GetViewState();
            return !(state.Equals("Full") || state.Equals("Fill"));
        }

        // View state management for switching among Full, Fill, Snapped, and Portrait states.
        // Complicated by additional states representing two logical pages (master + detail) for
        // portrait and snapped states.

        private DisplayPropertiesEventHandler _displayHandler;
        private TypedEventHandler<ApplicationLayout, ApplicationLayoutChangedEventArgs> _layoutHandler;

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            if (_displayHandler == null)
            {
                _displayHandler = Page_OrientationChanged;
                _layoutHandler = Page_LayoutChanged;
            }
            DisplayProperties.OrientationChanged += _displayHandler;
            ApplicationLayout.GetForCurrentView().LayoutChanged += _layoutHandler;
            SetCurrentViewState(this);
            this.SearchTextBox.Focus();            
        }

        private void Page_Unloaded(object sender, RoutedEventArgs e)
        {
            DisplayProperties.OrientationChanged -= _displayHandler;
            ApplicationLayout.GetForCurrentView().LayoutChanged -= _layoutHandler;
        }

        private void Page_LayoutChanged(object sender, ApplicationLayoutChangedEventArgs e)
        {
            SetCurrentViewState(this);
        }

        private void Page_OrientationChanged(object sender)
        {
            SetCurrentViewState(this);
        }

        private void SetCurrentViewState(Control viewStateAwareControl)
        {
            VisualStateManager.GoToState(viewStateAwareControl, this.GetViewState(), false);
        }

        private void AlbumsGrid_Tapped(object sender, RoutedEventArgs e)
        {
            this.ViewModel.ShowSearchResultFor("albums");
        }

        private void ArtistsGrid_Tapped(object sender, RoutedEventArgs e)
        {
            this.ViewModel.ShowSearchResultFor("artists");
        }

        private void TracksGrid_Tapped(object sender, RoutedEventArgs e)
        {
            this.ViewModel.ShowSearchResultFor("tracks");
        }

        private void ResultListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private String GetViewState()
        {
            var hasSelection = false; // ItemListView.SelectedItem != null;

            var orientation = DisplayProperties.CurrentOrientation;
            if (orientation == DisplayOrientations.Portrait ||
                orientation == DisplayOrientations.PortraitFlipped)
            {
                return hasSelection ? "PortraitDetail" : "Portrait";
            }

            var layout = ApplicationLayout.Value;
            if (layout == ApplicationLayoutState.Filled) return "Fill";
            if (layout == ApplicationLayoutState.Snapped)
            {
                return hasSelection ? "SnappedDetail" : "Snapped";
            }
            return "Full";
        }
    }
}
