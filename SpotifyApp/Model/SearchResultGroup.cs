using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Data;

namespace Spotify.Metro.Model
{
    public class SearchResultGroup : SearchResultItem, IGroupInfo
    {
        private List<SearchResultItem> _searchResults = new List<SearchResultItem>();

        public override string Subtitle
        {
            get
            {
                return _searchResults.Count + " items";
            }
            set
            {
                base.Subtitle = value;
            }
        }

        public void Add(SearchResultItem item)
        {
            this._searchResults.Add(item);
        }

        public void AddRange(IEnumerable<SearchResultItem> items)
        {
            this._searchResults.AddRange(items);
        }

        #region IGroupInfo
        public object Key
        {
            get { return this; }
        }

        public IEnumerator<object> GetEnumerator()
        {
            return this._searchResults.GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
        #endregion
    }
}
