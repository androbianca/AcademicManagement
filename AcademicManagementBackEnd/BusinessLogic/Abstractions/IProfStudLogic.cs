using Entities;
using Models;
using System.Collections.Generic;

namespace BusinessLogic.Abstractions
{
    public interface IProfStudLogic
    {
        IEnumerable<ProfStuds> Add(IEnumerable<ProfStudDto> profStudDtos);

    }
}
