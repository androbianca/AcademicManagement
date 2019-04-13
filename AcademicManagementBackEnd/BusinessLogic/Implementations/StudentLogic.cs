using System;
using System.Collections.Generic;
using System.Text;
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

        public ICollection<StudentDto> getByProfId(string id)
        {
            var courses = _courseLogic.GetProfCourses(id);

            return null;

        }
    }
}
