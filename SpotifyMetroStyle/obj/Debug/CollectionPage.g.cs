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
    public partial class CollectionPage : Windows.UI.Xaml.Controls.UserControl, IComponentConnector
    {
        public void Connect(int connectionId, object target)
        {
            switch(connectionId)
            {
            case 1:
                ((Windows.UI.Xaml.FrameworkElement)(target)).Loaded
                        += new Windows.UI.Xaml.RoutedEventHandler(this.Page_Loaded);
                ((Windows.UI.Xaml.FrameworkElement)(target)).Unloaded
                        += new Windows.UI.Xaml.RoutedEventHandler(this.Page_Unloaded);
                break;
            case 2:
                ((Windows.UI.Xaml.Controls.Primitives.Selector)(target)).SelectionChanged
                        += new Windows.UI.Xaml.Controls.SelectionChangedEventHandler(this.ItemView_SelectionChanged);
                break;
            case 3:
                ((Windows.UI.Xaml.Controls.Primitives.Selector)(target)).SelectionChanged
                        += new Windows.UI.Xaml.Controls.SelectionChangedEventHandler(this.ItemView_SelectionChanged);
                break;
            }
            this._contentLoaded = true;
        }
    }
}


