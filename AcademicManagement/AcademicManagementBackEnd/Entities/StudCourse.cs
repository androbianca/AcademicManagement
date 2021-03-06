﻿using System;

namespace Entities
{
   public class StudCourse : BaseEntity
    {
        public Guid CourseId { get; set; }

        public Guid StudId { get; set; }

        public Course Course { get; set; }

        public Student Student { get; set; }
    }
}
