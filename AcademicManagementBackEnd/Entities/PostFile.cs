using System;

namespace Entities
{
    public class PostFile : BaseEntity
    {
        public Guid UploadedFileId { get; set; }
        public Guid PostId { get; set; }
    }
}
