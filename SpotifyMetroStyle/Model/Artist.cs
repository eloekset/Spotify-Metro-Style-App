using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spotify.MetroStyle.Model
{
    public class Artist : SearchResultItemBase
    {

        public Artist(string name, decimal popularity, string href)
            : base(name, popularity, null, href)
        {

        }
    }
}
