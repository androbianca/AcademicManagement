using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
   public class OptionalDto
    {
        public string GoogleForm { get; set; }
        public string Path { get; set; }
        public string Filename { get; set; }
        public int Year { get; set; }
        public Guid Id { get; set; }
    }
}
