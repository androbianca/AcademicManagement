using BusinessLogic.Abstractions;
using DataAccess.Abstractions;
using Entities;
using Models;
using System;
using System.Collections.Generic;

namespace BusinessLogic.Implementations
{
    public class GradeLogic :BaseLogic, IGradeLogic
    {
        private INotificationLogic _notificationLogic;

        public GradeLogic(IRepository repository, INotificationLogic notificationLogic)
            : base(repository)
        {
            _notificationLogic = notificationLogic; }

        public ICollection<GradeDto> GetGradesByStud(Guid courseId,Guid studentId)
        {
            var gradeDtos = new List<GradeDto>();
            var grades = _repository.GetAllByFilter<Grade>(x => x.CourseId == courseId && x.StudentId == studentId);
           
            foreach (var grade in grades)
            {
                var category = _repository.GetByFilter<GradeCategory>(x => x.Id == grade.CategoryId);


                var gradeDto = new GradeDto
                {
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

        public void Add(GradeDto gradeDto)
        {
            var grade = new Grade()
            {
                StudentId = gradeDto.StudentId,
                ProfId = gradeDto.ProfId,
                CourseId = gradeDto.CourseId,
                Value = gradeDto.Value,
                CategoryId = gradeDto.CategoryId

            };

            _repository.Insert(grade);
            _repository.Save();

            var notification = CreateNotification(gradeDto);

            _notificationLogic.Create(notification);


        }

        public float ComputeLabFinalGrade(Guid courseId, Guid studentId)
       {
            float sum = 0;
            var grades = this.GetGradesByStud(courseId, studentId);
            foreach(var grade in grades){
                var category = _repository.GetByFilter<GradeCategory>(x => x.Id == grade.CategoryId);
                var number = category.Percentage;
                sum += (number*grade.Value)/100;
            }

            return sum;
        }

        private NotificationDto CreateNotification(GradeDto gradeDto)
        {
            var prof = _repository.GetByFilter<Professor>(x => x.Id == gradeDto.ProfId);
            var course = _repository.GetByFilter<Course>(x => x.Id == gradeDto.CourseId);
            var stud = _repository.GetByFilter<Student>(x => x.Id == gradeDto.StudentId);
            var notification = new NotificationDto
            {
                Title = "New grade",
                Body = prof.FirstName + " added a new grade for " + course.Name,
                IsRead = false,
                ReciverId = stud.PotentialUserId,
                SenderId = prof.PotentialUserId
            };

            return notification;

        }
    }
}
