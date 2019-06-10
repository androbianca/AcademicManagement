using Entities;
using Models;

namespace BusinessLogic.Abstractions
{
    public interface IAlertLogic
    {
        AlertDto GetAlert();
        void AddAlert(Alert alert);

    }
}
