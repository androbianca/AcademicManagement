using System;
using System.Collections.Generic;
using BusinessLogic.Abstractions;
using DataAccess.Abstractions;
using Entities;
using Models;

namespace BusinessLogic.Implementations
{
    public class StudentLogic : BaseLogic,IStudentLogic
    {
        private ICourseLogic _courseLogic;
        public StudentLogic(IRepository repository, ICourseLogic courseLogic)
            : base(repository)
        {
            _courseLogic = courseLogic;
        }

        public ICollection<StudentDto> getByProfId(string userCode, Guid courseId)
        {
            var students = new List<Student>();
            var studentDtos = new List<StudentDto>();
            var groups = new List<Group>();
            var potentialUserId = _repository.GetByFilter<PotentialUser>(x => x.UserCode == userCode).Id;
            var prof = _repository.GetByFilter<Professor>(x => x.PotentialUserId == potentialUserId);
            var profStuds = _repository.GetAllByFilter<ProfStuds>(x => x.CourseId == courseId && x.ProfId == prof.Id);

            foreach (var profStud in profStuds)
            {
                var group = _repository.GetByFilter<Group>(x => x.Id == profStud.GroupId);

                groups.Add(group);

            }

            foreach (var group in groups)
            {
                var student = _repository.GetAllByFilter<Student>(x => x.GroupId == group.Id);

                students.AddRange(student);
            }

            foreach (var student in students)
            {
                var usercode = _repository.GetByFilter<PotentialUser>(x => x.Id == student.PotentialUserId).UserCode;
                var studentDto = new StudentDto
                {
                    Id = student.Id,
                    LastName = student.LastName,
                    FirstName = student.FirstName,
                    Year = student.Group.Year,
                    Group = student.Group.Name

                };

                studentDtos.Add(studentDto);

            }
            return studentDtos;

        }

    }
}
