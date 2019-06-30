using BusinessLogic.Abstractions;
using DataAccess.Abstractions;
using Entities;
using Models;
using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using System.Data;

namespace BusinessLogic.Implementations
{
    public class GradeLogic : BaseLogic, IGradeLogic
    {
        private INotificationLogic _notificationLogic;
        private IFinalGradeLogic _finalGradeLogic;

        public GradeLogic(IRepository repository, INotificationLogic notificationLogic, IFinalGradeLogic finalGradeLogic)
            : base(repository)
        {
            _finalGradeLogic = finalGradeLogic;
            _notificationLogic = notificationLogic;

        }

        public ICollection<GradeDto> GetGradesByStud(Guid courseId, Guid studentId)
        {
            var gradeDtos = new List<GradeDto>();
            var grades = _repository.GetAllByFilter<Grade>(x => x.CourseId == courseId && x.StudentId == studentId);

            foreach (var grade in grades)
            {
                var category = _repository.GetByFilter<GradeCategory>(x => x.Id == grade.CategoryId);


                var gradeDto = new GradeDto
                {
                    Id = grade.Id,
                    Value = grade.Value,
                    StudentId = grade.StudentId,
                    ProfId = grade.ProfId,
                    CourseId = grade.CourseId,
                    CategoryId = grade.CategoryId,
                    Category = category.Name


                };

                gradeDtos.Add(gradeDto);
            }

            return gradeDtos;
        }

        public GradeDto GetById(Guid gradeId)
        {
            var grade = _repository.GetByFilter<Grade>(x => x.Id == gradeId);

            if (grade == null)
            {
                return null;
            }

            var gradeDto = new GradeDto()
            {
                StudentId = grade.StudentId,
                ProfId = grade.ProfId,
                CourseId = grade.CourseId,
                Value = grade.Value,
                CategoryId = grade.CategoryId
            };

            return gradeDto;

        }

        public Grade Update(GradeDto gradeDto)
        {
            var grade = _repository.GetByFilter<Grade>(x => x.Id == gradeDto.Id);
            if (grade == null)
            {
                return null;
            }

            grade.Value = gradeDto.Value;

            _repository.Update(grade);
            _repository.Save();

            _finalGradeLogic.ComputeFinalGrade(gradeDto.CourseId, gradeDto.StudentId);

            return grade;
        }

        public Grade Add(GradeDto gradeDto)
        {
            var grade = new Grade()
            {
                StudentId = gradeDto.StudentId,
                ProfId = gradeDto.ProfId,
                CourseId = gradeDto.CourseId,
                Value = gradeDto.Value,
                CategoryId = gradeDto.CategoryId,
                Id = Guid.NewGuid(),
                Date = DateTime.Now

            };

            _repository.Insert(grade);
            _repository.Save();

            var notification = CreateNotification(grade);

            _notificationLogic.Create(notification);

            var final = _finalGradeLogic.ComputeFinalGrade(gradeDto.CourseId, gradeDto.StudentId);

            return grade;

        }


       public double ComputeFinalGrade(Guid courseId,Guid studentId)
        {
            return _finalGradeLogic.ComputeFinalGrade(courseId, studentId);
        }


        private NotificationDto CreateNotification(Grade grade)
        {
            var prof = _repository.GetByFilter<Professor>(x => x.Id == grade.ProfId);
            var course = _repository.GetByFilter<Course>(x => x.Id == grade.CourseId);
            var stud = _repository.GetByFilter<Student>(x => x.Id == grade.StudentId);
            if (prof == null || course == null || stud == null)
            {
                return null;
            }
            var notification = new NotificationDto
            {
                Title = "New grade",
                Body = prof.LastName + ' ' + prof.FirstName + " added a new grade for " + course.Name,
                IsRead = false,
                ReciverId = stud.PotentialUserId,
                SenderId = prof.PotentialUserId,
                ItemId = grade.Id
            };

            return notification;

        }

    }
}
