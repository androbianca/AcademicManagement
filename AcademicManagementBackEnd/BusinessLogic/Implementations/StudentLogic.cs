using System;
using System.Collections.Generic;
using BusinessLogic.Abstractions;
using DataAccess.Abstractions;
using Entities;
using Models;

namespace BusinessLogic.Implementations
{
    public class StudentLogic : BaseLogic, IStudentLogic
    {
        private ICourseLogic _courseLogic;
        public StudentLogic(IRepository repository, ICourseLogic courseLogic)
            : base(repository)
        {
            _courseLogic = courseLogic;
        }

        public ICollection<StudentDto> GetByProfId(string userCode, Guid courseId)
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
                    GroupId = student.GroupId
                };

                studentDtos.Add(studentDto);
            }

            return studentDtos;
        }

        public StudentDto GetByUserCode(string userCode)
        {

            var potentialUser = _repository.GetByFilter<PotentialUser>(x => x.UserCode == userCode);

            var student = _repository.GetByFilter<Student>(x => x.PotentialUserId == potentialUser.Id);
            var studentDto = new StudentDto
            {
                Id = student.Id,
                LastName = student.LastName,
                FirstName = student.FirstName,
                GroupId = student.GroupId
            };

            return studentDto;
        }

        public StudentDto GetById(Guid id)
        {
            var student = _repository.GetByFilter<Student>(x => x.Id == id);

            if(student == null)
            {
                return null;
            }
            var studentDto = new StudentDto
            {
                Id = student.Id,
                LastName = student.LastName,
                FirstName = student.FirstName,
                GroupId = student.GroupId
            };

            return studentDto;
        }

        public Student Add(StudentDto studentDto)
        {
            var student = new Student
            {
                Id = Guid.NewGuid(),
                GroupId = studentDto.GroupId,
                FirstName = studentDto.FirstName,
                LastName = studentDto.LastName,
                PotentialUserId = studentDto.PotentialUserId
            };

            _repository.Insert(student);
            _repository.Save();

            return student;
        }

        public ICollection<StudentDto> GetAll()
        {
            var students = _repository.GetAll<Student>();
            var studentDtos = new List<StudentDto>();

            foreach (var student in students)
            {
                var studentDto = new StudentDto
                {
                    IsDeleted = student.IsDeleted,
                    FirstName = student.FirstName,
                    LastName = student.LastName,
                    Id = student.Id
                };

                studentDtos.Add(studentDto);
            }

            return studentDtos;
        }

        public Student Remove(Guid studentId)
        {
            var student = _repository.GetByFilter<Student>(x => x.Id == studentId);
            student.IsDeleted = true;
            _repository.Update(student);
            _repository.Save();

            return student;

        }
    }
}
