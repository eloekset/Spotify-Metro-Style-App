﻿#pragma checksum "C:\Users\eloekset\Documents\Visual Studio 11\Projects\SpotifyMetroStyle\SpotifyMetroStyle\CollectionPage.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "835427997D9F946B6DECCF60AC0B1045"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using Windows.Foundation;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Markup;

namespace Spotify.MetroStyle
{
    public partial class CollectionPage : Windows.UI.Xaml.Controls.UserControl
    {
        Windows.UI.Xaml.Data.CollectionViewSource CollectionViewSource;
        Windows.UI.Xaml.Controls.Grid LayoutRoot;
        Windows.UI.Xaml.VisualStateGroup OrientationStates;
        Windows.UI.Xaml.VisualState Full;
        Windows.UI.Xaml.VisualState Fill;
        Windows.UI.Xaml.VisualState Portrait;
        Windows.UI.Xaml.VisualState Snapped;
        Windows.UI.Xaml.Controls.GridView ItemGridView;
        Windows.UI.Xaml.Controls.ListView ItemListView;
        Windows.UI.Xaml.Controls.Button BackButton;
        Windows.UI.Xaml.Controls.TextBlock PageTitle;
        private bool _contentLoaded;

        public void InitializeComponent()
        {
            if (_contentLoaded)
                return;

            _contentLoaded = true;
            Application.LoadComponent(this, new System.Uri("ms-resource://spotifymetrostyle/Files/CollectionPage.xaml"));

            CollectionViewSource = (Windows.UI.Xaml.Data.CollectionViewSource)this.FindName("CollectionViewSource");
            LayoutRoot = (Windows.UI.Xaml.Controls.Grid)this.FindName("LayoutRoot");
            OrientationStates = (Windows.UI.Xaml.VisualStateGroup)this.FindName("OrientationStates");
            Full = (Windows.UI.Xaml.VisualState)this.FindName("Full");
            Fill = (Windows.UI.Xaml.VisualState)this.FindName("Fill");
            Portrait = (Windows.UI.Xaml.VisualState)this.FindName("Portrait");
            Snapped = (Windows.UI.Xaml.VisualState)this.FindName("Snapped");
            ItemGridView = (Windows.UI.Xaml.Controls.GridView)this.FindName("ItemGridView");
            ItemListView = (Windows.UI.Xaml.Controls.ListView)this.FindName("ItemListView");
            BackButton = (Windows.UI.Xaml.Controls.Button)this.FindName("BackButton");
            PageTitle = (Windows.UI.Xaml.Controls.TextBlock)this.FindName("PageTitle");
        }
    }
}


