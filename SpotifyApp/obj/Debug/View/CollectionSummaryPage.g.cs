﻿#pragma checksum "C:\Users\eloekset\Documents\Visual Studio 11\Projects\SpotifyApp\SpotifyApp\View\CollectionSummaryPage.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "AC5B2A434158F3EAB8B53233336E8AC9"
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

namespace Spotify.Metro.View
{
    public partial class CollectionSummaryPage : Windows.UI.Xaml.Controls.UserControl, IComponentConnector
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
            case 4:
                ((Windows.UI.Xaml.Controls.Primitives.ButtonBase)(target)).Click
                        += new Windows.UI.Xaml.RoutedEventHandler(this.BackButton_Click);
                break;
            }
            this._contentLoaded = true;
        }
    }
}


