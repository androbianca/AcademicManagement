using Entities;
using Models;
using System;
using System.Collections.Generic;

namespace BusinessLogic.Abstractions
{
    public interface IPotentialUserLogic
    {
        PotentialUser Add(PotentialUserDto potentialUserDto);
        PotentialUser Remove(Guid id);
        ICollection<string> GetEmails();
        PotentialUserDto GetByUserCode(string id);
    }
}
