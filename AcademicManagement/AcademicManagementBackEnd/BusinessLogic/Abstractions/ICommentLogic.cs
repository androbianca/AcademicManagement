using Entities;
using Models;
using System;
using System.Collections.Generic;

namespace BusinessLogic.Abstractions
{
    public interface ICommentLogic
    {
        Comment AddComment(CommentDto commentDto);
        ICollection<CommentDto> GetComents(Guid postId);
    }
}
