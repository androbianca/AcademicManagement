using System;
using DataAccess.Abstractions;

namespace BusinessLogic.Implementations
{
    public class BaseLogic
    {
        protected readonly IRepository _repository;

        public BaseLogic(IRepository repository)
        {
            _repository = repository ?? throw new ArgumentNullException();
        }
    }
}
