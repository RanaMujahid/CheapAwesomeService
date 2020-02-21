using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CheapAwesomeServices.Utility
{
    public class APIGateWay
    {

        private readonly HttpClient _httpClient;
        private readonly string baseURL;

        public APIGateWay(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            baseURL = "https://webbedsdevtest.azurewebsites.net/api";
        }
        /// <summary>  
        /// Common method for making GET calls  
        /// </summary>  
        public async Task<T> GetAsync<T>(string requestUrl)
        {
            var response = await _httpClient.GetAsync(baseURL + requestUrl, HttpCompletionOption.ResponseHeadersRead);
            response.EnsureSuccessStatusCode();
            var data = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<T>(data);
        }

        /// <summary>  
        /// Common method for making POST calls  
        /// </summary>  
        public async Task<T> PostAsync<T>(string requestUrl, T content)
        {
            var response = await _httpClient.PostAsync(baseURL + requestUrl, CreateHttpContent<T>(content));
            response.EnsureSuccessStatusCode();
            var data = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<T>(data);
        }

        private HttpContent CreateHttpContent<T>(T content)
        {
            var json = JsonConvert.SerializeObject(content);
            return new StringContent(json, Encoding.UTF8, "application/json");
        }
    }
}
