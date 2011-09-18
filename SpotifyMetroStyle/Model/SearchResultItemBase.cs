using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spotify.MetroStyle.Model
{
    public class SearchResultItemBase : BindableItemBase
    {
        public string Name
        {
            get { return base.Title; }
            set
            {
                if (base.Title != value)
                {
                    base.Title = value;
                    NotifyPropertyChanged("Name");
                }
            }
        }

        public override string Title
        {
            get { return base.Title; }
            set
            {
                if (base.Title != value)
                {
                    this.Name = value;
                    NotifyPropertyChanged("Title");
                }
            }
        }

        private decimal _popularity = decimal.MinusOne;
        public decimal Popularity
        {
            get { return _popularity; }
            set
            {
                this._popularity = value;
                NotifyPropertyChanged("Popularity");
            }
        }

        private List<ExternalId> _externalIds = new List<ExternalId>();
        public List<ExternalId> ExternalIds
        {
            get { return _externalIds; }
            set
            {
                if (this._externalIds != value)
                {
                    this._externalIds = value;
                    NotifyPropertyChanged("ExternalIds");
                }
            }
        }

        private string _href;
        public string Href
        {
            get { return _href; }
            set
            {
                if (this._href != value)
                {
                    this._href = value;
                    NotifyPropertyChanged("Href");
                }
            }
        }

        public SearchResultItemBase(string name, decimal popularity, IEnumerable<ExternalId> externalIds, string href)
            : base(name, null, null)
        {
            this.Popularity = popularity;
            if (externalIds != null)
                this.ExternalIds.AddRange(externalIds);
            this.Href = href;
        }

    }
}
