using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Silverhorse.WebApi.DAL;

namespace Silverhorse.WebApi.Controllers
{
    [ApiController]
    [Route("api/collections")]
    public class CollectionController : Controller
    {
        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetCollections()
        {
            try
            {
                var collections = await DSCollection.CollectionsAsync();

                return Ok(collections);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message.ToString());
            }
        }
    }
}
