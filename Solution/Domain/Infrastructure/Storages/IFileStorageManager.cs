using Domain.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Domain.Infrastructure.Storages
{
    public interface IFileStorageManager
    {
        void Create(FileEntry fileEntry, MemoryStream stream);
        byte[] Read(FileEntry fileEntry);
        void Delete(FileEntry fileEntry);
    }
}
