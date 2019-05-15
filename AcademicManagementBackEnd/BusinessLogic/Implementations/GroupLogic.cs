using System;
using System.Collections.Generic;
using BusinessLogic.Abstractions;
using DataAccess.Abstractions;
using Entities;
using Models;

namespace BusinessLogic.Implementations
{
    public class GroupLogic : BaseLogic, IGroupLogic
    {
        public GroupLogic(IRepository repository)
            : base(repository)
        { }

        public Group Add(GroupDto groupDto)
        {
            var group = new Group
            {
                Id = Guid.NewGuid(),
                Name = groupDto.Name,
                Year = groupDto.Year
            };

            _repository.Insert(group);
            _repository.Save();

            return group;
        }

        public Group Remove(Guid groupId)
        {

            var group = _repository.GetByFilter<Group>(x => x.Id == groupId);
            _repository.Delete(group);
            _repository.Save();

            return group;
        }
        public ICollection<GroupDto> GetAll()
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
