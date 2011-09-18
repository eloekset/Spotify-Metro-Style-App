using System;
using Windows.UI.Xaml.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spotify.MetroStyle.Model
{
    public abstract class SearchResultBase : INotifyPropertyChanged
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
                    NotifyPropertyChanged("Info");
                }
            }
        }

        public SearchResultBase(SearchResultInfo info)
        {
            this._info = info;
        }

        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;

        public void NotifyPropertyChanged(string propertyName)
        {
            if (this.PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}
