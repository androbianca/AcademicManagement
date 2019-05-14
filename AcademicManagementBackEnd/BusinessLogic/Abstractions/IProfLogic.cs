using Entities;
using Models;
using System;
using System.Collections.Generic;

namespace BusinessLogic.Abstractions
{
    public interface IProfLogic
    {
        Professor Add(ProfDto prof);
        Professor Remove(Guid id);
        ICollection<ProfDto> GetAll();
        }
}
