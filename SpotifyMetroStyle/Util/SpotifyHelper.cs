using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using Newtonsoft.Json;
using System.IO;
using Spotify.MetroStyle.Model;

namespace Spotify.MetroStyle.Util
{
    class SpotifyHelper
    {
        public string UserId { get; set; }
        DelegateMarshaler _marshaler;

        public SpotifyHelper(string userId)
        {
            this.UserId = userId;
            this._marshaler = DelegateMarshaler.Create();
        }

        public void SearchAlbumsAsync(string query, Action<SearchResultAlbum> callback)
        {
            this.SearchAsync<SearchResultAlbum>(query, callback);
        }

        public void SearchArtistsAsync(string query, Action<SearchResultArtist> callback)
        {
            this.SearchAsync<SearchResultArtist>(query, callback);
        }

        public void SearchTracksAsync(string query, Action<SearchResultTrack> callback)
        {
            this.SearchAsync<SearchResultTrack>(query, callback);
        }

        private void SearchAsync<Tresult>(string query, Action<Tresult> callback) where Tresult : SearchResultBase, new()
        {
            string uriTypePart;
            Tresult searchResult = new Tresult();
            if (searchResult is SearchResultAlbum)
                uriTypePart = "album";
            else if (searchResult is SearchResultArtist)
                uriTypePart = "artist";
            else
                uriTypePart = "track";

            string urlEncodedQuery = this.UrlEncode(query);
            string uri = string.Format(@"http://ws.spotify.com/search/1/{0}.json?q={1}", uriTypePart, urlEncodedQuery);
            HttpWebRequest request = WebRequest.Create(uri) as HttpWebRequest;

            request.BeginGetResponse((result) =>
            {
                WebResponse response = request.EndGetResponse(result);
                string json = new StreamReader(response.GetResponseStream()).ReadToEnd();

                if (json != null && json.Length > 0)
                {
                    using (StringReader stringReader = new StringReader(json))
                    using (JsonTextReader reader = new JsonTextReader(stringReader))
                    {
                        JsonSerializer serializer = new JsonSerializer();
                        Tresult spotifyResult = serializer.Deserialize<Tresult>(reader);                                                
                        this._marshaler.Invoke<Tresult>(callback, spotifyResult);
                    }
                }
            }, null);
        }

        private string UrlEncode(string str)
        {
            return System.Text.RegularExpressions.Regex.Replace(str, @"[^\w]", m => "%" + ((int)m.Value[0]).ToString("X2"));
        }
    }
}
