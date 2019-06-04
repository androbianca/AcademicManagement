using System;
using System.Collections.Generic;
using BusinessLogic.Abstractions;
using DataAccess.Abstractions;
using Entities;
using Models;

namespace BusinessLogic.Implementations
{
    public class ProfLogic : BaseLogic, IProfLogic
    {
        public ProfLogic(IRepository repository) : base(repository)
        {
        }

        public ICollection<ProfDto> GetAll()
        {
            var profDtos = new List<ProfDto>();
            var profs = _repository.GetAll<Professor>();

            foreach (var prof in profs)
            {
                var profDto = new ProfDto
                {
                    IsDeleted = prof.IsDeleted,
                    FirstName = prof.FirstName,
                    LastName = prof.LastName,
                    PotentialUserId = prof.PotentialUserId,
                    Id = prof.Id
                };

                profDtos.Add(profDto);
            }

            return profDtos;
        }

        public Professor Remove(Guid id)
        {
            var prof = _repository.GetByFilter<Professor>(x => x.Id == id);
            prof.IsDeleted = true;
            _repository.Update(prof);
            _repository.Save();

            return prof;
        }

        public Professor Add(ProfDto profDto)
        {
            var prof = new Professor
            {
                Id = Guid.NewGuid(),
                FirstName = profDto.FirstName,
                LastName = profDto.LastName,
                PotentialUserId = profDto.PotentialUserId

            };
            _repository.Insert(prof);
            _repository.Save();

            return prof;
        }

        public ICollection<ProfDto> GetByCourseId(Guid courseId)
        {
            var profDtos = new List<ProfDto>();
            var profStuds = _repository.GetAllByFilter<ProfStuds>(x => x.CourseId == courseId);

            foreach (var profStud in profStuds)
            {
                var prof = _repository.GetByFilter<Professor>(x => x.Id == profStud.ProfId);

                var profDto = new ProfDto
                {
                    FirstName = prof.FirstName,
                    LastName = prof.LastName,
                    Id = prof.Id
                };

                profDtos.Add(profDto);

            }
            return profDtos;

        }



        public ProfDto GetById(string userCode)
        {

            var potentialUser = _repository.GetByFilter<PotentialUser>(x => x.UserCode == userCode);

            var professor = _repository.GetByFilter<Professor>(x => x.PotentialUserId == potentialUser.Id);
            var profDto = new ProfDto
            {
                Id = professor.Id,
                LastName = professor.LastName,
                FirstName = professor.FirstName,
            };

            return profDto;
        }
    }
}
