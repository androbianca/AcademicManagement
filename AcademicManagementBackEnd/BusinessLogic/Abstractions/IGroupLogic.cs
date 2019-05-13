using System.Collections.Generic;
using Models;

namespace BusinessLogic.Abstractions
{
    public interface IGroupLogic
   {
       ICollection<GroupDto> getAll();
   }
}
