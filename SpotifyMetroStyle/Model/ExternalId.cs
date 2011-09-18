using System;
using System.Collections.Generic;
using Windows.UI.Xaml.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spotify.MetroStyle.Model
{
    public class ExternalId : INotifyPropertyChanged
    {
        public string _type;
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

        public string _id;
        public string Id
        {
            get { return _id; }
            set
            {
                if (this._id != value)
                {
                    this._id = value;
                    NotifyPropertyChanged("Id");
                }
            }
        }

        public ExternalId(string type, string id)
        {
            this.Type = type;
            this.Id = id;
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
