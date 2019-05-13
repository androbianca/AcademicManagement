using Entities;
using Models;
using System.Collections.Generic;

namespace BusinessLogic.Abstractions
{
    public interface IProfStudLogic
    {
        IEnumerable<ProfStuds> AddProfStud(IEnumerable<ProfStudDto> profStudDtos);

    }
}
