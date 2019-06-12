using BusinessLogic.Abstractions;
using DataAccess.Abstractions;
using Entities;
using Models;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using System.Data;

namespace BusinessLogic.Implementations
{
    public class GradeLogic : BaseLogic, IGradeLogic
    {
        private INotificationLogic _notificationLogic;
        private IFinalGradeLogic _finalGradeLogic;
        private IHttpContextAccessor _httpContextAccessor;
        private HttpContext context;

        public GradeLogic(IRepository repository, INotificationLogic notificationLogic, IFinalGradeLogic finalGradeLogic, IHttpContextAccessor httpContextAccessor)
            : base(repository)
        {
            _finalGradeLogic = finalGradeLogic;
            _notificationLogic = notificationLogic;
            _httpContextAccessor = httpContextAccessor;
            context = httpContextAccessor.HttpContext;

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
                Id = Guid.NewGuid()

            };

            _repository.Insert(grade);
            _repository.Save();

            var notification = CreateNotification(grade);

            _notificationLogic.Create(notification);

            var final = ComputeFinalGrade(gradeDto.CourseId, gradeDto.StudentId);

            var finalGrade = _repository.GetByFilter<FinalGrade>(x => x.StudentId == gradeDto.StudentId && x.CourseId == gradeDto.CourseId);
            if (finalGrade == null)
            {
                return null;
            }
            finalGrade.Value = final;
            _finalGradeLogic.Update(finalGrade);

            return grade;

        }

        public async Task<bool> SendAlert()
        {
            // var t = _httpContextAccessor.HttpContext;
            //.Request.Headers["Authorization"];

            var handler = new JwtSecurityTokenHandler();
            //  var token = handler.ReadToken(headerValue) as JwtSecurityToken;
            // var id = token.Claims.FirstOrDefault(c => c.Type == "Identifier").Value;

            return true;
        }

        public double ComputeFinalGrade(Guid courseId, Guid studentId)
        {
            var grades = this.GetGradesByStud(courseId, studentId);
            var courseGradeCategories = _repository.GetAllByFilter<GradeCategory>(x => x.CourseId == courseId);

            if (courseGradeCategories == null)
            {
                return 0;
            }

            var courseFormula = _repository.GetByFilter<CourseFormula>(x => x.CourseId == courseId);

            if(courseFormula == null)
            {
                return 0;
            }

            var formula = courseFormula.Formula;

            Dictionary<string, string> categoryGrade = new Dictionary<string, string>();

            foreach(var courseCategory in courseGradeCategories){
                categoryGrade.Add(courseCategory.Name, "0");
            }
            foreach (var grade in grades)
            {
                var category = _repository.GetByFilter<GradeCategory>(x => x.Id == grade.CategoryId);
                categoryGrade[category.Name] = grade.Value.ToString();

            }

            foreach (KeyValuePair<string, string> entry in categoryGrade)
            {
                formula = formula.Replace(entry.Key, entry.Value);
            }

            DataTable dt = new DataTable();
            var result = dt.Compute(formula,"").ToString();

            return Math.Round(Convert.ToDouble(result), 2);
        }

        //public float ComputeLabFinalGrade(Guid courseId, Guid studentId)
        //{
        //    var finalGrades = _repository.GetAll<FinalGrade>();

        //    if(finalGrades.Count == 0)
        //    {
        //        _finalGradeLogic.AddAll();
        //    };

        //    float lab = 0;
        //    float final = 0;
        //    var remainingPercentage = 0;
        //    var percentage = 0;

        //    var grades = this.GetGradesByStud(courseId, studentId);
        //    foreach (var grade in grades)
        //    {
        //        var category = _repository.GetByFilter<GradeCategory>(x => x.Id == grade.CategoryId && x.IsCourseCategory == false);
        //        if (category != null)
        //        {
        //            var number = category.Percentage;
        //            lab += (number * grade.Value) / 100;
        //        }
        //    }

        //    foreach (var grade in grades)
        //    {
        //        var category = _repository.GetByFilter<GradeCategory>(x => x.Id == grade.CategoryId && x.IsCourseCategory == true);
        //        if (category != null)
        //        {
        //            var number = category.Percentage;
        //            percentage += number;
        //            final += (number * grade.Value) / 100;
        //        }
        //    }
        //    remainingPercentage = 100 - percentage;
        //    final += (remainingPercentage * lab) / 100;

        //    return (float)System.Math.Round(final,2);
        //}

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
