using Newtonsoft.Json;
using Silverhorse.WebApi.Models;
using System.Text;

namespace Silverhorse.WebApi.DAL
{
    public static class DSPost
    {
        public static async Task<List<Post>> AllPostsAsync()
        {

            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync("https://jsonplaceholder.typicode.com/posts");
            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();
            List<Post> postList = JsonConvert.DeserializeObject<List<Post>>(responseBody);

            return postList;
        }

        public static async Task<Post> GetPostAsync(int id)
        {
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync("https://jsonplaceholder.typicode.com/posts/" + id.ToString());
            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();
            var obj = JsonConvert.DeserializeObject<Post>(responseBody);

            return obj;
        }

        public static async Task<Post> AddPostAsync(Post post)
        {
            HttpContent httpContent = new StringContent(JsonConvert.SerializeObject(post), Encoding.UTF8);
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.PostAsync("https://jsonplaceholder.typicode.com/posts/", httpContent);
            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();
            var obj = JsonConvert.DeserializeObject<Post>(responseBody);

            return obj;

        }

        public static async Task<Post> UpdatePostAsync(Post post, int id)
        {
            HttpContent httpContent = new StringContent(JsonConvert.SerializeObject(post), Encoding.UTF8);
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.PutAsync("https://jsonplaceholder.typicode.com/posts/" + id.ToString(), httpContent);
            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();
            var obj = JsonConvert.DeserializeObject<Post>(responseBody);

            return obj;

        }

        public static async Task<Post> UpdatePostAsync(int id)
        {
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.DeleteAsync("https://jsonplaceholder.typicode.com/posts/" + id.ToString());
            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();
            var obj = JsonConvert.DeserializeObject<Post>(responseBody);

            return obj;

        }
    }
}
