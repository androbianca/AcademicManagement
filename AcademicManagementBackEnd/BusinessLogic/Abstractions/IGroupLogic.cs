using System;
using System.Collections.Generic;
using Entities;
using Models;

namespace BusinessLogic.Abstractions
{
    public interface IGroupLogic
    {
        ICollection<GroupDto> GetAll();
        Group Add(GroupDto group);
        Group Remove(Guid groupId);
        ICollection<GroupDto> getProfGroups(Guid profId, Guid courseId);



    }
}
