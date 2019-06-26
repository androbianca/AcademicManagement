using Entities;
using Models;

namespace BusinessLogic.Abstractions
{
    public interface IAlertLogic
    {
        AlertDto GetAlert(string userCode);
        void AddAlert(Alert alert);

    }
}
