﻿using System;

namespace Models
{
    public class GroupDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Year { get; set; }
        public bool IsDeleted { get; set; }

    }
}
