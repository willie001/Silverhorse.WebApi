using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Silverhorse.WebApi.DAL;
using Silverhorse.WebApi.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Silverhorse.WebApi.Controllers
{
    [Route("api/posts")]
    [ApiController]
    public class PostsController : ControllerBase
    {
        // GET: api/<PostsController>
        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetPosts()
        {
            try
            {

                var allPosts = await DSPost.AllPostsAsync();

                return Ok(allPosts);
            }
            catch (Exception ex)
            {                
                return StatusCode(500, ex.Message.ToString());
            }
        }

        // GET api/<PostsController>/5
        [HttpGet("{id}")]
        [Authorize]
        public async Task<IActionResult> GetPost(int id)
        {
            try
            {
                var post = await DSPost.GetPostAsync(id);

                return Ok(post);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message.ToString());
            }
        }

        // POST api/<PostsController>
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> CreatePost([FromBody] Post post)
        {
            try
            {
                if (post == null)
                {                    
                    return BadRequest("CompanyForCreationDto object is null");
                }

                var newPost = await DSPost.AddPostAsync(post);

                return Ok(newPost);

            }
            catch (Exception ex)
            {                
                return StatusCode(500, ex.Message.ToString());
            }
        }

        // PUT api/<PostsController>/5
        [HttpPut("{id}")]
        [Authorize]
        public async Task<IActionResult> UpdatePost([FromBody] Post post, int id)
        {
            try
            {
                if (post == null)
                {
                    return BadRequest("CompanyForCreationDto object is null");
                }

                var newPost = await DSPost.UpdatePostAsync(post, id);

                return Ok(newPost);

            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message.ToString());
            }
        }

        // DELETE api/<PostsController>/5
        [HttpDelete("{id}")]
        [Authorize]
        public void Delete(int id)
        {
        }
    }
}
