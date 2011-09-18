using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Media;
using System.Net.Http;

namespace Spotify.MetroStyle.Util
{
    class ImageLoader
    {

        public ImageSource LoadImage(string imageUri)
        {
            throw new NotImplementedException();
        }


        public void LoadImageAsync(string imageUri, Action<ImageSource> callback)
        {
            //System.Net.WebRequest.Create(imageUri).BeginGetResponse((c)  =>
            //{

            //    ImageSource imageSource = c.AsyncState as ImageSource;
            //    callback.Invoke(imageSource);
            //}, null);
            throw new NotImplementedException();
        }
    }
}
