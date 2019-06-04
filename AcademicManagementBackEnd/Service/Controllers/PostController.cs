using BusinessLogic.Abstractions;
using Microsoft.AspNetCore.Mvc;
using Models;
using System.Collections.Generic;

namespace Service.Controllers
{
    [Route("api/posts")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private IPostLogic _postLogic;

        public PostController(IPostLogic postLogic)
        {
            _postLogic = postLogic;
        }

        [HttpPost]
        public IActionResult AddPost(PostDto postDto)
        {

            var result = _postLogic.Add(postDto);

            return Ok();
        }

        [HttpGet]
        public ActionResult<ICollection<PostDto>> GetAll()
        {

            var result = _postLogic.GetAll();

            return Ok(result);
        }

    }

}
