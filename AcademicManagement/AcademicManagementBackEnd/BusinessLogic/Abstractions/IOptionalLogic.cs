using Entities;
using Microsoft.AspNetCore.Http;
using Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public interface IOptionalLogic
    {
        Task<Optional> UploadFiles(IFormFile file, string googleForm, string time);
        void Create(Optional optional);
        ICollection<OptionalDto> GetAll();
        Optional Delete(Guid id);

    }
}
