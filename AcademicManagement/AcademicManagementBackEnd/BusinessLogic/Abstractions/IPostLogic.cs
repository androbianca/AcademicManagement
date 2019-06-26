using Entities;
using Models;
using System.Collections.Generic;

namespace BusinessLogic.Abstractions
{
    public interface IPostLogic
    {
        Post Add(PostDto postDto);
        ICollection<PostDto> GetAll();
    }
}
