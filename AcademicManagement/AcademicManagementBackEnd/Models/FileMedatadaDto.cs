using System;

namespace Models
{
    public class FileMetadataDto
    {
        public Guid CourseId { get; set; }
        public string Path { get; set; }
        public string FileName { get; set; }
    }
}
