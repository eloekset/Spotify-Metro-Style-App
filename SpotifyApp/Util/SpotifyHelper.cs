using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using Newtonsoft.Json;
using System.IO;
using Expression.Blend.SampleData.SampleDataSource;
using Spotify.Metro.Model;

namespace Spotify.Metro.Util
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

        public void SearchAlbumsAsync(string query, Action<SearchResultAlbums> callback)
        {
            this.SearchAsync<SearchResultAlbums>(query, "album", callback);
        }

        public SearchResultArtists SearchArtists(string query)
        {
            string urlEncodedQuery = this.UrlEncode(query);
            string uri = string.Format(@"http://ws.spotify.com/search/1/{0}.json?q={1}", "artist", urlEncodedQuery);
            HttpWebRequest request = WebRequest.Create(uri) as HttpWebRequest;
            SearchResultArtists searchResult = new SearchResultArtists();
            searchResult.Info.NumberOfResults = 1;
            searchResult.Info.Query = "artist";
            searchResult.Info.Offset = 0;
            searchResult.Info.Page = 1;
            searchResult.Artists.Add(new ArtistSearchResult { Title = "a-ha", Popularity = 5 });

            return searchResult;
        }

        public void SearchArtistsAsync(string query, Action<SearchResultArtists> callback)
        {
            this.SearchAsync<SearchResultArtists>(query, "artist", callback);
        }

        public void SearchTracksAsync(string query, Action<SearchResultTracks> callback)
        {
            this.SearchAsync<SearchResultTracks>(query, "track", callback);
        }

        private void SearchAsync<Tresult>(string query, string searchFor, Action<Tresult> callback) 
        {
            //string uriTypePart;
            //Tresult searchResult = new Tresult();
            //if (searchResult is SearchResultAlbum)
            //    uriTypePart = "album";
            //else if (searchResult is SearchResultArtist)
            //    uriTypePart = "artist";
            //else
            //    uriTypePart = "track";

            string urlEncodedQuery = this.UrlEncode(query);
            string uri = string.Format(@"http://ws.spotify.com/search/1/{0}.json?q={1}", searchFor, urlEncodedQuery);
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
