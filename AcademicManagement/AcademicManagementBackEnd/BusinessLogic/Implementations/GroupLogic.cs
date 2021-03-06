﻿using System;
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

            group.IsDeleted = true;
            _repository.Update(group);
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
                    IsDeleted = group.IsDeleted,
                    Year = group.Year,
                    Id = group.Id,
                    Name = group.Name
                };


                groupDtos.Add(groupDto);
            }

            return groupDtos;
        }

        public GroupDto GetById(Guid groupId)
        {
            var group = _repository.GetByFilter<Group>(x=> x.Id == groupId);
          
                var groupDto = new GroupDto()
                {
                    IsDeleted = group.IsDeleted,
                    Year = group.Year,
                    Id = group.Id,
                    Name = group.Name
                };

      
            return groupDto;
        }

        public ICollection<GroupDto> getProfGroups(Guid profId, Guid courseId)
        {
            var profStuds = _repository.GetAllByFilter<ProfStuds>(x => x.ProfId == profId && x.CourseId == courseId);
            var groupDtos = new List<GroupDto>();

            foreach (var profStud in profStuds)
            {
                var group = _repository.GetByFilter<Group>(x => x.Id == profStud.GroupId);

                var groupDto = new GroupDto
                {
                    Id = group.Id,
                    Name = group.Name,
                    Year = group.Year
                };

                var item = groupDtos.Find(x => x.Id == groupDto.Id);
                if (item == null)
                {
                    groupDtos.Add(groupDto);

                }
            }

                return groupDtos;
            }
    }
}
