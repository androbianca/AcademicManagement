﻿using System;
using System.Collections.Generic;

namespace Entities
{
    public class Student : BaseUser
    {
        public Guid PotentialUserId { get; set; }

        public PotentialUser PotentialUser { get; set; }

        public Guid GroupId { get; set; }

        public Group Group { get; set; }

        public bool IsDeleted { get; set; }

        public IEnumerable<StudCourse> Courses { get; set; }

        public IEnumerable<Grade> Grades { get; set; }

        public IEnumerable<Feedback> Feedback { get; set; }



    }
}
