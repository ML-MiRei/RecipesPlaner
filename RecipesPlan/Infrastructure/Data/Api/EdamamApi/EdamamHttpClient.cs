using RecipesPlan.Core.Entities;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace RecipesPlan.Data.Api.EdamamApi
{
    internal class EdamamHttpClient : IDisposable
    {


        private static readonly HttpClient _httpClient;
        static EdamamHttpClient()
        {
            _httpClient = new HttpClient();
            _httpClient.Timeout = TimeSpan.FromSeconds(600);
        }

        public static HttpClient GetHttpClient()
        {
            return _httpClient;
        }

        public void Dispose()
        {
            _httpClient?.Dispose();
        }
    }
}
