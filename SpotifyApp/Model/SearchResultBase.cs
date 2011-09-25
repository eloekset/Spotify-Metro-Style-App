using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Data;

namespace Spotify.Metro.Model
{
    public class SearchResultBase<T> where T : SearchResultItem, INotifyPropertyChanged
    {
        protected SearchResultInfo _info;
        public SearchResultInfo Info
        {
            get { return _info; }
            set
            {
                if (this._info != value)
                {
                    this._info = value;
                    OnPropertyChanged("Info");
                }
            }
        }

        protected List<T> _innerList;

        public SearchResultBase(SearchResultInfo info)
        {
            this._info = info;
            this._innerList = new List<T>();
        }

        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string propertyName)
        {
            if (this.PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}
