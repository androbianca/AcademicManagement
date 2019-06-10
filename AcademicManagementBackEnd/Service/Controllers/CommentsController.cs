using BusinessLogic.Abstractions;
using Microsoft.AspNetCore.Mvc;
using Models;
using System;
using System.Collections.Generic;

namespace Service.Controllers
{
    [ApiController]
    [Route("api/comments")]
    public class CommentController : ControllerBase
    {

        private readonly ICommentLogic _commentLogic;

        public CommentController(ICommentLogic commentLogic)
        {
            _commentLogic = commentLogic;
        }

        [HttpGet("{postId:guid}")]
        public ActionResult<ICollection<CommentDto>> GetByPostId([FromRoute]Guid postId)
        {
            var comments = _commentLogic.GetComents(postId);

            return Ok(comments);
        }

        [HttpPost]
        public IActionResult AddComment([FromBody]CommentDto commentDto)
        {
            var comment = _commentLogic.AddComment(commentDto);

            return Ok();
        }
    }
}
