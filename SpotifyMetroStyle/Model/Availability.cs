using System;
using System.Collections.Generic;
using Windows.UI.Xaml.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spotify.MetroStyle.Model
{
    public class Availability : INotifyPropertyChanged
    {

        private string _territories;
        public string Territories
        {
            get { return _territories; }
            set
            {
                if (this._territories != value)
                {
                    this._territories = value;
                    NotifyPropertyChanged("Territories");
                }
            }
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
