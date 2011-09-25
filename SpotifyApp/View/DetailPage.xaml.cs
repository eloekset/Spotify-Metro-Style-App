using System;
using System.Collections.Generic;
using System.Linq;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Graphics.Display;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;

namespace Spotify.Metro.View
{
    public sealed partial class DetailPage
    {
        private PropertySet _flipState = new PropertySet();

        public DetailPage()
        {
            InitializeComponent();

            _flipState["CanFlipNext"] = false;
            _flipState["CanFlipPrevious"] = false;
            ApplicationBar.DataContext = _flipState;
        }

        void HomeButton_Click(object sender, RoutedEventArgs e)
        {
            // Construct the appropriate destination page and set its context appropriately
            App.ShowGroupedCollection();
        }

        void BackButton_Click(object sender, RoutedEventArgs e)
        {
            // Construct the appropriate destination page and set its context appropriately
            App.ShowCollectionSummary(Items);
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
                CollectionViewSource.Source = value;
                PageTitle.DataContext = value;
            }
        }

        public Object Item
        {
            get
            {
                return FlipView.SelectedItem;
            }

            set
            {
                FlipView.SelectedItem = value;
            }
        }

        // Mirror the flipper controls in the application bar

        void FlipView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            _flipState["CanFlipNext"] = CanFlipNext;
            _flipState["CanFlipPrevious"] = CanFlipPrevious;
        }

        bool CanFlipPrevious
        {
            get { return FlipView.SelectedIndex > 0; }
        }

        bool CanFlipNext
        {
            get { return FlipView.SelectedIndex < (FlipView.Items.Count - 1); }
        }

        void PreviousButton_Click(object sender, RoutedEventArgs e)
        {
            if (CanFlipPrevious) FlipView.SelectedIndex -= 1;
        }

        void NextButton_Click(object sender, RoutedEventArgs e)
        {
            if (CanFlipNext) FlipView.SelectedIndex += 1;
        }

        // View state management for switching among Full, Fill, Snapped, and Portrait states.
        // Complicated by the fact that the page is instantiated multiple times within a FlipView
        // context.

        private DisplayPropertiesEventHandler _displayHandler;
        private TypedEventHandler<ApplicationLayout, ApplicationLayoutChangedEventArgs> _layoutHandler;
        private List<Control> viewStateAwareControls = new List<Control>();

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            //Workaround: the initial selection for a FlipView isn't respected when it's made before the page is loaded,
            // so it's necessary to clear its state and try again once the page is loaded.  Clearly this is not intended
            // to be necessary.
            if (sender == this)
            {
                var originallySelectedItem = Item;
                Item = null;
                UpdateLayout();
                Item = originallySelectedItem;
            }

            var control = sender as Control;
            if (viewStateAwareControls.Count == 0)
            {
                if (_displayHandler == null)
                {
                    _displayHandler = Page_OrientationChanged;
                    _layoutHandler = Page_LayoutChanged;
                }
                DisplayProperties.OrientationChanged += _displayHandler;
                ApplicationLayout.GetForCurrentView().LayoutChanged += _layoutHandler;
            }
            viewStateAwareControls.Add(control);
            SetCurrentViewState(control);
        }

        private void Page_Unloaded(object sender, RoutedEventArgs e)
        {
            viewStateAwareControls.Remove(sender as Control);
            if (viewStateAwareControls.Count == 0)
            {
                DisplayProperties.OrientationChanged -= _displayHandler;
                ApplicationLayout.GetForCurrentView().LayoutChanged -= _layoutHandler;
            }
        }

        private void Page_LayoutChanged(object sender, ApplicationLayoutChangedEventArgs e)
        {
            foreach (var control in viewStateAwareControls)
            {
                SetCurrentViewState(control);
            }
        }

        private void Page_OrientationChanged(object sender)
        {
            foreach (var control in viewStateAwareControls)
            {
                SetCurrentViewState(control);
            }
        }

        private void SetCurrentViewState(Control viewStateAwareControl)
        {
            VisualStateManager.GoToState(viewStateAwareControl, this.GetViewState(), false);
        }

        private String GetViewState()
        {
            var orientation = DisplayProperties.CurrentOrientation;
            if (orientation == DisplayOrientations.Portrait ||
                orientation == DisplayOrientations.PortraitFlipped) return "Portrait";
            var layout = ApplicationLayout.Value;
            if (layout == ApplicationLayoutState.Filled) return "Fill";
            if (layout == ApplicationLayoutState.Snapped) return "Snapped";
            return "Full";
        }
    }
}
