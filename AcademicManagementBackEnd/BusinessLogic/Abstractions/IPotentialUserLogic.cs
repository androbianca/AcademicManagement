using Entities;
using System;
using System.Collections.Generic;

namespace BusinessLogic.Abstractions
{
    public interface IPotentialUserLogic
    {
        Guid Add(string userCode);
        PotentialUser Remove(Guid id);
        ICollection<string> GetEmails();
    }
}
