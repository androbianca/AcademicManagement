using System;
using System.Collections.Generic;
using System.Text;
using Models;

namespace BusinessLogic.Abstractions
{
    interface IOptionalLogic
    {
        ICollection<OptionalDto> GetAll();
        ICollection<OptionalDto> GetByYear(int year);
    }
}
