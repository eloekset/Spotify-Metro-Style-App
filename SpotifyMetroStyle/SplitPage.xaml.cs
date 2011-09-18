using System;
using System.Collections.Generic;
using System.Linq;
using Windows.Foundation;
using Windows.Graphics.Display;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;

namespace Spotify.MetroStyle
{
    public sealed partial class SplitPage
    {
        public SplitPage()
        {
            InitializeComponent();
        }

        private bool _ignoreReentrancy;
        void ItemListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (!this.IsSnappedOrPortrait() || _ignoreReentrancy) return;

            //Temporary: Workaround for view state change disturbing selection
            _ignoreReentrancy = true;
            var selectedItem = ItemListView.SelectedItem;
            this.SetCurrentViewState(this);
            ItemListView.SelectedItem = selectedItem;
            _ignoreReentrancy = false;
        }

        void BackButton_Click(object sender, RoutedEventArgs e)
        {
            if (this.IsSnappedOrPortrait() && ItemListView.SelectedItem != null)
            {
                ItemListView.SelectedItem = null;
            }
            else
            {
                // Construct the appropriate destination page and set its context appropriately
                App.ShowCollection();
            }
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

        private String GetViewState()
        {
            var hasSelection = ItemListView.SelectedItem != null;

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
