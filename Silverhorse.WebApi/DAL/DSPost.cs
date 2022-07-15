using Newtonsoft.Json;
using Silverhorse.WebApi.Helpers;
using Silverhorse.WebApi.Models;
using System.Text;

namespace Silverhorse.WebApi.DAL
{
    public static class DSPost
    {
        public static async Task<List<Post>> AllPostsAsync()
        {                       
            string responseBody = await HttpClientHelper.GetHttpResponse("posts"); 
            List<Post>? postList = JsonConvert.DeserializeObject<List<Post>>(responseBody);

            return postList;
        }

        public static async Task<Post> GetPostAsync(int id)
        {           
            string responseBody = await HttpClientHelper.GetHttpResponse("posts", id);
            var obj = JsonConvert.DeserializeObject<Post>(responseBody);

            return obj;
        }

        public static async Task<Post> AddPostAsync(Post post)
        {            
            string responseBody = await HttpClientHelper.PostHttpResponse("posts", post);
            var obj = JsonConvert.DeserializeObject<Post>(responseBody);

            return obj;
        }

        public static async Task<Post> UpdatePostAsync(Post post, int id)
        {            
            string responseBody = await HttpClientHelper.PutHttpResponse("posts", post, id);
            var obj = JsonConvert.DeserializeObject<Post>(responseBody);

            return obj;
        }

        public static async Task<Post> DeletePostAsync(int id)
        {            
            string responseBody = await HttpClientHelper.DeleteHttpResponse("posts", id);
            var obj = JsonConvert.DeserializeObject<Post>(responseBody);

            return obj;
        }
    }
}
