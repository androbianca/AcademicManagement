using BusinessLogic.Abstractions;
using DataAccess.Abstractions;
using Entities;
using Models;
using System;
using System.Collections.Generic;

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

        public void Update(GradeDto gradeDto)
        {
            var grade = _repository.GetByFilter<Grade>(x => x.Id == gradeDto.Id);
            grade.Value = gradeDto.Value;
 
            _repository.Update(grade);
            _repository.Save();
        }

        public void Add(GradeDto gradeDto)
        {
            var grade = new Grade()
            {
                StudentId = gradeDto.StudentId,
                ProfId = gradeDto.ProfId,
                CourseId = gradeDto.CourseId,
                Value = gradeDto.Value,
                CategoryId = gradeDto.CategoryId,
                Id = Guid.NewGuid()

            };

            _repository.Insert(grade);
            _repository.Save();

            var notification = CreateNotification(grade);

            _notificationLogic.Create(notification);

            var final = ComputeLabFinalGrade(gradeDto.CourseId, gradeDto.StudentId);

            var finalGrade = _repository.GetByFilter<FinalGrade>(x => x.StudentId == gradeDto.StudentId && x.CourseId == gradeDto.CourseId);
            finalGrade.Value = final;
            _finalGradeLogic.Update(finalGrade);

        }

        public float ComputeLabFinalGrade(Guid courseId, Guid studentId)
        {
            var finalGrades = _repository.GetAll<FinalGrade>();

            if(finalGrades.Count == 0)
            {
                _finalGradeLogic.AddAll();
            };

            float lab = 0;
            float final = 0;
            var remainingPercentage = 0;
            var percentage = 0;

            var grades = this.GetGradesByStud(courseId, studentId);
            foreach (var grade in grades)
            {
                var category = _repository.GetByFilter<GradeCategory>(x => x.Id == grade.CategoryId && x.IsCourseCategory == false);
                if (category != null)
                {
                    var number = category.Percentage;
                    lab += (number * grade.Value) / 100;
                }
            }

            foreach (var grade in grades)
            {
                var category = _repository.GetByFilter<GradeCategory>(x => x.Id == grade.CategoryId && x.IsCourseCategory == true);
                if (category != null)
                {
                    var number = category.Percentage;
                    percentage += number;
                    final += (number * grade.Value) / 100;
                }
            }
            remainingPercentage = 100 - percentage;
            final += (remainingPercentage * lab) / 100;

            return (float)System.Math.Round(final,2);
        }

        private NotificationDto CreateNotification(Grade grade)
        {
            var prof = _repository.GetByFilter<Professor>(x => x.Id == grade.ProfId);
            var course = _repository.GetByFilter<Course>(x => x.Id == grade.CourseId);
            var stud = _repository.GetByFilter<Student>(x => x.Id == grade.StudentId);
            var notification = new NotificationDto
            {
                Title = "New grade",
                Body =prof.LastName + ' ' + prof.FirstName + " added a new grade for " + course.Name,
                IsRead = false,
                ReciverId = stud.PotentialUserId,
                SenderId = prof.PotentialUserId,
                ItemId = grade.Id
            };

            return notification;

        }
    }
}
