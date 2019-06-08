using Entities;
using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogic.Abstractions
{
    public interface IAlertLogic
    {
        AlertDto GetAlert();
        void AddAlert(Alert alert);

    }
}
