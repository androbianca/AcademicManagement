using System;
using System.Collections.Generic;
using System.Text;
using Entities;
using Models;

namespace BusinessLogic.Abstractions
{
    public interface IProfLogic
    {
        Professor addProf(ProfDto prof);
    }
}
