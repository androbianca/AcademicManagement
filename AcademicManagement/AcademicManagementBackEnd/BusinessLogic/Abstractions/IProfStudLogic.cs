using Entities;
using Models;
using System;
using System.Collections.Generic;

namespace BusinessLogic.Abstractions
{
    public interface IProfStudLogic
    {
        IEnumerable<ProfStuds> Add(IEnumerable<ProfStudDto> profStudDtos);
        void Delete(Guid profStudDtoId);
        IEnumerable<ProfStudDto> GetByProfId(Guid profId);
    }
}
