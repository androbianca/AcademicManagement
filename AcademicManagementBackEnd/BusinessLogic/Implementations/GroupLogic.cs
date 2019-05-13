using System.Collections.Generic;
using BusinessLogic.Abstractions;
using DataAccess.Abstractions;
using Entities;
using Models;

namespace BusinessLogic.Implementations
{
    public class GroupLogic :BaseLogic,IGroupLogic
    {
        public GroupLogic(IRepository repository)
            : base(repository)
        { }

        public ICollection<GroupDto> getAll()
        {
            var groupDtos = new List<GroupDto>();
            var groups = _repository.GetAll<Group>();
            foreach (var group in groups)
            {
                var groupDto = new GroupDto()
                {
                    Year = group.Year,
                    Id = group.Id,
                    Name = group.Name
                };
                groupDtos.Add(groupDto);
            }

            return groupDtos;
        }
    }
}
