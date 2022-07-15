using Newtonsoft.Json;
using System.Text;

namespace Silverhorse.WebApi.Helpers
{
    public static class HttpClientHelper
    {
        private static HttpClient _httpClient = new HttpClient();
        private static string _baseUrl = "https://jsonplaceholder.typicode.com/";
        private static HttpResponseMessage? _httpResponseMessage;

        public static async Task<string> GetHttpResponse(string endPoint, int id = 0)
        {
            string url = _baseUrl + endPoint;            

            if (id > 0) url = _baseUrl + endPoint + "/" + id.ToString();

            _httpResponseMessage = await _httpClient.GetAsync(url);
            _httpResponseMessage.EnsureSuccessStatusCode();

            return await _httpResponseMessage.Content.ReadAsStringAsync();
        }

        public static async Task<string> PostHttpResponse(string endPoint, object content)
        {
            HttpContent httpContent = new StringContent(JsonConvert.SerializeObject(content), Encoding.UTF8);
            _httpResponseMessage = await _httpClient.PostAsync(_baseUrl + endPoint, httpContent);
            _httpResponseMessage.EnsureSuccessStatusCode();
            
            return await _httpResponseMessage.Content.ReadAsStringAsync();
            
        }

        public static async Task<string> PutHttpResponse(string endPoint, object content, int id)
        {
            HttpContent httpContent = new StringContent(JsonConvert.SerializeObject(content), Encoding.UTF8);
            _httpResponseMessage = await _httpClient.PostAsync(_baseUrl + endPoint + "/" + id.ToString(), httpContent);
            _httpResponseMessage.EnsureSuccessStatusCode();

            return await _httpResponseMessage.Content.ReadAsStringAsync();

        }

        public static async Task<string> DeleteHttpResponse(string endPoint, int id)
        {
            _httpResponseMessage = await _httpClient.DeleteAsync(_baseUrl + endPoint + "/" + id.ToString());
            _httpResponseMessage.EnsureSuccessStatusCode();

            return await _httpResponseMessage.Content.ReadAsStringAsync();

        }

    }
}
