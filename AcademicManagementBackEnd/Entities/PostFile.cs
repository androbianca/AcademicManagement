using System;
using System.Collections.Generic;
using System.Text;

namespace Entities
{
    public class PostFile : BaseEntity
    {
        public Guid UploadedFileId { get; set; }
        public Guid PostId { get; set; }
    }
}
