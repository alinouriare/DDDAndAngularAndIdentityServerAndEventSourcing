using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.FileEntries.DTOs
{
    public class FileUploadedEvent
    {
        public FileEntry FileEntry { get; set; }
    }
}
