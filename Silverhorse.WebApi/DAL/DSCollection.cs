﻿using Newtonsoft.Json;
using Silverhorse.WebApi.Models;

namespace Silverhorse.WebApi.DAL
{
    public static class DSCollection
    {
        public static async Task<string> CollectionsAsync()
        {
            //Get posts
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync("https://jsonplaceholder.typicode.com/posts");
            response.EnsureSuccessStatusCode();
            string responsePosts = await response.Content.ReadAsStringAsync();
            List<Post> objectListPosts = JsonConvert.DeserializeObject<List<Post>>(responsePosts);

            //Get albums
            response = await client.GetAsync("https://jsonplaceholder.typicode.com/albums");
            response.EnsureSuccessStatusCode();
            string responseAlbums = await response.Content.ReadAsStringAsync();
            List<Album> objectListAlbums = JsonConvert.DeserializeObject<List<Album>>(responseAlbums);

            //Get users
            response = await client.GetAsync("https://jsonplaceholder.typicode.com/users");
            response.EnsureSuccessStatusCode();
            string responseUsers = await response.Content.ReadAsStringAsync();
            List<Album> objectListUsers = JsonConvert.DeserializeObject<List<Album>>(responseUsers);

            List<Object> collection = new List<object>();

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

            collection.Add(posts);
            collection.Add(albums);
            collection.Add(users);

            Dictionary<string, List<object>> result = new Dictionary<string, List<object>>();

            result.Add("post", posts);
            result.Add("album", albums);
            result.Add("user", users);

            string serialData = JsonConvert.SerializeObject(result);

            return serialData;
        }
    }
}
