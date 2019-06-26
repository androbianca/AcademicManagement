using System;

namespace Models
{
    public class FormulaDto
    {
      public Guid CourseId { get; set; }
      public Guid StudentId { get; set; }
      public string Formula { get; set; }
    }
}
