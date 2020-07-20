using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.FileEntries.DTOs
{
    public class FileDeletedEvent
    {
        public FileEntry FileEntry { get; set; }
    }
}
