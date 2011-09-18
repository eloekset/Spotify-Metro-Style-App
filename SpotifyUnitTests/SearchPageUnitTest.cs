using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Spotify.MetroStyle.ViewModel;

namespace SpotifyUnitTests
{
    [TestClass]
    public class SearchPageUnitTest
    {
        [TestMethod]        
        public void FindKnownArtist()
        {
            SearchPageViewModel viewModel = new SearchPageViewModel();
            Assert.IsFalse(viewModel.SearchCommand.CanExecute(viewModel.SearchText), "Can execute search with empty query");                       
            viewModel.SearchText = "a-ha";
            Assert.IsTrue(viewModel.SearchCommand.CanExecute(viewModel.SearchText), "Cannot execute search with query content");
            viewModel.SearchCommand.Execute(viewModel.SearchText);
            Thread.SpinWait(10);
            Assert.IsNotNull(viewModel.Artists, "Artists property is null");
            Assert.IsTrue(viewModel.Artists.Artists.Count >= 1, "No artists named 'a-ha'");
            Assert.IsTrue(viewModel.Artists.Info.NumberOfResults >= 1, "Info says no artists named 'a-ha'");
            Assert.AreEqual<int>(viewModel.Artists.Artists.Count, viewModel.NumberOfArtists, "Number of artists doesn't match NumberOfArtists");
        }
    }
}
