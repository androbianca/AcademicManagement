using System;
using System.Collections.Generic;
using System.Text;
using Models;

namespace BusinessLogic.Abstractions
{
   public interface IGroupLogic
   {
       ICollection<GroupDto> getAll();
   }
}
