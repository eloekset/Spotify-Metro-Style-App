using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Data;

namespace Spotify.Metro.Model
{
    public class SearchResultInfo : INotifyPropertyChanged
    {

        private int _numberOfResults;
        [Newtonsoft.Json.JsonProperty("num_results")]
        public int NumberOfResults
        {
            get { return _numberOfResults; }
            set
            {
                if (this._numberOfResults != value)
                {
                    this._numberOfResults = value;
                    NotifyPropertyChanged("NumberOfResults");
                }
            }
        }

        private int _limit;
        public int Limit
        {
            get { return _limit; }
            set
            {
                if (this._limit != value)
                {
                    this._limit = value;
                    NotifyPropertyChanged("Limit");
                }
            }
        }

        private int _offset;
        public int Offset
        {
            get { return _offset; }
            set
            {
                if (this._offset != value)
                {
                    this._offset = value;
                    NotifyPropertyChanged("Offset");
                }
            }
        }

        private string _query;
        public string Query
        {
            get { return _query; }
            set
            {
                if (this._query != value)
                {
                    this._query = value;
                    NotifyPropertyChanged("Query");
                }
            }
        }

        private string _type;
        public string Type
        {
            get { return _type; }
            set
            {
                if (this._type != value)
                {
                    this._type = value;
                    NotifyPropertyChanged("Type");
                }
            }
        }

        private int _page;
        public int Page
        {
            get { return _page; }
            set
            {
                if (this._page != value)
                {
                    this._page = value;
                    NotifyPropertyChanged("Page");
                }
            }
        }

        public SearchResultInfo() { }

        public SearchResultInfo(string type)
            : this()
        {
            this.Type = type;
        }

        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;

        public void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion

    }
}
