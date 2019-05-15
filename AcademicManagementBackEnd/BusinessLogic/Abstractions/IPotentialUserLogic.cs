using Entities;
using System;

namespace BusinessLogic.Abstractions
{
    public interface IPotentialUserLogic
    {
        Guid Add(string userCode);
        PotentialUser Remove(Guid id);
    }
}
