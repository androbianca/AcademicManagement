using System;

namespace BusinessLogic.Abstractions
{
    public interface IPotentialUserLogic
    {
        Guid AddPotentialUser(string userCode);
    }
}
