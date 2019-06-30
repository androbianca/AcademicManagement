using BusinessLogic.Abstractions;
using DataAccess.Abstractions;
using Entities;
using Models;
using System;
using System.Collections.Generic;
using System.Data;

namespace BusinessLogic.Implementations
{
    public class FinalGradeLogic : BaseLogic, IFinalGradeLogic
    {
        public FinalGradeLogic(IRepository repository)
            : base(repository)
        {
        }



        public FinalGrade Update(FinalGradeDto finalGradeDto)
        {
            var finalGrade = _repository.GetByFilter<FinalGrade>(x => x.StudentId == finalGradeDto.StudentId && x.CourseId == finalGradeDto.CourseId);

            if (finalGrade == null)
            {
                return null;
            }

            finalGrade.Value = finalGradeDto.Value;
            _repository.Update(finalGrade);
            _repository.Save();

            return finalGrade;
        }


        public void AddFinalGradeToMandatoryCourses(Guid studentId)
        {
            var stud = _repository.GetByFilter<Student>(x => x.Id == studentId);
            var group = _repository.GetByFilter<Group>(x => x.Id == stud.GroupId);
            var courses = _repository.GetAllByFilter<Course>(x => x.Package == null && x.Year <= group.Year);

            foreach (var course in courses)
            {
                var finalGrade = new FinalGrade
                {
                    CourseId = course.Id,
                    StudentId = studentId,
                    Value = 0
                };

                _repository.Insert(finalGrade);
                _repository.Save();
            }

        }

        public void AddFinalGradeToOptionalCourses(Guid studentId, Guid courseId)
        {
            {
                var finalGrade = new FinalGrade
                {
                    CourseId = courseId,
                    StudentId = studentId,
                    Value = 0
                };

                _repository.Insert(finalGrade);
                _repository.Save();
            }

        }


        public void AddAll()
        {
            var students = _repository.GetAll<Student>();
            var courses = _repository.GetAllByFilter<Course>(x => x.Package == null);

            foreach (var student in students)
            {
                var optionals = _repository.GetAllByFilter<StudCourse>(x => x.StudId == student.Id);

                foreach (var optional in optionals)
                {
                    var finalGrade = new FinalGrade
                    {
                        CourseId = optional.CourseId,
                        StudentId = student.Id,
                        Value = 0
                    };

                    _repository.Insert(finalGrade);
                    _repository.Save();
                }

                foreach (var course in courses)
                {
                    var finalGrade = new FinalGrade
                    {
                        CourseId = course.Id,
                        StudentId = student.Id,
                        Value = 0
                    };

                    _repository.Insert(finalGrade);
                    _repository.Save();
                }

            }
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

        public double ComputeFinalGrade(Guid courseId, Guid studentId)
        {

            var finalGrades = _repository.GetAll<FinalGrade>();

            if (finalGrades.Count == 0)
            {
                AddAll();
            };

            var grades = GetGradesByStud(courseId, studentId);
            var courseGradeCategories = _repository.GetAllByFilter<GradeCategory>(x => x.CourseId == courseId);

            if (courseGradeCategories.Count == 0)
            {
                return 0;
            }

            var courseFormula = _repository.GetByFilter<CourseFormula>(x => x.CourseId == courseId);

            if (courseFormula == null)
            {
                return 0;
            }

            var formula = courseFormula.Formula.ToLower();

            Dictionary<string, string> categoryGrade = new Dictionary<string, string>();

            foreach (var courseCategory in courseGradeCategories)
            {
                categoryGrade.Add(courseCategory.Name.ToLower(), "0");
            }
            foreach (var grade in grades)
            {
                var category = _repository.GetByFilter<GradeCategory>(x => x.Id == grade.CategoryId);
                categoryGrade[category.Name.ToLower()] = grade.Value.ToString();

            }

            foreach (KeyValuePair<string, string> entry in categoryGrade)
            {
                formula = formula.Replace(entry.Key, entry.Value);
            }

            DataTable dt = new DataTable();
            var result = dt.Compute(formula, "").ToString();
            var finalGrade = Math.Round(Convert.ToDouble(result), 2);

            UpdateFinalGrade(courseId, studentId, finalGrade);

            return finalGrade;
        }

        private void UpdateFinalGrade(Guid courseId, Guid studentId, double value)
        {
            var finalGradeDto = new FinalGradeDto
            {
                CourseId = courseId,
                StudentId = studentId,
                Value = value

            };

            Update(finalGradeDto);
        }


        public IEnumerable<FinalGradeDto> GetAllByCourseId(Guid courseId)
        {

            var profStuds = _repository.GetAll<ProfStuds>();

            foreach (var profStud in profStuds)
            {
                var students = _repository.GetAllByFilter<Student>(x => x.GroupId == profStud.GroupId);

                foreach (var student in students)
                {
                    ComputeFinalGrade(profStud.CourseId, student.Id);
                }
            }
            var gradeDtos = new List<FinalGradeDto>();
            var grades = _repository.GetAllByFilter<FinalGrade>(x => x.CourseId == courseId);

            foreach (var grade in grades)
            {
                var finalGrade = new FinalGradeDto
                {
                    Value = grade.Value
                };

                if (finalGrade.Value > 0)
                {
                    gradeDtos.Add(finalGrade);
                }

            }

            return gradeDtos;
        }
    }
}
