using Newtonsoft.Json;
using Silverhorse.WebApi.Models;

namespace Silverhorse.WebApi.DAL
{
    public static class DSCollection
    {

        public static IConfiguration StaticConfig { get; private set; }
        public static async Task<Dictionary<string, List<object>>> CollectionsAsync()
        {                 
            //Get posts
            string responsePosts = await HttpResponse("posts");
            List<Post> objectListPosts = JsonConvert.DeserializeObject<List<Post>>(responsePosts);

            //Get albums           
            string responseAlbums = await HttpResponse("albums");
            List<Album> objectListAlbums = JsonConvert.DeserializeObject<List<Album>>(responseAlbums);

            //Get users            
            string responseUsers = await HttpResponse("users");
            List<Album> objectListUsers = JsonConvert.DeserializeObject<List<Album>>(responseUsers);            

            List<object> posts = new List<object>();
            List<object> albums = new List<object>(); 
            List<object> users = new List<object>();
                        
            Random p = new Random();
            Random a = new Random();
            Random c = new Random();

            for (var i = 0; i < 10; i += 1)
            {
                posts.Add(objectListPosts[p.Next(0, 100)]);
                albums.Add(objectListAlbums[a.Next(0, 100)]);
                users.Add(objectListUsers[c.Next(0, 10)]);
            }            

            Dictionary<string, List<object>> result = new Dictionary<string, List<object>>();

            result.Add("post", posts);
            result.Add("album", albums);
            result.Add("user", users);

            string serialData = JsonConvert.SerializeObject(result);

            return result;
        }

        public static async Task<string> HttpResponse(string endPoint)
        {
            string baseUrl = "https://jsonplaceholder.typicode.com/"
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync(baseUrl + endPoint);
            response.EnsureSuccessStatusCode();

            return await response.Content.ReadAsStringAsync();
        }
    }
}
