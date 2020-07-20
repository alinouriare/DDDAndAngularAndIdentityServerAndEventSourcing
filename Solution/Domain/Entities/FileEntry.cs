using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class FileEntry : AggregateRoot<Guid>
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public long Size { get; set; }

        public DateTime UploadedTime { get; set; }

        public string FileName { get; set; }

        public string FileLocation { get; set; }
    }
}
